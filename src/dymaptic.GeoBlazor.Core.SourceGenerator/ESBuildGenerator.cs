using dymaptic.GeoBlazor.Core.SourceGenerator.Shared;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text;


namespace dymaptic.GeoBlazor.Core.SourceGenerator;

/// <summary>
///     Triggers the ESBuild build process for the GeoBlazor project, so that your JavaScript code is up to date.
/// </summary>
[Generator]
[SuppressMessage("MicrosoftCodeAnalysisCorrectness", "RS1035:Do not use APIs banned for analyzers")]
public class ESBuildGenerator : IIncrementalGenerator
{
    private static string? BuildScriptsPath => _corePath is null
        ? null
        : Path.GetFullPath(Path.Combine(_corePath, "..", "..", "build"));

    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Tracks all TypeScript source files in the Scripts directories of Core and Pro.
        // This will trigger the build any time a TypeScript file is added, removed, or changed.
        IncrementalValueProvider<ImmutableArray<AdditionalText>> tsFilesProvider = context.AdditionalTextsProvider
            .Where(static text => text.Path.Contains("Scripts")
                && text.Path.EndsWith(".ts"))
            .Collect();

        // Reads the MSBuild properties to get the project directory and configuration.
        IncrementalValueProvider<(string?, string?, string?)> optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select((configProvider, _) =>
            {
                configProvider.GlobalOptions.TryGetValue("build_property.CoreProjectPath",
                    out string? projectDirectory);

                configProvider.GlobalOptions.TryGetValue("build_property.Configuration",
                    out string? configuration);

                configProvider.GlobalOptions.TryGetValue("build_property.PipelineBuild",
                    out string? pipelineBuild);

                return (projectDirectory, configuration, pipelineBuild);
            });

        IncrementalValueProvider<(ImmutableArray<AdditionalText> Left, (string?, string?, string?) Right)> combined =
            tsFilesProvider.Combine(optionsProvider);

        context.RegisterSourceOutput(combined, FilesChanged);
    }

    private void FilesChanged(SourceProductionContext context,
        (ImmutableArray<AdditionalText> Files,
            (string? ProjectDirectory, string? Configuration, string? PipelineBuild) Options) pipeline)
    {
        if (!SetProjectDirectoryAndConfiguration(pipeline.Options, context))
        {
            return;
        }

        ProcessHelper.Log(nameof(ESBuildGenerator),
            "ESBuild Source Generation triggered.",
            DiagnosticSeverity.Info,
            context);

        if (pipeline.Options.PipelineBuild == "true")
        {
            // If the pipeline build is enabled, we skip the ESBuild process.
            // This is to avoid race conditions where the files are not ready on time, and we do the build separately.
            ProcessHelper.Log(nameof(ESBuildGenerator),
                "Skipping ESBuild process as PipelineBuild is set to true.",
                DiagnosticSeverity.Info,
                context, true);

            ProcessHelper.CloseDialog();

            return;
        }

        if (pipeline.Files.Length > 0)
        {
            LaunchESBuild(context);
        }
    }

    private bool SetProjectDirectoryAndConfiguration(
        (string? ProjectDirectory, string? Configuration, string? _) options,
        SourceProductionContext context)
    {
        string? projectDirectory = options.ProjectDirectory;

        if (projectDirectory is not null)
        {
            _corePath = Path.GetFullPath(projectDirectory);

            ProcessHelper.Log(nameof(ESBuildGenerator),
                $"Project directory set to {_corePath}",
                DiagnosticSeverity.Info,
                context);

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
                context);

            return false;
        }

        if (options.Configuration is { } configuration)
        {
            _configuration = configuration;

            return true;
        }

        ProcessHelper.Log(nameof(ESBuildGenerator),
            "Could not parse configuration setting, invalid configuration.",
            DiagnosticSeverity.Error,
            context);

        return false;
    }

    private void LaunchESBuild(SourceProductionContext context)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        ProcessHelper.Log(nameof(ESBuildGenerator),
            "Starting Core ESBuild process...",
            DiagnosticSeverity.Info,
            context);

        StringBuilder logBuilder = new StringBuilder(DateTime.Now.ToLongTimeString());
        logBuilder.AppendLine();
        logBuilder.AppendLine("Starting Core ESBuild process...");

        try
        {
            List<Task> tasks = [];
            bool buildSuccess = false;
            bool proBuildSuccess = false;

            // gets the ESBuild.cs script
            tasks.Add(Task.Run(async () =>
            {
                await ProcessHelper.Execute("Core",
                    BuildScriptsPath!, "dotnet",
                    [
                        "run",
                        "ESBuild.cs",
                        "-c", _configuration!, // pass config to MSBuild
                        "--",
                        "-c", _configuration!, // set config for ESBuild
                        "-d" // show dialog
                    ], logBuilder, context.CancellationToken);
                buildSuccess = true;
            }));

            if (_proPath is not null)
            {
                logBuilder.AppendLine("Starting Pro ESBuild process...");

                tasks.Add(Task.Run(async () =>
                {
                    await ProcessHelper.Execute("Pro",
                        BuildScriptsPath!, "dotnet",
                        [
                            "run",
                            "ESBuild.cs",
                            "-c", _configuration!, // pass config to MSBuild
                            "--",
                            "-c", _configuration!, // set config for ESBuild
                            "-d", // show dialog
                            "--pro" // build for Pro project
                        ], logBuilder, context.CancellationToken);
                    proBuildSuccess = true;
                }));
            }

            Task.WhenAll(tasks).GetAwaiter().GetResult();

            if (!buildSuccess)
            {
                ProcessHelper.Log(nameof(ESBuildGenerator),
                    $"Core ESBuild process failed\r\n{logBuilder}",
                    DiagnosticSeverity.Error,
                    context);

                return;
            }

            logBuilder.AppendLine("Core ESBuild process completed successfully.");
            logBuilder.AppendLine();

            if (_proPath is not null)
            {
                if (!proBuildSuccess)
                {
                    ProcessHelper.Log(nameof(ESBuildGenerator),
                        $"Pro ESBuild process failed\r\n{logBuilder}",
                        DiagnosticSeverity.Error,
                        context);

                    return;
                }

                logBuilder.AppendLine("Pro ESBuild process completed successfully.");
                logBuilder.AppendLine();
            }

            ProcessHelper.Log(nameof(ESBuildGenerator),
                logBuilder.ToString(),
                DiagnosticSeverity.Info,
                context);
        }
        catch (Exception ex)
        {
            ProcessHelper.Log(nameof(ESBuildGenerator),
                $"An error occurred while running ESBuild: {ex.Message}\r\n{ex.StackTrace}",
                DiagnosticSeverity.Error,
                context);

            ClearESBuildLocks(context);
        }
    }

    private void ClearESBuildLocks(SourceProductionContext context)
    {
        StringBuilder logBuilder = new();
        string rootCorePath = Path.Combine(_corePath!, "..", "..");

        _ = Task.Run(async () => await ProcessHelper.RunPowerShellScript("Clear Locks",
            rootCorePath, "esBuildClearLocks.ps1", [],
            logBuilder, context.CancellationToken));

        ProcessHelper.Log(nameof(ESBuildGenerator),
            "Cleared ESBuild Process Locks",
            DiagnosticSeverity.Info,
            context);
    }

    private static string? _corePath;
    private static string? _proPath;
    private static string? _configuration;
}