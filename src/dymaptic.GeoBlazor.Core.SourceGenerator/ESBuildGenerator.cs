using dymaptic.GeoBlazor.Core.SourceGenerator.Shared;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;


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
        : Path.GetFullPath(Path.Combine(_corePath, "..", "..", "build-tools", $"{os}-{arch}"));

    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Tracks all TypeScript source files in the Scripts directories of Core and Pro.
        // This will trigger the build any time a TypeScript file is added, removed, or changed.
        var tsFilesProvider = context
            .AdditionalTextsProvider
            .Where(static text => text.Path.Contains("Scripts")
                && text.Path.EndsWith(".ts"))
            .Collect();

        // Reads the MSBuild properties to get the project directory and configuration.
        var optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select((configProvider, _) =>
            {
                Dictionary<string, string> options = [];

                if (configProvider.GlobalOptions.TryGetValue("build_property.CoreProjectPath",
                    out var projectDirectory))
                {
                    options["CoreProjectPath"] = projectDirectory;
                }

                if (configProvider.GlobalOptions.TryGetValue("build_property.Configuration",
                    out var configuration))
                {
                    options["Configuration"] = configuration;
                }

                if (configProvider.GlobalOptions.TryGetValue("build_property.DesignTimeBuild",
                    out var designTimeBuild))
                {
                    options["DesignTimeBuild"] = designTimeBuild;
                }

                if (configProvider.GlobalOptions.TryGetValue("build_property.ShowSourceGenDialogs",
                    out var showDialog))
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

        if (!_isDesignTimeBuild)
        {
            // If this is a full compilation, we call ESBuild directly from Core.csproj earlier in the process,
            // so we want to exit out here.
            ProcessHelper.Log(nameof(ESBuildGenerator),
                "ESBuild Source Generation skipped during full compilation.",
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
            ProcessHelper.CloseDialog(_proSessionId);
        }
    }

    private bool SetProjectDirectoryAndConfiguration(Dictionary<string, string> options,
        SourceProductionContext context)
    {
        if (options.TryGetValue("CoreProjectPath", out var projectDirectory))
        {
            _corePath = Path.GetFullPath(projectDirectory);

            if (_corePath.Contains("GeoBlazor.Pro"))
            {
                // we are inside the Pro submodule, we should also set the Pro path to build the Pro JavaScript files
                var path = _corePath;

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

        if (options.TryGetValue("Configuration", out var configuration))
        {
            _configuration = configuration;

            if (options.TryGetValue("DesignTimeBuild", out var designTimeBuild)
                && bool.TryParse(designTimeBuild, out var designTimeBuildBool))
            {
                _isDesignTimeBuild = designTimeBuildBool;
            }

            if (options.TryGetValue("ShowSourceGenDialogs", out var showDialog)
                && bool.TryParse(showDialog, out var showDialogBool))
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
            var buildSuccess = false;
            var proBuildSuccess = false;

            // gets the ESBuild.cs script
            List<string> esBuildArgs =
            [
                "ESBuild.dll",
                "-c", _configuration! // set config for ESBuild
            ];

            tasks.Add(Task.Run(async () =>
            {
                var coreArgs = esBuildArgs.ToArray();

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
                    context, _showDialog, _proSessionId);

                string[] proArgs = [..esBuildArgs, "--pro"];

                tasks.Add(Task.Run(async () =>
                {
                    await ProcessHelper.Execute("Pro",
                        BuildToolsPath!, "dotnet",
                        proArgs, context, _showDialog, _proSessionId);
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
                        context, _showDialog, _proSessionId);
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
        var clearTask = Task.Run(async () => await ProcessHelper.Execute("Clear Locks",
            BuildToolsPath!, "dotnet",
            ["ESBuildClearLocks.dll"],
            context, _showDialog, _sessionId));

        clearTask.GetAwaiter().GetResult();

        ProcessHelper.Log(nameof(ESBuildGenerator),
            "Cleared ESBuild Process Locks",
            DiagnosticSeverity.Info,
            context, _showDialog, _sessionId);
    }

    private static readonly string os = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        ? "win"
        : RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
            ? "osx"
            : "linux";
    private static readonly string arch = RuntimeInformation.OSArchitecture.ToString().ToLowerInvariant();

    private static string? _corePath;
    private static string? _proPath;
    private static string? _configuration;
    private static bool _isDesignTimeBuild;
    private static bool _showDialog;

    // Generate a unique session ID for this build session
    private readonly string _sessionId = $"{nameof(ESBuildGenerator)}_{Guid.NewGuid():N}";
    private readonly string _proSessionId = $"{nameof(ESBuildGenerator)}_{Guid.NewGuid():N}";
}