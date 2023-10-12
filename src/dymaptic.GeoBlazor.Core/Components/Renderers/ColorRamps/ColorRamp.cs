using dymaptic.GeoBlazor.Core.Serialization;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Renderers.ColorRamps;

/// <summary>
///     A ColorRamp object is used to specify a range of colors that are applied to a group of symbols or pixels.
///     There are two types of color ramps available:
///     Algorithmic color ramp: A AlgorithmicColorRamp is defined by two colors and the algorithm used to traverse the intervening color space between them.
///     Multipart color ramp: A MultipartColorRamp is defined by a list of constituent color ramps.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ColorRamp.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public abstract class ColorRamp : MapComponent
{
    /// <summary>
    ///     A string value representing the color ramp type.  Possible Values:"algorithmic"|"multipart"
    /// </summary>
    [JsonPropertyName("type")]
    public abstract ColorRampType ColorRampType { get; }
}

/// <summary>
///     An enum converter containing the string values representing the color ramp type.  Possible Values:"algorithmic"|"multipart"
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ColorRampType>))]
public enum ColorRampType
{
#pragma warning disable CS1591
    Algorithmic,
    Multipart
#pragma warning restore CS1591
}
