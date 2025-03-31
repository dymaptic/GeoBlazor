namespace dymaptic.GeoBlazor.Core.Components.Symbols;

[JsonConverter(typeof(MarkerSymbolJsonConverter))]
public abstract partial class MarkerSymbol : Symbol
{
    /// <summary>
    ///     The angle of the marker relative to the screen in degrees.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Angle { get; set; }

    /// <summary>
    ///     The offset on the x-axis in points. This value may be autocast with a string expressing size in points or pixels (e.g. 12px).
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Xoffset { get; set; }

    /// <summary>
    ///     The offset on the y-axis in points. This value may be autocast with a string expressing size in points or pixels (e.g. 12px).
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Yoffset { get; set; }
}