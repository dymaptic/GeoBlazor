namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Represents a screenshot of the map view.
/// </summary>
/// <param name="DataUrl">
///     The data url of the screenshot, beginning with `data:image/png:base64,`. Can be used as a source for an image element.
/// </param>
/// <param name="Data">
///     The <see cref="ImageData"/> for the screenshot.
/// </param>
public record Screenshot(string DataUrl, ImageData Data);

/// <summary>
///     Represents the image data of a screenshot.
/// </summary>
/// <param name="Data">
///     The image data as a byte array. Can be used with libraries such as ImageSharp or SkiaSharp to render or manipulate the image.
/// </param>
/// <param name="ColorSpace">
///     The color space of the image.
/// </param>
/// <param name="Height">
///     The height of the image.
/// </param>
/// <param name="Width">
///     The width of the image.
/// </param>
public record ImageData(byte[] Data, string ColorSpace, long Height, long Width);

/// <summary>
///     Internal representation of a screenshot, for passing from JavaScript.
/// </summary>
internal record JsScreenshot(IJSStreamReference Stream, long Height, long Width, string ColorSpace);

/// <summary>
///     Options for taking a screenshot
/// </summary>
public record ScreenshotOptions
{
    /// <summary>
    ///     The format of the resulting encoded data url.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ScreenshotFormat? Format { get; init; }
    
    /// <summary>
    ///     When used, only the visible layers with Ids in this list will be included in the output.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyCollection<Guid>? LayerIds { get; init; }
    
    /// <summary>
    ///     The quality (0 to 100) of the encoded image when encoding as jpg.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Quality { get; init; }
    
    /// <summary>
    ///     The width of the screenshot (defaults to the area width). The height will be derived automatically if left unspecified, according to the aspect ratio of the of the screenshot area.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Width { get; init; }
    
    /// <summary>
    ///     The height of the screenshot (defaults to the area height). The width will be derived automatically if left unspecified, according to the aspect ratio of the screenshot area.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Height { get; init; }
    
    /// <summary>
    ///     The area of the view to take a screenshot of.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ScreenshotArea? Area { get; init; }
    
    /// <summary>
    ///     Indicates whether to ignore the background color set in the initial view properties of the web map.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IgnoreBackground { get; init; }
    
    /// <summary>
    ///     Indicates whether view padding should be ignored. Set this property to true to allow padded areas to be included in the screenshot.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IgnorePadding { get; init; }
}

/// <summary>
///     Specifies whether to take a screenshot of a specific area of the view. The area coordinates are relative to the origin of the padded view and will be clipped to the view size. Defaults to the whole view.
/// </summary>
public record ScreenshotArea
{
    /// <summary>
    ///     The x coordinate of the area.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? X { get; init; }
    
    /// <summary>
    ///     The y coordinate of the area.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Y { get; init; }
    
    /// <summary>
    ///     The width of the area.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Width { get; init; }
    
    /// <summary>
    ///     The height of the area.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Height { get; init; }
}

/// <summary>
///     The format of the resulting encoded data url.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ScreenshotFormat>))]
public enum ScreenshotFormat
{
#pragma warning disable CS1591
    Jpg,
    Png
#pragma warning restore CS1591
}