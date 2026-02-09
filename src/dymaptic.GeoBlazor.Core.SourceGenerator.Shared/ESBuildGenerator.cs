using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;


namespace dymaptic.GeoBlazor.Core.SourceGenerator.Shared;

[SuppressMessage("MicrosoftCodeAnalysisCorrectness", "RS1035:Do not use APIs banned for analyzers")]
public static class ESBuildGenerator
{
    public static Dictionary<string, string> ConfigSelector(AnalyzerConfigOptionsProvider configProvider,
        CancellationToken _)
    {
        Dictionary<string, string> options = [];

        if (configProvider.GlobalOptions.TryGetValue($"{BUILD_PROPERTY}.{GB_BUILD_TOOLS_PATH}",
            out var gbBuildToolsPath))
        {
            options[GB_BUILD_TOOLS_PATH] = gbBuildToolsPath;
        }

        if (configProvider.GlobalOptions.TryGetValue($"{BUILD_PROPERTY}.{DESIGN_TIME_BUILD}",
            out var designTimeBuild))
        {
            options[DESIGN_TIME_BUILD] = designTimeBuild;
        }

        return options;
    }

    public static void FilesChanged(SourceProductionContext context,
        (ImmutableArray<AdditionalText> Files, Dictionary<string, string> Options) pipeline)
    {
        if (pipeline.Files.Length == 0)
        {
            ProcessHelper.Log(nameof(ESBuildGenerator),
                "ESBuild Source Generator no files changed.",
                DiagnosticSeverity.Info,
                context);

            return;
        }

        var parsedOptions = ParseOptions(pipeline.Options, context);

        if (parsedOptions is null)
        {
            return;
        }

        var options = parsedOptions.Value;

        if (options.GBBuildToolsPath is null)
        {
            ProcessHelper.Log(nameof(ESBuildGenerator),
                "ESBuild Source Generation skipped due to missing configuration settings.",
                DiagnosticSeverity.Info,
                context);

            return;
        }

        ClearESBuildLocks(options, context);
    }

    private static ESBuildGeneratorOptions? ParseOptions(Dictionary<string, string> options,
        SourceProductionContext context)
    {
        try
        {
            // Use TryGetValue to safely access dictionary keys
            options.TryGetValue(GB_BUILD_TOOLS_PATH, out var gbBuildToolsPath);

            // For boolean values, provide defaults if not found
            var designTimeBuild = false;

            if (options.TryGetValue(DESIGN_TIME_BUILD, out var designTimeBuildStr))
            {
                bool.TryParse(designTimeBuildStr, out designTimeBuild);
            }

            return new ESBuildGeneratorOptions(gbBuildToolsPath, designTimeBuild);
        }
        catch (Exception ex)
        {
            ProcessHelper.Log(nameof(ESBuildGenerator),
                $"Error parsing configuration settings: {ex.Message}",
                DiagnosticSeverity.Error, context);

            return null;
        }
    }

    private static void ClearESBuildLocks(ESBuildGeneratorOptions options,
        SourceProductionContext context)
    {
        _ = Task.Run(async () => await ProcessHelper.Execute("Clear Locks",
            options.GBBuildToolsPath!, "dotnet",
            ["ESBuildClearLocks.dll"], context, false, null));

        ProcessHelper.Log(nameof(ESBuildGenerator),
            "Cleared ESBuild Process Locks",
            DiagnosticSeverity.Info,
            context);
    }

    private const string GB_BUILD_TOOLS_PATH = "GBBuildToolsPath";
    private const string DESIGN_TIME_BUILD = "DesignTimeBuild";
    private const string BUILD_PROPERTY = "build_property";
}

public record struct ESBuildGeneratorOptions(
    string? GBBuildToolsPath,
    bool DesignTimeBuild);