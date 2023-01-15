namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Allows you to use basemaps from OpenStreetMap. Set the tileservers property to change which OpenStreetMap tiles you want to use.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-OpenStreetMapLayer.html">ArcGIS JS API</a>
/// </summary>
public class OpenStreetMapLayer: WebTileLayer
{
    /// <inheritdoc />
    public override string LayerType => "open-street-map";
}