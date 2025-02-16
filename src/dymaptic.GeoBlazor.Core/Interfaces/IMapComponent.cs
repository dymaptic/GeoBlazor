namespace dymaptic.GeoBlazor.Core.Interfaces;

public interface IMapComponent
{
    Guid Id { get; internal set; }

    void ValidateRequiredGeneratedChildren();
}