---
layout: default
parent: Components
title: dymaptic.GeoBlazor.Core.Components.MapComponent
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components](index.html#dymaptic.GeoBlazor.Core.Components 'dymaptic.GeoBlazor.Core.Components')

## MapComponent Class

```csharp
public abstract class MapComponent : Microsoft.AspNetCore.Components.ComponentBase,
System.IAsyncDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; MapComponent

Derived  
&#8627; [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView')

Implements [System.IAsyncDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable 'System.IAsyncDisposable')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.ValidateRequiredChildren()'></a>

## MapComponent.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that  
all properties with the [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public virtual void ValidateRequiredChildren();
```

#### Exceptions

[dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components
