namespace dymaptic.GeoBlazor.Core.Components;

public partial class RasterBandStatistics : MapComponent
{

    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     Average of the statistics.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Avg { get; set; }
    
    /// <summary>
    ///     Count of the statistics.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Count { get; set; }
    
    /// <summary>
    ///     Maximum value of the statistics.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Max { get; set; }
    
    /// <summary>
    ///     Median value of the statistics.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Median { get; set; }
    
    /// <summary>
    ///     Minimum value of the statistics.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Min { get; set; }
    
    /// <summary>
    ///     Mode value of the statistics.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Mode { get; set; }
    
    /// <summary>
    ///     Standard deviation of the statistics.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Stddev { get; set; }
    
    /// <summary>
    ///     Sum of the statistics.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Sum { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Avg property.
    /// </summary>
    public async Task<double?> GetAvg()
    {
        if (CoreJsModule is null)
        {
            return Avg;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Avg;
        }

        // get the property value
#pragma warning disable BL0005
        Avg = await CoreJsModule!.InvokeAsync<double?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "avg");
#pragma warning restore BL0005
        return Avg;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Count property.
    /// </summary>
    public async Task<int?> GetCount()
    {
        if (CoreJsModule is null)
        {
            return Count;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Count;
        }

        // get the property value
#pragma warning disable BL0005
        Count = await CoreJsModule!.InvokeAsync<int?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "count");
#pragma warning restore BL0005
        return Count;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Max property.
    /// </summary>
    public async Task<double?> GetMax()
    {
        if (CoreJsModule is null)
        {
            return Max;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Max;
        }

        // get the property value
#pragma warning disable BL0005
        Max = await CoreJsModule!.InvokeAsync<double?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "max");
#pragma warning restore BL0005
        return Max;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Median property.
    /// </summary>
    public async Task<double?> GetMedian()
    {
        if (CoreJsModule is null)
        {
            return Median;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Median;
        }

        // get the property value
#pragma warning disable BL0005
        Median = await CoreJsModule!.InvokeAsync<double?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "median");
#pragma warning restore BL0005
        return Median;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Min property.
    /// </summary>
    public async Task<double?> GetMin()
    {
        if (CoreJsModule is null)
        {
            return Min;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Min;
        }

        // get the property value
#pragma warning disable BL0005
        Min = await CoreJsModule!.InvokeAsync<double?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "min");
#pragma warning restore BL0005
        return Min;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Mode property.
    /// </summary>
    public async Task<double?> GetMode()
    {
        if (CoreJsModule is null)
        {
            return Mode;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Mode;
        }

        // get the property value
#pragma warning disable BL0005
        Mode = await CoreJsModule!.InvokeAsync<double?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "mode");
#pragma warning restore BL0005
        return Mode;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Stddev property.
    /// </summary>
    public async Task<double?> GetStddev()
    {
        if (CoreJsModule is null)
        {
            return Stddev;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Stddev;
        }

        // get the property value
#pragma warning disable BL0005
        Stddev = await CoreJsModule!.InvokeAsync<double?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "stddev");
#pragma warning restore BL0005
        return Stddev;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Sum property.
    /// </summary>
    public async Task<double?> GetSum()
    {
        if (CoreJsModule is null)
        {
            return Sum;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Sum;
        }

        // get the property value
#pragma warning disable BL0005
        Sum = await CoreJsModule!.InvokeAsync<double?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "sum");
#pragma warning restore BL0005
        return Sum;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Avg property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetAvg(double value)
    {
#pragma warning disable BL0005
        Avg = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Avg)] = value;
        
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
            JsComponentReference, "avg", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Count property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetCount(int value)
    {
#pragma warning disable BL0005
        Count = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Count)] = value;
        
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
            JsComponentReference, "count", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Max property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMax(double value)
    {
#pragma warning disable BL0005
        Max = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Max)] = value;
        
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
            JsComponentReference, "max", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Median property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMedian(double value)
    {
#pragma warning disable BL0005
        Median = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Median)] = value;
        
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
            JsComponentReference, "median", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Min property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMin(double value)
    {
#pragma warning disable BL0005
        Min = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Min)] = value;
        
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
            JsComponentReference, "min", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Mode property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMode(double value)
    {
#pragma warning disable BL0005
        Mode = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Mode)] = value;
        
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
            JsComponentReference, "mode", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Stddev property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetStddev(double value)
    {
#pragma warning disable BL0005
        Stddev = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Stddev)] = value;
        
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
            JsComponentReference, "stddev", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Sum property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSum(double value)
    {
#pragma warning disable BL0005
        Sum = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Sum)] = value;
        
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
            JsComponentReference, "sum", value);
    }
    
#endregion
    
}