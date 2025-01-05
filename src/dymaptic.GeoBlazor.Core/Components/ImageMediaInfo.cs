namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///     An ImageMediaInfo is a type of media element that represents images to display within a popup.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-ImageMediaInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ImageMediaInfo : MediaInfo
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    public ImageMediaInfo()
    {
    }

    /// <summary>
    ///     Constructor for building a <see cref = "ImageMediaInfo"/> in code.
    /// </summary>
    /// <param name="title">
    ///     The title of the media element.
    /// </param>
    /// <param name="caption">
    ///     Defines a caption for the media.
    /// </param>
    /// <param name="altText">
    ///     Provides an alternate text for an image if the image cannot be displayed.
    /// </param>
    /// <param name="value">
    ///     Defines the value format of the image media element and how the images should be retrieved.
    /// </param>
    /// <param name="refreshInterval">
    ///     Refresh interval of the layer in minutes. Non-zero value indicates automatic layer refresh at the specified
    /// </param>
    public ImageMediaInfo(string? title = null, string? caption = null, string? altText = null, ImageMediaInfoValue? value = null, double? refreshInterval = null)
    {
#pragma warning disable BL0005
        Title = title;
        Caption = caption;
        AltText = altText;
        Value = value;
        RefreshInterval = refreshInterval;
#pragma warning restore BL0005
    }

    /// <inheritdoc/>
    public override string Type => "image-media";

    /// <summary>
    ///     Provides an alternate text for an image if the image cannot be displayed.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AltText { get; set; }

    /// <summary>
    ///     Defines a caption for the media.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Caption { get; set; }

    /// <summary>
    ///     The title of the media element.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     Refresh interval of the layer in minutes. Non-zero value indicates automatic layer refresh at the specified
    ///     interval. Value of 0 indicates auto refresh is not enabled. If the property does not exist, it is equivalent to
    ///     having a value of 0.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? RefreshInterval { get; set; }

    /// <summary>
    ///     Defines the value format of the image media element and how the images should be retrieved.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ImageMediaInfoValue? Value { get; set; }

    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ImageMediaInfoValue imageMediaInfoValue:
                Value = imageMediaInfoValue;
                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ImageMediaInfoValue:
                Value = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Value?.ValidateRequiredChildren();
    }

    internal override MediaInfoSerializationRecord ToSerializationRecord()
    {
        return new MediaInfoSerializationRecord("image-media")
        {
            AltText = AltText,
            Caption = Caption,
            Title = Title,
            Value = Value?.ToSerializationRecord(),
            RefreshInterval = RefreshInterval
        };
    }
}