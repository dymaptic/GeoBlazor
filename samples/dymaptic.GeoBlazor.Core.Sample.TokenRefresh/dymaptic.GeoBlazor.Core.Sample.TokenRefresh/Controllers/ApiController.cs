using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Services;
using Microsoft.AspNetCore.Mvc;

namespace dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Controllers;

/// <summary>
/// API controller providing both authentication and configuration endpoints for the TokenRefresh sample.
/// 
/// Configuration Architecture:
/// - Server stores sensitive credentials (ArcGISAppId, ArcGISClientSecret) in appsettings.json or user secrets
/// - Client retrieves non-sensitive config (GeoBlazor license, ArcGIS API key, Portal URL, App ID) via /api/config endpoint
/// - Client calls /api/auth/token endpoint to request tokens without exposing credentials
/// 
/// This separation ensures:
/// - Client secrets remain secure on the server
/// - WebAssembly client gets necessary configuration for GeoBlazor initialization
/// - Token requests are authenticated server-side using client credentials flow
/// </summary>
[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    private readonly ArcGisAuthService _authService;
    private readonly IConfiguration _configuration;
    
    public ApiController(ArcGisAuthService authService, IConfiguration configuration)
    {
        _authService = authService;
        _configuration = configuration;
    }
    
    /// <summary>
    /// Retrieves client configuration needed for WebAssembly application initialization.
    /// Returns non-sensitive configuration values that the client needs to configure GeoBlazor.
    /// </summary>
    [HttpGet("config")]
    public IActionResult GetClientConfig()
    {
        try
        {
            var config = new
            {
                GeoBlazorLicenseKey = _configuration["GeoBlazor:RegistrationKey"],
                ArcGISApiKey = _configuration["ArcGISApiKey"],
                ArcGISPortalUrl = _configuration["ArcGISPortalUrl"],
                ArcGISAppId = _configuration["ArcGISAppId"]
            };
            
            return Ok(config);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    
    /// <summary>
    /// Authenticates with ArcGIS using server-side client credentials and returns a token.
    /// The client calls this endpoint to obtain tokens without exposing sensitive credentials.
    /// </summary>
    /// <param name="forceRefresh">Forces a new token request instead of using cached token</param>
    [HttpPost("auth/token")]
    public async Task<IActionResult> GetToken([FromBody] bool forceRefresh = false)
    {
        try
        {
            var tokenResponse = await _authService.GetTokenAsync(forceRefresh);
            return Ok(tokenResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}