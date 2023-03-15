---
layout: default
title: RangeValue
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## RangeValue Class

Filters features from the layer that are within the specified range values. Requires ArcGIS Enterprise services  
10.5 or greater.This parameter is only supported with MapImageLayer pointing to a map service.

```csharp
public class RangeValue :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.RangeValue>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RangeValue

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[RangeValue](dymaptic.GeoBlazor.Core.Objects.RangeValue.html 'dymaptic.GeoBlazor.Core.Objects.RangeValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.RangeValue.RangeValue(string,object)'></a>

## RangeValue(string, object) Constructor

Filters features from the layer that are within the specified range values. Requires ArcGIS Enterprise services  
10.5 or greater.This parameter is only supported with MapImageLayer pointing to a map service.

```csharp
public RangeValue(string Name, object Value);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.RangeValue.RangeValue(string,object).Name'></a>

`Name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The range id.

<a name='dymaptic.GeoBlazor.Core.Objects.RangeValue.RangeValue(string,object).Value'></a>

`Value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Single value or value range.
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.RangeValue.Name'></a>

## RangeValue.Name Property

The range id.

```csharp
public string Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.RangeValue.Value'></a>

## RangeValue.Value Property

Single value or value range.

```csharp
public object Value { get; set; }
```

#### Property Value
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')
