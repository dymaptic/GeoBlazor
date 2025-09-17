using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

const string SUCCESS_MESSAGE = "All classes with 2+ constructors have a parameterless constructor using the [ActivatorUtilitiesConstructor] attribute.";
const string FAILURE_MESSAGE = "The following classes contain 2+ constructors, but do not have a parameterless constructor that correctly uses the [ActivatorUtilitiesConstructor] attribute. Please update the following list of the class names:";
const int CONSOLE_OUTPUT_PADDING = 60;

// Define a record for violations instead of tuple
record Violation(string ClassName, string FilePath);

if (args.Length == 0)
{
    Console.WriteLine("Usage: dymaptic.GeoBlazor.Core.Validator <path-to-project-file>");
    return 1;
}

var projectPath = args[0];

if (!File.Exists(projectPath))
{
    Console.WriteLine($"Project file not found: {projectPath}");
    return 1;
}

try
{
    // Initialize MSBuild for Roslyn workspace
    MSBuildLocator.RegisterDefaults();

    // Analyze the project
    var violations = await AnalyzeProject(projectPath);

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

    Console.WriteLine($"Analyzing {project.Name}...");

    var violations = new List<Violation>();
    var compilation = await project.GetCompilationAsync();

    if (compilation == null)
    {
        Console.WriteLine("Failed to get compilation for project.");
        return violations;
    }

    var syntaxTrees = compilation.SyntaxTrees.ToList();
    var fileCount = syntaxTrees.Count;
    var currentFile = 0;

    foreach (var syntaxTree in syntaxTrees)
    {
        currentFile++;
        var fileName = Path.GetFileName(syntaxTree.FilePath);

        // Show progress using Environment.NewLine
        Console.WriteLine($"{Environment.NewLine}Analyzing file {currentFile}/{fileCount}: {fileName}");

        var classViolations = await AnalyzeSyntaxTree(syntaxTree, compilation, projectPath);
        violations.AddRange(classViolations);
    }

    Console.WriteLine($"{Environment.NewLine}Analyzed {fileCount} files.");

    return violations;
}

async Task<List<Violation>> AnalyzeSyntaxTree(
    SyntaxTree syntaxTree,
    Compilation compilation,
    string projectPath)
{
    var violations = new List<Violation>();
    var semanticModel = compilation.GetSemanticModel(syntaxTree);
    var root = await syntaxTree.GetRootAsync();

    // Find all class declarations in this file
    var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

    foreach (var classDeclaration in classDeclarations)
    {
        var violation = AnalyzeClass(classDeclaration, semanticModel, syntaxTree.FilePath, projectPath);
        if (violation != null)
        {
            violations.Add(violation);
        }
    }

    return violations;
}

Violation? AnalyzeClass(
    ClassDeclarationSyntax classDeclaration,
    SemanticModel semanticModel,
    string filePath,
    string projectPath)
{
    var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration);
    if (classSymbol == null) return null;

    // Skip classes that don't inherit from ComponentBase
    if (!InheritsFromComponentBase(classSymbol)) return null;

    // Get public constructors (excluding compiler-generated ones)
    var constructors = classSymbol.Constructors
        .Where(c => !c.IsImplicitlyDeclared && c.DeclaredAccessibility == Accessibility.Public)
        .ToList();

    // Skip classes with less than 2 constructors (we only check classes with 2 or more)
    if (constructors.Count < 2) return null;

    // Check if any constructor has the ActivatorUtilitiesConstructor attribute
    var hasAttributedConstructor = constructors.Any(HasActivatorUtilitiesConstructorAttribute);

    // If there's an attributed constructor, check if it's parameterless
    if (hasAttributedConstructor)
    {
        var attributedConstructor = constructors.First(HasActivatorUtilitiesConstructorAttribute);
        if (attributedConstructor.Parameters.Length == 0)
        {
            // Compliant: has a parameterless constructor with the attribute
            return null;
        }
    }

    // Non-compliant: either no attributed constructor or attributed constructor has parameters
    var projectDir = Path.GetDirectoryName(projectPath);
    var relativePath = projectDir != null
        ? Path.GetRelativePath(projectDir, filePath)
        : filePath;

    return new Violation(classSymbol.Name, relativePath);
}

bool InheritsFromComponentBase(INamedTypeSymbol classSymbol)
{
    var baseType = classSymbol.BaseType;

    while (baseType != null)
    {
        var typeName = baseType.Name;

        // Check for MapComponent first (most common in this codebase)
        if (typeName == "MapComponent")
        {
            return true;
        }

        // Check for ComponentBase (base class of MapComponent and other Blazor components)
        if (typeName == "ComponentBase")
        {
            return true;
        }

        baseType = baseType.BaseType;
    }

    return false;
}

bool HasActivatorUtilitiesConstructorAttribute(IMethodSymbol constructor)
{
    return constructor.GetAttributes().Any(attr =>
        attr.AttributeClass?.Name == "ActivatorUtilitiesConstructor");
}

int ReportResults(List<Violation> violations)
{
    if (violations.Count == 0)
    {
        Console.WriteLine($"{Environment.NewLine}{SUCCESS_MESSAGE}");
        return 0;
    }

    Console.WriteLine($"{Environment.NewLine}{FAILURE_MESSAGE}");
    foreach (var violation in violations)
    {
        Console.WriteLine($"- {violation.ClassName} - {violation.FilePath}");
    }
    return 1;
}