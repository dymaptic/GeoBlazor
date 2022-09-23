namespace dymaptic.GeoBlazor.Core.Exceptions;

public class MissingRequiredChildElementException : Exception
{
    public MissingRequiredChildElementException(string parentType, string childType) :
        base($"The type {childType} must be added as a child of type {parentType}")
    {
    }
}

public class MissingRequiredOptionsChildElementException : Exception
{
    public MissingRequiredOptionsChildElementException(string parentType, IEnumerable<string> options) :
        base($"One of the types in [ {string.Join(", ", options)} ] must be added as a child of type {parentType}")
    {
    }
}