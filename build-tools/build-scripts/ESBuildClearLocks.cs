#!/usr/bin/env dotnet
#:project ../utilities/Utilities.csproj

// ESBuild Clear Locks Script
// C# file-based app version of esBuildClearLocks.ps1
// Removes ESBuild lock files for both Core and Pro projects
//
// Usage: dotnet ESBuildClearLocks.cs
//   -h, --help    Display help message

using System.Runtime.CompilerServices;
using Utilities;

// Parse command line arguments
bool help = args.Any(a => a is "-h" or "--help");

if (help)
{
    Console.WriteLine("ESBuild Clear Locks Script");
    Console.WriteLine("Removes ESBuild lock files for both Core and Pro projects.");
    Console.WriteLine();
    Console.WriteLine("Usage: dotnet ESBuildClearLocks.cs");
    Console.WriteLine();
    Console.WriteLine("Options:");
    Console.WriteLine("  -h, --help    Display this help message");
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

foreach (string lockFile in lockFiles)
{
    if (File.Exists(lockFile))
    {
        try
        {
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
else
{
    Console.WriteLine("No esBuild lock files found");
}

return 0;
