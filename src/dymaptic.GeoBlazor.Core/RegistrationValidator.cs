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

internal class RegistrationValidator(GeoBlazorSettings settings) : IAppValidator
{
    public ValueTask ValidateLicense()
    {
        // if we've already shown the message or validated, there's no need to check again
        if (_validating || _isValidated)
        {
            return ValueTask.CompletedTask;
        }

        _validating = true;

        string? registration = settings.RegistrationKey;
        
        if (registration == null)
        {
            _validating = false;
            throw new InvalidRegistrationException("No GeoBlazor Registration key provided. Please visit <a href='https://licensing.dymaptic.com' target='_blank'>https://licensing.dymaptic.com</a> to generate your free registration key.");
        }
        
        bool valid = true;

        try
        {
            string registrationText = Encoding.UTF8.GetString(Convert.FromBase64String(registration));

            RegistrationObject registrationObject =
                JsonSerializer.Deserialize<RegistrationObject>(registrationText)!;
            if (valid && registrationObject.LicenseVersion != 1)
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
        
        if (!valid)
        {
            _validating = false;

            throw new InvalidRegistrationException(
                "Invalid GeoBlazor registration key. Please visit <a href='https://licensing.dymaptic.com' target='_blank'>https://licensing.dymaptic.com</a> to generate a new free registration key.");
        }

        _isValidated = true;
        _validating = false;
        return ValueTask.CompletedTask;
    }

    private static bool _isValidated;
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
    string LicenseType, 
    string Software,
    int LicenseVersion);

internal class InvalidRegistrationException(string message) : Exception(message)
{
    public override string StackTrace => string.Empty;
}