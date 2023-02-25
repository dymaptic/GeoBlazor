namespace dymaptic.GeoBlazor.Core.Exceptions;

/// <summary>
///     Converts a JavaScript Error into a .NET Exception
/// </summary>
public class JavascriptException : Exception
{
    /// <summary>
    ///     Creates a new Exception from a JavaScript Error
    /// </summary>
    /// <param name="error">
    ///     The original JavaScript error.
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

/// <summary>
///     A JavaScript error
/// </summary>
/// <param name="Message">
///     The message of the error.
/// </param>
/// <param name="Name">
///     The name of the error.
/// </param>
/// <param name="Stack">
///     The stack trace of the error.
/// </param>
public record JavascriptError(string? Message, string? Name, string? Stack = null);