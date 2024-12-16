using dymaptic.GeoBlazor.Core.Enums;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///    The Image Measurement widget allows you to perform measurements on image services with mensuration capability.
///     Mensuration is a method of applying geometric rules to find length of lines, area of surfaces, or volume using information obtained
///     from lines and angles. It can also include measuring the height and absolute location of a feature.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Measurement.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class MeasurementWidget : Widget
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string WidgetType => "measurement";

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
    ///     Unit system (imperial, metric) or specific unit used for displaying the distance values.
    /// </summary>
    /// <remarks>
    ///     In a future version of GeoBlazor, the type of this property will be replaced with the
    ///     more expansive `SystemOrLengthUnit` type.
    /// </remarks>
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