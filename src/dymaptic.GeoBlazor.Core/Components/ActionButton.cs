namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A customizable button that performs a specific action(s) used in widgets such as the Popup, LayerList, and
///     BasemapLayerList.
/// </summary>
public class ActionButton : ActionBase
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    public ActionButton()
    {
    }

    /// <summary>
    ///    Constructor for use in code.
    /// </summary>
    /// <param name="title">
    ///     The title of the action.
    /// </param>
    /// <param name="image">
    ///     The URL to an image that will be used to represent the action. This property will be used as a background image
    /// </param>
    /// <param name="id">
    ///     The name of the ID assigned to this action.
    /// </param>
    /// <param name="callbackFunction">
    ///     The action function to perform on click.
    /// </param>
    /// <param name="className">
    ///     This adds a CSS class to the ActionButton's node.
    /// </param>
    /// <param name="active">
    ///     Set this property to true to display a spinner icon.
    /// </param>
    /// <param name="disabled">
    ///     Indicates whether this action is disabled.
    /// </param>
    /// <param name="visible">
    ///     Indicates if the action is visible.
    /// </param>
    public ActionButton(string? title = null, string? image = null, string? id = null,
        Func<Task>? callbackFunction = null, string? className = null, bool? active = null, bool? disabled = null,
        bool? visible = null)
    {
#pragma warning disable BL0005
        Title = title;
        Image = image;
        Id = id;
        CallbackFunction = callbackFunction;
        ClassName = className;
        Active = active;
        Disabled = disabled;
        Visible = visible;
#pragma warning restore BL0005
    }
    
    /// <inheritdoc />
    public override string Type => "button";

    /// <summary>
    ///     The URL to an image that will be used to represent the action. This property will be used as a background image for
    ///     the node. It may be used in conjunction with the className property or by itself. If neither image nor className
    ///     are specified, a default icon will display
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Image { get; set; }

    internal override ActionBaseSerializationRecord ToSerializationRecord()
    {
        return new ActionBaseSerializationRecord(Type, Title, ClassName, Active, Disabled, Visible, Id)
        {
            Image = Image
        };
    }
}