using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;


namespace dymaptic.GeoBlazor.Core.SourceGenerator;

/// <summary>
///     Triggers the ESBuild build process for the GeoBlazor project, so that your JavaScript code is up to date.
/// </summary>
[Generator]
public class ESBuildLauncher : IIncrementalGenerator
{
    // Notifications are only used for the unit tests, source generators are not intended to have logging/output typically.
    public event EventHandler<string>? Notification;

    public void PassNotification(object? _, string message)
    {
        Notification?.Invoke(this, message);
    }
    
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        ProcessHelper.Notification += PassNotification;
        
        // Tracks all TypeScript source files in the Scripts directories of Core and Pro.
        // This will trigger the build any time a TypeScript file is added, removed, or changed.
        IncrementalValueProvider<ImmutableArray<AdditionalText>> jsFilesProvider = context.AdditionalTextsProvider
            .Where(static text => text.Path.Contains("Scripts") && text.Path.EndsWith(".ts"))
            .Collect();

        // Reads the MSBuild properties to get the project directory and configuration.
        IncrementalValueProvider<(string?, string?, string?)> optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select((configProvider, _) =>
            {
                configProvider.GlobalOptions.TryGetValue("build_property.MSBuildProjectDirectory",
                    out string? projectDirectory);

                configProvider.GlobalOptions.TryGetValue("build_property.Configuration",
                    out string? configuration);

                configProvider.GlobalOptions.TryGetValue("build_property.PipelineBuild",
                    out string? pipelineBuild);

                return (projectDirectory, configuration, pipelineBuild);
            });

        context.RegisterSourceOutput(optionsProvider.Combine(jsFilesProvider), FilesChanged);
        ProcessHelper.Notification -= PassNotification;
    }

    private void FilesChanged(SourceProductionContext context,
        ((string? projectDirectory, string? configuration, string? pipelineBuild) OptionsConfig, 
            ImmutableArray<AdditionalText> _) pipeline)
    {
        if (pipeline.OptionsConfig.pipelineBuild == "true")
        {
            // If the pipeline build is enabled, we skip the ESBuild process.
            // This is to avoid race conditions where the files are not ready on time, and we do the build separately.
            ProcessHelper.Log(nameof(ESBuildLauncher), 
                "Skipping ESBuild process as PipelineBuild is set to true.", 
                DiagnosticSeverity.Info,
                context);
            return;
        }

        if (!SetProjectDirectoryAndConfiguration(pipeline.OptionsConfig, context))
        {
            return;
        }

        ProcessHelper.Log(nameof(ESBuildLauncher),
            "ESBuildLauncher triggered.", 
            DiagnosticSeverity.Info,
            context);
        LaunchESBuild(context);
    }

    private bool SetProjectDirectoryAndConfiguration((string? projectDirectory, string? configuration, string? _) options,
        SourceProductionContext context)
    {
        if (options.projectDirectory is { } projectDirectory)
        {
            _corePath = Path.GetFullPath(projectDirectory);

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
            ProcessHelper.Log(nameof(ESBuildLauncher),
                "Invalid project directory.",
                DiagnosticSeverity.Error,
                context);

            return false;
        }

        if (options.configuration is { } configuration)
        {
            _configuration = configuration;

            return true;
        }

        ProcessHelper.Log(nameof(ESBuildLauncher),
            "Could not parse configuration setting, invalid configuration.",
            DiagnosticSeverity.Error,
            context);

        return false;
    }

    private void LaunchESBuild(SourceProductionContext context)
    {
        context.CancellationToken.ThrowIfCancellationRequested();
        
        ProcessHelper.Log(nameof(ESBuildLauncher), 
            "Starting Core ESBuild process...", 
            DiagnosticSeverity.Info,
            context);

        StringBuilder logBuilder = new StringBuilder(DateTime.Now.ToLongTimeString());
        logBuilder.AppendLine("Starting Core ESBuild process...");

        try
        {
            List<Task> tasks = [];
            bool buildSuccess = false;
            bool proBuildSuccess = false;

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

            string gitBranch = string.Empty;

            Process gitBranchProc = Process.Start(new ProcessStartInfo
            {
                WorkingDirectory = _corePath!,
                FileName = "git",
                Arguments = "rev-parse --abbrev-ref HEAD",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            })!;

            tasks.Add(Task.Run(async () =>
                gitBranch = (await gitBranchProc.StandardOutput.ReadLineAsync())?.Trim() ?? string.Empty));

            Task.WhenAll(tasks).GetAwaiter().GetResult();

            if (!buildSuccess)
            {
                ProcessHelper.Log(nameof(ESBuildLauncher),
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
                    ProcessHelper.Log(nameof(ESBuildLauncher),
                        $"Pro ESBuild process failed\r\n{logBuilder}",
                        DiagnosticSeverity.Error,
                        context);
                    return;
                }
                
                logBuilder.AppendLine("Pro ESBuild process completed successfully.");
                logBuilder.AppendLine();
            }

            if (string.IsNullOrEmpty(gitBranch))
            {
                logBuilder.AppendLine("Could not determine the current Git branch. " +
                    "This may affect the generated ESBuildRecord class.");
                gitBranch = "unknown";
            }

            logBuilder.AppendLine($"ESBuild completed successfully for branch '{gitBranch}' with configuration '{
                _configuration}'.");

            string source = $$"""
                              // <auto-generated/>

                              namespace dymaptic.GeoBlazor.Core;

                              /// <summary>
                              ///     This class is generated by a source generator and contains metadata about the build.
                              /// </summary>
                              internal class ESBuildRecord
                              {
                                  private const long Timestamp = {{DateTime.UtcNow.Ticks}};
                                  private const string GitBranch = "{{gitBranch}}";
                                  private const string Configuration = "{{_configuration}}";
                                  private const bool IncludeProBuild = {{(_proPath is not null).ToString().ToLower()}};
                              }
                              """;

            context.AddSource("ESBuildRecord.g.cs", source);
            logBuilder.AppendLine();
            logBuilder.AppendLine(source);
            ProcessHelper.Log(nameof(ESBuildLauncher),
                logBuilder.ToString(),
                DiagnosticSeverity.Info,
                context);

            Notification?.Invoke(this, "");
            Notification?.Invoke(this, source);
        }
        catch (Exception ex)
        {
            ProcessHelper.Log(nameof(ESBuildLauncher),
                $"An error occurred while running ESBuild: {ex.Message}\r\n{ex.StackTrace}", 
                DiagnosticSeverity.Error,
                context);
        }
    }

    private static string? _corePath;
    private static string? _proPath;
    private static string? _configuration;
}