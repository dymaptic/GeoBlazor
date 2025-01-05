namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Event arguments for the <see cref = "SliderWidget.OnTickClick"/> event.
/// </summary>
/// <param name = "Value">
///     The approximate value that the tick represents on the slider track.
/// </param>
/// <param name = "ConfigIndex">
///     The 0-based index of the associated configuration provided in tickConfigs.
/// </param>
/// <param name = "GroupIndex">
///     The 0-based index of the tick and/or group (associated label) relative to other ticks in the same configuration.
/// </param>
public record SliderTickClickEvent(double Value, int ConfigIndex, int GroupIndex);
