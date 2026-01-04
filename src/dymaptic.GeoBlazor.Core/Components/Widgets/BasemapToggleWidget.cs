namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class BasemapToggleWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.BasemapToggle;
    
    /// <summary>
    ///     The next <see cref="BasemapStyleName" /> for toggling.
    /// </summary>
    [Parameter]
#pragma warning disable CS0618 // Type or member is obsolete
    [RequiredProperty(nameof(NextBasemap))]
#pragma warning restore CS0618 // Type or member is obsolete
    [CodeGenerationIgnore]
    public BasemapStyleName? NextBasemapStyle { get; set; }
    
    /// <summary>
    ///     The next basemap for toggling.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapToggle.html#nextBasemap">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
#pragma warning disable CS0618 // Type or member is obsolete
    [RequiredProperty(nameof(NextBasemapStyle))]
#pragma warning restore CS0618 // Type or member is obsolete
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
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
    public override void ValidateRequiredChildren()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        if (NextBasemap is null && NextBasemapStyle is null)
        {
            throw new MissingRequiredOptionsChildElementException(nameof(BasemapToggleWidget), [nameof(NextBasemap), nameof(NextBasemapStyle)]);
        }
#pragma warning restore CS0618 // Type or member is obsolete
        
        base.ValidateRequiredChildren();
    }

}