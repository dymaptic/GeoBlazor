namespace dymaptic.GeoBlazor.Core.Components;

[CodeGenerationIgnore]
public partial class ActionToggle : ActionBase
{


    /// <inheritdoc />
    public override string Type => "toggle";

    /// <summary>
    ///     Indicates the value of whether the action is toggled on/off.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Value { get; set; }

    public override ActionBaseSerializationRecord ToProtobuf()
    {
        return new ActionBaseSerializationRecord(Id.ToString(), Type, Title, null, Active, Disabled, Visible, ActionId)
        {
            Value = Value
        };
    }
}