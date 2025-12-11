namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class BaseTileLayer : Layer, ITileLayer
{

    
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
    public double? MaxScale { get; set; }
    
    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and less than or equal to the service specification.
    ///     Default Value: 0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinScale { get; set; }
    
    /// <summary>
    ///     Refresh interval of the layer in minutes. Value of 0 indicates no refresh.
    ///     Default Value:0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? RefreshInterval { get; set; }

    /// <inheritdoc />
    public override LayerType Type => LayerType.BaseTile;

    
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
    [CodeGenerationIgnore]
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
    public async Task SetEffect(Effect? effect)
    {
        await JsComponentReference!.InvokeVoidAsync("setEffect", effect);
    }

}