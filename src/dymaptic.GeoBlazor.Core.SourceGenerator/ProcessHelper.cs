using CliWrap;
using CliWrap.EventStream;
using Microsoft.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;


namespace dymaptic.GeoBlazor.Core.SourceGenerator;

public static class ProcessHelper
{
    public static event EventHandler<string>? Notification;
    
    /// <summary>
    ///		Executes a shell command and returns when it is complete.
    /// </summary>
    public static async Task RunCommand(string processName, string workingDirectory, string arguments,
        StringBuilder logBuilder, CancellationToken token, string? fileName = null, 
        Dictionary<string, string?>? environmentVariables = null)
    {
        // Determine the shell and arguments format based on the operating system
        fileName ??= RuntimeInformation.IsOSPlatform(OSPlatform.Windows) 
            ? "pwsh" 
            : "/bin/bash";
        
        string shellArguments = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) 
            ? $"-Command {{ {arguments} }}" 
            : RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
                ? $"-c \"{workingDirectory.TrimEnd('/')}{
                    (string.IsNullOrEmpty(workingDirectory) ? "" : "/")}{arguments}\""
                : $"-c \"{arguments}\"";

        await Execute(processName, shellArguments, workingDirectory, 
            logBuilder, token, fileName, environmentVariables);
    }
    
    public static async Task RunPowerShellScript(string processName, string workingDirectory, 
        string powershellScriptName, string arguments, StringBuilder logBuilder, CancellationToken token, 
        Dictionary<string, string?>? environmentVariables = null)
    {
        string shellArguments = $"-NoProfile -ExecutionPolicy ByPass -File \"{
            Path.Combine(workingDirectory, powershellScriptName)}\" {arguments}";
        
        await Execute(processName, shellArguments, workingDirectory, logBuilder, token, "pwsh", 
            environmentVariables);
    }

    private static async Task Execute(string processName, string shellArguments, string workingDirectory, 
        StringBuilder logBuilder, CancellationToken token, string? fileName = null, 
        Dictionary<string, string?>? environmentVariables = null)
    {
        fileName ??= shellCommand;
        
        StringBuilder outputBuilder = new();
        int? processId = null;
        int? exitCode = null;
        
        token.Register(() =>
        {
            logBuilder.AppendLine($"{processName}: Command execution cancelled.");
            logBuilder.AppendLine(outputBuilder.ToString());
            outputBuilder.Clear();
        });

        Command cmd = Cli.Wrap(fileName)
            .WithArguments(shellArguments)
            .WithWorkingDirectory(workingDirectory)
            .WithValidation(CommandResultValidation.None)
            .WithEnvironmentVariables(environmentVariables ?? new Dictionary<string, string?>());
        
        await foreach (CommandEvent cmdEvent in cmd.ListenAsync(cancellationToken: token))
        {
            switch (cmdEvent)
            {
                case StartedCommandEvent started:
                    processId = started.ProcessId;
                    outputBuilder.AppendLine($"{processName} Process started: {started.ProcessId}");
                    outputBuilder.AppendLine($"{processName} - PID {processId}: Executing command: {fileName} {shellArguments}");
                    break;
                case StandardOutputCommandEvent stdOut:
                    string line = stdOut.Text.Trim();
                    outputBuilder.AppendLine($"{processName} - PID {processId}: [stdout] {line}");
                    break;
                case StandardErrorCommandEvent stdErr:
                    outputBuilder.AppendLine($"{processName} - PID {processId}: [stderr] {stdErr.Text}");
                    break;
                case ExitedCommandEvent exited:
                    exitCode = exited.ExitCode;
                    outputBuilder.AppendLine($"{processName} - PID {processId}: Process exited with code: {exited.ExitCode}");
                    logBuilder.AppendLine(outputBuilder.ToString());
                    outputBuilder.Clear();
                    break;
            }
        }

        if (outputBuilder.Length > 0)
        {
            logBuilder.AppendLine(outputBuilder.ToString());
        }
        

        if (exitCode != 0)
        {
            logBuilder.AppendLine(outputBuilder.ToString());
            // Throw an exception if the process returned an error
            throw new Exception($"{processName}: Error executing command '{shellArguments}' for process {processId}. Exit code: {exitCode}");
        }

        // Return the standard output if the process completed normally
        logBuilder.AppendLine($"{processName}: Command '{shellArguments}' completed successfully on process {processId}.");
    }
    
    public static void Log(string title, string message, DiagnosticSeverity severity,
        SourceProductionContext context)
    {
        Notification?.Invoke(null, $"{title}: {message}");
        context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor(
            "GBSourceGen",
            title,
            message,
            "Logging",
            severity,
            isEnabledByDefault: true), Location.None));
    }
    
    public static async Task ReadStreamAsync(StreamReader reader, string prefix, StringBuilder logBuilder, 
        CancellationToken cancellationToken)
    {
        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                string? line = await reader.ReadLineAsync();
                if (line == null) break;
            
                if (!string.IsNullOrWhiteSpace(line))
                {
                    Notification?.Invoke(null, $"{prefix}: {line}");
                    logBuilder.AppendLine($"{prefix}: {line}");
                }
            }
        }
        catch when (cancellationToken.IsCancellationRequested)
        {
            // Expected when cancellation occurs
            Notification?.Invoke(null, $"{prefix}: Process was cancelled.");
            logBuilder.AppendLine($"{prefix}: Process was cancelled.");
        }
    }
    
    private const string LinuxShell = "/bin/bash";
    private const string WindowsShell = "cmd";
    private static readonly string shellCommand = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        ? WindowsShell 
        : LinuxShell;
}