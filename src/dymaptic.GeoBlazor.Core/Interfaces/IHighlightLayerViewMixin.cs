namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Interfaces.IHighlightLayerViewMixin.html">GeoBlazor Docs</a>
///     Interface for types CatalogFootprintLayerView, CSVLayerView, FeatureLayerView, GeoJSONLayerView, GraphicsLayerView, OGCFeatureLayerView, ParquetLayerView, StreamLayerView, WFSLayerView
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IHighlightLayerViewMixin>))]
[CodeGenerationIgnore]
public interface IHighlightLayerViewMixin
{
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Interfaces.IHighlightLayerViewMixin.html#ihighlightlayerviewmixinhighlightoptions-property">GeoBlazor Docs</a>
    ///     Options for configuring the highlight.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-HighlightLayerViewMixin.html#highlightOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [Obsolete("Deprecated since GeoBlazor version 4.4.0. Use the <a target=\"_blank\" href=\"module:esri/views/View#highlights\">View.highlights</a> property instead.")]
    HighlightOptions? HighlightOptions { get; set; }
    
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