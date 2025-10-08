namespace dymaptic.GeoBlazor.Core.Components.Popups;

public partial class PopupExpressionInfo : MapComponent, IProtobufSerializable
{
    internal PopupExpressionInfoSerializationRecord ToSerializationRecord()
    {
        return new PopupExpressionInfoSerializationRecord(Id.ToString(), Expression, Name, Title, ReturnType);
    }
    
    public MapComponentSerializationRecord ToProtobuf()
    {
        return ToSerializationRecord();
    }
}

[ProtoContract(Name = "ExpressionInfo")]
internal record PopupExpressionInfoSerializationRecord : MapComponentSerializationRecord
{
    public PopupExpressionInfoSerializationRecord()
    {
    }

    public PopupExpressionInfoSerializationRecord(string Id, string? Expression, string? Name, string? Title, 
        PopupExpressionInfoReturnType? ReturnType)
    {
        this.Id = Id;
        this.Expression = Expression;
        this.Name = Name;
        this.Title = Title;
        this.ReturnType = ReturnType.ToString();
    }

    public PopupExpressionInfo FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();

        if (Guid.TryParse(Id, out Guid guid))
        {
            id = guid;
        }
        
        return new PopupExpressionInfo(Expression, Name, 
            ReturnType is null ? null : Enum.Parse<PopupExpressionInfoReturnType>(ReturnType),
            Title) { Id = id };
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
    
    [ProtoMember(5)]
    public string? Id { get; init; }
}