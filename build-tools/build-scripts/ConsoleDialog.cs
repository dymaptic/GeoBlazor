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
int idleTimeout = 300;

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
            string logLine = $"[{timestamp}] {message}{Environment.NewLine}";
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
/// Detects if running under Windows Subsystem for Linux.
/// </summary>
bool IsWsl()
{
    try
    {
        if (File.Exists("/proc/version"))
        {
            string version = File.ReadAllText("/proc/version");
            return version.Contains("microsoft", StringComparison.OrdinalIgnoreCase);
        }
    }
    catch { }
    return false;
}

/// <summary>
/// Starts a platform-specific console window that tails the log file.
/// Dispatches to Windows, macOS, WSL, or Linux-specific implementations.
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
            if (IsWsl())
            {
                StartWslConsole(windowTitle);
            }
            else
            {
                StartLinuxConsole(windowTitle);
            }
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
                   $"Write-Host ('=' * 120); " +
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
/// Uses tail -f for log following (no pwsh dependency required).
/// </summary>
void StartMacConsole(string title)
{
    // Escape for single-quoted shell strings
    string shellTitle = title.Replace("'", "'\\''");
    string shellPath = _consoleTempFile!.Replace("'", "'\\''");

    // Build the shell command for the visible Terminal window
    // clear removes the login banner and echoed command that Terminal.app shows
    string shellCommand = $"clear; echo '{shellTitle}'; echo '{new string('=', 80)}'; tail -f '{shellPath}'";

    // Escape the shell command for embedding in an AppleScript double-quoted string
    string asCommand = shellCommand.Replace("\\", "\\\\").Replace("\"", "\\\"");

    // Pass AppleScript via stdin to avoid nested shell escaping issues
    string appleScript = "tell application \"Terminal\"\n" +
                         "    activate\n" +
                         $"    do script \"{asCommand}\"\n" +
                         "end tell";

    var osascript = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "osascript",
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardInput = true
        }
    };
    osascript.Start();
    osascript.StandardInput.Write(appleScript);
    osascript.StandardInput.Close();
    osascript.WaitForExit(5000);

    // osascript exits immediately after telling Terminal to open, so start a
    // long-lived sentinel process for lifecycle tracking by the main loop
    _consoleProcess = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "sleep",
            Arguments = "86400",
            UseShellExecute = false,
            CreateNoWindow = true
        }
    };
    _consoleProcess.Start();
}

/// <summary>
/// Starts a console window from WSL by using Windows Terminal (wt.exe) to open
/// a new tab that runs tail -f back inside WSL. Falls back to standard Linux
/// terminals if Windows Terminal is not available.
/// </summary>
/// <remarks>
/// Uses a temp script file instead of bash -c to avoid wt.exe interpreting
/// semicolons as its own command delimiters.
/// </remarks>
void StartWslConsole(string title)
{
    // Write a helper bash script to avoid wt.exe's ';' delimiter parsing issues.
    // wt.exe treats ';' as a separator for multiple tab/pane commands, so passing
    // "echo '...'; tail -f '...'" via bash -c gets split into separate WT commands.
    string scriptFile = _consoleTempFile + ".sh";
    string shellTitle = title.Replace("'", "'\\''");
    string shellPath = _consoleTempFile!.Replace("'", "'\\''");
    File.WriteAllText(scriptFile,
        $"#!/bin/bash\necho '{shellTitle}'\necho '{new string('=', 80)}'\ntail -f '{shellPath}'\n");

    // Try Windows Terminal (wt.exe) - available on most modern Windows 10/11 + WSL setups
    try
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "wt.exe",
            UseShellExecute = false,
            CreateNoWindow = true
        };
        startInfo.ArgumentList.Add("new-tab");
        startInfo.ArgumentList.Add("--title");
        startInfo.ArgumentList.Add(title);
        startInfo.ArgumentList.Add("--");
        startInfo.ArgumentList.Add("wsl.exe");
        startInfo.ArgumentList.Add("bash");
        startInfo.ArgumentList.Add(scriptFile);

        var wtProcess = new Process { StartInfo = startInfo };
        wtProcess.Start();
        wtProcess.WaitForExit(5000); // wt.exe exits immediately after dispatching

        // wt.exe exits immediately (delegates to Windows Terminal server),
        // so use a sentinel process for lifecycle tracking
        _consoleProcess = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "sleep",
                Arguments = "86400",
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        _consoleProcess.Start();
        return;
    }
    catch
    {
        // wt.exe not available, clean up script and fall through
        try { File.Delete(scriptFile); } catch { }
    }

    // Fallback: try standard Linux terminal emulators (unlikely to work in WSL, but try anyway)
    StartLinuxConsole(title);
}

