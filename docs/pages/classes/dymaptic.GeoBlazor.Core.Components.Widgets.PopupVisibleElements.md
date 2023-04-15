---
layout: default
title: PopupVisibleElements
parent: Classes
---
---
layout: default
title: PopupVisibleElements
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## PopupVisibleElements Class

The visible elements that are displayed within the widget. This provides the ability to turn individual elements of  
the widget's display on/off.

```csharp
public class PopupVisibleElements : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; PopupVisibleElements
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements.PopupVisibleElements()'></a>

## PopupVisibleElements() Constructor

Parameterless constructor for use as a razor component.

```csharp
public PopupVisibleElements();
```

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements.PopupVisibleElements(System.Nullable_bool_,System.Nullable_bool_)'></a>

## PopupVisibleElements(Nullable<bool>, Nullable<bool>) Constructor

Constructor for creating a PopupVisibleElements object in code.

```csharp
public PopupVisibleElements(System.Nullable<bool> closeButton=null, System.Nullable<bool> featureNavigation=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements.PopupVisibleElements(System.Nullable_bool_,System.Nullable_bool_).closeButton'></a>

`closeButton` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements.PopupVisibleElements(System.Nullable_bool_,System.Nullable_bool_).featureNavigation'></a>

`featureNavigation` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements.CloseButton'></a>

## PopupVisibleElements.CloseButton Property

Indicates whether to display a close button on the popup dialog. Default value is true.

```csharp
public System.Nullable<bool> CloseButton { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements.FeatureNavigation'></a>

## PopupVisibleElements.FeatureNavigation Property

Indicates whether pagination for feature navigation will be displayed. Default value is true. This allows the user  
to scroll through various selected features using pagination arrows.

```csharp
public System.Nullable<bool> FeatureNavigation { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

