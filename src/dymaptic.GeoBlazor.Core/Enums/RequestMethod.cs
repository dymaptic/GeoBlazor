using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Request methods for the <see cref="RequestOptions" /> class.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<RequestMethod>))]
public enum RequestMethod
{
#pragma warning disable CS1591
    Auto,
    Delete,
    Head,
    Post,
    Put
#pragma warning restore CS1591
}