/// <summary>
/// Starts a terminal window on Linux by trying common terminal emulators
/// (gnome-terminal, konsole, xfce4-terminal, xterm) until one succeeds.
/// Uses tail -f for log following (no pwsh dependency required).
/// </summary>
void StartLinuxConsole(string title)
{
    string shellTitle = title.Replace("'", "'\\''");
    string shellPath = _consoleTempFile!.Replace("'", "'\\''");

    // Shell command to display title banner and follow the log file
    string shellCommand = $"echo '{shellTitle}'; echo '{new string('=', 80)}'; tail -f '{shellPath}'";

    // Try common Linux terminal emulators in order of popularity
    // Use ArgumentList to pass args directly as argv, avoiding shell escaping issues
    string[] terminals = ["gnome-terminal", "konsole", "xfce4-terminal", "xterm"];

    foreach (string terminal in terminals)
    {
        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = terminal,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Each terminal uses a different flag to specify the command to run
            if (terminal == "gnome-terminal")
            {
                // gnome-terminal uses -- to separate its args from the child command
                startInfo.ArgumentList.Add("--");
            }
            else
            {
                // konsole, xfce4-terminal, xterm all use -e
                startInfo.ArgumentList.Add("-e");
            }

            startInfo.ArgumentList.Add("bash");
            startInfo.ArgumentList.Add("-c");
            startInfo.ArgumentList.Add(shellCommand);

            var terminalProcess = new Process { StartInfo = startInfo };
            terminalProcess.Start();

            // gnome-terminal exits immediately (delegates to the GNOME Terminal server),
            // so use a sentinel process for lifecycle tracking, consistent with macOS
            _consoleProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "sleep",
                    Arguments = "86400",
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
/// Closes the Terminal.app window on macOS by finding and closing the tab
/// that is running tail -f on our temp file.
/// </summary>
void CloseMacTerminalWindow(string tempFilePath)
{
    try
    {
        string escapedPath = tempFilePath.Replace("\\", "\\\\").Replace("\"", "\\\"");

        // AppleScript to find and close the Terminal tab running our tail command
        string appleScript =
            "tell application \"Terminal\"\n" +
            "    repeat with w in windows\n" +
            "        repeat with t in tabs of w\n" +
            $"            if processes of t contains \"tail\" and history of t contains \"{escapedPath}\" then\n" +
            "                close w\n" +
            "                return\n" +
            "            end if\n" +
            "        end repeat\n" +
            "    end repeat\n" +
            "end tell";

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "osascript",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardInput = true
            }
        };
        process.Start();
        process.StandardInput.Write(appleScript);
        process.StandardInput.Close();
        process.WaitForExit(5000);
    }
    catch
    {
        // Terminal may have already been closed
    }
}

/// <summary>
/// Closes a Linux terminal window by killing the tail process that is
/// following our specific temp file. When tail exits, bash -c completes,
/// and the terminal emulator closes the window.
/// </summary>
void CloseLinuxTerminalWindow(string tempFilePath)
{
    try
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "pkill",
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        // Use ArgumentList so the pattern is passed as a single argv element
        process.StartInfo.ArgumentList.Add("-f");
        process.StartInfo.ArgumentList.Add($"tail -f {tempFilePath}");
        process.Start();
        process.WaitForExit(5000);
    }
    catch
    {
        // Process may have already exited
    }
}

bool _cleanupComplete = false;

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

            // Close the platform-specific terminal window (sentinel process doesn't own it)
            if (OperatingSystem.IsMacOS() && _consoleTempFile is not null)
            {
                CloseMacTerminalWindow(_consoleTempFile);
            }
            else if (OperatingSystem.IsLinux() && _consoleTempFile is not null)
            {
                CloseLinuxTerminalWindow(_consoleTempFile);
            }
            
            // delete the temp file and WSL helper script
            if (_consoleTempFile is not null)
            {
                File.Delete(_consoleTempFile);
                // Clean up the WSL helper script if it exists
                string scriptFile = _consoleTempFile + ".sh";
                if (File.Exists(scriptFile)) File.Delete(scriptFile);
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
            _cleanupComplete = true;
        }
    }
}

ShowOrUpdateConsole(title, string.Empty);

bool hold = false;
long lastMessageTicks = DateTime.UtcNow.Ticks;

_ = Task.Run(async () =>
{
    while (_consoleProcess is null || !_consoleProcess.HasExited)
    {
        await Task.Delay(1000);

        if (!hold && (DateTime.UtcNow.Ticks - Volatile.Read(ref lastMessageTicks)) > (long)idleTimeout * TimeSpan.TicksPerSecond)
        {
            Console.WriteLine("Console dialog timed out. Closing...");
            CloseConsole(title, wait);
            Environment.Exit(0);
        }
    }
    Console.WriteLine("Console window closed. Exiting...");
    CloseConsole(title, wait);
    Environment.Exit(0);
});

// Handle Ctrl-C gracefully
Console.CancelKeyPress += (sender, e) =>
{
    e.Cancel = true; // Prevent immediate termination to allow cleanup

    _ = Task.Run(() => CloseConsole(title, wait));

    int timeoutSeconds = wait * 2;

    while (!_cleanupComplete && (timeoutSeconds > 0))
    {
        Thread.Sleep(1000);
        timeoutSeconds--;
    }

    if (_cleanupComplete)
    {
        Environment.Exit(1);
        return;
    }
};

while (true)
{
    if (_consoleProcess?.HasExited == true)
    {
        break;
    }

    if (Console.ReadLine() is not { } inputLine)
    {
        Thread.Sleep(100);
        continue;
    }

    Volatile.Write(ref lastMessageTicks, DateTime.UtcNow.Ticks);

    if (inputLine.Trim().Equals("hold", StringComparison.OrdinalIgnoreCase))
    {
        hold = true;
        continue;
    }

    if (inputLine.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        CloseConsole(title, wait);

        break;
    }

    ShowOrUpdateConsole(title, inputLine);
}

Environment.Exit(0);