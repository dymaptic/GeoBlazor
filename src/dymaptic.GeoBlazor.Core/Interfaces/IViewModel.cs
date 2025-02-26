namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Convenience interface for managing view models for layers and widgets.
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IViewModel>))]
public interface IViewModel
{
    
}