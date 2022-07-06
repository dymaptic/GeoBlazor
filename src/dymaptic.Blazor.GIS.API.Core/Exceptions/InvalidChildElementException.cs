namespace dymaptic.Blazor.GIS.API.Core.Exceptions;

public class InvalidChildElementException : Exception
{
    public InvalidChildElementException(string parentType, string childType) :
        base($"The type {childType} cannot be added as a child of type {parentType}")
    {
    }
}