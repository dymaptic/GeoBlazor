using Microsoft.AspNetCore.Components;
using ProtoBuf;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Observable Dictionary
/// </summary>
[JsonConverter(typeof(AttributesDictionaryConverter))]
public class AttributesDictionary : IEquatable<AttributesDictionary>
{
    private readonly Dictionary<string, object> _backingDictionary;

    /// <summary>
    ///     Constructor
    /// </summary>
    public AttributesDictionary()
    {
        _backingDictionary = new Dictionary<string, object>();
    }

    /// <summary>
    ///     Constructor from existing dictionary
    /// </summary>
    /// <param name="dictionary">
    ///     The dictionary to use
    /// </param>
    public AttributesDictionary(Dictionary<string, object> dictionary)
    {
        _backingDictionary = new Dictionary<string, object>();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        foreach (KeyValuePair<string, object> kvp in dictionary)
        {
            if (kvp.Value is JsonElement jsonElement)
            {
                object? typedValue = jsonElement.ValueKind switch
                {
                    JsonValueKind.Object => jsonElement.Deserialize(typeof(object), options),
                    JsonValueKind.Array => jsonElement.Deserialize(typeof(IEnumerable<object>), options),
                    JsonValueKind.False => false,
                    JsonValueKind.True => true,
                    JsonValueKind.Number => jsonElement.ToString().Contains('.')
                        ? Convert.ChangeType(jsonElement.ToString(), TypeCode.Double)
                        : Convert.ChangeType(jsonElement.ToString(), TypeCode.Int64),
                    JsonValueKind.String => jsonElement.ToString(),
                    _ => jsonElement
                };
                _backingDictionary[kvp.Key] = (typedValue ?? default(object))!;
            }
            else
            {
                _backingDictionary[kvp.Key] = kvp.Value;
            }
        }
    }
    
    [Obsolete("Using a Dictionary<string, object> for attributes is deprecated. Use an AttributesDictionary(Dictionary<string, object> dictionary) instead.")]
    public static implicit operator AttributesDictionary(Dictionary<string, object> dictionary)
    {
        Debug.WriteLine("Using a Dictionary<string, object> for attributes is deprecated. Use an AttributesDictionary(Dictionary<string, object> dictionary) instead.");
        return new AttributesDictionary(dictionary);
    }
    
    public static explicit operator Dictionary<string, object>(AttributesDictionary attributesDictionary)
    {
        return attributesDictionary._backingDictionary;
    }

    [JsonIgnore]
    public EventCallback OnChange { get; set; }
    
    public int Count => _backingDictionary.Count;
    
    public bool TryGetValue(string key, out object? value) => _backingDictionary.TryGetValue(key, out value);
    
    public async Task AddOrUpdate(string key, object value)
    {
        _backingDictionary[key] = value;

        await OnChange.InvokeAsync();
    }

    public async Task Remove(string key)
    {
        _backingDictionary.Remove(key);

        await OnChange.InvokeAsync();
    }

    public async Task Clear()
    {
        _backingDictionary.Clear();

        await OnChange.InvokeAsync();
    }
    
    public object this[string key] => _backingDictionary[key];
    
    public Dictionary<string, object>.KeyCollection Keys => _backingDictionary.Keys;
    
    public Dictionary<string, object>.ValueCollection Values => _backingDictionary.Values;

    public bool ContainsKey(string key) => _backingDictionary.ContainsKey(key);
    
    public bool ContainsValue(object value) => _backingDictionary.ContainsValue(value);

    internal AttributeSerializationRecord[] ToSerializationRecord()
    {
        return _backingDictionary
            .Select(kvp =>
                new AttributeSerializationRecord(kvp.Key, kvp.Value.ToString(), 
                    kvp.Value.GetType().ToString()))
            .ToArray();
    }

    public static bool operator ==(AttributesDictionary left, AttributesDictionary right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(AttributesDictionary? left, AttributesDictionary? right)
    {
        return !Equals(left, right);
    }

    public bool Equals(AttributesDictionary? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (other.Count != Count) return false;

        foreach (KeyValuePair<string, object> pair in _backingDictionary)
        {
            if (!other.TryGetValue(pair.Key, out object? value)) return false;

            if (value is null)
            {
                return false;
            }

            if (!value.Equals(pair.Value)) return false;
        }

        return true;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((AttributesDictionary)obj);
    }

    public bool Equals(Dictionary<string, object> otherDictionary)
    {
        if (otherDictionary.Count != Count) return false;

        foreach (KeyValuePair<string, object> pair in _backingDictionary)
        {
            if (!otherDictionary.TryGetValue(pair.Key, out object? value)) return false;

            if (!value.Equals(pair.Value)) return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

[ProtoContract(Name = "Attribute")]
internal record AttributeSerializationRecord([property: ProtoMember(1)] string Key,
    [property: ProtoMember(2)] string? Value, [property: ProtoMember(3)] string ValueType);

internal class AttributesDictionaryConverter : JsonConverter<AttributesDictionary>
{
    public override AttributesDictionary? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // read as a dictionary
        Dictionary<string, object>? dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(ref reader, options);

        if (dictionary is null)
        {
            return null;
        }

        return new AttributesDictionary(dictionary);
    }

    public override void Write(Utf8JsonWriter writer, AttributesDictionary value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var entry in (Dictionary<string, object>)value)
        {
            writer.WriteStartObject();
            writer.WriteString("key", entry.Key);
            writer.WriteString("value", entry.Value.ToString());
            writer.WriteString("valueType", entry.Value.GetType().ToString());
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
    }
}