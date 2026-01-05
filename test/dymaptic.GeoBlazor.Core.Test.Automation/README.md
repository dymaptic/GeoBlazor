# GeoBlazor .NET Automation Tests

.NET-based automated browser testing for GeoBlazor using MSTest and Playwright. Tests are auto-generated from test component files using a source generator.

## Quick Start

```bash
# Install Playwright browsers (first time only)
pwsh bin/Debug/net10.0/playwright.ps1 install chromium

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
|  GeoBlazorTestClass (Playwright)                         |
|  - Launches Chromium with GPU/WebGL2 support             |
|  - Navigates to test pages                               |
|  - Clicks "Run Test" button                              |
|  - Waits for pass/fail result                            |
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

### Test Discovery (Source Generator)

Tests are automatically discovered and generated from Blazor component files:

1. The source generator scans `dymaptic.GeoBlazor.Core.Test.Blazor.Shared/Components/` for test components
2. If Pro is available, it also scans `dymaptic.GeoBlazor.Pro.Test.Blazor.Shared/Components/`
3. For each test class, it generates an MSTest class with `[DynamicData]` test methods
4. Generated test classes are prefixed: `CORE_` for Core tests, `PRO_` for Pro tests

### Test Execution Flow

1. **Assembly Initialize**: Starts test app (locally via `dotnet run` or in Docker)
2. **Per Test**:
   - Creates new browser page with GPU-enabled Chromium
   - Navigates to `{TestAppUrl}?testFilter={TestName}&renderMode={RenderMode}`
   - Clicks section toggle and "Run Test" button
   - Waits for "Passed: 1" indicator (up to 120 seconds)
   - Retries up to 3 times on failure
3. **Assembly Cleanup**: Stops test app/container, kills orphaned processes

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
2. Wait for HTTP response on the configured port
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

Tests run in parallel at the method level (configured via `[Parallelize(Scope = ExecutionScope.MethodLevel)]`). Each test gets its own browser context for isolation.

## Project Structure

```
dymaptic.GeoBlazor.Core.Test.Automation/
├── GeoBlazorTestClass.cs      # Base test class with Playwright integration
├── TestConfig.cs              # Configuration and test app lifecycle
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

```bash
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

### Test timeouts

Tests have the following timeouts:
- Page navigation: 60 seconds
- Button clicks: 120 seconds
- Pass/fail visibility: 120 seconds
- App startup wait: 120 seconds (60 attempts x 2 seconds)

If tests consistently timeout, check:
- Test app startup in container logs or console
- WebGL availability (browser console for errors)
- Network connectivity to test endpoints

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

## CI/CD Integration

For CI/CD pipelines:

1. Set environment variables for API keys and license keys
2. Use container mode for consistent environments: `USE_CONTAINER=true`
3. The test framework handles container lifecycle automatically
4. TRX report output is enabled via MSTest.Sdk

```yaml
# Example GitHub Actions step
- name: Run Tests
  run: dotnet test --logger "trx;LogFileName=test-results.trx"
  env:
    ARCGIS_API_KEY: ${{ secrets.ARCGIS_API_KEY }}
    GEOBLAZOR_CORE_LICENSE_KEY: ${{ secrets.GEOBLAZOR_CORE_LICENSE_KEY }}
    USE_CONTAINER: true
```