namespace dymaptic.GeoBlazor.Core.Model;
/// <summary>
///     Represents a screenshot of the map view.
/// </summary>
/// <param name = "DataUrl">
///     The data url of the screenshot, beginning with `data:image/png:base64,`. Can be used as a source for an image element.
/// </param>
/// <param name = "Data">
///     The <see cref = "ImageData"/> for the screenshot.
/// </param>
public record Screenshot(string DataUrl, ImageData Data);

