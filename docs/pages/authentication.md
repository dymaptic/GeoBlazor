---
layout: page
title: Authentication
nav_order: 3
---

# ArcGIS Authentication

GeoBlazor utilizes the ArcGIS JavaScript API for all map rendering and Geospatial calculations.
There are several different ways to authenticate your application with ArcGIS. 
[This page](https://developers.arcgis.com/documentation/mapping-apis-and-services/security/) has more details from Esri.

## API Key

Possibly the simplest approach, is to create an API Key from your [ArcGIS Developer Dashboard](https://developers.arcgis.com/api-keys/).

### Pros
- Easy to create
- Long-lived token
- Requires no sign-in by end user

### Cons
- An API Key could potentially be copied from the client browser, as it is consumed in the JavaScript, or if it is stored
  in a file loaded into Wasm on the client
- API Keys are tied to _your_ developer account, which means you or your company will be responsible for all usage fees 
  if/when you pass the free tier of usage
  
### Additional Security Steps
- (Set up a referrer so only your url can use the token)[https://developers.arcgis.com/documentation/mapping-apis-and-services/security/api-keys/#referrers]
- Monitor your api-key usage and ArcGIS Dashboard billing regularly to catch any suspicious activity
- (Read the full API Key docs)[https://developers.arcgis.com/documentation/mapping-apis-and-services/security/api-keys] for ways to limit access to various types of services

## OAuth Sign-in

Using a `ClientId` and `ClientSecret`, you can set up your application to use 
[OAuth Authentication](https://developers.arcgis.com/documentation/mapping-apis-and-services/security/oauth-2.0/).
This secure system will redirect to an Esri login screen, and then back to your application, with a short-lived token
that can be used in place of the API Token. This is useful for creating an application for a company or government
agency that already has ArcGIS accounts.

### Pros
- Very secure, no chance of stealing your long-lived token or racking up charges on your account
- Short-lived token
- Grants access to online items (maps, layers, etc.) in the user's portal
- Charges are levied against the user's account

### Cons
- Requires registered ArcGIS Accounts for all users
- More difficult to set up than an API Key

# Using a Token in GeoBlazor
Once you have the API Token or OAuth Token, you can register it directly with Asp.NET's `IConfiguration` class. The Key
identifier is `ArcGISApiKey`. For a long-lived token, the easiest solution is to add the following to `appsettings.json`
(or perhaps `appsettings.production.json`).

```json
{
    "ArcGISApiKey": "yourKeyValue"
}
```

If you don't want to store a token long-term, or are using OAuth tokens, add the following line to your application startup
code in `Program.cs` (or `Startup.cs` for older templates).ArcGISApiKey

```csharp
builder.Configuration.AddInMemoryCollection();
```

This allows you to not only read from `IConfiguration`, but also write to it. Next, set up your custom logic for retrieving
an OAuth or API token. There is a simple example of OAuth code in 
[dymaptic.GeoBlazor.Core.Sample.Shared.Shared.MainLayout.razor](https://github.com/dymaptic/GeoBlazor/blob/develop/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Shared/MainLayout.razor).

Once you have the token, inject `IConfiguration` into your class, and set the value.

```csharp
@page "authenticate"
@inject IConfiguration Configuration

@code {
    private void SetConfiguration(string yourKeyValue)
    {
        Configuration["ArcGISApiKey"] = yourKeyValue;
    }
}

```

Once the token is registered by one of these methods, it will be picked up automatically by every `MapView` and `SceneView`.

## Allow Default Esri Login
By default, GeoBlazor prevents you from loading a map without a token. However, Esri has built in a simple in-map popup
login that you can use. This is not as secure as an OAuth login, but it is relatively straightforward.

To allow default logins, do one of the following.

In `appsettings.json`:
```json
{
    "AllowDefaultEsriLogin": true
}
```

or

When defining your `MapView` or `SceneView`:
```html
<MapView AllowDefaultEsriLogin="true">
    <Map></Map>
</MapView>
```