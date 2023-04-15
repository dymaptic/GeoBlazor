---
layout: default
title: BasemapToggleWidget
parent: Classes
---
---
layout: default
title: BasemapToggleWidget
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## BasemapToggleWidget Class

The BasemapToggle provides a widget which allows an end-user to switch between two basemaps. The toggled basemap is  
set inside the view's map object.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapToggle.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class BasemapToggleWidget : dymaptic.GeoBlazor.Core.Components.Widgets.Widget
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget') &#129106; BasemapToggleWidget
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.NextBasemap'></a>

## BasemapToggleWidget.NextBasemap Property

The next [Basemap](dymaptic.GeoBlazor.Core.Components.Basemap.html 'dymaptic.GeoBlazor.Core.Components.Basemap') for toggling.

```csharp
public dymaptic.GeoBlazor.Core.Components.Basemap? NextBasemap { get; set; }
```

#### Property Value
[Basemap](dymaptic.GeoBlazor.Core.Components.Basemap.html 'dymaptic.GeoBlazor.Core.Components.Basemap')

### Remarks
Set either [NextBasemapName](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.html#dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.NextBasemapName 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.NextBasemapName') or [NextBasemap](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.html#dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.NextBasemap 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.NextBasemap')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.NextBasemapName'></a>

## BasemapToggleWidget.NextBasemapName Property

The name of the next basemap for toggling.

```csharp
public string? NextBasemapName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
Set either [NextBasemapName](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.html#dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.NextBasemapName 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.NextBasemapName') or [NextBasemap](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.html#dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.NextBasemap 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.NextBasemap')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.WidgetType'></a>

## BasemapToggleWidget.WidgetType Property

The type of widget

```csharp
public override string WidgetType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## BasemapToggleWidget.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## BasemapToggleWidget.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.ValidateRequiredChildren()'></a>

## BasemapToggleWidget.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the  
[RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components

