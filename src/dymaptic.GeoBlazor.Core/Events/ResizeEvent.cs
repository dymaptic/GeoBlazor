namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     Result of the view.on('resize') event
/// </summary>
/// <param name="OldWidth">
///     The previous view width in pixels
/// </param>
/// <param name="OldHeight">
///     The previous view height in pixels
/// </param>
/// <param name="Width">
///     The new measured view width in pixels
/// </param>
/// <param name="Height">
///     The new measured view height in pixels
/// </param>
public record ResizeEvent(double OldWidth, double OldHeight, double Width, double Height);