namespace dymaptic.GeoBlazor.Core.Exceptions;

/// <summary>
///     Exception thrown when a component is added to the wrong type of parent component.
/// </summary>
public class InvalidChildElementException : Exception
{
    /// <summary>
    ///     Constructs an InvalidChildElementException.
    /// </summary>
    /// <param name="parentType">
    ///     The parent type attempting to register the child.
    /// </param>
    /// <param name="childType">
    ///     The child type attempting to register with the parent.
    /// </param>
    public InvalidChildElementException(string parentType, string childType) :
        base($"The type {childType} cannot be added as a child of type {parentType}")
    {
    }
}