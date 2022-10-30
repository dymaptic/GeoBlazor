namespace dymaptic.GeoBlazor.Core.Exceptions;

public class UnMatchedTargetNameException: Exception
{
    public UnMatchedTargetNameException(string targetName, string watchExpression) : base(
        $"The watch expression \"{watchExpression}\" does not target the target name \"{targetName}\". Make sure these parameters match.")
    {
    }
}