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

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ActiveTool? ActiveTool { get; set; }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AreaUnit? AreaUnit { get; set; }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LinearUnit? LinearUnit { get; set; }


    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }



}