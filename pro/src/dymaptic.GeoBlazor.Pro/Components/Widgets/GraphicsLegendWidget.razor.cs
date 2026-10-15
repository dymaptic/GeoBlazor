namespace dymaptic.GeoBlazor.Pro.Components.Widgets;

/// <summary>
///     A custom widget that displays a legend for the graphics in the View and Graphics Layers.
/// </summary>
public partial class GraphicsLegendWidget : ProWidget
{
    /// <summary>
    ///     The top-level label for the legend.
    /// </summary>
    [Parameter]
    public override string? Label { get; set; } = "Graphics";

    /// <summary>
    ///     The template for the label for each graphic or group.
    ///     The template is a string with placeholders for the graphic's attributes in the form of {attributeName}.
    ///     You can override this per graphic or group by setting the <see cref="Graphic.LegendLabel" /> property.
    /// </summary>
    [Parameter]
    [EditorRequired]
    public required string GraphicLabelTemplate { get; set; }

    /// <summary>
    ///     When true, field values in the <see cref="GraphicLabelTemplate"/> are either added together (for numeric values) or concatenated (for string values) for each group of graphics.
    /// </summary>
    [Parameter]
    public bool ConcatenateLabelsByTemplate { get; set; } = true;

    /// <summary>
    ///     Determines whether to group and show only a single entry for all graphics with the same symbol and color.
    /// </summary>
    [Parameter]
    public bool GroupBySymbol { get; set; }

    /// <summary>
    ///     Sets whether you can select and open a graphic popup via the legend.
    /// </summary>
    [Parameter]
    public bool SelectGraphics { get; set; }

    /// <summary>
    ///     Sets whether the legend can control the visibility of the graphics.
    /// </summary>
    [Parameter]
    public bool ToggleGraphics { get; set; }

    /// <summary>
    ///     Passes css styles to the underlying HTML components.
    /// </summary>
    [Parameter]
    public string? Style { get; set; }

    /// <summary>
    ///     Passes css classes to the underlying HTML components.
    /// </summary>
    [Parameter]
    public string? Class { get; set; }

    /// <inheritdoc />
    public override WidgetType Type => WidgetType.GraphicsLegend;

    private List<LayerRecord> GetLayerRecords => (View?.Graphics.Any() ?? false
            ? new List<LayerRecord> { new("Graphics", GroupBySymbolAndColor(View?.Graphics), View?.Id) }
            : new List<LayerRecord>())
        .Concat(View?.Map?.Layers.OfType<GraphicsLayer>()
                .Where(l => l.Graphics.Any())
                .Select(layer =>
                    new LayerRecord(layer.Title ?? string.Empty, 
                        GroupBySymbolAndColor(layer.Graphics), layer.Id)) ??
            Array.Empty<LayerRecord>())
        .ToList();

    private string CalculatedPosition => Position switch
    {
        OverlayPosition.BottomLeft => "esri-ui-bottom-left esri-ui-corner",
        OverlayPosition.BottomRight => "esri-ui-bottom-right esri-ui-corner",
        OverlayPosition.TopLeft => "esri-ui-top-left esri-ui-corner",
        OverlayPosition.TopRight => "esri-ui-top-right esri-ui-corner",
        OverlayPosition.Manual => "",
        _ => ""
    };

    private bool IsInMapView => Parent is MapView;

    /// <inheritdoc />
    protected internal override bool GeoBlazorWidget => true;
    

    private string BuildGraphicLabel(Graphic[] graphics)
    {
        string template = graphics.First().LegendLabel ?? GraphicLabelTemplate;

        return _regex.Replace(template, match =>
        {
            string attributeName = match.Groups[1].Value;

            if (graphics.Length == 1 || !ConcatenateLabelsByTemplate)
            {
                return graphics.First().Attributes[attributeName]?.ToString() ?? string.Empty;
            }

            object? attrValue = graphics.First().Attributes[attributeName];

            if (attrValue is double)
            {
                return graphics.Select(g => g.Attributes[attributeName])
                    .Cast<double>()
                    .Sum()
                    .ToString(CultureInfo.InvariantCulture);
            }

            if (attrValue is int)
            {
                return graphics.Select(g => g.Attributes[attributeName])
                    .Cast<int>()
                    .Sum()
                    .ToString(CultureInfo.InvariantCulture);
            }
            
            

            return string.Join(", ", graphics.Select(g => g.Attributes[attributeName]?.ToString()).Distinct());
        });
    }

    private string BuildGraphicColor(Graphic graphic)
    {
        if (graphic.Symbol?.Color is { } color)
        {
            return color.ToCss() ?? color.HexOrNameValue!;
        }

        return "black";
    }

    private List<Graphic[]> GroupBySymbolAndColor(IEnumerable<Graphic>? graphics)
    {
        if (graphics is null) return new List<Graphic[]>();
        if (!GroupBySymbol) return graphics.Select(g => new[] { g }).ToList();

        return graphics.GroupBy(g =>
                new
                {
                    GeometryType = g.Geometry?.Type,
                    SymbolType = g.Symbol?.Type,
                    g.Symbol?.Color,
                    PictureUrl = g.Symbol is PictureMarkerSymbol pictureMarkerSymbol
                        ? pictureMarkerSymbol.Url
                        : null
                })
            .Select(g => g.ToArray())
            .ToList();
    }

    private async Task OpenGraphicsPopup(IEnumerable<Graphic> graphics)
    {
        if (!SelectGraphics) return;

        PopupOpenOptions options = new() { Features = graphics.ToArray(), UpdateLocationEnabled = true };
        await View!.ClosePopup();
        await View.OpenPopup(options);
    }

    private async Task ToggleGraphicsVisibility(Graphic[] graphics)
    {
        bool currentState = graphics.First().Visible ?? true;

        foreach (Graphic graphic in graphics)
        {
            await graphic.SetVisibility(!currentState);
        }
    }

    private void ToggleLayer(LayerRecord layer)
    {
        if (layer.LayerId is null) return;

        if (_collapsedLayerIds.Contains(layer.LayerId.Value))
        {
            _collapsedLayerIds.Remove(layer.LayerId.Value);
        }
        else
        {
            _collapsedLayerIds.Add(layer.LayerId!.Value);
        }
    }

    private readonly Regex _regex = new("{(.*?)}");
    private List<Guid> _collapsedLayerIds = new();

    private record LayerRecord(string Title, IEnumerable<Graphic[]> Graphics, Guid? LayerId);
}