using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

namespace dymaptic.GeoBlazor.Core.Test.ConstructorTesting;

/// <summary>
/// Console application that validates ComponentBase-derived classes have proper constructor attributes.
/// </summary>
class Program
{
    private const string SUCCESS_MESSAGE = "All classes with 2+ constructors have a parameterless constructor using the [ActivatorUtilitiesConstructor] attribute.";
    private const string FAILURE_MESSAGE = "The following classes contain 2+ constructors, but do not have a parameterless constructor that correctly uses the [ActivatorUtilitiesConstructor] attribute. Please update the following list of the class names:";

    static async Task<int> Main(string[] args)
    {
        try
        {
            // Initialize MSBuild for Roslyn workspace
            MSBuildLocator.RegisterDefaults();

            // Locate and load the solution
            var solutionPath = FindSolutionFile(Directory.GetCurrentDirectory());
            if (string.IsNullOrEmpty(solutionPath))
            {
                Console.WriteLine("Could not find solution file (.sln) in the repository.");
                return 1;
            }

            // Analyze all projects in the solution
            var nonCompliantClasses = await AnalyzeSolution(solutionPath);

            // Report results
            return ReportResults(nonCompliantClasses);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return 1;
        }
    }

    /// <summary>
    /// Analyzes only the Core project for constructor compliance.
    /// </summary>
    static async Task<List<(string className, string filePath)>> AnalyzeSolution(string solutionPath)
    {
        using var workspace = MSBuildWorkspace.Create();

        // Load only the Core project instead of entire solution
        var projectPath = Path.Combine(Path.GetDirectoryName(solutionPath)!, "dymaptic.GeoBlazor.Core", "dymaptic.GeoBlazor.Core.csproj");

        if (!File.Exists(projectPath))
        {
            Console.WriteLine($"Could not find Core project at: {projectPath}");
            return new List<(string className, string filePath)>();
        }

        Console.WriteLine("Loading dymaptic.GeoBlazor.Core project...");
        var project = await workspace.OpenProjectAsync(projectPath);

        Console.WriteLine($"Analyzing {project.Name}...");
        var projectViolations = await AnalyzeProject(project, solutionPath);

        return projectViolations;
    }

    /// <summary>
    /// Analyzes a single project for constructor compliance.
    /// </summary>
    static async Task<List<(string className, string filePath)>> AnalyzeProject(Project project, string solutionPath)
    {
        var violations = new List<(string className, string filePath)>();
        var compilation = await project.GetCompilationAsync();
        if (compilation == null) return violations;

        var syntaxTrees = compilation.SyntaxTrees.ToList();
        var fileCount = syntaxTrees.Count;
        var currentFile = 0;

        foreach (var syntaxTree in syntaxTrees)
        {
            currentFile++;
            var fileName = Path.GetFileName(syntaxTree.FilePath);

            // Show progress - using carriage return to overwrite the same line
            Console.Write($"\rAnalyzing file {currentFile}/{fileCount}: {fileName,-50}");

            var classViolations = await AnalyzeSyntaxTree(syntaxTree, compilation, solutionPath);
            violations.AddRange(classViolations);
        }

        // Clear the progress line and move to next line
        Console.WriteLine($"\rAnalyzed {fileCount} files.{new string(' ', 60)}");

        return violations;
    }

    /// <summary>
    /// Analyzes a single syntax tree (file) for constructor compliance.
    /// </summary>
    static async Task<List<(string className, string filePath)>> AnalyzeSyntaxTree(
        SyntaxTree syntaxTree,
        Compilation compilation,
        string solutionPath)
    {
        var violations = new List<(string className, string filePath)>();
        var semanticModel = compilation.GetSemanticModel(syntaxTree);
        var root = await syntaxTree.GetRootAsync();

        // Find all class declarations in this file
        var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

        foreach (var classDeclaration in classDeclarations)
        {
            var violation = AnalyzeClass(classDeclaration, semanticModel, syntaxTree.FilePath, solutionPath);
            if (violation.HasValue)
            {
                violations.Add(violation.Value);
            }
        }

        return violations;
    }

    /// <summary>
    /// Analyzes a single class for constructor compliance.
    /// Returns violation info if non-compliant, null otherwise.
    /// </summary>
    static (string className, string filePath)? AnalyzeClass(
        ClassDeclarationSyntax classDeclaration,
        SemanticModel semanticModel,
        string filePath,
        string solutionPath)
    {
        var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration);
        if (classSymbol == null) return null;

        // Skip classes that don't inherit from ComponentBase
        if (!InheritsFromComponentBase(classSymbol)) return null;

        // Get public constructors (excluding compiler-generated ones)
        var constructors = classSymbol.Constructors
            .Where(c => !c.IsImplicitlyDeclared && c.DeclaredAccessibility == Accessibility.Public)
            .ToList();

        // Only check classes with 2 or more constructors
        if (constructors.Count < 2) return null;

        // Check for compliant parameterless constructor
        var hasCompliantParameterlessConstructor = constructors.Any(IsCompliantParameterlessConstructor);

        if (!hasCompliantParameterlessConstructor)
        {
            var relativePath = Path.GetRelativePath(Path.GetDirectoryName(solutionPath)!, filePath);
            return (classSymbol.Name, relativePath);
        }

        return null;
    }

    /// <summary>
    /// Checks if a constructor is parameterless and has the required attribute.
    /// </summary>
    static bool IsCompliantParameterlessConstructor(IMethodSymbol constructor)
    {
        return constructor.Parameters.Length == 0 &&
               HasActivatorUtilitiesConstructorAttribute(constructor);
    }

    /// <summary>
    /// Reports the analysis results to the console.
    /// </summary>
    static int ReportResults(List<(string className, string filePath)> nonCompliantClasses)
    {
        if (nonCompliantClasses.Count == 0)
        {
            Console.WriteLine(SUCCESS_MESSAGE);
            return 0;
        }

        Console.WriteLine(FAILURE_MESSAGE);
        foreach (var (className, filePath) in nonCompliantClasses)
        {
            Console.WriteLine($"- {className} - {filePath}");
        }
        return 1;
    }

    /// <summary>
    /// Finds the solution file by traversing up from the current directory.
    /// </summary>
    static string FindSolutionFile(string startDirectory)
    {
        var directory = new DirectoryInfo(startDirectory);

        while (directory != null)
        {
            // Look for the specific solution file
            var solutionFile = Path.Combine(directory.FullName, "src", "dymaptic.GeoBlazor.Core.sln");
            if (File.Exists(solutionFile))
            {
                return solutionFile;
            }

            // Move up one directory
            directory = directory.Parent;
        }

        return string.Empty;
    }

    /// <summary>
    /// Checks if a class inherits from ComponentBase (directly or through MapComponent).
    /// Most GeoBlazor components inherit from MapComponent, which inherits from ComponentBase.
    /// </summary>
    static bool InheritsFromComponentBase(INamedTypeSymbol classSymbol)
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

    /// <summary>
    /// Checks if a constructor has the [ActivatorUtilitiesConstructor] attribute.
    /// </summary>
    static bool HasActivatorUtilitiesConstructorAttribute(IMethodSymbol constructor)
    {
        return constructor.GetAttributes().Any(attr =>
            attr.AttributeClass?.Name == "ActivatorUtilitiesConstructorAttribute" ||
            attr.AttributeClass?.Name == "ActivatorUtilitiesConstructor");
    }
}