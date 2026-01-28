using dymaptic.GeoBlazor.Core.SourceGenerator.Shared;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;


namespace dymaptic.GeoBlazor.Core.SourceGenerator;

/// <summary>
///     Triggers the ESBuild build process for the GeoBlazor project, so that your JavaScript code is up to date.
/// </summary>
[Generator]
[SuppressMessage("MicrosoftCodeAnalysisCorrectness", "RS1035:Do not use APIs banned for analyzers")]
public class ESBuildGenerator : IIncrementalGenerator
{
    private static string? BuildToolsPath => _corePath is null
        ? null
        : Path.GetFullPath(Path.Combine(_corePath, "..", "..", "build-tools"));

    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Tracks all TypeScript source files in the Scripts directories of Core and Pro.
        // This will trigger the build any time a TypeScript file is added, removed, or changed.
        IncrementalValueProvider<ImmutableArray<AdditionalText>> tsFilesProvider = context
            .AdditionalTextsProvider
            .Where(static text => text.Path.Contains("Scripts")
                && text.Path.EndsWith(".ts"))
            .Collect();

        // Reads the MSBuild properties to get the project directory and configuration.
        IncrementalValueProvider<Dictionary<string, string>> optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select((configProvider, _) =>
            {
                Dictionary<string, string> options = [];

                if (configProvider.GlobalOptions.TryGetValue("build_property.CoreProjectPath",
                    out string? projectDirectory))
                {
                    options["CoreProjectPath"] = projectDirectory;
                }

                if (configProvider.GlobalOptions.TryGetValue("build_property.Configuration",
                    out string? configuration))
                {
                    options["Configuration"] = configuration;
                }

                if (configProvider.GlobalOptions.TryGetValue("build_property.PipelineBuild",
                    out string? pipelineBuild))
                {
                    options["PipelineBuild"] = pipelineBuild;
                }

                if (configProvider.GlobalOptions.TryGetValue("build_property.DesignTimeBuild",
                    out string? designTimeBuild))
                {
                    options["DesignTimeBuild"] = designTimeBuild;
                }

                if (configProvider.GlobalOptions.TryGetValue("build_property.ShowSourceGenDialogs",
                    out string? showDialog))
                {
                    options["ShowSourceGenDialogs"] = showDialog;
                }

                return options;
            });

        var
            combined =
                tsFilesProvider.Combine(optionsProvider);

