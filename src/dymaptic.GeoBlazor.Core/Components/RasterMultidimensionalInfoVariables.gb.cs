// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    The multi dimensional variables.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class RasterMultidimensionalInfoVariables : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public RasterMultidimensionalInfoVariables()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="description">
    ///     Variable description.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="dimensions">
    ///     A dimension may be used to represent real physical dimensions such as time or depth/height.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="histograms">
    ///     Variable histograms.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="name">
    ///     Variable name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="statistics">
    ///     Variable statistics.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="unit">
    ///     Unit of the variable measured in.
    ///     <a target="_blank" href="global.html#unit">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public RasterMultidimensionalInfoVariables(
        string? description = null,
        IReadOnlyList<RasterMultidimensionalInfoVariablesDimensions>? dimensions = null,
        IReadOnlyList<RasterHistogram>? histograms = null,
        string? name = null,
        IReadOnlyList<RasterBandStatistics>? statistics = null,
        string? unit = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Description = description;
        Dimensions = dimensions;
        Histograms = histograms;
        Name = name;
        Statistics = statistics;
        Unit = unit;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     Variable description.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }
    
    /// <summary>
    ///     A dimension may be used to represent real physical dimensions such as time or depth/height.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<RasterMultidimensionalInfoVariablesDimensions>? Dimensions { get; set; }
    
    /// <summary>
    ///     Variable histograms.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<RasterHistogram>? Histograms { get; set; }
    
    /// <summary>
    ///     Variable name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
    
    /// <summary>
    ///     Variable statistics.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<RasterBandStatistics>? Statistics { get; set; }
    
    /// <summary>
    ///     Unit of the variable measured in.
    ///     <a target="_blank" href="global.html#unit">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Unit { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Description property.
    /// </summary>
    public async Task<string?> GetDescription()
    {
        if (CoreJsModule is null)
        {
            return Description;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Description;
        }

        // get the property value
#pragma warning disable BL0005
        Description = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "description");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Description)] = Description;
        return Description;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Dimensions property.
    /// </summary>
    public async Task<IReadOnlyList<RasterMultidimensionalInfoVariablesDimensions>?> GetDimensions()
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
#pragma warning disable BL0005
        Dimensions = await CoreJsModule!.InvokeAsync<IReadOnlyList<RasterMultidimensionalInfoVariablesDimensions>?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "dimensions");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Dimensions)] = Dimensions;
        return Dimensions;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Histograms property.
    /// </summary>
    public async Task<IReadOnlyList<RasterHistogram>?> GetHistograms()
    {
        if (CoreJsModule is null)
        {
            return Histograms;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Histograms;
        }

        // get the property value
#pragma warning disable BL0005
        Histograms = await CoreJsModule!.InvokeAsync<IReadOnlyList<RasterHistogram>?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "histograms");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Histograms)] = Histograms;
        return Histograms;
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
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Name;
        }

        // get the property value
#pragma warning disable BL0005
        Name = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "name");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Name)] = Name;
        return Name;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Statistics property.
    /// </summary>
    public async Task<IReadOnlyList<RasterBandStatistics>?> GetStatistics()
    {
        if (CoreJsModule is null)
        {
            return Statistics;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Statistics;
        }

        // get the property value
#pragma warning disable BL0005
        Statistics = await CoreJsModule!.InvokeAsync<IReadOnlyList<RasterBandStatistics>?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "statistics");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Statistics)] = Statistics;
        return Statistics;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Unit property.
    /// </summary>
    public async Task<string?> GetUnit()
    {
        if (CoreJsModule is null)
        {
            return Unit;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Unit;
        }

        // get the property value
#pragma warning disable BL0005
        Unit = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "unit");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Unit)] = Unit;
        return Unit;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Description property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetDescription(string value)
    {
#pragma warning disable BL0005
        Description = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Description)] = value;
        
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
            JsComponentReference, "description", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Dimensions property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetDimensions(IReadOnlyList<RasterMultidimensionalInfoVariablesDimensions> value)
    {
#pragma warning disable BL0005
        Dimensions = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Dimensions)] = value;
        
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
            JsComponentReference, "dimensions", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Histograms property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetHistograms(IReadOnlyList<RasterHistogram> value)
    {
#pragma warning disable BL0005
        Histograms = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Histograms)] = value;
        
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
            JsComponentReference, "histograms", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Name property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetName(string value)
    {
#pragma warning disable BL0005
        Name = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Name)] = value;
        
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
            JsComponentReference, "name", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Statistics property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetStatistics(IReadOnlyList<RasterBandStatistics> value)
    {
#pragma warning disable BL0005
        Statistics = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Statistics)] = value;
        
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
            JsComponentReference, "statistics", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Unit property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetUnit(string value)
    {
#pragma warning disable BL0005
        Unit = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Unit)] = value;
        
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
            JsComponentReference, "unit", value);
    }
    
