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

        if (configProvider.GlobalOptions.TryGetValue($"{BUILD_PROPERTY}.{CONFIGURATION}", out var configuration))
        {
            options[CONFIGURATION] = configuration;
        }

        if (configProvider.GlobalOptions.TryGetValue($"{BUILD_PROPERTY}.{DESIGN_TIME_BUILD}",
            out var designTimeBuild))
        {
            options[DESIGN_TIME_BUILD] = designTimeBuild;
        }

        if (configProvider.GlobalOptions.TryGetValue($"{BUILD_PROPERTY}.{SHOW_SOURCE_GEN_DIALOGS}",
            out var showDialog))
        {
            options[SHOW_SOURCE_GEN_DIALOGS] = showDialog;
        }

        if (configProvider.GlobalOptions.TryGetValue($"{BUILD_PROPERTY}.{CORE_PROJECT_PATH}", out var coreProjectPath))
        {
            options[CORE_PROJECT_PATH] = coreProjectPath;
        }

        if (configProvider.GlobalOptions.TryGetValue($"{BUILD_PROPERTY}.{PRO_PROJECT_PATH}", out var proProjectPath))
        {
            options[PRO_PROJECT_PATH] = proProjectPath;
        }

        return options;
    }

    public static void FilesChanged(SourceProductionContext context,
        (ImmutableArray<AdditionalText> Files, Dictionary<string, string> Options) pipeline, bool isPro,
        string sessionId, string proSessionId)
    {
        var callingGenerator = isPro ? "Pro ESBuild Generator" : "Core ESBuild Generator";

        if (pipeline.Files.Length == 0)
        {
            ProcessHelper.Log(callingGenerator,
                "ESBuild Source Generation skipped due to no files changed.",
                DiagnosticSeverity.Info,
                context);

            return;
        }

        var parsedOptions = ParseOptions(pipeline.Options, callingGenerator, context);

        if (parsedOptions is null)
        {
            return;
        }

        var options = parsedOptions.Value;

        if (options.GBBuildToolsPath is null
            || options.Configuration is null
            || options.CoreProjectPath is null)
        {
            ProcessHelper.Log(callingGenerator,
                "ESBuild Source Generation skipped due to missing configuration settings.",
                DiagnosticSeverity.Info,
                context);

            return;
        }

        if (!options.DesignTimeBuild)
        {
            // If this is a full compilation, we call ESBuild directly from Core.csproj earlier in the process,
            // so we want to exit out here.
            ProcessHelper.Log(callingGenerator,
                "ESBuild Source Generation skipped during full compilation.",
                DiagnosticSeverity.Info,
                context);

            return;
        }

        if (ESBuildProcessIsLocked(options, isPro))
        {
            ProcessHelper.Log(callingGenerator,
                "ESBuild Source Generation skipped due to other current process lock.",
                DiagnosticSeverity.Info,
                context);

            return;
        }

        ProcessHelper.Log(callingGenerator,
            "ESBuild Source Generation triggered.",
            DiagnosticSeverity.Info,
            context, options.ShowSourceGenDialogs, sessionId);

        LaunchESBuild(options, sessionId, proSessionId, context, isPro);

        if (options.ShowSourceGenDialogs)
        {
            ProcessHelper.CloseDialog(sessionId);
            ProcessHelper.CloseDialog(proSessionId);
        }
    }

    private static ESBuildGeneratorOptions? ParseOptions(Dictionary<string, string> options, string processName,
        SourceProductionContext context)
    {
        try
        {
            // Use TryGetValue to safely access dictionary keys
            options.TryGetValue(GB_BUILD_TOOLS_PATH, out var gbBuildToolsPath);
            options.TryGetValue(CONFIGURATION, out var configuration);
            options.TryGetValue(CORE_PROJECT_PATH, out var coreProjectPath);
            options.TryGetValue(PRO_PROJECT_PATH, out var proProjectPath);

            // For boolean values, provide defaults if not found
            var designTimeBuild = false;

            if (options.TryGetValue(DESIGN_TIME_BUILD, out var designTimeBuildStr))
            {
                bool.TryParse(designTimeBuildStr, out designTimeBuild);
            }

            var showSourceGenDialogs = false;

            if (options.TryGetValue(SHOW_SOURCE_GEN_DIALOGS, out var showSourceGenDialogsStr))
            {
                bool.TryParse(showSourceGenDialogsStr, out showSourceGenDialogs);
            }

            return new ESBuildGeneratorOptions(gbBuildToolsPath,
                configuration,
                designTimeBuild,
                showSourceGenDialogs,
                coreProjectPath,
                proProjectPath);
        }
        catch (Exception ex)
        {
            ProcessHelper.Log(processName,
                $"Error parsing configuration settings: {ex.Message}",
                DiagnosticSeverity.Error, context);

            return null;
        }
    }

    private static bool ESBuildProcessIsLocked(ESBuildGeneratorOptions options, bool isPro)
    {
        var projectPath = isPro ? options.ProProjectPath! : options.CoreProjectPath!;
        var lockFilePath = Path.Combine(projectPath, $"esBuild.{options.Configuration}.lock");

        if (File.Exists(lockFilePath))
        {
            var lockFileContents = File.ReadAllText(lockFilePath);
            var lockFileDate = DateTime.Parse(lockFileContents);

            if (DateTime.UtcNow.Subtract(lockFileDate).TotalMinutes < 5)
            {
                // pause all background builds for 5 minutes to ensure no overlaps
                return true;
            }

            // delete old lock file
            File.Delete(lockFilePath);
        }

        return false;
    }

    private static void LaunchESBuild(ESBuildGeneratorOptions options, string sessionId,
        string proSessionId, SourceProductionContext context, bool isPro)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        ProcessHelper.Log("Core ESBuild Generator",
            "Starting Core ESBuild process...",
            DiagnosticSeverity.Info,
            context, options.ShowSourceGenDialogs, sessionId);

        try
        {
            List<Task> tasks = [];
            var coreBuildSuccess = false;
            var proBuildSuccess = false;

            // gets the ESBuild.cs script
            List<string> esBuildArgs =
            [
                "ESBuild.dll",
                "-c", options.Configuration! // set config for ESBuild
            ];

            if (!isPro)
            {
                // Run for Core Generation
                tasks.Add(Task.Run(async () =>
                {
                    var coreArgs = esBuildArgs.ToArray();

                    await ProcessHelper.Execute("Core ESBuild Generator",
                        options.GBBuildToolsPath!, "dotnet",
                        coreArgs, context, options.ShowSourceGenDialogs, sessionId);
                    coreBuildSuccess = true;
                }));
            }

            if (options.ProProjectPath is not null) // Run for Pro Generation, both from Core and Pro triggers
            {
                ProcessHelper.Log("Pro ESBuild Generator",
                    "Starting Pro ESBuild process...",
                    DiagnosticSeverity.Info,
                    context, options.ShowSourceGenDialogs, proSessionId);

                string[] proArgs = [..esBuildArgs, "--pro", "-pc"];

                tasks.Add(Task.Run(async () =>
                {
                    await ProcessHelper.Execute("Pro ESBuild Generator",
                        options.GBBuildToolsPath!, "dotnet",
                        proArgs, context, options.ShowSourceGenDialogs, proSessionId);
                    proBuildSuccess = true;
                }));
            }

            Task.WhenAll(tasks).GetAwaiter().GetResult();

            if (!coreBuildSuccess)
            {
                ProcessHelper.Log("Core ESBuild Generator",
                    "Core ESBuild process failed",
                    DiagnosticSeverity.Error,
                    context, options.ShowSourceGenDialogs, sessionId);

                return;
            }

            if (options.ProProjectPath is not null)
            {
                if (!proBuildSuccess)
                {
                    ProcessHelper.Log("Pro ESBuild Generator",
                        "Pro ESBuild process failed",
                        DiagnosticSeverity.Error,
                        context, options.ShowSourceGenDialogs, proSessionId);
                }
            }
        }
        catch (Exception ex)
        {
            ProcessHelper.Log(isPro ? "Pro ESBuild Generator" : "Core ESBuild Generator",
                $"An error occurred while running ESBuild: {ex.Message}\r\n{ex.StackTrace}",
                DiagnosticSeverity.Error,
                context, options.ShowSourceGenDialogs, sessionId);
        }
    }

    private const string GB_BUILD_TOOLS_PATH = "GBBuildToolsPath";
    private const string CONFIGURATION = "Configuration";
    private const string DESIGN_TIME_BUILD = "DesignTimeBuild";
    private const string SHOW_SOURCE_GEN_DIALOGS = "ShowSourceGenDialogs";
    private const string CORE_PROJECT_PATH = "CoreProjectPath";
    private const string PRO_PROJECT_PATH = "ProProjectPath";
    private const string BUILD_PROPERTY = "build_property";
}

public record struct ESBuildGeneratorOptions(
    string? GBBuildToolsPath,
    string? Configuration,
    bool DesignTimeBuild,
    bool ShowSourceGenDialogs,
    string? CoreProjectPath,
    string? ProProjectPath);