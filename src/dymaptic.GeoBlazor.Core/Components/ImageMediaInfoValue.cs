namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///     The ImageMediaInfoValue class contains information for popups regarding how images should be retrieved.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ImageMediaInfoValue.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ImageMediaInfoValue : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    public ImageMediaInfoValue()
    {
    }

    /// <summary>
    ///     Constructor for building a <see cref = "ImageMediaInfoValue"/> in code.
    /// </summary>
    /// <param name = "linkURL">
    ///     A string containing a URL to be launched in a browser when a user clicks the image.
    /// </param>
    /// <param name = "sourceURL">
    ///     A string containing the URL to the image.
    /// </param>
    public ImageMediaInfoValue(string? linkURL = null, string? sourceURL = null)
    {
#pragma warning disable BL0005
        LinkURL = linkURL;
        SourceURL = sourceURL;
#pragma warning restore BL0005
    }

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