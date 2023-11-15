# .NET 8 Blazor Web App Sample

This sample shows how to use the GeoBlazor library in a Blazor Web App.
There are two projects related to the BWA
- `dymaptic.GeoBlazor.Core.Sample.WebApp`
- `dymaptic.GeoBlazor.Core.Sample.WebApp.Client`

The `Client` app is referenced by the core `WebApp`, and is used to render WebAssembly components.
We have added a `RenderModeSelector` to the sample, which allows you to test the different rendering modes.