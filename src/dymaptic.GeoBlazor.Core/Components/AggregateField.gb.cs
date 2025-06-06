// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.AggregateField.html">GeoBlazor Docs</a>
///     Defines the aggregate fields used in a layer visualized with
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureReductionBinning.html">FeatureReductionBinning</a> or
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureReductionCluster.html">FeatureReductionCluster</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-AggregateField.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class AggregateField
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public AggregateField()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="alias">
    ///     The display name that describes the aggregate field in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html">Legend</a>,
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html">Popup</a>, and other UI elements.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-AggregateField.html#alias">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="isAutoGenerated">
    ///     Indicates whether the field was created internally by the JS API's rendering engine for
    ///     default <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureReductionCluster.html">FeatureReductionCluster</a> visualizations.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-AggregateField.html#isAutoGenerated">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="name">
    ///     The name of the aggregate field.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-AggregateField.html#name">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="onStatisticExpression">
    ///     An object containing an <a target="_blank" href="https://developers.arcgis.com/javascript/latest/arcade/">Arcade</a> expression, which evaluates for each child feature represented
    ///     by the aggregate graphic.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-AggregateField.html#onStatisticExpression">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="onStatisticField">
    ///     The name of the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#fields">layer field</a> to summarize with the given <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-AggregateField.html#statisticType">statisticType</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-AggregateField.html#onStatisticField">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="statisticType">
    ///     Defines the type of statistic used to aggregate data returned from <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-AggregateField.html#onStatisticField">onStatisticField</a>
    ///     or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-AggregateField.html#onStatisticExpression">onStatisticExpression</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-AggregateField.html#statisticType">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public AggregateField(
        string? alias = null,
        bool? isAutoGenerated = null,
        string? name = null,
        SupportExpressionInfo? onStatisticExpression = null,
        string? onStatisticField = null,
        AggregateStatisticType? statisticType = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Alias = alias;
        IsAutoGenerated = isAutoGenerated;
        Name = name;
        OnStatisticExpression = onStatisticExpression;
        OnStatisticField = onStatisticField;
        StatisticType = statisticType;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.AggregateField.html#aggregatefieldonstatisticexpression-property">GeoBlazor Docs</a>
    ///     An object containing an <a target="_blank" href="https://developers.arcgis.com/javascript/latest/arcade/">Arcade</a> expression, which evaluates for each child feature represented
    ///     by the aggregate graphic.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-AggregateField.html#onStatisticExpression">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SupportExpressionInfo? OnStatisticExpression { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Alias property.
    /// </summary>
    public async Task<string?> GetAlias()
    {
        if (CoreJsModule is null)
        {
            return Alias;
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
            return Alias;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "alias");
        if (result is not null)
        {
#pragma warning disable BL0005
             Alias = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Alias)] = Alias;
        }
         
        return Alias;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the IsAutoGenerated property.
    /// </summary>
    public async Task<bool?> GetIsAutoGenerated()
    {
        if (CoreJsModule is null)
        {
            return IsAutoGenerated;
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
            return IsAutoGenerated;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "isAutoGenerated");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             IsAutoGenerated = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(IsAutoGenerated)] = IsAutoGenerated;
        }
         
        return IsAutoGenerated;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Name property.
    /// </summary>
    public async Task<string?> GetName()
    {
        if (CoreJsModule is null)
        {
            return Name;
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
            return Name;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "name");
        if (result is not null)
        {
#pragma warning disable BL0005
             Name = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Name)] = Name;
        }
         
        return Name;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the OnStatisticExpression property.
    /// </summary>
    public async Task<SupportExpressionInfo?> GetOnStatisticExpression()
    {
        if (CoreJsModule is null)
        {
            return OnStatisticExpression;
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
            return OnStatisticExpression;
        }

        SupportExpressionInfo? result = await JsComponentReference.InvokeAsync<SupportExpressionInfo?>(
            "getOnStatisticExpression", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            OnStatisticExpression = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(OnStatisticExpression)] = OnStatisticExpression;
        }
        
        return OnStatisticExpression;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the OnStatisticField property.
    /// </summary>
    public async Task<string?> GetOnStatisticField()
    {
        if (CoreJsModule is null)
        {
            return OnStatisticField;
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
            return OnStatisticField;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "onStatisticField");
        if (result is not null)
        {
#pragma warning disable BL0005
             OnStatisticField = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(OnStatisticField)] = OnStatisticField;
        }
         
        return OnStatisticField;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the StatisticType property.
    /// </summary>
    public async Task<AggregateStatisticType?> GetStatisticType()
    {
        if (CoreJsModule is null)
        {
            return StatisticType;
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
            return StatisticType;
        }

        // get the property value
        JsNullableEnumWrapper<AggregateStatisticType>? result = await CoreJsModule!.InvokeAsync<JsNullableEnumWrapper<AggregateStatisticType>?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "statisticType");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             StatisticType = (AggregateStatisticType)result.Value.Value!;
#pragma warning restore BL0005
             ModifiedParameters[nameof(StatisticType)] = StatisticType;
        }
         
        return StatisticType;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Alias property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetAlias(string? value)
    {
#pragma warning disable BL0005
        Alias = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Alias)] = value;
        
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
            JsComponentReference, "alias", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the IsAutoGenerated property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetIsAutoGenerated(bool? value)
    {
#pragma warning disable BL0005
        IsAutoGenerated = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(IsAutoGenerated)] = value;
        
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
            JsComponentReference, "isAutoGenerated", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Name property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetName(string? value)
    {
#pragma warning disable BL0005
        Name = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Name)] = value;
        
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
            JsComponentReference, "name", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the OnStatisticExpression property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetOnStatisticExpression(SupportExpressionInfo? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        OnStatisticExpression = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(OnStatisticExpression)] = value;
        
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
            JsComponentReference, "onStatisticExpression", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the OnStatisticField property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetOnStatisticField(string? value)
    {
#pragma warning disable BL0005
        OnStatisticField = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(OnStatisticField)] = value;
        
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
            JsComponentReference, "onStatisticField", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the StatisticType property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetStatisticType(AggregateStatisticType? value)
    {
#pragma warning disable BL0005
        StatisticType = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(StatisticType)] = value;
        
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
            JsComponentReference, "statisticType", value);
    }
    
#endregion


    /// <inheritdoc />
    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SupportExpressionInfo onStatisticExpression:
                if (onStatisticExpression != OnStatisticExpression)
                {
                    OnStatisticExpression = onStatisticExpression;
                    ModifiedParameters[nameof(OnStatisticExpression)] = OnStatisticExpression;
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
            case SupportExpressionInfo _:
                OnStatisticExpression = null;
                ModifiedParameters[nameof(OnStatisticExpression)] = OnStatisticExpression;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    public override void ValidateRequiredGeneratedChildren()
    {
    
        OnStatisticExpression?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
