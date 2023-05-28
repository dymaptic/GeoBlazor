---
layout: default
title: Geometry
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Geometries](index.html#dymaptic.GeoBlazor.Core.Components.Geometries 'dymaptic.GeoBlazor.Core.Components.Geometries')

## Geometry Class

The base class for geometry objects. This class has no constructor. To construct geometries see  
[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point'), [PolyLine](dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.html 'dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine'), or [Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon').  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html">ArcGIS JS API</a>

```csharp
public abstract class Geometry : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; Geometry

Derived  
&#8627; [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')  
&#8627; [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')  
&#8627; [Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon')  
&#8627; [PolyLine](dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.html 'dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.Extent'></a>

## Geometry.Extent Property

The [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html#dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.Extent 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.Extent') of the geometry.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Extent? Extent { get; set; }
```

#### Property Value
[Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.SpatialReference'></a>

## Geometry.SpatialReference Property

The [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html#dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.SpatialReference 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.SpatialReference') of the geometry.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? SpatialReference { get; set; }
```

#### Property Value
[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.Type'></a>

## Geometry.Type Property

The Geometry "type", used internally to render.

```csharp
public virtual string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Geometry.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method. If you see no other way to register a child component, please open an issue on GitHub.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Geometry.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method.
