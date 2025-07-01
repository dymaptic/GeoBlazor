namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class GeoJSONLayer : Layer, IFeatureReductionLayer, IPopupTemplateLayer
{


    /// <inheritdoc />
    public override LayerType Type => LayerType.GeoJSON;


    /// <summary>
    ///     A copyright string to identify ownership of the data.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Copyright { get; set; }

    
    /// <summary>  
    ///     Configures the method for reducing the number of point features in the view.  
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-FeatureReductionLayer.html#featureReduction">ArcGIS Maps SDK for JavaScript</a>  
    /// </summary>  
    [Parameter]  
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  
    public IFeatureReduction? FeatureReduction { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#geojsonlayerurl-property">GeoBlazor Docs</a>
    ///     The URL of the GeoJSON file.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#url">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [RequiredProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual string Url { get; set; } = null!;
    
    /// <summary>
    ///    Asynchronously set the value of the FeatureReduction property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetFeatureReduction(IFeatureReduction? value)
    {
        if (FeatureReduction is not null)
        {
            await FeatureReduction.DisposeAsync();
        }
        
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        FeatureReduction = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(FeatureReduction)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await JsComponentReference.InvokeVoidAsync("setFeatureReduction", 
            CancellationTokenSource.Token, value);
    }
    
    /// <summary>
    ///     Internal use callback from JavaScript
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnQueryFeaturesStreamCallback(IJSStreamReference streamReference, Guid queryId)
    {
        try
        {
            await using Stream stream = await streamReference
                .OpenReadStreamAsync(View?.QueryResultsMaxSizeLimit ?? 1_000_000_000L);
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            ms.Seek(0, SeekOrigin.Begin);
            ProtoGraphicCollection collection = Serializer.Deserialize<ProtoGraphicCollection>(ms);
            Graphic[] graphics = collection?.Graphics.Select(g => g.FromSerializationRecord()).ToArray()!;

            ActiveQueries[queryId] = graphics;
        }
        catch (Exception ex)
        {
            throw new SerializationException("Error deserializing graphics from stream.", ex);   
        }
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case IFeatureReduction reduction:
                if (!reduction.Equals(FeatureReduction))
                {
                    FeatureReduction = reduction;
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
            case IFeatureReduction _:
                FeatureReduction = null;
                

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
        FeatureReduction?.ValidateRequiredChildren();
    }

    public Dictionary<Guid, Graphic[]> ActiveQueries = new();
}