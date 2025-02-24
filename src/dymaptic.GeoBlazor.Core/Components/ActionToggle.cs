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

    internal override ActionBaseSerializationRecord ToSerializationRecord()
    {
        return new ActionBaseSerializationRecord(Type, Title, null, Active, Disabled, Visible, Id)
        {
            Value = Value
        };
    }
}