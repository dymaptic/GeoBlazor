---
layout: page
title: Authentication
nav_order: 4
---

# ArcGIS Authentication

GeoBlazor utilizes the ArcGIS JavaScript API for all map rendering and Geospatial calculations.
There are several different ways to authenticate your application with ArcGIS.
[This page](https://developers.arcgis.com/documentation/mapping-apis-and-services/security/) has more details from Esri.

## API Key

Possibly the simplest approach, is to create an API Key from
your [ArcGIS Developer Dashboard](https://developers.arcgis.com/api-keys/). Once you have the API Token, you can register it directly with Asp.NET's `IConfiguration` class. The Key
identifier is `ArcGISApiKey`. For a long-lived token, the easiest solution is to add the following to `appsettings.json`
(or perhaps `appsettings.production.json`).

```json
{
    "ArcGISApiKey": "yourKeyValue"
}
```

### Pros

- Easy to create
- Long-lived token
- Requires no sign-in by end user

### Cons

- An API Key could potentially be copied from the client browser, as it is consumed in the JavaScript, or if it is
  stored
  in a file loaded into Wasm on the client
- API Keys are tied to _your_ developer account, which means you or your company will be responsible for all usage fees
  if/when you pass the free tier of usage

### Additional Security Steps

- (Set up a referrer so only your url can use the
  token)[https://developers.arcgis.com/documentation/mapping-apis-and-services/security/api-keys/#referrers]
- Monitor your api-key usage and ArcGIS Dashboard billing regularly to catch any suspicious activity
- (Read the full API Key
  docs)[https://developers.arcgis.com/documentation/mapping-apis-and-services/security/api-keys] for ways to limit
  access to various types of services

## OAuth Sign-in

OAuth is a more secure way to authenticate your users with ArcGIS. It requires that your users have an ArcGIS account.
You generate a new OAuth `Application` in the [ArcGIS Developer Dashboard](https://developers.arcgis.com/applications/),
and then store the `ClientId` in your application configuration as `ArcGISAppId`.

Users will be prompted to log in automatically on the first map load if you add `PromptForOAuthLogin="true"` to your `MapView`, 
or you can use the `OAuthAuthentication.Login()` method to trigger the login prompt.

```html
<MapView PromptForOAuthLogin="true">
    <Map ArcGISDefaultBasemap="arcgis-topographic"></Map>
</MapView>
```

For ArcGIS Enterprise logins, you need to provide one more item in the application configuration, `ArcGISPortalUrl`. 
This will ensure that when the OAuth login is triggered, the user is directed to the correct portal.

```json
{
    "ArcGISAppId": "yourClientId",
    "ArcGISPortalUrl": "https://arcgis.yourcompany.com"
}
```


### Pros

- Very secure, no chance of stealing your long-lived token or racking up charges on your account
- Short-lived token
- Grants access to online items (maps, layers, etc.) in the user's portal
- Charges are levied against the user's account

### Cons

- Requires registered ArcGIS Accounts for all users
- Not currently supported for Blazor Hybrid in MAUI

# Authentication Manager Class

The `AuthenticationManager` is a DI-injected class that handles all authentication for GeoBlazor. It is responsible for 
both the Api Key and OAuth authentication methods. It also allows you to retrieve the current authentication token with 
`GetCurrentToken` regardless of how that token was generated.

## Custom Token Injection

If you don't want to store a token long-term, or want to inject an API Key or OAuth token from a custom source, you can
simply set the value in `AuthenticationManager`

```csharp
authenticationManager.ApiKey = "yourKeyValue";
//or
authenticationManager.AppId = "yourClientId";
// then call
authenticationManager.Initialize();
```

Once the token is initialized, it will be picked up automatically by every `MapView`, `SceneView`, and logic component.

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

## Prevent API Token Prompt

This is essentially another way to silence the API token check in GeoBlazor. Calling ArcGIS resources will still
show the default login same as `AllowDefaultEsriLogin` above.

To silence the api key prompt, do one of the following.

In `appsettings.json`:

```json
{
    "PromptForArcGISKey": false
}
```

or

When defining your `MapView` or `SceneView`:

```html
<MapView PromptForArcGISKey="false">
    <Map></Map>
</MapView>
```