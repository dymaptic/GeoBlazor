using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Extensions;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The ScaleBar widget displays a scale bar on the map or in a specified HTML node. The widget respects various coordinate systems and displays units in metric or non-metric values. Metric values shows either kilometers or meters depending on the scale, and likewise non-metric values shows miles and feet depending on the scale.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-ScaleBar.html">ArcGIS JS API</a>
/// </summary>
public class ScaleBarWidget : Widget
{
    /// <inheritdoc />
    public override string WidgetType => "scaleBar";

    /// <summary>
    ///     Units to use for the scale bar
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public ScaleUnit? Unit { get; set; }
}

/// <summary>
///     Possible unit values for the <see cref="ScaleBarWidget"/>
/// </summary>
[JsonConverter(typeof(ScaleUnitConverter))]
public enum ScaleUnit
{
#pragma warning disable CS1591
    NonMetric,
    Metric,
    Dual
#pragma warning restore CS1591
}

internal class ScaleUnitConverter : JsonConverter<ScaleUnit>
{
    public override ScaleUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, ScaleUnit value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(ScaleUnit), value);
        string kebabString = stringVal!.ToKebabCase();
        writer.WriteRawValue($"\"{kebabString}\"");
    }
}