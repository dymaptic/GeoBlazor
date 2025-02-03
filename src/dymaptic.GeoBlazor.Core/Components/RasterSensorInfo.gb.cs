// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    The `RasterSensorInfo` class provides additional information on the raster sensor associated with an image service referenced by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#serviceRasterInfo">ImageryLayer</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html#rasterInfo">ImageryTileLayer</a>.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class RasterSensorInfo : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public RasterSensorInfo()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="acquisitionDate">
    ///     The acquisition date.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#acquisitionDate">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="cloudCover">
    ///     The cloud coverage (0-1).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#cloudCover">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="productName">
    ///     The satellite product name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#productName">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="sensorAzimuth">
    ///     The sensor azimuth.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#sensorAzimuth">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="sensorElevation">
    ///     The sensor elevation.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#sensorElevation">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="sensorName">
    ///     The sensor name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#sensorName">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="sunAzimuth">
    ///     The sun azimuth.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#sunAzimuth">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="sunElevation">
    ///     The sun elevation.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#sunElevation">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public RasterSensorInfo(
        DateTime? acquisitionDate = null,
        double? cloudCover = null,
        string? productName = null,
        double? sensorAzimuth = null,
        double? sensorElevation = null,
        string? sensorName = null,
        double? sunAzimuth = null,
        double? sunElevation = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        AcquisitionDate = acquisitionDate;
        CloudCover = cloudCover;
        ProductName = productName;
        SensorAzimuth = sensorAzimuth;
        SensorElevation = sensorElevation;
        SensorName = sensorName;
        SunAzimuth = sunAzimuth;
        SunElevation = sunElevation;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     The acquisition date.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#acquisitionDate">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? AcquisitionDate { get; set; }
    
    /// <summary>
    ///     The cloud coverage (0-1).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#cloudCover">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? CloudCover { get; set; }
    
    /// <summary>
    ///     The satellite product name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#productName">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ProductName { get; set; }
    
    /// <summary>
    ///     The sensor azimuth.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#sensorAzimuth">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SensorAzimuth { get; set; }
    
    /// <summary>
    ///     The sensor elevation.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#sensorElevation">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SensorElevation { get; set; }
    
    /// <summary>
    ///     The sensor name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#sensorName">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SensorName { get; set; }
    
    /// <summary>
    ///     The sun azimuth.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#sunAzimuth">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SunAzimuth { get; set; }
    
    /// <summary>
    ///     The sun elevation.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterSensorInfo.html#sunElevation">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SunElevation { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the AcquisitionDate property.
    /// </summary>
    public async Task<DateTime?> GetAcquisitionDate()
    {
        if (CoreJsModule is null)
        {
            return AcquisitionDate;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return AcquisitionDate;
        }

        // get the property value
        JsNullableDateTimeWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDateTimeWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "acquisitionDate");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             AcquisitionDate = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(AcquisitionDate)] = AcquisitionDate;
        }
         
        return AcquisitionDate;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the CloudCover property.
    /// </summary>
    public async Task<double?> GetCloudCover()
    {
        if (CoreJsModule is null)
        {
            return CloudCover;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return CloudCover;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "cloudCover");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             CloudCover = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(CloudCover)] = CloudCover;
        }
         
        return CloudCover;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the ProductName property.
    /// </summary>
    public async Task<string?> GetProductName()
    {
        if (CoreJsModule is null)
        {
            return ProductName;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return ProductName;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "productName");
        if (result is not null)
        {
#pragma warning disable BL0005
             ProductName = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(ProductName)] = ProductName;
        }
         
        return ProductName;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SensorAzimuth property.
    /// </summary>
    public async Task<double?> GetSensorAzimuth()
    {
        if (CoreJsModule is null)
        {
            return SensorAzimuth;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SensorAzimuth;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "sensorAzimuth");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             SensorAzimuth = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SensorAzimuth)] = SensorAzimuth;
        }
         
        return SensorAzimuth;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SensorElevation property.
    /// </summary>
    public async Task<double?> GetSensorElevation()
    {
        if (CoreJsModule is null)
        {
            return SensorElevation;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SensorElevation;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "sensorElevation");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             SensorElevation = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SensorElevation)] = SensorElevation;
        }
         
        return SensorElevation;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SensorName property.
    /// </summary>
    public async Task<string?> GetSensorName()
    {
        if (CoreJsModule is null)
        {
            return SensorName;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SensorName;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "sensorName");
        if (result is not null)
        {
#pragma warning disable BL0005
             SensorName = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SensorName)] = SensorName;
        }
         
        return SensorName;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SunAzimuth property.
    /// </summary>
    public async Task<double?> GetSunAzimuth()
    {
        if (CoreJsModule is null)
        {
            return SunAzimuth;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SunAzimuth;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "sunAzimuth");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             SunAzimuth = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SunAzimuth)] = SunAzimuth;
        }
         
        return SunAzimuth;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SunElevation property.
    /// </summary>
    public async Task<double?> GetSunElevation()
    {
        if (CoreJsModule is null)
        {
            return SunElevation;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return SunElevation;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "sunElevation");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             SunElevation = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SunElevation)] = SunElevation;
        }
         
        return SunElevation;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the AcquisitionDate property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetAcquisitionDate(DateTime value)
    {
#pragma warning disable BL0005
        AcquisitionDate = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(AcquisitionDate)] = value;
        
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
            JsComponentReference, "acquisitionDate", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the CloudCover property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetCloudCover(double value)
    {
#pragma warning disable BL0005
        CloudCover = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(CloudCover)] = value;
        
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
            JsComponentReference, "cloudCover", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ProductName property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetProductName(string value)
    {
#pragma warning disable BL0005
        ProductName = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ProductName)] = value;
        
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
            JsComponentReference, "productName", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SensorAzimuth property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSensorAzimuth(double value)
    {
#pragma warning disable BL0005
        SensorAzimuth = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SensorAzimuth)] = value;
        
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
            JsComponentReference, "sensorAzimuth", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SensorElevation property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSensorElevation(double value)
    {
#pragma warning disable BL0005
        SensorElevation = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SensorElevation)] = value;
        
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
            JsComponentReference, "sensorElevation", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SensorName property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSensorName(string value)
    {
#pragma warning disable BL0005
        SensorName = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SensorName)] = value;
        
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
            JsComponentReference, "sensorName", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SunAzimuth property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSunAzimuth(double value)
    {
#pragma warning disable BL0005
        SunAzimuth = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SunAzimuth)] = value;
        
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
            JsComponentReference, "sunAzimuth", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SunElevation property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSunElevation(double value)
    {
#pragma warning disable BL0005
        SunElevation = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SunElevation)] = value;
        
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
            JsComponentReference, "sunElevation", value);
    }
    
#endregion




}
