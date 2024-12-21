namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what
///     seems like a new layer. Unlike the method of using transparency which can result in a washed-out top layer, blend
///     modes can create a variety of very vibrant and intriguing results by blending a layer with the layer(s) below it.
/// </summary>
/// <remarks>
///     See more at
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WebTileLayer.html#blendMode">
///         ArcGIS Maps SDK for JavaScript
///     </a>
/// </remarks>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<BlendMode>))]
public enum BlendMode
{
#pragma warning disable CS1591
    Average,
    ColorBurn,
    ColorDodge,
    Color,
    Darken,
    DestinationAtop,
    DestinationIn,
    DestinationOut,
    DestinationOver,
    Difference,
    Exclusion,
    HardLight,
    Hue,
    Invert,
    Lighten,
    Lighter,
    Luminosity,
    Minus,
    Multiply,
    Normal,
    Overlay,
    Plus,
    Reflect,
    Saturation,
    Screen,
    SoftLight,
    SourceAtop,
    SourceIn,
    SourceOut,
    VividLight,
    Xor
#pragma warning restore CS1591
}