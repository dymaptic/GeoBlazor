---
layout: default
title: Map
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components](index.html#dymaptic.GeoBlazor.Core.Components 'dymaptic.GeoBlazor.Core.Components')

## Map Class

The Map class contains properties and methods for storing, managing, and overlaying layers common to both 2D and 3D viewing. Layers can be added and removed from the map, but are rendered via a MapView (for viewing data in 2D) or a SceneView (for viewing data in 3D). Thus a map instance is a simple container that holds the layers, while the View is the means of displaying and interacting with a map's layers and basemap.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Map.html">ArcGIS JS API</a>

```csharp
public class Map : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; Map
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Map.ArcGISDefaultBasemap'></a>

## Map.ArcGISDefaultBasemap Property

Sets the basemap by way of the arcgis basemap name (e.g., arcgis-topographic).

```csharp
public string? ArcGISDefaultBasemap { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
Either [ArcGISDefaultBasemap](dymaptic.GeoBlazor.Core.Components.Map.html#dymaptic.GeoBlazor.Core.Components.Map.ArcGISDefaultBasemap 'dymaptic.GeoBlazor.Core.Components.Map.ArcGISDefaultBasemap') or [Basemap](dymaptic.GeoBlazor.Core.Components.Map.html#dymaptic.GeoBlazor.Core.Components.Map.Basemap 'dymaptic.GeoBlazor.Core.Components.Map.Basemap') should be set, but not both.

<a name='dymaptic.GeoBlazor.Core.Components.Map.Basemap'></a>

## Map.Basemap Property

The [Basemap](dymaptic.GeoBlazor.Core.Components.Map.html#dymaptic.GeoBlazor.Core.Components.Map.Basemap 'dymaptic.GeoBlazor.Core.Components.Map.Basemap') for this map.

```csharp
public dymaptic.GeoBlazor.Core.Components.Basemap? Basemap { get; set; }
```

#### Property Value
[Basemap](dymaptic.GeoBlazor.Core.Components.Basemap.html 'dymaptic.GeoBlazor.Core.Components.Basemap')

### Remarks
Either [ArcGISDefaultBasemap](dymaptic.GeoBlazor.Core.Components.Map.html#dymaptic.GeoBlazor.Core.Components.Map.ArcGISDefaultBasemap 'dymaptic.GeoBlazor.Core.Components.Map.ArcGISDefaultBasemap') or [Basemap](dymaptic.GeoBlazor.Core.Components.Map.html#dymaptic.GeoBlazor.Core.Components.Map.Basemap 'dymaptic.GeoBlazor.Core.Components.Map.Basemap') should be set, but not both.

<a name='dymaptic.GeoBlazor.Core.Components.Map.Ground'></a>

## Map.Ground Property

Specifies the surface properties for the map.

```csharp
public string? Ground { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Map.Layers'></a>

## Map.Layers Property

A collection of operational [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')s.

```csharp
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.Layers.Layer> Layers { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Map.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Map.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Map.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Map.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Map.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Map.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Map.UpdateComponent()'></a>

## Map.UpdateComponent() Method

Checks if the map is already rendered, and if so, performs forced updates as defined by the component type.

```csharp
public override System.Threading.Tasks.Task UpdateComponent();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Map.ValidateRequiredChildren()'></a>

## Map.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components
