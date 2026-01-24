namespace dymaptic.GeoBlazor.Core.Test.Automation;

public static class Utilities
{
    public static Process? StartConsoleDialog(string buildDir, string title)
    {
        try
        {
            string consoleDialogPath = Path.Combine(buildDir, "ConsoleDialog.dll");

            if (!File.Exists(consoleDialogPath))
            {
                Trace.WriteLine($"ConsoleDialog.dll not found at {consoleDialogPath}");

                return null;
            }

            string[] args =
            [
                "ConsoleDialog.dll",
                $"\"{title}\"",
                "-w",
                "2"
            ];

            var psi = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = string.Join(" ", args),
                WorkingDirectory = buildDir,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process? dialog = Process.Start(psi);

            if (dialog?.StandardInput is null)
            {
                Trace.WriteLine("Failed to start console dialog. Exiting.");
            }
            else
            {
                dialog.StandardInput.AutoFlush = true;
                Trace.Listeners.Add(new DialogTraceListener(dialog));
            }

            return dialog;
        }
        catch (Exception ex)
        {
            Trace.WriteLine($"Failed to start ConsoleDialog: {ex.Message}");

            return null;
        }
    }

    public static void KillDialog(Process? dialog)
    {
        if (dialog is null || dialog.HasExited)
        {
            return;
        }

        try
        {
            // Flush to ensure all pending messages are sent before exit
            dialog.StandardInput.Flush();

            // Small delay to allow the dialog to display the final message
            Thread.Sleep(500);
            dialog.StandardInput.WriteLine("exit");
        }
        catch
        {
            dialog.Kill();
        }
    }
}

public class DialogTraceListener(Process? dialog) : TraceListener
{
    public override void Write(string? message)
    {
        if (dialog?.StandardInput is null || dialog.HasExited)
        {
            return;
        }

        try
        {
            dialog.StandardInput.Write(message);
        }
        catch
        {
            // Dialog may have closed - ignore
        }
    }

    public override void WriteLine(string? message)
    {
        if (dialog?.StandardInput is null || dialog.HasExited)
        {
            return;
        }

        try
        {
            dialog.StandardInput.WriteLine(message);
        }
        catch
        {
            // Dialog may have closed - ignore
        }
    }
}