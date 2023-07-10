using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Views;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Popup widget allows users to view content from feature attributes. Popups enhance web applications by providing
///     users with a simple way to interact with and view attributes in a layer. They play an important role in relaying
///     information to the user, which improves the storytelling capabilities of the application.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html">
///         ArcGIS
///         API
///     </a>
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
    public HashSet<ActionBase>? Actions { get; set; }

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
    public HashSet<Graphic> Features { get; set; } = new();

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
    public override string WidgetType => "popup";

    /// <summary>
    ///     The selected feature accessed by the popup. The content of the Popup is determined based on the PopupTemplate
    ///     assigned to this feature.
    /// </summary>
    public async Task<Graphic> GetSelectedFeature()
    {
        return await JsObjectReference!.InvokeAsync<Graphic>("getSelectedFeature",
            CancellationTokenSource.Token, View?.Id);
    }

    /// <summary>
    ///     Sets the string content of the popup.
    /// </summary>
    public async Task SetContent(string stringContent)
    {
        await JsObjectReference!.InvokeVoidAsync("setContent", CancellationTokenSource.Token, stringContent);
    }

    /// <summary>
    ///     Removes promises, features, content, title and location from the Popup.
    /// </summary>
    public async Task Clear()
    {
        await JsObjectReference!.InvokeVoidAsync("clear", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Use this method to return feature(s) at a given screen location. These features are fetched from all of the
    ///     LayerViews in the view. In order to use this, a layer must already have an associated PopupTemplate and have its
    ///     popupEnabled. These features can then be used within a custom Popup or Feature widget experience.
    /// </summary>
    public async Task<Graphic[]> FetchFeatures()
    {
        return await JsObjectReference!.InvokeAsync<Graphic[]>("fetchFeatures", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     The number of selected features available to the popup.
    /// </summary>
    public async Task<int> GetFeatureCount()
    {
        return await JsObjectReference!.InvokeAsync<int>("getFeatureCount", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Index of the feature that is selected. When features are set, the first index is automatically selected.
    /// </summary>
    public async Task<int> GetSelectedFeatureIndex()
    {
        return await JsObjectReference!.InvokeAsync<int>("getSelectedFeatureIndex", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Index of the feature that is selected. When features are set, the first index is automatically selected.
    /// </summary>
    public async Task<bool> GetVisibility()
    {
        return await JsObjectReference!.InvokeAsync<bool>("getVisibility", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Opens the popup at the given location with content defined either explicitly with content or driven from the
    ///     PopupTemplate of input features. This method sets the popup's visible property to true. Users can alternatively
    ///     open the popup by directly setting the visible property to true.
    /// </summary>
    public async Task Open()
    {
        await JsObjectReference!.InvokeVoidAsync("open", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Closes the popup by setting its visible property to false. Users can alternatively close the popup by directly
    ///     setting the visible property to false.
    /// </summary>
    public async Task Close()
    {
        await JsObjectReference!.InvokeVoidAsync("close", CancellationTokenSource.Token);
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
                Actions ??= new HashSet<ActionBase>();
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
///     Position of the popup in relation to the selected feature. The default behavior is to display above the feature and
///     adjust if not enough room. If needing to explicitly control where the popup displays in relation to the feature,
///     choose an option besides auto.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PopupAlignment>))]
public enum PopupAlignment
{
#pragma warning disable CS1591
    Auto,
    TopCenter,
    TopRight,
    BottomLeft,
    BottomCenter,
    BottomRight
#pragma warning restore CS1591
}

/// <summary>
///     Dock position in the View.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PopupDockPosition>))]
public enum PopupDockPosition
{
#pragma warning disable CS1591
    Auto,
    TopCenter,
    TopRight,
    TopLeft,
    BottomLeft,
    BottomCenter,
    BottomRight
#pragma warning restore CS1591
}

/// <summary>
///     Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.
///     When a popup is "dockEnabled" it means the popup no longer points to the selected feature or the location assigned
///     to it. Rather it is placed in one of the corners of the view or to the top or bottom of it. This property allows
///     the developer to set various options for docking the popup.
/// </summary>
public class PopupDockOptions : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    public PopupDockOptions()
    {
    }

    /// <summary>
    ///     Constructor for creating a PopupDockOptions object in code.
    /// </summary>
    /// <param name="position">
    ///     The position in the view at which to dock the popup.
    /// </param>
    /// <param name="buttonEnabled">
    ///     If true, displays the dock button. If false, hides the dock button from the popup.
    /// </param>
    /// <param name="breakPoint">
    ///     Defines the dimensions of the View at which to dock the popup. Set to false to disable docking at a breakpoint.
    /// </param>
    public PopupDockOptions(PopupDockPosition? position = null, bool? buttonEnabled = null,
        BreakPoint? breakPoint = null)
    {
#pragma warning disable BL0005
        Position = position;
        ButtonEnabled = buttonEnabled;
        BreakPoint = breakPoint;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The position in the view at which to dock the popup.
    /// </summary>
    [Parameter]
    public PopupDockPosition? Position { get; set; }

    /// <summary>
    ///     If true, displays the dock button. If false, hides the dock button from the popup.
    /// </summary>
    [Parameter]
    public bool? ButtonEnabled { get; set; }

    /// <summary>
    ///     Defines the dimensions of the View at which to dock the popup. Set to false to disable docking at a breakpoint.
    /// </summary>
    [Parameter]
    public BreakPoint? BreakPoint { get; set; }
}

/// <summary>
///     Defines the dimensions of the View at which to dock the popup. Set to false to disable docking at a breakpoint.
///     DefaultValue: true
/// </summary>
[JsonConverter(typeof(BreakPointConverter))]
public class BreakPoint
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

/// <summary>
///     The visible elements that are displayed within the widget. This provides the ability to turn individual elements of
///     the widget's display on/off.
/// </summary>
public class PopupVisibleElements : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
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

/// <summary>
///     Defines the location and content of the popup when opened with <see cref="MapView.OpenPopup" />
/// </summary>
public class PopupOpenOptions
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
    public Graphic[]? Features { get; set; }

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