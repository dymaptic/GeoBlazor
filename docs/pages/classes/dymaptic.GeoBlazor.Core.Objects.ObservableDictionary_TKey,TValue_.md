---
layout: default
title: ObservableDictionary_TKey,TValue_
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## ObservableDictionary<TKey,TValue> Class

Observable Dictionary

```csharp
public class ObservableDictionary<TKey,TValue> : System.Collections.Generic.Dictionary<TKey, TValue>,
System.Collections.Specialized.INotifyCollectionChanged
```
#### Type parameters

<a name='dymaptic.GeoBlazor.Core.Objects.ObservableDictionary_TKey,TValue_.TKey'></a>

`TKey`

Key

<a name='dymaptic.GeoBlazor.Core.Objects.ObservableDictionary_TKey,TValue_.TValue'></a>

`TValue`

Value

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[TKey](dymaptic.GeoBlazor.Core.Objects.ObservableDictionary_TKey,TValue_.html#dymaptic.GeoBlazor.Core.Objects.ObservableDictionary_TKey,TValue_.TKey 'dymaptic.GeoBlazor.Core.Objects.ObservableDictionary<TKey,TValue>.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[TValue](dymaptic.GeoBlazor.Core.Objects.ObservableDictionary_TKey,TValue_.html#dymaptic.GeoBlazor.Core.Objects.ObservableDictionary_TKey,TValue_.TValue 'dymaptic.GeoBlazor.Core.Objects.ObservableDictionary<TKey,TValue>.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2') &#129106; ObservableDictionary<TKey,TValue>

Implements [System.Collections.Specialized.INotifyCollectionChanged](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Specialized.INotifyCollectionChanged 'System.Collections.Specialized.INotifyCollectionChanged')
### Events

<a name='dymaptic.GeoBlazor.Core.Objects.ObservableDictionary_TKey,TValue_.CollectionChanged'></a>

## ObservableDictionary<TKey,TValue>.CollectionChanged Event

The notify collection changed event handler

```csharp
public event NotifyCollectionChangedEventHandler? CollectionChanged;
```

Implements [CollectionChanged](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Specialized.INotifyCollectionChanged.CollectionChanged 'System.Collections.Specialized.INotifyCollectionChanged.CollectionChanged')

#### Event Type
[System.Collections.Specialized.NotifyCollectionChangedEventHandler](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Specialized.NotifyCollectionChangedEventHandler 'System.Collections.Specialized.NotifyCollectionChangedEventHandler')
