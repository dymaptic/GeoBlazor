namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the GeoJSONLayer class.
/// </summary>
public static partial class GeoJSONLayerProExtensions
{
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#geojsonlayerqueryfeatures-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the layer and returns a
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html">FeatureSet</a> once the promise resolves.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#queryFeatures">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayer">
    ///     The <see cref="GeoJSONLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, then all features satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public static async Task<FeatureSet?> QueryFeatures(this GeoJSONLayer geoJSONLayer,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (geoJSONLayer.CoreJsModule is null)
        {
            return null;
        }

        geoJSONLayer.JsComponentReference ??= await geoJSONLayer.CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", geoJSONLayer.CancellationTokenSource.Token, geoJSONLayer.Id);

        if (geoJSONLayer.JsComponentReference is null) return null;

        geoJSONLayer.AbortManager ??= new AbortManager(geoJSONLayer.CoreJsModule!);
        IJSObjectReference abortSignal = await geoJSONLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        Guid queryId = Guid.NewGuid();

        FeatureSet result = (await geoJSONLayer.JsComponentReference!.InvokeAsync<FeatureSet?>("queryFeatures",
            cancellationToken,
            query, new { signal = abortSignal }, geoJSONLayer.DotNetComponentReference, queryId))!;

        if (geoJSONLayer.ActiveQueries.ContainsKey(queryId))
        {
            result = result with { Features = geoJSONLayer.ActiveQueries[queryId] };
            geoJSONLayer.ActiveQueries.Remove(queryId);
        }

        foreach (Graphic graphic in result.Features!)
        {
            graphic.View = geoJSONLayer.View;
            graphic.Parent = geoJSONLayer;
#pragma warning disable BL0005
            graphic.Layer = geoJSONLayer;
#pragma warning restore BL0005
            graphic.CoreJsModule = geoJSONLayer.CoreJsModule;
        }

        await geoJSONLayer.AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }
}