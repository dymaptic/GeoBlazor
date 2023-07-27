using dymaptic.GeoBlazor.Core.Extensions;
using dymaptic.GeoBlazor.Core.Objects;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Renderers.ColorRamps;

/// <summary>
///     Creates a color ramp for use in a raster renderer. The algorithmic color ramp is defined by specifying two colors and the
///     algorithm used to traverse the intervening color spaces.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AlgorithmicColorRamp.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class AlgorithmicColorRamp : ColorRamp
{
    public AlgorithmicColorRamp() { }
    /// <summary>
    ///     A string value representing the color ramp type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    ///     The algorithm used to generate the colors between the fromColor and toColor.
    /// </summary>

    public Algorithm Algorithm { get; set; }
    /// <summary>
    ///     The first color in the color ramp.
    /// </summary>
    public MapColor? FromColor { get; set; }
    /// <summary>
    ///     The last color in the color ramp.
    /// </summary>
    public MapColor? ToColor { get; set; }
}
/// <summary>
/// The algorithm used to generate the colors between the fromColor and toColor. Each algorithm uses different methods for generating the intervening colors.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<Algorithm>))]
public enum Algorithm
{
    CieLab,
    LabLch,
    Hsv
}

//internal class AlgorithmConverter : JsonConverter<Algorithm>
//{
//    public override Algorithm Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//    {
//        throw new NotImplementedException();
//    }

//    public override void Write(Utf8JsonWriter writer, Algorithm value, JsonSerializerOptions options)
//    {
//        string? stringVal = Enum.GetName(typeof(Algorithm), value);
//        string resultString = stringVal!.ToKebabCase();
//        writer.WriteRawValue($"\"{resultString}\"");
//    }
//}