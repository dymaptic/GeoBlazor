using System.Collections.Specialized;


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
public class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, INotifyCollectionChanged
{
    /// <summary>
    ///    The notify collection changed event handler
    /// </summary>
    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public ObservableDictionary()
    {
    }

    public ObservableDictionary(Dictionary<TKey, TValue> dictionary): base(dictionary)
    {
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
}