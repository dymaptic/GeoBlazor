namespace dymaptic.GeoBlazor.Core.Components.Layers;  

public partial class VectorTileLayer : Layer, ITileLayer
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