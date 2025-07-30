using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using dymaptic.GeoBlazor.Core.SourceGenerator.Tests.Utils;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace dymaptic.GeoBlazor.Core.SourceGenerator.Tests;

[TestClass]
public class ArcGISVersionInfoSourceGeneratorTests
{
    [TestMethod]
    public void TestCanParseNpmPackageVersionsAndBuildStaticClass()
    {
        // Create an instance of the source generator.
        var generator = new ArcGISVersionInfoSourceGenerator();

        // Source generators should be tested using 'GeneratorDriver'.
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        // Add the additional file separately from the compilation.
        driver = driver.AddAdditionalTexts([new TestAdditionalFile("./package.json", PackageJSONText)]);

        // To run generators, we can use an empty compilation.
        var compilation = CSharpCompilation.Create(nameof(ArcGISVersionInfoSourceGeneratorTests));

        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out var newCompilation, out _);

        // Retrieve all files in the compilation.
        var generatedFiles = newCompilation.SyntaxTrees
            .Select(t => Path.GetFileName(t.FilePath))
            .ToArray();

        // In this case, it is enough to check the file name.
        Assert.IsTrue(generatedFiles.SequenceEqual((string[]) ["ArcGISSDKVersionInfo.g.cs"]));
        string content = newCompilation.SyntaxTrees.First().ToString();
        Assert.IsTrue(content.Contains("internal static class ArcGISSDKVersionInfo"));
        Assert.IsTrue(content.Contains("public const string ArcGISVersion = \"4.33.8\";"));
        Assert.IsTrue(content.Contains("public const string ArcGISMapComponentsVersion = \"4.33.8\";"));
        Assert.IsTrue(content.Contains("public const string CalciteVersion = \"3.2.1\";"));
    }
    
    private const string PackageJSONText = """
                                           {
                                             "name": "dymaptic.GeoBlazor.Core",
                                             "description": "https://www.geoblazor.com",
                                             "main": "arcGisInterop.js",
                                             "type": "module",
                                             "scripts": {
                                               "debugBuild": "node ./esbuild.js --debug",
                                               "watchBuild": "node ./esbuild.js --watch",
                                               "releaseBuild": "node ./esbuild.js --release",
                                               "forceDebugBuild": "node ./esbuild.js --debug --force"
                                             },
                                             "keywords": [],
                                             "author": "dymaptic",
                                             "license": "ISC",
                                             "dependencies": {
                                               "@arcgis/core": "4.33.8",
                                               "@arcgis/map-components": "4.33.8",
                                               "@esri/calcite-components": "3.2.1",
                                               "esbuild": "0.25.2",
                                               "esbuild-clean-plugin": "^2.0.0",
                                               "protobufjs": "7.4.0"
                                             },
                                             "devDependencies": {
                                               "@eslint/js": "9.24.0",
                                               "@types/node": "^22.14.0",
                                               "esbuild-plugin-eslint": "^0.3.12",
                                               "eslint": "9.24.0",
                                               "globals": "^16.0.0",
                                               "typescript-eslint": "^8.29.0"
                                             }
                                           }
                                            
                                           """;
}