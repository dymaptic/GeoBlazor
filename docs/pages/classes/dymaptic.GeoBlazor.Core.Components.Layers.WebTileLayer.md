---
layout: default
title: WebTileLayer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## WebTileLayer Class

WebTileLayer provides a simple way to add non-ArcGIS Server map tiles as a layer to a map. The constructor takes a  
URL template that usually follows a pattern of http://some.domain.com/{level}/{col}/{row}/ where level corresponds  
to a zoom level, and column and row represent tile column and row, respectively. This pattern is not required, but  
is the most common one currently on the web.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WebTileLayer.html#urlTemplate">  
    ArcGIS  
    JS API  
</a>

```csharp
public class WebTileLayer : dymaptic.GeoBlazor.Core.Components.Layers.Layer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') &#129106; WebTileLayer

Derived  
&#8627; [OpenStreetMapLayer](dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.BlendMode'></a>

## WebTileLayer.BlendMode Property

Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what  
seems like a new layer.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Layers.BlendMode> BlendMode { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[BlendMode](dymaptic.GeoBlazor.Core.Components.Layers.BlendMode.html 'dymaptic.GeoBlazor.Core.Components.Layers.BlendMode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.Copyright'></a>

## WebTileLayer.Copyright Property

The attribution information for the layer.

```csharp
public string? Copyright { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.LayerType'></a>

## WebTileLayer.LayerType Property

Used internally to identify the sub type of Layer

```csharp
public override string LayerType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.MaxScale'></a>

## WebTileLayer.MaxScale Property

The maximum scale (most zoomed in) at which the layer is visible in the view.

```csharp
public System.Nullable<double> MaxScale { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.MinScale'></a>

## WebTileLayer.MinScale Property

The minimum scale (most zoomed out) at which the layer is visible in the view.

```csharp
public System.Nullable<double> MinScale { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.PortalItem'></a>

## WebTileLayer.PortalItem Property

The portal item from which the layer is loaded.

```csharp
public dymaptic.GeoBlazor.Core.Components.PortalItem? PortalItem { get; set; }
```

#### Property Value
[PortalItem](dymaptic.GeoBlazor.Core.Components.PortalItem.html 'dymaptic.GeoBlazor.Core.Components.PortalItem')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.RefreshInterval'></a>

## WebTileLayer.RefreshInterval Property

Refresh interval of the layer in minutes.

```csharp
public System.Nullable<double> RefreshInterval { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.SubDomains'></a>

## WebTileLayer.SubDomains Property

A string of subDomain names where tiles are served to speed up tile retrieval. If subDomains are specified, the  
[UrlTemplate](dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.UrlTemplate 'dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.UrlTemplate') should include a {subDomain} place holder.

```csharp
public System.Collections.Generic.IList<string>? SubDomains { get; set; }
```

#### Property Value
[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.TileInfo'></a>

## WebTileLayer.TileInfo Property

The tiling scheme information for the layer.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.TileInfo? TileInfo { get; set; }
```

#### Property Value
[TileInfo](dymaptic.GeoBlazor.Core.Components.Layers.TileInfo.html 'dymaptic.GeoBlazor.Core.Components.Layers.TileInfo')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.UrlTemplate'></a>

## WebTileLayer.UrlTemplate Property

The url template is a string that specifies the URL of the hosted tile images to load. The url template resembles  
an absolute URL but with a number of placeholder strings that the source evaluates to decide which tiles to load.

```csharp
public string? UrlTemplate { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
The url template can follow a pattern of https://some.domain.com/{level}/{col}/{row}/ where level corresponds to a  
zoom level, and column and row represent a tile column and row, respectively. It can also follow a pattern of  
https://some.domain.com/{z}/{x}/{y}/ where z corresponds to a zoom level, and x and y represent a tile location  
along x and y axis. The urlTemplate should contain a {subDomain} place holder if subDomains are specified.
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## WebTileLayer.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## WebTileLayer.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.ValidateRequiredChildren()'></a>

## WebTileLayer.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the  
[RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components
