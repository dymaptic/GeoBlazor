namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     An object used to create a thumbnail image that represents a feature type in the feature template.
/// </summary>
/// <param name="ContentType">
///     The MIME type of the image.
/// </param>
/// <param name="ImageData">
///     The base64EncodedImageData presenting the thumbnail image.
/// </param>
/// <param name="Height">
///     The height of the thumbnail.
/// </param>
/// <param name="Width">
///     The width of the thumbnail.
/// </param>
public record Thumbnail(string ContentType, string ImageData, double Height, double Width);