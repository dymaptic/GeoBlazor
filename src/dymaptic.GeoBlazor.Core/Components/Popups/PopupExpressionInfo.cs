namespace dymaptic.GeoBlazor.Core.Components.Popups;

public partial class PopupExpressionInfo : MapComponent
{
    internal PopupExpressionInfoSerializationRecord ToSerializationRecord()
    {
        return new PopupExpressionInfoSerializationRecord(Expression, Name, Title, ReturnType);
    }
}

[ProtoContract(Name = "ExpressionInfo")]
internal record PopupExpressionInfoSerializationRecord : MapComponentSerializationRecord
{
    public PopupExpressionInfoSerializationRecord()
    {
    }

    public PopupExpressionInfoSerializationRecord(string? Expression, string? Name, string? Title, 
        PopupExpressionInfoReturnType? ReturnType)
    {
        this.Expression = Expression;
        this.Name = Name;
        this.Title = Title;
        this.ReturnType = ReturnType.ToString();
    }

    public PopupExpressionInfo FromSerializationRecord()
    {
        return new PopupExpressionInfo(Expression, Name, 
            ReturnType is null ? null : Enum.Parse<PopupExpressionInfoReturnType>(ReturnType),
            Title);
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? Expression { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Name { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? Title { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public string? ReturnType { get; init; }
}