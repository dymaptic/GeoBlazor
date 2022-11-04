namespace dymaptic.GeoBlazor.Core.Exceptions;

/// <summary>
///     Converts a JavaScript Error into a .NET Exception
/// </summary>
public class JavascriptException : Exception
{
    /// <summary>
    ///     Creates a new Exception from a JavaScript Error
    /// </summary>
    /// <param name="message">
    ///     The JavaScript error message.
    /// </param>
    /// <param name="name">
    ///     The name of the JavaScript error.
    /// </param>
    /// <param name="stack">
    ///     The JavaScript stack trace.
    /// </param>
    public JavascriptException(JavascriptError error) : base(error.Message)
    {
        Name = error.Name;
        Stack = error.Stack;
    }
    
    /// <summary>
    ///     The JavaScript stack trace.
    /// </summary>
    public string? Stack { get; }
    
    /// <summary>
    ///     The name of the JavaScript error.
    /// </summary>
    public string? Name { get; }
}

public record JavascriptError(string Message, string? Name, string? Stack = null);