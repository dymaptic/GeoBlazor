---
layout: default
title: StatisticParameters
parent: Classes
---
---
layout: default
title: StatisticParameters
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## StatisticParameters Class

The parameters for percentile statistics. This property must be set when the statisticType is set to either  
percentile-continuous or percentile-discrete.

```csharp
public class StatisticParameters :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.StatisticParameters>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; StatisticParameters

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[StatisticParameters](dymaptic.GeoBlazor.Core.Objects.StatisticParameters.html 'dymaptic.GeoBlazor.Core.Objects.StatisticParameters')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.StatisticParameters.StatisticParameters(double)'></a>

## StatisticParameters(double) Constructor

The parameters for percentile statistics. This property must be set when the statisticType is set to either  
percentile-continuous or percentile-discrete.

```csharp
public StatisticParameters(double Value);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.StatisticParameters.StatisticParameters(double).Value'></a>

`Value` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Percentile value. This should be a decimal value between 0 and 1.
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.StatisticParameters.OrderBy'></a>

## StatisticParameters.OrderBy Property

Specify ASC (ascending) or DESC (descending) to control the order of the data. For example, in a data set of 10  
values from 1 to 10, the percentile value for 0.9 with orderBy set to ascending (ASC) is 9, but when orderBy is set  
to descending (DESC) the result is 2. The default is ASC.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Objects.OrderBy> OrderBy { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[OrderBy](dymaptic.GeoBlazor.Core.Objects.OrderBy.html 'dymaptic.GeoBlazor.Core.Objects.OrderBy')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.StatisticParameters.Value'></a>

## StatisticParameters.Value Property

Percentile value. This should be a decimal value between 0 and 1.

```csharp
public double Value { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

