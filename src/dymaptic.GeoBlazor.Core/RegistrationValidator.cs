using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Security;
using System.Text.Json;
using System.Web;


namespace dymaptic.GeoBlazor.Core;

public class RegistrationValidator
{
    public RegistrationValidator(GeoBlazorSettings settings, IJSRuntime jsRuntime, HttpClient httpClient,
        NavigationManager navigationManager, IConfiguration configuration)
    {
        _settings = settings;
        _jsRuntime = jsRuntime;
        _httpClient = httpClient;
        _navigationManager = navigationManager;
        _machineName = Environment.MachineName;
#if DEBUG
        _licenseServerUrl = configuration["LicenseServerUrl"] ?? "https://licensing-dev.dymaptic.com/";
#endif
    }

    private Version Version => GetType().Assembly.GetName().Version!;

    public async Task<bool> ValidateLicense()
    {
        // if we've already found a valid license while the software is running, there's no need to check
        if (_inMemoryValidationResult is not null && _inMemoryValidationResult.IsValid)
        {
            if (_inMemoryValidationResult.BaseUri != _navigationManager.BaseUri)
            {
                _inMemoryValidationResult = null;
            }
            else
            {
                return true;
            }
        }

        string? storedValidation;
        BlazorMode blazorMode;

        if (_jsRuntime.GetType().Name.Contains("Remote")) // Server
        {
            blazorMode = BlazorMode.Server;
            storedValidation = await GetServerFileValidationResult();
        }
        else
        {
            blazorMode = OperatingSystem.IsBrowser() ? BlazorMode.WebAssembly : BlazorMode.Maui;
            storedValidation = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", "validationResult");
        }

        ValidationResult? validationResult = null;
        ValidationResult? storedValidationResult = null;

        if (storedValidation is not null)
        {
            try
            {
                storedValidationResult = JsonSerializer.Deserialize<ValidationResult>(storedValidation);

                // don't use stored results with a different version, base uri, or machine name
                if (storedValidationResult?.Version is null || storedValidationResult.Version.Major < Version.Major ||
                    storedValidationResult.BaseUri != _navigationManager.BaseUri ||
                    !storedValidationResult.MachineName.Equals(_machineName, StringComparison.OrdinalIgnoreCase))
                {
                    storedValidationResult = null;
                }

                if (storedValidationResult?.AttemptedConnect is not null &&
                    storedValidationResult.AttemptedConnect.Value.AddMinutes(5) > DateTime.UtcNow)
                {
                    // too soon to check again, the connection was down
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // if there is no valid stored license, call the server to get a new license
        if ((storedValidationResult is null || !storedValidationResult.IsValid) && 
            _settings.RegistrationKey is not null)
        {
            try
            {
                var queryString = new Dictionary<string, string>
                {
                    { "version", HttpUtility.UrlEncode(Version.ToString()) },
                    { "licenseKey", HttpUtility.UrlEncode(_settings.RegistrationKey) },
                    { "licenseTypeName", "Free" },
                    { "softwareName", "GeoBlazorCore" },
                    { "blazorMode", blazorMode.ToString() }
                };

                if (!string.IsNullOrWhiteSpace(_settings.MauiAppName))
                {
                    queryString["mauiAppName"] = HttpUtility.UrlEncode(_settings.MauiAppName);
                }

                // build query string without QueryHelpers, which is only available in aspnetcore framework
                var queryStringString = string.Join("&", queryString.Select(kvp => $"{kvp.Key}={kvp.Value}"));
#if DEBUG
                var url = $"{_licenseServerUrl}/api/validate?{queryStringString}";
#else
                var url = $"https://licensing.dymaptic.com/api/validate?{queryStringString}";
#endif
                _httpClient.DefaultRequestHeaders.Referrer = new Uri(_navigationManager.BaseUri);
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                validationResult = await response.Content.ReadFromJsonAsync<ValidationResult>();

                if (validationResult is not null)
                {
                    validationResult.MachineName = _machineName;
                    validationResult.BaseUri = _navigationManager.BaseUri;
                    string jsonResult = JsonSerializer.Serialize(validationResult);

                    await SaveFile(blazorMode, jsonResult);
                }
            }
            catch (HttpRequestException)
            {
                if (storedValidationResult?.AttemptedConnect is not null)
                {
                    validationResult = storedValidationResult;
                    validationResult.AttemptedConnect = DateTime.UtcNow;
                }
                else
                {
                    validationResult =
                        new ValidationResult(false, DateTime.MaxValue, "Unable to reach license server.")
                        {
                            Version = Version, AttemptedConnect = DateTime.UtcNow
                        };
                }

                string jsonResult = JsonSerializer.Serialize(validationResult);
                await SaveFile(blazorMode, jsonResult);

                // the server appears to be down, try again in 5 minutes
                return true;
            }
            catch (Exception ex)
            {
                // don't throw anything here, we will deal with failure after checking stored result
                Console.WriteLine(ex);
            }
        }

        // if we failed to reach the server, or the server returned an error, use the stored result
        if (validationResult is null && storedValidationResult is not null)
        {
            validationResult = storedValidationResult;
        }

        if (validationResult is null || !validationResult.IsValid)
        {
            return false;
        }

        _inMemoryValidationResult = validationResult;

        return true;
    }

    private async Task<string?> GetServerFileValidationResult()
    {
        string directoryPath = _settings.ValidationServerStoragePath ?? Path.GetTempPath();
        string filePath = Path.Combine(directoryPath, ServerFileName);

        if (!File.Exists(filePath))
        {
            return null;
        }

        return await File.ReadAllTextAsync(filePath);
    }

    private async Task SaveFile(BlazorMode blazorMode, string encodedResult)
    {
        if (blazorMode == BlazorMode.Server) // Server
        {
            await SaveServerFileValidationResult(encodedResult);
        }
        else
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "validationResult", encodedResult);
        }
    }

    private async Task SaveServerFileValidationResult(string result)
    {
        string directoryPath = _settings.ValidationServerStoragePath ?? Path.GetTempPath();
        try
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, ServerFileName);
            await File.WriteAllTextAsync(filePath, result);
        }
        catch (SecurityException)
        {
            string failMessage =
                $"Unable to save registration validation file. Please verify that the application has write access to the directory {
                    directoryPath}.";
            await _jsRuntime.InvokeVoidAsync(
                $"console.log('{failMessage}'");
            Console.WriteLine(failMessage);
        }
    }

    private static ValidationResult? _inMemoryValidationResult;

    private readonly GeoBlazorSettings _settings;
    private readonly IJSRuntime _jsRuntime;
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;
    private readonly string _machineName;
    private const string ServerFileName = "geoblazor-registration-validation";
#if DEBUG
    private readonly string _licenseServerUrl;
#endif
}


public record ValidationResult(bool IsValid, DateTime ExpirationDate, string? Message = null)
{
    public string MachineName { get; set; } = string.Empty;
    public Version? Version { get; set; }
    
    public DateTime? AttemptedConnect { get; set; }
    public string? BaseUri { get; set; }
}

public enum BlazorMode
{
#pragma warning disable CS1591
    Server,
    WebAssembly,
    Maui
#pragma warning restore CS1591
}