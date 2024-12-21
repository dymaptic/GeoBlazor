namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The possible fill style for the <see cref="SimpleFillSymbol" />
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<FillStyle>))]
public enum FillStyle
{
#pragma warning disable CS1591
    BackwardDiagonal,
    Cross,
    DiagonalCross,
    ForwardDiagonal,
    Horizontal,
    None,
    Solid,
    Vertical
#pragma warning restore CS1591
}