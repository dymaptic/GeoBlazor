namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Describes the object representing the result of the Locator.SuggestLocations() method.
/// </summary>
/// <param name="IsCollection">
///     Indicates if the result is a Collection.
/// </param>
/// <param name="MagicKey">
///     ID used in combination with the text property to uniquely identify a suggestion.
/// </param>
/// <param name="Text">
///     The string name of the suggested location to geocode.
/// </param>
public record SuggestionResult(bool IsCollection, string MagicKey, string Text);