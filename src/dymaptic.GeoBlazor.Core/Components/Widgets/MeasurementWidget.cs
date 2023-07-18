using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///    The Image Measurement widget allows you to perform measurements on image services with mensuration capability.
///     Mensuration is a method of applying geometric rules to find length of lines, area of surfaces, or volume using information obtained
///     from lines and angles. It can also include measuring the height and absolute location of a feature.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Measurement.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class MeasurementWidget : Widget
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string WidgetType => "measurement";

    /// <summary>
    ///     A .NET object reference for calling this class from JavaScript.
    /// </summary>
    public DotNetObjectReference<MeasurementWidget> MeasurementWidgetObjectReference => DotNetObjectReference.Create(this);

    /// <summary>
    /// Specifies the current measurement tool to display.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ActiveTool? ActiveTool { get; set; }

    /// <summary>
    /// Unit system (imperial, metric) or specific unit used for displaying the area values.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AreaUnit? AreaUnit { get; set; }

    /// <summary>
    /// Unit system (imperial, metric) or specific unit used for displaying the distance values.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LengthUnit? LinearUnit { get; set; }

    /// <summary>
    /// The widget's default label.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }



}