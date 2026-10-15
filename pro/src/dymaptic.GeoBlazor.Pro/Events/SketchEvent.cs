namespace dymaptic.GeoBlazor.Pro.Events;

/// <summary>
///     The SketchEvent class is used to represent the event object passed to the event handlers for the <see cref="SketchWidget"/>.
/// </summary>
public record SketchEvent
{
    /// <summary>
    ///     The current state of the event.
    /// </summary>
    public SketchEventState? State { get; set; }
    
    /// <summary>
    ///     The graphic that is being created or updated.
    /// </summary>
    public Graphic[] Graphics { get; set; } = [];
    
    /// <summary>
    ///     Returns additional information associated with the operation such as where the user is clicking the view or where the user is moving the cursor to. Value of this parameter changes to null when the event's state changes to complete or cancel.
    /// </summary>
    public ToolEventInfo? ToolEventInfo { get; set; }
    
    /// <summary>
    ///     Name of the current tool.
    /// </summary>
    public SketchEventTool? Tool { get; set; }

    /// <summary>
    ///     The type of event.
    /// </summary>
    [JsonPropertyName("type")]
    public SketchEventType? EventType { get; set; }
}