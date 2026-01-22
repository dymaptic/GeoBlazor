#!/bin/bash
set -e

SESSION_ID="geoblazor-coverage"
COVERAGE_FILE_VERSION="$(date +%Y-%m-%d-%H-%M-%S)"
COVERAGE_OUTPUT="/coverage/coverage.$COVERAGE_FILE_VERSION.$COVERAGE_FORMAT"

# Trap SIGTERM to gracefully shutdown coverage collection
_term() {
    echo "Received SIGTERM, shutting down coverage collection..."
    if [ "$COVERAGE_ENABLED" = "true" ]; then
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

if [ "$COVERAGE_ENABLED" = "true" ]; then
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
        -f xml \
        --include-files "**/dymaptic.GeoBlazor.Core.dll" \
        --include-files "**/dymaptic.GeoBlazor.Pro.dll" \
        -l "$COVERAGE_OUTPUT.log" \
        -ll Verbose \
        -- "$@"
else
    echo "Starting without code coverage..."
    exec "$@"
fi