        context.RegisterSourceOutput(combined, FilesChanged);
    }

    private void FilesChanged(SourceProductionContext context,
        (ImmutableArray<AdditionalText> Files, Dictionary<string, string> Options) pipeline)
    {
        if (!SetProjectDirectoryAndConfiguration(pipeline.Options, context))
        {
            return;
        }

        if (pipeline.Options.TryGetValue("PipelineBuild", out string? pipelineBuild)
            && bool.TryParse(pipelineBuild, out bool pipelineBuildBool)
            && pipelineBuildBool)
        {
            // If the pipeline build is enabled, we skip the ESBuild process.
            // This is to avoid race conditions where the files are not ready on time, and we do the build separately.
            ProcessHelper.Log(nameof(ESBuildGenerator),
                "Skipping ESBuild process as PipelineBuild is set to true.",
                DiagnosticSeverity.Info,
                context);

            return;
        }

        ProcessHelper.Log(nameof(ESBuildGenerator),
            "ESBuild Source Generation triggered.",
            DiagnosticSeverity.Info,
            context, _showDialog, _sessionId);

        if (pipeline.Files.Length > 0)
        {
            LaunchESBuild(context);
        }

        if (_showDialog)
        {
            ProcessHelper.CloseDialog(_sessionId);
        }
    }

    private bool SetProjectDirectoryAndConfiguration(Dictionary<string, string> options,
        SourceProductionContext context)
    {
        if (options.TryGetValue("CoreProjectPath", out string? projectDirectory))
        {
            _corePath = Path.GetFullPath(projectDirectory);

            ProcessHelper.Log(nameof(ESBuildGenerator),
                $"Project directory set to {_corePath}",
                DiagnosticSeverity.Info,
                context, _showDialog, _sessionId);

            if (_corePath.Contains("GeoBlazor.Pro"))
            {
                // we are inside the Pro submodule, we should also set the Pro path to build the Pro JavaScript files
                string path = _corePath;

                while (!path.EndsWith("GeoBlazor.Pro"))
                {
                    // move up the directory tree until we find the GeoBlazor.Pro directory
                    path = Path.GetDirectoryName(path)!;
                }

                // set the pro path to the src/dymaptic.GeoBlazor.Pro directory
                _proPath = Path.GetFullPath(Path.Combine(path, "src", "dymaptic.GeoBlazor.Pro"));
            }
        }
        else
        {
            ProcessHelper.Log(nameof(ESBuildGenerator),
                "Invalid project directory.",
                DiagnosticSeverity.Error,
                context, _showDialog, _sessionId);

            return false;
        }

        if (options.TryGetValue("Configuration", out string? configuration))
        {
            _configuration = configuration;

            if (options.TryGetValue("DesignTimeBuild", out string? designTimeBuild)
                && bool.TryParse(designTimeBuild, out bool designTimeBuildBool))
            {
                _isDesignTimeBuild = designTimeBuildBool;
            }

            if (options.TryGetValue("ShowSourceGenDialogs", out string? showDialog)
                && bool.TryParse(showDialog, out bool showDialogBool))
            {
                _showDialog = showDialogBool;
            }

            return true;
        }

        ProcessHelper.Log(nameof(ESBuildGenerator),
            "Could not parse configuration setting, invalid configuration.",
            DiagnosticSeverity.Error,
            context, _showDialog, _sessionId);

        return false;
    }

    private void LaunchESBuild(SourceProductionContext context)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        ProcessHelper.Log(nameof(ESBuildGenerator),
            "Starting Core ESBuild process...",
            DiagnosticSeverity.Info,
            context, _showDialog, _sessionId);

        try
        {
            List<Task> tasks = [];
            bool buildSuccess = false;
            bool proBuildSuccess = false;

            // gets the ESBuild.cs script
            List<string> esBuildArgs =
            [
                "ESBuild.dll",
                "-c", _configuration! // set config for ESBuild
            ];

            tasks.Add(Task.Run(async () =>
            {
                string[] coreArgs = esBuildArgs.ToArray();

                await ProcessHelper.Execute("Core",
                    BuildToolsPath!, "dotnet",
                    coreArgs, context, _showDialog, _sessionId);
                buildSuccess = true;
            }));

            if (_proPath is not null)
            {
                ProcessHelper.Log(nameof(ESBuildGenerator),
                    "Starting Pro ESBuild process...",
                    DiagnosticSeverity.Info,
                    context, _showDialog, _sessionId);

                string[] proArgs = [..esBuildArgs, "--pro"];

                tasks.Add(Task.Run(async () =>
                {
                    await ProcessHelper.Execute("Pro",
                        BuildToolsPath!, "dotnet",
                        proArgs, context, _showDialog, _sessionId);
                    proBuildSuccess = true;
                }));
            }

            Task.WhenAll(tasks).GetAwaiter().GetResult();

            if (!buildSuccess)
            {
                ProcessHelper.Log(nameof(ESBuildGenerator),
                    "Core ESBuild process failed",
                    DiagnosticSeverity.Error,
                    context, _showDialog, _sessionId);

                return;
            }

            if (_proPath is not null)
            {
                if (!proBuildSuccess)
                {
                    ProcessHelper.Log(nameof(ESBuildGenerator),
                        "Pro ESBuild process failed",
                        DiagnosticSeverity.Error,
                        context, _showDialog, _sessionId);
                }
            }
        }
        catch (Exception ex)
        {
            ClearESBuildLocks(context);

            ProcessHelper.Log(nameof(ESBuildGenerator),
                $"An error occurred while running ESBuild: {ex.Message}\r\n{ex.StackTrace}",
                DiagnosticSeverity.Error,
                context, _showDialog, _sessionId);
        }
    }

    private void ClearESBuildLocks(SourceProductionContext context)
    {
        Task clearTask = Task.Run(async () => await ProcessHelper.Execute("Clear Locks",
            BuildToolsPath!, "dotnet",
            ["ESBuildClearLocks.dll"],
            context, _showDialog, _sessionId));

        clearTask.GetAwaiter().GetResult();

        ProcessHelper.Log(nameof(ESBuildGenerator),
            "Cleared ESBuild Process Locks",
            DiagnosticSeverity.Info,
            context, _showDialog, _sessionId);
    }

    private static string? _corePath;
    private static string? _proPath;
    private static string? _configuration;
    private static bool _isDesignTimeBuild;
    private static bool _showDialog;

    // Generate a unique session ID for this build session
    private readonly string _sessionId = $"{nameof(ESBuildGenerator)}_{Guid.NewGuid():N}";
}