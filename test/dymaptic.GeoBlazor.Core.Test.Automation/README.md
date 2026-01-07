# GeoBlazor .NET Automation Tests

.NET-based automated browser testing for GeoBlazor using MSTest and Playwright. Tests are auto-generated from test component files using a source generator.

## Quick Start

```bash
# Playwright browsers are installed automatically on first test run

# Run all tests
dotnet test

# Run with specific test filter
dotnet test --filter "FullyQualifiedName~FeatureLayerTests"

# Run only Core tests
dotnet test -e CORE_ONLY=true

# Run only Pro tests (requires Pro license)
dotnet test -e PRO_ONLY=true
```

## Configuration

Configuration is loaded from multiple sources (in order of precedence):
1. Environment variables
2. `.env` file in the test project directory
3. `appsettings.json` / `appsettings.{Environment}.json`
4. User secrets

### Required Environment Variables

```env
# ArcGIS API credentials
ARCGIS_API_KEY=your_api_key

# License keys (at least one required)
GEOBLAZOR_CORE_LICENSE_KEY=your_core_license_key
GEOBLAZOR_PRO_LICENSE_KEY=your_pro_license_key
```

### Optional Configuration

| Variable | Default | Description |
|----------|---------|-------------|
| `RENDER_MODE` | `WebAssembly` | Blazor render mode (`WebAssembly` or `Server`) |
| `CORE_ONLY` | `false` | Run only Core tests (auto-detected if Pro not available) |
| `PRO_ONLY` | `false` | Run only Pro tests |
| `USE_CONTAINER` | `false` | Run test app in Docker container instead of locally |
| `FORCE_BUILD` | `false` | Force rebuild of Docker container |
| `HTTPS_PORT` | `9443` | HTTPS port for test app |
| `HTTP_PORT` | `8080` | HTTP port for test app |
| `TEST_APP_URL` | `https://localhost:9443` | Test app URL |
| `BROWSER_POOL_SIZE` | `2` (CI) / `4` (local) | Maximum concurrent browser instances |

## How It Works

### Architecture

```
+----------------------------------------------------------+
|  MSTest + Source Generator                               |
|  - Auto-generates test classes from Blazor components    |
|  - Discovers tests from Core.Test.Blazor.Shared          |
|  - Discovers tests from Pro.Test.Blazor.Shared (if Pro)  |
+----------------------------+-----------------------------+
                             |
                             v
+----------------------------------------------------------+
|  Browser Pool                                            |
|  - Manages pool of reusable Chromium instances           |
|  - Limits concurrent browsers to prevent resource        |
|    exhaustion (configurable via BROWSER_POOL_SIZE)       |
|  - Health checks and automatic browser recycling         |
+----------------------------+-----------------------------+
                             |
                             v
+----------------------------------------------------------+
|  GeoBlazorTestClass (Playwright)                         |
|  - Checks out browser from pool                          |
|  - Launches Chromium with GPU/WebGL2 support             |
|  - Navigates to test pages                               |
|  - Clicks "Run Test" button                              |
|  - Waits for pass/fail result                            |
|  - Returns browser to pool                               |
+----------------------------+-----------------------------+
                             |
                             v
+----------------------------------------------------------+
|  Test App (local dotnet run or Docker)                   |
|  - Core: dymaptic.GeoBlazor.Core.Test.WebApp             |
|  - Pro: dymaptic.GeoBlazor.Pro.Test.WebApp               |
|  - Ports: 8080 (HTTP), 9443 (HTTPS)                      |
+----------------------------------------------------------+
```

### Browser Pooling

To prevent resource exhaustion when running many parallel tests, the framework uses a browser pool:

- **Pool Size**: Configurable via `BROWSER_POOL_SIZE` (default: 2 in CI, 4 locally)
- **Checkout/Return**: Tests check out a browser, use it, then return it to the pool
- **Health Checks**: Browsers are validated before reuse; unhealthy browsers are replaced
- **Automatic Cleanup**: Failed browsers are disposed and replaced with fresh instances
- **Semaphore-based**: Uses `SemaphoreSlim` to limit concurrent browser creation

