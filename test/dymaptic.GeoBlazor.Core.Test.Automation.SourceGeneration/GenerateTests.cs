using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Text.RegularExpressions;


namespace dymaptic.GeoBlazor.Core.Test.Automation.SourceGeneration;

[Generator]
public class GenerateTests: IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValueProvider<ImmutableArray<AdditionalText>> testProvider =
            context.AdditionalTextsProvider.Collect();
        context.RegisterSourceOutput(testProvider, Generate);
    }

    private void Generate(SourceProductionContext context, ImmutableArray<AdditionalText> testClasses)
    {
        foreach (AdditionalText testClass in testClasses)
        {
            string testClassName = testClass.Path.Split('/', '\\').Last().Split('.').First();
            bool isPro = testClass.Path.Contains("dymaptic.GeoBlazor.Pro.Test.Blazor.Shared");
            string className = isPro ? $"PRO_{testClassName}" : $"CORE_{testClassName}";

            List<string> testMethods = [];
            
            bool attributeFound = false;
            int lineNumber = 0;
            foreach (string line in testClass.GetText()!.Lines.Select(l => l.ToString()))
            {
                lineNumber++;
                if (attributeFound)
                {
                    if (testMethodRegex.Match(line) is { Success: true } match)
                    {
                        string methodName = match.Groups["testName"].Value;
                        testMethods.Add($"{testClassName}.{methodName}");
                        attributeFound = false;

                        continue;
                    }

                    if (line.Trim().StartsWith("//"))
                    {
                        // commented out test
                        attributeFound = false;

                        continue;
                    }

                    throw new FormatException($"Line after [TestMethod] should be a method signature: Line {lineNumber
                    } in test class {testClassName}");
                }
            
                if (line.Contains("[TestMethod]") && !line.Trim().StartsWith("//"))
                {
                    attributeFound = true;
                }
            }

            if (testMethods.Count == 0)
            {
                continue;
            }

            context.AddSource($"{className}.g.cs",
                $$"""
                namespace dymaptic.GeoBlazor.Core.Test.Automation;
                
                [TestClass]
                public class {{className}}: GeoBlazorTestClass
                {
                    public static IEnumerable<object[]> TestMethods => new string[][]
                        {
                            ["{{string.Join($"\"],\n{new string(' ', 12)}[\"", testMethods)}}"]
                        };
                        
                    [DynamicData(nameof(TestMethods), DynamicDataDisplayName = nameof(GenerateTestName), DynamicDataDisplayNameDeclaringType = typeof(GeoBlazorTestClass))]
                    [TestMethod]
                    public Task RunTest(string testClass)
                    {
                        return RunTestImplementation(testClass);
                    }
                }
                """);
        }
    }
    
    private static readonly Regex testMethodRegex = 
        new(@"^\s*public (?:async Task)?(?:void)? (?<testName>[A-Za-z0-9_]*)\(.*?$", RegexOptions.Compiled);
}