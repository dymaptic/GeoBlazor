namespace dymaptic.Blazor.GIS.API.Core.Exceptions;

public class MissingMapException : Exception
{
    public MissingMapException() :
        base("No map or web map was provided")
    {
    }
}