namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Defines a size stop used for creating a continuous size visualization in a size visual variable.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-support-SizeStop.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SizeStop : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SizeStop()
    {
    }

    /// <summary>
    ///     Constructs a new SizeStop in code with parameters
    /// </summary>
    /// <param name="value">
    ///     Specifies the data value to map to the given size.
    /// </param>
    /// <param name="size">
    ///     The size value in points (between 0 and 90) used to render features with the given value. This value may also be autocast from a string in points or pixels.
    /// </param>
    /// <param name="label">
    ///     A string value used to label the stop in the Legend.
    /// </param>
    public SizeStop(double value, Dimension? size = null, string? label = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Value = value;
        Size = size;
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
    ///     The size value in points (between 0 and 90) used to render features with the given value. This value may also be autocast from a string in points or pixels.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Size { get; set; }
    
    /// <summary>
    ///     Specifies the data value to map to the given size.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value {get; set;}
}