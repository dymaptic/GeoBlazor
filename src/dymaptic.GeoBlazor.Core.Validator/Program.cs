using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

const string SUCCESS_MESSAGE = "All classes with 2+ constructors have a parameterless constructor using the [ActivatorUtilitiesConstructor] attribute.";
const string FAILURE_MESSAGE = "The following classes contain 2+ constructors, but do not have a parameterless constructor that correctly uses the [ActivatorUtilitiesConstructor] attribute. Please update the following list of the class names:";

string? geoBlazorProjectPath = args.Length > 0 ? args[0] : null;

if (geoBlazorProjectPath is null)
{
    throw new Exception("Must pass in the path to the GeoBlazor project to Validate");
}

if (!File.Exists(geoBlazorProjectPath))
{
    Console.WriteLine($"Project file not found: {geoBlazorProjectPath}");
    return 1;
}

try
{
    // Initialize MSBuild for Roslyn workspace
    MSBuildLocator.RegisterDefaults();

    // Analyze the project
    var violations = await AnalyzeProject(geoBlazorProjectPath);

    // Report results
    return ReportResults(violations);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    return 1;
}

async Task<List<Violation>> AnalyzeProject(string projectPath)
{
    using var workspace = MSBuildWorkspace.Create();

    Console.WriteLine($"Loading project: {projectPath}");
    var project = await workspace.OpenProjectAsync(projectPath);

    if (project == null)
    {
        Console.WriteLine($"Failed to load project: {projectPath}");
        return new List<Violation>();
    }

    Console.WriteLine($"Analyzing {project.Name}...");

    var violations = new List<Violation>();
    var compilation = await project.GetCompilationAsync();

    if (compilation == null)
    {
        Console.WriteLine("Failed to get compilation for project.");
        return violations;
    }

    // Get all types from compilation - Roslyn has already merged partial classes
    var allTypes = compilation.GetSymbolsWithName(_ => true, SymbolFilter.Type)
        .OfType<INamedTypeSymbol>()
        .Where(t => t != null && t.TypeKind == TypeKind.Class)
        .ToList();

    Console.WriteLine($"{Environment.NewLine}Found {allTypes.Count} classes to analyze.");

    var projectDir = Path.GetDirectoryName(projectPath);
    var checkedClasses = 0;

    foreach (var classSymbol in allTypes)
    {
        // Skip null symbols (shouldn't happen but let's be safe)
        if (classSymbol == null) continue;

        checkedClasses++;
        if (checkedClasses % 100 == 0)
        {
            Console.WriteLine($"Progress: {checkedClasses}/{allTypes.Count} classes checked...");
        }

        // Check if this class has a violation
        if (HasViolation(classSymbol))
        {
            // Get all file paths for this class (handles partial classes)
            var filePaths = classSymbol.Locations
                .Where(loc => loc.IsInSource && loc.SourceTree?.FilePath != null)
                .Select(loc =>
                {
                    var filePath = loc.SourceTree!.FilePath;
                    return projectDir != null
                        ? Path.GetRelativePath(projectDir, filePath)
                        : filePath;
                })
                .Where(path => !string.IsNullOrEmpty(path))
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            // Only add violation if we have at least one valid file path
            if (filePaths.Count > 0)
            {
                violations.Add(new Violation(classSymbol.Name, filePaths));
            }
            else
            {
                // This shouldn't happen for source code, but log it
                Console.WriteLine($"Warning: Class {classSymbol.Name} has a violation but no source file paths found.");
            }
        }
    }

    // Summary
    var syntaxTrees = compilation.SyntaxTrees.ToList();
    var gbFiles = syntaxTrees.Count(t => t.FilePath != null && t.FilePath.EndsWith(".gb.cs"));
    var regularCs = syntaxTrees.Count(t => t.FilePath != null && t.FilePath.EndsWith(".cs") && !t.FilePath.EndsWith(".gb.cs"));
    Console.WriteLine($"{Environment.NewLine}Analyzed {allTypes.Count} classes from {syntaxTrees.Count} files ({regularCs} .cs, {gbFiles} .gb.cs).");

    return violations;
}

bool HasViolation(INamedTypeSymbol classSymbol)
{
    // Skip classes that don't inherit from ComponentBase
    if (!InheritsFromComponentBase(classSymbol)) return false;

    // Get public constructors (excluding compiler-generated ones)
    var constructors = classSymbol.Constructors
        .Where(c => !c.IsImplicitlyDeclared && c.DeclaredAccessibility == Accessibility.Public)
        .ToList();

    // If all constructors are parameterless, we don't need the attribute
    if (constructors.All(c => c.Parameters.Length == 0))
    {
        return false;
    }

    var parameterlessConstructors = constructors.Where(c => c.Parameters.Length == 0).ToList();

    if (parameterlessConstructors.Count > 0 &&
        parameterlessConstructors.Any(HasActivatorUtilitiesConstructorAttribute))
    {
        // Compliant: parameterless constructor has the attribute
        return false;
    }

    // Only report violation if there IS a parameterless constructor without the attribute
    return parameterlessConstructors.Count > 0;
}

bool InheritsFromComponentBase(INamedTypeSymbol classSymbol)
{
    // Skip MapComponent itself
    if (classSymbol.Name == "MapComponent")
    {
        return false;
    }

    var baseType = classSymbol.BaseType;

    while (baseType != null)
    {
        var typeName = baseType.Name;

        if (typeName == "MapComponent")
        {
            // This class inherits from MapComponent - validate it
            return true;
        }

        if (typeName == "ComponentBase")
        {
            // This class inherits directly from ComponentBase (not via MapComponent) - error
            throw new Exception($"Class {classSymbol.Name} inherits directly from ComponentBase instead of MapComponent. All GeoBlazor components must inherit from MapComponent.");
        }

        baseType = baseType.BaseType;
    }

    return false;
}

bool HasActivatorUtilitiesConstructorAttribute(IMethodSymbol constructor)
{
    return constructor?.GetAttributes().Any(attr =>
        attr.AttributeClass?.Name == "ActivatorUtilitiesConstructorAttribute") ?? false;
}

int ReportResults(List<Violation>? violations)
{
    if (violations == null || violations.Count == 0)
    {
        Console.WriteLine($"{Environment.NewLine}{SUCCESS_MESSAGE}");
        return 0;
    }

    Console.WriteLine($"{Environment.NewLine}{FAILURE_MESSAGE}");
    foreach (var violation in violations)
    {
        Console.WriteLine($"- {violation.ClassName}");
        foreach (var filePath in violation.FilePaths)
        {
            Console.WriteLine($"    {filePath}");
        }
    }
    return 1;
}

// Define a record for violations
record Violation(string ClassName, List<string> FilePaths);