---
layout: default
title: HitTestOptions
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## HitTestOptions Class

Options to specify what is included in or excluded from the hitTest.

```csharp
public class HitTestOptions :
System.IEquatable<dymaptic.GeoBlazor.Core.Events.HitTestOptions>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HitTestOptions

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[HitTestOptions](dymaptic.GeoBlazor.Core.Events.HitTestOptions.html 'dymaptic.GeoBlazor.Core.Events.HitTestOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.HitTestOptions.ExcludeByGeoBlazorId'></a>

## HitTestOptions.ExcludeByGeoBlazorId Property

A list of layers and/or graphics GeoBlazor Ids (Guid) to exclude from the hitTest. No layers or graphics will be excluded if exclude is not specified.

```csharp
public System.Collections.Generic.IEnumerable<System.Guid>? ExcludeByGeoBlazorId { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Events.HitTestOptions.ExcludeGraphicsByArcGISId'></a>

## HitTestOptions.ExcludeGraphicsByArcGISId Property

A list of graphic ArcGIS OBJECTID attributes to exclude in the hitTest. No layers and graphics will be excluded if exclude is not specified.

```csharp
public System.Collections.Generic.IEnumerable<string>? ExcludeGraphicsByArcGISId { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Events.HitTestOptions.ExcludeLayersByArcGISId'></a>

## HitTestOptions.ExcludeLayersByArcGISId Property

A list of layer ArcGIS Ids (aka FIELDID or OBJECTID) to exclude in the hitTest. No layers and graphics will be excluded if exclude is not specified.

```csharp
public System.Collections.Generic.IEnumerable<string>? ExcludeLayersByArcGISId { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Events.HitTestOptions.IncludeByGeoBlazorId'></a>

## HitTestOptions.IncludeByGeoBlazorId Property

A list of layers and/or graphics GeoBlazor Ids (Guid) to include in the hitTest. All layers and graphics will be included if include is not specified.

```csharp
public System.Collections.Generic.IEnumerable<System.Guid>? IncludeByGeoBlazorId { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Events.HitTestOptions.IncludeGraphicsByArcGISId'></a>

## HitTestOptions.IncludeGraphicsByArcGISId Property

A list of graphic ArcGIS OBJECTID attributes to include in the hitTest. All layers and graphics will be included if include is not specified.

```csharp
public System.Collections.Generic.IEnumerable<string>? IncludeGraphicsByArcGISId { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='dymaptic.GeoBlazor.Core.Events.HitTestOptions.IncludeLayersByArcGISId'></a>

## HitTestOptions.IncludeLayersByArcGISId Property

A list of layer ArcGIS Ids (aka FIELDID or OBJECTID) to include in the hitTest. All layers and graphics will be included if include is not specified.

```csharp
public System.Collections.Generic.IEnumerable<string>? IncludeLayersByArcGISId { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
