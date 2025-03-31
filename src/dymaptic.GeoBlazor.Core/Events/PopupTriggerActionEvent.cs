namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     The event that is triggered when an action is executed.
/// </summary>
/// <param name="Action">
///     The action that was executed.
/// </param>
[CodeGenerationIgnore]
public record PopupTriggerActionEvent(ActionBase Action);