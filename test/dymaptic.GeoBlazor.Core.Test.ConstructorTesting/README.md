# Constructor Testing Console Application

## Overview

This console application validates that all ComponentBase-derived classes in the GeoBlazor solution follow the required constructor pattern. Specifically, it ensures that any class inheriting from `ComponentBase` (or `MapComponent`) that has 2 or more constructors includes a parameterless constructor decorated with the `[ActivatorUtilitiesConstructor]` attribute.

## Purpose

In Blazor applications, components with multiple constructors must explicitly mark which constructor should be used for dependency injection. This is done using the `[ActivatorUtilitiesConstructor]` attribute on the parameterless constructor. This pattern is critical for GeoBlazor components to work correctly in both Razor markup and C# code contexts.

## How It Works

The application uses Roslyn (the .NET Compiler Platform) to:
1. Load the entire `dymaptic.GeoBlazor.Core.sln` solution
2. Analyze all projects and their source files
3. Identify classes that inherit from `ComponentBase` or `MapComponent`
4. Check if classes with 2+ constructors have a compliant parameterless constructor
5. Report any violations found

## Running the Application

### Command Line

From the repository root:
```bash
dotnet run --project test/dymaptic.GeoBlazor.Core.Test.ConstructorTesting/dymaptic.GeoBlazor.Core.Test.ConstructorTesting.csproj
```

From the project directory:
```bash
cd test/dymaptic.GeoBlazor.Core.Test.ConstructorTesting
dotnet run
```

### Build and Run
```bash
# Build the project
dotnet build test/dymaptic.GeoBlazor.Core.Test.ConstructorTesting/dymaptic.GeoBlazor.Core.Test.ConstructorTesting.csproj

# Run the compiled executable
dotnet test/dymaptic.GeoBlazor.Core.Test.ConstructorTesting/bin/Debug/net9.0/dymaptic.GeoBlazor.Core.Test.ConstructorTesting.dll
```

## Output

### Success
When all classes comply with the constructor requirements:
```
All classes with 2+ constructors have a parameterless constructor using the [ActivatorUtilitiesConstructor] attribute.
```
Exit code: 0

### Failure
When violations are found:
```
The following classes contain 2+ constructors, but do not have a parameterless constructor that correctly uses the [ActivatorUtilitiesConstructor] attribute. Please update the following list of the class names:
- ClassName1 - src/dymaptic.GeoBlazor.Core/Components/SomeComponent.cs
- ClassName2 - samples/SampleProject/SomeOtherComponent.cs
```
Exit code: 1

## Integration with Build Process

### PostBuild Event (Future Implementation)

To add this validation to the build process, add the following to the main project file (`dymaptic.GeoBlazor.Core.csproj`):

```xml
<Target Name="ValidateConstructors" AfterTargets="Build">
  <Exec Command="dotnet run --project $(MSBuildThisFileDirectory)../../test/dymaptic.GeoBlazor.Core.Test.ConstructorTesting/dymaptic.GeoBlazor.Core.Test.ConstructorTesting.csproj"
        WorkingDirectory="$(MSBuildProjectDirectory)"
        ContinueOnError="false" />
</Target>
```

Or for a more lightweight approach after publishing the tool:

```xml
<Target Name="ValidateConstructors" AfterTargets="Build">
  <Exec Command="dotnet $(MSBuildThisFileDirectory)../../test/dymaptic.GeoBlazor.Core.Test.ConstructorTesting/bin/$(Configuration)/net9.0/dymaptic.GeoBlazor.Core.Test.ConstructorTesting.dll"
        ContinueOnError="false" />
</Target>
```

### CI/CD Pipeline Integration

Add to your CI/CD pipeline (e.g., GitHub Actions, Azure DevOps):

```yaml
- name: Validate Constructor Patterns
  run: dotnet run --project test/dymaptic.GeoBlazor.Core.Test.ConstructorTesting/dymaptic.GeoBlazor.Core.Test.ConstructorTesting.csproj
```

## Technical Details

### What Gets Checked

- **Inheritance**: Classes inheriting from `ComponentBase` or `MapComponent`
- **Constructor Count**: Only classes with 2 or more public constructors
- **Compliance**: Presence of a parameterless constructor with `[ActivatorUtilitiesConstructor]`

### Example of Compliant Class

```csharp
public partial class MyComponent : MapComponent
{
    /// <summary>
    /// Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public MyComponent()
    {
    }

    /// <summary>
    /// Constructor for use in C# code.
    /// </summary>
    public MyComponent(string param1, int param2)
    {
        // Set properties
    }
}
```

## Dependencies

- .NET 9.0 SDK
- Microsoft.CodeAnalysis.CSharp (Roslyn)
- Microsoft.Build.Locator
- Access to the GeoBlazor solution file

## Troubleshooting

### "Could not find solution file"
- Ensure you're running from within the GeoBlazor repository
- The tool looks for `src/dymaptic.GeoBlazor.Core.sln` relative to current directory

### Build errors
- Ensure all projects in the solution can build successfully
- Run `dotnet build src/dymaptic.GeoBlazor.Core.sln` first

### MSBuild not found
- Ensure .NET SDK is properly installed
- The tool uses MSBuildLocator to find the appropriate MSBuild version