This prevents the "Your computer has run out of resources" errors that can occur when many browsers are launched simultaneously.

### Test Discovery (Source Generator)

Tests are automatically discovered and generated from Blazor component files:

1. The source generator scans `dymaptic.GeoBlazor.Core.Test.Blazor.Shared/Components/` for test components
2. If Pro is available, it also scans `dymaptic.GeoBlazor.Pro.Test.Blazor.Shared/Components/`
3. For each test class, it generates an MSTest class with `[DynamicData]` test methods
4. Generated test classes are prefixed: `CORE_` for Core tests, `PRO_` for Pro tests

### Test Execution Flow

1. **Assembly Initialize**:
   - Installs Playwright browsers if needed (via `Microsoft.Playwright.Program.Main`)
   - Starts test app (locally via `dotnet run` or in Docker)
   - Waits up to 8 minutes for app to be ready
2. **Per Test**:
   - Checks out browser from pool (up to 3 minute wait)
   - Creates new browser context with GPU-enabled Chromium
   - Navigates to `{TestAppUrl}?testFilter={TestName}&renderMode={RenderMode}`
   - Clicks section toggle and "Run Test" button
   - Waits for "Passed: 1" indicator (up to 120 seconds)
   - Retries up to 3 times on failure
   - Returns browser to pool
3. **Assembly Cleanup**:
   - Disposes browser pool
   - Stops test app/container
   - Kills orphaned processes

### WebGL2 Requirements

The ArcGIS Maps SDK for JavaScript requires WebGL2. The test framework:

- Launches Chromium locally with GPU-enabling flags
- Uses flags: `--ignore-gpu-blocklist`, `--enable-webgl`, `--enable-webgl2-compute-context`
- Local GPU provides WebGL2 acceleration

## Running Modes

### Local Mode (Default)

Tests start the appropriate test web application directly:

```bash
dotnet test
```

The test framework will:
1. Start `dotnet run` on the Core or Pro test web app
2. Wait for HTTP response on the configured port (up to 8 minutes)
3. Run tests against the local app
4. Stop the app after tests complete

### Container Mode

Run the test app in Docker for CI/CD environments:

```bash
dotnet test -e USE_CONTAINER=true
```

This uses Docker Compose with:
- `docker-compose-core.yml` - Core tests
- `docker-compose-pro.yml` - Pro tests (requires Pro availability)

## Parallel Execution

Tests run in parallel at the method level (configured via `[Parallelize(Scope = ExecutionScope.MethodLevel)]`). The browser pool ensures that only a limited number of browsers run concurrently, preventing resource exhaustion while maintaining parallelism.

## Project Structure

```
dymaptic.GeoBlazor.Core.Test.Automation/
├── GeoBlazorTestClass.cs      # Base test class with Playwright integration
├── TestConfig.cs              # Configuration and test app lifecycle
├── BrowserPool.cs             # Thread-safe browser instance pooling
├── BrowserService.cs          # Browser instance management
├── DotEnvFileSource.cs        # .env file configuration provider
├── SourceGeneratorInputs.targets  # MSBuild targets for source gen inputs
├── docker-compose-core.yml    # Docker config for Core tests
├── docker-compose-pro.yml     # Docker config for Pro tests
└── .env                       # Local configuration (not in git)

dymaptic.GeoBlazor.Core.Test.Automation.SourceGeneration/
└── GenerateTests.cs           # Source generator for test classes
```

## Troubleshooting

### Playwright browsers not installed

Browsers are installed automatically during `AssemblyInitialize`. If issues occur:

```bash
# Manual installation via PowerShell
pwsh bin/Debug/net10.0/playwright.ps1 install chromium
# or after Release build:
pwsh bin/Release/net10.0/playwright.ps1 install chromium
```

### Port already in use

The test framework automatically kills processes on the configured HTTPS port before starting. If issues persist:

```bash
# Windows (PowerShell)
Get-NetTCPConnection -LocalPort 9443 -State Listen |
    Select-Object -ExpandProperty OwningProcess |
    ForEach-Object { Stop-Process -Id $_ -Force }

# Linux/macOS
lsof -i:9443 | awk '{if(NR>1)print $2}' | xargs -r kill -9
```

