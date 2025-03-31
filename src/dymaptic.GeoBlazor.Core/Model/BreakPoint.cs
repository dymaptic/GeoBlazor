namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Defines the dimensions of the View at which to dock the popup. Set to false to disable docking at a breakpoint.
///     DefaultValue: true
/// </summary>
[JsonConverter(typeof(BreakPointConverter))]
public record BreakPoint
{
    /// <summary>
    ///     Constructor for building a breakpoint with specified max width and/or height.
    /// </summary>
    /// <param name="width">
    ///     The maximum width of the View at which the popup will be set to dockEnabled automatically.
    ///     DefaultValue: 544
    /// </param>
    /// <param name="height">
    ///     The maximum height of the View at which the popup will be set to dockEnabled automatically.
    ///     DefaultValue: 544
    /// </param>
    public BreakPoint(double? width = null, double? height = null)
    {
        Width = width;
        Height = height;
    }

    /// <summary>
    ///     Constructor for building a breakpoint with default max width and height.
    /// </summary>
    /// <param name="value">
    ///     Determines if the breakpoint is on or off.
    /// </param>
    public BreakPoint(bool value)
    {
        BoolValue = value;
    }

    /// <summary>
    ///     Determines if the breakpoint is on or off.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BoolValue { get; set; }

    /// <summary>
    ///     The maximum width of the View at which the popup will be set to dockEnabled automatically.
    ///     DefaultValue: 544
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Width { get; set; }

    /// <summary>
    ///     The maximum height of the View at which the popup will be set to dockEnabled automatically.
    ///     DefaultValue: 544
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Height { get; set; }
}