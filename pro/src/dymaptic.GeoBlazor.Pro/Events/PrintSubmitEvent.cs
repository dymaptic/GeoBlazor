namespace dymaptic.GeoBlazor.Pro.Events;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Events.PrintSubmitEvent.html">GeoBlazor Docs</a>
///     Event result type for the PrintWidget.OnSubmit event.
/// </summary>
/// <param name="Link">
///     Represents an exported map request from the result of the Print widget.
/// </param>
/// <param name="SaveExportEnabled">
///     Boolean indicating whether the Save Export button is enabled.
/// </param>
[CodeGenerationIgnore]
public record PrintSubmitEvent(FileLink? Link, bool SaveExportEnabled)
{
   // Add custom code to this file to override generated code
}