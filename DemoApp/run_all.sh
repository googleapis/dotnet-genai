#!/bin/bash

# Script to run or build all Interactions demos.

MODE="run"
if [ "$1" == "build" ]; then
  MODE="build"
fi

echo "Mode: $MODE"

# Get the directory of this script
SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )"
cd "$SCRIPT_DIR"

declare -A RESULTS

while read -r csproj; do
  # Skip Live examples, obj and bin directories
  if [[ "$csproj" == *"Live"* ]] || [[ "$csproj" == *"/obj/"* ]] || [[ "$csproj" == *"/bin/"* ]]; then
    continue
  fi
  
  dir=$(dirname "$csproj")
  # Remove ./ prefix
  dir_name="${dir#./}"

  echo "----------------------------------------"
  echo "Processing $dir_name ..."
  
  if [ "$MODE" == "build" ]; then
    dotnet build "$csproj" < /dev/null
    res=$?
  else
    dotnet run --project "$csproj" < /dev/null
    res=$?
  fi

  if [ $res -eq 0 ]; then
    RESULTS["$dir_name"]="CHECK"
  else
    RESULTS["$dir_name"]="X"
  fi
done < <(find . -name "*.csproj")

echo "========================================"
echo "Summary Report Card:"
echo "========================================"

for dir_name in "${!RESULTS[@]}"; do
  symbol="${RESULTS[$dir_name]}"
  if [ "$symbol" == "CHECK" ]; then
    echo "✅ $dir_name"
  else
    echo "❌ $dir_name"
  fi
done
