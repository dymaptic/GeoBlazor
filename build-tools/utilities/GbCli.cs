namespace Utilities;

public static class GbCli
{
    /// <summary>
    ///     Writes a formatted step header to the console with colored background.
    /// </summary>
    /// <param name="step">The step number.</param>
    /// <param name="description">A description of what this step does.</param>
    public static void WriteStepHeader(int step, string description)
    {
        int windowWidth = GetWindowWidth();

        int stepLength = step.ToString().Length;
        int descriptionLength = stepLength + 2 + description.Length; // 2 for period and space after step #

        while (descriptionLength > windowWidth)
        {
            descriptionLength -= windowWidth; // if the line is too long, let it wrap, but only count the last line
        }

        string timestamp = DateTime.Now.ToString("HH:mm:ss");
        int timestampLength = timestamp.Length;

        // calculate the buffer space between the description and the timestamp,
        // to place the timestamp 1 column from the right
        int buffer = windowWidth - descriptionLength - timestampLength - 1;

        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.ForegroundColor = ConsoleColor.White;

        if (buffer > 0)
        {
            Console.Write($"{step}. {description}{new string(' ', buffer)}{timestamp}");
        }
        else
        {
            // the description was too long, the timestamp doesn't fit on the same line, move it to the next line
            // buffer to the end of the description line
            buffer = windowWidth - descriptionLength - 1;
            Console.WriteLine($"{step}. {description}{new string(' ', buffer)}");

            // buffer to the end of the timestamp line, but start aligned with the description
            buffer = windowWidth - timestampLength - stepLength - 3;
            Console.Write($"{new string(' ', stepLength + 2)}{timestamp}{new string(' ', buffer)}");
        }

        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();
    }

    /// <summary>
    ///     Writes a step completion message showing elapsed time.
    /// </summary>
    /// <param name="step">The step number that completed.</param>
    /// <param name="stepStartTime">The time when this step started.</param>
    public static void WriteStepCompleted(int step, DateTime stepStartTime)
    {
        int windowWidth = GetWindowWidth();
        TimeSpan elapsed = DateTime.Now - stepStartTime;
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.ForegroundColor = ConsoleColor.Black;
        string content = $"Step {step} completed in {elapsed}.";
        int contentLength = content.Length;
        int bufferLength = windowWidth - contentLength - 1;
        Console.Write($"{content}{new string(' ', bufferLength)}");
        Console.ResetColor();
        Console.WriteLine();
    }

    public static int GetWindowWidth()
    {
        int windowWidth = 120;

        if (!Console.IsOutputRedirected)
        {
            windowWidth = Console.WindowWidth;
            Environment.SetEnvironmentVariable("CONSOLE_WIDTH", windowWidth.ToString());
        }
        else if (Environment.GetEnvironmentVariable("CONSOLE_WIDTH") is { } envWidthString
            && int.TryParse(envWidthString, out int envWidth))
        {
            windowWidth = envWidth - 2; // subtract 2 for child process indentation in ProcessRunner.cs
        }

        return windowWidth;
    }
}