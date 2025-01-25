// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    Indicates options supported by the exportMap operation.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class ArcGISMapServiceCapabilitiesExportMap : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ArcGISMapServiceCapabilitiesExportMap()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="supportsArcadeExpressionForLabeling">
    ///     Indicates if sublayers support Arcade expressions for labeling.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="supportsCIMSymbols">
    ///     _Since 4.23_ Indicates if <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-CIMSymbol.html">CIMSymbol</a> can be used in a sublayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#renderer">renderer</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="supportsDynamicLayers">
    ///     Indicates if sublayers rendering can be modified or added using dynamic layers.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="supportsSublayerDefinitionExpression">
    ///     Indicates if sublayers <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#definitionExpression">definition expression</a> can be set.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="supportsSublayersChanges">
    ///     Indicates if sublayers can be added, or removed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="supportsSublayerVisibility">
    ///     Indicates if sublayers <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#visible">visibility</a> can be changed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public ArcGISMapServiceCapabilitiesExportMap(
        bool? supportsArcadeExpressionForLabeling = null,
        bool? supportsCIMSymbols = null,
        bool? supportsDynamicLayers = null,
        bool? supportsSublayerDefinitionExpression = null,
        bool? supportsSublayersChanges = null,
        bool? supportsSublayerVisibility = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        SupportsArcadeExpressionForLabeling = supportsArcadeExpressionForLabeling;
        SupportsCIMSymbols = supportsCIMSymbols;
        SupportsDynamicLayers = supportsDynamicLayers;
        SupportsSublayerDefinitionExpression = supportsSublayerDefinitionExpression;
        SupportsSublayersChanges = supportsSublayersChanges;
        SupportsSublayerVisibility = supportsSublayerVisibility;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     Indicates if sublayers support Arcade expressions for labeling.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsArcadeExpressionForLabeling { get; set; }
    
    /// <summary>
    ///     _Since 4.23_ Indicates if <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-CIMSymbol.html">CIMSymbol</a> can be used in a sublayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#renderer">renderer</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsCIMSymbols { get; set; }
    
    /// <summary>
    ///     Indicates if sublayers rendering can be modified or added using dynamic layers.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsDynamicLayers { get; set; }
    
    /// <summary>
    ///     Indicates if sublayers <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#definitionExpression">definition expression</a> can be set.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsSublayerDefinitionExpression { get; set; }
    
    /// <summary>
    ///     Indicates if sublayers can be added, or removed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsSublayersChanges { get; set; }
    
    /// <summary>
    ///     Indicates if sublayers <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#visible">visibility</a> can be changed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsSublayerVisibility { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the SupportsArcadeExpressionForLabeling property.
    /// </summary>
    public async Task<bool?> GetSupportsArcadeExpressionForLabeling()
    {
        if (CoreJsModule is null)
        {
            return SupportsArcadeExpressionForLabeling;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SupportsArcadeExpressionForLabeling;
        }

        // get the property value
#pragma warning disable BL0005
        SupportsArcadeExpressionForLabeling = await CoreJsModule!.InvokeAsync<bool>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "supportsArcadeExpressionForLabeling");
#pragma warning restore BL0005
         ModifiedParameters[nameof(SupportsArcadeExpressionForLabeling)] = SupportsArcadeExpressionForLabeling;
        return SupportsArcadeExpressionForLabeling;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SupportsCIMSymbols property.
    /// </summary>
    public async Task<bool?> GetSupportsCIMSymbols()
    {
        if (CoreJsModule is null)
        {
            return SupportsCIMSymbols;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SupportsCIMSymbols;
        }

        // get the property value
#pragma warning disable BL0005
        SupportsCIMSymbols = await CoreJsModule!.InvokeAsync<bool>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "supportsCIMSymbols");
