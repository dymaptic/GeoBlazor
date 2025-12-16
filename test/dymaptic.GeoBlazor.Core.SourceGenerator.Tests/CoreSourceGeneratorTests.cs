using dymaptic.GeoBlazor.Core.SourceGenerator.Tests.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using ProtoBuf;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;


namespace dymaptic.GeoBlazor.Core.SourceGenerator.Tests;

[TestClass]
public class CoreSourceGeneratorTests
{
    [TestMethod]
    public void TestCanTriggerESBuildInDebugMode()
    {
        var corePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "..", "..", "..", "..", "..", "src", "dymaptic.GeoBlazor.Core");

        var generator = new ProtobufSourceGenerator();

        // get actual Scripts files
        var scriptsPath = Path.Combine(corePath, "Scripts");

        var additionalTexts = Directory
            .GetFiles(scriptsPath, "*.ts")
            .Select(f => new TestAdditionalFile(f, File.ReadAllText(f)));

        var cSharpParseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.Latest);

        TestAnalyzerConfigOptionsProvider analyzerConfigOptions = new(new Dictionary<string, string>
        {
            { "build_property.CoreProjectPath", corePath },
            { "build_property.Configuration", "Debug" },
            { "build_property.PipelineBuild", "false" }
        });

        // Source generators should be tested using 'GeneratorDriver'.
        GeneratorDriver driver = CSharpGeneratorDriver
            .Create([generator.AsSourceGenerator()], additionalTexts, cSharpParseOptions, analyzerConfigOptions);

        // Create a compilation that includes the dymaptic.GeoBlazor.Core sources so generated trees are merged with real trees.
        var compilation = CreateCompilationWithCoreSources(corePath, cSharpParseOptions);

        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out var newCompilation,
            out var diagnostics);

        Assert.IsTrue(diagnostics.Any(d => d.Id == "GBSourceGen"),
            "Expected a GBSourceGen diagnostic from the generator.");

        // find the generated tree that contains the ESBuildRecord marker
        var generatedTree = newCompilation.SyntaxTrees.FirstOrDefault(t => t.ToString().Contains("ESBuildRecord"));
        Assert.IsNotNull(generatedTree, "Expected a generated syntax tree containing 'ESBuildRecord'.");
        var generatedText = generatedTree!.ToString();

        Assert.Contains("private const string Configuration = \"Debug\";", generatedText,
            "Expected Configuration = \"Debug\" in generated tree.");
    }

    [TestMethod]
    public void TestCanTriggerESBuildInReleaseMode()
    {
        var corePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "..", "..", "..", "..", "..", "src", "dymaptic.GeoBlazor.Core");

        var generator = new ProtobufSourceGenerator();

        // get actual Scripts files
        var scriptsPath = Path.Combine(corePath, "Scripts");

        var additionalTexts = Directory
            .GetFiles(scriptsPath, "*.ts")
            .Select(f => new TestAdditionalFile(f, File.ReadAllText(f)));

        var cSharpParseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.Latest);

        TestAnalyzerConfigOptionsProvider analyzerConfigOptions = new(new Dictionary<string, string>
        {
            { "build_property.MSBuildProjectDirectory", corePath },
            { "build_property.Configuration", "Release" },
            { "build_property.PipelineBuild", "false" }
        });

        // Source generators should be tested using 'GeneratorDriver'.
        GeneratorDriver driver = CSharpGeneratorDriver
            .Create([generator.AsSourceGenerator()], additionalTexts, cSharpParseOptions, analyzerConfigOptions);

        var compilation = CreateCompilationWithCoreSources(corePath, cSharpParseOptions);

        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out var newCompilation,
            out var diagnostics);

        Assert.IsTrue(diagnostics.Any(d => d.Id == "GBSourceGen"),
            "Expected a GBSourceGen diagnostic from the generator.");

        var generatedTree = newCompilation.SyntaxTrees.FirstOrDefault(t => t.ToString().Contains("ESBuildRecord"));
        Assert.IsNotNull(generatedTree, "Expected a generated syntax tree containing 'ESBuildRecord'.");
        var generatedText = generatedTree!.ToString();

        Assert.Contains("private const string Configuration = \"Release\";", generatedText,
            "Expected Configuration = \"Release\" in generated tree.");
    }

    [TestMethod]
    public void TestCanSkipBuildInPipelineMode()
    {
        var corePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "..", "..", "..", "..", "..", "src", "dymaptic.GeoBlazor.Core");

        var generator = new ProtobufSourceGenerator();

        // get actual Scripts files
        var scriptsPath = Path.Combine(corePath, "Scripts");

        var additionalTexts = Directory
            .GetFiles(scriptsPath, "*.ts")
            .Select(f => new TestAdditionalFile(f, File.ReadAllText(f)));

        var cSharpParseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.Latest);

        TestAnalyzerConfigOptionsProvider analyzerConfigOptions = new(new Dictionary<string, string>
        {
            { "build_property.MSBuildProjectDirectory", corePath },
            { "build_property.Configuration", "Release" },
            { "build_property.PipelineBuild", "true" }
        });

        // Source generators should be tested using 'GeneratorDriver'.
        GeneratorDriver driver = CSharpGeneratorDriver
            .Create([generator.AsSourceGenerator()], additionalTexts, cSharpParseOptions, analyzerConfigOptions);

        // Create compilation with core sources so there are real syntax trees present
        var compilation = CreateCompilationWithCoreSources(corePath, cSharpParseOptions);

        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out var newCompilation,
            out var diagnostics);

        Assert.IsTrue(diagnostics.Any(d => d.Id == "GBSourceGen"),
            "Expected a GBSourceGen diagnostic from the generator.");

        // When running in pipeline mode the generator should not produce the ESBuildRecord generated tree
        Assert.IsFalse(newCompilation.SyntaxTrees.Any(t => t.ToString().Contains("ESBuildRecord")),
            "Did not expect an ESBuildRecord generated tree when PipelineBuild is true.");
    }

    // Helper: create a compilation that includes the dymaptic.GeoBlazor.Core source files
    private static CSharpCompilation CreateCompilationWithCoreSources(string corePath, CSharpParseOptions parseOptions)
    {
        // gather all .cs files from the core project
        var csFiles = Directory.GetFiles(corePath, "*.cs", SearchOption.AllDirectories);
        var trees = csFiles.Select(f => CSharpSyntaxTree.ParseText(File.ReadAllText(f), parseOptions, f)).ToList();

        // minimal set of references for compilation
        var referencePaths = new[]
            {
                typeof(object).Assembly.Location, 
                typeof(Enumerable).Assembly.Location,
                typeof(Attribute).Assembly.Location, 
                typeof(Console).Assembly.Location,
                typeof(ProtoContractAttribute).Assembly.Location
            }
            .Where(p => !string.IsNullOrEmpty(p))
            .Distinct();

        var references = referencePaths.Select(p => MetadataReference.CreateFromFile(p)).ToList();

        return CSharpCompilation.Create(nameof(CoreSourceGeneratorTests), trees, references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    }
}

public class TestAnalyzerConfigOptionsProvider(Dictionary<string, string> options)
    : AnalyzerConfigOptionsProvider
{
    public override AnalyzerConfigOptions GlobalOptions { get; } = new TestAnalyzerConfigOptions(options);

    public override AnalyzerConfigOptions GetOptions(SyntaxTree tree)
    {
        return GlobalOptions;
    }

    public override AnalyzerConfigOptions GetOptions(AdditionalText textFile)
    {
        return GlobalOptions;
    }
}

public class TestAnalyzerConfigOptions(Dictionary<string, string> options)
    : AnalyzerConfigOptions
{
    public override bool TryGetValue(string key, [NotNullWhen(true)] [UnscopedRef] out string? value)
    {
        if (options.TryGetValue(key, out var optionValue))
        {
            value = optionValue;

            return true;
        }

        value = null;

        return false;
    }
}