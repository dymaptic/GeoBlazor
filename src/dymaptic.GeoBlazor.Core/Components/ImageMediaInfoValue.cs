namespace dymaptic.GeoBlazor.Core.Components;

public partial class ImageMediaInfoValue : MapComponent, IMediaInfoValue
{


    /// <summary>
    ///     A string containing a URL to be launched in a browser when a user clicks the image.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LinkURL { get; set; }

    /// <summary>
    ///     A string containing the URL to the image.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SourceURL { get; set; }
    
    /// <inheritdoc />
    public MediaInfoValueSerializationRecord ToProtobuf()
    {
        return new MediaInfoValueSerializationRecord(Id.ToString(), LinkURL: LinkURL, SourceURL: SourceURL);
    }
}