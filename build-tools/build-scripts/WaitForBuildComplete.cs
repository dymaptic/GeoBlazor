#!/usr/bin/env dotnet

// WaitForBuildComplete - Wait for a parallel build step to finish
// ===============================================================
// Polls for the removal of a ".running" marker file created by AcquireBuildLock.
// Used by projects that did NOT acquire the build lock to wait for the project
// that DID acquire it to finish running ESBuild (or similar build step).
//
// Usage: dotnet WaitForBuildComplete.cs <running-file-path> [timeout-seconds]
//
// Arguments:
//   <running-file-path>   Path to the .running marker file
//   [timeout-seconds]     Max seconds to wait (default: 120)
//
// Exit codes:
//   0  Build step completed (marker file removed)
//   1  Timed out waiting

if (args.Length < 1 || args[0] is "-h" or "--help")
{
    Console.WriteLine("Usage: dotnet WaitForBuildComplete.cs <running-file-path> [timeout-seconds]");
    Console.WriteLine();
    Console.WriteLine("Exit codes:");
    Console.WriteLine("  0  Build step completed (marker removed)");
    Console.WriteLine("  1  Timed out waiting");
    return args.Length > 0 ? 0 : 1;
}

string runningFilePath = args[0];
int timeoutSeconds = args.Length > 1 && int.TryParse(args[1], out int t) ? t : 120;

// If the marker file doesn't exist, the build step already completed (or was never started)
if (!File.Exists(runningFilePath))
{
    return 0;
}

// Check immediately if the marker is stale (e.g., previous build crashed without cleanup)
try
{
    var age = DateTime.UtcNow - File.GetLastWriteTimeUtc(runningFilePath);
    if (age.TotalMinutes > 5)
    {
        Console.WriteLine($"Marker file {Path.GetFileName(runningFilePath)} is stale ({age.TotalMinutes:F0} min old). Removing it and proceeding.");
        File.Delete(runningFilePath);
        return 0;
    }
}
catch
{
    // File may have been deleted between exists check and age check
    return 0;
}

Console.WriteLine($"Waiting for build step to complete (marker: {Path.GetFileName(runningFilePath)})...");

var deadline = DateTime.UtcNow.AddSeconds(timeoutSeconds);
int pollMs = 500;

while (File.Exists(runningFilePath))
{
    if (DateTime.UtcNow >= deadline)
    {
        Console.WriteLine($"Timed out after {timeoutSeconds}s waiting for {Path.GetFileName(runningFilePath)} to be removed.");
        Console.WriteLine("Removing stale marker and proceeding.");
        try { File.Delete(runningFilePath); } catch { }
        return 0;
    }

    Thread.Sleep(pollMs);
}

Console.WriteLine("Build step completed.");
return 0;
