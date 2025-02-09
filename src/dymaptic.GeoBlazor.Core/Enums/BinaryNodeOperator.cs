namespace dymaptic.GeoBlazor.Core.Enums;
/// <summary>
///     Defines the way two expressions are combined to yield a single result.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-sql-WhereClause.html#BinaryNode">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(BinaryNodeOperatorConverter))]
[CodeGenerationIgnore]
public enum BinaryNodeOperator
{
#pragma warning disable CS1591
    And,
    Or,
    Is,
    IsNot,
    In,
    NotIn,
    Between,
    NotBetween,
    Like,
    NotLike,
    NotEqualTo,
    LessThan,
    GreaterThan,
    GreaterThanOrEqualTo,
    LessThanOrEqualTo,
    EqualTo,
    Times,
    Minus,
    Plus,
    DividedBy
#pragma warning restore CS1591
}

internal class BinaryNodeOperatorConverter : JsonConverter<BinaryNodeOperator>
{
    public override BinaryNodeOperator Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        return value switch
        {
            "AND" => BinaryNodeOperator.And,
            "OR" => BinaryNodeOperator.Or,
            "IS" => BinaryNodeOperator.Is,
            "ISNOT" => BinaryNodeOperator.IsNot,
            "IN" => BinaryNodeOperator.In,
            "NOT IN" => BinaryNodeOperator.NotIn,
            "BETWEEN" => BinaryNodeOperator.Between,
            "NOTBETWEEN" => BinaryNodeOperator.NotBetween,
            "LIKE" => BinaryNodeOperator.Like,
            "NOT LIKE" => BinaryNodeOperator.NotLike,
            "<>" => BinaryNodeOperator.NotEqualTo,
            "<" => BinaryNodeOperator.LessThan,
            ">" => BinaryNodeOperator.GreaterThan,
            ">=" => BinaryNodeOperator.GreaterThanOrEqualTo,
            "<=" => BinaryNodeOperator.LessThanOrEqualTo,
            "=" => BinaryNodeOperator.EqualTo,
            "*" => BinaryNodeOperator.Times,
            "-" => BinaryNodeOperator.Minus,
            "+" => BinaryNodeOperator.Plus,
            "/" => BinaryNodeOperator.DividedBy,
            _ => throw new JsonException()};
    }

    public override void Write(Utf8JsonWriter writer, BinaryNodeOperator value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            BinaryNodeOperator.And => "AND",
            BinaryNodeOperator.Or => "OR",
            BinaryNodeOperator.Is => "IS",
            BinaryNodeOperator.IsNot => "ISNOT",
            BinaryNodeOperator.In => "IN",
            BinaryNodeOperator.NotIn => "NOT IN",
            BinaryNodeOperator.Between => "BETWEEN",
            BinaryNodeOperator.NotBetween => "NOTBETWEEN",
            BinaryNodeOperator.Like => "LIKE",
            BinaryNodeOperator.NotLike => "NOT LIKE",
            BinaryNodeOperator.NotEqualTo => "<>",
            BinaryNodeOperator.LessThan => "<",
            BinaryNodeOperator.GreaterThan => ">",
            BinaryNodeOperator.GreaterThanOrEqualTo => ">=",
            BinaryNodeOperator.LessThanOrEqualTo => "<=",
            BinaryNodeOperator.EqualTo => "=",
            BinaryNodeOperator.Times => "*",
            BinaryNodeOperator.Minus => "-",
            BinaryNodeOperator.Plus => "+",
            BinaryNodeOperator.DividedBy => "/",
            _ => throw new JsonException()});
    }
}
