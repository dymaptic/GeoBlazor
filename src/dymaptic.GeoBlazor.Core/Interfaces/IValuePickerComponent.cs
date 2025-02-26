namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface for components in a ValuePickerWidget.
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IValuePickerComponent>))]
public interface IValuePickerComponent
{
}