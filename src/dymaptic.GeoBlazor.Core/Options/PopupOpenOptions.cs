namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     Defines the location and content of the popup when opened with <see cref="MapView.OpenPopup" />
/// </summary>
public record PopupOpenOptions
{
    /// <summary>
    ///     Sets the title of the popup.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    ///     Sets the content of the popup to a raw or html string.
    /// </summary>
    public string? StringContent { get; set; }

    /// <summary>
    ///     Sets the content of the popup to a <see cref="Widget" />.
    /// </summary>
    public Widget? WidgetContent { get; set; }

    /// <summary>
    ///     Sets the popup's location, which is the geometry used to position the popup.
    /// </summary>
    public Geometry? Location { get; set; }

    /// <summary>
    ///     When true, indicates the popup should fetch the content of this feature and display it. If no PopupTemplate exists,
    ///     a default template is created for the layer if defaultPopupTemplateEnabled = true. In order for this option to
    ///     work, there must be a valid view and location set.
    /// </summary>
    public bool? FetchFeatures { get; set; }

    /// <summary>
    ///     Sets the popup's features, which populate the title and content of the popup based on each graphic's PopupTemplate.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<Graphic>? Features { get; set; }

    /// <summary>
    ///     This property enables multiple features in a popup to display in a list rather than displaying the first selected
    ///     feature. Setting this to true allows the user to scroll through the list of features returned from the query and
    ///     choose the selection they want to display within the popup.
    /// </summary>
    public bool? FeatureMenuOpen { get; set; }

    /// <summary>
    ///     When true indicates the popup should update its location for each paginated feature based on the selected feature's
    ///     geometry.
    /// </summary>
    public bool? UpdateLocationEnabled { get; set; }

    /// <summary>
    ///     When true, indicates that only the popup header will display.
    /// </summary>
    public bool? Collapsed { get; set; }

    /// <summary>
    ///     When true, indicates that the focus should be on the popup after it has been opened.
    /// </summary>
    public bool? ShouldFocus { get; set; }
}