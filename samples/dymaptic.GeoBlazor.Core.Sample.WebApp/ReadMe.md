# Blazor Web App Sample

This sample shows how to use the GeoBlazor library in a Blazor Web App. It also showcases many different features of the library.

There are two projects related to the BWA
- `dymaptic.GeoBlazor.Core.Sample.WebApp`
- `dymaptic.GeoBlazor.Core.Sample.WebApp.Client`

The `Client` app is referenced by the core `WebApp`, and is used to render WebAssembly components.
We have added a `RenderModeSelector` to the sample, which allows you to test the different rendering modes.

To run the samples, you need to add an ArcGIS API key and a GeoBlazor Registration key to the `appsettings.json` file in
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