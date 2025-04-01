namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Label infos for the <see cref="SliderWidget"/>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Slider.html#LabelInfos">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Max">
///     The label for the minimum value.
/// </param>
/// <param name="Min">
///     The label for the maximum value.
/// </param>
/// <param name="Values">
///     The labels for the values.
/// </param>
public record LabelInfos(string? Max, string? Min, IReadOnlyCollection<string> Values);