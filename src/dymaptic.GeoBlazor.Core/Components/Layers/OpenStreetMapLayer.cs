namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Allows you to use basemaps from OpenStreetMap. Set the tileservers property to change which OpenStreetMap tiles you
///     want to use.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-OpenStreetMapLayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class OpenStreetMapLayer : WebTileLayer
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public OpenStreetMapLayer()
    {
    }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="portalItem">
    ///     The portal item from which to load the layer.
    /// </param>
    /// <param name="title">
    ///     The title of the layer used to identify it in places such as the Legend and LayerList widgets.
    /// </param>
    /// <param name="tileInfo">
    ///     The tiling scheme information for the layer.
    /// </param>
    /// <param name="opacity">
    ///     The opacity of the layer.
    /// </param>
    /// <param name="visible">
    ///     Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is
    ///     referenced in a view, but its features will not be visible in the view.
    /// </param>
    /// <param name="listMode">
    ///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
    /// </param>
    /// <param name="blendMode">
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what
    ///     seems like a new layer.
    /// </param>
    /// <param name="copyright">
    ///     The attribution information for the layer.
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view.
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view.
    /// </param>
    /// <param name="refreshInterval">
    ///     Refresh interval of the layer in minutes.
    /// </param>
    /// <param name="subDomains">
    ///     A string of subDomain names where tiles are served to speed up tile retrieval. If subDomains are specified, the
    ///     UrlTemplate should include a {subDomain} place holder.
    /// </param>
    public OpenStreetMapLayer(PortalItem? portalItem = null, string? title = null, BlendMode? blendMode = null,
        string? copyright = null, double? maxScale = null, double? minScale = null, double? refreshInterval = null,
        IReadOnlyList<string>? subDomains = null, TileInfo? tileInfo = null, double? opacity = null, bool? visible = null,
        ListMode? listMode = null)
    {
#pragma warning disable BL0005
        Title = title;
        Opacity = opacity;
        Visible = visible;
        ListMode = listMode;
        PortalItem = portalItem;
        TileInfo = tileInfo;
        BlendMode = blendMode;
        Copyright = copyright;
        MaxScale = maxScale;
        MinScale = minScale;
        RefreshInterval = refreshInterval;
        SubDomains = subDomains;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    public override string LayerType => "open-street-map";
}