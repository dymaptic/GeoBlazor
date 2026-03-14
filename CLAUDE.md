# CLAUDE.md - GeoBlazor Core

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

GeoBlazor is a Blazor component library that brings ArcGIS Maps SDK for JavaScript capabilities to .NET applications. It enables developers to create interactive maps using pure C# code without writing JavaScript.

## Related Repositories

| Repository           | URL                                              | Purpose                              |
|----------------------|--------------------------------------------------|--------------------------------------|
| **This Repo (Core)** | https://github.com/dymaptic/GeoBlazor            | Open-source Blazor mapping library   |
| GeoBlazor Pro        | https://github.com/dymaptic/GeoBlazor.Pro        | Commercial extension with 3D support |
| GeoBlazor Samples    | https://github.com/dymaptic/GeoBlazor-Samples    | Sample applications                  |

> **Note:** This repository may also be used as a git submodule within the GeoBlazor.Pro repository (at `GeoBlazor.Pro/GeoBlazor/`).
> When used as a submodule, the parent Pro repository's CLAUDE.md provides additional context about the Pro build system.

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

### Project Structure
```
GeoBlazor/
├── src/
│   ├── dymaptic.GeoBlazor.Core/                # Main library source
│   │   ├── Components/                          # Blazor components (MapView, layers, widgets, etc.)
│   │   ├── Scripts/                             # TypeScript interop files
│   │   └── wwwroot/                             # Static assets (JS output, CSS)
│   ├── dymaptic.GeoBlazor.Core.SourceGenerator/ # Source generator for test discovery
│   └── dymaptic.GeoBlazor.Core.BuildTools/      # MSBuild tasks
├── test/
│   ├── dymaptic.GeoBlazor.Core.Test.Unit/       # Unit tests
│   ├── dymaptic.GeoBlazor.Core.Test.Blazor.Shared/ # Blazor component tests
│   ├── dymaptic.GeoBlazor.Core.Test.WebApp/     # Test runner web application
│   └── dymaptic.GeoBlazor.Core.Test.Automation/ # Playwright automation tests
├── docs/                                        # Developer documentation
├── build-tools/                                 # Platform-specific build binaries
└── Directory.Build.props                        # Version and shared build configuration
```

## Common Commands

### Build
```bash
# Clean build of the Core project (use linux-x64 or win-x64 as appropriate)
dotnet ./build-tools/linux-x64/GeoBlazorBuild.dll
dotnet ./build-tools/win-x64/GeoBlazorBuild.dll

# GeoBlazorBuild includes many options, use -h to see all options

# Build entire solution
dotnet build src/dymaptic.GeoBlazor.Core.sln

# Build specific configuration
dotnet build src/dymaptic.GeoBlazor.Core.sln -c Release
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

### TypeScript Development
```bash
# Build TypeScript/JavaScript (from Core repo root)
dotnet ./build/ESBuild.cs -- -c Debug
dotnet ./build/ESBuild.cs -- -c Release

# Watch TypeScript changes (from src/dymaptic.GeoBlazor.Core/)
npm run watchBuild

# Install npm dependencies (from src/dymaptic.GeoBlazor.Core/)
npm install

# Clear ESBuild locks if build is stuck
dotnet ./build-tools/win-x64/ESBuildClearLocks.dll
```

### Version Management
```bash
# Bump version (from repository root)
pwsh bumpVersion.ps1              # Increments build number
pwsh bumpVersion.ps1 -publish     # Prepares for NuGet publish
pwsh bumpVersion.ps1 -test 1.2.3  # Test version bump
```

## Sample Projects

Sample projects are in the separate [GeoBlazor-Samples](https://github.com/dymaptic/GeoBlazor-Samples) repository.
Core samples are under `samples/core/` in that repo.

## Important Notes

### Build Errors
Known issue: ESBuild compilation conflicts with MSBuild static file analysis may cause intermittent build errors when building projects with project references to Core. This is tracked with [Microsoft](https://github.com/dotnet/sdk/issues/49988).

### Development Workflow
1. Changes to TypeScript require running ESBuild (automatic via source generator or manual via `ESBuild.cs`). You should see a popup dialog when this is happening automatically from the source generator.
2. Browser cache should be disabled when testing JavaScript changes
3. Generated code (`.gb.*` files) should never be edited directly. Instead, move code into the matching hand-editable file to "override" the generated code.
4. New sample pages go in the [GeoBlazor-Samples](https://github.com/dymaptic/GeoBlazor-Samples) repository

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
- **Platform:** When on Windows, use the Windows version (not WSL)
- **Shell:** Use Bash-compatible commands. On Windows this means Git Bash/MSYS2.
- **CRITICAL:** NEVER use `nul` in Bash commands - use `/dev/null` instead
- **Commands:** Use Unix/Bash commands (`ls`, `cat`, `grep`), NOT Windows commands (`dir`, `type`, `findstr`)

## Agents

Specialized Claude Code agent configurations for GeoBlazor development are maintained in the [GeoBlazor-Agents](https://github.com/dymaptic/GeoBlazor-Agents) repository. These provide researcher/developer/reviewer triplets for .NET, JavaScript, TypeScript, GeoBlazor Core/Pro/Code-Gen, C#/JS interop, and MCP development.

### Finding Agents

Agents are available from two locations (check in this order):

1. **Local on disk** — `CLAUDE_CONFIG_DIR` environment variable points to the local config directory (currently `D:/claude files`). Agent templates live in `$CLAUDE_CONFIG_DIR/agents/` with subdirectories per domain (`dotnet/`, `geoblazor/`, `interop/`, `javascript/`, `typescript/`, `mcp-experts/`).
2. **GitHub** — If not available locally, fetch from `https://github.com/dymaptic/GeoBlazor-Agents`. The `agents/` directory mirrors the local structure. Use `gh api repos/dymaptic/GeoBlazor-Agents/contents/agents` to browse, or clone the repo.

### Key Agent Files

- `AGENTS_REFERENCE.md` — Full catalog with triggers, descriptions, and usage examples
- `agents/DESIGN.md` — Agent system design principles and patterns
- `agents/AGENT_SYSTEM_TEMPLATE.md` — Template for creating new agents

### Agent Workflow

Use the **researcher → developer → reviewer** pattern: research existing patterns and known issues first, then implement, then review. For cross-repo work use `geoblazor-architect`; for C#/JS boundary issues use `interop-architect`.
