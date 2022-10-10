---
layout: default
title: ListItem
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets.LayerList](index.html#dymaptic.GeoBlazor.Core.Components.Widgets.LayerList 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList')

## ListItem Class

The description of a layer for display in a [LayerListWidget](dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget').

```csharp
public class ListItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ListItem
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.ActionSections'></a>

## ListItem.ActionSections Property

Sets the actions on click for the list item.

```csharp
public dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionSection[][]? ActionSections { get; set; }
```

#### Property Value
[ActionSection](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionSection.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionSection')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

### Remarks
The Action Sections property and corresponding functionality will be fully implemented  
in a future iteration.  Currently, a user can view available layers in the layer list widget  
and toggle the selected layer's visibility. More capabilities will be available after full  
implementation of ActionSection.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.Children'></a>

## ListItem.Children Property

The children items in a layer.

```csharp
public System.Collections.Generic.List<dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem>? Children { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

### Remarks
Editing not currently supported.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.Layer'></a>

## ListItem.Layer Property

Sets the layer values for this item.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Layer? Layer { get; set; }
```

#### Property Value
[Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

### Remarks
Editing not currently supported.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.Title'></a>

## ListItem.Title Property

The displayed title of the layer in the LayerList Widget.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.Visible'></a>

## ListItem.Visible Property

Determines whether the layer is visible on load.

```csharp
public System.Nullable<bool> Visible { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
