namespace dymaptic.GeoBlazor.Pro.Model;

/// <summary>
///     Represents style properties for GeoJSON features, supporting common SVG and CSS styling attributes.
///     Based on <a target="_blank" href="https://github.com/mapbox/simplestyle-spec/tree/master/1.1.0">Mapbox SimpleStyle Spec</a>
/// </summary>
/// <remarks>
///     COLOR RULES:
///     Colors can be in short form: "#ace", or long form: "#aaccee", with or without the # prefix.
///     Colors are interpreted the same as in CSS, in #RRGGBB and #RGB order, but other color formats or named colors are not supported.
/// </remarks>
public record GeoJSONStyle
{
    /// <summary>
    ///     A title to show when this item is clicked or hovered over
    /// </summary>
    [JsonPropertyName(TitleKebabCase)]
    public string? Title { get; init; }
    
    /// <summary>
    ///     A description to show when this item is clicked or hovered over
    /// </summary>
    [JsonPropertyName(DescriptionKebabCase)]
    public string? Description { get; init; }
    
    /// <summary>
    ///     Specify the size of the marker. sizes can be different pixel sizes in different implementations.
    ///     Value can be one of "small" (8pt), "medium" (12pt), "large" (16pt), or a pixel or point value (e.g., "4px", "2pt").
    ///     Plain numbers are interpreted as points.
    ///     Default "12pt".
    /// </summary>
    [JsonPropertyName(MarkerSizeKebabCase)]
    public string? MarkerSize { get; init; }
    
    /// <summary>
    ///     A symbol to position in the center of this icon if not provided or "", no symbol is overlaid and only the marker is shown.
    ///     Allowed values include
    ///      - Icon ID
    ///      - An integer 0 through 9
    ///      - A lowercase character "a" through "z"
    /// </summary>
    [JsonPropertyName(MarkerSymbolKebabCase)]
    public string? MarkerSymbol { get; init; }

    /// <summary>
    ///     The marker's color. Default value "#7e7e7e".
    ///     Value must follow the Color Rules defined in the remarks section of this class.
    /// </summary>
    [JsonPropertyName(MarkerColorKebabCase)]
    public string? MarkerColor { get; init; }
    
    /// <summary>
    ///     The color of a line as part of a polygon, polyline, or multigeometry. Default value "#555555".
    ///     Value must follow the Color Rules defined in the remarks section of this class.
    /// </summary>
    [JsonPropertyName(StrokeKebabCase)]
    public string? Stroke { get; init; }

    /// <summary>
    ///     The opacity of the line component of a polygon, polyline, or multigeometry. Default value 1.0.
    ///     Value must be a floating point number greater than or equal to zero and less or equal to than one.
    /// </summary>
    [JsonPropertyName(StrokeOpacityKebabCase)]
    public double? StrokeOpacity { get; init; }

    /// <summary>
    ///     The width of the line component of a polygon, polyline, or multigeometry. Default value 0.75(pt).
    ///     value must be a floating point number greater than or equal to 0.
    /// </summary>
    [JsonPropertyName(StrokeWidthKebabCase)]
    public double? StrokeWidth { get; init; }
    
    /// <summary>
    ///     The shape to be used at the end of open subpaths when they are stroked (e.g., "butt", "round", "square").
    /// </summary>
    [JsonPropertyName(StrokeLinecapKebabCase)]
    public string? StrokeLinecap { get; init; }

    /// <summary>
    ///     The shape to be used at the corners of paths or basic shapes when they are stroked (e.g., "miter", "round", "bevel").
    /// </summary>
    [JsonPropertyName(StrokeLinejoinKebabCase)]
    public string? StrokeLinejoin { get; init; }

    /// <summary>
    ///     A list of comma and/or white space separated numbers that specify the pattern of dashes and gaps to use for the stroke.
    ///     Supported values include:
    ///     - 4 ("Dash")
    ///     - 4,3,1,3 ("Dash Dot")
    ///     - 1,2 ("Dot")
    ///     - 8,3 ("Long Dash")
    ///     - 8,3,1,3 ("Long Dash Dot")
    ///     - 8,3,1,3,1,3 ("Long Dash Dot Dot")
    ///     - 4,1 ("Short Dash")
    ///     - 4,1,1,1 ("Short Dash Dot")
    ///     - 4,1,1,1,1,1 ("Short Dash Dot Dot")
    ///     - 1 ("Short Dot")
    /// </summary>
    [JsonPropertyName(StrokeDasharrayKebabCase)]
    public string? StrokeDasharray { get; init; }

    /// <summary>
    ///     The color of the interior of a polygon. Default value "#555555".
    ///     Some schemas may also apply this to the center of a marker/point.
    ///     Value must follow the Color Rules defined in the remarks section of this class.
    /// </summary>
    [JsonPropertyName(FillKebabCase)]
    public string? Fill { get; init; }

    /// <summary>
    ///     The opacity of the interior of a polygon. Default value 0.6.
    ///     Value must be a floating point number greater than or equal to zero and less or equal to than one.
    /// </summary>
    [JsonPropertyName(FillOpacityKebabCase)]
    public double? FillOpacity { get; init; }

    /// <summary>
    ///     The text label to display on the feature.
    /// </summary>
    [JsonPropertyName(TextKebabCase)]
    public string? Text { get; init; }

    /// <summary>
    ///     The font size for the text label (e.g., "12px", "1em").
    /// </summary>
    [JsonPropertyName(FontSizeKebabCase)]
    public string? FontSize { get; init; }

    /// <summary>
    ///     The font weight for the text label (e.g., "normal", "bold", "700").
    /// </summary>
    [JsonPropertyName(FontWeightKebabCase)]
    public string? FontWeight { get; init; }

    /// <summary>
    ///     The font style for the text label (e.g., "normal", "italic", "oblique").
    /// </summary>
    [JsonPropertyName(FontStyleKebabCase)]
    public string? FontStyle { get; init; }

    /// <summary>
    ///     Don't add these properties to GeoBlazor graphic attributes.
    /// </summary>
    public static string[] StyleProperties =
    [
        MarkerSizeKebabCase,
        MarkerSymbolKebabCase,
        MarkerColorKebabCase,
        StrokeKebabCase,
        StrokeOpacityKebabCase,
        StrokeWidthKebabCase,
        StrokeLinecapKebabCase,
        StrokeLinejoinKebabCase,
        StrokeDasharrayKebabCase,
        FillKebabCase,
        FillOpacityKebabCase,
        TextKebabCase,
        FontSizeKebabCase,
        FontWeightKebabCase,
        FontStyleKebabCase
    ];
    
    private const string TitleKebabCase = "title";
    private const string DescriptionKebabCase = "description";
    private const string MarkerSizeKebabCase = "marker-size";
    private const string MarkerSymbolKebabCase = "marker-symbol";
    private const string MarkerColorKebabCase = "marker-color";
    private const string StrokeKebabCase = "stroke";
    private const string StrokeOpacityKebabCase = "stroke-opacity";
    private const string StrokeWidthKebabCase = "stroke-width";
    private const string StrokeLinecapKebabCase = "stroke-linecap";
    private const string StrokeLinejoinKebabCase = "stroke-linejoin";
    private const string StrokeDasharrayKebabCase = "stroke-dasharray";
    private const string FillKebabCase = "fill";
    private const string FillOpacityKebabCase = "fill-opacity";
    private const string TextKebabCase = "text";
    private const string FontSizeKebabCase = "font-size";
    private const string FontWeightKebabCase = "font-weight";
    private const string FontStyleKebabCase = "font-style";
}