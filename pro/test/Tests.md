# GeoBlazor Pro Tests

See [GeoBlazor Tests](../../test/Tests.md) for basic information on how to write GeoBlazor tests.

## Differences in GeoBlazor Pro Blazor Tests

1. Write test classes in `dymaptic.GeoBlazor.Pro.Test.Blazor.Shared/Components`.
2. Use the `ProTestRunnerBase` base class instead of `TestRunnerBase`.
3. If you want to write Pro-specific JavaScript assertions, use the `AssertProJavaScript`
   method to call the test functions, and define the functions in `wwwroot/proTestRunner.js`.
4. To run the tests, you need an ArcGIS API key defined in `secrets.json` or `appsettings.json`. A GeoBlazor
   registration key is optional. See [GeoBlazor Pro](../ReadMe.md) for details.