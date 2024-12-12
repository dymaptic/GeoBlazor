using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Enums;
using dymaptic.GeoBlazor.Core.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     This class may be extended to create a custom TileLayer. Tile layers are composed of images, such as satellite imagery, that are composed of square tiles mosaicked together in columns and rows, giving the layer the appearance that it is one continuous image. These layers have several levels of detail (LOD) that permit users to zoom in to any region of the map and load additional tiles that depict features in higher resolution at larger map scales.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-BaseTileLayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class BaseTileLayer : Layer
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public BaseTileLayer()
    {
    }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="blendMode">
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer. Unlike the method of using transparency which can result in a washed-out top layer, blend modes can create a variety of very vibrant and intriguing results by blending a layer with the layer(s) below it.
    /// </param>
    /// <param name="effect">
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work. This powerful capability allows you to apply css filter-like functions to layers to create custom visual effects to enhance the cartographic quality of your maps. This is done by applying the desired effect to the layer's effect property as a string or an array of objects to set scale dependent effects.
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view. If the map is zoomed in beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a maximum scale. The maxScale value should always be smaller than the minScale value, and greater than or equal to the service specification.
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and less than or equal to the service specification.
    /// </param>
    /// <param name="refreshInterval">
    ///     Refresh interval of the layer in minutes. Value of 0 indicates no refresh.
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference of the layer.
    /// </param>
    public BaseTileLayer(BlendMode? blendMode = null, Effect? effect = null, int? maxScale = null,
        int? minScale = null, double? refreshInterval = null, SpatialReference? spatialReference = null)
    {
#pragma warning disable BL0005
        BlendMode = blendMode;
        Effect = effect;
        MaxScale = maxScale;
        MinScale = minScale;
        RefreshInterval = refreshInterval;
        SpatialReference = spatialReference;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer. Unlike the method of using transparency which can result in a washed-out top layer, blend modes can create a variety of very vibrant and intriguing results by blending a layer with the layer(s) below it.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BlendMode? BlendMode { get; set; }
    
    /// <summary>
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work. This powerful capability allows you to apply css filter-like functions to layers to create custom visual effects to enhance the cartographic quality of your maps. This is done by applying the desired effect to the layer's effect property as a string or an array of objects to set scale dependent effects.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Effect? Effect { get; set; }
    
    /// <summary>
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view. If the map is zoomed in beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a maximum scale. The maxScale value should always be smaller than the minScale value, and greater than or equal to the service specification.
    ///     Default Value: 0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxScale { get; set; }
    
    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and less than or equal to the service specification.
    ///     Default Value: 0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MinScale { get; set; }
    
    /// <summary>
    ///     Refresh interval of the layer in minutes. Value of 0 indicates no refresh.
    ///     Default Value:0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? RefreshInterval { get; set; }

    /// <inheritdoc />
    public override string LayerType => "base-tile";

    /// <summary>
    ///     The spatial reference of the layer.
    ///     Default Value:SpatialReference.WebMercator
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }
    
    /// <summary>
    ///     Returns the bounds of the tile as an array of four numbers that be readily converted to an Extent object.
    /// </summary>
    /// <param name="level">
    ///     The level of detail (LOD) of the tile.
    /// </param>
    /// <param name="row">
    ///     The tile's row (y) position in the dataset.
    /// </param>
    /// <param name="col">
    ///     The tile's column (x) position in the dataset.
    /// </param>
    /// <returns>
    ///     Returns an array with the following structure: [xmin, ymin, xmax, ymax]
    /// </returns>
    public async Task<double[]> GetTileBounds(int level, int row, int col)
    {
        return await JsComponentReference!.InvokeAsync<double[]>("getTileBounds", level, row, col);
    }

    /// <summary>
    ///     Returns the bounds of the tile as an Extent object.
    /// </summary>
    /// <param name="level">
    ///     The level of detail (LOD) of the tile.
    /// </param>
    /// <param name="row">
    ///     The tile's row (y) position in the dataset.
    /// </param>
    /// <param name="col">
    ///     The tile's column (x) position in the dataset.
    /// </param>
    public async Task<Extent> GetTileBoundsAsExtent(int level, int row, int col)
    {
        double[] bounds = await GetTileBounds(level, row, col);
        return new Extent(bounds[2], bounds[0], bounds[3], bounds[1]);
    }

    /// <summary>
    ///     Retrieves the tiling scheme information for the layer.
    /// </summary>
    public async Task<TileInfo?> GetTileInfo()
    {
        return await JsComponentReference!.InvokeAsync<TileInfo?>("getTileInfo");
    }
    
    /// <summary>
    ///     Changes the current effect on the layer.
    /// </summary>
    /// <param name="effect">
    ///     The effect to apply to the layer.
    /// </param>
    public async Task SetEffect(Effect effect)
    {
        await JsComponentReference!.InvokeVoidAsync("setEffect", effect);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SpatialReference spatialReference:
                if (!spatialReference.Equals(SpatialReference))
                {
                    SpatialReference = spatialReference;
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SpatialReference _:
                SpatialReference = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        SpatialReference?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}