#endregion

#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the Dimensions property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToDimensions(params RasterMultidimensionalInfoVariablesDimensions[] values)
    {
        RasterMultidimensionalInfoVariablesDimensions[] join = Dimensions is null
            ? values
            : [..Dimensions, ..values];
        await SetDimensions(join);
    }
    
    /// <summary>
    ///     Asynchronously adds elements to the Histograms property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToHistograms(params RasterHistogram[] values)
    {
        RasterHistogram[] join = Histograms is null
            ? values
            : [..Histograms, ..values];
        await SetHistograms(join);
    }
    
    /// <summary>
    ///     Asynchronously adds elements to the Statistics property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToStatistics(params RasterBandStatistics[] values)
    {
        RasterBandStatistics[] join = Statistics is null
            ? values
            : [..Statistics, ..values];
        await SetStatistics(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the Dimensions property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromDimensions(params RasterMultidimensionalInfoVariablesDimensions[] values)
    {
        if (Dimensions is null)
        {
            return;
        }
        await SetDimensions(Dimensions.Except(values).ToArray());
    }
    
    
    /// <summary>
    ///     Asynchronously remove an element from the Histograms property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromHistograms(params RasterHistogram[] values)
    {
        if (Histograms is null)
        {
            return;
        }
        await SetHistograms(Histograms.Except(values).ToArray());
    }
    
    
    /// <summary>
    ///     Asynchronously remove an element from the Statistics property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromStatistics(params RasterBandStatistics[] values)
    {
        if (Statistics is null)
        {
            return;
        }
        await SetStatistics(Statistics.Except(values).ToArray());
    }
    
#endregion





    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case RasterMultidimensionalInfoVariablesDimensions dimensions:
                Dimensions ??= [];
                if (!Dimensions.Contains(dimensions))
                {
                    Dimensions = [..Dimensions, dimensions];
                    
                    ModifiedParameters[nameof(Dimensions)] = Dimensions;
                }
                
                return true;
            case RasterHistogram histograms:
                Histograms ??= [];
                if (!Histograms.Contains(histograms))
                {
                    Histograms = [..Histograms, histograms];
                    
                    ModifiedParameters[nameof(Histograms)] = Histograms;
                }
                
                return true;
            case RasterBandStatistics statistics:
                Statistics ??= [];
                if (!Statistics.Contains(statistics))
                {
                    Statistics = [..Statistics, statistics];
                    
                    ModifiedParameters[nameof(Statistics)] = Statistics;
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
            case RasterMultidimensionalInfoVariablesDimensions dimensions:
                Dimensions = Dimensions?.Where(d => d != dimensions).ToList();
                
                ModifiedParameters[nameof(Dimensions)] = Dimensions;
                return true;
            case RasterHistogram histograms:
                Histograms = Histograms?.Where(h => h != histograms).ToList();
                
                ModifiedParameters[nameof(Histograms)] = Histograms;
                return true;
            case RasterBandStatistics statistics:
                Statistics = Statistics?.Where(s => s != statistics).ToList();
                
                ModifiedParameters[nameof(Statistics)] = Statistics;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredGeneratedChildren()
    {
    
        if (Dimensions is not null)
        {
            foreach (RasterMultidimensionalInfoVariablesDimensions child in Dimensions)
            {
                child.ValidateRequiredGeneratedChildren();
            }
        }
        if (Histograms is not null)
        {
            foreach (RasterHistogram child in Histograms)
            {
                child.ValidateRequiredGeneratedChildren();
            }
        }
        if (Statistics is not null)
        {
            foreach (RasterBandStatistics child in Statistics)
            {
                child.ValidateRequiredGeneratedChildren();
            }
        }
        base.ValidateRequiredGeneratedChildren();
    }
      
}
