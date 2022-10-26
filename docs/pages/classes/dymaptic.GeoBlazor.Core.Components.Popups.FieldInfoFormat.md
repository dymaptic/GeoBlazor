---
layout: default
title: FieldInfoFormat
parent: Classes
---
---
layout: default
title: FieldInfoFormat
parent: Classes
---
---
layout: default
title: FieldInfoFormat
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## FieldInfoFormat Class

The FieldInfoFormat class is used with numerical or date fields to provide more detail about how the value should be displayed in a popup. Use this class in place of the legacy formatting functions: DateString, DateFormat, and/or NumberFormat.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-support-FieldInfoFormat.html">ArcGIS JS API</a>

```csharp
public class FieldInfoFormat : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; FieldInfoFormat
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat.DateFormat'></a>

## FieldInfoFormat.DateFormat Property

Used only with Date fields.

```csharp
public string? DateFormat { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat.DigitSeparator'></a>

## FieldInfoFormat.DigitSeparator Property

Used only with Number fields.

```csharp
public System.Nullable<bool> DigitSeparator { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat.Places'></a>

## FieldInfoFormat.Places Property

Used only with Number fields to specify the number of supported decimal places that should appear in popups.

```csharp
public System.Nullable<int> Places { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')


