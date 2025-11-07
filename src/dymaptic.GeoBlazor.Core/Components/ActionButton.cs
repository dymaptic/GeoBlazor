namespace dymaptic.GeoBlazor.Core.Components;

[CodeGenerationIgnore]
public partial class ActionButton : ActionBase
{
    /// <inheritdoc />
    public override string Type => "button";

    /// <summary>
    ///     The URL to an image that will be used to represent the action. This property will be used as a background image for the node. It may be used in conjunction with the className property or by itself. If neither image nor className are specified, a default icon will display
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Image { get; set; }

    public override ActionBaseSerializationRecord ToProtobuf()
    {
        return new ActionBaseSerializationRecord(Id.ToString(), Type, Title, ClassName, Active, Disabled, Visible, ActionId)
        {
            Image = Image
        };
    }
}