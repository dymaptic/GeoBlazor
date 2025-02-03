// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    An object representing the pixel arrays in the view.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class PixelBlock : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public PixelBlock()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="height">
    ///     The height (or number of rows) of the PixelBlock in pixels.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#height">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="mask">
    ///     An array of nodata mask.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#mask">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="maskIsAlpha">
    ///     Indicates whether mask should be used as alpha values.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#maskIsAlpha">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="pixels">
    ///     A two dimensional array representing the pixels from the Image Service displayed on the client.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#pixels">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="pixelType">
    ///     The pixel type.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#pixelType">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="statistics">
    ///     An array of objects containing numeric statistical properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#statistics">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="validPixelCount">
    ///     Number of valid pixels
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#validPixelCount">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="width">
    ///     The width (or number of columns) of the PixelBlock in pixels.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#width">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public PixelBlock(
        int? height = null,
        Stream? mask = null,
        bool? maskIsAlpha = null,
        Stream? pixels = null,
        PixelType? pixelType = null,
        IReadOnlyList<PixelBlockStatistics>? statistics = null,
        int? validPixelCount = null,
        int? width = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Height = height;
        Mask = mask;
        MaskIsAlpha = maskIsAlpha;
        Pixels = pixels;
        PixelType = pixelType;
        Statistics = statistics;
        ValidPixelCount = validPixelCount;
        Width = width;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     The height (or number of rows) of the PixelBlock in pixels.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#height">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Height { get; set; }
    
    /// <summary>
    ///     An array of nodata mask.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#mask">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Stream? Mask { get; set; }
    
    /// <summary>
    ///     Indicates whether mask should be used as alpha values.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#maskIsAlpha">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? MaskIsAlpha { get; set; }
    
    /// <summary>
    ///     A two dimensional array representing the pixels from the Image Service displayed on the client.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#pixels">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Stream? Pixels { get; set; }
    
    /// <summary>
    ///     The pixel type.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#pixelType">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PixelType? PixelType { get; set; }
    
    /// <summary>
    ///     An array of objects containing numeric statistical properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#statistics">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<PixelBlockStatistics>? Statistics { get; set; }
    
    /// <summary>
    ///     Number of valid pixels
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#validPixelCount">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ValidPixelCount { get; set; }
    
    /// <summary>
    ///     The width (or number of columns) of the PixelBlock in pixels.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#width">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Width { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Height property.
    /// </summary>
    public async Task<int?> GetHeight()
    {
        if (CoreJsModule is null)
        {
            return Height;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Height;
        }

        // get the property value
        JsNullableIntWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableIntWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "height");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Height = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Height)] = Height;
        }
         
        return Height;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Mask property.
    /// </summary>
    public async Task<Stream?> GetMask()
    {
        if (CoreJsModule is null)
        {
            return Mask;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Mask;
        }

        // get the property value
        Stream? result = await JsComponentReference!.InvokeAsync<Stream?>("getProperty",
            CancellationTokenSource.Token, "mask");
        if (result is not null)
        {
#pragma warning disable BL0005
             Mask = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Mask)] = Mask;
        }
         
        return Mask;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the MaskIsAlpha property.
    /// </summary>
    public async Task<bool?> GetMaskIsAlpha()
    {
        if (CoreJsModule is null)
        {
            return MaskIsAlpha;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return MaskIsAlpha;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "maskIsAlpha");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             MaskIsAlpha = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(MaskIsAlpha)] = MaskIsAlpha;
        }
         
        return MaskIsAlpha;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Pixels property.
    /// </summary>
    public async Task<Stream?> GetPixels()
    {
        if (CoreJsModule is null)
        {
            return Pixels;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Pixels;
        }

        // get the property value
        Stream? result = await JsComponentReference!.InvokeAsync<Stream?>("getProperty",
            CancellationTokenSource.Token, "pixels");
        if (result is not null)
        {
#pragma warning disable BL0005
             Pixels = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Pixels)] = Pixels;
        }
         
        return Pixels;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the PixelType property.
    /// </summary>
    public async Task<PixelType?> GetPixelType()
    {
        if (CoreJsModule is null)
        {
            return PixelType;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return PixelType;
        }

        // get the property value
        PixelType? result = await JsComponentReference!.InvokeAsync<PixelType?>("getProperty",
            CancellationTokenSource.Token, "pixelType");
        if (result is not null)
        {
#pragma warning disable BL0005
             PixelType = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(PixelType)] = PixelType;
        }
         
        return PixelType;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Statistics property.
    /// </summary>
    public async Task<IReadOnlyList<PixelBlockStatistics>?> GetStatistics()
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
        IReadOnlyList<PixelBlockStatistics>? result = await JsComponentReference!.InvokeAsync<IReadOnlyList<PixelBlockStatistics>?>("getProperty",
            CancellationTokenSource.Token, "statistics");
        if (result is not null)
        {
#pragma warning disable BL0005
             Statistics = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Statistics)] = Statistics;
        }
         
        return Statistics;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the ValidPixelCount property.
    /// </summary>
    public async Task<int?> GetValidPixelCount()
    {
        if (CoreJsModule is null)
        {
            return ValidPixelCount;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return ValidPixelCount;
        }

        // get the property value
        JsNullableIntWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableIntWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "validPixelCount");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             ValidPixelCount = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(ValidPixelCount)] = ValidPixelCount;
        }
         
        return ValidPixelCount;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Width property.
    /// </summary>
    public async Task<int?> GetWidth()
    {
        if (CoreJsModule is null)
        {
            return Width;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Width;
        }

        // get the property value
        JsNullableIntWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableIntWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "width");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Width = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Width)] = Width;
        }
         
        return Width;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Height property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetHeight(int value)
    {
#pragma warning disable BL0005
        Height = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Height)] = value;
        
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
            JsComponentReference, "height", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Mask property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMask(Stream value)
    {
#pragma warning disable BL0005
        Mask = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Mask)] = value;
        
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
            JsComponentReference, "mask", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the MaskIsAlpha property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMaskIsAlpha(bool value)
    {
#pragma warning disable BL0005
        MaskIsAlpha = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(MaskIsAlpha)] = value;
        
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
            JsComponentReference, "maskIsAlpha", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Pixels property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetPixels(Stream value)
    {
#pragma warning disable BL0005
        Pixels = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Pixels)] = value;
        
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
            JsComponentReference, "pixels", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the PixelType property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetPixelType(PixelType value)
    {
#pragma warning disable BL0005
        PixelType = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(PixelType)] = value;
        
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
            JsComponentReference, "pixelType", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Statistics property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetStatistics(IReadOnlyList<PixelBlockStatistics> value)
    {
#pragma warning disable BL0005
        Statistics = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Statistics)] = value;
        
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
            JsComponentReference, "statistics", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ValidPixelCount property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetValidPixelCount(int value)
    {
#pragma warning disable BL0005
        ValidPixelCount = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ValidPixelCount)] = value;
        
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
            JsComponentReference, "validPixelCount", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Width property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetWidth(int value)
    {
#pragma warning disable BL0005
        Width = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Width)] = value;
        
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
            JsComponentReference, "width", value);
    }
    
