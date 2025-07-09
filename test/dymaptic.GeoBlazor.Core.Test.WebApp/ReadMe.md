# Blazor Web App Test Runner

This project is the main test runner for the GeoBlazor library. It is designed to be similar to a Unit Test runner in an IDE,
but with the addition of the map rendering capabilities necessary to truly test GeoBlazor.

The `RenderModeSelector` component allows you to switch between `WebAssembly` and `Server` render modes, to run tests in either mode.

To run the tests, you need to add an ArcGIS API key and a GeoBlazor Registration key to the `appsettings.json` file in
both projects. You can optionally use `User Secrets` in this project, but it does not work in the `Client` project. The
client appsettings must be in the `wwwroot` directory.

```json
{
  "ArcGisAPIKey": "YOUR_ARCGIS_API_KEY",
  "GeoBlazor" : {
    "LicenseKey": "YOUR_GEOBLAZOR_LICENSE_KEY"
  }
}
```

See https://docs.geoblazor.com/pages/authentication.html for more information on how to get your keys.


# Testing Notes

We have made every effort to make the test runner as consistent as possible. However, with the asynchronous and network-related
nature of the tests, and the need to have an ultimate time limit on tests, you will occasionally see tests fail that will
pass on a subsequent run. This issue is more pronounced if you try to run all tests at once, as the browser will struggle
to balance all of the JavaScript calls and the network requests to the ArcGIS servers running at once, and you will see
console messages about "too many WebGL contexts".

Suggested best practices:

1. Run tests in smaller batches, such as by class.
2. Re-run any failed tests before investigating code.
3. Run all tests in both Server and WebAssembly modes to ensure consistency.