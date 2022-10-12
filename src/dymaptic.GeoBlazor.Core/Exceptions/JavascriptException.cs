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
    ///     The JavaScript error stacktrace and/or message.
    /// </param>
    public JavascriptException(string message) : base(message)
    {
    }
}