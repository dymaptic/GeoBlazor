namespace dymaptic.GeoBlazor.Core.Components;

public partial class Label : MapComponent
{


    /// <summary>
    ///     Defines how labels should be placed relative to one another. By default, labels have a static deconfliction strategy, meaning labels that overlap are dropped to make them easier to read.
    ///     In some cases where few labels overlap, it may be preferable to turn off label deconfliction with the none option. It is also advisable to turn off deconfliction when labeling clusters with a count of features in the center of the cluster.
    /// </summary>
    /// <remarks>
    ///     Currently, this property only applies to FeatureLayer, CSVLayer, and StreamLayer in 2D MapViews.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DeconflictionStrategy? DeconflictionStrategy { get; set; }

    /// <summary>
    ///     The position of the label.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LabelPlacement? LabelPlacement { get; set; }

    /// <summary>
    ///     Defines the labels for a MapImageLayer.
    /// </summary>
    /// <remarks>
    ///     MapImageLayer not yet implemented in GeoBlazor
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LabelExpression { get; set; }

    /// <summary>
    ///     Specifies the orientation of the label position of a polyline label. If "curved", this means the characters follow the curve of the polyline, while "parallel" means the characters will always be straight, and the orientation will be based on the angle of the polyline's curve at the label's position.
    ///     Default Value: curved
    /// </summary>
    /// <remarks>
    ///     Currently, this property only applies to Polyline FeatureLayer and CSVLayer in 2D MapViews.
    ///     Currently, this property cannot be saved as part of a WebMap.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LabelPosition? LabelPosition { get; set; }

    /// <summary>
    ///     The maximum scale (most zoomed in) at which labels are visible in the view. A value of 0 means the label's visibility does not have a maximum scale. The maxScale value should always be smaller than the minScale value, and greater than or equal to the service specification.
    ///     Default Value:0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxScale { get; set; }

    /// <summary>
    ///     The minimum scale (most zoomed out) at which labels are visible in the view. A value of 0 means the label's visibility does not have a minimum scale. The minScale value should always be larger than the maxScale value, and less than or equal to the service specification.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinScale { get; set; }

    /// <summary>
    ///     Indicates whether or not to repeat the label along the polyline feature. If true, the label will be repeated according to the repeatLabelDistance. If false, the label will display once per polyline segment.
    /// </summary>
    /// <remarks>
    ///     Currently, this property only applies to Polyline FeatureLayer and CSVLayer in 2D MapViews.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? RepeatLabel { get; set; }

    /// <summary>
    ///     The size in points of the distance between labels on a polyline. This value may be autocast with a string expressing size in points or pixels (e.g. 100, or "64pt", or "128px"). The repeatLabel property must be true for this property to be honored.
    /// </summary>
    /// <remarks>
    ///     Currently, this property only applies to Polyline FeatureLayer and CSVLayer in 2D MapViews.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? RepeatLabelDistance { get; set; }

    /// <summary>
    ///     Indicates whether to use domain names if the fields in the labelExpression or labelExpressionInfo have domains.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseCodedValues { get; set; }

    /// <summary>
    ///     A SQL where clause used to determine the features to which the label class should be applied. When specified, only features evaluating to true based on this expression will be labeled.
    ///     Default Value:null
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Where { get; set; }


    /// <summary>
    ///     Gets the current <see cref = "Symbol"/> for the object.
    /// </summary>
    public virtual async Task<Symbol?> GetSymbol()
    {
        return await Task.Run(() => Symbol);
    }

    /// <summary>
    ///     Sets the <see cref = "Symbol"/> for the object.
    /// </summary>
    /// <param name="symbol">
    ///     The <see cref = "Symbol"/> for the object.
    /// </param>
    public virtual async Task SetSymbol(Symbol symbol)
    {
        Symbol = symbol;
        if (CoreJsModule is not null)
        {
            await CoreJsModule.InvokeVoidAsync("setGraphicSymbol", Id, Symbol.ToSerializationRecord());
        }
        else
        {
            _updateSymbol = true;
        }
    }


    /// <inheritdoc/>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (CoreJsModule is not null)
        {
            if (_updateSymbol)
            {
                _updateSymbol = false;
                await SetSymbol(Symbol!);
            }
        }
    }


    private bool _updateSymbol;
}