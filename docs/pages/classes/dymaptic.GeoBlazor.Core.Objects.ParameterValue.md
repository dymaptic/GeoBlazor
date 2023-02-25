---
layout: default
title: ParameterValue
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## ParameterValue Class

Filters features from the layer based on pre-authored parameterized filters. When value is not specified for any  
parameter in a request, the default value, that is assigned during authoring time, gets used. Requires an ArcGIS  
Enterprise service 10.5 or greater. This parameter is only supported with MapImageLayer pointing to a map service.

```csharp
public class ParameterValue :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.ParameterValue>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ParameterValue

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ParameterValue](dymaptic.GeoBlazor.Core.Objects.ParameterValue.html 'dymaptic.GeoBlazor.Core.Objects.ParameterValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.ParameterValue.ParameterValue(string,object)'></a>

## ParameterValue(string, object) Constructor

Filters features from the layer based on pre-authored parameterized filters. When value is not specified for any  
parameter in a request, the default value, that is assigned during authoring time, gets used. Requires an ArcGIS  
Enterprise service 10.5 or greater. This parameter is only supported with MapImageLayer pointing to a map service.

```csharp
public ParameterValue(string Name, object Value);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.ParameterValue.ParameterValue(string,object).Name'></a>

`Name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The parameter name.

<a name='dymaptic.GeoBlazor.Core.Objects.ParameterValue.ParameterValue(string,object).Value'></a>

`Value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Single value or array of values.
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.ParameterValue.Name'></a>

## ParameterValue.Name Property

The parameter name.

```csharp
public string Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.ParameterValue.Value'></a>

## ParameterValue.Value Property

Single value or array of values.

```csharp
public object Value { get; set; }
```

#### Property Value
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')
