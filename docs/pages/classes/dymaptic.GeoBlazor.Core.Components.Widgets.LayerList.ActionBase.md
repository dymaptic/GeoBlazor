---
layout: default
title: ActionBase
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets.LayerList](index.html#dymaptic.GeoBlazor.Core.Components.Widgets.LayerList 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList')

## ActionBase Class

Actions are customizable behavior which can be executed in certain widgets such as Popups, a BasemapLayerList, or a LayerList.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html">ArcGIS JS API</a>

```csharp
public abstract class ActionBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ActionBase

Derived  
&#8627; [ActionButton](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionButton.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionButton')  
&#8627; [ActionToggle](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionToggle.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionToggle')

### Remarks
The Action Sections property and corresponding functionality will be fully implemented  
in a future iteration.  Currently, a user can view available layers in the layer list widget  
and toggle the selected layer's visiblity. More capabilities will be available after full  
implementation of ActionSection.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase.Active'></a>

## ActionBase.Active Property

Set this property to true to display a spinner icon. You should do this if the action executes an async operation, such as a query, that requires letting the end user know that a process is ongoing in the background. Set the property back to false to communicate to the user that the process has finished.

```csharp
public System.Nullable<bool> Active { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase.ClassName'></a>

## ActionBase.ClassName Property

This adds a CSS clas to the ActionButton's node.

```csharp
public string? ClassName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase.Disabled'></a>

## ActionBase.Disabled Property

Indicates whether this action is disabled.

```csharp
public System.Nullable<bool> Disabled { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase.Id'></a>

## ActionBase.Id Property

The name of the ID assigned to this action.

```csharp
public string? Id { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase.Title'></a>

## ActionBase.Title Property

The title of the action.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase.Visible'></a>

## ActionBase.Visible Property

Indicates if the action is visible.

```csharp
public System.Nullable<bool> Visible { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
