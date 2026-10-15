#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace dymaptic.GeoBlazor.Core;

/// <summary>
///     For internal use only.
/// </summary>
/// <exclude/>
public interface IAppValidator
{
    public ValueTask ValidateLicense();
}

/// <summary>
///     Checks for a GeoBlazor registration key and, if none is found, asks the developer to register.
///     Used by both GeoBlazor Core and GeoBlazor Pro. It never throws, so a missing or unrecognized key
///     never stops an application from running.
/// </summary>
internal class RegistrationValidator(GeoBlazorSettings settings, IJSRuntime jsRuntime) : IAppValidator
{
    public async ValueTask ValidateLicense()
    {
        // if we've already shown the message or validated, there's no need to check again
        if (_messageShown || _isValidated || _validating)
        {
            return;
        }

        _validating = true;

        try
        {
            // users reading Pro documentation might use the name LicenseKey instead of RegistrationKey
            if (IsRecognizedKey(settings.RegistrationKey) || IsRecognizedKey(settings.LicenseKey))
            {
                _isValidated = true;

                return;
            }

            _messageShown = true;
            Console.WriteLine(RegistrationMessage);
            Debug.WriteLine(RegistrationMessage);

            // Blazor Server console output goes to the server log, so also write to the browser console
            if (jsRuntime.GetType().Name.Contains("Remote"))
            {
                try
                {
                    await jsRuntime.InvokeVoidAsync("console.log", RegistrationMessage);
                }
                catch
                {
                    // the message is informational only, so a lost circuit should not surface as an error
                }
            }
        }
        finally
        {
            _validating = false;
        }
    }

    /// <summary>
    ///     The validated and message-shown flags are static so the message appears once per app run.
    ///     Unit tests call this to start each test from a fresh state.
    /// </summary>
    internal static void ResetForTests()
    {
        _isValidated = false;
        _messageShown = false;
    }

    /// <summary>
    ///     Accepts a free GeoBlazor Core registration key or an existing GeoBlazor Pro license key.
    ///     Pro keys are "[base64 payload].[base64 signature]"; Core keys are only the payload.
    ///     The signature is not verified, because GeoBlazor is open source and the check would protect nothing.
    /// </summary>
    private static bool IsRecognizedKey(string? key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            return false;
        }

        try
        {
            string payload = Encoding.UTF8.GetString(Convert.FromBase64String(key.Split('.')[0]));
            RegistrationObject? registration = JsonSerializer.Deserialize<RegistrationObject>(payload);

            return registration is { Software: "GeoBlazorCore", LicenseType: "Free", LicenseVersion: 1 }
                or { Software: "GeoBlazorPro" };
        }
        catch
        {
            return false;
        }
    }

    private const string RegistrationMessage =
        "Thank you for using GeoBlazor! Please visit https://licensing.dymaptic.com to register.";
    private static bool _isValidated;
    private static bool _messageShown;
    private bool _validating;
}

/// <summary>
///     Identifies whether the application is running in Server, WebAssembly, or MAUI Hybrid
/// </summary>
public enum BlazorMode
{
#pragma warning disable CS1591
    Server,
    WebAssembly,
    Hybrid
#pragma warning restore CS1591
}

internal record RegistrationObject(
    string LicenseType,
    string Software,
    int LicenseVersion);