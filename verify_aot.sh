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

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
AOT_PROJECT="${SCRIPT_DIR}/Google.GenAI.Tests/AotTestApp/AotTestApp.csproj"

echo "=========================================================="
echo "1. Verifying Native AOT publish for Core / GenerateContent"
echo "=========================================================="
PUBLISH_DIR="${SCRIPT_DIR}/Google.GenAI.Tests/AotTestApp/bin/aot_publish"
rm -rf "${PUBLISH_DIR}"
dotnet publish "${AOT_PROJECT}" -c Release -o "${PUBLISH_DIR}"

if [[ -f "${PUBLISH_DIR}/AotTestApp" ]]; then
  AOT_BIN="${PUBLISH_DIR}/AotTestApp"
elif [[ -f "${PUBLISH_DIR}/AotTestApp.exe" ]]; then
  AOT_BIN="${PUBLISH_DIR}/AotTestApp.exe"
else
  echo "ERROR: Native AOT binary not found in publish directory: ${PUBLISH_DIR}"
  exit 1
fi
echo "==> Executing compiled Native AOT binary at ${AOT_BIN}..."
"${AOT_BIN}"

echo ""
echo "=========================================================="
echo "2. Verifying Interactions triggers Native AOT trim and dynamic code errors"
echo "=========================================================="
set +e
INTERACTIONS_OUTPUT=$(dotnet build "${AOT_PROJECT}" -c Release /p:TestInteractions=true 2>&1)
INTERACTIONS_STATUS=$?
set -e

if [[ ${INTERACTIONS_STATUS} -eq 0 ]]; then
  echo "ERROR: Expected compilation to fail when referencing Interactions under Native AOT, but it succeeded!"
  exit 1
fi

if echo "${INTERACTIONS_OUTPUT}" | grep -q -E "IL2026|IL3050"; then
  echo "==> Successfully verified that accessing Interactions triggers Native AOT trim / dynamic code diagnostics (IL2026 / IL3050)."
else
  echo "ERROR: Expected IL2026 / IL3050 diagnostic in compiler output, but got:"
  echo "${INTERACTIONS_OUTPUT}"
  exit 1
fi

echo ""
echo "==> All Native AOT verification checks passed!"