#pragma warning restore BL0005
         ModifiedParameters[nameof(SupportsCIMSymbols)] = SupportsCIMSymbols;
        return SupportsCIMSymbols;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SupportsDynamicLayers property.
    /// </summary>
    public async Task<bool?> GetSupportsDynamicLayers()
    {
        if (CoreJsModule is null)
        {
            return SupportsDynamicLayers;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SupportsDynamicLayers;
        }

        // get the property value
#pragma warning disable BL0005
        SupportsDynamicLayers = await CoreJsModule!.InvokeAsync<bool>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "supportsDynamicLayers");
#pragma warning restore BL0005
         ModifiedParameters[nameof(SupportsDynamicLayers)] = SupportsDynamicLayers;
        return SupportsDynamicLayers;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SupportsSublayerDefinitionExpression property.
    /// </summary>
    public async Task<bool?> GetSupportsSublayerDefinitionExpression()
    {
        if (CoreJsModule is null)
        {
            return SupportsSublayerDefinitionExpression;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SupportsSublayerDefinitionExpression;
        }

        // get the property value
#pragma warning disable BL0005
        SupportsSublayerDefinitionExpression = await CoreJsModule!.InvokeAsync<bool>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "supportsSublayerDefinitionExpression");
#pragma warning restore BL0005
         ModifiedParameters[nameof(SupportsSublayerDefinitionExpression)] = SupportsSublayerDefinitionExpression;
        return SupportsSublayerDefinitionExpression;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SupportsSublayersChanges property.
    /// </summary>
    public async Task<bool?> GetSupportsSublayersChanges()
    {
        if (CoreJsModule is null)
        {
            return SupportsSublayersChanges;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SupportsSublayersChanges;
        }

        // get the property value
#pragma warning disable BL0005
        SupportsSublayersChanges = await CoreJsModule!.InvokeAsync<bool>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "supportsSublayersChanges");
#pragma warning restore BL0005
         ModifiedParameters[nameof(SupportsSublayersChanges)] = SupportsSublayersChanges;
        return SupportsSublayersChanges;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SupportsSublayerVisibility property.
    /// </summary>
    public async Task<bool?> GetSupportsSublayerVisibility()
    {
        if (CoreJsModule is null)
        {
            return SupportsSublayerVisibility;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SupportsSublayerVisibility;
        }

        // get the property value
#pragma warning disable BL0005
        SupportsSublayerVisibility = await CoreJsModule!.InvokeAsync<bool>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "supportsSublayerVisibility");
#pragma warning restore BL0005
         ModifiedParameters[nameof(SupportsSublayerVisibility)] = SupportsSublayerVisibility;
        return SupportsSublayerVisibility;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the SupportsArcadeExpressionForLabeling property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSupportsArcadeExpressionForLabeling(bool value)
    {
#pragma warning disable BL0005
        SupportsArcadeExpressionForLabeling = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SupportsArcadeExpressionForLabeling)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "supportsArcadeExpressionForLabeling", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SupportsCIMSymbols property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSupportsCIMSymbols(bool value)
    {
#pragma warning disable BL0005
        SupportsCIMSymbols = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SupportsCIMSymbols)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "supportsCIMSymbols", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SupportsDynamicLayers property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSupportsDynamicLayers(bool value)
    {
#pragma warning disable BL0005
        SupportsDynamicLayers = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SupportsDynamicLayers)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "supportsDynamicLayers", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SupportsSublayerDefinitionExpression property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSupportsSublayerDefinitionExpression(bool value)
    {
#pragma warning disable BL0005
        SupportsSublayerDefinitionExpression = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SupportsSublayerDefinitionExpression)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "supportsSublayerDefinitionExpression", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SupportsSublayersChanges property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSupportsSublayersChanges(bool value)
    {
#pragma warning disable BL0005
        SupportsSublayersChanges = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SupportsSublayersChanges)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "supportsSublayersChanges", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SupportsSublayerVisibility property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSupportsSublayerVisibility(bool value)
    {
#pragma warning disable BL0005
        SupportsSublayerVisibility = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SupportsSublayerVisibility)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "supportsSublayerVisibility", value);
    }
    
#endregion




}
