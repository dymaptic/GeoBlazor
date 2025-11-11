namespace dymaptic.GeoBlazor.Core.Components.Popups;

public partial class MediaPopupContent : PopupContent
{

    
    /// <inheritdoc />
    public override PopupContentType Type => PopupContentType.Media;

    /// <summary>
    ///     Index of the current active media within the popup's media content. This will be the media that is currently viewed when displayed.
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
    ///     Contains the media elements representing images or charts to display within the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-PopupTemplate.html">PopupTemplate</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-MediaContent.html#mediaInfos">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<MediaInfo>? MediaInfos { get; set; }


    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case MediaInfo mediaInfo:
                MediaInfos ??= [];
                MediaInfos = [..MediaInfos, mediaInfo];

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
                MediaInfos = MediaInfos?.Except([mediaInfo]).ToList();

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }


    /// <inheritdoc />
    public override PopupContentSerializationRecord ToProtobuf()
    {
        return new PopupContentSerializationRecord(Id.ToString(), Type.ToString().ToKebabCase())
        {
            ActiveMediaInfoIndex = ActiveMediaInfoIndex,
            Description = Description,
            Title = Title,
            MediaInfos = MediaInfos?.Select(x => x.ToProtobuf()).ToArray()
        };
    }
}