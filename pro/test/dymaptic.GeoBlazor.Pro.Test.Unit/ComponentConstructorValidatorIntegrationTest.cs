using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Pro.Components.Layers;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Immutable;
using System.Reflection;


namespace dymaptic.GeoBlazor.Pro.Test.Unit;

/// <summary>
///     Integration test to verify the ComponentConstructorValidator analyzer is properly
///     available to the Pro project through the shared Analyzers project.
///     Analyzer flow: dymaptic.GeoBlazor.Core.Analyzers -> Pro.SourceGenerator -> Pro
///     Note: Full analyzer tests are in Core.Test.Unit - this only validates integration.
/// </summary>
[TestClass]
public class ComponentConstructorValidatorIntegrationTest
{
    [TestMethod]
    public async Task AnalyzerIntegration_ShouldDetectMissingActivatorUtilitiesConstructor()
    {
        // Arrange
        string testCode = CreateTestComponent(false);

        // Act
        ImmutableArray<Diagnostic> diagnostics = await RunAnalyzerAsync(testCode);

        // Assert
        Assert.IsTrue(diagnostics.Any(d => d.Id == AnalyzerDiagnosticId),
            $"Expected {AnalyzerDiagnosticId} diagnostic was not triggered - analyzer integration failed.");
    }

    [TestMethod]
    public async Task AnalyzerIntegration_ShouldAcceptProperlyAttributedConstructor()
    {
        // Arrange
        string testCode = CreateTestComponent(true);

        // Act
        ImmutableArray<Diagnostic> diagnostics = await RunAnalyzerAsync(testCode);

        // Assert
        Assert.IsFalse(diagnostics.Any(d => d.Id == AnalyzerDiagnosticId),
            $"Analyzer should not trigger {AnalyzerDiagnosticId} when [ActivatorUtilitiesConstructor] is present");
    }

    // Asserts that deeper inheritance also triggers the analyzer
    [TestMethod]
    public async Task ProLayer_ShouldDetectMissingActivatorUtilitiesConstructor()
    {
        string testProLayerCode = """
                                  using dymaptic.GeoBlazor.Core.Enums;
                                  using dymaptic.GeoBlazor.Core.Interfaces;
                                  using dymaptic.GeoBlazor.Pro.Components.Layers;

                                  namespace dymaptic.GeoBlazor.Pro.Test.Unit;

                                  public class TestProLayer : ProLayer,
                                      IBlendLayer,
                                      IFeatureEffectLayer,
                                      IFeatureSetLayer,
                                      IFeatureTableWidgetLayers,
                                      IScaleRangeLayer
                                  {
                                      public TestProLayer() { }

                                      public TestProLayer(string param)
                                      {
                                      }

                                      public override LayerType Type => (LayerType)10000;
                                  }
                                  """;

        // Act
        ImmutableArray<Diagnostic> diagnostics = await RunAnalyzerAsync(testProLayerCode);

        // Assert
        Assert.IsTrue(diagnostics.Any(d => d.Id == AnalyzerDiagnosticId),
            $"Expected {AnalyzerDiagnosticId
            } diagnostic for ProLayer was not triggered - analyzer integration failed.");
    }

    private const string AnalyzerDiagnosticId = "GeoBlazor_AUC";
    private const string AnalyzerTypeName = "ComponentConstructorValidator";


#region Helper Methods

    private static string CreateTestComponent(bool withAttribute)
    {
        string attribute = withAttribute ? "[ActivatorUtilitiesConstructor]" : "";

        return $$"""
                 using System;
                 using System.Threading.Tasks;
                 using Microsoft.AspNetCore.Components;
                 using Microsoft.Extensions.DependencyInjection;

                 namespace TestNamespace;

                 public abstract class MapComponent : ComponentBase
                 {
                     public bool AllowRender { get; set; }
                     public virtual Task RegisterChildComponent(MapComponent child) => Task.CompletedTask;
                 }

                 public class TestComponent : MapComponent
                 {
                     {{attribute}}
                     public TestComponent() { }

                     public TestComponent(string param)
                     {
                         AllowRender = false;
                     }
                 }
                 """;
    }

    private async Task<ImmutableArray<Diagnostic>> RunAnalyzerAsync(string sourceCode)
    {
        DiagnosticAnalyzer analyzer = LoadAnalyzer();
        CSharpCompilation compilation = CreateCompilation(sourceCode);

        CompilationWithAnalyzers compilationWithAnalyzers = compilation.WithAnalyzers([analyzer]);

        return await compilationWithAnalyzers.GetAnalyzerDiagnosticsAsync();
    }

    private DiagnosticAnalyzer LoadAnalyzer()
    {
        Assembly analyzerAssembly = LoadAnalyzerAssembly();

        Type? analyzerType = analyzerAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == AnalyzerTypeName);

        if (analyzerType == null)
        {
            Assert.Inconclusive($"{AnalyzerTypeName} not found in analyzer assembly.");
        }

        return (DiagnosticAnalyzer)Activator.CreateInstance(analyzerType)!;
    }

    private Assembly LoadAnalyzerAssembly()
    {
        string[] possiblePaths = GetAnalyzerAssemblyPaths();

        string? existingPath = possiblePaths.FirstOrDefault(File.Exists);

        if (existingPath == null)
        {
            Assert.Inconclusive($"Analyzer assembly not found.\nSearched:\n{string.Join("\n", possiblePaths)}");
        }

        return Assembly.LoadFrom(existingPath);
    }

    private string[] GetAnalyzerAssemblyPaths()
    {
        string testAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        string repoRoot = Path.GetFullPath(Path.Combine(testAssemblyLocation, "..", "..", "..", "..", ".."));
#if DEBUG
        var config = "Debug";
#else
        string config = "Release";
#endif

        return
        [
            // dymaptic.GeoBlazor.Core.Analyzers (where ComponentConstructorValidator now lives)
            // repoRoot is the pro/ folder; Core lives one level up, at the repository root
            Path.Combine(repoRoot, "..", "src", "dymaptic.GeoBlazor.Core.Analyzers",
                "bin", config, "netstandard2.0", "dymaptic.GeoBlazor.Core.Analyzers.dll")
        ];
    }

    private static CSharpCompilation CreateCompilation(string sourceCode)
    {
        SyntaxTree tree = CSharpSyntaxTree.ParseText(sourceCode);

        PortableExecutableReference[] references = new[]
            {
                typeof(object).Assembly, // System.Runtime
                typeof(Console).Assembly, // System.Console
                typeof(ComponentBase).Assembly, // Microsoft.AspNetCore.Components
                typeof(ActivatorUtilitiesConstructorAttribute).Assembly, // Microsoft.Extensions.DependencyInjection
                Assembly.Load("System.Runtime"), Assembly.Load("netstandard"),
                typeof(Layer).Assembly, // dymaptic.GeoBlazor.Core
                typeof(ProLayer).Assembly // dymaptic.GeoBlazor.Pro
            }
            .Select(a => MetadataReference.CreateFromFile(a.Location))
            .ToArray();

        return CSharpCompilation.Create("TestAssembly",
            [tree],
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    }

#endregion
}