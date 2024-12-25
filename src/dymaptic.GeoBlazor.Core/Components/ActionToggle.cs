namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A customizable toggle used in the LayerList widget that performs a specific action(s) which can be toggled on/off.
/// </summary>
public class ActionToggle : ActionBase
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    public ActionToggle()
    {
    }

    /// <summary>
    ///    Constructor for use in code.
    /// </summary>
    /// <param name="title">
    ///     The title of the action.
    /// </param>
    /// <param name="id">
    ///     The name of the ID assigned to this action.
    /// </param>
    /// <param name="callbackFunction">
    ///     The action function to perform on click.
    /// </param>
    /// <param name="value">
    ///     Indicates the value of whether the action is toggled on/off.
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
    public ActionToggle(string? title = null, string? id = null, Func<Task>? callbackFunction = null,
        bool? value = null, bool? active = null, bool? disabled = null, bool? visible = null)
    {
#pragma warning disable BL0005
        Title = title;
        Id = id;
        CallbackFunction = callbackFunction;
        Value = value;
        Active = active;
        Disabled = disabled;
        Visible = visible;
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

    internal override ActionBaseSerializationRecord ToSerializationRecord()
    {
        return new ActionBaseSerializationRecord(Type, Title, null, Active, Disabled, Visible, Id)
        {
            Value = Value
        };
    }
}