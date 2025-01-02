namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     A MediaContent popup element contains an individual or array of chart and/or image media elements to display within
///     a popup's content.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-MediaContent.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class MediaPopupContent : PopupContent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public MediaPopupContent()
    {
    }

    /// <summary>
    ///     Constructor for creating content in C# code.
    /// </summary>
    /// <param name="title">
    ///     Heading indicating what the media's content represents.
    /// </param>
    /// <param name="description">
    ///     Describes the media's content in detail.
    /// </param>
    /// <param name="mediaInfos">
    ///     Contains the media elements representing images or charts to display within the PopupTemplate. This can be an
    /// </param>
    /// <param name="activeMediaInfoIndex">
    ///     Index of the current active media within the popup's media content. This will be the media that is currently viewed
    /// </param>
    public MediaPopupContent(string? title = null, string? description = null, 
        IReadOnlyList<MediaInfo>? mediaInfos = null, int? activeMediaInfoIndex = null)
    {
#pragma warning disable BL0005
        Title = title;
        Description = description;
        ActiveMediaInfoIndex = activeMediaInfoIndex;
#pragma warning restore BL0005

        if (mediaInfos is not null)
        {
            MediaInfos = new List<MediaInfo>(mediaInfos);
        }
        
    }
    
    /// <inheritdoc />
    public override PopupContentType Type => PopupContentType.Media;

    /// <summary>
    ///     Index of the current active media within the popup's media content. This will be the media that is currently viewed
    ///     when displayed.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ActiveMediaInfoIndex { get; set; }

    /// <summary>
    ///     Describes the media's content in detail.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <summary>
    ///     Heading indicating what the media's content represents.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     Contains the media elements representing images or charts to display within the PopupTemplate. This can be an
    ///     individual chart or image element, or an array containing a combination of any of these types.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IList<MediaInfo>? MediaInfos { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case MediaInfo mediaInfo:
                MediaInfos ??= new List<MediaInfo>();
                MediaInfos.Add(mediaInfo);

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case MediaInfo mediaInfo:
                MediaInfos?.Remove(mediaInfo);

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();

        if (MediaInfos is not null)
        {
            foreach (MediaInfo mediaInfo in MediaInfos)
            {
                mediaInfo.ValidateRequiredChildren();
            }
        }
    }

    internal override PopupContentSerializationRecord ToSerializationRecord()
    {
        return new PopupContentSerializationRecord(Type.ToString().ToKebabCase())
        {
            ActiveMediaInfoIndex = ActiveMediaInfoIndex,
            Description = Description,
            Title = Title,
            MediaInfos = MediaInfos?.Select(x => x.ToSerializationRecord()).ToArray()
        };
    }
}