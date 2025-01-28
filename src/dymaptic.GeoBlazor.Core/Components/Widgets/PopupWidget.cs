using dymaptic.GeoBlazor.Core.Components.Popups.PopupDockComponents;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Popup widget allows users to view content from feature attributes. Popups enhance web applications by providing
///     users with a simple way to interact with and view attributes in a layer. They play an important role in relaying
///     information to the user, which improves the storytelling capabilities of the application.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <remarks>
///     All Views contain a default popup. This popup can display generic content, which is set in its title and content
///     properties. When content is set directly on the Popup instance it is not tied to a specific feature or layer.
///     In most cases this module will not need to be loaded into your application because the view contains a default
///     instance of popup.
/// </remarks>
public class PopupWidget : Widget
{
    /// <summary>
    ///     Defines actions that may be executed by clicking the icon or image symbolizing them in the popup. By default, every
    ///     popup has a zoom-to action styled with a magnifying glass icon. When this icon is clicked, the view zooms in four
    ///     LODs and centers on the selected feature.
    /// </summary>
    public List<ActionBase>? Actions { get; set; }

    /// <summary>
    ///     Position of the popup in relation to the selected feature. The default behavior is to display above the feature and
    ///     adjust if not enough room. If needing to explicitly control where the popup displays in relation to the feature,
    ///     choose an option besides auto.
    /// </summary>
    [Parameter]
    public PopupAlignment? Alignment { get; set; }

    /// <summary>
    ///     This closes the popup when the View camera or Viewpoint changes.
    /// </summary>
    [Parameter]
    public bool? AutoCloseEnabled { get; set; }

    /// <summary>
    ///     This property indicates to the Popup that it needs to allow or disallow the click event propagation. Use
    ///     view.popup.autoOpenEnabled = false; when needing to stop the click event propagation.
    ///     DefaultValue: true
    /// </summary>
    [Parameter]
    [Obsolete("Use MapView.PopupEnabled instead")]
    public bool? AutoOpenEnabled { get; set; }

    /// <summary>
    ///     Indicates whether the popup displays its content. If true, only the header displays.
    /// </summary>
    [Parameter]
    public bool? Collapsed { get; set; }

    /// <summary>
    ///     Indicates whether to enable collapse functionality for the popup.
    ///     DefaultValue: true
    /// </summary>
    [Parameter]
    public bool? CollapseEnabled { get; set; }

    /// <summary>
    ///     The html string content of the popup. When set directly on the Popup, this content is static and cannot use fields
    ///     to set content templates. To set a template for the content based on field or attribute names, see
    ///     <see cref="PopupTemplate.Content" />.
    /// </summary>
    [Parameter]
    public string? StringContent { get; set; }

    /// <summary>
    ///     Enables automatic creation of a popup template for layers that have popups enabled but no popupTemplate defined.
    ///     Automatic popup templates are supported for layers that support the createPopupTemplate method. (Supported for
    ///     FeatureLayer, GeoJSONLayer, OGCFeatureLayer, SceneLayer, CSVLayer, PointCloudLayer, StreamLayer, and ImageryLayer).
    /// </summary>
    [Parameter]
    public bool? DefaultPopupTemplateEnabled { get; set; }

    /// <summary>
    ///     Indicates whether the placement of the popup is docked to the side of the view.
    ///     Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.
    ///     When a popup is "dockEnabled" it means the popup no longer points to the selected feature or the location assigned
    ///     to it. Rather it is attached to a side, the top, or the bottom of the view.
    ///     See <see cref="DockOptions" /> to override default options related to docking the popup.
    /// </summary>
    [Parameter]
    public bool? DockEnabled { get; set; }

    /// <summary>
    ///     Indicates the heading level to use for the title of the popup. By default, the title is rendered as a level 2
    ///     heading (e.g. <h2>Popup title</h2>). Depending on the widget's placement in your app, you may need to adjust this
    ///     heading for proper semantics. This is important for meeting accessibility standards.
    ///     DefaultValue:2
    /// </summary>
    [Parameter]
    public int? HeadingLevel { get; set; }

    /// <summary>
    ///     Highlight the selected popup feature using the highlightOptions set on the MapView or the highlightOptions set on
    ///     the SceneView.
    /// </summary>
    [Parameter]
    public bool? HighlightEnabled { get; set; }

