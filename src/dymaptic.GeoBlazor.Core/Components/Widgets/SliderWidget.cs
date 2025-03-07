namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class SliderWidget: Widget
{


    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Slider;
    
    /// <summary>
    ///     When true, sets the slider to a disabled state so the user cannot interact with it.
    ///     Default Value: false
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Disabled { get; set; }
    
    /// <summary>
    ///     Indicates if the user can drag the segment between thumbs to update thumb positions.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DraggableSegmentsEnabled { get; set; }
    
    /// <summary>
    ///     When set, the user is restricted from moving slider thumbs to positions higher than this value. This value should be less than the slider max. The effectiveMax and effectiveMin allow you to represent ranges of values in a dataset that cannot be filtered or selected with the slider. This can be useful when using the slider to represent datasets with outliers, or scale ranges not suitable for a layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? EffectiveMax { get; set; }
    
    /// <summary>
    ///     When set, the user is restricted from moving slider thumbs to positions less than this value. This value should be greater than the slider min. The effectiveMin and effectiveMax allow you to represent ranges of values in a dataset that cannot be filtered or selected with the slider. This can be useful when using the slider to represent datasets with outliers, or scale ranges not suitable for a layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? EffectiveMin { get; set; }

    
    /// <summary>
    ///     Indicates whether to enable editing input values via keyboard input when the user clicks a label. This allows the user to move the slider thumb to precise values without sliding the thumbs.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LabelInputsEnabled { get; set; }
    
    /// <summary>
    ///     Determines the layout/orientation of the Slider widget. By default, the slider will render horizontally with the min value on the left side of the track.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SliderLayout? Layout { get; set; }
    
    /// <summary>
    ///     The maximum possible data/thumb value of the slider. In the constructor, if one of the values specified in values is greater than the max value specified in this property, then the max will update to the highest value in values.
    ///     To display the max value's label on the slider, set visibleElements.rangeLabels to true. To allow the end user to modify the max value, set rangeLabelInputsEnabled to true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Max { get; set; }
    
    /// <summary>
    ///     The minimum possible data/thumb value of the slider. In the constructor, if one of the values specified in values is less than the min value specified in this property, then the min will update to the lowest value in values.
    ///     To display the min value's label on the slider, set visibleElements.rangeLabels to true. To allow the end user to modify the min value, set rangeLabelInputsEnabled to true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Min { get; set; }
    
    /// <summary>
    ///     Defines how slider thumb values should be rounded. This number indicates the number of decimal places slider thumb values should round to when they have been moved.
    ///     This value also indicates the precision of thumb labels when the data range is less than 10 (i.e. (max - min) &lt; 10).
    ///     When the data range is larger than 10, labels display with a precision of no more than two decimal places, though actual slider thumb values will maintain the precision specified in this property.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Precision { get; set; }
    
    /// <summary>
    ///     Indicates whether to enable editing range values via keyboard input when the user clicks a min or max label. This allows the user to increase or decrease the data range of the slider.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? RangeLabelInputsEnabled { get; set; }
    
    /// <summary>
    ///     Indicates if the closest thumb will snap to the clicked location on the track.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SnapOnClickEnabled { get; set; }
    
    /// <summary>
    ///     Sets steps on the slider that restrict user input to specific values. If an array of numbers is passed to this property, the slider thumbs may only be moved to the positions specified in the array. User either this or <see cref="StepInterval"/>.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<double>? Steps { get; set; }
    
    /// <summary>
    ///     The interval in which slider thumbs can be moved. Use either this or <see cref="Steps"/>.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? StepInterval { get; set; }
    
    /// <summary>
    ///     When true, all segments will sync together in updating thumb values when the user drags any segment. This maintains the interval between all thumbs when any segment is dragged. Only applicable when draggableSegmentsEnabled is true.
    ///     Default Value:false
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SyncedSegmentsEnabled { get; set; }
    
    /// <summary>
    ///     When false, the user can freely move any slider thumb to any position along the track. By default, a thumb's position is constrained to the positions of neighboring thumbs so you cannot move one thumb past another. Set this property to false to disable this constraining behavior.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ThumbsConstrained { get; set; }
    
    /// <summary>
    ///     A collection of numbers representing absolute thumb positions on the slider.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<double>? Values { get; set; }


#region Event Handlers
    /// <summary>
    ///     Fires when a user changes the max value of the slider.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SliderMaxChangeEvent> OnMaxChange { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsMaxChange(SliderMaxChangeEvent changeEvent)
    {
        await OnMaxChange.InvokeAsync(changeEvent);
    }
    
    /// <summary>
    ///     Fires when a user clicks the max label element.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SliderMaxClickEvent> OnMaxClick { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsMaxClick(SliderMaxClickEvent clickEvent)
    {
        await OnMaxClick.InvokeAsync(clickEvent);
    }
    
    /// <summary>
    ///     Fires when a user changes the min value of the slider.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SliderMinChangeEvent> OnMinChange { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsMinChange(SliderMinChangeEvent changeEvent)
    {
        await OnMinChange.InvokeAsync(changeEvent);
    }
    
    /// <summary>
    ///     Fires when a user clicks the min label element.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SliderMinClickEvent> OnMinClick { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsMinClick(SliderMinClickEvent clickEvent)
    {
        await OnMinClick.InvokeAsync(clickEvent);
    }

    /// <summary>
    ///     Fires when a user clicks a segment element on the slider. A segment is a portion of the track that lies between two thumbs. This only applies when two or more thumbs are set on the slider.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SliderSegmentClickEvent> OnSegmentClick { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsSegmentClick(SliderSegmentClickEvent clickEvent)
    {
        await OnSegmentClick.InvokeAsync(clickEvent);
    }
    
    /// <summary>
    ///     Fires when a user drags a segment element on the slider. A segment is a portion of the track that lies between two thumbs. This only applies when two or more thumbs are set on the slider.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SliderSegmentDragEvent> OnSegmentDrag { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsSegmentDrag(SliderSegmentDragEvent dragEvent)
    {
        await OnSegmentDrag.InvokeAsync(dragEvent);
    }
    
    /// <summary>
    ///     Fires when a user changes the value of a thumb via the arrow keys or by keyboard editing of the label on the slider.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SliderThumbChangeEvent> OnThumbChange { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsThumbChange(SliderThumbChangeEvent changeEvent)
    {
        await OnThumbChange.InvokeAsync(changeEvent);
    }
    
    /// <summary>
    ///     Fires when a user clicks a thumb element.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SliderThumbClickEvent> OnThumbClick { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsThumbClick(SliderThumbClickEvent clickEvent)
    {
        await OnThumbClick.InvokeAsync(clickEvent);
    }
    
    /// <summary>
    ///     Fires when a user drags a thumb on the Slider widget.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SliderThumbDragEvent> OnThumbDrag { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsThumbDrag(SliderThumbDragEvent dragEvent)
    {
        await OnThumbDrag.InvokeAsync(dragEvent);
    }
    
    /// <summary>
    ///     Fires when a user clicks a tick or its associated label.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SliderTickClickEvent> OnTickClick { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsTickClick(SliderTickClickEvent clickEvent)
    {
        await OnTickClick.InvokeAsync(clickEvent);
    }
    
    /// <summary>
    ///     Fires when a user clicks the track element.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SliderTrackClickEvent> OnTrackClick { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsTrackClick(SliderTrackClickEvent clickEvent)
    {
        await OnTrackClick.InvokeAsync(clickEvent);
    }
    
    /// <summary>
    ///     Fires when a user changes the selected range or value of the slider.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<double[]> ValueChanged { get; set; }

    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    public async Task OnJsValueChanged(double[] newValues)
    {
        Values = newValues;
        await ValueChanged.InvokeAsync(newValues);
    }

#endregion

    /// <summary>
    ///     Retrieves references to the HTML Element nodes representing the slider segment between the min and effectiveMin, and the segment between the effectiveMax and max. You can use this method to customize the style and attach event handlers to these segments. This only applies to sliders where the effectiveMin and effectiveMax are specified.
    /// </summary>
    public async Task<IReadOnlyList<ElementReference>?> GetEffectiveSegmentElements()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<IReadOnlyList<ElementReference>>("getEffectiveSegmentElements");
    }

    /// <summary>
    ///     Retrieves references to the HTML Element nodes representing labels attached to slider thumbs. You can use this property to customize the style of labels and attach event handlers to each element.
    /// </summary>
    public async Task<IReadOnlyList<ElementReference>?> GetLabelElements()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<IReadOnlyList<ElementReference>>("getLabelElements");
    }

    
    /// <summary>
    ///     Retrieves the HTML Element node representing the max value label. You can use this property to customize the style and attach event handlers.
    /// </summary>
    public async Task<ElementReference?> GetMaxLabelElement()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<ElementReference>("getMaxLabelElement");
    }
    
    /// <summary>
    ///     Retrieves the HTML Element node representing the min value label. You can use this property to customize the style and attach event handlers.
    /// </summary>
    public async Task<ElementReference?> GetMinLabelElement()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<ElementReference>("getMinLabelElement");
    }
    
    /// <summary>
    ///     Retrieves the HTML Element nodes representing interactive slider segments. Segments are interactive when situated between two thumbs. You can use this property to customize the style and attach event handlers to segments.
    /// </summary>
    public async Task<IReadOnlyList<ElementReference>?> GetSegmentElements()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<IReadOnlyList<ElementReference>>("getSegmentElements");
    }

    /// <summary>
    ///     Retrieves the current state of the widget.
    /// </summary>
    public async Task<SliderState?> GetState()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<SliderState>("getState");
    }
    
    /// <summary>
    ///     Retrieves references to the HTML Element nodes representing slider thumbs. You can use this property to customize the style of thumbs and attach event handlers to each thumb.
    /// </summary>
    public async Task<IReadOnlyList<ElementReference>?> GetThumbElements()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<IReadOnlyList<ElementReference>>("getThumbElements");
    }
    
    /// <summary>
    ///     Retrieves references to the HTML Element nodes representing slider ticks and their associated labels. These elements are created in TickCreatedFunction and configured in tickConfigs.
    /// </summary>
    [CodeGenerationIgnore]
