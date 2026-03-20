namespace dymaptic.GeoBlazor.Core.Components;

public partial class LegendStyle : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public LegendStyle()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="type">
    ///     The Legend style type.
    /// </param>
    /// <param name="layout">
    ///     When a `card` type is specified, you can specify one of the following layout options.
    ///     default stack
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public LegendStyle(LegendStyleType? type = null,
        LegendStyleLayout? layout = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Type = type;
        Layout = layout;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     Implicit conversion between a <see cref="LegendStyleType"/> and a <see cref="LegendStyle"/>.
    /// </summary>
    /// <param name="type"></param>
    public static implicit operator LegendStyle(LegendStyleType type) => new LegendStyle(type: type);

    /// <summary>
    /// The Legend style type.
    /// </summary>
    [Parameter]
    public LegendStyleType? Type { get; set; }

    /// <summary>
    /// The legend style layout when there are multiple legends
    /// </summary>
    [Parameter]
    public LegendStyleLayout? Layout { get; set; }
}