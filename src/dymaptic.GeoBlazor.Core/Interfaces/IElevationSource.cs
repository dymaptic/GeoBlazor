namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface for elevation sources.
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IElevationSource>))]
public class IElevationSource
{
    
}