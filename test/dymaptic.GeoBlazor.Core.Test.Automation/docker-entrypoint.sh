#!/bin/bash
set -e

SESSION_ID="geoblazor-coverage"

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
    /tools/dotnet-coverage collect \
        --session-id "$SESSION_ID" \
        -o "$COVERAGE_OUTPUT" \
        -f xml \
        --include-files "**/dymaptic.GeoBlazor.Core.dll" \
        --include-files "**/dymaptic.GeoBlazor.Pro.dll" \
        -- "$@"
else
    echo "Starting without code coverage..."
    exec "$@"
fi
