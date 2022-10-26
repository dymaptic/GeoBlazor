---
layout: default
title: BasemapGalleryWidget
parent: Classes
---
---
layout: default
title: BasemapGalleryWidget
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## BasemapGalleryWidget Class

The BasemapGallery widget displays a collection images representing basemaps from ArcGIS.com or a user-defined set of map or image services. When a new basemap is selected from the BasemapGallery, the map's basemap layers are removed and replaced with the basemap layers of the associated basemap selected in the gallery.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapGallery.html">ArcGIS JS API</a>

```csharp
public class BasemapGalleryWidget : dymaptic.GeoBlazor.Core.Components.Widgets.Widget
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget') &#129106; BasemapGalleryWidget
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.PortalBasemapsSource'></a>

## BasemapGalleryWidget.PortalBasemapsSource Property

The source for basemaps that the widget will display.

```csharp
public dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource? PortalBasemapsSource { get; set; }
```

#### Property Value
[PortalBasemapsSource](dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.html 'dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource')

### Remarks
Use either [Title](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.html#dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.Title 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.Title') or [PortalBasemapsSource](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.html#dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.PortalBasemapsSource 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.PortalBasemapsSource') to define the query.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.Title'></a>

## BasemapGalleryWidget.Title Property

The title to query against the source.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
Use either [Title](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.html#dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.Title 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.Title') or [PortalBasemapsSource](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.html#dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.PortalBasemapsSource 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.PortalBasemapsSource') to define the query.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.WidgetType'></a>

## BasemapGalleryWidget.WidgetType Property

The type of widget

```csharp
public override string WidgetType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## BasemapGalleryWidget.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## BasemapGalleryWidget.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.ValidateRequiredChildren()'></a>

## BasemapGalleryWidget.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components

