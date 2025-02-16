namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The visible elements that are displayed within the widget. This property provides the ability to turn individual elements of the widget's display on/off.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html#VisibleElements">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class BasemapLayerListWidgetVisibleElements: MapComponent
{
    /// <summary>
    ///     Indicates whether to the status indicators will be displayed. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? StatusIndicators { get; set; }
    
    /// <summary>
    ///     Indicates whether to the base layers will be displayed. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BaseLayers { get; set; }
    
    /// <summary>
    ///     Indicates whether the reference layers will be displayed. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReferenceLayers { get; set; }
    
    /// <summary>
    ///     Indicates whether layer load errors will be displayed. Default is false.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Errors { get; set; }
}