#!/usr/bin/env dotnet

// ESBuild Wait For Completion Script
// C# file-based app version of esBuildWaitForCompletion.ps1
// Waits for ESBuild lock files to be released before proceeding
//
// Usage: dotnet ESBuildWaitForCompletion.cs [options]
//   -c, --configuration <Debug|Release>  Build configuration (default: Debug)
//   -t, --timeout <seconds>              Timeout in seconds (default: 30)
//   -h, --help                           Display help message
//
// Example:
//   dotnet ESBuildWaitForCompletion.cs
//   dotnet ESBuildWaitForCompletion.cs -c Release
//   dotnet ESBuildWaitForCompletion.cs -c Debug -t 60

using System.Runtime.CompilerServices;

// Parse command line arguments
string configuration = "Debug";
int timeout = 30;
bool help = false;

for (int i = 0; i < args.Length; i++)
{
    string arg = args[i].ToLowerInvariant();
    switch (arg)
    {
        case "-c":
        case "--configuration":
            if (i + 1 < args.Length)
            {
                configuration = args[++i];
            }
            break;
        case "-t":
        case "--timeout":
            if (i + 1 < args.Length && int.TryParse(args[++i], out int t))
            {
                timeout = t;
            }
            break;
        case "-h":
        case "--help":
            help = true;
            break;
    }
}

if (help)
{
    Console.WriteLine("ESBuild Wait For Completion Script");
    Console.WriteLine("Waits for ESBuild lock files to be released before proceeding.");
    Console.WriteLine();
    Console.WriteLine("Usage: dotnet ESBuildWaitForCompletion.cs [options]");
    Console.WriteLine();
    Console.WriteLine("Options:");
    Console.WriteLine("  -c, --configuration <Debug|Release>  Build configuration (default: Debug)");
    Console.WriteLine("  -t, --timeout <seconds>              Timeout in seconds (default: 30)");
    Console.WriteLine("  -h, --help                           Display this help message");
    Console.WriteLine();
    Console.WriteLine("Examples:");
    Console.WriteLine("  dotnet ESBuildWaitForCompletion.cs");
    Console.WriteLine("  dotnet ESBuildWaitForCompletion.cs -c Release");
    Console.WriteLine("  dotnet ESBuildWaitForCompletion.cs -c Debug -t 60");
    return 0;
}

// Normalize configuration
configuration = configuration.Equals("release", StringComparison.OrdinalIgnoreCase) ? "Release" : "Debug";

string scriptDir = GetScriptDirectory();

// Define paths relative to script location (build-scripts folder)
// Core: ../src/dymaptic.GeoBlazor.Core
// Pro: ../../src/dymaptic.GeoBlazor.Pro
string coreRootDir = Path.GetFullPath(Path.Combine(scriptDir, "..", "src", "dymaptic.GeoBlazor.Core"));
string proRootDir = Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "src", "dymaptic.GeoBlazor.Pro"));

string coreLockFilePath = Path.Combine(coreRootDir, $"esBuild.{configuration}.lock");
string proLockFilePath = Path.Combine(proRootDir, $"esBuild.{configuration}.lock");

Console.WriteLine($"Waiting for lock files: {coreLockFilePath}, {proLockFilePath}");

bool coreLockExists = File.Exists(coreLockFilePath);
bool proLockExists = File.Exists(proLockFilePath);

if (coreLockExists || proLockExists)
{
    Console.WriteLine("Lock file found. Waiting for release.");
}
else
{
    Console.WriteLine("No lock file found. Exiting.");
    return 0;
}

int elapsed = 0;

while (File.Exists(coreLockFilePath) || File.Exists(proLockFilePath))
{
    Thread.Sleep(1000);
    Console.Write(".");
    elapsed++;

    if (elapsed >= timeout)
    {
        Console.WriteLine();
        Console.WriteLine($"Timeout reached ({timeout} seconds). Deleting lock files.");

        if (File.Exists(coreLockFilePath))
        {
            try
            {
                File.Delete(coreLockFilePath);
                Console.WriteLine($"Deleted: {coreLockFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete {coreLockFilePath}: {ex.Message}");
            }
        }

        if (File.Exists(proLockFilePath))
        {
            try
            {
                File.Delete(proLockFilePath);
                Console.WriteLine($"Deleted: {proLockFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete {proLockFilePath}: {ex.Message}");
            }
        }

        break;
    }
}

Console.WriteLine();
Console.WriteLine("Lock file removed. Exiting.");
return 0;

// Helper method
static string GetScriptDirectory([CallerFilePath] string? callerFilePath = null)
{
    return Path.GetDirectoryName(callerFilePath!) ?? Environment.CurrentDirectory;
}
