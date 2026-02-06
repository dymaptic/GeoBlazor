#!/usr/bin/env dotnet

#:package CliWrap@3.10.0

// GBTest.cs - GeoBlazor Test Runner
// Runs the GeoBlazor Core automation test project via `dotnet run`.
// Supports configuration, test filtering, code coverage, and container execution.
//
// Usage: dotnet ./build-scripts/GBTest.cs [options]
//
// Options:
//   -h, --help             Show this help message and exit
//   -c, --configuration    Build configuration (default: Release)
//   -f, --filter           Test filter expression passed to dotnet test
//   -p, --percentage       Percentage of tests that must pass to be counted as successful (default 100%)
//       --cover            Enable code coverage collection (sets COVER=true)
//       --container        Run tests in a container (sets USE_CONTAINER=true)

using CliWrap;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

// Default option values
bool cover = false;
bool container = false;
string config = "Release";
string? filter = null;
int percentage = 100;

// Parse command-line arguments
for (int i = 0; i < args.Length; i++)
{
    switch (args[i].ToLowerInvariant())
    {
        case "-h":
        case "--help":
            Console.WriteLine("""
                GBTest - GeoBlazor Test Runner

                Usage: dotnet ./build-scripts/GBTest.cs [options]

                Options:
                  -h, --help             Show this help message and exit
                  -c, --configuration    Build configuration (default: Release)
                  -f, --filter           Test filter expression passed to dotnet test
                  -p, --percentage       Percentage of tests that must pass to be counted as successful (default 100%)
                      --cover            Enable code coverage collection (sets COVER=true)
                      --container        Run tests in a container (sets USE_CONTAINER=true)

                Examples:
                  dotnet ./build-scripts/GBTest.cs
                  dotnet ./build-scripts/GBTest.cs -c Debug
                  dotnet ./build-scripts/GBTest.cs --filter "FullyQualifiedName~MapView"
                  dotnet ./build-scripts/GBTest.cs --cover --container
                """);
            return 0;
        case "--cover":
            cover = true;
            break;
        case "--container":
            container = true;
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
        case "-p":
        case "--percentage":
            if (i + 1 < args.Length && int.TryParse(args[++i], out int p))
            {
                percentage = p;
            }
            break;
    }
}

CancellationTokenSource cts = new();
CancellationTokenSource forceCts = new();

Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true; // Prevent immediate termination of this script
    cts.Cancel();
    forceCts.CancelAfter(20_000);
};

// Resolve paths relative to this script's location
string scriptsDir = GetScriptsDirectory();

string testProjectDir = Path.GetFullPath(
    Path.Combine(scriptsDir, "..", "test", "dymaptic.GeoBlazor.Core.Test.Automation"));

string testProjectFilePath = Path.Combine(testProjectDir, "dymaptic.GeoBlazor.Core.Test.Automation.csproj");

// Build the argument list for `dotnet run`
List<string> buildArgs =
[
    "--project", testProjectFilePath,
    "-c", config,
    "--ignore-exit-code", "2"
];

if (filter != null)
{
    buildArgs = [..buildArgs, "--filter", filter];
}

// Set environment variables to toggle optional features
Dictionary<string, string?>? environmentVariables = [];

if (cover)
{
    environmentVariables["COVER"] = "true";
}

if (container)
{
	environmentVariables["USE_CONTAINER"] = "true";
}

// Execute the test project
await RunDotnetCommandWithOutputAsync(testProjectDir, "run", buildArgs, environmentVariables, cts.Token, forceCts.Token);

Console.WriteLine("FINAL SUMMARY");
Console.WriteLine("-------------------------------------------------------");

// Read the test output log
string testOutputLogPath = Path.Combine(testProjectDir, "test-run.log");

Regex finalCountRegex = new(@"^.*FINAL_SUMMARY: (?<passed>\d+) / (?<total>\d+) TESTS PASSED.\s*$");

