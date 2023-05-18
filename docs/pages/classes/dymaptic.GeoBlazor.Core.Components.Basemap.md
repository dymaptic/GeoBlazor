---
layout: default
title: Basemap
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components](index.html#dymaptic.GeoBlazor.Core.Components 'dymaptic.GeoBlazor.Core.Components')

## Basemap Class

Creates a new basemap object. Basemaps can be created from a PortalItem, from a well known basemap ID, or can be  
used for creating custom basemaps. These basemaps may be created from tiled services you publish to your own  
server, or from tiled services published by third parties.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html">  
    ArcGIS JS  
    API  
</a>

```csharp
public class Basemap : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; Basemap
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Basemap.Layers'></a>

## Basemap.Layers Property

A collection of tile layers that make of the basemap's features.

```csharp
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.Layers.Layer> Layers { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

<a name='dymaptic.GeoBlazor.Core.Components.Basemap.PortalItem'></a>

## Basemap.PortalItem Property

The [PortalItem](dymaptic.GeoBlazor.Core.Components.Basemap.html#dymaptic.GeoBlazor.Core.Components.Basemap.PortalItem 'dymaptic.GeoBlazor.Core.Components.Basemap.PortalItem')

```csharp
public dymaptic.GeoBlazor.Core.Components.PortalItem? PortalItem { get; set; }
```

#### Property Value
[PortalItem](dymaptic.GeoBlazor.Core.Components.PortalItem.html 'dymaptic.GeoBlazor.Core.Components.PortalItem')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Basemap.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Basemap.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Basemap.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Basemap.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Basemap.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Basemap.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')
