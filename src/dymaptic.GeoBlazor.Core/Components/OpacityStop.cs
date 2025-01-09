namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Defines a opacity stop used for creating a continuous opacity visualization in a opacity visual variable.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-support-OpacityStop.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class OpacityStop : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public OpacityStop()
    {
    }
    
    /// <summary>
    ///     Constructs a new OpacityStop in code with parameters
    /// </summary>
    /// <param name="value">
    ///     Specifies the data value to map to the given opacity.
    /// </param>
    /// <param name="opacity">
    ///     The opacity value in points (between 0.0 and 1.0) used to render features with the given value.
    /// </param>
    /// <param name="label">
    ///     A string value used to label the stop in the Legend.
    /// </param>
    public OpacityStop(double value, double opacity, string? label = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Value = value;
        Opacity = opacity;
        Label = label;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     A string value used to label the stop in the Legend.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
    
    /// <summary>
    ///     The opacity value in points (between 0.0 and 1.0) used to render features with the given value.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Opacity { get; set; }
    
    /// <summary>
    ///     Specifies the data value to map to the given opacity.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value {get; set;}
}