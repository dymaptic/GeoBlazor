using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Authentication modes for the <see cref="RequestOptions" /> class.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<AuthMode>))]
public enum AuthMode
{
#pragma warning disable CS1591
    Auto,
    Anonymous,
    Immediate,
    NoPrompt
#pragma warning restore CS1591
}