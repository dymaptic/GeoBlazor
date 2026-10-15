namespace dymaptic.GeoBlazor.Pro.Components.Widgets;

public partial class TimeSliderWidget : ProWidget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.TimeSlider;

    /// <summary>
    ///     When true, sets the widget to a disabled state so the user cannot interact with it.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Disabled { get; set; }



    /// <summary>
    /// The temporal extent of the entire slider.
    /// </summary>
    [Parameter]
    public TimeExtent? FullTimeExtent { get; set; }


    /// <summary>
    /// Determines the layout used by the TimeSlider widget.
    /// </summary>
    [Parameter]
    public TimeSliderLayout Layout { get; set; } = TimeSliderLayout.Auto;

    /// <summary>
    /// When true, the time slider will play its animation in a loop.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Loop { get; set; }

    /// <summary>
    /// The time slider mode.
    /// </summary>
    [Parameter]
    public TimeSliderMode Mode { get; set; } = TimeSliderMode.TimeWindow;

    /// <summary>
    /// The time (in milliseconds) between animation steps.
    /// </summary>
    [Parameter]
    public double PlayRate { get; set; } = 1000;


    /// <summary>
    /// The current time extent of the time slider.
    /// </summary>
    [Parameter]
    public TimeExtent? TimeExtent { get; set; }

    /// <summary>
    /// Shows/hides time in the display.
    /// </summary>
    [Parameter]
    public bool TimeVisible { get; set; }

    /// <summary>
    ///     Use to set the fullTimeExtent property after the widget has been created.
    /// </summary>
    public async Task SetFullTimeExtent(TimeExtent fullTimeExtent)
    {
        FullTimeExtent = fullTimeExtent;
        if (JsComponentReference is null) return;
        await JsComponentReference.InvokeVoidAsync("setFullTimeExtent", fullTimeExtent);

    }

    /// <summary>
    /// Use to set the Stops property after the widget has been created.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task SetStops(TimeSliderStops timeSliderStop)
    {
        Stops = timeSliderStop;
        if (JsComponentReference is null) return;
        await JsComponentReference.InvokeVoidAsync("setStops", timeSliderStop);
    }


    /// <summary>
    /// Use to set the TimeExtent property after the widget has been created.
    /// </summary>
    public async Task SetTimeExtent(TimeExtent timeExtent)
    {
        TimeExtent = timeExtent;
        if (JsComponentReference is null) return;
        await JsComponentReference.InvokeVoidAsync("setTimeExtent", timeExtent);
    }

    /// <summary>
    /// Use to retrieve the current TimeExtent property after the widget has been created.
    /// </summary>
    public async Task<TimeExtent?> GetTimeExtent()
    {
        if (JsComponentReference is not null)
        {
            TimeExtent = await JsComponentReference.InvokeAsync<TimeExtent>("getTimeExtent");
        }

        return TimeExtent;
    }

    /// <summary>
    /// Sets the specified properties on the widget.
    /// </summary>
    /// <param name="properties">The properties to set on the TimeSlider Widget</param>
    [CodeGenerationIgnore]
    public async Task SetPropertiesFromWebMap(WebMapProperties properties)
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("setPropertiesFromWebMap", properties);
    }
    
    /// <summary>
    /// Sets the specified properties on the widget to the current WebMap properties.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task SetPropertiesFromWebMap()
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("setPropertiesFromWebMap");
    }


    /// <summary>
    /// Extracts time slider settings from a WebMap if the webmap contains a time slider widget definition.
    /// Returns an object with properties that can be used to configure the TimeSlider or TimeSliderViewModel.
    /// If a webmap does not contain a time slider definition then null is returned.
    /// </summary>
    /// <param name="viewId">The Guid Id of the view that contains the map to get the properties from</param>
    [CodeGenerationIgnore]
    public async Task<WebMapProperties?> GetPropertiesFromWebMap(Guid viewId)
    {
        if (JsComponentReference is null) return null;

        var result = await JsComponentReference.InvokeAsync<WebMapProperties>("getPropertiesFromWebMap");

        return result;
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case TickConfig tickConfig:
                TickConfigs ??= [];
                if (!TickConfigs!.Contains(tickConfig))
                {
                    TickConfigs = [..TickConfigs, tickConfig];
                }
                if (MapRendered)
                    {
                        await UpdateWidget();
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
            case TickConfig tickConfig:
                TickConfigs = TickConfigs?.Except([tickConfig]).ToList();
                
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }
    
    /// <summary>
    ///     JavaScript-Invokable Method for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsTriggerAction(IJSStreamReference jsStreamRef)
    {
        TimeSliderTriggerActionEvent? triggerActionEvent =
            await jsStreamRef.ReadJsStreamReference<TimeSliderTriggerActionEvent>();
        
        if (triggerActionEvent is null)
        {
            return;
        }
        
        if (Actions is not null)
        {
            foreach (TimeSliderAction action in Actions)
            {
                if (action.ActionId == triggerActionEvent.Action?.ActionId && action.CallbackFunction is not null)
                {
                    await action.CallbackFunction.Invoke();
                }
            }
        }
        
        await OnTriggerAction.InvokeAsync(triggerActionEvent);
    }
    
    /// <summary>
    ///     Event Listener for TriggerAction.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<TimeSliderTriggerActionEvent> OnTriggerAction { get; set; }

}