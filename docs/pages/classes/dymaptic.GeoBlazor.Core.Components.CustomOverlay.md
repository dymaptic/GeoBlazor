---
layout: default
title: CustomOverlay
parent: Classes
---
---
layout: default
title: CustomOverlay
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components](index.html#dymaptic.GeoBlazor.Core.Components 'dymaptic.GeoBlazor.Core.Components')

## CustomOverlay Class

A container for placing custom html or Razor Components on top of the Map View.

```csharp
public class CustomOverlay : Microsoft.AspNetCore.Components.ComponentBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; CustomOverlay
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.CustomOverlay.ChildContent'></a>

## CustomOverlay.ChildContent Property

The child content to place over the map.

```csharp
public Microsoft.AspNetCore.Components.RenderFragment? ChildContent { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.RenderFragment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.RenderFragment 'Microsoft.AspNetCore.Components.RenderFragment')

<a name='dymaptic.GeoBlazor.Core.Components.CustomOverlay.Position'></a>

## CustomOverlay.Position Property

The position to place the child content over the map.

```csharp
public dymaptic.GeoBlazor.Core.Components.OverlayPosition Position { get; set; }
```

#### Property Value
[OverlayPosition](dymaptic.GeoBlazor.Core.Components.OverlayPosition.html 'dymaptic.GeoBlazor.Core.Components.OverlayPosition')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.CustomOverlay.Refresh()'></a>

## CustomOverlay.Refresh() Method

A convenience method to force the child content to call StateHasChanged

```csharp
public void Refresh();
```

