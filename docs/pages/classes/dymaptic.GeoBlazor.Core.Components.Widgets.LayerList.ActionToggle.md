---
layout: default
title: ActionToggle
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets.LayerList](index.html#dymaptic.GeoBlazor.Core.Components.Widgets.LayerList 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList')

## ActionToggle Class

A customizable toggle used in the LayerList widget that performs a specific action(s) which can be toggled on/off.

```csharp
public class ActionToggle : dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActionBase](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase') &#129106; ActionToggle
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionToggle.Type'></a>

## ActionToggle.Type Property

Specifies the type of action. Choose between "button" or "toggle".

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionToggle.Value'></a>

## ActionToggle.Value Property

Indicates the value of whether the action is toggled on/off.

```csharp
public System.Nullable<bool> Value { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