public async Task<TickElementGroup[][]?> GetTickElements()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<TickElementGroup[][]>("getTickElements");
    }

    /// <summary>
    ///     The HTML Element node representing the slider track. Use this property to attach event listeners to the track or to customize the track's CSS.
    /// </summary>
    public async Task<ElementReference?> GetTrackElement()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<ElementReference>("getTrackElement");
    }

    /// <summary>
    ///     Updates the <see cref="Max"/> value after initial render.
    /// </summary>
    public async Task SetMax(double max)
    {
        Max = max;

        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("setProperty", "max", max);
    }
    
    /// <summary>
    ///     Updates the <see cref="Min"/> value after initial render.
    /// </summary>
    public async Task SetMin(double min)
    {
        Min = min;

        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("setProperty", "min", min);
    }

    /// <summary>
    ///     Updates the <see cref="Values"/> after initial render.
    /// </summary>
    public async Task SetValues(IReadOnlyList<double> values)
    {
        Values = values;
        
        if (JsComponentReference is null) return;
        
        await JsComponentReference.InvokeVoidAsync("setProperty", "values", values);
    }

    /// <summary>
    ///     Updates the <see cref="StepInterval"/> value after initial render.
    /// </summary>
    public async Task SetStepInterval(double stepInterval)
    {
        StepInterval = stepInterval;
        
        if (JsComponentReference is null) return;
        
        await JsComponentReference.InvokeVoidAsync("setProperty", "steps", stepInterval);
    }
    
    /// <summary>
    ///     Updates the <see cref="Steps"/> value after initial render.
    /// </summary>
    public async Task SetSteps(IReadOnlyList<double> steps)
    {
        Steps = steps;
        
        if (JsComponentReference is null) return;
        
        await JsComponentReference.InvokeVoidAsync("setProperty", "steps", steps);
    }
}