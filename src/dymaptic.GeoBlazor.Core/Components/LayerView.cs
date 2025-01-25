namespace dymaptic.GeoBlazor.Core.Components;

public partial class LayerView : MapComponent
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