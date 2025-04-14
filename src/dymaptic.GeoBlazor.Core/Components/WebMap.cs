namespace dymaptic.GeoBlazor.Core.Components;

public partial class WebMap : Map, IPortalLayer
{
    /// <summary>
    ///     The portal item from which the WebMap is loaded.
    /// </summary>
    [RequiredProperty(nameof(Basemap))]
    [RequiredProperty] // the extra required here is for WebMap only, whereas the previous allows a check against the Map base type
    [CodeGenerationIgnore]
    public PortalItem? PortalItem { get; set; }
    
    /// <summary>
    ///    Asynchronously set the value of the PortalItem property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetPortalItem(PortalItem? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        PortalItem = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(PortalItem)] = value;
        
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
        
        await JsComponentReference.InvokeVoidAsync("setPortalItem", 
            CancellationTokenSource.Token, value);
    }

    /// <summary>
    ///     Asynchronously retrieve the current value of the PortalItem property.
    /// </summary>
    public async Task<PortalItem?> GetPortalItem()
    {
        if (CoreJsModule is null)
        {
            return PortalItem;
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
            return PortalItem;
        }

        PortalItem? result = await JsComponentReference.InvokeAsync<PortalItem?>(
            "getPortalItem", CancellationTokenSource.Token);
        
        if (result is not null)
        {
            if (PortalItem is not null)
            {
                result.Id = PortalItem.Id;
            }
            
#pragma warning disable BL0005
            PortalItem = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(PortalItem)] = PortalItem;
        }
        
        return PortalItem;
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