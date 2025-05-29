namespace dymaptic.GeoBlazor.Core.Interfaces;

[JsonConverter(typeof(MultiTypeConverter<IHighlightLayerViewMixin>))]
public partial interface IHighlightLayerViewMixin
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
    Task<Handle> Highlight(ObjectId objectId);
    
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
    [CodeGenerationIgnore]
    Task<Handle> Highlight(IReadOnlyCollection<ObjectId> objectIds);
    
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
    Task<Handle> Highlight(Graphic graphic);
    
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
    Task<Handle> Highlight(IReadOnlyCollection<Graphic> graphics);
}