    /// <summary>
    ///     The widget's default label.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    ///     Defines the maximum icons displayed at one time in the action area.
    ///     DefaultValue: 3
    /// </summary>
    [Parameter]
    public int? MaxInlineActions { get; set; }

    /// <summary>
    ///     Indicates whether to display a spinner at the popup location prior to its display when it has pending promises.
    /// </summary>
    [Parameter]
    public bool? SpinnerEnabled { get; set; }

    /// <summary>
    ///     The title of the popup. This can be set generically on the popup no matter the features that are selected. If the
    ///     selected feature has a PopupTemplate, then the title set in the corresponding template is used here.
    /// </summary>
    [Parameter]
    public string? Title { get; set; }

    /// <summary>
    ///     The widget content of the popup. When set directly on the Popup, this content is static and cannot use fields to
    ///     set content templates. To set a template for the content based on field or attribute names, see
    ///     <see cref="PopupTemplate.Content" />.
    /// </summary>
    public Widget? WidgetContent { get; set; }

    /// <summary>
    ///     Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.
    ///     When a popup is "dockEnabled" it means the popup no longer points to the selected feature or the location assigned
    ///     to it. Rather it is placed in one of the corners of the view or to the top or bottom of it. This property allows
    ///     the developer to set various options for docking the popup.
    /// </summary>
    public PopupDockOptions? DockOptions { get; set; }

    /// <summary>
    ///     An array of features associated with the popup. Each graphic in this array must have a valid PopupTemplate set.
    ///     They may share the same PopupTemplate or have unique PopupTemplates depending on their attributes. The content and
    ///     title of the popup is set based on the content and title properties of each graphic's respective PopupTemplate.
    ///     When more than one graphic exists in this array, the current content of the Popup is set based on the value of the
    ///     selected feature.
    ///     This value is null if no features are associated with the popup.
    /// </summary>
    public List<Graphic> Features { get; set; } = new();

    /// <summary>
    ///     Point used to position the popup. This is automatically set when viewing the popup by selecting a feature. If using
    ///     the Popup to display content not related to features in the map, such as the results from a task, then you must set
    ///     this property before making the popup visible to the user.
    /// </summary>
    public Point? Location { get; set; }

    /// <summary>
    ///     The visible elements that are displayed within the widget. This property provides the ability to turn individual
    ///     elements of the widget's display on/off.
    /// </summary>
    public PopupVisibleElements? VisibleElements { get; set; }

    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Popup;

    /// <summary>
    ///     The selected feature accessed by the popup. The content of the Popup is determined based on the PopupTemplate
    ///     assigned to this feature.
    /// </summary>
    public async Task<Graphic?> GetSelectedFeature()
    {
        return await JsComponentReference!.InvokeAsync<Graphic?>("getSelectedFeature",
            CancellationTokenSource.Token, View?.Id);
    }

    /// <summary>
    ///     Sets the string content of the popup.
    /// </summary>
    public async Task SetContent(string stringContent)
    {
        await JsComponentReference!.InvokeVoidAsync("setContent", CancellationTokenSource.Token, stringContent);
    }

