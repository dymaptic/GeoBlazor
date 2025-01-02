namespace dymaptic.GeoBlazor.Core.Interfaces;


public partial interface IRefreshableLayer
{
    [CodeGenerationIgnore]
    public ValueTask Refresh();
}