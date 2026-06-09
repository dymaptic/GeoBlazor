using Polly;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace Utilities;

public static partial class ProcessRunner
{
    public static bool FormatOutput =>
        !string.Equals(Environment.GetEnvironmentVariable("FORMAT_OUTPUT"), "false", StringComparison.OrdinalIgnoreCase);

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
            ["ERR!"],
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
            ProcessStartInfo psi = new()
            {
                FileName = fileName,
                Arguments = arguments,
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            foreach (KeyValuePair<string, string> kvp in environmentVariables)
            {
                psi.Environment[kvp.Key] = kvp.Value;
            }

            await LaunchResilientTask($"dotnet {arguments}", async _ =>
            {
                using Process? process = Process.Start(psi);
                bool lineWasEmpty = false;
                bool failureTriggered = false;
                string? failureTriggerWord = null;

                if (process != null)
                {
                    process.OutputDataReceived += (_, e) =>
                    {
                        if (e.Data != null)
                        {
                            string line = e.Data;

                            if (FormatOutput)
                            {
                                WriteFormattedLine(line, lineWasEmpty, windowWidth);
                            }
                            else
                            {
                                Console.WriteLine(line);
                            }

                            lineWasEmpty = string.IsNullOrEmpty(line);

                            foreach (string triggerWord in failureTriggerWords)
                            {
                                if (e.Data.Contains(triggerWord, StringComparison.OrdinalIgnoreCase))
                                {
                                    failureTriggered = true;
                                    failureTriggerWord = triggerWord;
                                }
                            }
                        }
                    };

                    process.ErrorDataReceived += (_, e) =>
                    {
                        if (e.Data != null)
                        {
                            if (FormatOutput)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"| {e.Data}");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine(e.Data);
                            }

                            foreach (string triggerWord in failureTriggerWords)
                            {
                                if (e.Data.Contains(triggerWord, StringComparison.OrdinalIgnoreCase))
                                {
                                    failureTriggered = true;
                                    failureTriggerWord = triggerWord;
                                }
                            }
                        }
                    };

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    await process.WaitForExitAsync(cancellationToken);

                    if (failureTriggered)
                    {
                        throw new TaskFailureException($"Detected failure word '{failureTriggerWord}' in output of process {psi.FileName} {psi.Arguments}.");
                    }

                    if (!process.HasExited)
                    {
                        process.Kill(true);
                    }

                    if (process.ExitCode != 0)
                    {
                        throw new Exception($"Error code {process.ExitCode} for process {psi.FileName} {psi.Arguments
                        }");
                    }
                }
            }, cancellationToken);
        }
        finally
        {
            sw.Stop();

            Console.WriteLine($"Process {fileName} {arguments} completed in {sw.Elapsed.Minutes}m {sw.Elapsed.Seconds
            }s.");
        }
    }

    private static async Task LaunchResilientTask(string taskName, Func<ResilienceContext, ValueTask> task,
        CancellationToken cancellationToken)
    {
        ResilienceContext context = ResilienceContextPool.Shared.Get(
            new ResilienceContextCreationArguments(taskName, null, cancellationToken));
        await ResilienceSetup.AppRetryPipeline.ExecuteAsync(task, context);

        ResilienceContextPool.Shared.Return(context);
    }

    private static void WriteFormattedLine(string line, bool lineWasEmpty, int windowWidth)
    {
        Console.Write("| ");
        int lineSpace = windowWidth - 3;

        if (stepHeaderRegex.Match(line) is { Success: true } headerMatch && lineWasEmpty)
        {
            string indents = headerMatch.Groups["indents"].Value;

            Console.BackgroundColor = (indents.Length == 0 ? 0 : indents.Length / 2) switch
            {
                0 => ConsoleColor.DarkBlue,
                1 => ConsoleColor.DarkGreen,
                _ => ConsoleColor.DarkYellow
            };
            Console.ForegroundColor = ConsoleColor.White;
            string header = headerMatch.Groups["header"].Value;
            string timestamp = headerMatch.Groups["timestamp"].Value;
            int buffer = windowWidth - indents.Length - header.Length - timestamp.Length - 3;

            while (buffer < 0)
            {
                buffer += windowWidth;
            }

            Console.Write($"{indents}{header}{new string(' ', buffer)}{timestamp}");
            Console.ResetColor();
            Console.WriteLine();
        }
        else if (stepFooterRegex.Match(line) is { Success: true } footerMatch)
        {
            string indents = footerMatch.Groups["indents"].Value;

            Console.BackgroundColor = (indents.Length == 0 ? 0 : indents.Length / 2) switch
            {
                0 => ConsoleColor.Blue,
                1 => ConsoleColor.Green,
                _ => ConsoleColor.Yellow
            };
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            string footer = footerMatch.Groups["footer"].Value;
            int buffer = windowWidth - indents.Length - footer.Length - 3;

            while (buffer < 0)
            {
                buffer += windowWidth;
            }

            Console.Write($"{indents}{footer}{new string(' ', buffer)}");
            Console.ResetColor();
            Console.WriteLine();
        }
        else
        {
            while (line.Length > lineSpace)
            {
                Console.WriteLine(line[..lineSpace]);
                Console.Write("|  ");
                line = line[lineSpace..];
            }

            Console.WriteLine(line);
        }
    }

    [GeneratedRegex(@"^(?<indents>[|\s]*?)(?<header>\d+\.\s.*?)\s*(?<timestamp>[\d\:]+)", RegexOptions.Compiled)]
    private static partial Regex StepHeaderRegex();

    [GeneratedRegex(@"^(?<indents>[|\s]*?)(?<footer>Step \d+ completed in .*?)\s*$", RegexOptions.Compiled)]
    private static partial Regex StepFooterRegex();

    private static readonly Regex stepHeaderRegex = StepHeaderRegex();
    private static readonly Regex stepFooterRegex = StepFooterRegex();
}

public class TaskFailureException(string message) : Exception(message);