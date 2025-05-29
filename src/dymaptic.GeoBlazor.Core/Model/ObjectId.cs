namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Wraps the string and numeric possibilities of ObjectIds from ArcGIS.
/// </summary>
/// <param name="stringVal">
///     The string value of the ObjectId.
/// </param>
[JsonConverter(typeof(ObjectIdConverter))]
public class ObjectId(string stringVal) : IEquatable<ObjectId>
{
    /// <summary>
    ///     Constructor for ObjectId that takes a numeric (long) value.
    /// </summary>
    public ObjectId(long numericVal) : this(numericVal.ToString())
    {
        NumericVal = numericVal;
    }

    /// <summary>
    ///     The string value of the ObjectId. If the ObjectId is numeric, this will be the string representation of the number.
    /// </summary>
    public string StringVal { get; } = stringVal;

    /// <summary>
    ///     The numeric value of the ObjectId, if applicable.
    /// </summary>
    public long? NumericVal { get; }
    
    /// <summary>
    ///     Implicit conversion from ObjectId to long. If the ObjectId is not numeric, this will return 0.
    /// </summary>
    public static implicit operator long(ObjectId objectId) => objectId.NumericVal ?? 0;
    
    /// <summary>
    ///     Implicit conversion from ObjectId to string. If the ObjectId is numeric, this will return the string representation of the number.
    /// </summary>
    public static implicit operator string(ObjectId objectId) => objectId.StringVal;
    
    /// <summary>
    ///     Implicit conversion from string to ObjectId. This will create a new ObjectId with the string value.
    /// </summary>
    public static implicit operator ObjectId(string stringVal) => new(stringVal);
    
    /// <summary>
    ///     Implicit conversion from long to ObjectId. This will create a new ObjectId with the numeric value.
    /// </summary>
    public static implicit operator ObjectId(long numericVal) => new(numericVal);
    
    /// <summary>
    ///     Equality check for ObjectId. Two ObjectIds are equal if their string values are equal, ignoring case.
    /// </summary>
    public bool Equals(ObjectId? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return string.Equals(StringVal, other.StringVal, StringComparison.OrdinalIgnoreCase);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is ObjectId other && Equals(other);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(StringVal, NumericVal);
    }

    /// <summary>
    ///     Overrides the equality operator to compare ObjectIds.
    /// </summary>
    public static bool operator ==(ObjectId? left, ObjectId? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Overrides the inequality operator to compare ObjectIds.
    /// </summary>
    public static bool operator !=(ObjectId? left, ObjectId? right)
    {
        return !Equals(left, right);
    }

    /// <inheritdoc />
    public override string ToString() => StringVal;
}

internal class ObjectIdConverter : JsonConverter<ObjectId>
{
    public override ObjectId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string stringVal = reader.GetString()!;
            return new ObjectId(stringVal);
        }

        if (reader.TokenType == JsonTokenType.Number)
        {
            long numericVal = reader.GetInt64();
            return new ObjectId(numericVal);
        }

        throw new JsonException($"Unexpected token {reader.TokenType} when parsing ObjectId.");
    }

    public override void Write(Utf8JsonWriter writer, ObjectId value, JsonSerializerOptions options)
    {
        if (value.NumericVal.HasValue)
        {
            writer.WriteNumberValue(value.NumericVal.Value);
        }
        else
        {
            writer.WriteStringValue(value.StringVal);
        }
    }
}