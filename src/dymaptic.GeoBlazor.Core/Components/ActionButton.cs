namespace dymaptic.GeoBlazor.Core.Components;

[ProtobufSerializable]
public partial class ActionButton : ActionBase
{
    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="title">
    ///     The title of the action.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="image">
    ///     The URL to an image that will be used to represent the action.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionButton.html#image">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="actionId">
    ///     The name of the ID assigned to this action.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="callbackFunction">
    ///     The action function to perform on click.
    /// </param>
    /// <param name="className">
    ///     This adds a CSS class to the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionButton.html">ActionButton's</a> node.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#className">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="active">
    ///     Set this property to `true` to display a spinner icon.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#active">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="disabled">
    ///     Indicates whether this action is disabled.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#disabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visible">
    ///     Indicates if the action is visible.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#visible">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="icon">
    ///     Calcite icon used for the action.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#icon">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public ActionButton(string? title = null,
        string? image = null,
        string? actionId = null,
        Func<Task>? callbackFunction = null,
        string? className = null,
        bool? active = null,
        bool? disabled = null,
        bool? visible = null,
        string? icon = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Title = title;
        Image = image;
        ActionId = actionId;
        CallbackFunction = callbackFunction;
        ClassName = className;
        Active = active;
        Disabled = disabled;
        Visible = visible;
        Icon = icon;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    public override string Type => "button";

    /// <summary>
    ///     The URL to an image that will be used to represent the action. This property will be used as a background image for the node. It may be used in conjunction with the className property or by itself. If neither image nor className are specified, a default icon will display
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Image { get; set; }

    /// <inheritdoc />
    public override ActionBaseSerializationRecord ToProtobuf()
    {
        return new ActionBaseSerializationRecord(Id.ToString(), Type, Title, ClassName, Active, Disabled, Visible, ActionId)
        {
            Image = Image
        };
    }
}