### Container startup issues

```bash
# Check container status
docker compose -f docker-compose-core.yml ps

# View container logs
docker compose -f docker-compose-core.yml logs test-app

# Rebuild and restart
docker compose -f docker-compose-core.yml down
docker compose -f docker-compose-core.yml up -d --build
```

### Resource exhaustion / "Out of resources" errors

If you see errors about resources being exhausted:

1. **Reduce pool size**: Set `BROWSER_POOL_SIZE=1` to run one browser at a time
2. **Check system resources**: Ensure adequate RAM and CPU available
3. **Close other applications**: Browsers are memory-intensive

### Test timeouts

Tests have the following timeouts:
- App startup wait: 8 minutes (240 attempts x 2 seconds)
- Browser checkout from pool: 3 minutes
- Page navigation: 60 seconds
- Button clicks: 120 seconds
- Pass/fail visibility: 120 seconds

If tests consistently timeout, check:
- Test app startup in container logs or console
- WebGL availability (browser console for errors)
- Network connectivity to test endpoints
- Browser pool availability (may be waiting for a browser)

### Debugging test failures

Console and error messages from the browser are captured and logged:
- Console messages appear in test output on success
- Error messages appear in test output on failure

To see browser activity, you can modify `_launchOptions` in `GeoBlazorTestClass.cs` to add `Headless = false`.

## Writing New Tests

1. Create a new Blazor component in `dymaptic.GeoBlazor.Core.Test.Blazor.Shared/Components/`
2. Add test methods with `[TestMethod]` attribute
3. The source generator will automatically create corresponding MSTest methods
4. Run `dotnet build` to regenerate test classes

Example test component structure:
```razor
@inherits TestRunnerBase

[TestMethod]
public async Task MyNewTest()
{
    // Test implementation
    await PassTest();
}
```

## GitHub Actions Integration

The test framework is integrated with GitHub Actions workflows for both Core and Pro repositories.

### Core Repository Workflows

Located in `.github/workflows/`:

- **tests.yml**: Dedicated test workflow
  - Runs on self-hosted Windows runner with GPU
  - Uses container mode (`USE_CONTAINER=true`)
  - Uploads TRX test results as artifacts

- **dev-pr-build.yml**: PR validation
  - Builds and tests on pull requests
  - Uses self-hosted runner for Playwright tests

### Pro Repository Workflows

Located in `GeoBlazor.Pro/.github/workflows/`:

- **tests.yml**: Pro test workflow
  - Similar to Core but includes Pro license
  - Tests Pro-specific features

- **dev-pr-build.yml**: Pro PR validation
  - Builds Pro components
  - Runs Pro test suite

### Self-Hosted Runner Requirements

The GitHub Actions workflows use self-hosted Windows runners because:

1. **GPU Required**: ArcGIS Maps SDK requires WebGL2/GPU acceleration
2. **Resource Intensive**: Browser tests need significant RAM
3. **License Keys**: Secure access to Pro license keys

Runner setup requirements:
- Windows with GPU (for WebGL2)
- Docker Desktop installed
- .NET SDK installed
- Playwright browsers accessible

### Example Workflow Configuration

```yaml
# Example GitHub Actions step
- name: Run Tests
  run: dotnet test --logger "trx;LogFileName=test-results.trx"
  env:
    ARCGIS_API_KEY: ${{ secrets.ARCGIS_API_KEY }}
    GEOBLAZOR_CORE_LICENSE_KEY: ${{ secrets.GEOBLAZOR_CORE_LICENSE_KEY }}
    GEOBLAZOR_PRO_LICENSE_KEY: ${{ secrets.GEOBLAZOR_PRO_LICENSE_KEY }}
    USE_CONTAINER: true
    BROWSER_POOL_SIZE: 2

- name: Upload Test Results
  uses: actions/upload-artifact@v4
  if: always()
  with:
    name: test-results
    path: "**/*.trx"
```