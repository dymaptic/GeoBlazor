# Blazor OAuth Sample

This sample shows how to set up User Authentication with OAuth in a Blazor Web App using the GeoBlazor library.

There are two projects related to the BWA
- `dymaptic.GeoBlazor.Core.Sample.OAuth`
- `dymaptic.GeoBlazor.Core.Sample.OAuth.Client`

The `Client` app is referenced by the core `WebApp`, and is used to render WebAssembly components.
We have added a `RenderModeSelector` to the sample, which allows you to test the different rendering modes.

To run the samples, you need to get a `ClientId` (AppId) from ArcGIS and a GeoBlazor Registration key,
and add these to the `appsettings.json` files in both projects. You can optionally use `User Secrets` in this project, 
but it does not work in the `Client` project. The client appsettings must be in the `wwwroot` directory.

```json
{
  "ArcGISAppId": "YOUR_ARCGIS_APP_ID",
  "GeoBlazor" : {
    "LicenseKey": "YOUR_GEOBLAZOR_LICENSE_KEY"
  }
}
```

See https://docs.geoblazor.com/pages/arcgis.html#oauth2-credentials-user-and-app-authentication for more information on 
how to get your ArcGIS App registered.