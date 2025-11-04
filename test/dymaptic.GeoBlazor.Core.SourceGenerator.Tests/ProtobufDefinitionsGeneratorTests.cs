using dymaptic.GeoBlazor.Core.SourceGenerator.Tests.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;
using System.Reflection;


namespace dymaptic.GeoBlazor.Core.SourceGenerator.Tests;

[TestClass]
public class ProtobufDefinitionsGeneratorTests
{
    [TestMethod]
    public void TestCanTriggerProtoGenWhenProtoContractPresent()
    {
        ProtobufDefinitionsGenerator generator = new ProtobufDefinitionsGenerator();
        ProcessHelper.Notification += generator.PassNotification;
        bool resultsReceived = false;
        generator.Notification += (_, message) =>
        {
            Console.WriteLine(message);
            resultsReceived = true;
        };

        // No additional files required for this generator
        IEnumerable<AdditionalText> additionalTexts = [];

        CSharpParseOptions cSharpParseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp7_3);

        TestAnalyzerConfigOptionsProvider analyzerConfigOptions = new(new Dictionary<string, string>
        {
            { "build_property.MSBuildProjectDirectory", RoslynUtility.CorePath },
            { "build_property.PipelineBuild", "false" }
        });

        GeneratorDriver driver = CSharpGeneratorDriver
            .Create([generator.AsSourceGenerator()], additionalTexts, cSharpParseOptions, analyzerConfigOptions);

        string filePath = Path.Combine(RoslynUtility.CorePath, "Serialization", "ProtobufSerializationRecords.cs");
        CSharpCompilation compilation = RoslynUtility.CreateCompilation(File.ReadAllText(filePath));

        driver.RunGeneratorsAndUpdateCompilation(compilation, out _, 
            out ImmutableArray<Diagnostic> diagnostics);

        // The generator triggers ProtoGen which will report back via diagnostics; assert we got a message
        Assert.IsTrue(diagnostics.Any(d => d.Id == "GBSourceGen"), "Expected a GBSourceGen diagnostic from the generator.");
        Assert.IsTrue(resultsReceived, "Expected to receive notifications from the generator.");

        ProcessHelper.Notification -= generator.PassNotification;
    }

    [TestMethod]
    public void TestSkippingProtoGenInPipelineMode()
    {
        ProtobufDefinitionsGenerator generator = new ProtobufDefinitionsGenerator();
        ProcessHelper.Notification += generator.PassNotification;
        bool resultsReceived = false;
        generator.Notification += (_, message) =>
        {
            Console.WriteLine(message);
            resultsReceived = true;
        };

        // No additional files required for this generator
        IEnumerable<AdditionalText> additionalTexts = [];

        CSharpParseOptions cSharpParseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp7_3);

        TestAnalyzerConfigOptionsProvider analyzerConfigOptions = new(new Dictionary<string, string>
        {
            { "build_property.MSBuildProjectDirectory", RoslynUtility.CorePath },
            { "build_property.PipelineBuild", "true" }
        });

        GeneratorDriver driver = CSharpGeneratorDriver
            .Create([generator.AsSourceGenerator()], additionalTexts, cSharpParseOptions, analyzerConfigOptions);

        string filePath = Path.Combine(RoslynUtility.CorePath, "Serialization", "ProtobufSerializationRecords.cs");
        CSharpCompilation compilation = RoslynUtility.CreateCompilation(File.ReadAllText(filePath));

        driver.RunGeneratorsAndUpdateCompilation(compilation, out _, out ImmutableArray<Diagnostic> diagnostics);

        // In pipeline mode the generator should skip work and report a GBSourceGen diagnostic about skipping
        Assert.IsTrue(diagnostics.Any(d => d.Id == "GBSourceGen" && d.GetMessage().Contains("Skipping ProtoGen")), "Expected GBSourceGen diagnostic indicating ProtoGen was skipped.");
        Assert.IsTrue(resultsReceived, "Expected to receive notifications from the generator.");

        ProcessHelper.Notification -= generator.PassNotification;
    }
}
