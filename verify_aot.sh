#!/bin/bash
# Copyright 2026 Google LLC
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#      https://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

# Verifies that Google.GenAI is Native AOT compatible:
#   1. Publishes Google.GenAI.Tests/AotTestApp with Native AOT. The app roots the whole
#      AOT-compatible surface of Google.GenAI (see TrimmerRoots.xml).
#   2. Fails if the AOT compiler reports any trim or AOT warning in Google.GenAI.
#   3. Runs the published app, which exercises the client end to end against a local server.
# All steps run even if an earlier one fails, so every gap is reported at once.

set -uo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
AOT_DIR="${SCRIPT_DIR}/Google.GenAI.Tests/AotTestApp"
AOT_PROJECT="${AOT_DIR}/AotTestApp.csproj"
PUBLISH_DIR="${AOT_DIR}/bin/aot_publish"
PUBLISH_LOG="${AOT_DIR}/bin/aot_publish.log"
# Upper bound for running the published binary, in seconds.
RUN_TIMEOUT=300
FAILURES=()

echo "=========================================================="
echo "1. Publishing AotTestApp with Native AOT"
echo "=========================================================="
# The AOT compiler only reports warnings when it runs, so never publish incrementally.
rm -rf "${AOT_DIR}/bin" "${AOT_DIR}/obj"
mkdir -p "${AOT_DIR}/bin"
PUBLISH_OK=true
if ! dotnet publish "${AOT_PROJECT}" -c Release -o "${PUBLISH_DIR}" 2>&1 | tee "${PUBLISH_LOG}"; then
  PUBLISH_OK=false
  FAILURES+=("Native AOT publish failed")
fi

echo ""
echo "=========================================================="
echo "2. Checking for trim and AOT warnings in Google.GenAI"
echo "=========================================================="
if [[ "${PUBLISH_OK}" != true ]]; then
  echo "ERROR: Skipped because the publish failed; the AOT compiler may not have run."
else
  # AOT compiler warnings name the member that causes them. Google.GenAI also defines types in the
  # Microsoft.Extensions.AI namespace (the IChatClient and other adapters). IL2104/IL3053 summary
  # warnings for the assembly as a whole are matched too, in case per-member reporting is lost.
  GENAI_WARNINGS=$(grep -E "warning IL[0-9]+: ((Google\.GenAI|Microsoft\.Extensions\.AI)[.:]|Assembly 'Google\.GenAI')" "${PUBLISH_LOG}" \
    | sed -E 's/ \[[^]]*\]$//' | sort -u || true)
  if [[ -n "${GENAI_WARNINGS}" ]]; then
    echo "ERROR: The AOT compiler reported trim or AOT warnings in Google.GenAI:"
    echo "${GENAI_WARNINGS}"
    FAILURES+=("trim/AOT warnings in Google.GenAI")
  else
    echo "==> No trim or AOT warnings in Google.GenAI."
  fi
fi

echo ""
echo "=========================================================="
echo "3. Running the Native AOT binary"
echo "=========================================================="
if [[ -f "${PUBLISH_DIR}/AotTestApp" ]]; then
  AOT_BIN="${PUBLISH_DIR}/AotTestApp"
elif [[ -f "${PUBLISH_DIR}/AotTestApp.exe" ]]; then
  AOT_BIN="${PUBLISH_DIR}/AotTestApp.exe"
else
  AOT_BIN=""
fi
RUN=()
if command -v timeout > /dev/null; then
  RUN=(timeout "${RUN_TIMEOUT}")
fi
if [[ -z "${AOT_BIN}" ]]; then
  echo "ERROR: Native AOT binary not found in ${PUBLISH_DIR}"
  FAILURES+=("Native AOT binary not found")
elif ! ${RUN[@]+"${RUN[@]}"} "${AOT_BIN}"; then
  FAILURES+=("Native AOT binary checks failed (or timed out after ${RUN_TIMEOUT}s)")
fi

echo ""
if [[ ${#FAILURES[@]} -gt 0 ]]; then
  echo "ERROR: Native AOT verification failed:"
  printf '  - %s\n' "${FAILURES[@]}"
  exit 1
fi
echo "==> All Native AOT verification checks passed!"