bool failed = false;
foreach (string line in await File.ReadAllLinesAsync(testOutputLogPath))
{
    if (line.Contains("FINAL_SUMMARY"))
    {
        string content = line.Substring(38); // 38 is the timestamp plus FINAL_SUMMARY:
        Console.WriteLine(content);
        if (finalCountRegex.Match(line) is { Success: true } match)
        {
            int total = int.Parse(match.Groups["total"].Value);
            int passed = int.Parse(match.Groups["passed"].Value);
            double passedPercentage = (double)passed / total * 100;
            Console.WriteLine($"TEST RESULTS: {passed} / {total} TESTS PASSED ({passedPercentage:F2}%).");
            if (passedPercentage < percentage)
            {
                Console.WriteLine($"TEST RUN FAILED: Passed percentage {passedPercentage:F2}% is below the required {percentage}%.");
                failed = true;
            }
        }
    }
}

if (failed)
{
    return 1;
}

return 0;


/// <summary>
/// Runs a dotnet command and captures both stdout and stderr output.
/// Output is written to the console in real-time.
/// Handles Ctrl+C by forwarding the kill signal to the child process.
/// </summary>
/// <param name="workingDirectory">The working directory for the command.</param>
/// <param name="command">The dotnet command (e.g., "build", "restore").</param>
/// <param name="args">The arguments to pass to the command.</param>
/// <param name="environmentVariables">Optional environment variables to set for the process.</param>
/// <returns>The exit code of the process.</returns>
static async Task RunDotnetCommandWithOutputAsync(string workingDirectory,
    string command, IEnumerable<string> args, Dictionary<string, string?>? environmentVariables,
    CancellationToken cancellationToken, CancellationToken forceCancellationToken)
{
    bool summaryStarted = false;
    bool testLineMatched = false;
    ConsoleColor defaultColor = Console.ForegroundColor;
    Regex testLineRegex = new(@"^\[\+(?<passed>\d+)\/x(?<failed>\d+)\/\?(?<skipped>\d+)\] (?<content>.*)$");

    await Cli.Wrap("dotnet")
        .WithArguments($"{command} {string.Join(" ", args.Where(a => !string.IsNullOrWhiteSpace(a)))}")
        .WithWorkingDirectory(workingDirectory)
        .WithEnvironmentVariables(environmentVariables ?? [])
        .WithStandardOutputPipe(PipeTarget.ToDelegate(line =>
        {
            if (!string.IsNullOrWhiteSpace(line) && !summaryStarted)
            {
                if (line.Contains("Test run summary"))
                {
                    summaryStarted = true;

                    return;
                }
                if (testLineRegex.Match(line) is { Success: true } match && !summaryStarted)
                {
                    if (testLineMatched)
                    {
                        // Move cursor up and clear the previous line
                        int cursorTop = Console.GetCursorPosition().Top;
                        Console.SetCursorPosition(0, cursorTop - 1);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, cursorTop - 1);
                    }

                    int passed = int.Parse(match.Groups["passed"].Value);
                    int failed = int.Parse(match.Groups["failed"].Value);
                    int skipped = int.Parse(match.Groups["skipped"].Value);
                    string content = match.Groups["content"].Value;
                    Console.ForegroundColor = defaultColor;
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"+{passed}");
                    Console.ForegroundColor = defaultColor;
                    Console.Write("/");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"x{failed}");
                    Console.ForegroundColor = defaultColor;
                    Console.Write("/");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"?{skipped}");
                    Console.ForegroundColor = defaultColor;
                    Console.WriteLine($"] {content}");
                    testLineMatched = true;
                    return;
                }

                testLineMatched = false;
                Console.WriteLine(line);
            }
        }))
        .WithStandardErrorPipe(PipeTarget.ToDelegate(line =>
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(line);
                Console.ForegroundColor = defaultColor;
            }
        }))
        .ExecuteAsync(forceCancellationToken, cancellationToken);
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
    string parent = Path.GetDirectoryName(dllDirectory)!;
    while (Path.GetFileName(parent) != "GeoBlazor")
    {
        parent = Path.GetDirectoryName(parent)!;
    }
    return Path.Combine(parent!, "build-scripts");
}