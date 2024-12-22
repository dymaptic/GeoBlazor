using dymaptic.GeoBlazor.Core.Attributes;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The BasemapToggle provides a widget which allows an end-user to switch between two basemaps. The toggled basemap is
///     set inside the view's map object.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapToggle.html">ArcGIS Maps SDK for JavaScript</a>
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
    ///     Set either <see cref="NextBasemapName" /> or <see cref="NextBasemap" />
    /// </remarks>
    [Parameter]
    [Obsolete("Use NextBasemapStyle instead")]
    [RequiredProperty(nameof(NextBasemap), nameof(NextBasemapStyle))]
    public string? NextBasemapName { get; set; }
    
    /// <summary>
    ///     The next <see cref="BasemapStyleName" /> for toggling.
    /// </summary>
    [Parameter]
#pragma warning disable CS0618 // Type or member is obsolete
    [RequiredProperty(nameof(NextBasemapName), nameof(NextBasemap))]
#pragma warning restore CS0618 // Type or member is obsolete
    public BasemapStyleName? NextBasemapStyle { get; set; }

    /// <summary>
    ///     The next <see cref="Basemap" /> for toggling.
    /// </summary>
    /// <remarks>
    ///     Set either <see cref="NextBasemapName" /> or <see cref="NextBasemap" />
    /// </remarks>
#pragma warning disable CS0618 // Type or member is obsolete
    [RequiredProperty(nameof(NextBasemapName), nameof(NextBasemapStyle))]
#pragma warning restore CS0618 // Type or member is obsolete
    public Basemap? NextBasemap { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Basemap basemap:
                NextBasemap = basemap;

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
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        NextBasemap?.ValidateRequiredChildren();
    }
}