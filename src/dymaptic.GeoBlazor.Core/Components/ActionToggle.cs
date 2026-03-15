namespace dymaptic.GeoBlazor.Core.Components;

[ProtobufSerializable]
public partial class ActionToggle : ActionBase
{
    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="title">
    ///     The title of the action.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="actionId">
    ///     The name of the ID assigned to this action.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="callbackFunction">
    ///     The action function to perform on click.
    /// </param>
    /// <param name="value">
    ///     Indicates the value of whether the action is toggled on/off.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionToggle.html#value">ArcGIS Maps SDK for JavaScript</a>
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
    /// <param name="className">
    ///     This adds a CSS class to the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionButton.html">ActionButton's</a>
    ///     node.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#className">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="icon">
    ///     Calcite icon used for the action.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#icon">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public ActionToggle(string? title = null,
        string? actionId = null,
        Func<Task>? callbackFunction = null,
        bool? value = null,
        bool? active = null,
        bool? disabled = null,
        bool? visible = null,
        string? className = null,
        string? icon = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Title = title;
        ActionId = actionId;
        CallbackFunction = callbackFunction;
        Value = value;
        Active = active;
        Disabled = disabled;
        Visible = visible;
        ClassName = className;
        Icon = icon;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    public override string Type => "toggle";

    /// <summary>
    ///     Indicates the value of whether the action is toggled on/off.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Value { get; set; }

    /// <inheritdoc />
    public override ActionBaseSerializationRecord ToProtobuf()
    {
        return new ActionBaseSerializationRecord(Id.ToString(), Type, Title, null, Active, Disabled, Visible, ActionId)
        {
            Value = Value
        };
    }
}