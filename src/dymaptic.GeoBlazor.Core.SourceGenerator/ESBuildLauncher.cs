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
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValueProvider<ImmutableArray<AdditionalText>> provider = context.AdditionalTextsProvider
            .Where(static text => text.Path.Contains("Scripts") && text.Path.EndsWith(".ts"))
            .Collect();
        
        IncrementalValueProvider<(string?, string?)> optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select((configProvider, _) =>
            {
                configProvider.GlobalOptions.TryGetValue("build_property.MSBuildProjectDirectory",
                    out string? projectDirectory);

                configProvider.GlobalOptions.TryGetValue("build_property.Configuration",
                    out string? configuration);
                
                return (projectDirectory, configuration);
            });
        
        context.RegisterSourceOutput(optionsProvider, SetProjectDirectoryAndConfiguration);
        context.RegisterSourceOutput(provider, LaunchESBuild);
    }

    private void SetProjectDirectoryAndConfiguration(SourceProductionContext sourceProductionContext, 
        (string? projectDirectory, string? configuration) options)
    {
        if (options.projectDirectory is { } projectDirectory)
        {
            _corePath = Path.GetFullPath(projectDirectory);
            if (_corePath.Contains("GeoBlazor.Pro"))
            {
                // we are inside the Pro submodule, we can also set the Pro path
                _proPath = Path.GetFullPath(Path.Combine(_corePath, "..", "..", "..", "src", 
                    "dymaptic.GeoBlazor.Pro"));
            }
        }
        
        if (options.configuration is { } configuration)
        {
            _configuration = configuration;
        }
    }

    private void LaunchESBuild(SourceProductionContext context, ImmutableArray<AdditionalText> files)
    {
        // This will trigger the ESBuild build process.
        // The actual build is done in the dymaptic.GeoBlazor.Core project.
        // This is just a trigger to ensure that the build is done when the source generator is run.
        context.CancellationToken.ThrowIfCancellationRequested();

        try
        {
            StringBuilder results = new("Starting Core ESBuild process...");
            results.AppendLine();

            if (_proPath is null)
            {
                ProcessStartInfo processStartInfo = new()
                {
                    FileName = "pwsh",
                    Arguments = $"-NoProfile -ExecutionPolicy ByPass -File \"{Path.Combine(_corePath!, "npmBuild.ps1")}\"{(
                        string.Equals(_configuration, "Release", StringComparison.OrdinalIgnoreCase) ? " -release" : string.Empty)}",
                    WorkingDirectory = _corePath!,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var process = Process.Start(processStartInfo);

                if (process == null)
                {
                    context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("GB0001", "ESBuild Error",
                            "Failed to start ESBuild process.", "Build",
                            DiagnosticSeverity.Error, true),
                        Location.None));

                    return;
                }

                while (!process.StandardOutput.EndOfStream
                    && !context.CancellationToken.IsCancellationRequested
                    && !process.HasExited)
                {
                    string line = process.StandardOutput.ReadLine()
                        ?? process.StandardError.ReadLine()
                        ?? string.Empty;

                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        results.AppendLine(line);
                    }
                }

                if (!process.StandardOutput.EndOfStream)
                {
                    results.AppendLine(process.StandardOutput.ReadLine());
                }

                if (!process.StandardError.EndOfStream)
                {
                    results.AppendLine(process.StandardError.ReadLine());
                }
            }
            else
            {
                string proScriptPath = Path.Combine(_proPath, "coreTypeScriptCopy.ps1");
                
                ProcessStartInfo proStartInfo = new()
                {
                    FileName = "pwsh",
                    Arguments = $"-NoProfile -ExecutionPolicy ByPass -File \"{proScriptPath}\" -build{(
                        string.Equals(_configuration, "Release", StringComparison.OrdinalIgnoreCase) ? " -release" : string.Empty)}",
                    WorkingDirectory = _proPath,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                results.AppendLine();
                results.AppendLine("Starting Pro ESBuild process...");
                
                var proProcess = Process.Start(proStartInfo);

                if (proProcess == null)
                {
                    context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("GB0001", "ESBuild Error",
                            "Failed to start ESBuild process.", "Build",
                            DiagnosticSeverity.Error, true),
                        Location.None));

                    return;
                }

                while (!proProcess.StandardOutput.EndOfStream
                    && !context.CancellationToken.IsCancellationRequested
                    && !proProcess.HasExited)
                {
                    string line = proProcess.StandardOutput.ReadLine()
                        ?? proProcess.StandardError.ReadLine()
                        ?? string.Empty;

                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        results.AppendLine(line);
                    }
                }

                if (!proProcess.StandardOutput.EndOfStream)
                {
                    results.AppendLine(proProcess.StandardOutput.ReadLine());
                }

                if (!proProcess.StandardError.EndOfStream)
                {
                    results.AppendLine(proProcess.StandardError.ReadLine());
                }
            }
            
            Process gitBranchProc = Process.Start(new  ProcessStartInfo
            {
                WorkingDirectory = _corePath!,
                FileName = "git",
                Arguments = "rev-parse --abbrev-ref HEAD",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            })!;
            
            string? gitBranch = gitBranchProc.StandardOutput.ReadLine()?.Trim();

            results.AppendLine();
            
            results.AppendLine($"ESBuild completed successfully for branch '{gitBranch}' with configuration '{_configuration}'.");

            string source = $$"""
                              /// <auto-generated/>

                              namespace dymaptic.GeoBlazor.Core;

                              internal class ESBuildRecord
                              {
                                  private const long Timestamp = {{DateTime.UtcNow.Ticks}};
                                  private const string GitBranch = "{{gitBranch}}";
                                  private const string Configuration = "{{_configuration}}";
                                  private const bool IncludeProBuild = {{(_proPath is not null).ToString().ToLower()}};
                              }
                              """;
            
            context.AddSource("ESBuildRecord.g.cs", source);
            
            results.AppendLine();
            results.AppendLine(source);
            
            context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("GB0000", "ESBuild Results",
                    $"ESBuild completed successfully.\n\n{results}", 
                    "Build",
                    DiagnosticSeverity.Info, true),
                Location.None));
        }
        catch (Exception e)
        {
            context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("GB0002", "ESBuild Error",
                    $"An error occurred while running ESBuild: {e.Message}", "Build",
                    DiagnosticSeverity.Error, true),
                Location.None));
        }
    }

    private static string? _corePath;
    private static string? _proPath;
    private static string? _configuration;
}