    /// <summary>
    ///     Removes promises, features, content, title and location from the Popup.
    /// </summary>
    [ArcGISMethod]
public async Task Clear()
    {
        await JsComponentReference!.InvokeVoidAsync("clear", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Use this method to return feature(s) at a given screen location. These features are fetched from all of the
    ///     LayerViews in the view. In order to use this, a layer must already have an associated PopupTemplate and have its
    ///     popupEnabled. These features can then be used within a custom Popup or Feature widget experience.
    /// </summary>
    [CodeGenerationIgnore]
public async Task<Graphic[]> FetchFeatures()
    {
        return await JsComponentReference!.InvokeAsync<Graphic[]>("fetchFeatures", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     The number of selected features available to the popup.
    /// </summary>
    public async Task<int> GetFeatureCount()
    {
        return await JsComponentReference!.InvokeAsync<int>("getFeatureCount", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Index of the feature that is selected. When features are set, the first index is automatically selected.
    /// </summary>
    public async Task<int> GetSelectedFeatureIndex()
    {
        return await JsComponentReference!.InvokeAsync<int>("getSelectedFeatureIndex", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Index of the feature that is selected. When features are set, the first index is automatically selected.
    /// </summary>
    public async Task<bool> GetVisibility()
    {
        return await JsComponentReference!.InvokeAsync<bool>("getVisibility", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Opens the popup at the given location with content defined either explicitly with content or driven from the
    ///     PopupTemplate of input features. This method sets the popup's visible property to true. Users can alternatively
    ///     open the popup by directly setting the visible property to true.
    /// </summary>
    public async Task Open()
    {
        await JsComponentReference!.InvokeVoidAsync("open", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Closes the popup by setting its visible property to false. Users can alternatively close the popup by directly
    ///     setting the visible property to false.
    /// </summary>
    [ArcGISMethod]
public async Task Close()
    {
        await JsComponentReference!.InvokeVoidAsync("close", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     JS-invokable method for triggering actions.
    /// </summary>
    /// <param name="actionId">
    ///     The action ID.
    /// </param>
    [JSInvokable]
    public async Task OnTriggerAction(string actionId)
    {
        ActionBase? action = Actions?.FirstOrDefault(a => a.Id == actionId);

        if (action is not null)
        {
            await action.CallbackFunction!.Invoke();
        }
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Widget widget:
                if (!widget.Equals(WidgetContent))
                {
                    WidgetContent = widget;
                }

                break;
            case PopupDockOptions dockOptions:
                if (!dockOptions.Equals(DockOptions))
                {
                    DockOptions = dockOptions;
                }

                break;
            case Graphic graphic:
                Features.Add(graphic);

                break;
            case Point point:
                if (!point.Equals(Location))
                {
                    Location = point;
                }

                break;
            case PopupVisibleElements visibleElements:
                if (!visibleElements.Equals(VisibleElements))
                {
                    VisibleElements = visibleElements;
                }

                break;
            case ActionBase action:
                Actions ??= new List<ActionBase>();
                Actions.Add(action);

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Widget:
                WidgetContent = null;

                break;
            case PopupDockOptions:
                DockOptions = null;

                break;
            case Graphic graphic:
                Features.Remove(graphic);

                break;
            case Point:
                Location = null;

                break;
            case PopupVisibleElements:
                VisibleElements = null;

                break;
            case ActionBase action:
                Actions?.Remove(action);

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        WidgetContent?.ValidateRequiredChildren();
        DockOptions?.ValidateRequiredChildren();

        foreach (Graphic feature in Features)
        {
            feature.ValidateRequiredChildren();
        }

        if (Actions is not null)
        {
            foreach (ActionBase action in Actions)
            {
                action.ValidateRequiredChildren();
            }
        }

        base.ValidateRequiredChildren();
    }
}


/// <summary>
///     Defines the dimensions of the View at which to dock the popup. Set to false to disable docking at a breakpoint.
///     DefaultValue: true
/// </summary>
[JsonConverter(typeof(BreakPointConverter))]
public record BreakPoint
{
    /// <summary>
    ///     Constructor for building a breakpoint with specified max width and/or height.
    /// </summary>
    /// <param name="width">
    ///     The maximum width of the View at which the popup will be set to dockEnabled automatically.
    ///     DefaultValue: 544
    /// </param>
    /// <param name="height">
    ///     The maximum height of the View at which the popup will be set to dockEnabled automatically.
    ///     DefaultValue: 544
    /// </param>
    public BreakPoint(double? width = null, double? height = null)
    {
        Width = width;
        Height = height;
    }

    /// <summary>
    ///     Constructor for building a breakpoint with default max width and height.
    /// </summary>
    /// <param name="value">
    ///     Determines if the breakpoint is on or off.
    /// </param>
    public BreakPoint(bool value)
    {
        BoolValue = value;
    }

    /// <summary>
    ///     Determines if the breakpoint is on or off.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BoolValue { get; set; }

    /// <summary>
    ///     The maximum width of the View at which the popup will be set to dockEnabled automatically.
    ///     DefaultValue: 544
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Width { get; set; }

    /// <summary>
    ///     The maximum height of the View at which the popup will be set to dockEnabled automatically.
    ///     DefaultValue: 544
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Height { get; set; }
}


internal class BreakPointConverter : JsonConverter<BreakPoint>
{
    public override BreakPoint? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize(ref reader, typeof(object), options) as BreakPoint;
    }

    public override void Write(Utf8JsonWriter writer, BreakPoint value, JsonSerializerOptions options)
    {
        if (value.BoolValue.HasValue)
        {
            JsonSerializer.Serialize(writer, value.BoolValue.Value, options);
        }
        else
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }
}