using dymaptic.GeoBlazor.Core.SourceGenerator.Tests.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;


namespace dymaptic.GeoBlazor.Core.SourceGenerator.Tests;

public class ESBuildLauncherTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ESBuildLauncherTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void TestCanTriggerESBuildForCore()
    {
        string corePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "..", "..", "..", "..", "..", "src", "dymaptic.GeoBlazor.Core");
        
        var generator = new ESBuildLauncher();
        
        // Source generators should be tested using 'GeneratorDriver'.
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator).WithUpdatedAnalyzerConfigOptions(
            new TestAnalyzerConfigOptionsProvider(new Dictionary<string, string>
            {
                {"build_property.MSBuildProjectDirectory", corePath}
            }));
        
        // get actual Scripts files
        string scriptsPath = Path.Combine(corePath, "Scripts");
        
        foreach (string file in Directory.GetFiles(scriptsPath, "*.ts"))
        {
            // Add the additional file separately from the compilation.
            driver = driver.AddAdditionalTexts([new TestAdditionalFile(file, File.ReadAllText(file))]);
        }
        
        // To run generators, we can use an empty compilation.
        var compilation = CSharpCompilation.Create(nameof(ESBuildLauncherTests));
        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out Compilation newCompilation, 
            out ImmutableArray<Diagnostic> diagnostics);
        
        // Check for diagnostics.
        if (diagnostics.Length > 0)
        {
            foreach (Diagnostic diagnostic in diagnostics)
            {
                _testOutputHelper.WriteLine(diagnostic.ToString());
            }
        }
        
        Assert.True(diagnostics.All(d => d.Severity == DiagnosticSeverity.Info));
        
        _testOutputHelper.WriteLine("Generated code:");
        _testOutputHelper.WriteLine(newCompilation.SyntaxTrees.First().ToString());
    }
    
    [Fact]
    public void TestCanTriggerESBuildForCoreInReleaseMode()
    {
        string corePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "..", "..", "..", "..", "..", "src", "dymaptic.GeoBlazor.Core");
        
        var generator = new ESBuildLauncher();
        
        // Source generators should be tested using 'GeneratorDriver'.
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator).WithUpdatedAnalyzerConfigOptions(
            new TestAnalyzerConfigOptionsProvider(new Dictionary<string, string>()
            {
                {"build_property.MSBuildProjectDirectory", corePath},
                {"build_property.Configuration", "Release"}
            }));
        
        // get actual Scripts files
        string scriptsPath = Path.Combine(corePath, "Scripts");
        
        foreach (string file in Directory.GetFiles(scriptsPath, "*.ts"))
        {
            // Add the additional file separately from the compilation.
            driver = driver.AddAdditionalTexts([new TestAdditionalFile(file, File.ReadAllText(file))]);
        }
        
        // To run generators, we can use an empty compilation.
        var compilation = CSharpCompilation.Create(nameof(ESBuildLauncherTests));
        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out Compilation newCompilation, 
            out ImmutableArray<Diagnostic> diagnostics);
        
        // Check for diagnostics.
        if (diagnostics.Length > 0)
        {
            foreach (Diagnostic diagnostic in diagnostics)
            {
                _testOutputHelper.WriteLine(diagnostic.ToString());
            }
        }
        
        Assert.True(diagnostics.All(d => d.Severity == DiagnosticSeverity.Info));
        
        _testOutputHelper.WriteLine("Generated code:");
        _testOutputHelper.WriteLine(newCompilation.SyntaxTrees.First().ToString());
    }
    
    [Fact]
    public void TestCanTriggerESBuildForPro()
    {
        string proPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "..", "..", "..", "..", "..", "..", "src", "dymaptic.GeoBlazor.Pro");
        
        var generator = new ESBuildLauncher();
        
        // Source generators should be tested using 'GeneratorDriver'.
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator).WithUpdatedAnalyzerConfigOptions(
            new TestAnalyzerConfigOptionsProvider(new Dictionary<string, string>()
            {
                {"build_property.MSBuildProjectDirectory", proPath}
            }));
        
        // get actual Scripts files
        string scriptsPath = Path.Combine(proPath, "Scripts");
        
        foreach (string file in Directory.GetFiles(scriptsPath, "*.ts"))
        {
            // Add the additional file separately from the compilation.
            driver = driver.AddAdditionalTexts([new TestAdditionalFile(file, File.ReadAllText(file))]);
        }
        
        // To run generators, we can use an empty compilation.
        var compilation = CSharpCompilation.Create(nameof(ESBuildLauncherTests));
        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out Compilation newCompilation, 
            out ImmutableArray<Diagnostic> diagnostics);
        
        // Check for diagnostics.
        if (diagnostics.Length > 0)
        {
            foreach (Diagnostic diagnostic in diagnostics)
            {
                _testOutputHelper.WriteLine(diagnostic.ToString());
            }
        }
        
        Assert.True(diagnostics.All(d => d.Severity == DiagnosticSeverity.Info));
        
        _testOutputHelper.WriteLine("Generated code:");
        _testOutputHelper.WriteLine(newCompilation.SyntaxTrees.First().ToString());
    }
    
    [Fact]
    public void TestCanTriggerESBuildForProInReleaseMode()
    {
        string proPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "..", "..", "..", "..", "..", "..", "src", "dymaptic.GeoBlazor.Pro");
        
        var generator = new ESBuildLauncher();
        
        // Source generators should be tested using 'GeneratorDriver'.
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator).WithUpdatedAnalyzerConfigOptions(
            new TestAnalyzerConfigOptionsProvider(new Dictionary<string, string>()
            {
                {"build_property.MSBuildProjectDirectory", proPath},
                {"build_property.Configuration", "Release"}
            }));
        
        // get actual Scripts files
        string scriptsPath = Path.Combine(proPath, "Scripts");
        
        foreach (string file in Directory.GetFiles(scriptsPath, "*.ts"))
        {
            // Add the additional file separately from the compilation.
            driver = driver.AddAdditionalTexts([new TestAdditionalFile(file, File.ReadAllText(file))]);
        }
        
        // To run generators, we can use an empty compilation.
        var compilation = CSharpCompilation.Create(nameof(ESBuildLauncherTests));
        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out Compilation newCompilation, 
            out ImmutableArray<Diagnostic> diagnostics);
        
        // Check for diagnostics.
        if (diagnostics.Length > 0)
        {
            foreach (Diagnostic diagnostic in diagnostics)
            {
                _testOutputHelper.WriteLine(diagnostic.ToString());
            }
        }
        
        Assert.True(diagnostics.All(d => d.Severity == DiagnosticSeverity.Info));
        
        _testOutputHelper.WriteLine("Generated code:");
        _testOutputHelper.WriteLine(newCompilation.SyntaxTrees.First().ToString());
    }
}

public class TestAnalyzerConfigOptionsProvider(Dictionary<string, string> options) 
    : AnalyzerConfigOptionsProvider
{
    public override AnalyzerConfigOptions GetOptions(SyntaxTree tree)
    {
        return GlobalOptions;
    }

    public override AnalyzerConfigOptions GetOptions(AdditionalText textFile)
    {
        return GlobalOptions;
    }

    public override AnalyzerConfigOptions GlobalOptions { get; } = new TestAnalyzerConfigOptions(options);
}

public class TestAnalyzerConfigOptions(Dictionary<string, string> options) 
    : AnalyzerConfigOptions
{
    public override bool TryGetValue(string key, [NotNullWhen(true)] [UnscopedRef] out string? value)
    {
        if (options.TryGetValue(key, out string? optionValue))
        {
            value = optionValue;
            return true;
        }

        value = null;
        return false;
    }
}