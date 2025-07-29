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
    
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Tracks all TypeScript source files in the Scripts directories of Core and Pro.
        // This will trigger the build any time a TypeScript file is added, removed, or changed.
        IncrementalValueProvider<ImmutableArray<AdditionalText>> jsFilesProvider = context.AdditionalTextsProvider
            .Where(static text => text.Path.Contains("Scripts") && text.Path.EndsWith(".ts"))
            .Collect();

        // Reads the MSBuild properties to get the project directory and configuration.
        IncrementalValueProvider<(string?, string?)> optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select((configProvider, _) =>
            {
                configProvider.GlobalOptions.TryGetValue("build_property.MSBuildProjectDirectory",
                    out string? projectDirectory);

                configProvider.GlobalOptions.TryGetValue("build_property.Configuration",
                    out string? configuration);

                return (projectDirectory, configuration);
            });

        context.RegisterSourceOutput(optionsProvider.Combine(jsFilesProvider), FilesChanged);
    }

    private void FilesChanged(SourceProductionContext context,
        ((string?, string?) OptionsConfig, ImmutableArray<AdditionalText> _) pipeline)
    {
        SetProjectDirectoryAndConfiguration(pipeline.OptionsConfig);
        LaunchESBuild(context);
    }

    private void SetProjectDirectoryAndConfiguration((string? projectDirectory, string? configuration) options)
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
            throw new Exception("Invalid project directory");
        }

        if (options.configuration is { } configuration)
        {
            _configuration = configuration;
        }
        else
        {
            throw new Exception("Invalid configuration");
        }
    }

    private void LaunchESBuild(SourceProductionContext context)
    {
        context.CancellationToken.ThrowIfCancellationRequested();
        
        Notification?.Invoke(this, "Starting Core ESBuild process...");

        StringBuilder logBuilder = new StringBuilder();
        try
        {
            List<Task> tasks = [];
            bool buildSuccess = false;
            bool proBuildSuccess = false;
            
            // gets the esBuild.ps1 script from the Core path
            ProcessStartInfo processStartInfo = new()
            {
                FileName = "pwsh",
                Arguments = $"-NoProfile -ExecutionPolicy ByPass -File \"{Path.Combine(_corePath!, "esBuild.ps1")}\" -c {_configuration}",
                WorkingDirectory = _corePath!,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            
            tasks.Add(Task.Run(async () => 
                buildSuccess = await RunProcess("Core", processStartInfo, logBuilder, context.CancellationToken)));

            if (_proPath is not null)
            {
                string proScriptPath = Path.Combine(_proPath, "esProBuild.ps1");

                ProcessStartInfo proStartInfo = new()
                {
                    FileName = "pwsh",
                    Arguments = $"-NoProfile -ExecutionPolicy ByPass -File \"{proScriptPath}\" -c {_configuration}",
                    WorkingDirectory = _proPath,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Notification?.Invoke(this, "Starting Pro ESBuild process...");
                logBuilder.AppendLine("Starting Pro ESBuild process...");

                tasks.Add(Task.Run(async() => 
                    proBuildSuccess = await RunProcess("Pro", proStartInfo, logBuilder, context.CancellationToken)));
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
                Notification?.Invoke(this, "Core ESBuild process failed");
                throw new Exception("Core ESBuild process failed. Check the output for details.");
            }
            
            Notification?.Invoke(this, "Core ESBuild process completed successfully.");
            Notification?.Invoke(this, "");
            logBuilder.AppendLine("Core ESBuild process completed successfully.");
            logBuilder.AppendLine();

            if (_proPath is not null)
            {
                if (!proBuildSuccess)
                {
                    Notification?.Invoke(this, "Pro ESBuild process failed");
                    throw new Exception("Pro ESBuild process failed. Check the output for details.");
                }
                
                Notification?.Invoke(this, "Pro ESBuild process completed successfully.");
                Notification?.Invoke(this, "");
                logBuilder.AppendLine("Pro ESBuild process completed successfully.");
                logBuilder.AppendLine();
            }

            if (string.IsNullOrEmpty(gitBranch))
            {
                Notification?.Invoke(this, "Could not determine the current Git branch. " +
                    "This may affect the generated ESBuildRecord class.");
                logBuilder.AppendLine("Could not determine the current Git branch. " +
                    "This may affect the generated ESBuildRecord class.");
                gitBranch = "unknown";
            }
            
            Notification?.Invoke(this,
                $"ESBuild completed successfully for branch '{gitBranch}' with configuration '{_configuration}'.");
            logBuilder.AppendLine($"ESBuild completed successfully for branch '{gitBranch}' with configuration '{_configuration}'.");

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
            
            Notification?.Invoke(this, "");
            Notification?.Invoke(this, source);
        }
        catch (Exception ex)
        {
            Notification?.Invoke(this, $"An error occurred while running ESBuild: {ex.Message}");
            Notification?.Invoke(this, ex.StackTrace);

            throw new Exception($"An error occurred while running ESBuild: {ex.Message}\n\n{logBuilder}\n\n{ex.StackTrace}", ex);
        }
    }

    private async Task<bool> RunProcess(string processName, ProcessStartInfo processStartInfo, StringBuilder logBuider, 
        CancellationToken cancellationToken)
    {
        var process = Process.Start(processStartInfo);

        if (process == null)
        {
            Notification?.Invoke(this, $"Failed to start ESBuild process for {processName}.");
            logBuider.AppendLine($"Failed to start ESBuild process for {processName}.");
            return false;
        }

        while (!process.StandardOutput.EndOfStream
            && !cancellationToken.IsCancellationRequested
            && !process.HasExited)
        {
            string line = await process.StandardOutput.ReadLineAsync()
                ?? await process.StandardError.ReadLineAsync()
                ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(line))
            {
                Notification?.Invoke(this, $"{processName} ESBuild Output: {line}");
                logBuider.AppendLine($"{processName} ESBuild Output: {line}");
            }
        }
        
        process.WaitForExit();

        if (cancellationToken.IsCancellationRequested)
        {
            return false;
        }

        if (!process.StandardOutput.EndOfStream)
        {
            string line = await process.StandardOutput.ReadToEndAsync();
            Notification?.Invoke(this, $"{processName} ESBuild Output: {line}");
            logBuider.AppendLine($"{processName} ESBuild Output: {line}");
        }

        if (!process.StandardError.EndOfStream)
        {
            string line = await process.StandardError.ReadToEndAsync();
            Notification?.Invoke(this, $"{processName} ESBuild Error: {line}");
            logBuider.AppendLine($"{processName} ESBuild Error: {line}");
        }
            
        return process.ExitCode == 0;
    }

    private static string? _corePath;
    private static string? _proPath;
    private static string? _configuration;
}