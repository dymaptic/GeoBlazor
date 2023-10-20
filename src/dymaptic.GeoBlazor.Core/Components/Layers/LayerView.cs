using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Represents the view for a single layer after it has been added to either a MapView or a SceneView.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class LayerView : IDisposable
{
    /// <summary>
    ///     The layer being viewed.
    /// </summary>
    public Layer Layer { get; set; } = default!;

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
    ///     Value is true when the layer is updating; for example, if it is in the process of fetching data.
    /// </summary>
    public bool Visible { get; init; }

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

    /// <summary>
    ///     Creates a cancellation token to control external calls
    /// </summary>
    protected CancellationTokenSource CancellationTokenSource = new();
}

#pragma warning disable CS1574, CS0419
/// <summary>
///     A handle to a <see cref="LayerView.Highlight" /> call result. The handle can be used to remove the installed
///     highlight.
/// </summary>
/// <param name="JsObjectReference">
///     The JavaScript object reference used by the handle.
/// </param>
#pragma warning restore CS1574, CS0419
public record HighlightHandle(IJSObjectReference JsObjectReference)
{
    /// <summary>
    ///     Removes the highlight.
    /// </summary>
    public async Task Remove()
    {
        await JsObjectReference.InvokeVoidAsync("remove");
    }
}