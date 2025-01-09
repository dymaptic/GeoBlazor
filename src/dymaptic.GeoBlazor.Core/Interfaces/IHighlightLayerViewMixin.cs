namespace dymaptic.GeoBlazor.Core.Interfaces;

public interface IHighlightLayerViewMixin
{
    /// <summary>
    ///     Highlights the given feature(s).
    /// </summary>
    /// <param name="objectId">
    ///     The ObjectID of the graphic to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    [CodeGenerationIgnore]
Task<HighlightHandle> Highlight(long objectId);
    
    /// <summary>
    ///     Highlights the given feature(s).
    /// </summary>
    /// <param name="objectId">
    ///     The ObjectID as string of the graphic to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    Task<HighlightHandle> Highlight(string objectId);
    
    /// <summary>
    ///     Highlights the given feature(s).
    /// </summary>
    /// <param name="objectIds">
    ///     The ObjectIDs of the graphics to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Throws if no ObjectIDs are provided.
    /// </exception>
    Task<HighlightHandle> Highlight(IReadOnlyCollection<long> objectIds);
    
    /// <summary>
    ///     Highlights the given feature(s).
    /// </summary>
    /// <param name="objectIds">
    ///     The ObjectIDs as strings of the graphics to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Throws if no ObjectIDs are provided.
    /// </exception>
    Task<HighlightHandle> Highlight(IReadOnlyCollection<string> objectIds);
    
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
    Task<HighlightHandle> Highlight(Graphic graphic);
    
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
    Task<HighlightHandle> Highlight(IReadOnlyCollection<Graphic> graphics);
}