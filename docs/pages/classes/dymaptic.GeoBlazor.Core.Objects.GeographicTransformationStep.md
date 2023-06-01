---
layout: default
title: GeographicTransformationStep
parent: Classes
---
---
layout: default
title: GeographicTransformationStep
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## GeographicTransformationStep Class

Represents a step in the process of transforming coordinates from one geographic coordinate system to another. A  
geographic transformation step can be constructed from a well-known ID (wkid) or a well known text (wkt) that  
represents a geographic datum transformation.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-GeographicTransformationStep.html">ArcGIS JS API</a>

```csharp
public class GeographicTransformationStep
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GeographicTransformationStep
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.GeographicTransformationStep.IsInverse'></a>

## GeographicTransformationStep.IsInverse Property

Indicates if the geographic transformation is inverted.

```csharp
public System.Nullable<bool> IsInverse { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.GeographicTransformationStep.Wkid'></a>

## GeographicTransformationStep.Wkid Property

The well-known id (wkid) that represents a known geographic transformation.

```csharp
public System.Nullable<double> Wkid { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.GeographicTransformationStep.Wkt'></a>

## GeographicTransformationStep.Wkt Property

The well-known text (wkt) that represents a known geographic transformation.

```csharp
public string? Wkt { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

