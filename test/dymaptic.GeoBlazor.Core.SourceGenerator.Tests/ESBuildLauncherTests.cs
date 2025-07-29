using dymaptic.GeoBlazor.Core.SourceGenerator.Tests.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;


namespace dymaptic.GeoBlazor.Core.SourceGenerator.Tests;

[TestClass]
public class ESBuildLauncherTests
{
    
    [TestMethod]
    public void TestCanTriggerESBuildInDebugMode()
    {
        string corePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "..", "..", "..", "..", "..", "src", "dymaptic.GeoBlazor.Core");
        
        var generator = new ESBuildLauncher();
        bool resultsReceived = false;
        generator.Notification += (_, message) =>
        {
            Console.WriteLine(message);
            resultsReceived = true;
        };
        
        // get actual Scripts files
        string scriptsPath = Path.Combine(corePath, "Scripts");
        IEnumerable<TestAdditionalFile> additionalTexts = Directory
            .GetFiles(scriptsPath, "*.ts")
            .Select(f => new TestAdditionalFile(f, File.ReadAllText(f)));
        
        CSharpParseOptions cSharpParseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp7_3);

        TestAnalyzerConfigOptionsProvider analyzerConfigOptions = new(new Dictionary<string, string>
        {
            { "build_property.MSBuildProjectDirectory", corePath }, 
            { "build_property.Configuration", "Debug" }
        });
        
        // Source generators should be tested using 'GeneratorDriver'.
        GeneratorDriver driver = CSharpGeneratorDriver
            .Create([generator.AsSourceGenerator()], additionalTexts, cSharpParseOptions, analyzerConfigOptions);
        
        // To run generators, we can use an empty compilation.
        var compilation = CSharpCompilation.Create(nameof(ESBuildLauncherTests));
        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out Compilation newCompilation, 
            out ImmutableArray<Diagnostic> _);
        
        Assert.IsTrue(resultsReceived);
        Assert.IsNotEmpty(newCompilation.SyntaxTrees);
        Assert.Contains("ESBuildRecord", newCompilation.SyntaxTrees.First().ToString());
        Assert.Contains("private const string Configuration = \"Debug\";", newCompilation.SyntaxTrees.First().ToString());
    }
    
    [TestMethod]
    public void TestCanTriggerESBuildInReleaseMode()
    {
        string corePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "..", "..", "..", "..", "..", "src", "dymaptic.GeoBlazor.Core");
        
        var generator = new ESBuildLauncher();
        
        // get actual Scripts files
        string scriptsPath = Path.Combine(corePath, "Scripts");
        IEnumerable<TestAdditionalFile> additionalTexts = Directory
            .GetFiles(scriptsPath, "*.ts")
            .Select(f => new TestAdditionalFile(f, File.ReadAllText(f)));
        
        CSharpParseOptions cSharpParseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp7_3);

        TestAnalyzerConfigOptionsProvider analyzerConfigOptions = new(new Dictionary<string, string>
        {
            { "build_property.MSBuildProjectDirectory", corePath }, 
            { "build_property.Configuration", "Release" }
        });
        
        // Source generators should be tested using 'GeneratorDriver'.
        GeneratorDriver driver = CSharpGeneratorDriver
            .Create([generator.AsSourceGenerator()], additionalTexts, cSharpParseOptions, analyzerConfigOptions);
        
        // To run generators, we can use an empty compilation.
        var compilation = CSharpCompilation.Create(nameof(ESBuildLauncherTests));
        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out Compilation newCompilation, 
            out ImmutableArray<Diagnostic> _);
        
        Assert.IsNotEmpty(newCompilation.SyntaxTrees);
        Assert.Contains("ESBuildRecord", newCompilation.SyntaxTrees.First().ToString());
        Assert.Contains("private const string Configuration = \"Release\";", newCompilation.SyntaxTrees.First().ToString());
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