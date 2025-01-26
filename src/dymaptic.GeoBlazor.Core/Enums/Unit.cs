namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Combined list of units Length, Area, Volume, and Angle.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<Unit>))]
[CodeGenerationIgnore]
public enum Unit
{
#pragma warning disable CS1591
    Millimeters,
    Centimeters,
    Decimeters,
    Meters,
    Kilometers,
    Inches,
    Feet,
    Yards,
    Miles,
    NauticalMiles,
    UsFeet,
    SquareMillimeters,
    SquareCentimeters,
    SquareDecimeters,
    SquareMeters,
    SquareKilometers,
    SquareInches,
    SquareFeet,
    SquareYards,
    SquareMiles,
    SquareUsFeet,
    Acres,
    Ares,
    Hectares,
    Liters,
    CubicMillimeters,
    CubicCentimeters,
    CubicDecimeters,
    CubicMeters,
    CubicKilometers,
    CubicInches,
    CubicFeet,
    CubicYards,
    CubicMiles,
    Degrees,
    Radians
#pragma warning restore CS1591
}