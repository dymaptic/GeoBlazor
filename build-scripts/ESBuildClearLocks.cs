#!/usr/bin/env dotnet

// ESBuild Clear Locks Script
// C# file-based app version of esBuildClearLocks.ps1
// Removes ESBuild lock files for both Core and Pro projects
//
// Usage: dotnet ESBuildClearLocks.cs
//   -h, --help    Display help message

using System.Runtime.CompilerServices;

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

string scriptDir = GetScriptsDirectory();

// Define lock file paths relative to script location (build-scripts folder)
string[] lockFiles =
[
    Path.GetFullPath(Path.Combine(scriptDir, "..", "src", "dymaptic.GeoBlazor.Core", "esBuild.Debug.lock")),
    Path.GetFullPath(Path.Combine(scriptDir, "..", "src", "dymaptic.GeoBlazor.Core", "esBuild.Release.lock")),
    Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "src", "dymaptic.GeoBlazor.Pro", "esBuild.Debug.lock")),
    Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "src", "dymaptic.GeoBlazor.Pro", "esBuild.Release.lock"))
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

// Helper method
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
