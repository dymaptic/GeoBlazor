#!/usr/bin/env dotnet

// Console Dialog - Build Progress Display Window
// ===============================================
// Manages a console window for displaying log messages during source generation
// and build processes. Opens a separate terminal window that tails a log file,
// allowing real-time visibility of build progress.
//
// Usage:
//   dotnet ConsoleDialog.cs [title] [options]
//   dotnet ConsoleDialog.cs "GeoBlazor Build"                    Start with custom title
//   dotnet ConsoleDialog.cs "Build" -w 5 -t 120                  Custom wait/timeout
//
// Options:
//   -w, --wait <seconds>      Seconds to wait before closing on exit (default: 3)
//   -t, --timeout <seconds>   Idle timeout before auto-close (default: 60)
//
// Communication:
//   The dialog reads from stdin. Send lines of text to display in the console window.
//   Special commands:
//     "hold"  - Prevent auto-timeout (keeps window open indefinitely)
//     "exit"  - Close the console window
//
// Cross-Platform Support:
//   - Windows: Opens PowerShell 7 (pwsh) window with Get-Content -Wait
//   - macOS: Opens Terminal.app via osascript
//   - Linux: Tries gnome-terminal, konsole, xfce4-terminal, or xterm
//
// Note: Messages are written to a temp file and tailed by the console window.

using System.Diagnostics;

object _consoleLock = new();
Process? _consoleProcess = null;
string? _consoleTempFile = null;

string? title = null;
int wait = 3;
int idleTimeout = 60;

for (int i = 0; i < args.Length; i++)
{
    string arg = args[i];

    switch (arg)
    {
        case "-w":
        case "--wait":
            wait = int.TryParse(args[i + 1], out int parsedWait) ? parsedWait : wait;
            i++;
            break;
        case "-t":
        case "--timeout":
            idleTimeout = int.TryParse(args[i + 1], out int parsedTimeout) ? parsedTimeout : idleTimeout;
            i++;
            break;
        default:
            if (title is null)
            {
                title = arg;
            }
            else
            {
                title = $"{title} {arg}";
            }
            break;
    }
}

title ??= "GeoBlazor Build";

/// <summary>
/// Shows or updates the console window with a new message.
/// Creates the temp log file and starts the console window on first call.
/// </summary>
/// <param name="title">The title for the console window.</param>
/// <param name="message">The message to display (empty string to just ensure window is open).</param>
void ShowOrUpdateConsole(string title, string message)
{
    lock (_consoleLock)
    {
        // Ensure the temp file exists (create if needed)
        if (_consoleTempFile is null || !File.Exists(_consoleTempFile))
        {
            _consoleTempFile = Path.Combine(Path.GetTempPath(), $"geoblazor_sourcegen_{Guid.NewGuid():N}.log");
            // Create the file immediately so Get-Content -Wait has something to tail
            File.WriteAllText(_consoleTempFile, $" {Environment.NewLine}");
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

/// <summary>
/// Starts a platform-specific console window that tails the log file.
/// Dispatches to Windows, macOS, or Linux-specific implementations.
/// </summary>
/// <param name="title">The title for the console window.</param>
void StartConsoleWindow(string title)
{
    string windowTitle = string.IsNullOrWhiteSpace(title) ? "GeoBlazor Build" : title;
    try
    {
        if (OperatingSystem.IsWindows())
        {
            StartWindowsConsole(windowTitle);
        }
        else if (OperatingSystem.IsMacOS())
        {
            StartMacConsole(windowTitle);
        }
        else if (OperatingSystem.IsLinux())
        {
            StartLinuxConsole(windowTitle);
        }
    }
    catch
    {
        // Console window creation failed - continue silently
        // Messages are still written to the temp file and MSBuild diagnostics
    }
}

/// <summary>
/// Starts a PowerShell 7 console window on Windows using Get-Content -Wait to tail the log file.
/// </summary>
/// <param name="title">The title for the console window.</param>
void StartWindowsConsole(string title)
{
    string escapedPath = _consoleTempFile!.Replace("'", "''");
    string command = $"$Host.UI.RawUI.WindowTitle = '{title}'; " +
                   $"Write-Host '{title}' -ForegroundColor Cyan; " +
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

/// <summary>
/// Starts a Terminal.app window on macOS using osascript/AppleScript.
/// </summary>
void StartMacConsole(string title)
{
    string escapedPath = _consoleTempFile!.Replace("'", "'\\''");

    // Use osascript to open Terminal.app with a pwsh command
    string pwshCommand = "pwsh -NoProfile -NoLogo -Command \\\"" +
                       $"Write-Host '{title}' -ForegroundColor Cyan; " +
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

/// <summary>
/// Starts a terminal window on Linux by trying common terminal emulators
/// (gnome-terminal, konsole, xfce4-terminal, xterm) until one succeeds.
/// </summary>
void StartLinuxConsole(string title)
{
    string escapedPath = _consoleTempFile!.Replace("'", "'\\''");
    string pwshCommand = "pwsh -NoProfile -NoLogo -Command \\\"" +
                       $"Write-Host '{title}' -ForegroundColor Cyan; " +
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

/// <summary>
/// Closes the console window gracefully, waiting for final messages to display
/// before killing the process and cleaning up the temp file.
/// </summary>
/// <param name="title">The title (used in closing message).</param>
/// <param name="wait">Seconds to wait before killing the process.</param>
void CloseConsole(string title, int wait)
{
    lock (_consoleLock)
    {
        try
        {
            if (_consoleProcess is { HasExited: false } && _consoleTempFile is not null)
            {
                File.WriteAllText(_consoleTempFile, $"[{DateTime.Now:HH:mm:ss}] {title}: Console closing...");
                // Give a brief moment for final messages to appear
                Thread.Sleep(wait * 1000);
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

ShowOrUpdateConsole(title, string.Empty);

CancellationTokenSource cts = new();
cts.CancelAfter(TimeSpan.FromSeconds(60));

bool hold = false;
bool messageReceived = false;

_ = Task.Run(async () =>
{
    while ((!cts.IsCancellationRequested || hold)
        && (_consoleProcess is null || !_consoleProcess.HasExited))
    {
        await Task.Delay(1000);

        if (messageReceived)
        {
            cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(idleTimeout));
            messageReceived = false;
        }
    }
    Console.WriteLine("Console dialog timed out. Closing...");
    CloseConsole(title, wait);
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
        CloseConsole(title, wait);
        
        break;
    }

    messageReceived = true;
    ShowOrUpdateConsole(title, inputLine);
}

Environment.Exit(0);