namespace dymaptic.GeoBlazor.Core.Components.Widgets.LayerList;

/// <summary>
///     Actions are customizable behavior which can be executed in certain widgets such as Popups, a BasemapLayerList, or a LayerList.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html">ArcGIS JS API</a>
/// </summary>
/// <remarks>
///     The Action Sections property and corresponding functionality will be fully implemented
///     in a future iteration.  Currently, a user can view available layers in the layer list widget
///     and toggle the selected layer's visibility. More capabilities will be available after full
///     implementation of ActionSection.
/// </remarks>
public abstract class ActionBase
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
    
    /// <summary>
    ///     Set this property to true to display a spinner icon. You should do this if the action executes an async operation, such as a query, that requires letting the end user know that a process is ongoing in the background. Set the property back to false to communicate to the user that the process has finished.
    /// </summary>
    public bool? Active { get; set; }
    
    /// <summary>
    ///     Indicates whether this action is disabled.
    /// </summary>
    public bool? Disabled { get; set; }
    
    /// <summary>
    ///     Indicates if the action is visible.
    /// </summary>
    public bool? Visible { get; set; }

    /// <summary>
    ///     Specifies the type of action. Choose between "button" or "toggle".
    /// </summary>
    public virtual string Type { get; } = default!;
}

/// <summary>
///     A customizable button that performs a specific action(s) used in widgets such as the Popup, LayerList, and BasemapLayerList.
/// </summary>
public class ActionButton : ActionBase
{
    /// <inheritdoc />
    public override string Type => "button";
    
    /// <summary>
    ///     The URL to an image that will be used to represent the action. This property will be used as a background image for the node. It may be used in conjunction with the className property or by itself. If neither image nor className are specified, a default icon will display
    /// </summary>
    public string? Image { get; set; }
}

/// <summary>
///     A customizable toggle used in the LayerList widget that performs a specific action(s) which can be toggled on/off.
/// </summary>
public class ActionToggle : ActionBase
{
    /// <inheritdoc />
    public override string Type => "toggle";
    
    /// <summary>
    ///     Indicates the value of whether the action is toggled on/off.
    /// </summary>
    public bool? Value { get; set; }
}