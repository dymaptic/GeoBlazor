namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Only applicable when working in a SceneView. Defines the axis the size visual variable should be applied to when rendering features with an ObjectSymbol3DLayer. See the local scene sample for an example of this.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<VisualAxis>))]
public enum VisualAxis
{
#pragma warning disable CS1591
    Width,
    Depth,
    Height,
    WidthAndDepth,
    All
#pragma warning restore CS1591
}