// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    A subset of multidimensional raster data created by slicing the data along defined variables and dimensions.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MultidimensionalSubset.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class MultidimensionalSubset
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public MultidimensionalSubset()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="areaOfInterest">
    ///     The spatial area of interest.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MultidimensionalSubset.html#areaOfInterest">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="subsetDefinitions">
    ///     The variable and dimension subset definitions to set the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MultidimensionalSubset.html#subsetDefinitions">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public MultidimensionalSubset(
        Geometry? areaOfInterest = null,
        IReadOnlyList<DimensionalDefinition>? subsetDefinitions = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        AreaOfInterest = areaOfInterest;
        SubsetDefinitions = subsetDefinitions;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     The spatial area of interest.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MultidimensionalSubset.html#areaOfInterest">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? AreaOfInterest { get; set; }
    
    /// <summary>
    ///     The aggregated dimension names and their extents or ranges computed from the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MultidimensionalSubset.html#subsetDefinitions">subsetDefinitions</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MultidimensionalSubset.html#dimensions">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<SubsetDimension>? Dimensions { get; protected set; }
    
    /// <summary>
    ///     The variable and dimension subset definitions to set the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MultidimensionalSubset.html#subsetDefinitions">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<DimensionalDefinition>? SubsetDefinitions { get; set; }
    
    /// <summary>
    ///     The aggregated variables list computed from the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MultidimensionalSubset.html#subsetDefinitions">subsetDefinitions</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MultidimensionalSubset.html#variables">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<string>? Variables { get; protected set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the AreaOfInterest property.
    /// </summary>
    public async Task<Geometry?> GetAreaOfInterest()
    {
        if (CoreJsModule is null)
        {
            return AreaOfInterest;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return AreaOfInterest;
        }

        // get the property value
        Geometry? result = await JsComponentReference!.InvokeAsync<Geometry?>("getProperty",
            CancellationTokenSource.Token, "areaOfInterest");
        if (result is not null)
        {
#pragma warning disable BL0005
             AreaOfInterest = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(AreaOfInterest)] = AreaOfInterest;
        }
         
        return AreaOfInterest;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Dimensions property.
    /// </summary>
    public async Task<IReadOnlyList<SubsetDimension>?> GetDimensions()
    {
        if (CoreJsModule is null)
        {
            return Dimensions;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Dimensions;
        }

        // get the property value
        IReadOnlyList<SubsetDimension>? result = await JsComponentReference!.InvokeAsync<IReadOnlyList<SubsetDimension>?>("getProperty",
            CancellationTokenSource.Token, "dimensions");
        if (result is not null)
        {
#pragma warning disable BL0005
             Dimensions = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Dimensions)] = Dimensions;
        }
         
        return Dimensions;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SubsetDefinitions property.
    /// </summary>
    public async Task<IReadOnlyList<DimensionalDefinition>?> GetSubsetDefinitions()
    {
        if (CoreJsModule is null)
        {
            return SubsetDefinitions;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SubsetDefinitions;
        }

        // get the property value
        IReadOnlyList<DimensionalDefinition>? result = await JsComponentReference!.InvokeAsync<IReadOnlyList<DimensionalDefinition>?>("getProperty",
            CancellationTokenSource.Token, "subsetDefinitions");
        if (result is not null)
        {
#pragma warning disable BL0005
             SubsetDefinitions = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SubsetDefinitions)] = SubsetDefinitions;
        }
         
        return SubsetDefinitions;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Variables property.
    /// </summary>
    public async Task<IReadOnlyList<string>?> GetVariables()
    {
        if (CoreJsModule is null)
        {
            return Variables;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Variables;
        }

        // get the property value
        IReadOnlyList<string>? result = await JsComponentReference!.InvokeAsync<IReadOnlyList<string>?>("getProperty",
            CancellationTokenSource.Token, "variables");
        if (result is not null)
        {
#pragma warning disable BL0005
             Variables = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Variables)] = Variables;
        }
         
        return Variables;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the AreaOfInterest property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetAreaOfInterest(Geometry value)
    {
#pragma warning disable BL0005
        AreaOfInterest = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(AreaOfInterest)] = value;
        
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
            JsComponentReference, "areaOfInterest", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SubsetDefinitions property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSubsetDefinitions(IReadOnlyList<DimensionalDefinition> value)
    {
#pragma warning disable BL0005
        SubsetDefinitions = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SubsetDefinitions)] = value;
        
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
            JsComponentReference, "subsetDefinitions", value);
    }
    
#endregion

#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the SubsetDefinitions property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToSubsetDefinitions(params DimensionalDefinition[] values)
    {
        DimensionalDefinition[] join = SubsetDefinitions is null
            ? values
            : [..SubsetDefinitions, ..values];
        await SetSubsetDefinitions(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the SubsetDefinitions property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromSubsetDefinitions(params DimensionalDefinition[] values)
    {
        if (SubsetDefinitions is null)
        {
            return;
        }
        await SetSubsetDefinitions(SubsetDefinitions.Except(values).ToArray());
    }
    
#endregion





    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case DimensionalDefinition subsetDefinitions:
                SubsetDefinitions ??= [];
                if (!SubsetDefinitions.Contains(subsetDefinitions))
                {
                    SubsetDefinitions = [..SubsetDefinitions, subsetDefinitions];
                    
                    ModifiedParameters[nameof(SubsetDefinitions)] = SubsetDefinitions;
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
            case DimensionalDefinition subsetDefinitions:
                SubsetDefinitions = SubsetDefinitions?.Where(s => s != subsetDefinitions).ToList();
                
                ModifiedParameters[nameof(SubsetDefinitions)] = SubsetDefinitions;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredGeneratedChildren()
    {
    
        if (SubsetDefinitions is not null)
        {
            foreach (DimensionalDefinition child in SubsetDefinitions)
            {
                child.ValidateRequiredGeneratedChildren();
            }
        }
        base.ValidateRequiredGeneratedChildren();
    }
      
}
