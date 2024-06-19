using dymaptic.GeoBlazor.Core.Components;
using ProtoBuf;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Dictionary of Graphic Attributes that can be asynchronously updated
/// </summary>
[JsonConverter(typeof(AttributesDictionaryConverter))]
public class AttributesDictionary : IEquatable<AttributesDictionary>
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public AttributesDictionary()
    {
        _backingDictionary = new Dictionary<string, object?>();
    }

    /// <summary>
    ///     Constructor from existing dictionary
    /// </summary>
    /// <param name="dictionary">
    ///     The dictionary to use
    /// </param>
    public AttributesDictionary(Dictionary<string, object?> dictionary)
    {
        _backingDictionary = new Dictionary<string, object?>();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        foreach (KeyValuePair<string, object?> kvp in dictionary)
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
                if (typedValue is string stringValue && Guid.TryParse(stringValue, out Guid guidValue))
                {
                    typedValue = guidValue;
                }
                _backingDictionary[kvp.Key] = (typedValue ?? default(object?))!;
            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            else if (kvp.Value is null) // could be null from serialization
            {
                _backingDictionary[kvp.Key] = string.Empty;
            }
            else
            {
                _backingDictionary[kvp.Key] = kvp.Value;
            }
        }
    }

    internal AttributesDictionary(AttributeSerializationRecord[]? serializedAttributes)
    {
        _backingDictionary = new Dictionary<string, object?>();

        if (serializedAttributes is not null)
        {
            foreach (AttributeSerializationRecord record in serializedAttributes)
            {
                switch (record.ValueType)
                {
                    case "[object Number]":
                        _backingDictionary[record.Key] = double.Parse(record.Value!, CultureInfo.CurrentCulture);
                        
                        break;
                    case "[object Boolean]":
                        _backingDictionary[record.Key] = bool.Parse(record.Value!);

                        break;
                    case "[object String]":
                        if (Guid.TryParse(record.Value, out Guid guidValue))
                        {
                            _backingDictionary[record.Key] = guidValue;
                        }
                        else
                        {
                            _backingDictionary[record.Key] = record.Value;
                        }

                        break;
                    case "[object Date]":
                        _backingDictionary[record.Key] = DateTime.Parse(record.Value!, CultureInfo.CurrentCulture);

                        break;
                    default:
                        _backingDictionary[record.Key] = record.Value;

                        break;
                }
            }
        }
    }

    /// <summary>
    ///     Explicit conversion from AttributesDictionary to <see cref="Dictionary{TKey,TValue}" />.
    /// </summary>
    public static explicit operator Dictionary<string, object?>(AttributesDictionary attributesDictionary)
    {
        return attributesDictionary._backingDictionary;
    }

    /// <summary>
    ///     Equality operator
    /// </summary>
    public static bool operator ==(AttributesDictionary left, AttributesDictionary right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Inequality operator
    /// </summary>
    public static bool operator !=(AttributesDictionary? left, AttributesDictionary? right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    ///     Event that is fired when an attribute is added, updated or removed
    /// </summary>
    [JsonIgnore]
    public Func<Task>? OnChange { get; set; }

    /// <summary>
    ///     The number of attribute entries in the dictionary
    /// </summary>
    public int Count => _backingDictionary.Count;

    /// <summary>
    ///     Returns all the keys in the dictionary
    /// </summary>
    public Dictionary<string, object?>.KeyCollection Keys => _backingDictionary.Keys;

    /// <summary>
    ///     Returns all the values in the dictionary
    /// </summary>
    public Dictionary<string, object?>.ValueCollection Values => _backingDictionary.Values;

    /// <inheritdoc />
    public bool Equals(AttributesDictionary? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (other.Count != Count) return false;

        foreach (KeyValuePair<string, object?> pair in _backingDictionary)
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

    /// <summary>
    ///     Attempts to get the value associated with the specified key from the dictionary.
    /// </summary>
    /// <param name="key">
    ///     The key to search for
    /// </param>
    /// <param name="value">
    ///     Out parameter for the found value, if any. If not found, returns the default value for the type.
    /// </param>
    /// <returns>
    ///     True if the key was found, false otherwise.
    /// </returns>
    public bool TryGetValue(string key, out object? value)
    {
        return _backingDictionary.TryGetValue(key, out value);
    }

    /// <summary>
    ///     Adds or updates the value associated with the specified key.
    /// </summary>
    /// <param name="key">
    ///     The key to add or update
    /// </param>
    /// <param name="value">
    ///     The value to add or update
    /// </param>
    public async Task AddOrUpdate(string key, object value)
    {
        _backingDictionary[key] = value;

        if (OnChange is not null)
        {
            await OnChange();
        }
    }

    /// <summary>
    ///     Updates the AttributesDictionary with new key/value pairs from a <see cref="Dictionary{TKey,TValue}" />
    /// </summary>
    /// <param name="newEntries">
    ///     The new key/value pairs to add or update
    /// </param>
    public async Task AddOrUpdate(Dictionary<string, object> newEntries)
    {
        foreach (KeyValuePair<string, object> kvp in newEntries)
        {
            _backingDictionary[kvp.Key] = kvp.Value;
        }

        if (OnChange is not null)
        {
            await OnChange();
        }
    }

    /// <summary>
    ///     Removes the value associated with the specified key.
    /// </summary>
    /// <param name="key">
    ///     The key to remove
    /// </param>
    public async Task Remove(string key)
    {
        _backingDictionary.Remove(key);

        if (OnChange is not null)
        {
            await OnChange();
        }
    }

    /// <summary>
    ///     Removes all keys and values from the dictionary.
    /// </summary>
    public async Task Clear()
    {
        _backingDictionary.Clear();

        if (OnChange is not null)
        {
            await OnChange();
        }
    }

    /// <summary>
    ///     Determines whether the dictionary contains the specified key.
    /// </summary>
    /// <param name="key">
    ///     The key to locate in the dictionary
    /// </param>
    /// <returns>
    ///     True if the key was found, false otherwise.
    /// </returns>
    public bool ContainsKey(string key)
    {
        return _backingDictionary.ContainsKey(key);
    }

    /// <summary>
    ///     Determines whether the dictionary contains the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value to locate in the dictionary
    /// </param>
    /// <returns>
    ///     True if the value was found, false otherwise.
    /// </returns>
    public bool ContainsValue(object value)
    {
        return _backingDictionary.ContainsValue(value);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((AttributesDictionary)obj);
    }

    /// <summary>
    ///     Determines whether the dictionary contains the same keys and values as the specified dictionary.
    /// </summary>
    public bool Equals(Dictionary<string, object> otherDictionary)
    {
        if (otherDictionary.Count != Count) return false;

        foreach (KeyValuePair<string, object?> pair in _backingDictionary)
        {
            if (!otherDictionary.TryGetValue(pair.Key, out object? value)) return false;

            if (!value.Equals(pair.Value)) return false;
        }

        return true;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    internal AttributeSerializationRecord[] ToSerializationRecord()
    {
        return _backingDictionary
            .Select(kvp =>
                new AttributeSerializationRecord(kvp.Key, kvp.Value?.ToString(),
                    kvp.Value?.GetType().ToString() ?? "null"))
            .ToArray();
    }

    private readonly Dictionary<string, object?> _backingDictionary;

    /// <summary>
    ///     Gets the value associated with the specified key.
    /// </summary>
    /// <param name="key">
    ///     The key to get the value for
    /// </param>
    public object? this[string key] => _backingDictionary[key];
}

[ProtoContract(Name = "Attribute")]
internal record AttributeSerializationRecord : MapComponentSerializationRecord
{
    public AttributeSerializationRecord()
    {
    }
    
    public AttributeSerializationRecord(string Key,
        string? Value,
        string ValueType)
    {
        this.Key = Key;
        this.Value = Value;
        this.ValueType = ValueType;
    }

    [ProtoMember(1)]
    public string Key { get; init; } = string.Empty;
    [ProtoMember(2)]
    public string? Value { get; init; }
    [ProtoMember(3)]
    public string ValueType { get; init; } = string.Empty;
}

internal class AttributesDictionaryConverter : JsonConverter<AttributesDictionary>
{
    public override AttributesDictionary? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        // read as a dictionary
        Dictionary<string, object?>? dictionary =
            JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, options);

        if (dictionary is null)
        {
            return null;
        }

        return new AttributesDictionary(dictionary);
    }

    public override void Write(Utf8JsonWriter writer, AttributesDictionary value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (KeyValuePair<string, object?> entry in (Dictionary<string, object?>)value)
        {
            writer.WriteStartObject();
            writer.WriteString("key", entry.Key);
            writer.WriteString("value", entry.Value?.ToString());
            writer.WriteString("valueType", entry.Value?.GetType().ToString() ?? "null");
            writer.WriteEndObject();
        }

        writer.WriteEndArray();
    }
}