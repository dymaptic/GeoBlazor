using System.Diagnostics;
using System.Text;


namespace dymaptic.GeoBlazor.Core.Test.Automation;

public class StringBuilderTraceListener(StringBuilder builder) : TraceListener
{
    public override void Write(string? message)
    {
        builder.Append(message);
    }

    public override void WriteLine(string? message)
    {
        builder.AppendLine($"{DateTime.Now:u} {message}");
    }
}