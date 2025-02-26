namespace dymaptic.GeoBlazor.Core.Interfaces;

[JsonConverter(typeof(MultiTypeConverter<IRefreshableLayer>))]
public partial interface IRefreshableLayer
{
    [CodeGenerationIgnore]
    public ValueTask Refresh();
}