# GeoBlazor Token Refresh Sample

This sample demonstrates how o implement automatic token refresh in GeoBlazor applications using server-side authentication with ArcGIS Portal, ArcGIS Online, or both platforms.

## App Registration Requirements
- [Register your application on ArcGIS Online](https://enterprise.arcgis.com/en/portal/latest/use/add-app-url.htm#REG_APP)
- [Create OAuth credentials for your organization's portal](https://developers.arcgis.com/documentation/security-and-authentication/app-authentication/tutorials/create-oauth-credentials-app-auth/)

You can run the app with registration for either ArcGIS Online or an Enterprise Portal. If you want to test both, you can switch between them by changing the `ArcGISPortalUrl` setting.

## Configuration Setup

Configure your ArcGIS authentication settings in `appsettings.Development.json` or user secrets:

- **ArcGISPortalUrl**:
  - If not specified, defaults to `https://www.arcgis.com` (ArcGIS Online).
  - For an organizational AGOL account, set to `https://your-company.arcgis.com`.
  - For Enterprise Portal, set to your portal host (e.g., `https://your-server/portal`), which typically ends with `/portal`.
    On rare occasion, the Enterprise setup will have altered the endpoint to not end with `/portal`.
- **ArcGISAppId**: Your registered application's Client ID.
- **ArcGISClientSecret**: Your application's Client Secret.
- **ArcGISAppTokenCacheFile**: Path to a file for caching tokens (e.g., `App_Data/arcgis_token_cache.json`).
- **ArcGISTokenExpirationMinutes**: Token expiration time in minutes (e.g., `60`).
- **GeoBlazor:LicenseKey** (optional): Your GeoBlazor license key.

Example configuration:
```json
{
  "ArcGISAppTokenCacheFile": "arcgis_token_cache.json",
  "ApplicationBaseUrl": "https://localhost:7143",
  "ArcGISTokenExpirationMinutes": 60,
  "ArcGISPortalUrl": "https://arcgis.your_company.com/portal" // for Enterprise
  // OR "ArcGISPortalUrl": "https://your_company.arcgis.com" for AGOL
  "ArcGISAppId": "YOUR_CLIENT_ID",
  "ArcGISClientSecret": "YOUR_CLIENT_SECRET",
  "GeoBlazor": {
    "LicenseKey": "YOUR_GEO_BLAZOR_LICENSE_KEY"
  }
}
```

