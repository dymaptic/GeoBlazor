namespace dymaptic.GeoBlazor.Core.Components;

public partial class ImageMediaInfoValue : MapComponent
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

    internal ChartMediaInfoValueSerializationRecord ToSerializationRecord()
    {
        return new ChartMediaInfoValueSerializationRecord(LinkURL: LinkURL, SourceURL: SourceURL);
    }
}