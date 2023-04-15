---
layout: default
title: MarkerSymbol
parent: Classes
---
---
layout: default
title: MarkerSymbol
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Symbols](index.html#dymaptic.GeoBlazor.Core.Components.Symbols 'dymaptic.GeoBlazor.Core.Components.Symbols')

## MarkerSymbol Class

Marker symbols are used to draw Point graphics in a FeatureLayer or individual graphics in a 2D MapView. To create  
new marker symbols, use either SimpleMarkerSymbol or PictureMarkerSymbol.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-MarkerSymbol.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public abstract class MarkerSymbol : dymaptic.GeoBlazor.Core.Components.Symbols.Symbol
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') &#129106; MarkerSymbol

Derived  
&#8627; [PictureMarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol')  
&#8627; [SimpleMarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MarkerSymbol.Angle'></a>

## MarkerSymbol.Angle Property

The angle of the marker relative to the screen in degrees.

```csharp
public System.Nullable<double> Angle { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MarkerSymbol.XOffset'></a>

## MarkerSymbol.XOffset Property

The offset on the x-axis in points.

```csharp
public System.Nullable<double> XOffset { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MarkerSymbol.YOffset'></a>

## MarkerSymbol.YOffset Property

The offset on the y-axis in points.

```csharp
public System.Nullable<double> YOffset { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

