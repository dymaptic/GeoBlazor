using System.Diagnostics;


namespace Utilities;

public static class ProcessKiller
{
    public static bool KillByProcessOrFileName(string fileName)
    {
        Process[] processes = Process.GetProcesses();
        bool killed = false;

        foreach (Process process in processes)
        {
            try
            {
                if (process.ProcessName.Contains(fileName, StringComparison.OrdinalIgnoreCase))
                {
                    process.Kill();
                    killed = true;

                    continue;
                }

                if (process.Modules.Cast<ProcessModule>()
                    .Any(m => m.FileName
                        .Contains(fileName, StringComparison.OrdinalIgnoreCase)))
                {
                    process.Kill();
                    killed = true;
                }
            }
            catch
            {
                // Can't access this process — skip it
            }
        }

        return killed;
    }
}