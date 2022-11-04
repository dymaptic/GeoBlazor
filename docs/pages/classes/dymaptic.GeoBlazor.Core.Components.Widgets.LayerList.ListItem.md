---
layout: default
title: ListItem
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets.LayerList](index.html#dymaptic.GeoBlazor.Core.Components.Widgets.LayerList 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList')

## ListItem Class

The ListItem class represents one of the operationalItems in the LayerListViewModel. In the LayerList widget UI, the list item represents a layer displayed in the view. It provides access to the associated layer's properties, allows the developer to configure actions related to the layer, and allows the developer to add content to the item related to the layer.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html#actionsSections">ArcGIS JS API</a>

```csharp
public class ListItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ListItem
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.ActionSections'></a>

## ListItem.ActionSections Property

Sets the actions on click for the list item.

```csharp
public dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase[][]? ActionSections { get; set; }
```

#### Property Value
[ActionBase](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

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
