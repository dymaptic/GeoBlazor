namespace dymaptic.GeoBlazor.Core.Interfaces;

[JsonConverter(typeof(MultiTypeConverter<IMapComponent>))]
public interface IMapComponent
{
    Guid Id { get; internal set; }

    void ValidateRequiredChildren();
    void ValidateRequiredGeneratedChildren();
}