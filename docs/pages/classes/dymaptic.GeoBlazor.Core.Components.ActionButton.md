---
layout: default
title: ActionButton
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components](index.html#dymaptic.GeoBlazor.Core.Components 'dymaptic.GeoBlazor.Core.Components')

## ActionButton Class

A customizable button that performs a specific action(s) used in widgets such as the Popup, LayerList, and  
BasemapLayerList.

```csharp
public class ActionButton : dymaptic.GeoBlazor.Core.Components.ActionBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [ActionBase](dymaptic.GeoBlazor.Core.Components.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.ActionBase') &#129106; ActionButton
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.ActionButton.ClassName'></a>

## ActionButton.ClassName Property

This adds a CSS class to the ActionButton's node.

```csharp
public string? ClassName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.ActionButton.Image'></a>

## ActionButton.Image Property

The URL to an image that will be used to represent the action. This property will be used as a background image for  
the node. It may be used in conjunction with the className property or by itself. If neither image nor className  
are specified, a default icon will display

```csharp
public string? Image { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.ActionButton.Type'></a>

## ActionButton.Type Property

Specifies the type of action. Choose between "button" or "toggle".

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
