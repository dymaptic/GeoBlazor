using Polly;
using System.Diagnostics;


namespace Utilities;

public static class ProcessRunner
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

            if (environmentVariables != null)
            {
                foreach (var kvp in environmentVariables)
                {
                    psi.Environment[kvp.Key] = kvp.Value;
                }
            }

            await LaunchResilientTask($"dotnet {arguments}", async context =>
            {
                using var process = Process.Start(psi);

                if (process != null)
                {
                    process.OutputDataReceived += (_, e) =>
                    {
                        if (e.Data != null)
                        {
                            Console.WriteLine(e.Data);

                            foreach (var triggerWord in failureTriggerWords)
                            {
                                if (e.Data.Contains(triggerWord, StringComparison.OrdinalIgnoreCase))
                                {
                                    throw new Exception($"Detected failure word '{triggerWord}' in output of process {
                                        psi.FileName} {psi.Arguments}.");
                                }
                            }
                        }
                    };

                    process.ErrorDataReceived += (_, e) =>
                    {
                        if (e.Data != null)
                        {
                            Console.WriteLine(e.Data);

                            foreach (var triggerWord in failureTriggerWords)
                            {
                                if (e.Data.Contains(triggerWord, StringComparison.OrdinalIgnoreCase))
                                {
                                    throw new Exception($"Detected failure word '{triggerWord
                                    }' in error output of process {
                                        psi.FileName} {psi.Arguments}.");
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
        var context = ResilienceContextPool.Shared.Get(
            new ResilienceContextCreationArguments(taskName, null, cancellationToken));
        await ResilienceSetup.AppRetryPipeline.ExecuteAsync(task, context);

        ResilienceContextPool.Shared.Return(context);
    }
}