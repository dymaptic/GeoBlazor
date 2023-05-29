---
layout: default
title: ActionToggle
parent: Classes
---
---
layout: default
title: ActionToggle
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components](index.html#dymaptic.GeoBlazor.Core.Components 'dymaptic.GeoBlazor.Core.Components')

## ActionToggle Class

A customizable toggle used in the LayerList widget that performs a specific action(s) which can be toggled on/off.

```csharp
public class ActionToggle : dymaptic.GeoBlazor.Core.Components.ActionBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [ActionBase](dymaptic.GeoBlazor.Core.Components.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.ActionBase') &#129106; ActionToggle
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.ActionToggle.Type'></a>

## ActionToggle.Type Property

Specifies the type of action. Choose between "button" or "toggle".

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.ActionToggle.Value'></a>

## ActionToggle.Value Property

Indicates the value of whether the action is toggled on/off.

```csharp
public System.Nullable<bool> Value { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

