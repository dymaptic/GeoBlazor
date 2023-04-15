---
layout: default
title: TopFeaturesQuery
parent: Classes
---
---
layout: default
title: TopFeaturesQuery
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## TopFeaturesQuery Class

This class defines parameters for executing top features queries from a FeatureLayer. Once a TopFeaturesQuery  
object's properties are defined, it can then be passed into executable functions on a server-side FeatureLayer,  
which can return a FeatureSet containing features within a group. For example, you can use FeatureLayer's  
queryTopFeatures() method to query the most populous three counties in each state of the United States.  
This class has many of the same properties as Query class. However, unlike the Query class, this class does not  
support properties such as outStatistics and its related parameters or returnDistinctValues.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-TopFeaturesQuery.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class TopFeaturesQuery
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TopFeaturesQuery
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.CacheHint'></a>

## TopFeaturesQuery.CacheHint Property

Indicates if the service should cache the query results. It only applies if the layer's  
capabilities.queryTopFeatures.supportsCacheHint is set to true. Use only for queries that have the same parameters  
every time the app is used.

```csharp
public System.Nullable<bool> CacheHint { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.Distance'></a>

## TopFeaturesQuery.Distance Property

Specifies a search distance from a given geometry in a spatial query. The units property indicates the unit of  
measurement. In essence, setting this property creates a buffer at the specified size around the input geometry.  
The query will use that buffer to return features in the layer or layer view that adhere to the to the indicated  
spatial relationship.  
If querying a feature service, the supportsQueryWithDistance capability must be true.

```csharp
public System.Nullable<double> Distance { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.Geometry'></a>

## TopFeaturesQuery.Geometry Property

The geometry to apply to the spatial filter. The spatial relationship as specified by spatialRelationship will  
indicate how the geometry should be used to query features.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Geometry? Geometry { get; set; }
```

#### Property Value
[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

### Remarks
Known Limitations: Mesh geometry types are currently not supported.

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.GeometryPrecision'></a>

## TopFeaturesQuery.GeometryPrecision Property

Specify the number of decimal places for the geometries returned by the query operation.

```csharp
public System.Nullable<double> GeometryPrecision { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.MaxAllowableOffset'></a>

## TopFeaturesQuery.MaxAllowableOffset Property

The maximum allowable offset used for generalizing geometries returned by the query operation. The offset is in the  
units of outSpatialReference. If outSpatialReference is not defined, the spatialReference of the view is used.

```csharp
public System.Nullable<double> MaxAllowableOffset { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.Num'></a>

## TopFeaturesQuery.Num Property

The number of features to retrieve. This option should be used in conjunction with the start property. Use this to  
implement paging (i.e. to retrieve "pages" of results when querying).  
If not provided, but an instance of Query has a start property, then the default value of num is 10. If neither num  
nor start properties are provided, then the default value of num is equal to the maxRecordCount of the service,  
which can be found at the REST endpoint of the FeatureLayer.

```csharp
public System.Nullable<int> Num { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.ObjectIds'></a>

## TopFeaturesQuery.ObjectIds Property

An array of objectIds for the features in the layer/table being queried.

```csharp
public System.Collections.Generic.IEnumerable<int>? ObjectIds { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.OrderByFields'></a>

## TopFeaturesQuery.OrderByFields Property

One or more field names used to order the query results. Specify ASC (ascending) or DESC (descending) after the  
field name to control the order. The default order is ASC.

```csharp
public System.Collections.Generic.IEnumerable<string>? OrderByFields { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.OutFields'></a>

## TopFeaturesQuery.OutFields Property

Attribute fields to include in the FeatureSet. Fields must exist in the service layer. You must list actual field  
names rather than field aliases. You may, however, use field aliases when you display the results of the query.  
When specifying the output fields, you should limit the fields to only those you expect to use in the query or the  
results. The fewer fields you include, the smaller the payload size, and therefore the faster the response of the  
query.  
You can also specify SQL expressions as outFields to calculate new values server side for the query results. See  
the example snippets below for an example of this.  
Each query must have access to the Shape and ObjectId fields for a layer. However, the list of outFields does not  
need to include these two fields.

```csharp
public System.Collections.Generic.IEnumerable<string>? OutFields { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

### Remarks
Known Limitations: If specifying outFields as expressions on a feature service-based FeatureLayer, the service  
capabilities advancedQueryCapabilities.supportsOutFieldSQLExpression and useStandardizedQueries must both be true.

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.OutSpatialReference'></a>

## TopFeaturesQuery.OutSpatialReference Property

The spatial reference for the returned geometry. If not specified, the geometry is returned in the spatial  
reference of the queried layer.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? OutSpatialReference { get; set; }
```

#### Property Value
[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.ReturnGeometry'></a>

## TopFeaturesQuery.ReturnGeometry Property

If true, each feature in the returned FeatureSet includes the geometry.

```csharp
public System.Nullable<bool> ReturnGeometry { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.ReturnM'></a>

## TopFeaturesQuery.ReturnM Property

If true, and returnGeometry is true, then m-values are included in the geometry.

```csharp
public System.Nullable<bool> ReturnM { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.ReturnZ'></a>

## TopFeaturesQuery.ReturnZ Property

If true, and returnGeometry is true, then z-values are included in the geometry.

```csharp
public System.Nullable<bool> ReturnZ { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.SpatialRelationship'></a>

## TopFeaturesQuery.SpatialRelationship Property

For spatial queries, this parameter defines the spatial relationship to query features in the layer or layer view  
against the input geometry. The spatial relationships discover how features are spatially related to each other.  
For example, you may want to know if a polygon representing a county completely contains points representing  
settlements.  
The spatial relationship is determined by whether the boundaries or interiors of a geometry intersect.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Objects.SpatialRelationship> SpatialRelationship { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[SpatialRelationship](dymaptic.GeoBlazor.Core.Objects.SpatialRelationship.html 'dymaptic.GeoBlazor.Core.Objects.SpatialRelationship')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.Start'></a>

## TopFeaturesQuery.Start Property

The zero-based index indicating where to begin retrieving features. This property should be used in conjunction  
with num. Use this to implement paging and retrieve "pages" of results when querying. Features are sorted ascending  
by object ID by default.

```csharp
public System.Nullable<int> Start { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.TimeExtent'></a>

## TopFeaturesQuery.TimeExtent Property

A time extent for a temporal query against time-aware layers. For example, it can be used to discover all crimes  
that occurred during the night shift from 10 PM to 6 AM on a particular date.

```csharp
public dymaptic.GeoBlazor.Core.Objects.TimeExtent? TimeExtent { get; set; }
```

#### Property Value
[TimeExtent](dymaptic.GeoBlazor.Core.Objects.TimeExtent.html 'dymaptic.GeoBlazor.Core.Objects.TimeExtent')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.TopFilter'></a>

## TopFeaturesQuery.TopFilter Property

A time extent for a temporal query against time-aware layers. For example, it can be used to discover all crimes  
that occurred during the night shift from 10 PM to 6 AM on a particular date.

```csharp
public dymaptic.GeoBlazor.Core.Objects.TopFilter? TopFilter { get; set; }
```

#### Property Value
[TopFilter](dymaptic.GeoBlazor.Core.Objects.TopFilter.html 'dymaptic.GeoBlazor.Core.Objects.TopFilter')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.Units'></a>

## TopFeaturesQuery.Units Property

The unit for calculating the buffer distance when distance is specified in spatial queries. If units is not  
specified, the unit is derived from the geometry spatial reference. If the geometry spatial reference is not  
specified, the unit is derived from the feature service data spatial reference. For service-based queries, this  
parameter only applies if the layer's capabilities.query.supportsDistance is true.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> Units { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.Where'></a>

## TopFeaturesQuery.Where Property

A where clause for the query. Any legal SQL where clause operating on the fields in the layer is allowed. Be sure  
to have the correct sequence of single and double quotes when writing the where clause in JavaScript.

```csharp
public string? Where { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

