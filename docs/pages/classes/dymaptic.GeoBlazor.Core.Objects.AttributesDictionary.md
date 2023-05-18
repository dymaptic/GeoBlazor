---
layout: default
title: AttributesDictionary
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## AttributesDictionary Class

Dictionary of Graphic Attributes that can be asynchronously updated

```csharp
public class AttributesDictionary :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.AttributesDictionary>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AttributesDictionary

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[AttributesDictionary](dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.html 'dymaptic.GeoBlazor.Core.Objects.AttributesDictionary')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.AttributesDictionary()'></a>

## AttributesDictionary() Constructor

Constructor

```csharp
public AttributesDictionary();
```

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.AttributesDictionary(System.Collections.Generic.Dictionary_string,object_)'></a>

## AttributesDictionary(Dictionary<string,object>) Constructor

Constructor from existing dictionary

```csharp
public AttributesDictionary(System.Collections.Generic.Dictionary<string,object> dictionary);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.AttributesDictionary(System.Collections.Generic.Dictionary_string,object_).dictionary'></a>

`dictionary` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

The dictionary to use
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.Count'></a>

## AttributesDictionary.Count Property

The number of attribute entries in the dictionary

```csharp
public int Count { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.Keys'></a>

## AttributesDictionary.Keys Property

Returns all the keys in the dictionary

```csharp
public System.Collections.Generic.Dictionary<string,object>.KeyCollection Keys { get; }
```

#### Property Value
[System.Collections.Generic.Dictionary.KeyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2.KeyCollection 'System.Collections.Generic.Dictionary`2.KeyCollection')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2.KeyCollection 'System.Collections.Generic.Dictionary`2.KeyCollection')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2.KeyCollection 'System.Collections.Generic.Dictionary`2.KeyCollection')

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.OnChange'></a>

## AttributesDictionary.OnChange Property

Event that is fired when an attribute is added, updated or removed

```csharp
public Microsoft.AspNetCore.Components.EventCallback OnChange { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback 'Microsoft.AspNetCore.Components.EventCallback')

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.this[string]'></a>

## AttributesDictionary.this[string] Property

Gets or the value associated with the specified key.

```csharp
public object this[string key] { get; }
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.this[string].key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key to get the value for

#### Property Value
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.Values'></a>

## AttributesDictionary.Values Property

Returns all the values in the dictionary

```csharp
public System.Collections.Generic.Dictionary<string,object>.ValueCollection Values { get; }
```

#### Property Value
[System.Collections.Generic.Dictionary.ValueCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2.ValueCollection 'System.Collections.Generic.Dictionary`2.ValueCollection')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2.ValueCollection 'System.Collections.Generic.Dictionary`2.ValueCollection')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2.ValueCollection 'System.Collections.Generic.Dictionary`2.ValueCollection')
### Methods

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.AddOrUpdate(string,object)'></a>

## AttributesDictionary.AddOrUpdate(string, object) Method

Adds or updates the value associated with the specified key.

```csharp
public System.Threading.Tasks.Task AddOrUpdate(string key, object value);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.AddOrUpdate(string,object).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key to add or update

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.AddOrUpdate(string,object).value'></a>

`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The value to add or update

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.Clear()'></a>

## AttributesDictionary.Clear() Method

Removes all keys and values from the dictionary.

```csharp
public System.Threading.Tasks.Task Clear();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.ContainsKey(string)'></a>

## AttributesDictionary.ContainsKey(string) Method

Determines whether the dictionary contains the specified key.

```csharp
public bool ContainsKey(string key);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.ContainsKey(string).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key to locate in the dictionary

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the key was found, false otherwise.

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.ContainsValue(object)'></a>

## AttributesDictionary.ContainsValue(object) Method

Determines whether the dictionary contains the specified value.

```csharp
public bool ContainsValue(object value);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.ContainsValue(object).value'></a>

`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The value to locate in the dictionary

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the value was found, false otherwise.

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.Equals(object)'></a>

## AttributesDictionary.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.Equals(System.Collections.Generic.Dictionary_string,object_)'></a>

## AttributesDictionary.Equals(Dictionary<string,object>) Method

Determines whether the dictionary contains the same keys and values as the specified dictionary.

```csharp
public bool Equals(System.Collections.Generic.Dictionary<string,object> otherDictionary);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.Equals(System.Collections.Generic.Dictionary_string,object_).otherDictionary'></a>

`otherDictionary` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.GetHashCode()'></a>

## AttributesDictionary.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.Remove(string)'></a>

## AttributesDictionary.Remove(string) Method

Removes the value associated with the specified key.

```csharp
public System.Threading.Tasks.Task Remove(string key);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.Remove(string).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key to remove

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.TryGetValue(string,object)'></a>

