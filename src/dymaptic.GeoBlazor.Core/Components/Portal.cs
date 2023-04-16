using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The Portal class is part of the ArcGIS Enterprise portal that provides a way to build applications that work with
///     content from ArcGIS Online or an ArcGIS Enterprise portal.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
/// <remarks>
///     This component is not needed when using ArcGIS Online resources
/// </remarks>
public class Portal : MapComponent
{
    /// <summary>
    ///     The URL to the portal instance.
    /// </summary>
    [Parameter]
    [EditorRequired]
    [RequiredProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }
}