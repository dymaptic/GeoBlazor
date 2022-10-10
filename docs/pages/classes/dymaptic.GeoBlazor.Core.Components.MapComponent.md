---
layout: default
title: MapComponent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components](index.html#dymaptic.GeoBlazor.Core.Components 'dymaptic.GeoBlazor.Core.Components')

## MapComponent Class

The abstract base Razor Component class that all GeoBlazor components derive from.

```csharp
public abstract class MapComponent : Microsoft.AspNetCore.Components.ComponentBase,
System.IAsyncDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; MapComponent

Derived  
&#8627; [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')  
&#8627; [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')  
&#8627; [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')  
&#8627; [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView')

Implements [System.IAsyncDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable 'System.IAsyncDisposable')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.ChildContent'></a>

## MapComponent.ChildContent Property

ChildContent defines the ability to add other components within this component in the razor syntax.

```csharp
public Microsoft.AspNetCore.Components.RenderFragment? ChildContent { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.RenderFragment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.RenderFragment 'Microsoft.AspNetCore.Components.RenderFragment')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.Id'></a>

## MapComponent.Id Property

A unique identifier, used to track components across .NET and JavaScript.

```csharp
public System.Guid Id { get; set; }
```

#### Property Value
[System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.JsModule'></a>

## MapComponent.JsModule Property

The reference to arcGisJsInterop.ts from .NET

```csharp
public Microsoft.JSInterop.IJSObjectReference? JsModule { get; set; }
```

#### Property Value
[Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.MapRendered'></a>

## MapComponent.MapRendered Property

A boolean flag that indicates that the current [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') has finished rendering.  
To listen for a map rendering event, use [OnMapRenderedHandler](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.OnMapRenderedHandler 'dymaptic.GeoBlazor.Core.Components.Views.MapView.OnMapRenderedHandler').

```csharp
public bool MapRendered { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.Parent'></a>

## MapComponent.Parent Property

The parent MapComponent of this component.

```csharp
public dymaptic.GeoBlazor.Core.Components.MapComponent? Parent { get; set; }
```

#### Property Value
[MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.View'></a>

## MapComponent.View Property

The parent [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') of the current component.

```csharp
public dymaptic.GeoBlazor.Core.Components.Views.MapView? View { get; set; }
```

#### Property Value
[MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.DisposeAsync()'></a>

## MapComponent.DisposeAsync() Method

Implements the `IAsyncDisposable` pattern.

```csharp
public virtual System.Threading.Tasks.ValueTask DisposeAsync();
```

Implements [DisposeAsync()](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable.DisposeAsync 'System.IAsyncDisposable.DisposeAsync')

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.Refresh()'></a>

## MapComponent.Refresh() Method

Provides a way to externally call `StateHasChanged` on the component.

```csharp
public virtual void Refresh();
```

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## MapComponent.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public virtual System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## MapComponent.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public virtual System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.UpdateComponent()'></a>

## MapComponent.UpdateComponent() Method

Checks if the map is already rendered, and if so, performs forced updates as defined by the component type.

```csharp
public virtual System.Threading.Tasks.Task UpdateComponent();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.ValidateRequiredChildren()'></a>

## MapComponent.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that  
all properties with the [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public virtual void ValidateRequiredChildren();
```

#### Exceptions

[dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components
