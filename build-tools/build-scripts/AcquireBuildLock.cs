#!/usr/bin/env dotnet

// AcquireBuildLock - Atomic build lock acquisition
// =================================================
// Atomically checks whether a time-based lock file is stale and acquires it
// if so, using exclusive file access to prevent races in parallel MSBuild.
//
// Usage: dotnet AcquireBuildLock.cs <lock-file-path> [stale-minutes]
//
// Arguments:
//   <lock-file-path>   Path to the lock file
//   [stale-minutes]    Minutes before the lock is considered stale (default: 5)
//
// Exit codes:
//   0  Lock acquired — caller should proceed with the build step
//   1  Lock is fresh or held by another process — caller should skip

if (args.Length < 1 || args[0] is "-h" or "--help")
{
    Console.WriteLine("Usage: dotnet AcquireBuildLock.cs <lock-file-path> [stale-minutes]");
    Console.WriteLine();
    Console.WriteLine("Exit codes:");
    Console.WriteLine("  0  Lock acquired (proceed)");
    Console.WriteLine("  1  Lock fresh or held (skip)");
    return args.Length > 0 ? 0 : 1;
}

string lockFilePath = args[0];
int staleMinutes = args.Length > 1 && int.TryParse(args[1], out int m) ? m : 5;

try
{
    string? dir = Path.GetDirectoryName(lockFilePath);
    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
        Directory.CreateDirectory(dir);

    // FileShare.None = exclusive lock; concurrent callers get IOException
    using var fs = new FileStream(lockFilePath,
        FileMode.OpenOrCreate,
        FileAccess.ReadWrite,
        FileShare.None);

    using var reader = new StreamReader(fs, leaveOpen: true);
    string content = reader.ReadToEnd().Trim();

    if (!string.IsNullOrEmpty(content) &&
        DateTime.TryParse(content, out DateTime lastWrite) &&
        (DateTime.Now - lastWrite).TotalMinutes < staleMinutes)
    {
        // Lock is fresh — another project already triggered
        return 1;
    }

    // Stale or missing — we win, stamp it
    fs.SetLength(0);
    using var writer = new StreamWriter(fs);
    writer.Write(DateTime.Now.ToString("o"));
    writer.Flush();

    return 0;
}
catch (IOException)
{
    // Another process holds the exclusive lock — they win
    return 1;
}
