using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;


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
        IncrementalValueProvider<(string?, string?, string?, string?)> optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select((configProvider, _) =>
            {
                configProvider.GlobalOptions.TryGetValue("build_property.MSBuildProjectDirectory",
                    out string? projectDirectory);

                configProvider.GlobalOptions.TryGetValue("build_property.Configuration",
                    out string? configuration);

                configProvider.GlobalOptions.TryGetValue("build_property.PipelineBuild",
                    out string? pipelineBuild);
                
                configProvider.GlobalOptions.TryGetValue("build_property.LogESBuildOutput",
                    out string? logESBuildOutput);

                return (projectDirectory, configuration, pipelineBuild, logESBuildOutput);
            });

        context.RegisterSourceOutput(optionsProvider.Combine(jsFilesProvider), FilesChanged);
    }

    private void FilesChanged(SourceProductionContext context,
        ((string? projectDirectory, string? configuration, string? pipelineBuild, string? logESBuildOutput) OptionsConfig, 
            ImmutableArray<AdditionalText> _) pipeline)
    {
        _logESBuildOutput = pipeline.OptionsConfig.logESBuildOutput == "true";
        
        if (pipeline.OptionsConfig.pipelineBuild == "true")
        {
            // If the pipeline build is enabled, we skip the ESBuild process.
            // This is to avoid race conditions where the files are not ready on time, and we do the build separately.
            Notification?.Invoke(this, "Skipping ESBuild process as PipelineBuild is set to true.");
            Log("Skipping ESBuild process as PipelineBuild is set to true.");
            return;
        }
        
        SetProjectDirectoryAndConfiguration(pipeline.OptionsConfig);
        Log("ESBuildLauncher triggered.");
        LaunchESBuild(context);
    }

    private void SetProjectDirectoryAndConfiguration((string? projectDirectory, string? configuration, 
        string? _, string? __) options)
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
            Log("Could not parse configuration setting", true);
            throw new Exception("Invalid configuration");
        }
    }

    private void LaunchESBuild(SourceProductionContext context)
    {
        context.CancellationToken.ThrowIfCancellationRequested();
        
        Notification?.Invoke(this, "Starting Core ESBuild process...");

        StringBuilder logBuilder = new StringBuilder(DateTime.Now.ToLongTimeString());
        logBuilder.AppendLine("Starting Core ESBuild process...");

        try
        {
            List<Task> tasks = [];
            bool buildSuccess = false;
            bool proBuildSuccess = false;

            // gets the esBuild.ps1 script from the Core path
            tasks.Add(Task.Run(async () =>
                buildSuccess = await RunPowerShellScript("Core", "esBuild.ps1", _corePath!, 
                    $"-c {_configuration}", logBuilder, context.CancellationToken)));

            if (_proPath is not null)
            {
                Notification?.Invoke(this, "Starting Pro ESBuild process...");
                logBuilder.AppendLine("Starting Pro ESBuild process...");

                tasks.Add(Task.Run(async () =>
                    proBuildSuccess = await RunPowerShellScript("Pro", "esProBuild.ps1", _proPath, 
                        $"-c {_configuration}", logBuilder, context.CancellationToken)));
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

                throw new Exception($"Core ESBuild process failed.\r\n{logBuilder}");
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

                    throw new Exception($"Pro ESBuild process failed.\r\n{logBuilder}");
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
            Log(logBuilder.ToString());

            Notification?.Invoke(this, "");
            Notification?.Invoke(this, source);
        }
        catch (Exception ex)
        {
            Notification?.Invoke(this, $"An error occurred while running ESBuild: {ex.Message}");
            Notification?.Invoke(this, ex.StackTrace);

            Log($"{ex.Message}\r\n{ex.StackTrace}", true);

            throw new Exception(
                $"An error occurred while running ESBuild: {ex.Message}\n\n{logBuilder}\n\n{ex.StackTrace}", ex);
        }
    }

    private void Log(string content, bool isError = false)
    {
        if (!_logESBuildOutput && !isError)
        {
            return;
        }
        StringBuilder loggerOutput = new StringBuilder();
        // Replace multiple consecutive newlines (with optional whitespace) with a single newline
        content = Regex.Replace(content, @"\r?\n(?:\s*\r?\n)+", "\n");
        
        if (!RunPowerShellScript("Logger", "esBuildLogger.ps1", _corePath!,
                $"-c \"{content}\" -e {isError.ToString().ToLower()}", loggerOutput,
                CancellationToken.None)
            .GetAwaiter()
            .GetResult())
        {
            throw new Exception($"Failed to run the ESBuild logger script. {loggerOutput}");
        }
    }

    private async Task<bool> RunPowerShellScript(string processName, string powershellScriptName, string workingFolder, 
        string arguments, StringBuilder logBuilder, CancellationToken cancellationToken)
    {
        ProcessStartInfo processStartInfo = new()
        {
            WorkingDirectory = workingFolder,
            FileName = "pwsh",
            Arguments =
                $"-NoProfile -ExecutionPolicy ByPass -File \"{Path.Combine(workingFolder, powershellScriptName)}\" {arguments}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        
        using var process = Process.Start(processStartInfo);

        if (process == null)
        {
            Notification?.Invoke(this, $"Failed to start ESBuild process for {processName}.");
            logBuilder.AppendLine($"Failed to start ESBuild process for {processName}.");
            return false;
        }
        
        // Read both streams concurrently to avoid deadlocks
        Task outputTask = ReadStreamAsync(process.StandardOutput, $"{processName} ESBuild Output", logBuilder, cancellationToken);
        Task errorTask = ReadStreamAsync(process.StandardError, $"{processName} ESBuild Error", logBuilder, cancellationToken);
        
        try
        {
            // Use Task.Run to make the blocking WaitForExit async-friendly
            await Task.Run(() => process.WaitForExit(), cancellationToken);
            await Task.WhenAll(outputTask, errorTask);
        
            return process.ExitCode == 0;
        }
        catch (OperationCanceledException)
        {
            process.Kill();
            return false;
        }
    }
    
    private async Task ReadStreamAsync(StreamReader reader, string prefix, StringBuilder logBuilder, CancellationToken cancellationToken)
    {
        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                string? line = await reader.ReadLineAsync();
                if (line == null) break;
            
                if (!string.IsNullOrWhiteSpace(line))
                {
                    Notification?.Invoke(this, $"{prefix}: {line}");
                    logBuilder.AppendLine($"{prefix}: {line}");
                }
            }
        }
        catch when (cancellationToken.IsCancellationRequested)
        {
            // Expected when cancellation occurs
            Notification?.Invoke(this, $"{prefix}: Process was cancelled.");
            logBuilder.AppendLine($"{prefix}: Process was cancelled.");
        }
    }

    private static string? _corePath;
    private static string? _proPath;
    private static string? _configuration;
    private static bool _logESBuildOutput;
}