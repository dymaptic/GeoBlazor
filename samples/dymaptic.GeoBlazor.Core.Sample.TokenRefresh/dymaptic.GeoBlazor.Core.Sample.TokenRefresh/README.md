# GeoBlazor TokenRefresh Sample

This sample demonstrates how to implement automatic token refresh for ArcGIS authentication in a Blazor WebAssembly application using GeoBlazor.

## Architecture Overview

This sample uses a **dual-project architecture** designed for WebAssembly security requirements:

- **Server Project**: Handles secure operations (token requests, configuration storage)
- **Client Project**: WebAssembly application that consumes server APIs

### Key Design Principles

1. **Security First**: Sensitive credentials (client secrets) remain on the server
2. **Separation of Concerns**: Static configuration separate from dynamic tokens
3. **WebAssembly Compatible**: All client configuration comes via API endpoints

## Project Structure

```
TokenRefresh/
├── dymaptic.GeoBlazor.Core.Sample.TokenRefresh/          # Server Project
│   ├── Controllers/
│   │   ├── AuthController.cs                            # Token refresh API
│   │   └── ConfigController.cs                          # Static configuration API
│   ├── Services/
│   │   └── ArcGisAuthService.cs                         # Server-side authentication
│   └── appsettings.json                                 # Secure configuration
└── dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client/  # WebAssembly Client
    ├── Models/
    │   └── TokenModels.cs                               # Shared data models
    ├── Pages/
    │   └── MapPage.razor                                # Map with OAuth integration
    ├── ArcGisAuthServiceWasm.cs                         # Client-side auth service
    └── Program.cs                                       # WebAssembly startup
```

## Configuration

### Server Configuration (appsettings.json)

```json
{
  "ArcGISAppId": "Your_ARCGIS_APP_ID",
  "ArcGISClientSecret": "Your_ARCGIS_CLIENT_SECRET",
  "ArcGISApiKey": "Your_ARCGIS_API_KEY",
  "ArcGISPortalUrl": "https://your-portal-url/portal/",
  "ArcGISAppTokenCacheFile": "arcgis_token_cache.json",
  "ArcGISTokenExpirationMinutes": "1440",
  "GeoBlazor": {
    "RegistrationKey": "YOUR_GEO_BLAZOR_REGISTRATION_KEY"
  }
}
```

**Security Note**: Use User Secrets or environment variables for production deployments.

### Client Configuration

The WebAssembly client receives configuration dynamically from the server via API endpoints:

- Static configuration: `/api/config/client` (GeoBlazor license, API key, portal URL, app ID)
- Dynamic tokens: `/api/auth/token` (OAuth tokens with expiration)

## Authentication Flow

### Initialization Sequence

1. **Client Startup** (`Program.cs`):
   ```csharp
   // STEP 1: Get static configuration from server
   var response = await httpClient.GetAsync("/api/config/client");
   var configResponse = await response.Content.ReadFromJsonAsync<ClientConfigResponse>();
   
   // STEP 2: Configure GeoBlazor with retrieved configuration
   builder.Configuration.AddInMemoryCollection(tempConfig);
   builder.Services.AddGeoBlazor(builder.Configuration);
   
   // STEP 3: Register other services
   builder.Services.AddScoped<ArcGisAuthServiceWasm>();
   ```

2. **Map Loading** (`MapPage.razor`):
   ```csharp
   // OAuth flow triggered automatically when accessing private portal items
   <MapView PromptForOAuthLogin="true">
       <Map>
           <Basemap>
               <PortalItem PortalItemId="Your Portal Item" />
           </Basemap>
       </Map>
   </MapView>
   ```

### Token Management

#### Server-Side Token Management
- **ArcGisAuthService**: Handles OAuth client credentials flow
- **File-based caching**: Tokens cached to avoid unnecessary requests
- **Automatic refresh**: Expired tokens automatically renewed

