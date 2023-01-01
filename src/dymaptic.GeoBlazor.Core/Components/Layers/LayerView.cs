using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Represents the view for a single layer after it has been added to either a MapView or a SceneView.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">ArcGIS JS API</a>
/// </summary>

/// <param name="SpatialReferenceSupported">
///     
/// </param>
/// <param name="Suspended">
///     Value is true if the layer is suspended (i.e., layer will not redraw or update itself when the extent changes).
/// </param>
/// <param name="Updating">
///     
/// </param>
/// <param name="Visible">
///     
/// </param>
public class LayerView
{
    /// <summary>
    ///     The layer being viewed.
    /// </summary>
    public Layer Layer { get; set; }
    
    /// <summary>
    ///    The JavaScript object reference used by the LayerView.
    /// </summary>
    public IJSObjectReference? JsObjectReference { get; set; }
    
    /// <summary>
    ///     Indicates if the spatialReference of the MapView is supported by the layer view.
    /// </summary>
    public bool SpatialReferenceSupported { get; init; }
    
    /// <summary>
    ///     Value is true if the layer is suspended (i.e., layer will not redraw or update itself when the extent changes).
    /// </summary>
    public bool Suspended { get; init; }
    
    /// <summary>
    ///     Value is true when the layer is updating; for example, if it is in the process of fetching data.
    /// </summary>
    public bool Updating { get; init; }
    
    /// <summary>
    ///     Value is true when the layer is updating; for example, if it is in the process of fetching data.
    /// </summary>
    public bool Visible { get; init; }
}

public class FeatureLayerView: LayerView
{
    public FeatureLayerView(LayerView layerView)
    {
        Layer = layerView.Layer;
        JsObjectReference = layerView.JsObjectReference;
        SpatialReferenceSupported = layerView.SpatialReferenceSupported;
        Suspended = layerView.Suspended;
        Updating = layerView.Updating;
        Visible = layerView.Visible;
    }
    
    /// <summary>
    ///    Highlights the given feature(s).
    /// </summary>
    /// <param name="objectId">
    ///     The ObjectID of the graphic to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    public async Task<HighlightHandle> Highlight(int objectId)
    {
        IJSObjectReference objectRef = 
            await JsObjectReference!.InvokeAsync<IJSObjectReference>("highlight", objectId);
        return new HighlightHandle(objectRef);
    }
    
    /// <summary>
    ///    Highlights the given feature(s).
    /// </summary>
    /// <param name="objectIds">
    ///     The ObjectIDs of the graphics to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    public async Task<HighlightHandle> Highlight(IEnumerable<int> objectIds)
    {
        IJSObjectReference objectRef = 
            await JsObjectReference!.InvokeAsync<IJSObjectReference>("highlight", objectIds);
        return new HighlightHandle(objectRef);
    }
    
    /// <summary>
    ///    Highlights the given feature(s).
    /// </summary>
    /// <param name="graphic">
    ///     The <see cref="Graphic"/> to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    public async Task<HighlightHandle> Highlight(Graphic graphic)
    {
        IJSObjectReference objectRef = 
            await JsObjectReference!.InvokeAsync<IJSObjectReference>("highlight", graphic);
        return new HighlightHandle(objectRef);
    }

    /// <summary>
    ///    Highlights the given feature(s).
    /// </summary>
    /// <param name="graphics">
    ///     The graphics to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    public async Task<HighlightHandle> Highlight(IEnumerable<Graphic> graphics)
    {
        IJSObjectReference objectRef = 
            await JsObjectReference!.InvokeAsync<IJSObjectReference>("highlight", graphics);
        return new HighlightHandle(objectRef);
    }

    /// <summary>
    ///     Creates query parameter object that can be used to fetch features as they are being displayed. It sets the query parameter's outFields property to ["*"] and returnGeometry to true. The output spatial reference outSpatialReference is set to the spatial reference of the view. Parameters of the filter currently applied to the layerview are also incorporated in the returned query object. The results will include geometries of features and values for availableFields.
    /// </summary>
    public async Task<Query> CreateQuery()
    {
        return await JsObjectReference!.InvokeAsync<Query>("createQuery");
    }
    
    /// <summary>
    ///     Executes a Query against features available for drawing in the layerView and returns array of the ObjectIDs of features that satisfy the input query. If query parameters are not provided, the ObjectIDs of all features available for drawing are returned.
    ///     To query for ObjectIDs of features directly from a Feature Service rather than those visible in the view, you must use the FeatureLayer.queryObjectIds() method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the geometry parameter in the query object to the view's extent.
    /// </param>
    public async Task<int[]> QueryObjectIds(Query query)
    {
        return await JsObjectReference!.InvokeAsync<int[]>("queryObjectIds", query);
    }
}

#pragma warning disable CS1574, CS0419
/// <summary>
///     A handle to a <see cref="LayerView.Highlight"/> call result. The handle can be used to remove the installed highlight.
/// </summary>
/// <param name="JsObjectReference">
///     The JavaScript object reference used by the handle.
/// </param>
#pragma warning restore CS1574, CS0419
public record HighlightHandle(IJSObjectReference JsObjectReference)
{
    /// <summary>
    ///    Removes the highlight.
    /// </summary>
    public async Task Remove()
    {
        await JsObjectReference.InvokeVoidAsync("remove");
    }
}