---
layout: default
title: PopupTemplate
parent: Classes
---
---
layout: default
title: PopupTemplate
parent: Classes
---
---
layout: default
title: PopupTemplate
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## PopupTemplate Class

A PopupTemplate formats and defines the content of a Popup for a specific Layer or Graphic. The user can also use the PopupTemplate to access values from feature attributes and values returned from Arcade expressions when a feature in the view is selected.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-PopupTemplate.html">ArcGIS JS API</a>

```csharp
public class PopupTemplate : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; PopupTemplate
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.Content'></a>

## PopupTemplate.Content Property

The template for defining and formatting a popup's content, provided as a collection of [PopupContent](dymaptic.GeoBlazor.Core.Components.Popups.PopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupContent')s.

```csharp
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.Popups.PopupContent> Content { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[PopupContent](dymaptic.GeoBlazor.Core.Components.Popups.PopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupContent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

### Remarks
Either [Content](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html#dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.Content 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.Content') or [StringContent](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html#dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.StringContent 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.StringContent') should be defined, but not both.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.StringContent'></a>

## PopupTemplate.StringContent Property

The template for defining and formatting a popup's content, provided as a simple string.

```csharp
public string? StringContent { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
Either [Content](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html#dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.Content 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.Content') or [StringContent](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html#dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.StringContent 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.StringContent') should be defined, but not both.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.Title'></a>

## PopupTemplate.Title Property

The template for defining how to format the title used in a popup.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## PopupTemplate.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## PopupTemplate.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.ValidateRequiredChildren()'></a>

## PopupTemplate.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components


