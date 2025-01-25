namespace dymaptic.GeoBlazor.Core.Components;

public partial class ExpressionInfo : MapComponent
{


    /// <summary>
    ///     An Arcade expression following the specification defined by the Arcade Popup Profile. Expressions must return a
    ///     string or a number and may access data values from the feature, its layer, or other layers in the map or datastore
    ///     with the $feature, $layer, $map, and $datastore profile variables.
    /// </summary>
    [Parameter]
    public string? Expression { get; set; }

    /// <summary>
    ///     The name of the expression. This is used to reference the value of the given expression in the popupTemplate's
    ///     content property by wrapping it in curly braces and prefacing it with expression/ (e.g.
    ///     {expression/expressionName}).
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    /// <summary>
    ///     The title used to describe the value returned by the expression in the popup. This will display if the value is
    ///     referenced in a FieldInfo table.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     Indicates the return type of the Arcade expression.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ExpressionInfoReturnType? ReturnType { get; set; }

    internal ExpressionInfoSerializationRecord ToSerializationRecord()
    {
        return new ExpressionInfoSerializationRecord(Expression, Name, Title, ReturnType);
    }
}

[ProtoContract(Name = "ExpressionInfo")]
internal record ExpressionInfoSerializationRecord : MapComponentSerializationRecord
{
    public ExpressionInfoSerializationRecord()
    {
    }

    public ExpressionInfoSerializationRecord(string? Expression, string? Name, string? Title, ExpressionInfoReturnType? ReturnType)
    {
        this.Expression = Expression;
        this.Name = Name;
        this.Title = Title;
        this.ReturnType = ReturnType;
    }

    public ExpressionInfo FromSerializationRecord()
    {
        return new ExpressionInfo();
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
    public ExpressionInfoReturnType? ReturnType { get; init; }
}