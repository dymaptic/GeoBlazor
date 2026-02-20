using Polly;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace Utilities;

public static partial class ProcessRunner
{
    /// <summary>
    ///     Runs an npm command using PowerShell 7 for cross-platform compatibility.
    ///     Output is captured and also written to the Trace listeners.
    /// </summary>
    /// <param name="workingDirectory">The directory to run the command in.</param>
    /// <param name="command">The npm command (e.g., "install", "run build").</param>
    /// <param name="environmentVariables">Environment variables to set for the process.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
    /// <param name="args">Additional arguments to pass to the command.</param>
    public static Task RunNpmCommand(string workingDirectory, string command,
        Dictionary<string, string>? environmentVariables = null,
        CancellationToken cancellationToken = default, params IEnumerable<string> args)
    {
        return RunCommand(workingDirectory, "pwsh", "-Command",
            environmentVariables, cancellationToken,
            ["Error", "Warning"],
            $"\"npm {command} {string.Join(" ", args.Where(a => !string.IsNullOrWhiteSpace(a)))}\"");
    }

    /// <summary>
    ///     Runs a dotnet command without capturing output.
    /// </summary>
    /// <param name="workingDirectory">The working directory for the command.</param>
    /// <param name="command">The dotnet command (e.g., "build", "restore", "clean").</param>
    /// <param name="environmentVariables">Environment variables to set for the process.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
    /// <param name="args">Additional arguments to pass to the command.</param>
    public static Task RunDotnetCommand(string workingDirectory, string command,
        Dictionary<string, string>? environmentVariables = null,
        CancellationToken cancellationToken = default, params IEnumerable<string> args)
    {
        // make sure there is a space after the word "Error" to avoid false positives on output like "0 Error(s)"
        return RunCommand(workingDirectory, "dotnet", command, environmentVariables, cancellationToken,
            ["Build FAILED", "Error "], args);
    }

    /// <summary>
    ///     Runs a dotnet command without capturing output.
    /// </summary>
    /// <param name="workingDirectory">The working directory for the command.</param>
    /// <param name="fileName">The executable file name (e.g., "dotnet").</param>
    /// <param name="command">The dotnet command (e.g., "build", "restore", "clean").</param>
    /// <param name="environmentVariables">Environment variables to set for the process.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
    /// <param name="failureTriggerWords">Words in output that should trigger a failure.</param>
    /// <param name="args">Additional arguments to pass to the command.</param>
    public static async Task RunCommand(string workingDirectory, string fileName, string command,
        Dictionary<string, string>? environmentVariables, CancellationToken cancellationToken,
        string[] failureTriggerWords, params IEnumerable<string> args)
    {
        Stopwatch sw = new();
        sw.Start();
        string arguments = $"{command} {string.Join(" ", args.Where(a => !string.IsNullOrWhiteSpace(a)))}";

        int windowWidth = GbCli.GetWindowWidth();
        environmentVariables ??= [];
        environmentVariables["CONSOLE_WIDTH"] = windowWidth.ToString();

        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            foreach (var kvp in environmentVariables)
            {
                psi.Environment[kvp.Key] = kvp.Value;
            }

            await LaunchResilientTask($"dotnet {arguments}", async _ =>
            {
                using var process = Process.Start(psi);
                bool lineWasEmpty = false;

                if (process != null)
                {
                    process.OutputDataReceived += (_, e) =>
                    {
                        if (e.Data != null)
                        {
                            string line = e.Data;

                            Console.Write("| ");

                            if (stepHeaderRegex.Match(line) is { Success: true } headerMatch && lineWasEmpty)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                string header = headerMatch.Groups["header"].Value;
                                string timestamp = headerMatch.Groups["timestamp"].Value;
                                int buffer = windowWidth - header.Length - timestamp.Length - 3;

                                while (buffer < 0)
                                {
                                    buffer += windowWidth;
                                }

                                Console.WriteLine($"{header}{new string(' ', buffer)}{timestamp}");
                            }
                            else if (stepFooterRegex.Match(line) is { Success: true } footerMatch)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.White;
                                string footer = footerMatch.Groups["footer"].Value;
                                int buffer = windowWidth - footer.Length - 3;

                                while (buffer < 0)
                                {
                                    buffer += windowWidth;
                                }

                                Console.WriteLine($"{footer}{new string(' ', buffer)}");
                            }
                            else
                            {
                                Console.WriteLine(line);
                            }

                            Console.ResetColor();

                            lineWasEmpty = string.IsNullOrEmpty(line);

                            foreach (var triggerWord in failureTriggerWords)
                            {
                                if (e.Data.Contains(triggerWord, StringComparison.OrdinalIgnoreCase))
                                {
                                    throw new TaskFailureException($"Detected failure word '{triggerWord}' in output of process {psi.FileName} {psi.Arguments}.");
                                }
                            }
                        }
                    };

                    process.ErrorDataReceived += (_, e) =>
                    {
                        if (e.Data != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"| {e.Data}");
                            Console.ResetColor();

                            foreach (var triggerWord in failureTriggerWords)
                            {
                                if (e.Data.Contains(triggerWord, StringComparison.OrdinalIgnoreCase))
                                {
                                    throw new TaskFailureException($"Detected failure word '{triggerWord}' in error output of process {psi.FileName} {psi.Arguments}.");
                                }
                            }
                        }
                    };

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    await process.WaitForExitAsync(cancellationToken);

                    if (!process.HasExited)
                    {
                        process.Kill(true);
                    }

                    if (process.ExitCode != 0)
                    {
                        throw new Exception($"Error code {process.ExitCode} for process {psi.FileName} {psi.Arguments}");
                    }
                }
            }, cancellationToken);
        }
        finally
        {
            sw.Stop();

            Console.WriteLine($"Process {fileName} {arguments} completed in {sw.Elapsed.Minutes}m {sw.Elapsed.Seconds}s.");
        }
    }

    private static async Task LaunchResilientTask(string taskName, Func<ResilienceContext, ValueTask> task,
        CancellationToken cancellationToken)
    {
        var context = ResilienceContextPool.Shared.Get(
            new ResilienceContextCreationArguments(taskName, null, cancellationToken));
        await ResilienceSetup.AppRetryPipeline.ExecuteAsync(task, context);

        ResilienceContextPool.Shared.Return(context);
    }

    private static readonly Regex stepHeaderRegex = StepHeaderRegex();
    private static readonly Regex stepFooterRegex = StepFooterRegex();

    [GeneratedRegex(@"^(?<header>\d+\.\s.*?)\s*(?<timestamp>[\d\:]+)", RegexOptions.Compiled)]
    private static partial Regex StepHeaderRegex();

    [GeneratedRegex(@"^(?<footer>Step \d+ completed in .*?)\s*$", RegexOptions.Compiled)]
    private static partial Regex StepFooterRegex();
}

public class TaskFailureException(string message) : Exception(message);