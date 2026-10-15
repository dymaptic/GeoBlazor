namespace dymaptic.GeoBlazor.Pro.Components;

/// <summary>
///     Pro Extension methods for the ImageryTileLayerView class.
/// </summary>
public static partial class ImageryTileLayerViewProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.ImageryTileLayerView.html#imagerytilelayerviewgetsourcescale-method">GeoBlazor Docs</a>
    ///     Returns the map scale that corresponds to the source level of raster data.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-ImageryTileLayerView.html#getSourceScale">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryTileLayerView">
    ///     The <see cref="ImageryTileLayerView"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<double?> GetSourceScale(this ImageryTileLayerView imageryTileLayerView)
    {
        if (imageryTileLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            imageryTileLayerView.JsComponentReference ??= await imageryTileLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", imageryTileLayerView.CancellationTokenSource.Token, imageryTileLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (imageryTileLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        return await imageryTileLayerView.JsComponentReference!.InvokeAsync<double?>(
            "getSourceScale", 
            imageryTileLayerView.CancellationTokenSource.Token);
    }
    

}