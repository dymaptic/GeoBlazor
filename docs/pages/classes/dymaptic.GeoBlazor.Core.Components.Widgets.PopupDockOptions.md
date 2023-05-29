---
layout: default
title: PopupDockOptions
parent: Classes
---
---
layout: default
title: PopupDockOptions
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## PopupDockOptions Class

Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.  
When a popup is "dockEnabled" it means the popup no longer points to the selected feature or the location assigned  
to it. Rather it is placed in one of the corners of the view or to the top or bottom of it. This property allows  
the developer to set various options for docking the popup.

```csharp
public class PopupDockOptions : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; PopupDockOptions
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions.PopupDockOptions()'></a>

## PopupDockOptions() Constructor

Parameterless constructor for use as a razor component.

```csharp
public PopupDockOptions();
```

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions.PopupDockOptions(System.Nullable_dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockPosition_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint)'></a>

## PopupDockOptions(Nullable<PopupDockPosition>, Nullable<bool>, BreakPoint) Constructor

Constructor for creating a PopupDockOptions object in code.

```csharp
public PopupDockOptions(System.Nullable<dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockPosition> position=null, System.Nullable<bool> buttonEnabled=null, dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint? breakPoint=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions.PopupDockOptions(System.Nullable_dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockPosition_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint).position'></a>

`position` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[PopupDockPosition](dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockPosition.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockPosition')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The position in the view at which to dock the popup.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions.PopupDockOptions(System.Nullable_dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockPosition_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint).buttonEnabled'></a>

`buttonEnabled` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

If true, displays the dock button. If false, hides the dock button from the popup.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions.PopupDockOptions(System.Nullable_dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockPosition_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint).breakPoint'></a>

`breakPoint` [BreakPoint](dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint.html 'dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint')

Defines the dimensions of the View at which to dock the popup. Set to false to disable docking at a breakpoint.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions.BreakPoint'></a>

## PopupDockOptions.BreakPoint Property

Defines the dimensions of the View at which to dock the popup. Set to false to disable docking at a breakpoint.

```csharp
public dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint? BreakPoint { get; set; }
```

#### Property Value
[BreakPoint](dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint.html 'dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions.ButtonEnabled'></a>

## PopupDockOptions.ButtonEnabled Property

If true, displays the dock button. If false, hides the dock button from the popup.

```csharp
public System.Nullable<bool> ButtonEnabled { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions.Position'></a>

## PopupDockOptions.Position Property

The position in the view at which to dock the popup.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockPosition> Position { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[PopupDockPosition](dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockPosition.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockPosition')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

