using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Text;
using System.Text.RegularExpressions;


namespace dymaptic.GeoBlazor.Core.Test.Automation.SourceGeneration;

[Generator]
public class GenerateTests : IIncrementalGenerator
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

            List<string> additionalAttributes = [];
            List<string> classAttributes = [];
            Dictionary<string, List<string>> testMethods = [];

            bool attributeFound = false;
            var inMethod = false;
            var openingBracketFound = false;
            int lineNumber = 0;
            var methodBracketCount = 0;

            foreach (var line in testClass.GetText()!.Lines.Select(l => l.ToString().Trim()))
            {
                lineNumber++;

                if (inMethod)
                {
                    if (line.Contains("}"))
                    {
                        methodBracketCount++;
                    }
                    else if (line.Contains("{"))
                    {
                        openingBracketFound = true;
                        methodBracketCount--;
                    }

                    if (openingBracketFound && (methodBracketCount == 0))
                    {
                        inMethod = false;
                    }

                    continue;
                }

                if (attributeFound)
                {
                    if (testMethodRegex.Match(line) is { Success: true } match)
                    {
                        inMethod = true;

                        if (line.Contains("{"))
                        {
                            openingBracketFound = true;
                        }

                        string methodName = match.Groups["testName"].Value;
                        testMethods.Add(methodName, additionalAttributes);
                        attributeFound = false;
                        additionalAttributes = [];

                        continue;
                    }

                    if (line.StartsWith("//"))
                    {
                        // commented out test
                        attributeFound = false;

                        continue;
                    }

                    throw new FormatException($"Line after [TestMethod] should be a method signature: Line {lineNumber
                    } in test class {testClassName}");
                }

                if (line.Contains("[TestMethod]") && !line.StartsWith("//"))
                {
                    attributeFound = true;
                }
                else if (attributesToIgnore.Any(attribute => line.Contains($"[{attribute}")))
                {
                    // ignore these attributes
                }
                else if (attributeRegex.Match(line) is { Success: true })
                {
                    additionalAttributes.Add(line);
                }
                else if (razorAttributeRegex.Match(line) is { Success: true } razorAttribute)
                {
                    var attributeContent = razorAttribute.Groups["attributeContent"].Value;

                    // razor attributes are on the whole class
                    classAttributes.Add($"[{attributeContent}]");
                }
                else if (classDeclarationRegex.Match(line) is { Success: true })
                {
                    classAttributes = additionalAttributes;
                    additionalAttributes = [];
                }
            }

            if (testMethods.Count == 0)
            {
                continue;
            }

            StringBuilder sourceBuilder = new($$"""
                                                namespace dymaptic.GeoBlazor.Core.Test.Automation;

                                                [TestClass]{{
                                                    (classAttributes.Count > 0
                                                        ? $"\n{string.Join("\n", classAttributes)}"
                                                        : "")}}
                                                public class {{className}}: GeoBlazorTestClass
                                                {

                                                """);

            foreach (KeyValuePair<string, List<string>> testMethod in testMethods)
            {
                var methodName = testMethod.Key.Split('.').Last();
                var methodAttributes = testMethod.Value;

                sourceBuilder.AppendLine($$"""
                                               [TestMethod]{{
                                                   (methodAttributes.Count > 0
                                                       ? $"\n    {string.Join("\n    ", methodAttributes)}"
                                                       : "")}}
                                               public Task {{methodName}}()
                                               {
                                                   return RunTestImplementation($"{{testClassName}}.{nameof({{methodName
                                                   }})}");
                                               }

                                           """);
            }

            sourceBuilder.AppendLine("}");

            context.AddSource($"{className}.g.cs", sourceBuilder.ToString());
        }
    }

    private static readonly string[] attributesToIgnore =
    [
        "TestClass",
        "Inject",
        "Parameter",
        "CascadingParameter",
        "IsolatedTest",
        "SuppressMessage"
    ];
    private static readonly Regex testMethodRegex =
        new(@"^\s*public (?:async Task)?(?:void)? (?<testName>[A-Za-z0-9_]*)\(.*?$", RegexOptions.Compiled);
    private static readonly Regex attributeRegex = new(@"^\[.+\]$", RegexOptions.Compiled);
    private static readonly Regex razorAttributeRegex =
        new("^@attribute (?<attributeContent>[A-Za-z0-9_]*.*?)$", RegexOptions.Compiled);
    private static readonly Regex classDeclarationRegex =
        new(@"^public class (?<className>[A-Za-z0-9_]+)\s*?:?.*?$", RegexOptions.Compiled);
}