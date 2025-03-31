namespace dymaptic.GeoBlazor.Core.Interfaces;

[JsonConverter(typeof(MultiTypeConverter<IRefreshableLayer>))]
public partial interface IRefreshableLayer
{
    /// <summary>
    ///     Fetches all the data for the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-RefreshableLayer.html#refresh">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [CodeGenerationIgnore]
    public ValueTask Refresh();
}
