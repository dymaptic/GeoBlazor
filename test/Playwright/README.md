# GeoBlazor Playwright Test Runner

Automated browser testing for GeoBlazor using Playwright with local Chrome (GPU-enabled) and the test app in a Docker container.

## Quick Start

```bash
# Install Playwright browsers (first time only)
npx playwright install chromium

# Run all tests
npm test

# Run with test filter
TEST_FILTER=FeatureLayerTests npm test

# Keep container running after tests
KEEP_CONTAINER=true npm test

# Run with visible browser (non-headless)
HEADLESS=false npm test
```

## Configuration

Create a `.env` file with the following variables:

```env
# Required - ArcGIS API credentials
ARCGIS_API_KEY=your_api_key
GEOBLAZOR_LICENSE_KEY=your_license_key

# Optional - Test configuration
TEST_FILTER=                    # Regex to filter test classes (e.g., FeatureLayerTests)
RENDER_MODE=WebAssembly         # WebAssembly or Server
PRO_ONLY=false                  # Run only Pro tests
TEST_TIMEOUT=1800000            # Test timeout in ms (default: 30 minutes)
START_CONTAINER=true           # Auto-start Docker container
KEEP_CONTAINER=false           # Keep container running after tests
SKIP_WEBGL_CHECK=false          # Skip WebGL2 availability check
USE_LOCAL_CHROME=true           # Use local Chrome with GPU (default: true)
HEADLESS=true                   # Run browser in headless mode (default: true)
```

## WebGL2 Requirements

**IMPORTANT:** The ArcGIS Maps SDK for JavaScript requires WebGL2 (since version 4.29).

By default, the test runner launches a local Chrome browser with GPU support, which provides WebGL2 capabilities on machines with a GPU. This allows all map-based tests to run successfully.

### How GPU Support Works

- The test runner uses Playwright to launch Chrome locally (not in Docker)
- Chrome is launched with GPU-enabling flags (`--ignore-gpu-blocklist`, `--enable-webgl`, etc.)
- The test app runs in a Docker container and is accessed via `https://localhost:8443`
- Your local GPU (e.g., NVIDIA RTX 3050) provides WebGL2 acceleration

### References

- [ArcGIS System Requirements](https://developers.arcgis.com/javascript/latest/system-requirements/)
- [Chrome Developer Blog: Web AI Testing](https://developer.chrome.com/blog/supercharge-web-ai-testing)
- [Esri KB: Chrome without GPU](https://support.esri.com/en-us/knowledge-base/usage-of-arcgis-maps-sdk-for-javascript-with-chrome-whe-000038872)

## Architecture

```
┌─────────────────────────────────────────────────────┐
│  runBrowserTests.js (Node.js test orchestrator)    │
│  - Launches local Chrome with GPU support           │
│  - Monitors test output from console messages       │
│  - Reports pass/fail results                        │
└───────────────────────────┬─────────────────────────┘
                            │
                            ▼
┌──────────────────────────────────────────────────────┐
│  Local Chrome (Playwright)                           │
│  - Uses host GPU for WebGL2                          │
│  - Connects to test-app at https://localhost:8443    │
└───────────────────────────┬──────────────────────────┘
                            │
                            ▼
┌──────────────────────────────────────────────────────┐
│  test-app (Docker Container)                         │
│  - Blazor WebApp with GeoBlazor tests                │
│  - Ports: 8080 (HTTP), 8443 (HTTPS)                  │
└──────────────────────────────────────────────────────┘
```

## Test Output Format

The test runner parses console output from the Blazor test application:

- `Running test {TestName}` - Test started
- `### TestName - Passed` - Test passed
- `### TestName - Failed` - Test failed

## Troubleshooting

### Playwright browsers not installed

```bash
npx playwright install chromium
```

### WebGL2 not available

The test runner checks for WebGL2 support at startup. If your machine doesn't have a GPU, WebGL2 may not be available:

- Run on a machine with a dedicated GPU
- Use `SKIP_WEBGL_CHECK=true` to skip the check (map tests may still fail)

### Container startup issues

```bash
# Check container status
docker compose ps

# View container logs
docker compose logs test-app

# Restart container
docker compose down && docker compose up -d
```

### Remote Chrome (CDP) mode

To use a remote Chrome instance instead of local Chrome:

```bash
USE_LOCAL_CHROME=false CDP_ENDPOINT=http://remote-chrome:9222 npm test
```

## Files

- `runBrowserTests.js` - Main test orchestrator
- `docker-compose.yml` - Docker container configuration (test-app only)
- `package.json` - NPM dependencies
- `.env` - Environment configuration (not in git)
