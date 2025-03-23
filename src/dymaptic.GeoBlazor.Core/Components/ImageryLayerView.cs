namespace dymaptic.GeoBlazor.Core.Components;

public partial class ImageryLayerView
{
    // Add custom code to this file to override generated code
    
    /// <inheritdoc />
    public override LayerType? Type => LayerType.Imagery;
   
    /// <summary>
    ///     Highlights the given feature(s).
    /// </summary>
    /// <param name="graphic">
    ///     The <see cref="Graphic" /> to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Throws if the graphic has no OBJECTID attribute and was not queried via GeoBlazor.
    /// </exception>
    [CodeGenerationIgnore]
    public async Task<HighlightHandle> Highlight(Graphic graphic)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference>("getJsComponent");
        IJSObjectReference? objectRef;
        if (graphic.Attributes.TryGetValue("OBJECTID", out object? objectId))
        {
            objectRef = await JsComponentReference.InvokeAsync<IJSObjectReference>("highlight",
                    CancellationTokenSource.Token, objectId);
        }
        else
        {
            objectRef = await JsComponentReference.InvokeAsync<IJSObjectReference?>("highlightByGeoBlazorId",
                CancellationTokenSource.Token, graphic.Id);
            
            if (objectRef is null)
            {
                throw new InvalidOperationException("The graphic does not have an OBJECTID attribute and was not registered with GeoBlazor.");
            }
        }
        
        return new HighlightHandle(objectRef);
    }

    /// <summary>
    ///     Highlights the given feature(s).
    /// </summary>
    /// <param name="graphics">
    ///     The graphics to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Throws if the graphics have no OBJECTID attribute and were not queried via GeoBlazor.
    /// </exception>
    [CodeGenerationIgnore]
    public async Task<HighlightHandle> Highlight(IReadOnlyCollection<Graphic> graphics)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference>("getJsComponent");
        IJSObjectReference? objectRef;

        if (graphics.Count == 0)
        {
            throw new ArgumentException("At least one graphic must be provided.", nameof(graphics));
        }
        if (graphics.First().Attributes.TryGetValue("OBJECTID", out _))
        {
            objectRef = await JsComponentReference.InvokeAsync<IJSObjectReference>("highlight",
                CancellationTokenSource.Token, graphics.Select(g => g.Attributes["OBJECTID"]).ToArray());
        }
        else
        {
            objectRef = await JsComponentReference.InvokeAsync<IJSObjectReference?>("highlightByGeoBlazorIds",
                CancellationTokenSource.Token, graphics.Select(g => g.Id).ToArray());
            
            if (objectRef is null)
            {
                throw new InvalidOperationException("The graphics do not have the OBJECTID attribute and were not registered with GeoBlazor.");
            }
        }

        return new HighlightHandle(objectRef);
    }
}