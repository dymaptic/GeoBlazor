---
layout: default
title: TopFilter
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## TopFilter Class

This class defines the top filter parameters for executing top features queries for features from a FeatureLayer. This parameter must be set on the TopFeaturesQuery object when calling any of top query methods on a FeatureLayer. It is used to set the groupByFields, orderByFields, and count criteria used the top features query. For example, you can use FeatureLayer's queryTopFeatures() method to query the most populous three counties in each state of the United States.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-TopFilter.html">ArcGIS JS API</a>

```csharp
public class TopFilter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TopFilter
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.TopFilter.GroupByFields'></a>

## TopFilter.GroupByFields Property

When one or more field names are provided in this property, the output result will be grouped based on unique values from those fields.

```csharp
public System.Collections.Generic.IEnumerable<string>? GroupByFields { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFilter.OrderByFields'></a>

## TopFilter.OrderByFields Property

One or more field names used to order the query results. Specify ASC (ascending) or DESC (descending) after the field name to control the order. The default order is ASC.

```csharp
public System.Collections.Generic.IEnumerable<string>? OrderByFields { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFilter.TopCount'></a>

## TopFilter.TopCount Property

Defines the number of features to be returned from the top features query.

```csharp
public System.Nullable<int> TopCount { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
