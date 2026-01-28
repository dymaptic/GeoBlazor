#!/usr/bin/env dotnet



/// <summary>
/// Runs a dotnet command and captures both stdout and stderr output.
/// Output is also written to the console in real-time.
/// </summary>
/// <param name="workingDirectory">The working directory for the command.</param>
/// <param name="command">The dotnet command (e.g., "build", "restore").</param>
/// <param name="args">Additional arguments to pass to the command.</param>
/// <returns>A tuple containing the exit code and a list of all output lines.</returns>
static async Task<(int ExitCode, List<string> Output)> RunDotnetCommandWithOutputAsync(string workingDirectory,
    string command, params string[] args)
{
    var output = new List<string>();

    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"{command} {string.Join(" ", args.Where(a => !string.IsNullOrWhiteSpace(a)))}",
        WorkingDirectory = workingDirectory,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    using var process = Process.Start(psi);
    if (process == null)
    {
        return (1, ["Failed to start dotnet"]);
    }

    process.OutputDataReceived += (_, e) =>
    {
        if (e.Data != null)
        {
            Console.WriteLine(e.Data);
            output.Add(e.Data);
        }
    };

    process.ErrorDataReceived += (_, e) =>
    {
        if (e.Data != null)
        {
            Console.WriteLine(e.Data);
            output.Add(e.Data);
        }
    };

    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    await process.WaitForExitAsync();

    return (process.ExitCode, output);
}