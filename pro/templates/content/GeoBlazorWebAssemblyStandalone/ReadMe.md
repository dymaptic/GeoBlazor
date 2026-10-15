# Getting Started with the GeoBlazor WebAssembly Standalone Template

1. Get an API Key from the [ArcGIS Location Platform](https://location.arcgis.com/). 
2. Place this in your `wwwroot/appsetting.Development.json` file:

   ```json
   {
       "ArcGISApiKey": "YourArcGISApiKey"
   }
   ```

3. Optionally, register at [licensing.dymaptic.com](https://licensing.dymaptic.com) for a free GeoBlazor registration key.
   A key is not required, but without one GeoBlazor logs a message in the console asking you to register.
   Existing GeoBlazor Pro license keys still work. Set one as `LicenseKey` in the same `GeoBlazor` section.
   Add the key to the `appsettings.Development.json` file:

    ```json
        {
            "ArcGISApiKey": "YourArcGISApiKey",
            "GeoBlazor": {
                "RegistrationKey": "YourGeoBlazorRegistrationKey"
            }
        }
    ```

4. Run the project. You should see interactive maps on both the `Home` and `Counter` pages.