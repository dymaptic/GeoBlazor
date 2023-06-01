---
layout: default
title: StatisticDefinition
parent: Classes
---
---
layout: default
title: StatisticDefinition
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## StatisticDefinition Class

This class defines the parameters for querying a layer or layer view for statistics.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-StatisticDefinition.html">ArcGIS JS API</a>

```csharp
public class StatisticDefinition :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.StatisticDefinition>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; StatisticDefinition

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[StatisticDefinition](dymaptic.GeoBlazor.Core.Objects.StatisticDefinition.html 'dymaptic.GeoBlazor.Core.Objects.StatisticDefinition')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.StatisticDefinition.StatisticDefinition(string,string,dymaptic.GeoBlazor.Core.Objects.StatisticType,dymaptic.GeoBlazor.Core.Objects.StatisticParameters)'></a>

## StatisticDefinition(string, string, StatisticType, StatisticParameters) Constructor

This class defines the parameters for querying a layer or layer view for statistics.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-StatisticDefinition.html">ArcGIS JS API</a>

```csharp
public StatisticDefinition(string OnStatisticField, string OutStatisticFieldName, dymaptic.GeoBlazor.Core.Objects.StatisticType StatisticType, dymaptic.GeoBlazor.Core.Objects.StatisticParameters StatisticParameters);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.StatisticDefinition.StatisticDefinition(string,string,dymaptic.GeoBlazor.Core.Objects.StatisticType,dymaptic.GeoBlazor.Core.Objects.StatisticParameters).OnStatisticField'></a>

`OnStatisticField` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Defines the field for which statistics will be calculated. This can be service field names or SQL expressions. See  
the snippets below for examples.

<a name='dymaptic.GeoBlazor.Core.Objects.StatisticDefinition.StatisticDefinition(string,string,dymaptic.GeoBlazor.Core.Objects.StatisticType,dymaptic.GeoBlazor.Core.Objects.StatisticParameters).OutStatisticFieldName'></a>

`OutStatisticFieldName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Specifies the output field name for the requested statistic. Output field names can only contain alpha-numeric  
characters and an underscore. If no output field name is specified, the server assigns a field name to the returned  
statistic field.

<a name='dymaptic.GeoBlazor.Core.Objects.StatisticDefinition.StatisticDefinition(string,string,dymaptic.GeoBlazor.Core.Objects.StatisticType,dymaptic.GeoBlazor.Core.Objects.StatisticParameters).StatisticType'></a>

`StatisticType` [StatisticType](dymaptic.GeoBlazor.Core.Objects.StatisticType.html 'dymaptic.GeoBlazor.Core.Objects.StatisticType')

Defines the type of statistic.

<a name='dymaptic.GeoBlazor.Core.Objects.StatisticDefinition.StatisticDefinition(string,string,dymaptic.GeoBlazor.Core.Objects.StatisticType,dymaptic.GeoBlazor.Core.Objects.StatisticParameters).StatisticParameters'></a>

`StatisticParameters` [StatisticParameters](dymaptic.GeoBlazor.Core.Objects.StatisticParameters.html 'dymaptic.GeoBlazor.Core.Objects.StatisticParameters')

The parameters for percentile statistics. This property must be set when the statisticType is set to either  
percentile-continuous or percentile-discrete.
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.StatisticDefinition.OnStatisticField'></a>

## StatisticDefinition.OnStatisticField Property

Defines the field for which statistics will be calculated. This can be service field names or SQL expressions. See  
the snippets below for examples.

```csharp
public string OnStatisticField { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.StatisticDefinition.OutStatisticFieldName'></a>

## StatisticDefinition.OutStatisticFieldName Property

Specifies the output field name for the requested statistic. Output field names can only contain alpha-numeric  
characters and an underscore. If no output field name is specified, the server assigns a field name to the returned  
statistic field.

```csharp
public string OutStatisticFieldName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.StatisticDefinition.StatisticParameters'></a>

## StatisticDefinition.StatisticParameters Property

The parameters for percentile statistics. This property must be set when the statisticType is set to either  
percentile-continuous or percentile-discrete.

```csharp
public dymaptic.GeoBlazor.Core.Objects.StatisticParameters StatisticParameters { get; set; }
```

#### Property Value
[StatisticParameters](dymaptic.GeoBlazor.Core.Objects.StatisticParameters.html 'dymaptic.GeoBlazor.Core.Objects.StatisticParameters')

<a name='dymaptic.GeoBlazor.Core.Objects.StatisticDefinition.StatisticType'></a>

## StatisticDefinition.StatisticType Property

Defines the type of statistic.

```csharp
public dymaptic.GeoBlazor.Core.Objects.StatisticType StatisticType { get; set; }
```

#### Property Value
[StatisticType](dymaptic.GeoBlazor.Core.Objects.StatisticType.html 'dymaptic.GeoBlazor.Core.Objects.StatisticType')