#### Client-Side Token Management  
- **ArcGisAuthServiceWasm**: WebAssembly-compatible auth service
- **API delegation**: All auth operations delegated to server endpoints
- **AuthenticationManager integration**: Tokens registered with GeoBlazor

## API Endpoints

### `/api/config/client` (GET)
Returns static configuration needed by WebAssembly client:

**Response:**
```json
{
  "geoBlazorLicenseKey": "...",
  "arcGISApiKey": "...",
  "arcGISPortalUrl": "https://your-portal.com/portal/",
  "arcGISAppId": "your-app-id"
}
```

### `/api/auth/token` (POST)
Handles token refresh requests from WebAssembly client:

**Request:**
```json
true  // forceRefresh boolean
```

**Response:**
```json
{
  "success": true,
  "accessToken": "first 20 characters of your geoblazor key...",
  "expires": "2024-01-02T15:30:00Z",
  "errorMessage": null
}
```

## Security Considerations

### What's Safe for WebAssembly
✅ **Sent to Client:**
- GeoBlazor License Key
- ArcGIS API Key
- ArcGIS Portal URL  
- ArcGIS App ID (for OAuth redirects)

### What Must Stay on Server
❌ **Never sent to Client:**
- ArcGIS Client Secret
- Raw authentication credentials
- Internal server configuration

### Token Security
- **Short-lived tokens**: Configurable expiration (default 24 hours)
- **Server-side refresh**: Client cannot directly access OAuth endpoints
- **Automatic cleanup**: Expired tokens automatically refreshed

## OAuth Integration

The sample demonstrates OAuth integration with private portal items:

1. **Automatic OAuth Trigger**: `PromptForOAuthLogin="true"` on MapView
2. **Portal Item Access**: Private portal items trigger authentication
3. **Seamless Experience**: Users authenticate once per session
4. **Token Management**: Background refresh without user intervention

## Testing Features

The MapPage includes a testing panel with:

- **Get Token**: Tests complete authentication flow
- **Check Auth Status**: Verifies authentication state  
- **Get Token Expires**: Shows token expiration details

## Development Setup

1. **Configure Server**: Update `appsettings.json` with your ArcGIS credentials
2. **Run Server**: `dotnet run` in the Server project directory
3. **Client Auto-starts**: WebAssembly client served automatically
4. **Test Authentication**: Navigate to `/map` and test OAuth flow

## Production Deployment

### Server Environment
- Use User Secrets or Azure Key Vault for sensitive configuration
- Configure CORS appropriately for your domain
- Implement proper logging and monitoring

### Client Deployment
- WebAssembly client can be served from CDN
- Ensure server API endpoints are accessible from client domain
- Configure OAuth redirect URLs in ArcGIS application settings

## Troubleshooting

### Common Issues

**"No ArcGIS API Key Found"**
- Ensure `/api/config/client` returns valid configuration
- Check console for configuration retrieval messages
- Verify GeoBlazor service registration order in `Program.cs`

**404 Errors During Map Load**
- Verify portal item ID exists and is accessible
- Check that portal URL matches authentication portal
- Ensure OAuth application is configured correctly

**OAuth Flow Not Triggering**
- Confirm `PromptForOAuthLogin="true"` on MapView
- Verify portal item requires authentication
- Check browser console for authentication errors

### Debug Console Messages

During startup, look for these success messages:
```
✅ Successfully retrieved GeoBlazor license from server
✅ Successfully retrieved ArcGIS API Key from server  
✅ Successfully retrieved ArcGIS Portal URL from server
✅ Successfully retrieved ArcGIS App ID from server
```

## Related Documentation

- [GeoBlazor Authentication Guide](https://docs.geoblazor.com/authentication)
- [ArcGIS OAuth Documentation](https://developers.arcgis.com/documentation/security/oauth-2.0/)
- [Blazor WebAssembly Security](https://docs.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/)

---

*This sample project was developed with assistance from Claude Code (claude.ai/code), Anthropic's AI-powered development environment.*