#!/usr/bin/env dotnet
#:project ../utilities/Utilities.csproj

// ESBuild Clear Locks Script
// C# file-based app version of esBuildClearLocks.ps1
// Removes ESBuild lock files for both Core and Pro projects
//
// Usage: dotnet ESBuildClearLocks.cs
//   -sf  --stale-files    Remove stale lock files only
//   -h, --help            Display help message

using System.Runtime.CompilerServices;
using Utilities;

// Parse command line arguments
bool help = false;
bool staleFilesOnly = false;

for (int i = 0; i < args.Length; i++)
{
	switch (args[i])
    {
        case "-h":
        case "--help":
            help = true;
            break;
        case "-sf":
        case "--stale-files":
            staleFilesOnly = true;
            break;
        default:
            Console.WriteLine($"Unknown argument: {args[i]}");
            return 1;
    }
}

if (help)
{
    Console.WriteLine("ESBuild Clear Locks Script");
    Console.WriteLine("Removes ESBuild lock files for both Core and Pro projects.");
    Console.WriteLine();
    Console.WriteLine("Usage: dotnet ESBuildClearLocks.cs");
    Console.WriteLine();
    Console.WriteLine("Options:");
    Console.WriteLine("  -h, --help            Display this help message");
    Console.WriteLine("  -sf, --stale-files    Remove stale lock files only");
    return 0;
}

string scriptDir = PathFinder.GetScriptsDirectory();

// Define lock file paths relative to script location (build-scripts folder)
string[] lockFiles =
[
    Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "src", "dymaptic.GeoBlazor.Core", "esBuild.Debug.lock")),
    Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "src", "dymaptic.GeoBlazor.Core", "esBuild.Release.lock")),
    Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "..", "src", "dymaptic.GeoBlazor.Pro", "esBuild.Debug.lock")),
    Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "..", "src", "dymaptic.GeoBlazor.Pro", "esBuild.Release.lock"))
];

int deletedCount = 0;

DateTime staleFileThreshold = DateTime.UtcNow.AddMinutes(-5);

foreach (string lockFile in lockFiles)
{
    if (File.Exists(lockFile))
    {
        try
        {
			if (staleFilesOnly && File.GetLastWriteTimeUtc(lockFile) > staleFileThreshold)
			{
				continue;
			}
            File.Delete(lockFile);
            Console.WriteLine($"Deleted: {lockFile}");
            deletedCount++;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to delete {lockFile}: {ex.Message}");
        }
    }
}

if (deletedCount > 0)
{
    Console.WriteLine($"Cleared {deletedCount} esBuild lock file(s)");
}

return 0;
