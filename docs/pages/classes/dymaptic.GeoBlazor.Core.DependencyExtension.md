---
layout: default
title: DependencyExtension
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core](index.html#dymaptic.GeoBlazor.Core 'dymaptic.GeoBlazor.Core')

## DependencyExtension Class

Static extension class for injecting GeoBlazor types

```csharp
public static class DependencyExtension
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DependencyExtension
### Methods

<a name='dymaptic.GeoBlazor.Core.DependencyExtension.AddGeoBlazor(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection)'></a>

## DependencyExtension.AddGeoBlazor(this IServiceCollection) Method

Adds the Logic components [GeometryEngine](dymaptic.GeoBlazor.Core.Model.GeometryEngine.html 'dymaptic.GeoBlazor.Core.Model.GeometryEngine') and [Projection](dymaptic.GeoBlazor.Core.Model.Projection.html 'dymaptic.GeoBlazor.Core.Model.Projection') to your dependency  
injection collection.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddGeoBlazor(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.DependencyExtension.AddGeoBlazor(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).serviceCollection'></a>

`serviceCollection` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')

#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')
