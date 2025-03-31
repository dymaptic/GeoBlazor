namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     SymbolType enumeration.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SymbolType>))]
public enum SymbolType
{
#pragma warning disable CS1591
    SimpleMarker,
    PictureMarker,
    SimpleLine,
    SimpleFill,
    PictureFill,
    Text,
    ShieldLabelSymbol,
    Point3d,
    Line3d,
    Polygon3d,
    WebStyle,
    Mesh3d,
    Label3d,
    Cim
#pragma warning restore CS1591
}