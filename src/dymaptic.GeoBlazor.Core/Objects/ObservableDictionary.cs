using System.Collections.Specialized;
using System.Text.Json;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Observable Dictionary
/// </summary>
/// <typeparam name="TKey">
///     Key
/// </typeparam>
/// <typeparam name="TValue">
///     Value
/// </typeparam>
internal class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, INotifyCollectionChanged,
    IEquatable<ObservableDictionary<TKey, TValue>> where TKey : notnull
{
    /// <summary>
    ///    The notify collection changed event handler
    /// </summary>
    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    /// <summary>
    ///    Constructor
    /// </summary>
    public ObservableDictionary()
    {
    }

    /// <summary>
    ///     Constructor from existing dictionary
    /// </summary>
    /// <param name="dictionary">
    ///     The dictionary to use
    /// </param>
    public ObservableDictionary(Dictionary<TKey, TValue> dictionary)
    {
        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        foreach (KeyValuePair<TKey, TValue> kvp in dictionary)
        {
            if (kvp.Value is JsonElement jsonElement)
            {
                object? typedValue = jsonElement.ValueKind switch
                {
                    JsonValueKind.Object => jsonElement.Deserialize(typeof(TValue), options),
                    JsonValueKind.Array => jsonElement.Deserialize(typeof(IEnumerable<object?>), options),
                    JsonValueKind.False => false,
                    JsonValueKind.True => true,
                    JsonValueKind.Number => jsonElement.ToString().Contains('.') 
                        ? Convert.ChangeType(jsonElement.ToString(), TypeCode.Double) 
                        : Convert.ChangeType(jsonElement.ToString(), TypeCode.Int64),
                    JsonValueKind.String => jsonElement.ToString(),
                    _ => jsonElement
                };
                this[kvp.Key] = (TValue)(typedValue ?? default(TValue))!;
            }
            else
            {
                this[kvp.Key] = kvp.Value;
            }
        }
    }
    
    public new TValue this[TKey key]
    {
        get => base[key];
        set
        {
            base[key] = value;
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, key));
        }
    }

    public new void Add(TKey key, TValue value)
    {
        base.Add(key, value);
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value, key));
    }

    public new void Remove(TKey key)
    {
        TValue value = base[key];
        base.Remove(key);
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, value, key));
    }

    public bool Equals(ObservableDictionary<TKey, TValue>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (other.Count != this.Count) return false;

        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            if (!other.TryGetValue(pair.Key, out TValue? value)) return false;

            if (value is null)
            {
                return pair.Value is null;
            }
            if (!value.Equals(pair.Value)) return false;
        }

        return true;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

        return Equals((ObservableDictionary<TKey, TValue>)obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator ==(ObservableDictionary<TKey, TValue>? left, ObservableDictionary<TKey, TValue>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ObservableDictionary<TKey, TValue>? left, ObservableDictionary<TKey, TValue>? right)
    {
        return !Equals(left, right);
    }
}