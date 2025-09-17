# GeoBlazor Constructor Validator

## Purpose

This validator ensures that Blazor components in GeoBlazor projects follow the correct constructor patterns required by the .NET Dependency Injection container.

Specifically, it validates that classes inheriting from `ComponentBase` (or `MapComponent`) that have multiple constructors properly use the `[ActivatorUtilitiesConstructor]` attribute on their parameterless constructor.

## Why This Matters

When a Blazor component has multiple constructors (both parameterless and parameterized), the DI container needs to know which constructor to use. The `[ActivatorUtilitiesConstructor]` attribute tells the DI container to use the marked constructor when instantiating the component from Razor markup.

## Validation Rules

The validator checks the following:

1. **Classes that inherit from ComponentBase or MapComponent** - Only these classes are validated
2. **Classes with both parameterless and parameterized constructors** - The parameterless constructor must have the attribute
3. **Both `.cs` and `.gb.cs` files are validated** - Generated code must also follow the pattern

## What Gets Skipped

- Classes with only parameterless constructors (no attribute needed)
- Classes with only parameterized constructors (compiler will handle this)
- Non-ComponentBase classes

## Usage

The validator can be used with any GeoBlazor project (Core, Pro, etc.).

### Automatic Build Integration

The validator runs automatically before building GeoBlazor projects via an MSBuild target:

```xml
<Target Name="ValidateConstructors" BeforeTargets="Build">
    <Message Importance="high" Text="Validating constructor patterns..." />
    <Exec Command="dotnet run -- $(MSBuildProjectFullPath)"
          WorkingDirectory="$(ProjectDir)../dymaptic.GeoBlazor.Core.Validator"
          ContinueOnError="false"
          IgnoreExitCode="false" />
</Target>
```

### Manual Execution

```bash
# From the validator directory
cd src/dymaptic.GeoBlazor.Core.Validator
dotnet run -- <path-to-project-file>

# Or from anywhere
dotnet run --project src/dymaptic.GeoBlazor.Core.Validator/dymaptic.GeoBlazor.Core.Validator.csproj -- <path-to-project-file>
```

Examples:
```bash
# Validate GeoBlazor.Core
dotnet run -- ../dymaptic.GeoBlazor.Core/dymaptic.GeoBlazor.Core.csproj

# Validate GeoBlazor.Pro
dotnet run -- ../dymaptic.GeoBlazor.Pro/dymaptic.GeoBlazor.Pro.csproj
```

## Output

The validator reports:
- Number of files analyzed (including breakdown of `.cs` vs `.gb.cs` files)
- Success message if all classes are compliant
- List of non-compliant classes with their file paths if violations are found

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