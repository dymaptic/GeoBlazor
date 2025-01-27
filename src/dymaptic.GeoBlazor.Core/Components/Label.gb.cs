// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    Defines label expressions, symbols, scale ranges, label priorities, and label placement options for labels on a layer.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class Label
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public Label()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="labelPlacement">
    ///     The position of the label.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#labelPlacement">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="labelExpression">
    ///     Defines the labels for a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-MapImageLayer.html">MapImageLayer</a>.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#labelExpression">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="labelExpressionInfo">
    ///     Defines the labels for a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">FeatureLayer</a>.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#labelExpressionInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="allowOverrun">
    ///     Specifies whether or not a polyline label can overrun the feature being labeled.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#allowOverrun">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="deconflictionStrategy">
    ///     Defines how labels should be placed relative to one another.
    ///     default static
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#deconflictionStrategy">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="labelPosition">
    ///     Specifies the orientation of the label position of a polyline label.
    ///     default "curved"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#labelPosition">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which labels are visible in the view.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#maxScale">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which labels are visible in the view.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#minScale">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="repeatLabel">
    ///     Indicates whether or not to repeat the label along the polyline feature.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#repeatLabel">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="repeatLabelDistance">
    ///     The size in points of the distance between labels on a polyline.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#repeatLabelDistance">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="symbol">
    ///     Defines the symbol used for rendering the label.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#symbol">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="useCodedValues">
    ///     Indicates whether to use domain names if the fields in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#labelExpression">labelExpression</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#labelExpressionInfo">labelExpressionInfo</a> have domains.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#useCodedValues">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="where">
    ///     A SQL where clause used to determine the features to which the label class should be applied.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#where">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public Label(
        LabelPlacement? labelPlacement = null,
        string? labelExpression = null,
        LabelExpressionInfo? labelExpressionInfo = null,
        bool? allowOverrun = null,
        DeconflictionStrategy? deconflictionStrategy = null,
        LabelPosition? labelPosition = null,
        double? maxScale = null,
        double? minScale = null,
        bool? repeatLabel = null,
        Dimension? repeatLabelDistance = null,
        Symbol? symbol = null,
        bool? useCodedValues = null,
        string? where = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        LabelPlacement = labelPlacement;
        LabelExpression = labelExpression;
        LabelExpressionInfo = labelExpressionInfo;
        AllowOverrun = allowOverrun;
        DeconflictionStrategy = deconflictionStrategy;
        LabelPosition = labelPosition;
        MaxScale = maxScale;
        MinScale = minScale;
        RepeatLabel = repeatLabel;
        RepeatLabelDistance = repeatLabelDistance;
        Symbol = symbol;
        UseCodedValues = useCodedValues;
        Where = where;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     Specifies whether or not a polyline label can overrun the feature being labeled.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#allowOverrun">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AllowOverrun { get; set; }
    
    /// <summary>
    ///     Defines the labels for a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">FeatureLayer</a>.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#labelExpressionInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LabelExpressionInfo? LabelExpressionInfo { get; set; }
    
    /// <summary>
    ///     Defines the symbol used for rendering the label.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#symbol">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Symbol? Symbol { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the AllowOverrun property.
    /// </summary>
    public async Task<bool?> GetAllowOverrun()
    {
        if (CoreJsModule is null)
        {
            return AllowOverrun;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return AllowOverrun;
        }

        // get the property value
        bool? result = await CoreJsModule!.InvokeAsync<bool?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "allowOverrun");
        if (result is not null)
        {
#pragma warning disable BL0005
             AllowOverrun = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(AllowOverrun)] = AllowOverrun;
        }
         
        return AllowOverrun;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the DeconflictionStrategy property.
    /// </summary>
    public async Task<DeconflictionStrategy?> GetDeconflictionStrategy()
    {
        if (CoreJsModule is null)
        {
            return DeconflictionStrategy;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return DeconflictionStrategy;
        }

        // get the property value
        DeconflictionStrategy? result = await CoreJsModule!.InvokeAsync<DeconflictionStrategy?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "deconflictionStrategy");
        if (result is not null)
        {
#pragma warning disable BL0005
             DeconflictionStrategy = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(DeconflictionStrategy)] = DeconflictionStrategy;
        }
         
        return DeconflictionStrategy;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the LabelExpression property.
    /// </summary>
    public async Task<string?> GetLabelExpression()
    {
        if (CoreJsModule is null)
        {
            return LabelExpression;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return LabelExpression;
        }

        // get the property value
        string? result = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "labelExpression");
        if (result is not null)
        {
#pragma warning disable BL0005
             LabelExpression = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(LabelExpression)] = LabelExpression;
        }
         
        return LabelExpression;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the LabelExpressionInfo property.
    /// </summary>
    public async Task<LabelExpressionInfo?> GetLabelExpressionInfo()
    {
        if (CoreJsModule is null)
        {
            return LabelExpressionInfo;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return LabelExpressionInfo;
        }

        // get the property value
        LabelExpressionInfo? result = await CoreJsModule!.InvokeAsync<LabelExpressionInfo?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "labelExpressionInfo");
        if (result is not null)
        {
#pragma warning disable BL0005
             LabelExpressionInfo = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(LabelExpressionInfo)] = LabelExpressionInfo;
        }
         
        return LabelExpressionInfo;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the LabelPlacement property.
    /// </summary>
    public async Task<LabelPlacement?> GetLabelPlacement()
    {
        if (CoreJsModule is null)
        {
            return LabelPlacement;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return LabelPlacement;
        }

        // get the property value
        LabelPlacement? result = await CoreJsModule!.InvokeAsync<LabelPlacement?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "labelPlacement");
        if (result is not null)
        {
#pragma warning disable BL0005
             LabelPlacement = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(LabelPlacement)] = LabelPlacement;
        }
         
        return LabelPlacement;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the LabelPosition property.
    /// </summary>
    public async Task<LabelPosition?> GetLabelPosition()
    {
        if (CoreJsModule is null)
        {
            return LabelPosition;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return LabelPosition;
        }

        // get the property value
        LabelPosition? result = await CoreJsModule!.InvokeAsync<LabelPosition?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "labelPosition");
        if (result is not null)
        {
#pragma warning disable BL0005
             LabelPosition = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(LabelPosition)] = LabelPosition;
        }
         
        return LabelPosition;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the MaxScale property.
    /// </summary>
    public async Task<double?> GetMaxScale()
    {
        if (CoreJsModule is null)
        {
            return MaxScale;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return MaxScale;
        }

        // get the property value
        double? result = await CoreJsModule!.InvokeAsync<double?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "maxScale");
        if (result is not null)
        {
#pragma warning disable BL0005
             MaxScale = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(MaxScale)] = MaxScale;
        }
         
        return MaxScale;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the MinScale property.
    /// </summary>
    public async Task<double?> GetMinScale()
    {
        if (CoreJsModule is null)
        {
            return MinScale;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return MinScale;
        }

        // get the property value
        double? result = await CoreJsModule!.InvokeAsync<double?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "minScale");
        if (result is not null)
        {
#pragma warning disable BL0005
             MinScale = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(MinScale)] = MinScale;
        }
         
        return MinScale;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the RepeatLabel property.
    /// </summary>
    public async Task<bool?> GetRepeatLabel()
    {
        if (CoreJsModule is null)
        {
            return RepeatLabel;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return RepeatLabel;
        }

        // get the property value
        bool? result = await CoreJsModule!.InvokeAsync<bool?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "repeatLabel");
        if (result is not null)
        {
#pragma warning disable BL0005
             RepeatLabel = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(RepeatLabel)] = RepeatLabel;
        }
         
        return RepeatLabel;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the RepeatLabelDistance property.
    /// </summary>
    public async Task<Dimension?> GetRepeatLabelDistance()
    {
        if (CoreJsModule is null)
        {
            return RepeatLabelDistance;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return RepeatLabelDistance;
        }

        // get the property value
        Dimension? result = await CoreJsModule!.InvokeAsync<Dimension?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "repeatLabelDistance");
        if (result is not null)
        {
#pragma warning disable BL0005
             RepeatLabelDistance = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(RepeatLabelDistance)] = RepeatLabelDistance;
        }
         
        return RepeatLabelDistance;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the UseCodedValues property.
    /// </summary>
    public async Task<bool?> GetUseCodedValues()
    {
        if (CoreJsModule is null)
        {
            return UseCodedValues;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return UseCodedValues;
        }

        // get the property value
        bool? result = await CoreJsModule!.InvokeAsync<bool?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "useCodedValues");
        if (result is not null)
        {
#pragma warning disable BL0005
             UseCodedValues = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(UseCodedValues)] = UseCodedValues;
        }
         
        return UseCodedValues;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Where property.
    /// </summary>
    public async Task<string?> GetWhere()
    {
        if (CoreJsModule is null)
        {
            return Where;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Where;
        }

        // get the property value
        string? result = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "where");
        if (result is not null)
        {
#pragma warning disable BL0005
             Where = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Where)] = Where;
        }
         
        return Where;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the AllowOverrun property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetAllowOverrun(bool value)
    {
#pragma warning disable BL0005
        AllowOverrun = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(AllowOverrun)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "allowOverrun", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the DeconflictionStrategy property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetDeconflictionStrategy(DeconflictionStrategy value)
    {
#pragma warning disable BL0005
        DeconflictionStrategy = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(DeconflictionStrategy)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "deconflictionStrategy", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the LabelExpression property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetLabelExpression(string value)
    {
#pragma warning disable BL0005
        LabelExpression = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(LabelExpression)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "labelExpression", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the LabelExpressionInfo property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetLabelExpressionInfo(LabelExpressionInfo value)
    {
#pragma warning disable BL0005
        LabelExpressionInfo = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(LabelExpressionInfo)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "labelExpressionInfo", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the LabelPlacement property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetLabelPlacement(LabelPlacement value)
    {
#pragma warning disable BL0005
        LabelPlacement = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(LabelPlacement)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "labelPlacement", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the LabelPosition property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetLabelPosition(LabelPosition value)
    {
#pragma warning disable BL0005
        LabelPosition = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(LabelPosition)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "labelPosition", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the MaxScale property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMaxScale(double value)
    {
#pragma warning disable BL0005
        MaxScale = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(MaxScale)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "maxScale", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the MinScale property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMinScale(double value)
    {
#pragma warning disable BL0005
        MinScale = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(MinScale)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "minScale", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the RepeatLabel property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetRepeatLabel(bool value)
    {
#pragma warning disable BL0005
        RepeatLabel = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(RepeatLabel)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "repeatLabel", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the RepeatLabelDistance property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetRepeatLabelDistance(Dimension value)
    {
#pragma warning disable BL0005
        RepeatLabelDistance = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(RepeatLabelDistance)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "repeatLabelDistance", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the UseCodedValues property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetUseCodedValues(bool value)
    {
#pragma warning disable BL0005
        UseCodedValues = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(UseCodedValues)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "useCodedValues", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Where property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetWhere(string value)
    {
#pragma warning disable BL0005
        Where = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Where)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "where", value);
    }
    
#endregion





    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Symbol symbol:
                if (symbol != Symbol)
                {
                    Symbol = symbol;
                    
                    ModifiedParameters[nameof(Symbol)] = Symbol;
                }
                
                return true;
            default:
                return await base.RegisterGeneratedChildComponent(child);
        }
    }

    protected override async ValueTask<bool> UnregisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Symbol _:
                Symbol = null;
                
                ModifiedParameters[nameof(Symbol)] = Symbol;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredGeneratedChildren()
    {
    
        Symbol?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
