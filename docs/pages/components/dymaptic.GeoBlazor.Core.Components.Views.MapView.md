---
layout: default
parent: Components
title: dymaptic.GeoBlazor.Core.Components.Views.MapView
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Views](index.html#dymaptic.GeoBlazor.Core.Components.Views 'dymaptic.GeoBlazor.Core.Components.Views')

## MapView Class

```csharp
public class MapView : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; MapView
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.DrawRouteAndGetDirections(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,string)'></a>

## MapView.DrawRouteAndGetDirections(Symbol, string) Method

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Objects.Direction[]> DrawRouteAndGetDirections(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol routeSymbol, string routeUrl);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.DrawRouteAndGetDirections(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,string).routeSymbol'></a>

`routeSymbol` [dymaptic.GeoBlazor.Core.Components.Symbols.Symbol](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Symbols.Symbol 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.DrawRouteAndGetDirections(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,string).routeUrl'></a>

`routeUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[dymaptic.GeoBlazor.Core.Objects.Direction](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Objects.Direction 'dymaptic.GeoBlazor.Core.Objects.Direction')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns the directions of the route
