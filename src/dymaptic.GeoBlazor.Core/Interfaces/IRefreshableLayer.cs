namespace dymaptic.GeoBlazor.Core.Interfaces;


public partial interface IRefreshableLayer
{
    public ValueTask Refresh();
}