// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.SearchLayer.html">GeoBlazor Docs</a>
///     Represents a layer to be included in search.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webdoc-applicationProperties-SearchLayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class SearchLayer : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SearchLayer()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="field">
    ///     The field to use for search.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webdoc-applicationProperties-SearchLayer.html#field">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="searchLayerId">
    ///     The id of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webdoc-applicationProperties-SearchLayer.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="subLayer">
    ///     The sub layer index.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webdoc-applicationProperties-SearchLayer.html#subLayer">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public SearchLayer(
        SearchLayerField? field = null,
        string? searchLayerId = null,
        double? subLayer = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Field = field;
        SearchLayerId = searchLayerId;
        SubLayer = subLayer;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     The field to use for search.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webdoc-applicationProperties-SearchLayer.html#field">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SearchLayerField? Field { get; set; }
    
    /// <summary>
    ///     The id of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webdoc-applicationProperties-SearchLayer.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SearchLayerId { get; set; }
    
    /// <summary>
    ///     The sub layer index.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webdoc-applicationProperties-SearchLayer.html#subLayer">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SubLayer { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Field property.
    /// </summary>
    public async Task<SearchLayerField?> GetField()
    {
        if (CoreJsModule is null)
        {
            return Field;
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
            return Field;
        }

        SearchLayerField? result = await JsComponentReference.InvokeAsync<SearchLayerField?>(
            "getField", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            Field = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Field)] = Field;
        }
        
        return Field;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SearchLayerId property.
    /// </summary>
    public async Task<string?> GetSearchLayerId()
    {
        if (CoreJsModule is null)
        {
            return SearchLayerId;
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
            return SearchLayerId;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "id");
        if (result is not null)
        {
#pragma warning disable BL0005
             SearchLayerId = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SearchLayerId)] = SearchLayerId;
        }
         
        return SearchLayerId;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SubLayer property.
    /// </summary>
    public async Task<double?> GetSubLayer()
    {
        if (CoreJsModule is null)
        {
            return SubLayer;
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
            return SubLayer;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "subLayer");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             SubLayer = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SubLayer)] = SubLayer;
        }
         
        return SubLayer;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Field property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetField(SearchLayerField? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        Field = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Field)] = value;
        
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
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "field", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SearchLayerId property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSearchLayerId(string? value)
    {
#pragma warning disable BL0005
        SearchLayerId = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SearchLayerId)] = value;
        
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
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "id", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SubLayer property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSubLayer(double? value)
    {
#pragma warning disable BL0005
        SubLayer = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SubLayer)] = value;
        
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
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "subLayer", value);
    }
    
#endregion


    /// <inheritdoc />
    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SearchLayerField field:
                if (field != Field)
                {
                    Field = field;
                    ModifiedParameters[nameof(Field)] = Field;
                }
                
                return true;
            default:
                return await base.RegisterGeneratedChildComponent(child);
        }
    }

    /// <inheritdoc />
    protected override async ValueTask<bool> UnregisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SearchLayerField _:
                Field = null;
                ModifiedParameters[nameof(Field)] = Field;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    public override void ValidateRequiredGeneratedChildren()
    {
    
        Field?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