#endregion

#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the Statistics property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToStatistics(params PixelBlockStatistics[] values)
    {
        PixelBlockStatistics[] join = Statistics is null
            ? values
            : [..Statistics, ..values];
        await SetStatistics(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the Statistics property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromStatistics(params PixelBlockStatistics[] values)
    {
        if (Statistics is null)
        {
            return;
        }
        await SetStatistics(Statistics.Except(values).ToArray());
    }
    
#endregion


#region Public Methods

    /// <summary>
    ///     Adds another plane to the PixelBlock.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#addData">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="planeData">
    ///     The data to add to the PixelBlock.
    /// </param>
    [ArcGISMethod]
    public async Task AddData(PixelBlockAddDataPlaneData planeData)
    {
        if (JsComponentReference is null) return;
        
        await JsComponentReference!.InvokeVoidAsync(
            "addData", 
            CancellationTokenSource.Token,
planeData);
    }
    
    /// <summary>
    ///     Returns pixels and masks using a single array in bip format (e.g.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#getAsRGBA">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISMethod]
    public async Task<Stream?> GetAsRGBA()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference!.InvokeAsync<Stream?>(
            "getAsRGBA", 
            CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     Similar to <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#getAsRGBA">getAsRGBA</a>, but returns floating point data.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#getAsRGBAFloat">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISMethod]
    public async Task<float[]?> GetAsRGBAFloat()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference!.InvokeAsync<float[]?>(
            "getAsRGBAFloat", 
            CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     Returns the plane band count of the PixelBlock.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#getPlaneCount">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISMethod]
    public async Task<int?> GetPlaneCount()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference!.InvokeAsync<int?>(
            "getPlaneCount", 
            CancellationTokenSource.Token);
    }
    
#endregion




    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PixelBlockStatistics statistics:
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
            case PixelBlockStatistics statistics:
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
    
        if (Statistics is not null)
        {
            foreach (PixelBlockStatistics child in Statistics)
            {
                child.ValidateRequiredGeneratedChildren();
            }
        }
        base.ValidateRequiredGeneratedChildren();
    }
      
}
