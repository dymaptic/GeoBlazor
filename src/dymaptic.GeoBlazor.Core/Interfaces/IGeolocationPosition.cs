namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface for GeolocationPosition
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IGeolocationPosition>))]
public interface IGeolocationPosition
{
    /// <summary>
    ///     The coordinates of the position.
    /// </summary>
    IGeolocationCoordinates Coords { get; }

    /// <summary>
    ///     The timestamp of when the coordinates were read.
    /// </summary>
    long Timestamp { get; }
}