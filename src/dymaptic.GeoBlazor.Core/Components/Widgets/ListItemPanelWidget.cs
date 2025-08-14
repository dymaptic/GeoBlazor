namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class ListItemPanelWidget: Widget
{
   // Add custom code to this file to override generated code
   
   /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public ListItemPanelWidget()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="containerId">
    ///     The id of an external HTML Element (div). If provided, the widget will be placed inside that element, instead of on the map.
    /// </param>
    /// <param name="content">
    ///     The content of the panel as a list of <see cref="ListItemPanelContent"/> items. Use this to add multiple content items to the panel in an ordered manner. Accepts strings, widgets, and HTML element references.
    /// </param>
    /// <param name="showLegendContent">
    ///     Display a LegendWidget as the content of the panel.
    /// </param>
    /// <param name="disabled">
    ///     If `true`, disables the ListItem's panel so the user cannot open or interact with it.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html#disabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="flowEnabled">
    ///     Indicates whether the panel's content should be rendered as a <a target="_blank" href="https://developers.arcgis.com/calcite-design-system/components/flow-item/">Calcite Flow Item</a>.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html#flowEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="icon">
    ///     Icon which represents the widget.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html#icon">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="image">
    ///     The URL or data URI of an image used to represent the panel.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html#image">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="label">
    ///     The widget's label.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html#label">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="mapView">
    ///     If the Widget is defined outside of the MapView, this link is required to connect them together.
    /// </param>
    /// <param name="open">
    ///     Indicates if the panel's content is open and visible to the user.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html#open">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="position">
    ///     The position of the widget in relation to the map view.
    /// </param>
    /// <param name="title">
    ///     The title of the panel.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visible">
    ///     Indicates whether the widget is visible.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html#visible">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="widgetId">
    ///     The unique ID assigned to the widget when the widget is created.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public ListItemPanelWidget(
        string? containerId = null,
        IReadOnlyList<ListItemPanelContent>? content = null,
        bool? showLegendContent = null,
        bool? disabled = null,
        bool? flowEnabled = null,
        string? icon = null,
        string? image = null,
        string? label = null,
        MapView? mapView = null,
        bool? open = null,
        OverlayPosition? position = null,
        string? title = null,
        bool? visible = null,
        string? widgetId = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        ContainerId = containerId;

        if (content is not null)
        {
            Content = content;
        }
        
        ShowLegendContent = showLegendContent;
        Disabled = disabled;
        FlowEnabled = flowEnabled;
        Icon = icon;
        Image = image;
        Label = label;
        MapView = mapView;
        Open = open;
        Position = position;
        Title = title;
        Visible = visible;
        WidgetId = widgetId;
#pragma warning restore BL0005    
    }
    
   
   /// <inheritdoc />
   public override WidgetType Type => WidgetType.ListItemPanel;
   
   /// <summary>
   ///     Convenience method to display a LegendWidget as the content of the panel.
   /// </summary>
   [Parameter]
   [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
   public bool? ShowLegendContent { get; set; }
   
   /// <summary>
   ///      The content of the panel as a list of <see cref="ListItemPanelContent"/> items. Use this to add multiple content items to the panel in an ordered manner. Accepts strings, widgets, and HTML element references.
   /// </summary>
   [Parameter]
   [CodeGenerationIgnore]
   public IReadOnlyList<ListItemPanelContent> Content { get; set; } = [];
   
   /// <inheritdoc />
   public override async Task RegisterChildComponent(MapComponent child)
   {
       switch (child)
       {
           case Widget widget:
               if (Content.All(c => c.WidgetContent?.Id != widget.Id))
               {
                   Content = [..Content, new ListItemPanelContent(widget)];
               }
               
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
           case Widget widget:
               Content = Content.Except(Content.Where(c => c.WidgetContent?.Id == widget.Id)).ToList();

               break;
           default:
               await base.UnregisterChildComponent(child);

               break;
       }
   }


}