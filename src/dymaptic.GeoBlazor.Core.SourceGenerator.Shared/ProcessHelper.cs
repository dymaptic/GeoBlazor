using CliWrap;
using CliWrap.EventStream;
using Microsoft.CodeAnalysis;
using System.Collections.Concurrent;
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
    /// <param name="context">The SourceProductionContext for diagnostic reporting.</param>
    /// <param name="environmentVariables">Optional environment variables to set for the process.</param>
    public static async Task RunPowerShellScript(string processName, string workingDirectory,
        string powershellScriptName, string[] arguments, StringBuilder logBuilder, SourceProductionContext context,
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

        await Execute(processName, workingDirectory, "pwsh", arguments, logBuilder, context,
            environmentVariables);
    }

    /// <summary>
    ///     Executes a PowerShell command directly without a script file.
    /// </summary>
    /// <param name="processName">A descriptive name for the process, used in logging.</param>
    /// <param name="workingDirectory">The working directory for the command execution.</param>
    /// <param name="arguments">The PowerShell command to execute.</param>
    /// <param name="logBuilder">A StringBuilder to accumulate log output.</param>
    /// <param name="context">The SourceProductionContext for diagnostic reporting.</param>
    /// <param name="environmentVariables">Optional environment variables to set for the process.</param>
    public static async Task RunPowerShellCommand(string processName, string workingDirectory,
        string[] arguments, StringBuilder logBuilder, SourceProductionContext context,
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

        await Execute(processName, workingDirectory, "pwsh", arguments, logBuilder, context,
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
    /// <param name="context">The SourceProductionContext for diagnostic reporting.</param>
    /// <param name="environmentVariables">Optional environment variables to set for the process.</param>
    /// <exception cref="ProcessException">Thrown when the process exits with a non-zero exit code.</exception>
    public static async Task Execute(string processName, string workingDirectory, string? fileName,
        string[] shellArguments, StringBuilder logBuilder, SourceProductionContext context,
        Dictionary<string, string?>? environmentVariables = null)
    {
        fileName ??= shellCommand;

        StringBuilder outputBuilder = new();
        int? processId = null;
        int? exitCode = null;

        context.CancellationToken.Register(() =>
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

        await foreach (var cmdEvent in cmd.ListenAsync(context.CancellationToken))
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
            var response = logBuilder.ToString();
            Log(processName, response, DiagnosticSeverity.Info, context);

            if (response.Contains("The process cannot access the file") && (fileName == "dotnet"))
            {
                var programName = shellArguments[1]; // dotnet[fileName] run[arg[0]] ESBuild.cs[arg[1]]

                var runningProc = Process.GetProcessesByName("dotnet")
                    .FirstOrDefault(p => p.MainModule?.FileName.Contains(programName) ?? false);

                if (runningProc is not null)
                {
                    try
                    {
                        runningProc.Kill();
                        runningProc.WaitForExit();
                    }
                    catch
                    {
                        // ignore
                    }
                }

                await Task.Delay(500);

                await Execute(processName, workingDirectory, fileName, shellArguments, logBuilder, context,
                    environmentVariables);

                return;
            }

            Log(processName,
                $"Command '{fileName} {string.Join(" ", shellArguments)}' failed with exit code {exitCode}.",
                DiagnosticSeverity.Error,
                context);

            return;
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
    /// <param name="sessionId">Optional session ID to identify the console dialog instance. Each unique session ID gets its own dialog window.</param>
    public static void Log(string title, string message, DiagnosticSeverity severity,
        SourceProductionContext context, bool showConsole = false, string? sessionId = null)
    {
        if (showConsole)
        {
            ShowOrUpdateConsole(title, message, sessionId);
        }

        context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("GBSourceGen",
            title,
            message,
            "Logging",
            severity,
            isEnabledByDefault: true), Location.None));
    }

    /// <summary>
    ///     Closes the console window for the specified session.
    /// </summary>
    /// <param name="sessionId">The session ID of the console dialog to close.</param>
    public static void CloseDialog(string sessionId)
    {
        _ = Task.Run(() =>
        {
            if (!_consoleProcesses.TryRemove(sessionId, out var process))
            {
                return;
            }

            if (HasProcessExited(process))
            {
                return;
            }

            try
            {
                process.StandardInput.Flush();
                Thread.Sleep(500);
                process.StandardInput.WriteLine("exit");
                process.WaitForExit();
                process.Dispose();
            }
            catch (InvalidOperationException)
            {
                // Process was not started or has already exited - ignore
            }
        });
    }

    /// <summary>
    ///     Closes all open console windows created by <see cref="Log" />.
    /// </summary>
    public static void CloseAllDialogs()
    {
        foreach (var sessionId in _consoleProcesses.Keys.ToArray())
        {
            CloseDialog(sessionId);
        }
    }

    private static void ShowOrUpdateConsole(string title, string message, string? sessionId = null,
        [CallerFilePath] string callerFilePath = "")
    {
        // Use session ID if provided, otherwise use title as the key
        var key = sessionId ?? title;

        try
        {
            // Try to get existing process for this session
            if (_consoleProcesses.TryGetValue(key, out var existingProcess) && !HasProcessExited(existingProcess))
            {
                existingProcess.StandardInput.WriteLine(message);

                return;
            }

            // Need to create a new process - use lock to prevent race conditions
            lock (_consoleLock)
            {
                // Double-check after acquiring lock
                if (_consoleProcesses.TryGetValue(key, out existingProcess) && !HasProcessExited(existingProcess))
                {
                    existingProcess.StandardInput.WriteLine(message);

                    return;
                }

                // Remove stale process if it exists
                if (existingProcess is not null)
                {
                    _consoleProcesses.TryRemove(key, out _);

                    try
                    {
                        existingProcess.Dispose();
                    }
                    catch
                    {
                        // ignore disposal errors
                    }
                }

                var buildScriptPath = Path.GetFullPath(Path.Combine(
                    Path.GetDirectoryName(
                        callerFilePath)!, // GeoBlazor/src/dymaptic.GeoBlazor.Core.SourceGenerator.Shared
                    "..", // GeoBlazor/src
                    "..", // GeoBlazor Core repo root
                    "build-tools"));

                string[] args =
                [
                    "ConsoleDialog.dll",
                    $"\"{title}\"",
                    "-w",
                    "2"
                ];

                ProcessStartInfo startInfo = new("dotnet")
                {
                    Arguments = string.Join(" ", args),
                    WorkingDirectory = buildScriptPath,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true
                };

                var newProcess = Process.Start(startInfo);

                if (newProcess is null)
                {
                    return; // Failed to start process
                }

                newProcess.StandardInput.AutoFlush = true;
                _consoleProcesses[key] = newProcess;
                newProcess.StandardInput.WriteLine(message);
            }
        }
        catch (InvalidOperationException)
        {
            // Process failed to start or is in invalid state - remove from dictionary
            _consoleProcesses.TryRemove(key, out _);
        }
    }

    private static bool HasProcessExited(Process process)
    {
        try
        {
            return process.HasExited;
        }
        catch (InvalidOperationException)
        {
            return true; // Process was never started or is in invalid state
        }
    }

    private static readonly string shellCommand = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        ? WindowsShell
        : LinuxShell;

    private static readonly ConcurrentDictionary<string, Process> _consoleProcesses = new();
    private static readonly object _consoleLock = new();

    private const string LinuxShell = "/bin/bash";
    private const string WindowsShell = "cmd";
}

/// <summary>
///     Exception thrown when an external process execution fails.
/// </summary>
/// <param name="message">The error message describing the failure.</param>
public class ProcessException(string message) : Exception(message);