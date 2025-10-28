namespace dymaptic.GeoBlazor.Core.Exceptions;

/// <summary>
///     An exception that specifies that a required child component was not added to the parent.
/// </summary>
public class MissingRequiredChildElementException : Exception
{
    /// <summary>
    ///     Generates a new MissingRequiredChildElementException
    /// </summary>
    /// <param name="parentType">
    ///     The parent type with a required child.
    /// </param>
    /// <param name="childType">
    ///     The missing required child type.
    /// </param>
    public MissingRequiredChildElementException(string parentType, string childType) :
        base($"The type {childType} must be added as a child of type {parentType}")
    {
    }
}

/// <summary>
///     An exception that specifies that none of the choices of required child components were added.
/// </summary>
public class MissingRequiredOptionsChildElementException : Exception
{
    /// <summary>
    ///     Generates a new MissingRequiredOptionsChildElementException
    /// </summary>
    /// <param name="parentType">
    ///     The parent type which requires one child out of a collection of options.
    /// </param>
    /// <param name="options">
    ///     The potential required children, none of which were present.
    /// </param>
    public MissingRequiredOptionsChildElementException(string parentType, IEnumerable<string> options) :
        base($"One of the types in [ {string.Join(", ", options)} ] must be added as a child of type {parentType}")
    {
    }
}

/// <summary>
///     An exception that specifies that a specific child component/parameter must be added when another specific parameter is assigned.
/// </summary>
/// <param name="parentType">
///     The parent type.
/// </param>
/// <param name="assignedParameter">
///     A parameter which, when assigned, requires another parameter as well.
/// </param>
/// <param name="childType">
///     The missing required child type/parameter.
/// </param>
public class MissingConditionallyRequiredChildElementException(string parentType, string assignedParameter, 
    string childType) :
    Exception($"The type {childType} must be added as a child of type {parentType} when {assignedParameter} is also assigned.")
{
}