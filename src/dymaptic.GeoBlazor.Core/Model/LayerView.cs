namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Represents the view for a single layer after it has been added to either a MapView or a SceneView.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class LayerView : MapComponent
{
    /// <summary>  
    ///     The layer being viewed.  
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html#layer">ArcGIS Maps SDK for JavaScript</a>  
    /// </summary>  
    [ArcGISProperty]  
    [CodeGenerationIgnore]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  
    public Layer? Layer { get; internal set; }

    /// <summary>
    ///     The JavaScript object reference used by the LayerView.
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
    ///     Disposes the LayerView.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            CancellationTokenSource.Cancel();
        }
    }
}