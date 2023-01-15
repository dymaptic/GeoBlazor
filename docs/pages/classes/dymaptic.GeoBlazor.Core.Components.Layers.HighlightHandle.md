---
layout: default
title: HighlightHandle
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## HighlightHandle Class

A handle to a [Highlight(int)](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html#dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Highlight(int) 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Highlight(int)') call result. The handle can be used to remove the installed highlight.

```csharp
public class HighlightHandle :
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HighlightHandle

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[HighlightHandle](dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle.html 'dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle.HighlightHandle(Microsoft.JSInterop.IJSObjectReference)'></a>

## HighlightHandle(IJSObjectReference) Constructor

A handle to a [Highlight(int)](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html#dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Highlight(int) 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Highlight(int)') call result. The handle can be used to remove the installed highlight.

```csharp
public HighlightHandle(Microsoft.JSInterop.IJSObjectReference JsObjectReference);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle.HighlightHandle(Microsoft.JSInterop.IJSObjectReference).JsObjectReference'></a>

`JsObjectReference` [Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

The JavaScript object reference used by the handle.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle.JsObjectReference'></a>

## HighlightHandle.JsObjectReference Property

The JavaScript object reference used by the handle.

```csharp
public Microsoft.JSInterop.IJSObjectReference JsObjectReference { get; set; }
```

#### Property Value
[Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle.Remove()'></a>

## HighlightHandle.Remove() Method

Removes the highlight.

```csharp
public System.Threading.Tasks.Task Remove();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')
