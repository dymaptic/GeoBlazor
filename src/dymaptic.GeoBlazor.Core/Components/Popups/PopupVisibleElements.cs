namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     The visible elements that are displayed within the widget. This provides the ability to turn individual elements of
///     the widget's display on/off.
/// </summary>
public class PopupVisibleElements : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public PopupVisibleElements()
    {
    }

    /// <summary>
    ///     Constructor for creating a PopupVisibleElements object in code.
    /// </summary>
    public PopupVisibleElements(bool? closeButton = null, bool? featureNavigation = null)
    {
#pragma warning disable BL0005
        CloseButton = closeButton;
        FeatureNavigation = featureNavigation;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     Indicates whether to display a close button on the popup dialog. Default value is true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CloseButton { get; set; }

    /// <summary>
    ///     Indicates whether pagination for feature navigation will be displayed. Default value is true. This allows the user
    ///     to scroll through various selected features using pagination arrows.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? FeatureNavigation { get; set; }
}

