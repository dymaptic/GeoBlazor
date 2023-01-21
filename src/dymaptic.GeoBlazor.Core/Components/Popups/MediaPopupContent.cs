using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     A MediaContent popup element contains an individual or array of chart and/or image media elements to display within a popup's content.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-MediaContent.html">ArcGIS JS API</a>
/// </summary>
public class MediaPopupContent: PopupContent
{
    /// <inheritdoc />
    public override string Type => "media";
    
    /// <summary>
    ///     Index of the current active media within the popup's media content. This will be the media that is currently viewed when displayed.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ActiveMediaInfoIndex { get; set; }
    
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
    ///     Contains the media elements representing images or charts to display within the PopupTemplate. This can be an individual chart or image element, or an array containing a combination of any of these types.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HashSet<MediaInfo> MediaInfos { get; set; } = new();
}