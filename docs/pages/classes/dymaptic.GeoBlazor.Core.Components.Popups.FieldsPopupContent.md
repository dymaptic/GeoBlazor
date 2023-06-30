---
layout: default
title: FieldsPopupContent
parent: Classes
---
---
layout: default
title: FieldsPopupContent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## FieldsPopupContent Class

A FieldsContent popup element represents the FieldInfo associated with a feature. If this is not set within the  
content, it will revert to whatever may be set within the PopupTemplate.fieldInfos property.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-FieldsContent.html">ArcGIS JS API</a>

```csharp
public class FieldsPopupContent : dymaptic.GeoBlazor.Core.Components.Popups.PopupContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [PopupContent](dymaptic.GeoBlazor.Core.Components.Popups.PopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupContent') &#129106; FieldsPopupContent
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.FieldsPopupContent()'></a>

## FieldsPopupContent() Constructor

Parameterless constructor for using as a razor component

```csharp
public FieldsPopupContent();
```

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.FieldsPopupContent(dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo[],string,string)'></a>

## FieldsPopupContent(FieldInfo[], string, string) Constructor

Constructs a new PopupContent in code with parameters

```csharp
public FieldsPopupContent(dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo[] fieldInfos, string? description=null, string? title=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.FieldsPopupContent(dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo[],string,string).fieldInfos'></a>

`fieldInfos` [FieldInfo](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

A collection of [FieldInfo](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.FieldsPopupContent(dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo[],string,string).description'></a>

`description` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Describes the field's content in detail.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.FieldsPopupContent(dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo[],string,string).title'></a>

`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Heading indicating what the field's content represents.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.Description'></a>

## FieldsPopupContent.Description Property

Describes the field's content in detail.

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.FieldInfos'></a>

## FieldsPopupContent.FieldInfos Property

Array of [FieldInfo](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo')s

```csharp
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo>? FieldInfos { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[FieldInfo](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.Title'></a>

## FieldsPopupContent.Title Property

Heading indicating what the field's content represents.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.Type'></a>

## FieldsPopupContent.Type Property

The type of Popup Content

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## FieldsPopupContent.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method. If you see no other way to register a child component, please open an issue on GitHub.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## FieldsPopupContent.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method.

