---
layout: default
title: PortalBasemapsSource
parent: Classes
---
---
layout: default
title: PortalBasemapsSource
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components](index.html#dymaptic.GeoBlazor.Core.Components 'dymaptic.GeoBlazor.Core.Components')

## PortalBasemapsSource Class

The PortalBasemapsSource class is a Portal-driven Basemap source in the BasemapGalleryViewModel or BasemapGallery  
widget.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapGallery-support-PortalBasemapsSource.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class PortalBasemapsSource : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; PortalBasemapsSource
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.Portal'></a>

## PortalBasemapsSource.Portal Property

The Portal from which to fetch basemaps.

```csharp
public dymaptic.GeoBlazor.Core.Components.Portal? Portal { get; set; }
```

#### Property Value
[Portal](dymaptic.GeoBlazor.Core.Components.Portal.html 'dymaptic.GeoBlazor.Core.Components.Portal')

<a name='dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.QueryParams'></a>

## PortalBasemapsSource.QueryParams Property

An object with key-value pairs used to create a custom basemap gallery group query.

```csharp
public System.Collections.Generic.Dictionary<string,string>? QueryParams { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

### Remarks
User either [QueryString](dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.html#dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.QueryString 'dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.QueryString') or [QueryParams](dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.html#dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.QueryParams 'dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.QueryParams')

<a name='dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.QueryString'></a>

## PortalBasemapsSource.QueryString Property

An query string used to create a custom basemap gallery group query.

```csharp
public string? QueryString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
User either [QueryString](dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.html#dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.QueryString 'dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.QueryString') or [QueryParams](dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.html#dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.QueryParams 'dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.QueryParams')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## PortalBasemapsSource.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## PortalBasemapsSource.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.ValidateRequiredChildren()'></a>

## PortalBasemapsSource.ValidateRequiredChildren() Method

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

