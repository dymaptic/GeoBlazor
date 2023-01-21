---
layout: default
title: FeatureSet
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## FeatureSet Class

A collection of features returned from ArcGIS Server or used as input to methods. Each feature in the FeatureSet may contain geometry, attributes, and symbology. If the FeatureSet does not contain geometry, and only contains attributes, the FeatureSet can be treated as a table where each feature is a row object. Methods that return FeatureSet include query.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html">ArcGIS JS API</a>

```csharp
public class FeatureSet :
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeatureSet

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[FeatureSet](dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.FeatureSet(string,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Layers.Graphic[],dymaptic.GeoBlazor.Core.Components.Layers.Field[],System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference)'></a>

## FeatureSet(string, Nullable<bool>, Graphic[], Field[], Nullable<GeometryType>, Geometry, SpatialReference) Constructor

A collection of features returned from ArcGIS Server or used as input to methods. Each feature in the FeatureSet may contain geometry, attributes, and symbology. If the FeatureSet does not contain geometry, and only contains attributes, the FeatureSet can be treated as a table where each feature is a row object. Methods that return FeatureSet include query.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html">ArcGIS JS API</a>

```csharp
public FeatureSet(string? DisplayFieldName, System.Nullable<bool> ExceededTransferLimit, dymaptic.GeoBlazor.Core.Components.Layers.Graphic[]? Features, dymaptic.GeoBlazor.Core.Components.Layers.Field[]? Fields, System.Nullable<dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType> GeometryType, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry? QueryGeometry, dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? SpatialReference);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.FeatureSet(string,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Layers.Graphic[],dymaptic.GeoBlazor.Core.Components.Layers.Field[],System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).DisplayFieldName'></a>

`DisplayFieldName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the layer's primary display field. The value of this property matches the name of one of the fields of the feature. This is only applicable when the FeatureSet is returned from a task. It is ignored when the FeatureSet is used as input to a geoprocessing task.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.FeatureSet(string,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Layers.Graphic[],dymaptic.GeoBlazor.Core.Components.Layers.Field[],System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).ExceededTransferLimit'></a>

`ExceededTransferLimit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Typically, a layer has a limit on the number of features (i.e., records) returned by the query operation. If maxRecordCount is configured for a layer, exceededTransferLimit will be true if a query matches more than the maxRecordCount features. It will be false otherwise. Supported by ArcGIS Server version 10.1 and later.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.FeatureSet(string,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Layers.Graphic[],dymaptic.GeoBlazor.Core.Components.Layers.Field[],System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).Features'></a>

`Features` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The array of graphics returned from a task.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.FeatureSet(string,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Layers.Graphic[],dymaptic.GeoBlazor.Core.Components.Layers.Field[],System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).Fields'></a>

`Fields` [Field](dymaptic.GeoBlazor.Core.Components.Layers.Field.html 'dymaptic.GeoBlazor.Core.Components.Layers.Field')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Information about each field.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.FeatureSet(string,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Layers.Graphic[],dymaptic.GeoBlazor.Core.Components.Layers.Field[],System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).GeometryType'></a>

`GeometryType` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[GeometryType](dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType.html 'dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The geometry type of features in the FeatureSet. All features's geometry must be of the same type.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.FeatureSet(string,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Layers.Graphic[],dymaptic.GeoBlazor.Core.Components.Layers.Field[],System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).QueryGeometry'></a>

`QueryGeometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry used to query the features. It is useful for getting the buffer geometry generated when querying features by distance or getting the query geometry projected in the outSpatialReference of the query. The query geometry is returned only for client-side queries and hosted feature services. The query's returnQueryGeometry must be set to true and the layer's capabilities.query.supportsQueryGeometry has to be true for the query to return query geometry.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.FeatureSet(string,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Layers.Graphic[],dymaptic.GeoBlazor.Core.Components.Layers.Field[],System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).SpatialReference'></a>

`SpatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

When a FeatureSet is used as input to Geoprocessor, the spatial reference is set to the map's spatial reference by default. This value can be changed. When a FeatureSet is returned from a task, the value is the result as returned from the server.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.DisplayFieldName'></a>

## FeatureSet.DisplayFieldName Property

The name of the layer's primary display field. The value of this property matches the name of one of the fields of the feature. This is only applicable when the FeatureSet is returned from a task. It is ignored when the FeatureSet is used as input to a geoprocessing task.

```csharp
public string? DisplayFieldName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.ExceededTransferLimit'></a>

## FeatureSet.ExceededTransferLimit Property

Typically, a layer has a limit on the number of features (i.e., records) returned by the query operation. If maxRecordCount is configured for a layer, exceededTransferLimit will be true if a query matches more than the maxRecordCount features. It will be false otherwise. Supported by ArcGIS Server version 10.1 and later.

```csharp
public System.Nullable<bool> ExceededTransferLimit { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.Features'></a>

## FeatureSet.Features Property

The array of graphics returned from a task.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Graphic[]? Features { get; set; }
```

#### Property Value
[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.Fields'></a>

## FeatureSet.Fields Property

Information about each field.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Field[]? Fields { get; set; }
```

#### Property Value
[Field](dymaptic.GeoBlazor.Core.Components.Layers.Field.html 'dymaptic.GeoBlazor.Core.Components.Layers.Field')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.GeometryType'></a>

## FeatureSet.GeometryType Property

The geometry type of features in the FeatureSet. All features's geometry must be of the same type.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType> GeometryType { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[GeometryType](dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType.html 'dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.QueryGeometry'></a>

## FeatureSet.QueryGeometry Property

The geometry used to query the features. It is useful for getting the buffer geometry generated when querying features by distance or getting the query geometry projected in the outSpatialReference of the query. The query geometry is returned only for client-side queries and hosted feature services. The query's returnQueryGeometry must be set to true and the layer's capabilities.query.supportsQueryGeometry has to be true for the query to return query geometry.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Geometry? QueryGeometry { get; set; }
```

#### Property Value
[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.SpatialReference'></a>

## FeatureSet.SpatialReference Property

When a FeatureSet is used as input to Geoprocessor, the spatial reference is set to the map's spatial reference by default. This value can be changed. When a FeatureSet is returned from a task, the value is the result as returned from the server.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? SpatialReference { get; set; }
```

#### Property Value
[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')
