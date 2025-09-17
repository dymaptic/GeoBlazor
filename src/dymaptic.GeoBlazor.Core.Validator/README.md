# GeoBlazor Core Validator

## Purpose

This validator ensures that Blazor components in the GeoBlazor.Core project follow the correct constructor patterns required by the .NET Dependency Injection container.

Specifically, it validates that classes inheriting from `ComponentBase` (or `MapComponent`) that have multiple constructors properly use the `[ActivatorUtilitiesConstructor]` attribute on their parameterless constructor.

## Why This Matters

When a Blazor component has multiple constructors (both parameterless and parameterized), the DI container needs to know which constructor to use. The `[ActivatorUtilitiesConstructor]` attribute tells the DI container to use the marked constructor when instantiating the component from Razor markup.

## Validation Rules

The validator checks the following:

1. **Classes that inherit from ComponentBase or MapComponent** - Only these classes are validated
2. **Classes with both parameterless and parameterized constructors** - If all constructors are parameterless, no attribute is needed
3. **Parameterless constructor must have the attribute** - When both types exist, the parameterless one needs `[ActivatorUtilitiesConstructor]`

## What Gets Skipped

- Classes with only parameterless constructors (no attribute needed)
- Classes with only parameterized constructors (compiler will catch this)
- Generated code files (`.gb.cs`) - These are auto-generated and should not be modified
- Non-ComponentBase classes

## Usage

The validator runs automatically as part of the build process for the GeoBlazor.Core project.

### Manual Execution

```bash
dotnet run --project src/dymaptic.GeoBlazor.Core.Validator/dymaptic.GeoBlazor.Core.Validator.csproj -- <path-to-project>
```

Example:
```bash
dotnet run --project src/dymaptic.GeoBlazor.Core.Validator/dymaptic.GeoBlazor.Core.Validator.csproj -- src/dymaptic.GeoBlazor.Core/dymaptic.GeoBlazor.Core.csproj
```

## Build Integration

The validator is integrated into the GeoBlazor.Core build process via an MSBuild target:

```xml
<Target Name="ValidateConstructors" AfterTargets="Build">
    <Exec Command="$(ProjectDir)../dymaptic.GeoBlazor.Core.Validator/bin/$(Configuration)/net9.0/dymaptic.GeoBlazor.Core.Validator.exe $(MSBuildProjectFullPath)"
          ContinueOnError="false"
          Condition="Exists('$(ProjectDir)../dymaptic.GeoBlazor.Core.Validator/bin/$(Configuration)/net9.0/dymaptic.GeoBlazor.Core.Validator.exe')" />
</Target>
```

The build will fail if any violations are found.

## Example Violations

### ❌ Non-Compliant
```csharp
public class MyComponent : MapComponent
{
    public MyComponent() { }  // Missing [ActivatorUtilitiesConstructor]

    public MyComponent(ILogger logger) { }
}
```

### ✅ Compliant
```csharp
public class MyComponent : MapComponent
{
    [ActivatorUtilitiesConstructor]
    public MyComponent() { }

    public MyComponent(ILogger logger) { }
}
```

## Exit Codes

- `0` - All validations passed
- `1` - Validation failures found or error occurred

## Notes

- The validator uses Roslyn to analyze the C# syntax tree
- Only public constructors are checked (private/protected are ignored)
- Compiler-generated constructors are excluded from validation