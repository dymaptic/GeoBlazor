using CliWrap;
using CliWrap.EventStream;
using dymaptic.GeoBlazor.Core.SourceGenerator.Tests.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using ProtoBuf;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;


namespace dymaptic.GeoBlazor.Core.SourceGenerator.Tests;

[TestClass]
public class CoreSourceGeneratorTests
{
    [TestMethod]
    public void TestCanTriggerESBuildInDebugMode()
    {
        string corePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "..", "..", "..", "..", "..", "src", "dymaptic.GeoBlazor.Core");
        var buildToolsPath = Path.Combine(corePath, "..", "..", "build-tools");

        var generator = new CoreESBuildGenerator();

        // get actual Scripts files
        var scriptsPath = Path.Combine(corePath, "Scripts");

        IEnumerable<TestAdditionalFile> additionalTexts = Directory
            .GetFiles(scriptsPath, "*.ts")
            .Select(f => new TestAdditionalFile(f, File.ReadAllText(f)));

        var cSharpParseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.Latest);

        TestAnalyzerConfigOptionsProvider analyzerConfigOptions = new(new Dictionary<string, string>
        {
            { "build_property.CoreProjectPath", corePath },
            { "build_property.Configuration", "Debug" },
            { "build_property.DesignTimeBuild", "true" },
            { "build_property.GBBuildToolsPath", buildToolsPath }
        });

        // Source generators should be tested using 'GeneratorDriver'.
        GeneratorDriver driver = CSharpGeneratorDriver
            .Create([generator.AsSourceGenerator()], additionalTexts, cSharpParseOptions, analyzerConfigOptions);

        // Create a compilation that includes the dymaptic.GeoBlazor.Core sources so generated trees are merged with real trees.
        var compilation = CreateCompilationWithCoreSources(corePath, cSharpParseOptions);

        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out _,
            out var diagnostics);

        Trace.WriteLine(string.Join(Environment.NewLine, diagnostics.Select(d => d.GetMessage())));

        Assert.IsTrue(diagnostics.Any(d => d.Id == "GBSourceGen"),
            "Expected a GBSourceGen diagnostic from the generator.");

        Assert.IsTrue(diagnostics.Any(d => d.GetMessage()
                .Contains("Command 'dotnet ESBuild.dll -c Debug' completed successfully.")),
            "Expected a Core ESBuild process completed successfully.");
    }

    [TestMethod]
    public void TestCanTriggerESBuildInReleaseMode()
    {
        string corePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "..", "..", "..", "..", "..", "src", "dymaptic.GeoBlazor.Core");
        var buildToolsPath = Path.Combine(corePath, "..", "..", "build-tools");

        var generator = new CoreESBuildGenerator();

        // get actual Scripts files
        var scriptsPath = Path.Combine(corePath, "Scripts");

        IEnumerable<TestAdditionalFile> additionalTexts = Directory
            .GetFiles(scriptsPath, "*.ts")
            .Select(f => new TestAdditionalFile(f, File.ReadAllText(f)));

        var cSharpParseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.Latest);

        TestAnalyzerConfigOptionsProvider analyzerConfigOptions = new(new Dictionary<string, string>
        {
            { "build_property.CoreProjectPath", corePath },
            { "build_property.Configuration", "Release" },
            { "build_property.DesignTimeBuild", "true" },
            { "build_property.GBBuildToolsPath", buildToolsPath }
        });

        // Source generators should be tested using 'GeneratorDriver'.
        GeneratorDriver driver = CSharpGeneratorDriver
            .Create([generator.AsSourceGenerator()], additionalTexts, cSharpParseOptions, analyzerConfigOptions);

        var compilation = CreateCompilationWithCoreSources(corePath, cSharpParseOptions);

        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out _,
            out var diagnostics);

        Trace.WriteLine(string.Join(Environment.NewLine, diagnostics.Select(d => d.GetMessage())));

        Assert.IsTrue(diagnostics.Any(d => d.Id == "GBSourceGen"),
            "Expected a GBSourceGen diagnostic from the generator.");

        Assert.IsTrue(diagnostics.Any(d => d.GetMessage()
                .Contains("Command 'dotnet ESBuild.dll -c Release' completed successfully.")),
            "Expected a Core ESBuild process completed successfully.");
    }

    [TestMethod]
    public void TestCanSkipBuildInWhenNotInDesignTimeBuild()
    {
        string corePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "..", "..", "..", "..", "..", "src", "dymaptic.GeoBlazor.Core");

        var generator = new CoreESBuildGenerator();

        // get actual Scripts files
        var scriptsPath = Path.Combine(corePath, "Scripts");

        IEnumerable<TestAdditionalFile> additionalTexts = Directory
            .GetFiles(scriptsPath, "*.ts")
            .Select(f => new TestAdditionalFile(f, File.ReadAllText(f)));

        var cSharpParseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.Latest);

        TestAnalyzerConfigOptionsProvider analyzerConfigOptions = new(new Dictionary<string, string>
        {
            { "build_property.CoreProjectPath", corePath },
            { "build_property.Configuration", "Release" },
            { "build_property.DesignTimeBuild", "false" }
        });

        // Source generators should be tested using 'GeneratorDriver'.
        GeneratorDriver driver = CSharpGeneratorDriver
            .Create([generator.AsSourceGenerator()], additionalTexts, cSharpParseOptions, analyzerConfigOptions);

        // Create compilation with core sources so there are real syntax trees present
        var compilation = CreateCompilationWithCoreSources(corePath, cSharpParseOptions);

        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out _,
            out var diagnostics);

        Trace.WriteLine(string.Join(Environment.NewLine, diagnostics.Select(d => d.GetMessage())));

        Assert.IsTrue(diagnostics.Any(d => d.Id == "GBSourceGen"),
            "Expected a GBSourceGen diagnostic from the generator.");

        // When running in pipeline mode the generator should not run the esbuild processes
        Assert.IsFalse(diagnostics.Any(d => d.GetMessage()
                .Contains("Core ESBuild process completed successfully.")),
            "ESBuild ran when it should not have in a full compilation build");
    }

    // Helper: create a compilation that includes the dymaptic.GeoBlazor.Core source files
    private static CSharpCompilation CreateCompilationWithCoreSources(string corePath, CSharpParseOptions parseOptions)
    {
        // gather all .cs files from the core project
        var csFiles = Directory.GetFiles(corePath, "*.cs", SearchOption.AllDirectories);

        var trees = csFiles.Select(f => CSharpSyntaxTree.ParseText(File.ReadAllText(f), parseOptions, f))
            .ToList();

        // minimal set of references for compilation
        IEnumerable<string> referencePaths = new[]
            {
                typeof(object).Assembly.Location, typeof(Enumerable).Assembly.Location,
                typeof(Attribute).Assembly.Location, typeof(Console).Assembly.Location,
                typeof(ProtoContractAttribute).Assembly.Location, typeof(Cli).Assembly.Location,
                typeof(EventStreamCommandExtensions).Assembly.Location
            }
            .Where(p => !string.IsNullOrEmpty(p))
            .Distinct();

        List<PortableExecutableReference> references = referencePaths
            .Select(p => MetadataReference.CreateFromFile(p))
            .ToList();

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