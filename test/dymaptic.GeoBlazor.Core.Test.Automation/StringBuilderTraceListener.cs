namespace dymaptic.GeoBlazor.Core.Test.Automation;

public class StringBuilderTraceListener(Dictionary<string, Dictionary<DateTime, string>> builders) : TraceListener
{
    public override void Write(string? message)
    {
        Write(message, "NO_CATEGORY");
    }

    public override void Write(string? message, string? category)
    {
        _skipNextLineBreak = true;
        WriteLine(message, category);
    }

    public override void WriteLine(string? message)
    {
        WriteLine(message, "NO_CATEGORY");
    }

    public override void WriteLine(string? message, string? category)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            return;
        }

        category ??= "NO_CATEGORY";

        var isError = category.EndsWith("_ERROR");

        category = isError ? category.Substring(0, category.Length - 6) : category;

        if (!builders.TryGetValue(category, out var builder))
        {
            builder = new Dictionary<DateTime, string>();
            builders[category] = builder;
        }

        if (_skipNextLineBreak && (builder.Count > 0))
        {
            var lastEntry = builder.Last();
            var lastMessage = lastEntry.Value;
            lastMessage += message;
            builder[lastEntry.Key] = lastMessage;
        }
        else
        {
            builder[DateTime.Now] = isError ? $"ERROR: {message}" : message;
        }

        _skipNextLineBreak = false;
    }

    private bool _skipNextLineBreak;
}

// Writes each trace line to disk immediately (AutoFlush) so a hung/cancelled run still leaves a current log.
public class IncrementalLogFileTraceListener : TextWriterTraceListener
{
    public IncrementalLogFileTraceListener(string logFilePath)
        : base(new StreamWriter(logFilePath, append: false) { AutoFlush = true })
    {
    }

    public override void Write(string? message)
    {
        Write(message, "NO_CATEGORY");
    }

    public override void Write(string? message, string? category)
    {
        _skipNextLineBreak = true;
        WriteLine(message, category);
    }

    public override void WriteLine(string? message)
    {
        WriteLine(message, "NO_CATEGORY");
    }

    public override void WriteLine(string? message, string? category)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            return;
        }

        category ??= "NO_CATEGORY";

        var isError = category.EndsWith("_ERROR");
        category = isError ? category.Substring(0, category.Length - 6) : category;
        var text = isError ? $"ERROR: {message}" : message;

        if (_skipNextLineBreak)
        {
            // continuation of the previous line, append without timestamp prefix
            Writer?.Write(text);
        }
        else
        {
            Writer?.WriteLine($"[{DateTime.Now:u}] {category}: {text}");
        }

        _skipNextLineBreak = false;
    }

    private bool _skipNextLineBreak;
}