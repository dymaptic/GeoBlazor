namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     A collection of renderer types
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<RendererType>))]
public enum RendererType
{
#pragma warning disable CS1591
    Simple,
    UniqueValue,
    [LookupType("dymaptic.GeoBlazor.Pro.Components.Renderers.PieChartRenderer")]
    PieChart,
    ClassBreaks,
    Dictionary,
    DotDensity,
    Heatmap
#pragma warning restore CS1591
}

/// <summary>
///    Attribute to lookup the type name for a RendererType
/// </summary>
public class LookupTypeAttribute : Attribute
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public LookupTypeAttribute(string typeName)
    {
        TypeName = typeName;
    }

    /// <summary>
    ///     The type name
    /// </summary>
    public string TypeName { get; set; }
}