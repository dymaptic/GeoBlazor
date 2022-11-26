---
layout: default
title: BaseListItem
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets.LayerList](index.html#dymaptic.GeoBlazor.Core.Components.Widgets.LayerList 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList')

## BaseListItem Class

The ListItem class represents one of the operationalItems in the LayerListViewModel. In the LayerList widget UI, the list item represents a layer displayed in the view. It provides access to the associated layer's properties, allows the developer to configure actions related to the layer, and allows the developer to add content to the item related to the layer.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html">ArcGIS JS API</a>

```csharp
public class BaseListItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BaseListItem
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.BaseListItem.ActionSections'></a>

## BaseListItem.ActionSections Property

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

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.BaseListItem.BaseItems'></a>

## BaseListItem.BaseItems Property

The children base items in a layer.

```csharp
public System.Collections.Generic.List<dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem>? BaseItems { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.BaseListItem.BasemapItems'></a>

## BaseListItem.BasemapItems Property

The children basemap items in a layer.

```csharp
public System.Collections.Generic.List<dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem>? BasemapItems { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.BaseListItem.Id'></a>

## BaseListItem.Id Property

The displayed id of the basemap layer in the basemap LayerList Widget.

```csharp
public string? Id { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.BaseListItem.ReferenceItems'></a>

## BaseListItem.ReferenceItems Property

The children reference items in a layer.

```csharp
public System.Collections.Generic.List<dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem>? ReferenceItems { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.BaseListItem.Title'></a>

## BaseListItem.Title Property

The displayed title of the basemap layer in the Basemap LayerList Widget.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.BaseListItem.Visible'></a>

## BaseListItem.Visible Property

Determines whether the basemap layer is visible on load.

```csharp
public System.Nullable<bool> Visible { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
