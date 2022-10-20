namespace dymaptic.GeoBlazor.Core.Components.Widgets.LayerList;

/// <summary>
///     Actions are customizable behavior which can be executed in certain widgets such as Popups, a BasemapLayerList, or a LayerList.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html">ArcGIS JS API</a>
/// </summary>
/// <remarks>
///     The Action Sections property and corresponding functionality will be fully implemented
///     in a future iteration.  Currently, a user can view available layers in the layer list widget
///     and toggle the selected layer's visiblity. More capabilities will be available after full
///     implementation of ActionSection.
/// </remarks>
public class ActionBase
{
    /// <summary>
    ///     The title of the action.
    /// </summary>
    public string? Title { get; set; }
    
    /// <summary>
    ///     This adds a CSS clas to the ActionButton's node.
    /// </summary>
    public string? ClassName { get; set; }
    
    /// <summary>
    ///     The name of the ID assigned to this action.
    /// </summary>
    public string? Id { get; set; }
}


