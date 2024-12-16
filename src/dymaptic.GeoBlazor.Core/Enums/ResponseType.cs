using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Response types for the <see cref="RequestOptions" /> class.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ResponseType>))]
public enum ResponseType
{
#pragma warning disable CS1591
    Json,
    Text,
    ArrayBuffer,
    Blob,
    Image,
    Native,
    Document,
    Xml
#pragma warning restore CS1591
}