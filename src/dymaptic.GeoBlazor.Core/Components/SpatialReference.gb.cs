// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    Defines the spatial reference of a view, layer, or method parameters.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class SpatialReference
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SpatialReference()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="wkid">
    ///     The well-known ID of a spatial reference.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html#wkid">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="imageCoordinateSystem">
    ///     An <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/raster-ics.htm">image coordinate system</a> defines the spatial reference used to display the image in its original coordinates without distortion, map transformations or ortho-rectification.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html#imageCoordinateSystem">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="wkt">
    ///     The well-known text that defines a spatial reference.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html#wkt">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="wkt2">
    ///     The well-known text of the coordinate system as defined by OGC standard for well-known text strings.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html#wkt2">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public SpatialReference(
        int wkid,
        string? imageCoordinateSystem = null,
        string? wkt = null,
        string? wkt2 = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Wkid = wkid;
        ImageCoordinateSystem = imageCoordinateSystem;
        if (wkt is not null)
        {
            Wkt = wkt;
        }
        if (wkt2 is not null)
        {
            Wkt2 = wkt2;
        }
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     An <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/raster-ics.htm">image coordinate system</a> defines the spatial reference used to display the image in its original coordinates without distortion, map transformations or ortho-rectification.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html#imageCoordinateSystem">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ImageCoordinateSystem { get; set; }
    
    /// <summary>
    ///     The factor to convert one unit value in the spatial reference's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html#unit">unit</a> to meters.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html#metersPerUnit">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MetersPerUnit { get; protected set; }
    
    /// <summary>
    ///     The unit of the spatial reference.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html#unit">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReferenceUnit? Unit { get; protected set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the ImageCoordinateSystem property.
    /// </summary>
    public async Task<string?> GetImageCoordinateSystem()
    {
        if (CoreJsModule is null)
        {
            return ImageCoordinateSystem;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return ImageCoordinateSystem;
        }

        // get the property value
#pragma warning disable BL0005
        ImageCoordinateSystem = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "imageCoordinateSystem");
#pragma warning restore BL0005
         ModifiedParameters[nameof(ImageCoordinateSystem)] = ImageCoordinateSystem;
        return ImageCoordinateSystem;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the MetersPerUnit property.
    /// </summary>
    public async Task<double?> GetMetersPerUnit()
    {
        if (CoreJsModule is null)
        {
            return MetersPerUnit;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return MetersPerUnit;
        }

        // get the property value
#pragma warning disable BL0005
        MetersPerUnit = await CoreJsModule!.InvokeAsync<double>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "metersPerUnit");
#pragma warning restore BL0005
         ModifiedParameters[nameof(MetersPerUnit)] = MetersPerUnit;
        return MetersPerUnit;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Unit property.
    /// </summary>
    public async Task<SpatialReferenceUnit?> GetUnit()
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
        Unit = await CoreJsModule!.InvokeAsync<SpatialReferenceUnit>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "unit");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Unit)] = Unit;
        return Unit;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Wkid property.
    /// </summary>
    public async Task<int?> GetWkid()
    {
        if (CoreJsModule is null)
        {
            return Wkid;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Wkid;
        }

        // get the property value
#pragma warning disable BL0005
        Wkid = await CoreJsModule!.InvokeAsync<int>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "wkid");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Wkid)] = Wkid;
        return Wkid;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Wkt property.
    /// </summary>
    public async Task<string?> GetWkt()
    {
        if (CoreJsModule is null)
        {
            return Wkt;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Wkt;
        }

        // get the property value
#pragma warning disable BL0005
        Wkt = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "wkt");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Wkt)] = Wkt;
        return Wkt;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Wkt2 property.
    /// </summary>
    public async Task<string?> GetWkt2()
    {
        if (CoreJsModule is null)
        {
            return Wkt2;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Wkt2;
        }

        // get the property value
#pragma warning disable BL0005
        Wkt2 = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "wkt2");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Wkt2)] = Wkt2;
        return Wkt2;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the ImageCoordinateSystem property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetImageCoordinateSystem(string value)
    {
#pragma warning disable BL0005
        ImageCoordinateSystem = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ImageCoordinateSystem)] = value;
        
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
            JsComponentReference, "imageCoordinateSystem", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Wkid property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetWkid(int value)
    {
#pragma warning disable BL0005
        Wkid = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Wkid)] = value;
        
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
            JsComponentReference, "wkid", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Wkt property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetWkt(string value)
    {
#pragma warning disable BL0005
        Wkt = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Wkt)] = value;
        
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
            JsComponentReference, "wkt", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Wkt2 property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetWkt2(string value)
    {
#pragma warning disable BL0005
        Wkt2 = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Wkt2)] = value;
        
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
            JsComponentReference, "wkt2", value);
    }
    
#endregion




    /// <inheritdoc />
    internal override void ValidateRequiredGeneratedChildren()
    {
    
        if (Wkid is null && Wkt is null && Wkt2 is null)
        {
            throw new MissingRequiredOptionsChildElementException(nameof(SpatialReference), [nameof(Wkid), nameof(Wkt), nameof(Wkt2)]);
        }
        base.ValidateRequiredGeneratedChildren();
    }
      
}
