namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     Default update options set for the Sketch widget. Update options set on this property will be overwritten if the update options are changed when update() method is called.
/// </summary>
/// <param name="Enabled">
///     Indicates if highlighting is enabled for update operations. Only supported in 2D. Default Value: true.
/// </param>
public record DefaultUpdateHighlightOptions(bool Enabled);