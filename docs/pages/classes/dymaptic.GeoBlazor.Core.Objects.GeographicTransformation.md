---
layout: default
title: GeographicTransformation
parent: Classes
---
---
layout: default
title: GeographicTransformation
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## GeographicTransformation Class

Projecting your data between coordinate systems sometimes requires transforming between geographic coordinate systems. Geographic transformations are used to transform coordinates between spatial references that have different geographic coordinate systems, and thus different datums. Using the most suitable transformation ensures the best possible accuracy when converting geometries from one spatial reference to another.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-GeographicTransformation.html">ArcGIS JS API</a>

```csharp
public class GeographicTransformation
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GeographicTransformation
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.GeographicTransformation.Steps'></a>

## GeographicTransformation.Steps Property

Geographic transformation steps.

```csharp
public dymaptic.GeoBlazor.Core.Objects.GeographicTransformationStep[] Steps { get; set; }
```

#### Property Value
[GeographicTransformationStep](dymaptic.GeoBlazor.Core.Objects.GeographicTransformationStep.html 'dymaptic.GeoBlazor.Core.Objects.GeographicTransformationStep')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')
### Methods

<a name='dymaptic.GeoBlazor.Core.Objects.GeographicTransformation.GetInverse()'></a>

## GeographicTransformation.GetInverse() Method

Returns the inverse of the geographic transformation calling this method or null if the transformation is not invertible.

```csharp
public dymaptic.GeoBlazor.Core.Objects.GeographicTransformation GetInverse();
```

#### Returns
[GeographicTransformation](dymaptic.GeoBlazor.Core.Objects.GeographicTransformation.html 'dymaptic.GeoBlazor.Core.Objects.GeographicTransformation')

#### Exceptions

[System.NotImplementedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotImplementedException 'System.NotImplementedException')

