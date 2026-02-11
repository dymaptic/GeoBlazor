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
        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"{step}. {description}");
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
        var elapsed = DateTime.Now - stepStartTime;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write($"Step {step} completed in {elapsed}.");
        Console.ResetColor();
        Console.WriteLine();
    }
}