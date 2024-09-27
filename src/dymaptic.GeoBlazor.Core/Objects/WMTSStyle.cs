

using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
/// Contains information about the WMTS Style for WMTSSublayer. 
/// Valid WMTS styles are advertised in WMTS service metadata (GetCapabilities response)
/// </summary>
public class WMTSStyle
{
    /// <summary>
    ///     Constructor for use 
    /// </summary>
    public WMTSStyle()
    {
    }

    /// <summary>
    ///     Description for the WMTS style.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }


    /// <summary>
    ///     The unique id of WMTS style.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    ///     The URL to the legend which gets used in Legend widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }


    /// <summary>
    ///     The title of the WMTS style.
    /// </summary>
    public string? Title { get; set; }
}
