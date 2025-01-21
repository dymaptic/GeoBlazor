namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Dictionary of Graphic Attributes that can be asynchronously updated
/// </summary>
[JsonConverter(typeof(AttributesDictionaryConverter))]
public class AttributesDictionary : IEquatable<AttributesDictionary>, IEnumerable<KeyValuePair<string, object?>>
{
    /// <summary>
    ///     Constructor for a new, empty dictionary
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
                    JsonValueKind.Number => double.Parse(jsonElement.ToString(), CultureInfo.InvariantCulture),
                    JsonValueKind.String => jsonElement.ToString(),
                    _ => jsonElement
                };

                if (typedValue is double)
                {
                    if (int.TryParse(jsonElement.ToString(), NumberStyles.None, CultureInfo.InvariantCulture, out int intVal))
                    {
                        typedValue = intVal;
                    }
                    else if (long.TryParse(jsonElement.ToString(), NumberStyles.None, CultureInfo.InvariantCulture, out long longVal))
                    {
                        typedValue = longVal;
                    }
                }
                
                if (typedValue is string stringValue)
                {
                    if (Guid.TryParse(stringValue, out Guid guidValue))
                    {
                        typedValue = guidValue;
                    }
                    else if (DateTime.TryParse(stringValue, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
                    {
                        typedValue = dateValue;
                    }
                }
                _backingDictionary[kvp.Key] = (typedValue ?? default(object?))!;
            }
            _backingDictionary[kvp.Key] = kvp.Value;
        }
    }

    /// <summary>
    ///     Internal constructor for use with Protobuf deserialization
    /// </summary>
    /// <param name="serializedAttributes">
    ///     The serialized attributes to use.
    /// </param>
    internal AttributesDictionary(AttributeSerializationRecord[]? serializedAttributes)
    {
        _backingDictionary = new Dictionary<string, object?>();

        if (serializedAttributes is not null)
        {
            foreach (AttributeSerializationRecord record in serializedAttributes)
            {
                if (record.Value is null)
                {
                    _backingDictionary[record.Key] = null;
                    continue;
                }
                switch (record.ValueType)
                {
                    case "System.Int32":
                    case "integer":
                        _backingDictionary[record.Key] = int.Parse(record.Value!, CultureInfo.InvariantCulture);
                        
                        break;
                    case "System.Int16":
                    case "small-integer":
                        _backingDictionary[record.Key] = short.Parse(record.Value!, CultureInfo.InvariantCulture);
                        
                        break;
                    case "System.Int64":
                    case "big-integer":
                        _backingDictionary[record.Key] = long.Parse(record.Value!, CultureInfo.InvariantCulture);

                        break;
                    case "System.Single":
                    case "single":
                        _backingDictionary[record.Key] = float.Parse(record.Value!, CultureInfo.InvariantCulture);

                        break;
                    case "System.Double":
                    case "double":
                        _backingDictionary[record.Key] = double.Parse(record.Value!, CultureInfo.InvariantCulture);
                        
                        break;
                    case "[object Number]":
                        if (int.TryParse(record.Value, NumberStyles.None, CultureInfo.InvariantCulture, out int intVal))
                        {
                            _backingDictionary[record.Key] = intVal;
                        }
                        else if (long.TryParse(record.Value, NumberStyles.None, CultureInfo.InvariantCulture, out long longVal))
                        {
                            _backingDictionary[record.Key] = longVal;
                        }
                        else if (double.TryParse(record.Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double doubleVal))
                        {
                            _backingDictionary[record.Key] = doubleVal;
                        }
                        
                        break;
                    case "System.Boolean":
                    case "[object Boolean]":
                        _backingDictionary[record.Key] = bool.Parse(record.Value!);

                        break;
                    case "guid":
                        _backingDictionary[record.Key] = Guid.Parse(record.Value!);

                        break;
                    case "System.DateTime":
                    case "date":
                    case "timestamp-offset":
                    case "[object Date]":
                        // Date is serialized in ArcGIS as a long unix timestamp, so we check for this first.
                        if (long.TryParse(record.Value, out long unixTimestamp))
                        {
                            _backingDictionary[record.Key] = DateTimeOffset.FromUnixTimeMilliseconds(unixTimestamp).DateTime;
                        }
                        else
                        {
                            _backingDictionary[record.Key] = DateTime.Parse(record.Value!, CultureInfo.InvariantCulture);
                        }

                        break;
                    case "System.DateOnly":
                    case "date-only":
                        _backingDictionary[record.Key] = DateOnly.Parse(record.Value!, CultureInfo.InvariantCulture);

                        break;
                    case "System.TimeOnly":
                    case "time-only":
                        _backingDictionary[record.Key] = TimeOnly.Parse(record.Value!, CultureInfo.InvariantCulture);

                        break;
                    default:
                        if (Guid.TryParse(record.Value, out Guid guidValue))
                        {
                            _backingDictionary[record.Key] = guidValue;
                        }
                        else if (DateTime.TryParse(record.Value, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
                        {
                            _backingDictionary[record.Key] = dateValue;
                        }
                        else
                        {
                            _backingDictionary[record.Key] = record.Value;
                        }

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
    public async Task AddOrUpdate(string key, object? value)
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

    public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
    {
        return _backingDictionary.GetEnumerator();
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
        return _backingDictionary.GetHashCode();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    internal AttributeSerializationRecord[] ToSerializationRecord()
    {
        return _backingDictionary
            .Select(kvp =>
            {
                string valueType = kvp.Value?.GetType().ToString() ?? "null";
                string? stringVal = valueType switch
                {
                    "System.DateTime" => ((DateTime)kvp.Value!).ToString("O", CultureInfo.InvariantCulture),
                    "System.DateOnly" => ((DateOnly)kvp.Value!).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    "System.TimeOnly" => ((TimeOnly)kvp.Value!).ToString("HH:mm:ss", CultureInfo.InvariantCulture),
                    null => string.Empty,
                    _ => kvp.Value?.ToString()
                };
                return new AttributeSerializationRecord(kvp.Key, stringVal, valueType!);
            })
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
        // if first symbol is array
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            AttributeSerializationRecord[]? records = JsonSerializer.Deserialize<AttributeSerializationRecord[]>(ref reader, options);
            return new AttributesDictionary(records);
        }
        
        // read as a dictionary
        Dictionary<string, object?>? dictionary = JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, options);

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
            string valueType = entry.Value?.GetType().ToString() ?? "null";
            string? stringVal = valueType switch
            {
                "System.DateTime" => ((DateTime)entry.Value!).ToString("O", CultureInfo.InvariantCulture),
                "System.DateOnly" => ((DateOnly)entry.Value!).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                "System.TimeOnly" => ((TimeOnly)entry.Value!).ToString("HH:mm:ss", CultureInfo.InvariantCulture),
                null => string.Empty,
                _ => entry.Value?.ToString()
            };
            writer.WriteStartObject();
            writer.WriteString("key", entry.Key);
            writer.WriteString("value", stringVal);
            writer.WriteString("valueType", valueType);
            writer.WriteEndObject();
        }

        writer.WriteEndArray();
    }
}