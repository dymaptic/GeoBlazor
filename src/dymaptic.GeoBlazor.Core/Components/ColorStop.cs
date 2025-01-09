namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Defines a color stop used for creating a continuous color visualization in a color visual variable.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-support-ColorStop.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ColorStop: MapComponent
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ColorStop()
    {
    }
    
    /// <summary>
    ///     Constructs a new ColorStop in code with parameters
    /// </summary>
    /// <param name="value">
    ///     Specifies the data value to map to the given color.
    /// </param>
    /// <param name="color">
    ///     The Color used to render features with the given value.
    /// </param>
    /// <param name="label">
    ///     A string value used to label the stop along the color ramp in the Legend.
    /// </param>
    public ColorStop(double value, MapColor color, string? label = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Value = value;
        Color = color;
        Label = label;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     The Color used to render features with the given value.
    /// </summary>
    [Parameter]
    [RequiredProperty]
    public MapColor? Color { get; set; }
    
    /// <summary>
    ///     A string value used to label the stop along the color ramp in the Legend.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
    
    /// <summary>
    ///     Specifies the data value to map to the given color.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value { get; set; }
}