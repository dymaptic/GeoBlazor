namespace dymaptic.GeoBlazor.Core.Components;

public partial class ElementExpressionInfo
{
   // Add custom code to this file to override generated code
   
      internal ElementExpressionInfoSerializationRecord ToSerializationRecord()
      {
         return new ElementExpressionInfoSerializationRecord(Expression, Title);
      }
}

[ProtoContract(Name = "ElementExpressionInfo")]
internal record ElementExpressionInfoSerializationRecord: MapComponentSerializationRecord
{
    public ElementExpressionInfoSerializationRecord()
    {
    }
    
    public ElementExpressionInfoSerializationRecord(string? expression, string? title)
    {
        Expression = expression;
        Title = title;
    }
    
    [ProtoMember(1)]
    public string? Expression { get; init; }
    
    [ProtoMember(2)]
    public string? Title { get; init; }
    
    public ElementExpressionInfo FromSerializationRecord()
    {
        return new ElementExpressionInfo(Expression, Title);
    }
}