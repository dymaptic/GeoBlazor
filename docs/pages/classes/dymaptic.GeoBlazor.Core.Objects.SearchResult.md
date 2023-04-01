---
layout: default
title: SearchResult
parent: Classes
---
---
layout: default
title: SearchResult
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## SearchResult Class

The result object returned from a search.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#SearchResult">  
    ArcGIS  
    JS API  
</a>

```csharp
public class SearchResult
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SearchResult
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.SearchResult.Extent'></a>

## SearchResult.Extent Property

The extent, or bounding box, of the returned feature. The value depends on the data source, with higher quality  
data sources returning extents closer to the feature obtained from the search.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Extent? Extent { get; set; }
```

#### Property Value
[Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

<a name='dymaptic.GeoBlazor.Core.Objects.SearchResult.Feature'></a>

## SearchResult.Feature Property

The resulting feature or location obtained from the search.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Graphic? Feature { get; set; }
```

#### Property Value
[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

<a name='dymaptic.GeoBlazor.Core.Objects.SearchResult.Name'></a>

## SearchResult.Name Property

The name of the result.

```csharp
public string? Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

