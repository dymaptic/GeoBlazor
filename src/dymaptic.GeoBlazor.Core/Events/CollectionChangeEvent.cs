namespace dymaptic.GeoBlazor.Pro.Events;

/// <summary>
///     Event object emitted when a Collection changes. It contains arrays of added, removed, and moved items.
/// </summary>
/// <param name="Added">
///     An array of items added to the collection.
/// </param>
/// <param name="Removed">
///     An array of items removed from the collection.
/// </param>
/// <param name="Moved">
///     An array of items moved within the collection.
/// </param>
/// <typeparam name="T">
///     The type of the items in the collection.
/// </typeparam>
public record CollectionChangeEvent<T>(T[] Added, T[] Removed, T[] Moved);