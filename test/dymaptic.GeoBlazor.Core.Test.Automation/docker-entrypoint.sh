#!/bin/bash
set -e

COVERAGE_FILE_VERSION="$(date +%Y-%m-%d-%H-%M-%S)"
# The main Web app
if SESSION_ID="WEB_APP"; then
    COVERAGE_OUTPUT="/coverage/coverage.$COVERAGE_FILE_VERSION.$COVERAGE_FORMAT"
# The unit/sgen tests
else
    lowercase="${SESSION_ID,,}"
    COVERAGE_OUTPUT="/unit-coverage/coverage.$lowercase.$COVERAGE_FILE_VERSION.$COVERAGE_FORMAT"
fi

echo "SESSION_ID: " "$SESSION_ID"
echo "CONTAINER_CHECK: " "$CONTAINER_CHECK"

if [ "$CONTAINER_CHECK" = "True" ]; then
  exec bash
  return
fi

# Trap SIGTERM to gracefully shutdown coverage collection
_term() {
    echo "Received SIGTERM, shutting down coverage collection..."
    if [ "$COVER" = "true" ]; then
        # Use dotnet-coverage shutdown to gracefully stop and write coverage
        /tools/dotnet-coverage shutdown "$SESSION_ID" 2>&1 || true
        echo "Coverage shutdown command sent"
        # Give it time to write the coverage file
        sleep 5
        echo "Coverage directory contents:"
        ls -la "$(dirname "$COVERAGE_OUTPUT")" || true
    fi
}

trap _term SIGTERM SIGINT

if [ -n "$TEST_PROJECT" ]; then
  RUN_COMMAND=("exec" "dotnet" "run" "--project" "$TEST_PROJECT" "-c" "Release" "--no-build")
else
  RUN_COMMAND=("$@")
fi

if [ -n "$FILTER" ]; then
  RUN_COMMAND+=("--filter" "$FILTER")
fi

echo "RUN COMMAND: " "${RUN_COMMAND[@]}"

echo "COVERAGE ENABLED: " "$COVER"

if [ "$COVER" = "True" ]; then
    echo "Starting with code coverage collection in server mode..."
    echo "Session ID: $SESSION_ID"
    echo "Coverage output: $COVERAGE_OUTPUT"

    # Start dotnet-coverage in server mode with session ID
    # Note: We collect ALL assemblies (no --include-files filter) to capture
    # GeoBlazor code that executes through test assemblies and the web app.
    # The GeoBlazor Core and Pro DLLs are still in the report but may show low
    # coverage because most component logic runs in JavaScript (ArcGIS SDK).
    echo "Starting dotnet-coverage with verbose logging..."
    /tools/dotnet-coverage collect \
        --session-id "$SESSION_ID" \
        -o "$COVERAGE_OUTPUT" \
        -f "$COVERAGE_FORMAT" \
        --include-files "**/dymaptic.GeoBlazor.Core.dll" \
        --include-files "**/dymaptic.GeoBlazor.Pro.dll" \
        --include-files "**/dymaptic.GeoBlazor.Core.SourceGenerator.dll" \
        --include-files "**/dymaptic.GeoBlazor.Pro.SourceGenerator.dll" \
        --include-files "**/dymaptic.GeoBlazor.Core.SourceGenerator.Shared.dll" \
        --include-files "**/dymaptic.GeoBlazor.Core.Analyzers.dll" \
        -- "${RUN_COMMAND[@]}"
else
    echo "Starting without code coverage..."
    "${RUN_COMMAND[@]}"
fi