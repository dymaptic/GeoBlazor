using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The PortalBasemapsSource class is a Portal-driven Basemap source in the BasemapGalleryViewModel or BasemapGallery widget.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapGallery-support-PortalBasemapsSource.html">ArcGIS JS API</a>
/// </summary>
public class PortalBasemapsSource: MapComponent
{
    /// <summary>
    ///     An query string used to create a custom basemap gallery group query.
    /// </summary>
    /// <remarks>
    ///     User either <see cref="QueryString"/> or <see cref="QueryParams"/>
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? QueryString { get; set; }
    
    /// <summary>
    ///     An object with key-value pairs used to create a custom basemap gallery group query.
    /// </summary>
    /// <remarks>
    ///     User either <see cref="QueryString"/> or <see cref="QueryParams"/>
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? QueryParams { get; set; }
    
    /// <summary>
    ///     The Portal from which to fetch basemaps.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Portal? Portal { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Portal portal:
                // ReSharper disable once RedundantCast
                if (!((Object)portal).Equals(Portal))
                {
                    Portal = portal;
                    await UpdateComponent();
                }

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
            case Portal _:
                Portal = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Portal?.ValidateRequiredChildren();
    }
}