## AttributesDictionary.TryGetValue(string, object) Method

Attempts to get the value associated with the specified key from the dictionary.

```csharp
public bool TryGetValue(string key, out object? value);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.TryGetValue(string,object).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key to search for

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.TryGetValue(string,object).value'></a>

`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Out parameter for the found value, if any. If not found, returns the default value for the type.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the key was found, false otherwise.
### Operators

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.op_Equality(dymaptic.GeoBlazor.Core.Objects.AttributesDictionary,dymaptic.GeoBlazor.Core.Objects.AttributesDictionary)'></a>

## AttributesDictionary.operator ==(AttributesDictionary, AttributesDictionary) Operator

Equality operator

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Objects.AttributesDictionary left, dymaptic.GeoBlazor.Core.Objects.AttributesDictionary right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.op_Equality(dymaptic.GeoBlazor.Core.Objects.AttributesDictionary,dymaptic.GeoBlazor.Core.Objects.AttributesDictionary).left'></a>

`left` [AttributesDictionary](dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.html 'dymaptic.GeoBlazor.Core.Objects.AttributesDictionary')

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.op_Equality(dymaptic.GeoBlazor.Core.Objects.AttributesDictionary,dymaptic.GeoBlazor.Core.Objects.AttributesDictionary).right'></a>

`right` [AttributesDictionary](dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.html 'dymaptic.GeoBlazor.Core.Objects.AttributesDictionary')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.op_ExplicitSystem.Collections.Generic.Dictionary_string,object_(dymaptic.GeoBlazor.Core.Objects.AttributesDictionary)'></a>

## AttributesDictionary.explicit operator Dictionary<string,object>(AttributesDictionary) Operator

Implicit conversion from AttributesDictionary to [System.Collections.Generic.Dictionary&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2').

```csharp
public static System.Collections.Generic.Dictionary<string,object> explicit operator Dictionary<string,object>(dymaptic.GeoBlazor.Core.Objects.AttributesDictionary attributesDictionary);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.op_ExplicitSystem.Collections.Generic.Dictionary_string,object_(dymaptic.GeoBlazor.Core.Objects.AttributesDictionary).attributesDictionary'></a>

`attributesDictionary` [AttributesDictionary](dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.html 'dymaptic.GeoBlazor.Core.Objects.AttributesDictionary')

#### Returns
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.op_Implicitdymaptic.GeoBlazor.Core.Objects.AttributesDictionary(System.Collections.Generic.Dictionary_string,object_)'></a>

## AttributesDictionary.implicit operator AttributesDictionary(Dictionary<string,object>) Operator

Implicit conversion from [System.Collections.Generic.Dictionary&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2') to AttributesDictionary.  
This is only provided for backwards compatibility and may be removed in a future release.

```csharp
public static dymaptic.GeoBlazor.Core.Objects.AttributesDictionary implicit operator AttributesDictionary(System.Collections.Generic.Dictionary<string,object> dictionary);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.op_Implicitdymaptic.GeoBlazor.Core.Objects.AttributesDictionary(System.Collections.Generic.Dictionary_string,object_).dictionary'></a>

`dictionary` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

#### Returns
[AttributesDictionary](dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.html 'dymaptic.GeoBlazor.Core.Objects.AttributesDictionary')

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.op_Inequality(dymaptic.GeoBlazor.Core.Objects.AttributesDictionary,dymaptic.GeoBlazor.Core.Objects.AttributesDictionary)'></a>

## AttributesDictionary.operator !=(AttributesDictionary, AttributesDictionary) Operator

Inequality operator

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Objects.AttributesDictionary? left, dymaptic.GeoBlazor.Core.Objects.AttributesDictionary? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.op_Inequality(dymaptic.GeoBlazor.Core.Objects.AttributesDictionary,dymaptic.GeoBlazor.Core.Objects.AttributesDictionary).left'></a>

`left` [AttributesDictionary](dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.html 'dymaptic.GeoBlazor.Core.Objects.AttributesDictionary')

<a name='dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.op_Inequality(dymaptic.GeoBlazor.Core.Objects.AttributesDictionary,dymaptic.GeoBlazor.Core.Objects.AttributesDictionary).right'></a>

`right` [AttributesDictionary](dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.html 'dymaptic.GeoBlazor.Core.Objects.AttributesDictionary')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
