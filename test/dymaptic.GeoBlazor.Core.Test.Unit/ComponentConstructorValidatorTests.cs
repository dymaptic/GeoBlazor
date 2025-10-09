using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Test.Unit;

[TestClass]
public class ComponentConstructorValidatorTests
{
    private const string TestComponentBase = @"
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace TestNamespace
{
    public abstract class MapComponent : ComponentBase
    {
        public bool AllowRender { get; set; }
        public virtual Task RegisterChildComponent(MapComponent child) => Task.CompletedTask;
    }
";

    [TestMethod]
    public async Task InvalidConstructor_MultipleWithoutAttribute_ShouldTriggerError()
    {
        var testCode = TestComponentBase + @"
    public class TestComponent : MapComponent
    {
        // Missing [ActivatorUtilitiesConstructor] - should trigger error
        public TestComponent() { }

        public TestComponent(string param)
        {
            AllowRender = false;
        }
    }
}";

        var diagnostics = await GetDiagnosticsAsync(testCode);

        Assert.IsTrue(diagnostics.Any(d => d.Id == "GeoBlazor_AUC"),
            "Expected GeoBlazor_AUC diagnostic for missing ActivatorUtilitiesConstructor attribute");
    }

    [TestMethod]
    public async Task ValidConstructor_WithAttribute_ShouldNotTriggerError()
    {
        var testCode = TestComponentBase + @"
    public class TestComponent : MapComponent
    {
        [ActivatorUtilitiesConstructor]
        public TestComponent() { }

        public TestComponent(string param)
        {
            AllowRender = false;
        }
    }
}";

        var diagnostics = await GetDiagnosticsAsync(testCode);

        Assert.IsFalse(diagnostics.Any(d => d.Id == "GeoBlazor_AUC"),
            "Should not trigger GeoBlazor_AUC when attribute is present");
    }

    [TestMethod]
    public async Task ValidConstructor_SingleParameterless_ShouldNotTriggerError()
    {
        var testCode = TestComponentBase + @"
    public class TestComponent : MapComponent
    {
        public TestComponent() { }
    }
}";

        var diagnostics = await GetDiagnosticsAsync(testCode);

        Assert.IsFalse(diagnostics.Any(d => d.Id == "GeoBlazor_AUC"),
            "Should not trigger error for single parameterless constructor");
    }

    [TestMethod]
    public async Task InvalidConstructor_OnlyParameterized_ShouldTriggerError()
    {
        var testCode = TestComponentBase + @"
    public class TestComponent : MapComponent
    {
        public TestComponent(string param1)
        {
            AllowRender = false;
        }

        public TestComponent(string param1, int param2)
        {
            AllowRender = false;
        }
    }
}";

        var diagnostics = await GetDiagnosticsAsync(testCode);

        Assert.IsTrue(diagnostics.Any(d => d.Id == "GeoBlazor_AUC"),
            "Should trigger error - needs a parameterless constructor for Razor usage");
    }

    [TestMethod]
    public async Task ValidConstructor_AbstractClass_ShouldNotTriggerError()
    {
        var testCode = TestComponentBase + @"
    public abstract class TestComponent : MapComponent
    {
        public TestComponent() { }

        public TestComponent(string param)
        {
            AllowRender = false;
        }
    }
}";

        var diagnostics = await GetDiagnosticsAsync(testCode);

        Assert.IsFalse(diagnostics.Any(d => d.Id == "GeoBlazor_AUC"),
            "Should not trigger error for abstract classes");
    }

    [TestMethod]
    public async Task InvalidConstructor_MultipleParameterlessNoAttribute_ShouldTriggerError()
    {
        var testCode = TestComponentBase + @"
    public class TestComponent : MapComponent
    {
        public TestComponent() { }

        public TestComponent(string param1)
        {
            AllowRender = false;
        }

        public TestComponent(string param1, int param2)
        {
            AllowRender = false;
        }
    }
}";

        var diagnostics = await GetDiagnosticsAsync(testCode);

        Assert.IsTrue(diagnostics.Any(d => d.Id == "GeoBlazor_AUC"),
            "Expected GeoBlazor_AUC diagnostic for multiple constructors without attribute");
    }

    [TestMethod]
    public async Task ValidConstructor_NonComponent_ShouldNotTriggerError()
    {
        var testCode = @"
using System;
using Microsoft.Extensions.DependencyInjection;

namespace TestNamespace
{
    public class RegularClass
    {
        public RegularClass() { }

        public RegularClass(string param) { }
    }
}";

        var diagnostics = await GetDiagnosticsAsync(testCode);

        Assert.IsFalse(diagnostics.Any(d => d.Id == "GeoBlazor_AUC"),
            "Should not trigger error for non-component classes");
    }

    private async Task<ImmutableArray<Diagnostic>> GetDiagnosticsAsync(string sourceCode)
    {
        // Load the analyzer assembly
        var analyzerAssemblyPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "..", "..", "..", "..", "..",
            "src", "dymaptic.GeoBlazor.Analyzers", "bin", "Debug", "netstandard2.0",
            "dymaptic.GeoBlazor.Analyzers.dll");

        if (!File.Exists(analyzerAssemblyPath))
        {
            Assert.Inconclusive($"Analyzer assembly not found at: {analyzerAssemblyPath}. Build the Analyzers project first.");
            return ImmutableArray<Diagnostic>.Empty;
        }

        var analyzerAssembly = Assembly.LoadFrom(analyzerAssemblyPath);
        var analyzerType = analyzerAssembly.GetTypes()
            .FirstOrDefault(t => t.Name == "ComponentConstructorValidator");

        if (analyzerType == null)
        {
            Assert.Inconclusive("ComponentConstructorValidator type not found in analyzer assembly");
            return ImmutableArray<Diagnostic>.Empty;
        }

        var analyzer = (DiagnosticAnalyzer)Activator.CreateInstance(analyzerType)!;

        // Create compilation
        var tree = CSharpSyntaxTree.ParseText(sourceCode);
        var compilation = CSharpCompilation.Create(
            "TestAssembly",
            new[] { tree },
            new[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Runtime.AssemblyTargetedPatchBandAttribute).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Microsoft.AspNetCore.Components.ComponentBase).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Microsoft.AspNetCore.Components.ParameterAttribute).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Microsoft.Extensions.DependencyInjection.ActivatorUtilitiesConstructorAttribute).Assembly.Location),
                MetadataReference.CreateFromFile(Assembly.Load("System.Runtime").Location),
                MetadataReference.CreateFromFile(Assembly.Load("netstandard").Location)
            },
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        // Run analyzer
        var compilationWithAnalyzers = compilation.WithAnalyzers(ImmutableArray.Create(analyzer));
        var diagnostics = await compilationWithAnalyzers.GetAnalyzerDiagnosticsAsync();

        return diagnostics;
    }
}