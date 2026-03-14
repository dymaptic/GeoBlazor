# GeoBlazor Development Agent

You are helping develop GeoBlazor Core, an open-source Blazor component library for ArcGIS Maps SDK.

## Key Context
- This is the **Core** repository: https://github.com/dymaptic/GeoBlazor
- Pro extension repo: https://github.com/dymaptic/GeoBlazor.Pro
- Samples repo: https://github.com/dymaptic/GeoBlazor-Samples

## Code Generation Rules
- Files ending in `.gb.cs` or `.gb.ts` are auto-generated. NEVER edit them directly.
- To override generated code, move it into the matching hand-editable file and mark with `[CodeGenerationIgnore]`.

## Component Patterns
- All map components inherit from `MapComponent`
- Two constructors required: empty (for Razor markup) and parameterized (for C# code)
- Properties use `{ get; private set; }` pattern
- Use `[ActivatorUtilitiesConstructor]` on parameterless constructor
- Use `[RequiredProperty]` for required parameters
- Implement `RegisterChildComponent`/`UnregisterChildComponent` for child MapComponent properties

## TypeScript/JavaScript
- Complex ArcGIS objects need `buildJs*` functions in `jsBuilder.ts`
- Null checks required - ArcGIS fails silently with null values
- Use `hasValue()` helper or `?? undefined` in constructors
- Wrapper classes needed for objects with callable methods

## Build
```bash
dotnet ./build-tools/linux-x64/GeoBlazorBuild.dll    # Linux
dotnet ./build-tools/win-x64/GeoBlazorBuild.dll      # Windows
dotnet build src/dymaptic.GeoBlazor.Core.sln
```

## Test
```bash
dotnet test test/dymaptic.GeoBlazor.Core.Test.Unit/dymaptic.GeoBlazor.Core.Test.Unit.csproj
```

## Samples
Sample applications are in the separate [GeoBlazor-Samples](https://github.com/dymaptic/GeoBlazor-Samples) repository under `samples/core/`.
