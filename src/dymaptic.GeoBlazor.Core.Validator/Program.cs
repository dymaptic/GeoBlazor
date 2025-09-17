using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
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
    MSBuildLocator.RegisterDefaults();

    var violations = await AnalyzeProject(geoBlazorProjectPath);

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

    var allTypes = compilation.GetSymbolsWithName(_ => true, SymbolFilter.Type)
        .OfType<INamedTypeSymbol>()
        .Where(t => t != null && t.TypeKind == TypeKind.Class)
        .ToList();

    Console.WriteLine($"{Environment.NewLine}Found {allTypes.Count} classes to analyze.");

    var projectDir = Path.GetDirectoryName(projectPath);
    var checkedClasses = 0;

    foreach (var classSymbol in allTypes)
    {
        checkedClasses++;
        if (checkedClasses % 100 == 0)
        {
            Console.WriteLine($"Progress: {checkedClasses}/{allTypes.Count} classes checked...");
        }

        if (HasViolation(classSymbol))
        {
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

            if (filePaths.Count > 0)
            {
                violations.Add(new Violation(classSymbol.Name, filePaths));
            }
            else
            {
                Console.WriteLine($"Warning: Class {classSymbol.Name} has a violation but no source file paths found.");
            }
        }
    }

    var syntaxTrees = compilation.SyntaxTrees.ToList();
    var gbFiles = syntaxTrees.Count(t => t.FilePath != null && t.FilePath.EndsWith(".gb.cs"));
    var regularCs = syntaxTrees.Count(t => t.FilePath != null && t.FilePath.EndsWith(".cs") && !t.FilePath.EndsWith(".gb.cs"));
    Console.WriteLine($"{Environment.NewLine}Analyzed {allTypes.Count} classes from {syntaxTrees.Count} files ({regularCs} .cs, {gbFiles} .gb.cs).");

    return violations;
}

bool HasViolation(INamedTypeSymbol classSymbol)
{
    if (!InheritsFromComponentBase(classSymbol)) return false;

    var constructors = classSymbol.Constructors
        .Where(c => !c.IsImplicitlyDeclared && c.DeclaredAccessibility == Accessibility.Public)
        .ToList();

    if (constructors.All(c => c.Parameters.Length == 0))
    {
        return false;
    }

    var parameterlessConstructors = constructors.Where(c => c.Parameters.Length == 0).ToList();

    if (parameterlessConstructors.Count > 0 &&
        parameterlessConstructors.Any(HasActivatorUtilitiesConstructorAttribute))
    {
        return false;
    }

    return parameterlessConstructors.Count > 0;
}

bool InheritsFromComponentBase(INamedTypeSymbol classSymbol)
{
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
            return true;
        }

        if (typeName == "ComponentBase")
        {
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

record Violation(string ClassName, List<string> FilePaths);