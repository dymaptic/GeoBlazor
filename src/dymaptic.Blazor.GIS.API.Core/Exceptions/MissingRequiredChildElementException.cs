namespace dymaptic.Blazor.GIS.API.Core.Exceptions;

public class MissingRequiredChildElementException : Exception
{
    public MissingRequiredChildElementException(string parentType, string childType) :
        base($"The type {childType} must be added as a child of type {parentType}")
    {
    }
}