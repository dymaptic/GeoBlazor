# GeoBlazor Automation Test Runner

Automated browser testing for GeoBlazor using Playwright with local Chrome (GPU-enabled) and the test app in a Docker container.

## Quick Start

```bash
# Install Playwright browsers (first time only)
npx playwright install chromium

# Run all tests (Pro if available, otherwise Core)
npm test

# Run with test filter
npm test TEST_FILTER=FeatureLayerTests

# Run with visible browser (non-headless)
npm test HEADLESS=false

# Run only Core tests
npm test CORE_ONLY=true
# or
npm test core-only

# Run only Pro tests
npm test PRO_ONLY=true
# or
npm test pro-only
```

## Configuration

Configuration is loaded from environment variables and/or a `.env` file. Command-line arguments override both.

### Required Environment Variables

```env
# ArcGIS API credentials
ARCGIS_API_KEY=your_api_key

# License keys (at least one required)
GEOBLAZOR_CORE_LICENSE_KEY=your_core_license_key
GEOBLAZOR_PRO_LICENSE_KEY=your_pro_license_key

# WFS servers for testing (JSON format)
WFS_SERVERS='"WFSServers":[{"Url":"...","OutputFormat":"GEOJSON"}]'
```

### Optional Configuration

| Variable | Default | Description |
|----------|---------|-------------|
| `TEST_FILTER` | (none) | Regex to filter test classes (e.g., `FeatureLayerTests`) |
| `RENDER_MODE` | `WebAssembly` | Blazor render mode (`WebAssembly` or `Server`) |
| `CORE_ONLY` | `false` | Run only Core tests (auto-detected if Pro not available) |
| `PRO_ONLY` | `false` | Run only Pro tests |
| `HEADLESS` | `true` | Run browser in headless mode |
| `TEST_TIMEOUT` | `1800000` | Test timeout in ms (default: 30 minutes) |
| `IDLE_TIMEOUT` | `60000` | Idle timeout in ms (default: 1 minute) |
| `MAX_RETRIES` | `5` | Maximum retry attempts for failed tests |
| `HTTPS_PORT` | `9443` | HTTPS port for test app |
| `TEST_APP_URL` | `https://localhost:9443` | Test app URL (auto-generated from port) |

### Command-Line Arguments

Arguments can be passed as `KEY=value` pairs or as flags:

```bash
# Key=value format
npm test TEST_FILTER=MapViewTests HEADLESS=false

# Flag format (shortcuts)
npm test core-only headless
npm test pro-only
```

## WebGL2 Requirements

The ArcGIS Maps SDK for JavaScript requires WebGL2. The test runner launches a local Chrome browser with GPU support, which provides WebGL2 capabilities on machines with a GPU.

### How It Works

1. The test runner uses Playwright to launch Chrome locally (not in Docker)
2. Chrome is launched with GPU-enabling flags (`--ignore-gpu-blocklist`, `--enable-webgl`, etc.)
3. The test app runs in a Docker container and is accessed via HTTPS
4. Your local GPU provides WebGL2 acceleration

## Architecture

```
┌─────────────────────────────────────────────────────┐
│  runTests.js (Node.js test orchestrator)            │
│  - Starts Docker container with test app            │
│  - Launches local Chrome with GPU support           │
│  - Monitors test output from console messages       │
│  - Retries failed tests (up to MAX_RETRIES)         │
│  - Reports pass/fail results                        │
└───────────────────────────┬─────────────────────────┘
                            │
                            ▼
┌──────────────────────────────────────────────────────┐
│  Local Chrome (Playwright)                           │
│  - Uses host GPU for WebGL2                          │
│  - Connects to test-app at https://localhost:9443    │
└───────────────────────────┬──────────────────────────┘
                            │
                            ▼
┌──────────────────────────────────────────────────────┐
│  test-app (Docker Container)                         │
│  - Blazor WebApp with GeoBlazor tests                │
│  - Ports: 8080 (HTTP), 9443 (HTTPS)                  │
└──────────────────────────────────────────────────────┘
```

## Test Output

The test runner parses console output from the Blazor test application:

- `Running test {TestName}` - Test started
- `### TestName - Passed` - Test passed
- `### TestName - Failed` - Test failed
- `GeoBlazor Unit Test Results` - Final summary detected

### Retry Logic

When tests fail, the runner automatically retries up to `MAX_RETRIES` times. The best results across all attempts are preserved and reported.

## Troubleshooting

### Playwright browsers not installed

```bash
npx playwright install chromium
```

### Container startup issues

```bash
# Check container status
docker compose -f docker-compose-core.yml ps

# View container logs
docker compose -f docker-compose-core.yml logs test-app

# Restart container
docker compose -f docker-compose-core.yml down
docker compose -f docker-compose-core.yml up -d
```

### Service not becoming ready

The test runner waits up to 120 seconds for the test app to respond. Check:
- Docker container logs for startup errors
- Port conflicts (8080 or 9443 already in use)
- License key validity

## Files

- `runTests.js` - Main test orchestrator
- `docker-compose-core.yml` - Docker configuration for Core tests
- `docker-compose-pro.yml` - Docker configuration for Pro tests
- `package.json` - NPM dependencies
- `.env` - Environment configuration (not in git)
