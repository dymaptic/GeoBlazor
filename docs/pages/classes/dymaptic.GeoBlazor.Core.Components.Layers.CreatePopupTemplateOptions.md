---
layout: default
title: CreatePopupTemplateOptions
parent: Classes
---
---
layout: default
title: CreatePopupTemplateOptions
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## CreatePopupTemplateOptions Class

Options for creating the [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate').

```csharp
public class CreatePopupTemplateOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CreatePopupTemplateOptions
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.CreatePopupTemplateOptions.IgnoreFieldTypes'></a>

## CreatePopupTemplateOptions.IgnoreFieldTypes Property

An array of field types to ignore when creating the popup. System fields such as Shape_Area and Shape_length, in  
addition to geometry, blob, raster, guid and xml field types are automatically ignored.

```csharp
public string[]? IgnoreFieldTypes { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.CreatePopupTemplateOptions.VisibleFieldNames'></a>

## CreatePopupTemplateOptions.VisibleFieldNames Property

An array of field names set to be visible within the PopupTemplate.

```csharp
public System.Collections.Generic.HashSet<string>? VisibleFieldNames { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

