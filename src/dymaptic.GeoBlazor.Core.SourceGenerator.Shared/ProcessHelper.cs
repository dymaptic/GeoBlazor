using CliWrap;
using CliWrap.EventStream;
using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;


namespace dymaptic.GeoBlazor.Core.SourceGenerator.Shared;

/// <summary>
///     Provides helper methods for executing external processes, PowerShell scripts, and logging diagnostics.
/// </summary>
public static class ProcessHelper
{
    /// <summary>
    ///     Executes a PowerShell script file with the specified arguments.
    /// </summary>
    /// <param name="processName">A descriptive name for the process, used in logging.</param>
    /// <param name="workingDirectory">The working directory for the script execution.</param>
    /// <param name="powershellScriptName">The name of the PowerShell script file to execute.</param>
    /// <param name="arguments">Command-line arguments to pass to the script.</param>
    /// <param name="logBuilder">A StringBuilder to accumulate log output.</param>
    /// <param name="token">A cancellation token to cancel the operation.</param>
    /// <param name="environmentVariables">Optional environment variables to set for the process.</param>
    public static async Task RunPowerShellScript(string processName, string workingDirectory,
        string powershellScriptName, string[] arguments, StringBuilder logBuilder, CancellationToken token,
        Dictionary<string, string?>? environmentVariables = null)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            arguments =
            [
                "-NoProfile",
                "-ExecutionPolicy",
                "ByPass",
                "-File",
                Path.Combine(workingDirectory, powershellScriptName),
                ..arguments
            ];
        }
        else
        {
            arguments =
            [
                Path.Combine(workingDirectory, powershellScriptName),
                ..arguments
            ];
        }

        await Execute(processName, workingDirectory, "pwsh", arguments, logBuilder, token,
            environmentVariables);
    }

    /// <summary>
    ///     Executes a PowerShell command directly without a script file.
    /// </summary>
    /// <param name="processName">A descriptive name for the process, used in logging.</param>
    /// <param name="workingDirectory">The working directory for the command execution.</param>
    /// <param name="arguments">The PowerShell command to execute.</param>
    /// <param name="logBuilder">A StringBuilder to accumulate log output.</param>
    /// <param name="token">A cancellation token to cancel the operation.</param>
    /// <param name="environmentVariables">Optional environment variables to set for the process.</param>
    public static async Task RunPowerShellCommand(string processName, string workingDirectory,
        string[] arguments, StringBuilder logBuilder, CancellationToken token,
        Dictionary<string, string?>? environmentVariables = null)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            arguments =
            [
                "-NoProfile",
                "-ExecutionPolicy",
                "ByPass",
                "-Command",
                "{",
                ..arguments,
                "}"
            ];
        }

        await Execute(processName, workingDirectory, "pwsh", arguments, logBuilder, token,
            environmentVariables);
    }

    /// <summary>
    ///     Executes an external process with the specified arguments and captures its output.
    /// </summary>
    /// <param name="processName">A descriptive name for the process, used in logging.</param>
    /// <param name="workingDirectory">The working directory for the process execution.</param>
    /// <param name="fileName">The executable file name. If null, uses the platform-specific shell command.</param>
    /// <param name="shellArguments">Command-line arguments to pass to the process.</param>
    /// <param name="logBuilder">A StringBuilder to accumulate log output.</param>
    /// <param name="token">A cancellation token to cancel the operation.</param>
    /// <param name="environmentVariables">Optional environment variables to set for the process.</param>
    /// <exception cref="ProcessException">Thrown when the process exits with a non-zero exit code.</exception>
    public static async Task Execute(string processName, string workingDirectory, string? fileName,
        string[] shellArguments, StringBuilder logBuilder, CancellationToken token,
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
                    outputBuilder.AppendLine($" - {processName} Process started: {started.ProcessId}");

                    outputBuilder.AppendLine($" - {processName} - PID {processId}: Executing command: {fileName} {
                        string.Join(" ", shellArguments)}");

                    break;
                case StandardOutputCommandEvent stdOut:
                    string line = stdOut.Text.Trim();
                    outputBuilder.AppendLine($" - {processName} - PID {processId}: [stdout] {line}");

                    break;
                case StandardErrorCommandEvent stdErr:
                    outputBuilder.AppendLine($" - {processName} - PID {processId}: [stderr] {stdErr.Text}");

                    break;
                case ExitedCommandEvent exited:
                    exitCode = exited.ExitCode;

                    outputBuilder.AppendLine($" - {processName} - PID {processId}: Process exited with code: {
                        exited.ExitCode}");

                    break;
            }
        }

        // Append any accumulated output to the log
        if (outputBuilder.Length > 0)
        {
            logBuilder.AppendLine(outputBuilder.ToString());
        }

        if (exitCode != 0)
        {
            throw new ProcessException($"{processName}: Error executing command '{string.Join(" ", shellArguments)
            }' for process {
                processId}. Exit code: {exitCode}");
        }

        // Return the standard output if the process completed normally
        logBuilder.AppendLine($" - {processName}: Command '{string.Join(" ", shellArguments)
        }' completed successfully on process {processId
        }.");
    }

    /// <summary>
    ///     Logs a diagnostic message to the source generator context.
    /// </summary>
    /// <param name="title">The title of the diagnostic message.</param>
    /// <param name="message">The diagnostic message content.</param>
    /// <param name="severity">The severity level of the diagnostic.</param>
    /// <param name="context">The source production context to report the diagnostic to.</param>
    /// <param name="showConsole">Whether to show a popup console window with the message</param>
    public static void Log(string title, string message, DiagnosticSeverity severity,
        SourceProductionContext context, bool showConsole = false)
    {
        if (showConsole)
        {
            ShowOrUpdateConsole(title, message);
        }

        context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("GBSourceGen",
            title,
            message,
            "Logging",
            severity,
            isEnabledByDefault: true), Location.None));
    }

    /// <summary>
    ///     Closes any open console window created by <see cref="Log"/>.
    /// </summary>
    public static void CloseDialog()
    {
        _ = Task.Run(() =>
        {
            if (_consoleProcess is null)
            {
                return;
            }

            _consoleProcess.StandardInput.Flush();
            Thread.Sleep(500);
            _consoleProcess.StandardInput.WriteLine("exit");
            _consoleProcess.WaitForExit();
            _consoleProcess.Dispose();
        });
    }

    private static void ShowOrUpdateConsole(string title, string message,
        [CallerFilePath] string callerFilePath = "")
    {
        if (_consoleProcess is null)
        {
            string buildScriptPath = Path.GetFullPath(Path.Combine(
                Path.GetDirectoryName(callerFilePath)!, // GeoBlazor/src/dymaptic.GeoBlazor.Core.SourceGenerator.Shared
                "..", // GeoBlazor/src 
                "..", // GeoBlazor Core repo root
                "build"));

            string[] args =
            [
                "ConsoleDialog.cs",
                title
            ];

            ProcessStartInfo startInfo = new("dotnet")
            {
                Arguments = string.Join(" ", args),
                WorkingDirectory = buildScriptPath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                CreateNoWindow = true,
            };

            _consoleProcess = Process.Start(startInfo);
            _consoleProcess!.StandardInput.AutoFlush = true;
        }

        _consoleProcess.StandardInput.WriteLine(message);
    }

    private static readonly string shellCommand = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        ? WindowsShell
        : LinuxShell;

    private static Process? _consoleProcess;

    private const string LinuxShell = "/bin/bash";
    private const string WindowsShell = "cmd";
}

/// <summary>
///     Exception thrown when an external process execution fails.
/// </summary>
/// <param name="message">The error message describing the failure.</param>
public class ProcessException(string message) : Exception(message);