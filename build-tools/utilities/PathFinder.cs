using System.Runtime.CompilerServices;

namespace Utilities;

public static class PathFinder
{
    /// <summary>
    /// Gets the relative directory containing the build scripts.
    /// </summary>
    public static string GetScriptsDirectory([CallerFilePath] string? callerFilePath = null)
    {
        string dllDirectory = AppContext.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

        if (dllDirectory.Contains("dotnet"))
        {
            // we are running from the C# script in build-scripts, so we can use the caller file path to find the script directory
            return Path.GetDirectoryName(callerFilePath!)!;
        }

        // otherwise the dll is stored in ./build-tools/{os}-{arch}
        return Path.GetFullPath(Path.Combine(dllDirectory, "..", "build-scripts"));
    }
}