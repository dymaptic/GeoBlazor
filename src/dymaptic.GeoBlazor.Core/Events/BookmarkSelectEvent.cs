using dymaptic.GeoBlazor.Core.Components.Widgets;

namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
/// Event object for a a bookmark select event from the BookmarksWidget.
/// </summary>
/// <param name="Bookmark">The Bookmark that was selected</param>
public record BookmarkSelectEvent(Bookmark Bookmark);

