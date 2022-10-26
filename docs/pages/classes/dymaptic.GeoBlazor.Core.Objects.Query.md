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

<a name='dymaptic.GeoBlazor.Core.Objects.Query.Geometry'></a>

## Query.Geometry Property

The geometry to apply to the spatial filter.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Geometry? Geometry { get; set; }
```

#### Property Value
[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.OutFields'></a>

## Query.OutFields Property

Attribute fields to include in the FeatureSet.

```csharp
public System.Collections.Generic.HashSet<string> OutFields { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.ReturnGeometry'></a>

## Query.ReturnGeometry Property

If true, each feature in the returned FeatureSet includes the geometry.

```csharp
public bool ReturnGeometry { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.SpatialRelationship'></a>

## Query.SpatialRelationship Property

For spatial queries, this parameter defines the spatial relationship to query features in the layer or layer view against the input geometry.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Objects.SpatialRelationship> SpatialRelationship { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[SpatialRelationship](dymaptic.GeoBlazor.Core.Objects.SpatialRelationship.html 'dymaptic.GeoBlazor.Core.Objects.SpatialRelationship')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.UseViewExtent'></a>

## Query.UseViewExtent Property

Determines whether to use the view's extent as the query geometry

```csharp
public bool UseViewExtent { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Objects.Query.Where'></a>

## Query.Where Property

A where clause for the query.

```csharp
public string? Where { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
