# Getting Started with the GeoBlazor Maui and Web Template

1. Get an API Key from the [ArcGIS Location Platform](https://location.arcgis.com/). 
2. Place this in your `appsetting.json` and `appsetting.Development.json` files, once per rendering version of the application.
   If you chose render-mode `Auto`, you should have it in the `.Web` and `.Web.Client.wwwroot` folders, as well as the `.Maui` folder.
   There should be a file with placeholders in all the expected locations.

   ```json
   {
       "ArcGISApiKey": "YourArcGISApiKey"
   }
   ```


3. Optionally, register at [licensing.dymaptic.com](https://licensing.dymaptic.com) for a free GeoBlazor registration key.
   A key is not required, but without one GeoBlazor logs a message in the console asking you to register.
   Existing GeoBlazor Pro license keys still work. Set one as `LicenseKey` in the same `GeoBlazor` section.
   Add the key to all the `appsettings.json`/`appsettings.Development.json`/`secrets.json` files:

    ```json
        {
            "ArcGISApiKey": "YourArcGISApiKey",
            "GeoBlazor": {
                "RegistrationKey": "YourGeoBlazorRegistrationKey"
            }
        }
    ```

4. Run the MAUI or Web project. You should see interactive maps on both the `Home` and `Counter` pages.