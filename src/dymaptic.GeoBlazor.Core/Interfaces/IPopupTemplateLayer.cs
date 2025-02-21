namespace dymaptic.GeoBlazor.Core.Interfaces;

public partial interface IPopupTemplateLayer
{
    /// <summary>
    ///     The <see cref="PopupTemplate" /> for the layer.
    /// </summary>
    PopupTemplate? PopupTemplate { get; set; }
}