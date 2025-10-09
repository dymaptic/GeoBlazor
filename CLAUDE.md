# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

GeoBlazor is a Blazor component library that brings ArcGIS Maps SDK for JavaScript capabilities to .NET applications. It enables developers to create interactive maps using pure C# code without writing JavaScript.

## Architecture

### Core Structure
- **dymaptic.GeoBlazor.Core**: Main library with Blazor components wrapping ArcGIS JavaScript SDK
- **Code Generation**: Uses `.gb.cs` and `.gb.ts` generated files alongside editable `.cs` and `.ts` files
  - DO NOT edit `.gb.*` files - changes will be overwritten
  - Move code from generated files to non-generated versions and mark with `[CodeGenerationIgnore]`
- **TypeScript/JavaScript Bridge**: TypeScript files in `Scripts/` folder compiled via ESBuild
- **Component Pattern**: MapComponents can be used in both Razor markup and C# code

### Key Patterns
- **Dual Constructors**: Components have empty constructor for Razor and parameterized constructor for C# instantiation
- **Wrapper Pattern**: JavaScript objects wrapped in TypeScript classes for method calls
- **Build Functions**: `buildJs*` and `buildDotNet*` functions handle conversions between C#/JS objects

## Common Commands

### Build
```bash
# Build entire solution
dotnet build src/dymaptic.GeoBlazor.Core.sln

# Build specific configuration
dotnet build src/dymaptic.GeoBlazor.Core.sln -c Release
dotnet build src/dymaptic.GeoBlazor.Core.sln -c Debug

# Build TypeScript/JavaScript (from src/dymaptic.GeoBlazor.Core/)
pwsh esBuild.ps1 -c Debug
pwsh esBuild.ps1 -c Release

# NPM scripts for TypeScript compilation
npm run debugBuild
npm run releaseBuild
npm run watchBuild
```

### Test
```bash
# Run all tests
dotnet test src/dymaptic.GeoBlazor.Core.sln

# Run specific test project
dotnet test test/dymaptic.GeoBlazor.Core.Test.Unit/dymaptic.GeoBlazor.Core.Test.Unit.csproj
dotnet test test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared/dymaptic.GeoBlazor.Core.Test.Blazor.Shared.csproj

# Run with specific verbosity
dotnet test --verbosity normal
```

### Version Management
```bash
# Bump version (from repository root)
pwsh bumpVersion.ps1              # Increments build number
pwsh bumpVersion.ps1 -publish     # Prepares for NuGet publish
pwsh bumpVersion.ps1 -test 1.2.3  # Test version bump
```

### Development
```bash
# Clear ESBuild locks if build is stuck
pwsh esBuildClearLocks.ps1

# Watch TypeScript changes (from src/dymaptic.GeoBlazor.Core/)
npm run watchBuild

# Install npm dependencies
npm install
```

## Test Projects
- **dymaptic.GeoBlazor.Core.Test.Unit**: Unit tests
- **dymaptic.GeoBlazor.Core.Test.Blazor.Shared**: Blazor component tests
- **dymaptic.GeoBlazor.Core.Test.WebApp**: WebApp integration tests
- **dymaptic.GeoBlazor.Core.SourceGenerator.Tests**: Source generator tests

## Sample Projects
- **Sample.Wasm**: WebAssembly sample
- **Sample.WebApp**: Server-side Blazor sample
- **Sample.Maui**: MAUI hybrid sample
- **Sample.OAuth**: OAuth authentication sample
- **Sample.TokenRefresh**: Token refresh sample
- **Sample.Shared**: Shared components and pages for samples

## Important Notes

### Build Errors
Known issue: ESBuild compilation conflicts with MSBuild static file analysis may cause intermittent build errors when building projects with project references to Core. This is tracked with Microsoft.

### Development Workflow
1. Changes to TypeScript require running ESBuild (automatic via source generator or manual via `esBuild.ps1`)
2. Browser cache should be disabled when testing JavaScript changes
3. Generated code (`.gb.*` files) should never be edited directly
4. When adding new components, contact the GeoBlazor team for code generation setup

### Component Development
- Components must have `[ActivatorUtilitiesConstructor]` on parameterless constructor
- Properties should use `{ get; private set; }` pattern
- Child components require `RegisterChildComponent`/`UnregisterChildComponent` implementation
- Required parameters should use `[RequiredProperty]` attribute

### TypeScript/JavaScript Integration
- Complex ArcGIS objects need `buildJs*` functions in `jsBuilder.ts`
- Null checks required - ArcGIS fails silently with null values
- Use `?? undefined` in constructors or `hasValue()` checks
- Wrapper classes needed for objects with methods

## Dependencies
- .NET 8.0+ SDK
- Node.js (for TypeScript compilation)
- ArcGIS Maps SDK for JavaScript (v4.33.10)
- ESBuild for TypeScript compilation