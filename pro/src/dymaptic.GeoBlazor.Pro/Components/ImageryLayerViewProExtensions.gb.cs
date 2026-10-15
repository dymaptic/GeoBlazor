namespace dymaptic.GeoBlazor.Pro.Components;

/// <summary>
///     Pro Extension methods for the ImageryLayerView class.
/// </summary>
public static partial class ImageryLayerViewProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.ImageryLayerView.html#imagerylayerviewgetsourcescale-method">GeoBlazor Docs</a>
    ///     Returns the map scale that corresponds to the source level of raster data.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-ImageryLayerView.html#getSourceScale">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayerView">
    ///     The <see cref="ImageryLayerView"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<double?> GetSourceScale(this ImageryLayerView imageryLayerView)
    {
        if (imageryLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            imageryLayerView.JsComponentReference ??= await imageryLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", imageryLayerView.CancellationTokenSource.Token, imageryLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (imageryLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        return await imageryLayerView.JsComponentReference!.InvokeAsync<double?>(
            "getSourceScale", 
            imageryLayerView.CancellationTokenSource.Token);
    }
    

}