namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Indicates options supported by the exportMap operation. Will be null if the supportsExportMap is false.
/// </summary>
/// <param name="SupportsArcadeExpressionForLabeling">
///     Indicates if sublayers support Arcade expressions for labeling. Only applies to MapImageLayer.
/// </param>
/// <param name="SupportsDynamicLayers">
///     Indicates if sublayers rendering can be modified or added using dynamic layers.
/// </param>
/// <param name="SupportsSublayersChanges">
///     Indicates if sublayers can be added, or removed. supportsDynamicLayers must be true as well to be able to reorder sublayers.
/// </param>
/// <param name="SupportsSublayerDefinitionExpression">
///     Indicates if sublayers definition expression can be set.
/// </param>
/// <param name="SupportsSublayerVisibility">
///     Indicates if sublayers visibility can be changed.
/// </param>
/// <param name="SupportsCIMSymbols">
///     Indicates if CIMSymbol can be used in a sublayer's renderer.
/// </param>
public record MapImageExportMap(bool SupportsArcadeExpressionForLabeling, bool SupportsDynamicLayers,
    bool SupportsSublayersChanges, bool SupportsSublayerDefinitionExpression,
    bool SupportsSublayerVisibility, bool SupportsCIMSymbols);