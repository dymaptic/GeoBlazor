using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The BasemapToggle provides a widget which allows an end-user to switch between two basemaps. The toggled basemap is set inside the view's map object.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapToggle.html">ArcGIS JS API</a>
/// </summary>
public class BasemapToggleWidget : Widget
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string WidgetType => "basemapToggle";
    
    /// <summary>
    ///     The name of the next basemap for toggling.
    /// </summary>
    /// <remarks>
    ///     Set either <see cref="NextBasemapName"/> or <see cref="NextBasemap"/>
    /// </remarks>
    [Parameter]
    [RequiredProperty(nameof(NextBasemap))]
    public string? NextBasemapName { get; set; }
    
    /// <summary>
    ///     The next <see cref="Basemap"/> for toggling.
    /// </summary>
    /// <remarks>
    ///     Set either <see cref="NextBasemapName"/> or <see cref="NextBasemap"/>
    /// </remarks>
    [RequiredProperty(nameof(NextBasemapName))]
    public Basemap? NextBasemap { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Basemap basemap:
                NextBasemap = basemap;
                await UpdateComponent();

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
            case Basemap _:
                NextBasemap = null;

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
        NextBasemap?.ValidateRequiredChildren();
    }
}