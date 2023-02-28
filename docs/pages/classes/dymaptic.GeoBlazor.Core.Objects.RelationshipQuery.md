---
layout: default
title: RelationshipQuery
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## RelationshipQuery Class

This class defines parameters for executing queries for related records from a layer. Once a RelationshipQuery  
object's properties are defined, it can then be passed into the query.executeRelationshipQuery() and  
FeatureLayer.queryRelatedFeatures() methods, which will return FeatureSets grouped by source layer/table objectIds.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-RelationshipQuery.html#maxAllowableOffset">  
    ArcGIS  
    JS API  
</a>

```csharp
public class RelationshipQuery
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RelationshipQuery
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.CacheHint'></a>

## RelationshipQuery.CacheHint Property

Indicates if the service should cache the relationship query results. It only applies if the layer's  
capabilities.queryRelated.supportsCacheHint is set to true. Use only for queries that have the same parameters  
every time the app is used.

```csharp
public System.Nullable<bool> CacheHint { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.GdbVersion'></a>

## RelationshipQuery.GdbVersion Property

Specify the geodatabase version to query.

```csharp
public string? GdbVersion { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.GeometryPrecision'></a>

## RelationshipQuery.GeometryPrecision Property

Specify the number of decimal places for the geometries returned by the query operation.

```csharp
public System.Nullable<double> GeometryPrecision { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.HistoricMoment'></a>

## RelationshipQuery.HistoricMoment Property

The historic moment to query. This parameter applies only if the supportsHistoricMoment on FeatureLayer property of  
the layer is set to true.

```csharp
public System.Nullable<System.DateTime> HistoricMoment { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.MaxAllowableOffset'></a>

## RelationshipQuery.MaxAllowableOffset Property

The maximum allowable offset used for generalizing geometries returned by the query operation. The offset is in the  
units of outSpatialReference. If outSpatialReference is not defined, the spatialReference of the view is used.

```csharp
public System.Nullable<double> MaxAllowableOffset { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.Num'></a>

## RelationshipQuery.Num Property

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

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.ObjectIds'></a>

## RelationshipQuery.ObjectIds Property

An array of objectIds for the features in the layer/table being queried.

```csharp
public System.Collections.Generic.IEnumerable<int>? ObjectIds { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.OrderByFields'></a>

## RelationshipQuery.OrderByFields Property

One or more field names used to order the query results. Specify ASC (ascending) or DESC (descending) after the  
field name to control the order. The default order is ASC.

```csharp
public System.Collections.Generic.IEnumerable<string>? OrderByFields { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

### Remarks
Known Limitations  
- If querying a MapImageLayer, then supportsAdvancedQueries must be true on the service.  
- For FeatureLayer, FeatureLayer.capabilities.queryRelated.supportsOrderBy must be true.

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.OutFields'></a>

## RelationshipQuery.OutFields Property

Attribute fields to include in the FeatureSet. Fields must exist in the map layer. You must list actual field names  
rather than the alias names. You are, however, able to use the alias names when you display the results.  
When specifying the output fields, you should limit the fields to only those you expect to use in the query or the  
results. The fewer fields you include, the faster the response will be.  
Each query must have access to the Shape and ObjectId fields for a layer. However, your list of fields does not  
need to include these two fields.

```csharp
public System.Collections.Generic.IEnumerable<string>? OutFields { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.OutSpatialReference'></a>

## RelationshipQuery.OutSpatialReference Property

The spatial reference for the returned geometry. If outSpatialReference is not defined, the spatialReference of the  
view is used.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? OutSpatialReference { get; set; }
```

#### Property Value
[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.RelationshipId'></a>

## RelationshipQuery.RelationshipId Property

The ID of the relationship to be queried. The ids for the relationships the table or layer participates in are  
listed in the ArcGIS Services directory. The ID of the relationship to be queried. The relationships that this  
layer/table participates in are included in the Feature Service Layer resource response. Records in tables/layers  
corresponding to the related table/layer of the relationship are queried.

```csharp
public System.Nullable<int> RelationshipId { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.ReturnGeometry'></a>

## RelationshipQuery.ReturnGeometry Property

If true, each feature in the FeatureSet includes the geometry. Set to false (default) if you do not plan to include  
highlighted features on a map since the geometry makes up a significant portion of the response.

```csharp
public System.Nullable<bool> ReturnGeometry { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.ReturnM'></a>

## RelationshipQuery.ReturnM Property

If true, and returnGeometry is true, then m-values are included in the geometry.

```csharp
public System.Nullable<bool> ReturnM { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.ReturnZ'></a>

## RelationshipQuery.ReturnZ Property

If true, and returnGeometry is true, then z-values are included in the geometry.

```csharp
public System.Nullable<bool> ReturnZ { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.Start'></a>

## RelationshipQuery.Start Property

The zero-based index indicating where to begin retrieving features. This property should be used in conjunction  
with num. Use this to implement paging and retrieve "pages" of results when querying. Features are sorted ascending  
by object ID by default.

```csharp
public System.Nullable<int> Start { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.Where'></a>

## RelationshipQuery.Where Property

The definition expression to be applied to the related table or layer. Only records in the list of objectIds that  
satisfy the definition expression are queried for related records.

```csharp
public string? Where { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
