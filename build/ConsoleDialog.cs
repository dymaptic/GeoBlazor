#!/usr/bin/env dotnet

using System.Diagnostics;

// Manages a console window for displaying log messages during source generation.

object _consoleLock = new();
Process? _consoleProcess = null;
string? _consoleTempFile = null;



void ShowOrUpdateConsole(string title, string message)
{
    lock (_consoleLock)
    {
        // Ensure the temp file exists (create if needed)
        if (_consoleTempFile is null || !File.Exists(_consoleTempFile))
        {
            _consoleTempFile = Path.Combine(Path.GetTempPath(), $"geoblazor_sourcegen_{Guid.NewGuid():N}.log");
            // Create the file immediately so Get-Content -Wait has something to tail
            File.WriteAllText(_consoleTempFile, $"[{DateTime.Now:HH:mm:ss}] {title}: Starting...{Environment.NewLine}");
        }

        if (!string.IsNullOrWhiteSpace(message))
        {
            // Append message to the temp file
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string logLine = $"[{timestamp}] {title}: {message}{Environment.NewLine}";
            File.AppendAllText(_consoleTempFile, logLine);
        }

        // Start the console window if not already running
        if (_consoleProcess is null || _consoleProcess.HasExited)
        {
            StartConsoleWindow(title);
        }
    }
}

void StartConsoleWindow(string title)
{
    try
    {
        if (OperatingSystem.IsWindows())
        {
            StartWindowsConsole(title);
        }
        else if (OperatingSystem.IsMacOS())
        {
            StartMacConsole();
        }
        else if (OperatingSystem.IsLinux())
        {
            StartLinuxConsole();
        }
    }
    catch
    {
        // Console window creation failed - continue silently
        // Messages are still written to the temp file and MSBuild diagnostics
    }
}

void StartWindowsConsole(string title)
{
    string escapedPath = _consoleTempFile!.Replace("'", "''");
    string windowTitle = string.IsNullOrWhiteSpace(title) ? "GeoBlazor Build" : title;
    string command = $"$Host.UI.RawUI.WindowTitle = '{windowTitle}'; " +
                   $"Write-Host 'GeoBlazor Source Generator Output' -ForegroundColor Cyan; " +
                   $"Write-Host ('=' * 50); " +
                   $"Get-Content -Path '{escapedPath}' -Wait -Tail 100";

    _consoleProcess = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "pwsh",
            Arguments = $"-NoProfile -NoLogo -Command \"{command}\"",
            UseShellExecute = true,
            CreateNoWindow = false
        }
    };
    _consoleProcess.Start();
}

void StartMacConsole()
{
    string escapedPath = _consoleTempFile!.Replace("'", "'\\''");

    // Use osascript to open Terminal.app with a pwsh command
    string pwshCommand = "pwsh -NoProfile -NoLogo -Command \\\"" +
                       "Write-Host 'GeoBlazor Source Generator Output' -ForegroundColor Cyan; " +
                       "Write-Host ('=' * 50); " +
                       $"Get-Content -Path '{escapedPath}' -Wait -Tail 100\\\"";

    string appleScript = $"tell application \\\"Terminal\\\" to do script \\\"{pwshCommand}\\\"";

    _consoleProcess = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "osascript",
            Arguments = $"-e \"{appleScript}\"",
            UseShellExecute = false,
            CreateNoWindow = true
        }
    };
    _consoleProcess.Start();
}

void StartLinuxConsole()
{
    string escapedPath = _consoleTempFile!.Replace("'", "'\\''");
    string pwshCommand = "pwsh -NoProfile -NoLogo -Command \\\"" +
                       "Write-Host 'GeoBlazor Source Generator Output' -ForegroundColor Cyan; " +
                       "Write-Host ('=' * 50); " +
                       $"Get-Content -Path '{escapedPath}' -Wait -Tail 100\\\"";

    // Try common Linux terminal emulators in order of popularity
    string[] terminals = ["gnome-terminal", "konsole", "xfce4-terminal", "xterm"];

    foreach (string terminal in terminals)
    {
        try
        {
            string args = terminal switch
            {
                "gnome-terminal" => $"-- bash -c \"{pwshCommand}\"",
                "konsole" => $"-e bash -c \"{pwshCommand}\"",
                "xfce4-terminal" => $"-e \"bash -c \\\"{pwshCommand}\\\"\"",
                "xterm" => $"-e bash -c \"{pwshCommand}\"",
                _ => $"-e bash -c \"{pwshCommand}\""
            };

            _consoleProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = terminal,
                    Arguments = args,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            _consoleProcess.Start();
            return; // Success, exit the loop
        }
        catch
        {
            // This terminal emulator not available, try the next one
        }
    }

    // No terminal emulator found - messages still go to temp file and diagnostics
}

void CloseConsole(string title)
{
    lock (_consoleLock)
    {
        try
        {
            if (_consoleProcess is { HasExited: false } && _consoleTempFile is not null)
            {
                File.WriteAllText(_consoleTempFile, $"[{DateTime.Now:HH:mm:ss}] {title}: Console closing...");
                // Give a brief moment for final messages to appear
                Thread.Sleep(4000);
                _consoleProcess.Kill();
                _consoleProcess.Dispose();
            }
        }
        catch
        {
            // Process may have already exited
        }
        finally
        {
            _consoleProcess = null;
        }

        // Clean up temp file
        try
        {
            if (_consoleTempFile is not null && File.Exists(_consoleTempFile))
            {
                File.Delete(_consoleTempFile);
            }
        }
        catch
        {
            // File may be locked - ignore
        }
        finally
        {
            _consoleTempFile = null;
        }
    }
}


string? title = args.Length > 0 ? args[0] : "GeoBlazor Build";

ShowOrUpdateConsole(title, string.Empty);

CancellationTokenSource cts = new();
cts.CancelAfter(TimeSpan.FromSeconds(60));

bool hold = false;

_ = Task.Run(async () =>
{
    while ((!cts.IsCancellationRequested || hold)
        && (_consoleProcess is null || !_consoleProcess.HasExited))
    {
        await Task.Delay(1000);
    }
    Console.WriteLine("Console dialog timed out. Closing...");
    CloseConsole(title);
    Environment.Exit(0);
});

while (!cts.IsCancellationRequested)
{
    if (_consoleProcess?.HasExited == true)
    {
        break;
    }
    
    if (Console.ReadLine() is not { } inputLine)
    {
        continue;
    }

    if (inputLine.Trim().Equals("hold", StringComparison.OrdinalIgnoreCase))
    {
        hold = true;

        break;
    }

    if (inputLine.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        CloseConsole(title);
        
        break;
    }

    ShowOrUpdateConsole(title, inputLine);
}

Environment.Exit(0);