using System.Diagnostics;
using System.Text;


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace dymaptic.GeoBlazor.Core;


public interface IAppValidator
{
    public Task ValidateLicense();
}

internal class RegistrationValidator: IAppValidator
{
    public RegistrationValidator(GeoBlazorSettings settings, IJSRuntime jsRuntime, NavigationManager navigationManager)
    {
        _settings = settings;
        _jsRuntime = jsRuntime;
        _navigationManager = navigationManager;
    }

    public async Task ValidateLicense()
    {
        // if we've already shown the message or validated, there's no need to check again
        if (_messageShown || _isValidated)
        {
            return;
        }
        
        if (_validating) return;

        _validating = true;

        BlazorMode blazorMode = _jsRuntime.GetType().Name.Contains("Remote") ? BlazorMode.Server :
            OperatingSystem.IsBrowser() ? BlazorMode.WebAssembly : BlazorMode.Maui;

        string? registration = _settings.RegistrationKey;
        bool valid = registration is not null;

        if (valid)
        {
            try
            {
                string registrationText = Encoding.UTF8.GetString(Convert.FromBase64String(registration!));

                RegistrationObject registrationObject =
                    JsonSerializer.Deserialize<RegistrationObject>(registrationText)!;
                if (valid && registrationObject!.LicenseVersion != 1)
                {
                    valid = false;
                }
                if (valid && registrationObject.LicenseType != "Free")
                {
                    valid = false;
                }
                if (valid && registrationObject.Software != "GeoBlazorCore")
                {
                    valid = false;
                }
            }
            catch
            {
                valid = false;
            }
        }
        
        if (!valid)
        {
            if (!_messageShown)
            {
                Console.WriteLine(_registrationMessage);
                Debug.WriteLine(_registrationMessage);
                if (blazorMode == BlazorMode.Server)
                {
                    await _jsRuntime.InvokeVoidAsync("console.log", _registrationMessage);
                }

                _messageShown = true;
                return;
            }
        }

        _isValidated = true;
        _validating = false;
    }

    private static bool _isValidated;
    private readonly GeoBlazorSettings _settings;
    private readonly IJSRuntime _jsRuntime;
    private readonly NavigationManager _navigationManager;
    private readonly string _registrationMessage =
        "Thank you for using GeoBlazor! Please visit https://licensing.dymaptic.com/geoblazor-core to register.";
    private static bool _messageShown;
    private bool _validating;
}

internal enum BlazorMode
{
#pragma warning disable CS1591
    Server,
    WebAssembly,
    Maui
#pragma warning restore CS1591
}

internal record RegistrationObject(
    string Email, 
    string LicenseType, 
    string Software,
    int LicenseVersion);