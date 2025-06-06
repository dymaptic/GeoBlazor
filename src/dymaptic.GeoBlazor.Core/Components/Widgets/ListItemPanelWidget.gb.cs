// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components.Widgets;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Widgets.ListItemPanelWidget.html">GeoBlazor Docs</a>
///     This class allows you to display custom content for each <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html">ListItem</a>
///     in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html">LayerList</a> widget.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class ListItemPanelWidget
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
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
    ///     The content displayed in the ListItem panel.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html#content">ArcGIS Maps SDK for JavaScript</a>
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
    public ListItemPanelWidget(
        string? containerId = null,
        IReadOnlyList<ListItemPanelContent>? content = null,
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
        Content = content;
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
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Widgets.ListItemPanelWidget.html#listitempanelwidgetcontent-property">GeoBlazor Docs</a>
    ///     The content displayed in the ListItem panel.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html#content">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<ListItemPanelContent>? Content { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Widgets.ListItemPanelWidget.html#listitempanelwidgetdisabled-property">GeoBlazor Docs</a>
    ///     If `true`, disables the ListItem's panel so the user cannot open or interact with it.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html#disabled">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Disabled { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Widgets.ListItemPanelWidget.html#listitempanelwidgetflowenabled-property">GeoBlazor Docs</a>
    ///     Indicates whether the panel's content should be rendered as a <a target="_blank" href="https://developers.arcgis.com/calcite-design-system/components/flow-item/">Calcite Flow Item</a>.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html#flowEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? FlowEnabled { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Widgets.ListItemPanelWidget.html#listitempanelwidgetimage-property">GeoBlazor Docs</a>
    ///     The URL or data URI of an image used to represent the panel.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html#image">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Image { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Widgets.ListItemPanelWidget.html#listitempanelwidgetlistitem-property">GeoBlazor Docs</a>
    ///     The panel's parent ListItem that represents a layer in the map.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html#listItem">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [AncestorPropertyReference]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ListItem? ListItem { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Widgets.ListItemPanelWidget.html#listitempanelwidgetopen-property">GeoBlazor Docs</a>
    ///     Indicates if the panel's content is open and visible to the user.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html#open">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Open { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Widgets.ListItemPanelWidget.html#listitempanelwidgettitle-property">GeoBlazor Docs</a>
    ///     The title of the panel.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItemPanel.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Content property.
    /// </summary>
    public async Task<IReadOnlyList<ListItemPanelContent>?> GetContent()
    {
        if (CoreJsModule is null)
        {
            return Content;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return Content;
        }

        // get the property value
        IReadOnlyList<ListItemPanelContent>? result = await JsComponentReference!.InvokeAsync<IReadOnlyList<ListItemPanelContent>?>("getProperty",
            CancellationTokenSource.Token, "content");
        if (result is not null)
        {
#pragma warning disable BL0005
             Content = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Content)] = Content;
        }
         
        return Content;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Disabled property.
    /// </summary>
    public async Task<bool?> GetDisabled()
    {
        if (CoreJsModule is null)
        {
            return Disabled;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return Disabled;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "disabled");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Disabled = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Disabled)] = Disabled;
        }
         
        return Disabled;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the FlowEnabled property.
    /// </summary>
    public async Task<bool?> GetFlowEnabled()
    {
        if (CoreJsModule is null)
        {
            return FlowEnabled;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return FlowEnabled;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "flowEnabled");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             FlowEnabled = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(FlowEnabled)] = FlowEnabled;
        }
         
        return FlowEnabled;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Image property.
    /// </summary>
    public async Task<string?> GetImage()
    {
        if (CoreJsModule is null)
        {
            return Image;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return Image;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "image");
        if (result is not null)
        {
#pragma warning disable BL0005
             Image = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Image)] = Image;
        }
         
        return Image;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Open property.
    /// </summary>
    public async Task<bool?> GetOpen()
    {
        if (CoreJsModule is null)
        {
            return Open;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return Open;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "open");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Open = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Open)] = Open;
        }
         
        return Open;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Title property.
    /// </summary>
    public async Task<string?> GetTitle()
    {
        if (CoreJsModule is null)
        {
            return Title;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return Title;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "title");
        if (result is not null)
        {
#pragma warning disable BL0005
             Title = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Title)] = Title;
        }
         
        return Title;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Content property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetContent(IReadOnlyList<ListItemPanelContent>? value)
    {
#pragma warning disable BL0005
        Content = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Content)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "content", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Disabled property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetDisabled(bool? value)
    {
#pragma warning disable BL0005
        Disabled = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Disabled)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "disabled", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the FlowEnabled property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetFlowEnabled(bool? value)
    {
#pragma warning disable BL0005
        FlowEnabled = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(FlowEnabled)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "flowEnabled", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Image property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetImage(string? value)
    {
#pragma warning disable BL0005
        Image = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Image)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "image", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Open property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetOpen(bool? value)
    {
#pragma warning disable BL0005
        Open = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Open)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "open", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Title property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetTitle(string? value)
    {
#pragma warning disable BL0005
        Title = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Title)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "title", value);
    }
    
#endregion

#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the Content property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToContent(params ListItemPanelContent[] values)
    {
        ListItemPanelContent[] join = Content is null
            ? values
            : [..Content, ..values];
        await SetContent(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the Content property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromContent(params ListItemPanelContent[] values)
    {
        if (Content is null)
        {
            return;
        }
        await SetContent(Content.Except(values).ToArray());
    }
    
#endregion


    /// <inheritdoc />
    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ListItemPanelContent content:
                Content ??= [];
                if (!Content.Contains(content))
                {
                    Content = [..Content, content];
                    ModifiedParameters[nameof(Content)] = Content;
                    if (MapRendered)
                    {
                        await UpdateWidget();
                    }
                }
                
                return true;
            case ListItem listItem:
                if (listItem != ListItem)
                {
                    ListItem = listItem;
                    ModifiedParameters[nameof(ListItem)] = ListItem;
                    if (MapRendered)
                    {
                        await UpdateWidget();
                    }
                }
                
                return true;
            default:
                return await base.RegisterGeneratedChildComponent(child);
        }
    }

    /// <inheritdoc />
    protected override async ValueTask<bool> UnregisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ListItemPanelContent content:
                Content = Content?.Where(c => c != content).ToList();
                ModifiedParameters[nameof(Content)] = Content;
                return true;
            case ListItem _:
                ListItem = null;
                ModifiedParameters[nameof(ListItem)] = ListItem;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    public override void ValidateRequiredGeneratedChildren()
    {
    
        if (Content is not null)
        {
            foreach (ListItemPanelContent child in Content)
            {
                child.ValidateRequiredGeneratedChildren();
            }
        }
        ListItem?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
