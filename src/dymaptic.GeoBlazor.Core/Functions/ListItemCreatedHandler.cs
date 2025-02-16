namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>
/// <param name="listItemCreatedEvent">
///     The event that is triggered when a list item is created.    
/// </param>
public delegate Task ListItemCreatedHandler(ListItemCreatedEvent listItemCreatedEvent);

public record ListItemCreatedEvent(ListItem Item);