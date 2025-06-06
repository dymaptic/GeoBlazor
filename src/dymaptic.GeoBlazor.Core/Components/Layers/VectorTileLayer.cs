namespace dymaptic.GeoBlazor.Core.Components.Layers;  

public partial class VectorTileLayer : Layer  
{  
    /// <summary>  
    ///     The URL to the vector tile service.  
    /// </summary>  
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }

  
    /// <summary>  
    ///     The maximum scale of the layer.  
    /// </summary>  
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxScale { get; set; }  
  
    /// <summary>  
    ///     The minimum scale of the layer.  
    /// </summary>  
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinScale { get; set; }  

  
    /// <summary>  
    ///     The spatial reference of the layer.  
    /// </summary>  
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public SpatialReference? SpatialReference { get; set; }  
  
    /// <summary>  
    ///     The portal item of the layer.  
    /// </summary>  
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PortalItem? PortalItem { get; set; }

    /// <inheritdoc />
    [ArcGISProperty]
    public override LayerType Type => LayerType.VectorTile;  
  
    /// <inheritdoc />
    internal override async Task UpdateFromJavaScript(Layer renderedLayer)  
    {        await base.UpdateFromJavaScript(renderedLayer);  
        VectorTileLayer renderedTileLayer = (VectorTileLayer)renderedLayer;  
        Url ??= renderedTileLayer.Url;  
        Title ??= renderedTileLayer.Title;  
        Effect ??= renderedTileLayer.Effect;  
        ListMode ??= renderedTileLayer.ListMode;  
        MaxScale ??= renderedTileLayer.MaxScale;  
        MinScale ??= renderedTileLayer.MinScale;  
        Opacity ??= renderedTileLayer.Opacity;  
        PersistenceEnabled ??= renderedTileLayer.PersistenceEnabled;  
        Capabilities ??= renderedTileLayer.Capabilities;  
        SpatialReference ??= renderedTileLayer.SpatialReference;  
        MinScale ??= renderedTileLayer.MinScale;  
        MaxScale ??= renderedTileLayer.MaxScale;  
        PortalItem ??= renderedTileLayer.PortalItem;  
    }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalItem portalItem:
                if (!portalItem.Equals(PortalItem))
                {
                    PortalItem = portalItem;
                    if (MapRendered)
                    {
                        await UpdateLayer();
                    }
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
            case PortalItem _:
                PortalItem = null;
                

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
        PortalItem?.ValidateRequiredChildren();
    }
}