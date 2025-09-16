using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

namespace dymaptic.GeoBlazor.Core.Test.ConstructorTesting;

class Program
{
    static async Task<int> Main(string[] args)
    {
        // Register MSBuild
        MSBuildLocator.RegisterDefaults();

        // Find the solution file
        var currentDirectory = Directory.GetCurrentDirectory();
        var solutionPath = FindSolutionFile(currentDirectory);

        if (string.IsNullOrEmpty(solutionPath))
        {
            Console.WriteLine("Could not find solution file (.sln) in the repository.");
            return 1;
        }

        using var workspace = MSBuildWorkspace.Create();
        var solution = await workspace.OpenSolutionAsync(solutionPath);

        var nonCompliantClasses = new List<(string className, string filePath)>();

        foreach (var project in solution.Projects)
        {
            var compilation = await project.GetCompilationAsync();
            if (compilation == null) continue;

            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var semanticModel = compilation.GetSemanticModel(syntaxTree);
                var root = await syntaxTree.GetRootAsync();

                // Find all class declarations
                var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

                foreach (var classDeclaration in classDeclarations)
                {
                    var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration);
                    if (classSymbol == null) continue;

                    // Check if the class inherits from ComponentBase
                    if (!InheritsFromComponentBase(classSymbol)) continue;

                    // Get all constructors
                    var constructors = classSymbol.Constructors
                        .Where(c => !c.IsImplicitlyDeclared && c.DeclaredAccessibility == Accessibility.Public)
                        .ToList();

                    // Check if class has 2 or more constructors
                    if (constructors.Count >= 2)
                    {
                        // Check if there's a parameterless constructor with [ActivatorUtilitiesConstructor]
                        var hasCompliantParameterlessConstructor = constructors.Any(c =>
                            c.Parameters.Length == 0 &&
                            HasActivatorUtilitiesConstructorAttribute(c));

                        if (!hasCompliantParameterlessConstructor)
                        {
                            var filePath = syntaxTree.FilePath;
                            var relativePath = Path.GetRelativePath(Path.GetDirectoryName(solutionPath)!, filePath);
                            nonCompliantClasses.Add((classSymbol.Name, relativePath));
                        }
                    }
                }
            }
        }

        // Output results
        if (nonCompliantClasses.Count == 0)
        {
            Console.WriteLine("All classes with 2+ constructors have a parameterless constructor using the [ActivatorUtilitiesConstructor] attribute.");
            return 0;
        }
        else
        {
            Console.WriteLine("The following classes contain 2+ constructors, but do not have a parameterless constructor that correctly uses the [ActivatorUtilitiesConstructor] attribute. Please update the following list of the class names:");
            foreach (var (className, filePath) in nonCompliantClasses)
            {
                Console.WriteLine($"- {className} - {filePath}");
            }
            return 1;
        }
    }

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

    static bool InheritsFromComponentBase(INamedTypeSymbol classSymbol)
    {
        var baseType = classSymbol.BaseType;

        while (baseType != null)
        {
            // Check for ComponentBase (could be in Microsoft.AspNetCore.Components namespace)
            if (baseType.Name == "ComponentBase" ||
                baseType.ToString()?.Contains("ComponentBase") == true)
            {
                return true;
            }

            // Also check for MapComponent which likely inherits from ComponentBase
            if (baseType.Name == "MapComponent" ||
                baseType.ToString()?.Contains("MapComponent") == true)
            {
                return true;
            }

            baseType = baseType.BaseType;
        }

        return false;
    }

    static bool HasActivatorUtilitiesConstructorAttribute(IMethodSymbol constructor)
    {
        return constructor.GetAttributes().Any(attr =>
            attr.AttributeClass?.Name == "ActivatorUtilitiesConstructorAttribute" ||
            attr.AttributeClass?.Name == "ActivatorUtilitiesConstructor");
    }
}