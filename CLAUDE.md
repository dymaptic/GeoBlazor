# CLAUDE.md - GeoBlazor Core

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

> **IMPORTANT:** This repository is a git submodule of the GeoBlazor CodeGen repository.
> For complete context including environment notes, available agents, and cross-repo coordination,
> see the parent CLAUDE.md at: `../../CLAUDE.md` (`dymaptic.GeoBlazor.CodeGen/Claude.md`)

## Project Overview

GeoBlazor is a Blazor component library that brings ArcGIS Maps SDK for JavaScript capabilities to .NET applications. It enables developers to create interactive maps using pure C# code without writing JavaScript.

## Repository Context

| Repository             | Path                                                  | Purpose                               |
|------------------------|-------------------------------------------------------|---------------------------------------|
| **This Repo (Core)**   | `dymaptic.GeoBlazor.CodeGen/GeoBlazor.Pro/GeoBlazor`  | Open-source Blazor mapping library    |
| Parent (Pro)           | `dymaptic.GeoBlazor.CodeGen/GeoBlazor.Pro`            | Commercial extension with 3D support  |
| Root (CodeGen)         | `dymaptic.GeoBlazor.CodeGen`                          | Code generator from ArcGIS TypeScript |

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
# Clean build of the Core project
pwsh GeoBlazorBuild.ps1

# GeoBlazorBuild.ps1 includes lots of options, use -h to see options

# Build entire solution
dotnet build src/dymaptic.GeoBlazor.Core.sln

# Build specific configuration
dotnet build src/dymaptic.GeoBlazor.Core.sln -c Release
dotnet build src/dymaptic.GeoBlazor.Core.sln -c Debug

# Build TypeScript/JavaScript (from src/dymaptic.GeoBlazor.Core/)
pwsh esBuild.ps1 -c Debug
pwsh esBuild.ps1 -c Release
```

### Test
```bash
# Run all tests automatically in the GeoBlazor browser test runner
dotnet run test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj /p:RunOnStart=true /p:RenderMode=WebAssembly

# Run non-browser unit tests
dotnet test test/dymaptic.GeoBlazor.Core.Test.Unit/dymaptic.GeoBlazor.Core.Test.Unit.csproj

# Run source-generation tests
dotnet test test/dymaptic.GeoBlazor.Core.SourceGenerator.Tests/dymaptic.GeoBlazor.Core.SourceGenerator.Tests.csproj
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
npm install (from src/dymaptic.GeoBlazor.Core/)
```

## Test Projects
- **dymaptic.GeoBlazor.Core.Test.Unit**: Unit tests
- **dymaptic.GeoBlazor.Core.Test.Blazor.Shared**: GeoBlazor component tests and test runner logic
- **dymaptic.GeoBlazor.Core.Test.WebApp**: Test running application for the GeoBlazor component tests (`Core.Test.Blazor.Shared`)
- **dymaptic.GeoBlazor.Core.SourceGenerator.Tests**: Source generator tests

## Sample Projects
- **Sample.Wasm**: Standalone WebAssembly sample runner
- **Sample.WebApp**: Blazor Web App sample runner with render mode selector
- **Sample.Maui**: MAUI hybrid sample runner
- **Sample.OAuth**: OAuth authentication sample
- **Sample.TokenRefresh**: Token refresh sample
- **Sample.Shared**: Shared components and pages for samples (used by Wasm, WebApp, and Maui runners)

## Important Notes

### Build Errors
Known issue: ESBuild compilation conflicts with MSBuild static file analysis may cause intermittent build errors when building projects with project references to Core. This is tracked with Microsoft.

### Development Workflow
1. Changes to TypeScript require running ESBuild (automatic via source generator or manual via `esBuild.ps1`). You should see a popup dialog when this is happening automatically from the source generator.
2. Browser cache should be disabled when testing JavaScript changes
3. Generated code (`.gb.*` files) should never be edited directly. Instead, move code into the matching hand-editable file to "override" the generated code.
4. When adding new components, use the Code Generator in the parent CodeGen repository

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
- ArcGIS Maps SDK for JavaScript (v4.33)
- ESBuild for TypeScript compilation

## Environment Notes

**See parent CLAUDE.md for full environment details.** Key points:
- **Platform:** When on Windows, use the Windows version (not WSL)
- **Shell:** Bash (Git Bash/MSYS2) - Use Unix-style commands
- **CRITICAL:** NEVER use 'nul' in Bash commands - use `/dev/null` instead
- **Commands:** Use Unix/Bash commands (`ls`, `cat`, `grep`), NOT Windows commands (`dir`, `type`, `findstr`)
