#!/usr/bin/env dotnet

using System.Diagnostics;
using System.Runtime.CompilerServices;

bool cover = false;
string config = "Release";
string? filter = null;

for (int i = 0; i < args.Length; i++)
{
    switch (args[i].ToLowerInvariant())
    {
        case "--cover":
            cover = true;
            break;
        case "-c":
        case "--configuration":
            if (i + 1 < args.Length)
            {
                config = args[++i];
            }
            break;
        case "-f":
        case "--filter":
            if (i + 1 < args.Length)
            {
                filter = args[++i];
            }
            break;
    }
}

string scriptsDir = GetScriptsDirectory();

string testProjectDir = Path.GetFullPath(
    Path.Combine(scriptsDir, "..", "test", "dymaptic.GeoBlazor.Core.Test.Automation"));

string testProjectFilePath = Path.Combine(testProjectDir, "dymaptic.GeoBlazor.Core.Test.Automation.csproj");

List<string> buildArgs =
[
    "--project", testProjectFilePath,
    "-c", config
];

if (filter != null)
{
    buildArgs = [..buildArgs, "--filter", filter];
}

Dictionary<string, string>? environmentVariables = null;

if (cover)
{
    environmentVariables = new Dictionary<string, string>
    {
        ["COVER"] = "true"
    };
}

await RunDotnetCommandWithOutputAsync(testProjectDir, "run", buildArgs, environmentVariables);
/// <summary>
/// Runs a dotnet command and captures both stdout and stderr output.
/// Output is written to the console in real-time.
/// </summary>
/// <param name="workingDirectory">The working directory for the command.</param>
/// <param name="command">The dotnet command (e.g., "build", "restore").</param>
/// <param name="args">The arguments to pass to the command.</param>
/// <param name="environmentVariables">Optional environment variables to set for the process.</param>
/// <returns>The exit code of the process.</returns>
static async Task<int> RunDotnetCommandWithOutputAsync(string workingDirectory,
    string command, IEnumerable<string> args, Dictionary<string, string>? environmentVariables)
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

    if (environmentVariables != null)
    {
        foreach (var kvp in environmentVariables)
        {
            psi.Environment[kvp.Key] = kvp.Value;
        }
    }

    using var process = Process.Start(psi);
    if (process == null)
    {
        return 1;
    }

    process.OutputDataReceived += (_, e) =>
    {
        if (e.Data != null)
        {
            Console.WriteLine(e.Data);
        }
    };

    process.ErrorDataReceived += (_, e) =>
    {
        if (e.Data != null)
        {
            Console.WriteLine(e.Data);
        }
    };

    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    await process.WaitForExitAsync();

    return process.ExitCode;
}

/// <summary>
/// Gets the directory containing the build scripts.
/// When running as a .cs file, uses [CallerFilePath]. When running as a compiled DLL,
/// calculates the path relative to the DLL location.
/// </summary>
/// <param name="callerFilePath">Automatically populated with the source file path at compile time.</param>
/// <returns>The absolute path to the build-scripts directory.</returns>
static string GetScriptsDirectory([CallerFilePath] string? callerFilePath = null)
{
    // When running as a pre-compiled DLL, [CallerFilePath] contains the compile-time path
    // which is invalid at runtime (especially in Docker containers).
    // Detect this by checking if the file exists at the caller path.
    if (!string.IsNullOrEmpty(callerFilePath) && File.Exists(callerFilePath))
    {
        return Path.GetDirectoryName(callerFilePath)!;
    }

    // Running as a DLL - use AppContext.BaseDirectory which points to the DLL location
    // The DLL is in build-tools/, and scripts are in build-scripts/ (sibling directory)
    string dllDirectory = AppContext.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
    return Path.Combine(Path.GetDirectoryName(dllDirectory)!, "build-scripts");
}