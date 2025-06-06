// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CapabilitiesQueryRelated.html">GeoBlazor Docs</a>
///     Indicates if the layer's query operation supports querying features or records related to features in the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#Capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class CapabilitiesQueryRelated : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public CapabilitiesQueryRelated()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="supportsCacheHint">
    ///     Indicates if the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-RelationshipQuery.html">relationship query operation</a> supports a cache hint.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#Capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="supportsCount">
    ///     Indicates if the layer's query response includes the number of features or records related to features in the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#Capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="supportsOrderBy">
    ///     Indicates if the related features or records returned in the query response can be ordered by one or more fields.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#Capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="supportsPagination">
    ///     Indicates if the query response supports pagination for related features or records.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#Capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public CapabilitiesQueryRelated(
        bool? supportsCacheHint = null,
        bool? supportsCount = null,
        bool? supportsOrderBy = null,
        bool? supportsPagination = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        SupportsCacheHint = supportsCacheHint;
        SupportsCount = supportsCount;
        SupportsOrderBy = supportsOrderBy;
        SupportsPagination = supportsPagination;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CapabilitiesQueryRelated.html#capabilitiesqueryrelatedsupportscachehint-property">GeoBlazor Docs</a>
    ///     Indicates if the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-RelationshipQuery.html">relationship query operation</a> supports a cache hint.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#Capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsCacheHint { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CapabilitiesQueryRelated.html#capabilitiesqueryrelatedsupportscount-property">GeoBlazor Docs</a>
    ///     Indicates if the layer's query response includes the number of features or records related to features in the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#Capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsCount { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CapabilitiesQueryRelated.html#capabilitiesqueryrelatedsupportsorderby-property">GeoBlazor Docs</a>
    ///     Indicates if the related features or records returned in the query response can be ordered by one or more fields.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#Capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsOrderBy { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CapabilitiesQueryRelated.html#capabilitiesqueryrelatedsupportspagination-property">GeoBlazor Docs</a>
    ///     Indicates if the query response supports pagination for related features or records.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#Capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsPagination { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the SupportsCacheHint property.
    /// </summary>
    public async Task<bool?> GetSupportsCacheHint()
    {
        if (CoreJsModule is null)
        {
            return SupportsCacheHint;
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
            return SupportsCacheHint;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "supportsCacheHint");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             SupportsCacheHint = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SupportsCacheHint)] = SupportsCacheHint;
        }
         
        return SupportsCacheHint;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SupportsCount property.
    /// </summary>
    public async Task<bool?> GetSupportsCount()
    {
        if (CoreJsModule is null)
        {
            return SupportsCount;
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
            return SupportsCount;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "supportsCount");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             SupportsCount = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SupportsCount)] = SupportsCount;
        }
         
        return SupportsCount;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SupportsOrderBy property.
    /// </summary>
    public async Task<bool?> GetSupportsOrderBy()
    {
        if (CoreJsModule is null)
        {
            return SupportsOrderBy;
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
            return SupportsOrderBy;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "supportsOrderBy");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             SupportsOrderBy = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SupportsOrderBy)] = SupportsOrderBy;
        }
         
        return SupportsOrderBy;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SupportsPagination property.
    /// </summary>
    public async Task<bool?> GetSupportsPagination()
    {
        if (CoreJsModule is null)
        {
            return SupportsPagination;
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
            return SupportsPagination;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "supportsPagination");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             SupportsPagination = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SupportsPagination)] = SupportsPagination;
        }
         
        return SupportsPagination;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the SupportsCacheHint property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSupportsCacheHint(bool? value)
    {
#pragma warning disable BL0005
        SupportsCacheHint = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SupportsCacheHint)] = value;
        
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
            JsComponentReference, "supportsCacheHint", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SupportsCount property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSupportsCount(bool? value)
    {
#pragma warning disable BL0005
        SupportsCount = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SupportsCount)] = value;
        
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
            JsComponentReference, "supportsCount", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SupportsOrderBy property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSupportsOrderBy(bool? value)
    {
#pragma warning disable BL0005
        SupportsOrderBy = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SupportsOrderBy)] = value;
        
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
            JsComponentReference, "supportsOrderBy", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SupportsPagination property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSupportsPagination(bool? value)
    {
#pragma warning disable BL0005
        SupportsPagination = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SupportsPagination)] = value;
        
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
            JsComponentReference, "supportsPagination", value);
    }
    
#endregion

}
