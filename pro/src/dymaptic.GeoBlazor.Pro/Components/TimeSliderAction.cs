namespace dymaptic.GeoBlazor.Pro.Components;

/// <summary>
///     Definition of an action that can be assigned to the actions property on the TimeSlider or the TimeSliderViewModel. It is displayed in a menu when the user clicks the ellipsis button timeSlider-actions-menu on the TimeSlider widget.
/// </summary>
[CodeGenerationIgnore]
public class TimeSliderAction: MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Blazor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public TimeSliderAction()
    {
    }

    /// <summary>
    ///     Parameterized constructor for use in C# code.
    /// </summary>
    /// <param name="icon">
    ///     The name of the icon to display. The value of this property must match the icon name from <a target="_blank" href="https://developers.arcgis.com/calcite-design-system/icons/">Calcite UI Icons</a>.
    /// </param>
    /// <param name="actionId">
    ///     Unique identifier of the action.
    /// </param>
    /// <param name="title">
    ///     The title of the action that will be displayed in the menu.
    /// </param>
    /// <param name="callbackFunction">
    ///     A function that will be called when the action icon is clicked.
    /// </param>
    public TimeSliderAction(string icon, string actionId, string? title, Func<Task>? callbackFunction = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Icon = icon;
        ActionId = actionId;
        Title = title;
        CallbackFunction = callbackFunction;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     The name of the icon to display. The value of this property must match the icon name from <a target="_blank" href="https://developers.arcgis.com/calcite-design-system/icons/">Calcite UI Icons</a>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public string? Icon { get; set; }
    
    /// <summary>
    ///     Unique identifier of the action.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public string? ActionId { get; set; }
    
    /// <summary>
    ///     The title of the action that will be displayed in the menu.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public string? Title { get; set; }
    
    /// <summary>
    ///     The action function to perform on click.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public Func<Task>? CallbackFunction { get; set; }
    
    /// <summary>
    ///     Identifies whether the action has a callback function.
    /// </summary>
    public bool HasCallbackFunction => CallbackFunction != null;
}