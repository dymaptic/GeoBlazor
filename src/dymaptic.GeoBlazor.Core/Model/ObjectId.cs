namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Wraps the string and numeric possibilities of ObjectIds from ArcGIS.
/// </summary>
[JsonConverter(typeof(ObjectIdConverter))]
public class ObjectId(string stringVal) : IEquatable<ObjectId>
{
    public ObjectId(long numericVal) : this(numericVal.ToString())
    {
        NumericVal = numericVal;
    }

    public string StringVal { get; } = stringVal;

    public long? NumericVal { get; }
    
    public static implicit operator long(ObjectId objectId) => objectId.NumericVal ?? 0;
    public static implicit operator string(ObjectId objectId) => objectId.StringVal;
    public static implicit operator ObjectId(string stringVal) => new(stringVal);
    public static implicit operator ObjectId(long numericVal) => new(numericVal);
    
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

    public override bool Equals(object? obj)
    {
        return obj is ObjectId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(StringVal, NumericVal);
    }

    public static bool operator ==(ObjectId? left, ObjectId? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ObjectId? left, ObjectId? right)
    {
        return !Equals(left, right);
    }

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