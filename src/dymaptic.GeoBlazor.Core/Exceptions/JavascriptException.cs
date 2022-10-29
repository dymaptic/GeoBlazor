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
    public JavascriptException(string message, string name, string stack) : base(message)
    {
        Name = name;
        Stack = stack;
    }
    
    /// <summary>
    ///     The JavaScript stack trace.
    /// </summary>
    public string Stack { get; }
    
    /// <summary>
    ///     The name of the JavaScript error.
    /// </summary>
    public string Name { get; }
}