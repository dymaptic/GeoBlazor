namespace dymaptic.GeoBlazor.Core.Exceptions;

/// <summary>
///     This exception is thrown when a watchExpression's target object name doesn't match the targetName parameter.
/// </summary>
public class UnMatchedTargetNameException : Exception
{
    /// <summary>
    ///     Creates a new <see cref="UnMatchedTargetNameException" />
    /// </summary>
    /// <param name="targetName">
    ///     The targetName parameter from the throwing method.
    /// </param>
    /// <param name="watchExpression">
    ///     The watchExpression parameter from the throwing method.
    /// </param>
    public UnMatchedTargetNameException(string targetName, string watchExpression) :
        base(
            $"The watch expression \"{watchExpression}\" does not target the target name \"{targetName}\". Make sure these parameters match.")
    {
    }
}