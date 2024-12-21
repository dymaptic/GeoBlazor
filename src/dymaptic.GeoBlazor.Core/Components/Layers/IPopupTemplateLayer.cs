namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Interface for identifying Layer types that support <see cref="PopupTemplate"/>s.
/// </summary>
public interface IPopupTemplateLayer
{
    /// <summary>
    ///     The <see cref="PopupTemplate" /> for the layer.
    /// </summary>
    PopupTemplate? PopupTemplate { get; set; }
}