---
layout: default
title: FeatureFilter
parent: Classes
---
---
layout: default
title: FeatureFilter
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## FeatureFilter Class

<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html">  
                    ArcGIS  
                    JS API  
                </a>

```csharp
public class FeatureFilter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeatureFilter
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter.Distance'></a>

## FeatureFilter.Distance Property

Specifies a search distance from a given geometry in a spatial filter. The units property indicates the unit of  
measurement. In essence, setting this property creates a buffer at the specified size around the input geometry.  
The filter will use that buffer to display features in the layer or layer view that adhere to the to the indicated  
spatial relationship.

```csharp
public System.Nullable<double> Distance { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter.Geometry'></a>

## FeatureFilter.Geometry Property

The geometry to apply to the spatial filter. The spatial relationship as specified by spatialRelationship will  
indicate how the geometry should be used to filter features.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Geometry? Geometry { get; set; }
```

#### Property Value
[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

### Remarks
Known Limitations: Mesh geometry types are currently not supported.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter.ObjectIds'></a>

## FeatureFilter.ObjectIds Property

An array of objectIds of the features to be filtered.

```csharp
public System.Collections.Generic.IEnumerable<int>? ObjectIds { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter.SpatialRelationship'></a>

## FeatureFilter.SpatialRelationship Property

For spatial filters, this parameter defines the spatial relationship to filter features in the layer view against  
the filter geometry. The spatial relationships discover how features are spatially related to each other. For  
example, you may want to know if a polygon representing a county completely contains points representing  
settlements.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Objects.SpatialRelationship> SpatialRelationship { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[SpatialRelationship](dymaptic.GeoBlazor.Core.Objects.SpatialRelationship.html 'dymaptic.GeoBlazor.Core.Objects.SpatialRelationship')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter.TimeExtent'></a>

## FeatureFilter.TimeExtent Property

A range of time with start and end date. Only the features that fall within this time extent will be displayed. The  
Date field to be used for timeExtent should be added to outFields list when the layer is initialized. This ensures  
the best user experience when switching or updating fields for time filters.

```csharp
public dymaptic.GeoBlazor.Core.Objects.TimeExtent? TimeExtent { get; set; }
```

#### Property Value
[TimeExtent](dymaptic.GeoBlazor.Core.Objects.TimeExtent.html 'dymaptic.GeoBlazor.Core.Objects.TimeExtent')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter.Units'></a>

## FeatureFilter.Units Property

The unit for calculating the buffer distance when distance is specified in a spatial filter. If units is not  
specified, the unit is derived from the filter geometry's spatial reference.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> Units { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter.Where'></a>

## FeatureFilter.Where Property

A where clause for the feature filter. Any legal SQL92 where clause operating on the fields in the layer is  
allowed. Be sure to have the correct sequence of single and double quotes when writing the where clause in  
JavaScript.  
For apps where users can interactively change fields used for attribute filter, we suggest you include all possible  
fields in the outFields of the layer. This ensures the best user experience when switching or updating fields for  
attribute filters.

```csharp
public string? Where { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

