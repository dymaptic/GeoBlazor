// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    A dimension may be used to represent real physical dimensions such as time or depth/height.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class RasterMultidimensionalInfoVariablesDimensions : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public RasterMultidimensionalInfoVariablesDimensions()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="description">
    ///     Dimension description.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="extent">
    ///     The extent of dimension values.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="hasRegularIntervals">
    ///     Indicates if the dimension is recorded at regular intervals.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="interval">
    ///     Dimension interval.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="intervalUnit">
    ///     Dimension interval unit.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="name">
    ///     Dimension name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="unit">
    ///     Dimension unit.
    ///     <a target="_blank" href="global.html#unit">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="values">
    ///     An array of single values or tuples [min, max] each defining a range of valid values along the specified dimension.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public RasterMultidimensionalInfoVariablesDimensions(
        string? description = null,
        IReadOnlyList<double>? extent = null,
        bool? hasRegularIntervals = null,
        double? interval = null,
        string? intervalUnit = null,
        string? name = null,
        string? unit = null,
        IReadOnlyList<double>? values = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Description = description;
        Extent = extent;
        HasRegularIntervals = hasRegularIntervals;
        Interval = interval;
        IntervalUnit = intervalUnit;
        Name = name;
        Unit = unit;
        Values = values;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     Dimension description.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }
    
    /// <summary>
    ///     The extent of dimension values.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<double>? Extent { get; set; }
    
    /// <summary>
    ///     Indicates if the dimension is recorded at regular intervals.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasRegularIntervals { get; set; }
    
    /// <summary>
    ///     Dimension interval.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Interval { get; set; }
    
    /// <summary>
    ///     Dimension interval unit.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? IntervalUnit { get; set; }
    
    /// <summary>
    ///     Dimension name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
    
    /// <summary>
    ///     Dimension unit.
    ///     <a target="_blank" href="global.html#unit">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Unit { get; set; }
    
    /// <summary>
    ///     An array of single values or tuples [min, max] each defining a range of valid values along the specified dimension.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#RasterMultidimensionalInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<double>? Values { get; set; }
    
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
    ///     Asynchronously retrieve the current value of the Extent property.
    /// </summary>
    public async Task<IReadOnlyList<double>?> GetExtent()
    {
        if (CoreJsModule is null)
        {
            return Extent;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Extent;
        }

        // get the property value
#pragma warning disable BL0005
        Extent = await CoreJsModule!.InvokeAsync<IReadOnlyList<double>>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "extent");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Extent)] = Extent;
        return Extent;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the HasRegularIntervals property.
    /// </summary>
    public async Task<bool?> GetHasRegularIntervals()
    {
        if (CoreJsModule is null)
        {
            return HasRegularIntervals;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return HasRegularIntervals;
        }

        // get the property value
#pragma warning disable BL0005
        HasRegularIntervals = await CoreJsModule!.InvokeAsync<bool>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "hasRegularIntervals");
#pragma warning restore BL0005
         ModifiedParameters[nameof(HasRegularIntervals)] = HasRegularIntervals;
        return HasRegularIntervals;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Interval property.
    /// </summary>
    public async Task<double?> GetInterval()
    {
        if (CoreJsModule is null)
        {
            return Interval;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Interval;
        }

        // get the property value
#pragma warning disable BL0005
        Interval = await CoreJsModule!.InvokeAsync<double>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "interval");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Interval)] = Interval;
        return Interval;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the IntervalUnit property.
    /// </summary>
    public async Task<string?> GetIntervalUnit()
    {
        if (CoreJsModule is null)
        {
            return IntervalUnit;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return IntervalUnit;
        }

        // get the property value
#pragma warning disable BL0005
        IntervalUnit = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "intervalUnit");
#pragma warning restore BL0005
         ModifiedParameters[nameof(IntervalUnit)] = IntervalUnit;
        return IntervalUnit;
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
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Values property.
    /// </summary>
    public async Task<IReadOnlyList<double>?> GetValues()
    {
        if (CoreJsModule is null)
        {
            return Values;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Values;
        }

        // get the property value
#pragma warning disable BL0005
        Values = await CoreJsModule!.InvokeAsync<IReadOnlyList<double>>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "values");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Values)] = Values;
        return Values;
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
    ///    Asynchronously set the value of the Extent property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetExtent(IReadOnlyList<double> value)
    {
#pragma warning disable BL0005
        Extent = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Extent)] = value;
        
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
            JsComponentReference, "extent", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the HasRegularIntervals property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetHasRegularIntervals(bool value)
    {
#pragma warning disable BL0005
        HasRegularIntervals = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(HasRegularIntervals)] = value;
        
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
            JsComponentReference, "hasRegularIntervals", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Interval property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetInterval(double value)
    {
#pragma warning disable BL0005
        Interval = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Interval)] = value;
        
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
            JsComponentReference, "interval", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the IntervalUnit property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetIntervalUnit(string value)
    {
#pragma warning disable BL0005
        IntervalUnit = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(IntervalUnit)] = value;
        
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
            JsComponentReference, "intervalUnit", value);
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
    
    /// <summary>
    ///    Asynchronously set the value of the Values property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetValues(IReadOnlyList<double> value)
    {
#pragma warning disable BL0005
        Values = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Values)] = value;
        
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
            JsComponentReference, "values", value);
    }
    
#endregion

#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the Extent property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToExtent(params double[] values)
    {
        double[] join = Extent is null
            ? values
            : [..Extent, ..values];
        await SetExtent(join);
    }
    
    /// <summary>
    ///     Asynchronously adds elements to the Values property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToValues(params double[] values)
    {
        double[] join = Values is null
            ? values
            : [..Values, ..values];
        await SetValues(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the Extent property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromExtent(params double[] values)
    {
        if (Extent is null)
        {
            return;
        }
        await SetExtent(Extent.Except(values).ToArray());
    }
    
    
    /// <summary>
    ///     Asynchronously remove an element from the Values property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromValues(params double[] values)
    {
        if (Values is null)
        {
            return;
        }
        await SetValues(Values.Except(values).ToArray());
    }
    
#endregion




}
