namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Result of the view.on('resize') event
/// </summary>
public record ResizeResult(double OldWidth, double OldHeight, double Width, double Height);