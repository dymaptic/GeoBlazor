---
layout: default
title: Query
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## Query Class

This class defines parameters for executing queries for features from a layer or layer view. Once a Query object's properties are defined, it can then be passed into an executable function, which will return the features in a FeatureSet.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">ArcGIS JS API</a>

```csharp
public class Query
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Query
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.Query.AggregateIds'></a>

## Query.AggregateIds Property

An array of Object IDs representing aggregate (i.e. cluster) graphics. This property should be used to query features represented by one or more cluster graphics with the given Object IDs.

```csharp
public System.Collections.Generic.IEnumerable<int>? AggregateIds { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.CacheHint'></a>

## Query.CacheHint Property

Indicates if the service should cache the query results. It only applies if the layer's capabilities.query.supportsCacheHint is set to true. Use only for queries that have the same parameters every time the app is used.

```csharp
public System.Nullable<bool> CacheHint { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.DatumTransformation'></a>

## Query.DatumTransformation Property

Datum transformation used for projecting geometries in the query results when outSpatialReference is different than the layer's spatial reference. Requires ArcGIS Server service 10.5 or greater.

```csharp
public System.Nullable<double> DatumTransformation { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.Distance'></a>

## Query.Distance Property

Specifies a search distance from a given geometry in a spatial query. The units property indicates the unit of measurement. In essence, setting this property creates a buffer at the specified size around the input geometry. The query will use that buffer to return features in the layer or layer view that adhere to the indicated spatial relationship.  
If querying a feature service, the supportsQueryWithDistance capability must be true.

```csharp
public System.Nullable<double> Distance { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.GdbVersion'></a>

## Query.GdbVersion Property

Specifies the geodatabase version to display for feature service queries.

```csharp
public string? GdbVersion { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.Geometry'></a>

## Query.Geometry Property

The geometry to apply to the spatial filter.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Geometry? Geometry { get; set; }
```

#### Property Value
[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.GeometryPrecision'></a>

## Query.GeometryPrecision Property

Specifies the number of decimal places for geometries returned by the JSON query operation.

```csharp
public System.Nullable<int> GeometryPrecision { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.GroupByFieldsForStatistics'></a>

## Query.GroupByFieldsForStatistics Property

Used only in statistical queries. When one or more field names are provided in this property, the output statistics will be grouped based on unique values from those fields. This is only valid when outStatistics has been defined.

```csharp
public System.Collections.Generic.IEnumerable<string>? GroupByFieldsForStatistics { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.Having'></a>

## Query.Having Property

A condition used with outStatistics and groupByFieldsForStatistics to limit query results to groups that satisfy the aggregation function(s).  
The following aggregation functions are supported in this clause: MIN | MAX | AVG | SUM | STDDEV | COUNT | VAR  
Aggregation functions used in having must be included in the outStatistics as well. See the snippet below for an example of how this works.  
For service-based layer queries, this parameter applies only if the supportsHavingClause property of the layer is true. This property is supported on all LayerView queries.

```csharp
public string? Having { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.HistoricMoment'></a>

## Query.HistoricMoment Property

The historic moment to query. This parameter applies only if the supportsQueryWithHistoricMoment capability of the service being queried is true. This setting is provided in the layer resource.

```csharp
public System.Nullable<System.DateTime> HistoricMoment { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.MaxAllowableOffset'></a>

## Query.MaxAllowableOffset Property

The maximum distance in units of outSpatialReference used for generalizing geometries returned by the query operation. It limits how far any part of the generalized geometry can be from the original geometry. If outSpatialReference is not defined, the spatialReference of the data is used.

```csharp
public System.Nullable<double> MaxAllowableOffset { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
This property does not apply to LayerView or CSVLayer queries.

<a name='dymaptic.GeoBlazor.Core.Objects.Query.MaxRecordCountFactor'></a>

## Query.MaxRecordCountFactor Property

When set, the maximum number of features returned by the query will equal the maxRecordCount of the service multiplied by this factor. The value of this property may not exceed 5.

```csharp
public System.Nullable<int> MaxRecordCountFactor { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
Only supported with ArcGIS Online hosted services or ArcGIS Enterprise 10.6 services.

<a name='dymaptic.GeoBlazor.Core.Objects.Query.Num'></a>

## Query.Num Property

The number of features to retrieve. This option should be used in conjunction with the start property. Use this to implement paging (i.e. to retrieve "pages" of results when querying).  
If not provided, but an instance of Query has a start property, then the default value of num is 10. If neither num nor start properties are provided, then the default value of num is equal to the maxRecordCount of the service, which can be found at the REST endpoint of the FeatureLayer.

```csharp
public System.Nullable<int> Num { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.ObjectIds'></a>

## Query.ObjectIds Property

An array of ObjectIDs to be used to query for features in a layer.

```csharp
public System.Collections.Generic.IEnumerable<int>? ObjectIds { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.OrderByFields'></a>

## Query.OrderByFields Property

One or more field names used to order the query results. Specify ASC (ascending) or DESC (descending) after the field name to control the order. The default order is ASC.

```csharp
public System.Collections.Generic.IEnumerable<string>? OrderByFields { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

### Remarks
If querying a MapImageLayer, then supportsAdvancedQueries must be true on the service.  
For FeatureLayer, FeatureLayer.capabilities.queryRelated.supportsOrderBy must be true.

<a name='dymaptic.GeoBlazor.Core.Objects.Query.OutFields'></a>

## Query.OutFields Property

Attribute fields to include in the FeatureSet.

```csharp
public System.Collections.Generic.HashSet<string>? OutFields { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.OutSpatialReference'></a>

## Query.OutSpatialReference Property

The spatial reference for the returned geometry. If not specified, the geometry is returned in the spatial reference of the queried layer.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? OutSpatialReference { get; set; }
```

#### Property Value
[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.OutStatistics'></a>

## Query.OutStatistics Property

The definitions for one or more field-based statistics to be calculated. If outStatistics is specified the only other query parameters that should be used are groupByFieldsForStatistics, orderByFields, text, and where.

```csharp
public System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Objects.StatisticDefinition>? OutStatistics { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[StatisticDefinition](dymaptic.GeoBlazor.Core.Objects.StatisticDefinition.html 'dymaptic.GeoBlazor.Core.Objects.StatisticDefinition')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

### Remarks
For service-based queries, outStatistics is only supported on layers where supportsStatistics = true.

<a name='dymaptic.GeoBlazor.Core.Objects.Query.ParameterValues'></a>

## Query.ParameterValues Property

Filters features from the layer based on pre-authored parameterized filters. When value is not specified for any parameter in a request, the default value, that is assigned during authoring time, gets used. Requires an ArcGIS Enterprise service 10.5 or greater. This parameter is only supported with MapImageLayer pointing to a map service.

```csharp
public System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Objects.ParameterValue>? ParameterValues { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ParameterValue](dymaptic.GeoBlazor.Core.Objects.ParameterValue.html 'dymaptic.GeoBlazor.Core.Objects.ParameterValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.QuantizationParameters'></a>

## Query.QuantizationParameters Property

Used to project the geometry onto a virtual grid, likely representing pixels on the screen. Geometry coordinates are converted to integers by building a grid with a resolution matching the quantizationParameters.tolerance. Each coordinate is then snapped to one pixel on the grid.

```csharp
public dymaptic.GeoBlazor.Core.Objects.QuantizationParameters? QuantizationParameters { get; set; }
```

#### Property Value
[QuantizationParameters](dymaptic.GeoBlazor.Core.Objects.QuantizationParameters.html 'dymaptic.GeoBlazor.Core.Objects.QuantizationParameters')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.RangeValues'></a>

## Query.RangeValues Property

Filters features from the layer that are within the specified range values. Requires ArcGIS Enterprise services 10.5 or greater.This parameter is only supported with MapImageLayer pointing to a map service.

```csharp
public System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Objects.RangeValue>? RangeValues { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[RangeValue](dymaptic.GeoBlazor.Core.Objects.RangeValue.html 'dymaptic.GeoBlazor.Core.Objects.RangeValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.RelationParameter'></a>

## Query.RelationParameter Property

The Dimensionally Extended 9 Intersection Model (DE-9IM) matrix relation (encoded as a string) to query the spatial relationship of the input geometry to the layer's features. This string contains the test result of each intersection represented in the DE-9IM matrix. Each result is one character of the string and may be represented as either a number (maximum dimension returned: 0,1,2), a Boolean value (T or F), or a mask character (for ignoring results: '*').  
Set this parameter when the spatialRelationship is relation. The Relational functions for ST_Geometry topic has additional details on how to construct these strings.

```csharp
public string? RelationParameter { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
This property does not apply to layer view or CSVLayer queries.

<a name='dymaptic.GeoBlazor.Core.Objects.Query.ReturnCentroid'></a>

## Query.ReturnCentroid Property

If true, each feature in the returned FeatureSet will be returned with a centroid. This property only applies to queries against polygon FeatureLayers.

```csharp
public System.Nullable<bool> ReturnCentroid { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
Only supported with ArcGIS Online hosted services or ArcGIS Enterprise 10.6.1 services.

<a name='dymaptic.GeoBlazor.Core.Objects.Query.ReturnDistinctValues'></a>

## Query.ReturnDistinctValues Property

If true then the query returns distinct values based on the field(s) specified in outFields.

```csharp
public System.Nullable<bool> ReturnDistinctValues { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
For service-based queries, this parameter applies only if the supportsAdvancedQueries capability of the layer is true.  
Make sure to set returnGeometry to false when returnDistinctValues is true. Otherwise, reliable results will not be returned.

<a name='dymaptic.GeoBlazor.Core.Objects.Query.ReturnExceededLimitFeatures'></a>

## Query.ReturnExceededLimitFeatures Property

If true, then all features are returned for each tile request, even if they exceed the maximum record limit per query indicated on the service by maxRecordCount. If false, the tile request will not return any features if the maxRecordCount limit is exceeded.  
Default Value: true

```csharp
public System.Nullable<bool> ReturnExceededLimitFeatures { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
Only supported with ArcGIS Online hosted services or ArcGIS Enterprise 10.6 services.

<a name='dymaptic.GeoBlazor.Core.Objects.Query.ReturnGeometry'></a>

## Query.ReturnGeometry Property

If true, each feature in the returned FeatureSet includes the geometry.

```csharp
public System.Nullable<bool> ReturnGeometry { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.ReturnM'></a>

## Query.ReturnM Property

If true, and returnGeometry is true, then m-values are included in the geometry.

```csharp
public System.Nullable<bool> ReturnM { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.ReturnQueryGeometry'></a>

## Query.ReturnQueryGeometry Property

If true, the query geometry will be returned with the query results. It is useful for getting the buffer geometry generated when querying features by distance or getting the query geometry projected in the outSpatialReference of the query. The query geometry is returned only for client-side queries and hosted feature services and if the layer's capabilities.query.supportsQueryGeometry is true.

```csharp
public System.Nullable<bool> ReturnQueryGeometry { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.ReturnZ'></a>

## Query.ReturnZ Property

If true, and returnGeometry is true, then z-values are included in the geometry.

```csharp
public System.Nullable<bool> ReturnZ { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
FeatureLayerView.queryFeatures(), GeoJSONLayerView.queryFeatures(), and OGCFeatureLayerView.queryFeatures() results do not include the z-values when called in 2D MapView even if returnZ is set to true.

<a name='dymaptic.GeoBlazor.Core.Objects.Query.SpatialRelationship'></a>

## Query.SpatialRelationship Property

For spatial queries, this parameter defines the spatial relationship to query features in the layer or layer view against the input geometry.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Objects.SpatialRelationship> SpatialRelationship { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[SpatialRelationship](dymaptic.GeoBlazor.Core.Objects.SpatialRelationship.html 'dymaptic.GeoBlazor.Core.Objects.SpatialRelationship')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.SqlFormat'></a>

## Query.SqlFormat Property

This parameter can be either standard SQL92 standard or it can use the native SQL of the underlying datastore native. See the ArcGIS REST API documentation for more information.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Objects.SqlFormat> SqlFormat { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[SqlFormat](dymaptic.GeoBlazor.Core.Objects.SqlFormat.html 'dymaptic.GeoBlazor.Core.Objects.SqlFormat')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
This property does not apply to layer view or CSVLayer queries.

<a name='dymaptic.GeoBlazor.Core.Objects.Query.Start'></a>

## Query.Start Property

The zero-based index indicating where to begin retrieving features. This property should be used in conjunction with num. Use this to implement paging and retrieve "pages" of results when querying. Features are sorted ascending by object ID by default.

```csharp
public System.Nullable<int> Start { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.Text'></a>

## Query.Text Property

Shorthand for a where clause using "like". The field used is the display field defined in the services directory.

```csharp
public string? Text { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.TimeExtent'></a>

## Query.TimeExtent Property

A time extent for a temporal query against time-aware layers. For example, it can be used to discover all crimes that occurred during the night shift from 10 PM to 6 AM on a particular date.

```csharp
public dymaptic.GeoBlazor.Core.Objects.TimeExtent? TimeExtent { get; set; }
```

#### Property Value
[TimeExtent](dymaptic.GeoBlazor.Core.Objects.TimeExtent.html 'dymaptic.GeoBlazor.Core.Objects.TimeExtent')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.Units'></a>

## Query.Units Property

The unit for calculating the buffer distance when distance is specified in spatial queries. If units is not specified, the unit is derived from the geometry spatial reference. If the geometry spatial reference is not specified, the unit is derived from the feature service data spatial reference. For service-based queries, this parameter only applies if the layer's capabilities.query.supportsDistance is true.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> Units { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.UseViewExtent'></a>

## Query.UseViewExtent Property

Determines whether to use the view's extent as the query geometry

```csharp
public System.Nullable<bool> UseViewExtent { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.Where'></a>

## Query.Where Property

A where clause for the query.

```csharp
public string? Where { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
