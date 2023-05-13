---
layout: default
title: ChartMediaInfoValueSeries
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## ChartMediaInfoValueSeries Class

The ChartMediaInfoValueSeries class is a read-only support class that represents information specific to how data  
should be plotted in a chart. It helps provide a consistent API for plotting charts used by the Popup widget.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ChartMediaInfoValueSeries.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class ChartMediaInfoValueSeries : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; ChartMediaInfoValueSeries
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValueSeries.ChartMediaInfoValueSeries()'></a>

## ChartMediaInfoValueSeries() Constructor

Parameterless constructor for use as a razor component.

```csharp
public ChartMediaInfoValueSeries();
```

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValueSeries.ChartMediaInfoValueSeries(string,string,System.Nullable_double_)'></a>

## ChartMediaInfoValueSeries(string, string, Nullable<double>) Constructor

Constructor for building a [ChartMediaInfoValueSeries](dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValueSeries.html 'dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValueSeries') in code.

```csharp
public ChartMediaInfoValueSeries(string? fieldName=null, string? tooltip=null, System.Nullable<double> value=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValueSeries.ChartMediaInfoValueSeries(string,string,System.Nullable_double_).fieldName'></a>

`fieldName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String value indicating the field's name for a series.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValueSeries.ChartMediaInfoValueSeries(string,string,System.Nullable_double_).tooltip'></a>

`tooltip` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String value indicating the tooltip for a series.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValueSeries.ChartMediaInfoValueSeries(string,string,System.Nullable_double_).value'></a>

`value` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Numerical value for the chart series.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValueSeries.FieldName'></a>

## ChartMediaInfoValueSeries.FieldName Property

String value indicating the field's name for a series.

```csharp
public string? FieldName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValueSeries.Tooltip'></a>

## ChartMediaInfoValueSeries.Tooltip Property

String value indicating the tooltip for a series.

```csharp
public string? Tooltip { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValueSeries.Value'></a>

## ChartMediaInfoValueSeries.Value Property

Numerical value for the chart series.

```csharp
public System.Nullable<double> Value { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
