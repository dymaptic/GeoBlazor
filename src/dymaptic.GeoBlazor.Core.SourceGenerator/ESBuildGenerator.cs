using dymaptic.GeoBlazor.Core.SourceGenerator.Shared;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;


namespace dymaptic.GeoBlazor.Core.SourceGenerator;

/// <summary>
///     Triggers the ESBuild build process for the GeoBlazor project, so that your JavaScript code is up to date.
/// </summary>
[Generator]
public class ESBuildGenerator : IIncrementalGenerator
{
    public static bool InProcess { get; private set; }
    
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
                    out var projectDirectory);

                configProvider.GlobalOptions.TryGetValue("build_property.Configuration",
                    out var configuration);

                configProvider.GlobalOptions.TryGetValue("build_property.PipelineBuild",
                    out var pipelineBuild);

                return (projectDirectory, configuration, pipelineBuild);
            });

        var combined =
            tsFilesProvider
                .Combine(optionsProvider)
                .Combine(context.CompilationProvider);

        context.RegisterSourceOutput(combined, FilesChanged);
    }

    private void FilesChanged(SourceProductionContext context,
        ((ImmutableArray<AdditionalText> Files,
            (string? ProjectDirectory, string? Configuration, string? PipelineBuild) Options) Data,
            Compilation Compilation) pipeline)
    {
        if (!SetProjectDirectoryAndConfiguration(pipeline.Data.Options, context))
        {
            return;
        }

        ProcessHelper.Log(nameof(ESBuildGenerator),
            "ESBuild Source Generation triggered.",
            DiagnosticSeverity.Info,
            context);

        if (pipeline.Data.Options.PipelineBuild == "true")
        {
            // If the pipeline build is enabled, we skip the ESBuild process.
            // This is to avoid race conditions where the files are not ready on time, and we do the build separately.
            ProcessHelper.Log(nameof(ESBuildGenerator),
                "Skipping ESBuild process as PipelineBuild is set to true.",
                DiagnosticSeverity.Info,
                context);

            return;
        }

        if (pipeline.Data.Files.Length > 0)
        {
            LaunchESBuild(context);   
        }
    }

    private bool SetProjectDirectoryAndConfiguration(
        (string? ProjectDirectory, string? Configuration, string? _) options,
        SourceProductionContext context)
    {
        var projectDirectory = options.ProjectDirectory;

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
        Stopwatch? sw = null;

        while (InProcess && (sw is null || sw.ElapsedMilliseconds < 5_000))
        {
            if (sw is null)
            {
                sw = new Stopwatch();
                sw.Start();
            }
            
            Thread.Sleep(100);
        }

        if (InProcess)
        {
            ProcessHelper.Log(nameof(ESBuildGenerator),
                "Another instance of the ESBuild process has been running continuously for 5 seconds.",
                DiagnosticSeverity.Error,
                context);

            return;
        }
        
        InProcess = true;
        ClearESBuildLocks(context);
        context.CancellationToken.ThrowIfCancellationRequested();

        ProcessHelper.Log(nameof(ESBuildGenerator),
            "Starting Core ESBuild process...",
            DiagnosticSeverity.Info,
            context);

        var logBuilder = new StringBuilder(DateTime.Now.ToLongTimeString());
        logBuilder.AppendLine("Starting Core ESBuild process...");

        try
        {
            List<Task> tasks = [];
            var buildSuccess = false;
            var proBuildSuccess = false;

            // gets the esBuild.ps1 script from the Core path
            tasks.Add(Task.Run(async () =>
            {
                await ProcessHelper.RunPowerShellScript("Core",
                    _corePath!, "esBuild.ps1",
                    $"-c {_configuration}", logBuilder, context.CancellationToken);
                buildSuccess = true;
            }));

            if (_proPath is not null)
            {
                logBuilder.AppendLine("Starting Pro ESBuild process...");

                tasks.Add(Task.Run(async () =>
                {
                    await ProcessHelper.RunPowerShellScript("Pro",
                        _proPath, "esProBuild.ps1",
                        $"-c {_configuration}", logBuilder, context.CancellationToken);
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
        finally
        {
            InProcess = false;
        }
    }

    private void ClearESBuildLocks(SourceProductionContext context)
    {
        StringBuilder logBuilder = new();
        string rootCorePath = Path.Combine(_corePath!, "..", "..");
        _ = Task.Run(async () => await ProcessHelper.RunPowerShellScript("Clear Locks",
            rootCorePath, "esBuildClearLocks.ps1", "", 
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