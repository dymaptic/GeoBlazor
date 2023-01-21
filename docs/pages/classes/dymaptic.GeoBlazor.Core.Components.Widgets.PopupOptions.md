---
layout: default
title: PopupOptions
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## PopupOptions Class

A collection of options to define when creating a Popup.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html">ArcGIS JS API</a>

```csharp
public class PopupOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PopupOptions
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOptions.PopupOptions(dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions,dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements)'></a>

## PopupOptions(PopupDockOptions, PopupVisibleElements) Constructor

Creates a new PopupOptions

```csharp
public PopupOptions(dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions? dockOptions=null, dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements? visibleElements=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOptions.PopupOptions(dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions,dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements).dockOptions'></a>

`dockOptions` [PopupDockOptions](dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions')

Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOptions.PopupOptions(dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions,dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements).visibleElements'></a>

`visibleElements` [PopupVisibleElements](dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements')

The visible elements that are displayed within the widget.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOptions.DockOptions'></a>

## PopupOptions.DockOptions Property

Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.

```csharp
public dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions DockOptions { get; set; }
```

#### Property Value
[PopupDockOptions](dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOptions.VisibleElements'></a>

## PopupOptions.VisibleElements Property

The visible elements that are displayed within the widget.

```csharp
public dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements VisibleElements { get; set; }
```

#### Property Value
[PopupVisibleElements](dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements')
