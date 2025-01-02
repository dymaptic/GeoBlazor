namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     A slider widget that can be used for filtering data, or gathering numeric input from a user. The slider can have multiple thumbs, and provides you with the ability to format labels and control user input.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Slider.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <remarks>
///     At a minimum, the slider's container or parent container must have a width set in CSS for it to render.
/// </remarks>
public class SliderWidget: Widget
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SliderWidget()
    {
    }

    /// <summary>
    ///     Constructor for creating a SliderWidget in C# code.
    /// </summary>
    /// <param name="containerId">
    ///     The ID of the container element for the widget. The widget will be rendered within this container.
    /// </param>
    /// <param name="disabled">
    ///     When true, sets the slider to a disabled state so the user cannot interact with it.
    /// </param>
    /// <param name="draggableSegmentsEnabled">
    ///     Indicates if the user can drag the segment between thumbs to update thumb positions.
    /// </param>
    /// <param name="effectiveMax">
    ///     When set, the user is restricted from moving slider thumbs to positions higher than this value. This value should be less than the slider max. The effectiveMax and effectiveMin allow you to represent ranges of values in a dataset that cannot be filtered or selected with the slider. This can be useful when using the slider to represent datasets with outliers, or scale ranges not suitable for a layer.
    /// </param>
    /// <param name="effectiveMin">
    ///     When set, the user is restricted from moving slider thumbs to positions less than this value. This value should be greater than the slider min. The effectiveMin and effectiveMax allow you to represent ranges of values in a dataset that cannot be filtered or selected with the slider. This can be useful when using the slider to represent datasets with outliers, or scale ranges not suitable for a layer.
    /// </param>
    /// <param name="label">
    ///     The widget's default label. This label displays when it is used within another widget, such as the Expand or LayerList widgets.
    /// </param>
    /// <param name="labelInputsEnabled">
    ///     Indicates whether to enable editing input values via keyboard input when the user clicks a label. This allows the user to move the slider thumb to precise values without sliding the thumbs.
    /// </param>
    /// <param name="layout">
    ///     Determines the layout/orientation of the Slider widget. By default, the slider will render horizontally with the min value on the left side of the track.
    /// </param>
    /// <param name="max">
    ///     The maximum possible data/thumb value of the slider. In the constructor, if one of the values specified in values is greater than the max value specified in this property, then the max will update to the highest value in values.
    /// </param>
    /// <param name="min">
    ///     The minimum possible data/thumb value of the slider. In the constructor, if one of the values specified in values is less than the min value specified in this property, then the min will update to the lowest value in values.
    /// </param>
    /// <param name="precision">
    ///     Defines how slider thumb values should be rounded. This number indicates the number of decimal places slider thumb values should round to when they have been moved.
    /// </param>
    /// <param name="rangeLabelInputsEnabled">
    ///     Indicates whether to enable editing range values via keyboard input when the user clicks a min or max label. This allows the user to increase or decrease the data range of the slider.
    /// </param>
    /// <param name="snapOnClickEnabled">
    ///     Indicates if the closest thumb will snap to the clicked location on the track.
    /// </param>
    /// <param name="steps">
    ///     Sets steps on the slider that restrict user input to specific values. If an array of numbers is passed to this property, the slider thumbs may only be moved to the positions specified in the array. User either this or <see cref="StepInterval"/>.
    /// </param>
    /// <param name="stepInterval">
    ///     The interval in which slider thumbs can be moved. Use either this or <see cref="Steps"/>.
    /// </param>
    /// <param name="syncedSegmentsEnabled">
    ///     When true, all segments will sync together in updating thumb values when the user drags any segment. This maintains the interval between all thumbs when any segment is dragged. Only applicable when draggableSegmentsEnabled is true.
    /// </param>
    /// <param name="thumbsConstrained">
    ///     When false, the user can freely move any slider thumb to any position along the track. By default, a thumb's position is constrained to the positions of neighboring thumbs so you cannot move one thumb past another. Set this property to false to disable this constraining behavior.
    /// </param>
    /// <param name="values">
    ///     A collection of numbers representing absolute thumb positions on the slider.
    /// </param>
    /// <param name="inputCreatedFunction">
    ///     A function that provides the developer with access to the input elements when rangeLabelInputsEnabled and/or labelInputsEnabled are set to true. This allows the developer to customize the input elements corresponding to slider min/max and thumb values to validate user input. For example, you can access input elements and customize them with type and pattern attributes.
    /// </param>
    /// <param name="inputFormatFunction">
    ///     A JavaScript function used to format user inputs. As opposed to labelFormatFunction, which formats thumb labels, the inputFormatFunction formats thumb values in the input element when the user begins to edit them.
    /// </param>
    /// <param name="inputParseFunction">
    ///     Function used to parse slider inputs formatted by the inputFormatFunction. This property must be set if an inputFormatFunction is set. Otherwise the slider values will likely not update to their expected positions.
    /// </param>
    /// <param name="labelFormatFunction">
    ///     A function used to format labels. Overrides the default label formatter.
    /// </param>
    /// <param name="thumbCreatedFunction">
    ///     Function that executes each time a thumb is created on the slider. This can be used to add custom styling to each thumb or hook event listeners to specific thumbs.
    /// </param>
    /// <param name="tickConfigs">
    ///     When set, renders ticks along the slider track. See the TickConfig documentation for more information on how to configure tick placement, style, and behavior.
    /// </param>
    /// <param name="visible">
    ///     Indicates whether the widget is visible.
    /// </param>
    /// <param name="visibleElements">
    ///     The visible elements that are displayed within the widget. This property provides the ability to turn individual elements of the widget's display on/off.
    /// </param>
    public SliderWidget(string containerId, bool? disabled = null, bool? draggableSegmentsEnabled = null, 
        double? effectiveMax = null, double? effectiveMin = null, string? label = null, bool? labelInputsEnabled = null, 
        SliderLayout? layout = null, double? max = null, double? min = null, double? precision = null, 
        bool? rangeLabelInputsEnabled = null, bool? snapOnClickEnabled = null, double[]? steps = null, 
        double? stepInterval = null, bool? syncedSegmentsEnabled = null, bool? thumbsConstrained = null, 
        IReadOnlyCollection<double>? values = null, string? inputCreatedFunction = null, 
        string? inputFormatFunction = null, string? inputParseFunction = null, string? labelFormatFunction = null,
        string? thumbCreatedFunction = null, IReadOnlyCollection<SliderTickConfig>? tickConfigs = null,
        bool? visible = null, SliderVisibleElements? visibleElements = null)
    {
#pragma warning disable BL0005
        ContainerId = containerId;
        Disabled = disabled;
        DraggableSegmentsEnabled = draggableSegmentsEnabled;
        EffectiveMax = effectiveMax;
        EffectiveMin = effectiveMin;
        Label = label;
        LabelInputsEnabled = labelInputsEnabled;
        Layout = layout;
        Max = max;
        Min = min;
        Precision = precision;
        RangeLabelInputsEnabled = rangeLabelInputsEnabled;
        SnapOnClickEnabled = snapOnClickEnabled;
        Steps = steps;
        StepInterval = stepInterval;
        SyncedSegmentsEnabled = syncedSegmentsEnabled;
        ThumbsConstrained = thumbsConstrained;
        Values = values;
        InputCreatedFunction = inputCreatedFunction;
        InputFormatFunction = inputFormatFunction;
        InputParseFunction = inputParseFunction;
        LabelFormatFunction = labelFormatFunction;
        ThumbCreatedFunction = thumbCreatedFunction;
        Visible = visible;

        if (tickConfigs is not null)
        {
            TickConfigs = new List<SliderTickConfig>(tickConfigs);
        }

        VisibleElements = visibleElements;
#pragma warning restore BL0005
    }

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
    ///     The widget's default label. This label displays when it is used within another widget, such as the Expand or LayerList widgets.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
    
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
    public IReadOnlyCollection<double>? Steps { get; set; }
    
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
    public IReadOnlyCollection<double>? Values { get; set; }
    
    /// <summary>
    ///     A function that provides the developer with access to the input elements when rangeLabelInputsEnabled and/or labelInputsEnabled are set to true. This allows the developer to customize the input elements corresponding to slider min/max and thumb values to validate user input. For example, you can access input elements and customize them with type and pattern attributes.
    /// </summary>
    /// <remarks>
    ///     Because the attributes this function exposes are in HTML, they must be set in JavaScript, and it doesn't make sense to pass them to C#. Instead, pass in valid JavaScript code as a string. This code has access to three parameters (value, type, and thumbIndex). See <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Slider.html#inputCreatedFunction">ArcGIS Maps SDK for JavaScript</a> for more information. 
    ///     Example value:
    ///     """
    ///         input.setAttribute("type", "number");
    ///         input.setAttribute("pattern", "[0-9]*");
    ///     """;
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InputCreatedFunction { get; set; }
    
    /// <summary>
    ///     A JavaScript function used to format user inputs. As opposed to labelFormatFunction, which formats thumb labels, the inputFormatFunction formats thumb values in the input element when the user begins to edit them.
    /// </summary>
    /// <remarks>
    ///     Because this function must resolve synchronously, it cannot be used in Blazor. Instead, pass in valid JavaScript code as a string. This code has access to three parameters (value, type, and index) and must return a string. See <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Slider.html#inputFormatFunction">ArcGIS Maps SDK for JavaScript</a> for more information. 
    ///     Example value:
    ///     """
    ///     if(value >= 1000000){
    ///         return (value / 1000000).toPrecision(3) + "m"
    ///     }
    ///     if(value >= 100000){
    ///         return (value / 1000).toPrecision(3) + "k"
    ///     }
    ///     if(value >= 1000){
    ///         return (value / 1000).toPrecision(2) + "k"
    ///     }
    ///     return value.toFixed(0);
    ///     """;
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InputFormatFunction { get; set; }
    
    /// <summary>
    ///     Function used to parse slider inputs formatted by the inputFormatFunction. This property must be set if an inputFormatFunction is set. Otherwise the slider values will likely not update to their expected positions.
    ///     Overrides the default input parses, which is a parsed floating point number.
    /// </summary>
    /// <remarks>
    ///     Because this function must resolve synchronously, it cannot be used in Blazor. Instead, pass in valid JavaScript code as a string. This code has access to three parameters (value, type, and index) and must return a string. See <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Slider.html#inputParseFunction">ArcGIS Maps SDK for JavaScript</a> for more information. 
    ///     Example value:
    ///     """
    ///         let charLength = value.length;
    ///         let valuePrefix = parseFloat(value.substring(0,charLength-1));
    ///         let finalChar = value.substring(charLength-1);
    ///
    ///         if(parseFloat(finalChar) >= 0){
    ///             return parseFloat(value);
    ///         }
    ///         if(finalChar === "k"){
    ///             return valuePrefix * 1000;
    ///         }
    ///         if(finalChar === "m"){
    ///             return valuePrefix * 1000000;
    ///         }
    ///         return value;
    ///     """;
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InputParseFunction { get; set; }
    
    /// <summary>
    ///     A function used to format labels. Overrides the default label formatter.
    ///     By default labels are formatted in the following way:
    ///         - When the data range is less than 10 ((max - min) &lt; 10), labels are rounded based on the value set in the precision property.
    ///         - When the data range is larger than 10, labels display with a precision of no more than two decimal places, though actual slider thumb values will maintain the precision specified in precision.
    ///     Use this property to override the behavior defined above.
    /// </summary>
    /// <remarks>
    ///     Because this function must resolve synchronously, it cannot be used in Blazor. Instead, pass in valid JavaScript code as a string. This code has access to three parameters (value, type, and index) and must return a string. See <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Slider.html#labelFormatFunction">ArcGIS Maps SDK for JavaScript</a> for more information. 
    ///     Example value:
    ///     """
    ///         return (type === "value") ? value.toFixed(0) : value;
    ///     """;
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LabelFormatFunction { get; set; }
    
    /// <summary>
    ///     Function that executes each time a thumb is created on the slider. This can be used to add custom styling to each thumb or hook event listeners to specific thumbs.
    /// </summary>
    /// <remarks>
    ///     Because the attributes this function exposes are in HTML, they must be set in JavaScript, and it doesn't make sense to pass them to C#. Instead, pass in valid JavaScript code as a string. This code has access to four parameters (index, value, thumbElement, and labelElement). See <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Slider.html#inputCreatedFunction">ArcGIS Maps SDK for JavaScript</a> for more information. 
    ///     Example value:
    ///     """
    ///         thumbElement.classList.add("change-color");
    ///         thumbElement.addEventListener("focus", function() {
    ///             // add custom behavior here...tooltips, fire other actions, etc.
    ///         });
    ///     """;
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ThumbCreatedFunction { get; set; }

#region Event Handlers
    /// <summary>
    ///     Fires when a user changes the max value of the slider.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SliderMaxChangeEvent> OnMaxChange { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    public async Task OnJsMaxChange(SliderMaxChangeEvent changeEvent)
    {
        await OnMaxChange.InvokeAsync(changeEvent);
    }
    
    /// <summary>
    ///     Fires when a user clicks the max label element.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SliderMaxClickEvent> OnMaxClick { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    public async Task OnJsMaxClick(SliderMaxClickEvent clickEvent)
    {
        await OnMaxClick.InvokeAsync(clickEvent);
    }
    
    /// <summary>
    ///     Fires when a user changes the min value of the slider.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SliderMinChangeEvent> OnMinChange { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    public async Task OnJsMinChange(SliderMinChangeEvent changeEvent)
    {
        await OnMinChange.InvokeAsync(changeEvent);
    }
    
    /// <summary>
    ///     Fires when a user clicks the min label element.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SliderMinClickEvent> OnMinClick { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    public async Task OnJsMinClick(SliderMinClickEvent clickEvent)
    {
        await OnMinClick.InvokeAsync(clickEvent);
    }

    /// <summary>
    ///     Fires when a user clicks a segment element on the slider. A segment is a portion of the track that lies between two thumbs. This only applies when two or more thumbs are set on the slider.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SliderSegmentClickEvent> OnSegmentClick { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    public async Task OnJsSegmentClick(SliderSegmentClickEvent clickEvent)
    {
        await OnSegmentClick.InvokeAsync(clickEvent);
    }
    
    /// <summary>
    ///     Fires when a user drags a segment element on the slider. A segment is a portion of the track that lies between two thumbs. This only applies when two or more thumbs are set on the slider.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SliderSegmentDragEvent> OnSegmentDrag { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    public async Task OnJsSegmentDrag(SliderSegmentDragEvent dragEvent)
    {
        await OnSegmentDrag.InvokeAsync(dragEvent);
    }
    
    /// <summary>
    ///     Fires when a user changes the value of a thumb via the arrow keys or by keyboard editing of the label on the slider.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SliderThumbChangeEvent> OnThumbChange { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    public async Task OnJsThumbChange(SliderThumbChangeEvent changeEvent)
    {
        await OnThumbChange.InvokeAsync(changeEvent);
    }
    
    /// <summary>
    ///     Fires when a user clicks a thumb element.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SliderThumbClickEvent> OnThumbClick { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    public async Task OnJsThumbClick(SliderThumbClickEvent clickEvent)
    {
        await OnThumbClick.InvokeAsync(clickEvent);
    }
    
    /// <summary>
    ///     Fires when a user drags a thumb on the Slider widget.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SliderThumbDragEvent> OnThumbDrag { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    public async Task OnJsThumbDrag(SliderThumbDragEvent dragEvent)
    {
        await OnThumbDrag.InvokeAsync(dragEvent);
    }
    
    /// <summary>
    ///     Fires when a user clicks a tick or its associated label.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SliderTickClickEvent> OnTickClick { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
    public async Task OnJsTickClick(SliderTickClickEvent clickEvent)
    {
        await OnTickClick.InvokeAsync(clickEvent);
    }
    
    /// <summary>
    ///     Fires when a user clicks the track element.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SliderTrackClickEvent> OnTrackClick { get; set; }
    
    /// <summary>
    ///     JS-invokable method, for internal use only.
    /// </summary>
    [JSInvokable]
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
    ///     When set, renders ticks along the slider track. See the TickConfig documentation for more information on how to configure tick placement, style, and behavior.
    /// </summary>
    public IReadOnlyList<SliderTickConfig> TickConfigs
    {
        get => _tickConfigs;
        set => _tickConfigs = new List<SliderTickConfig>(value);
    }

    /// <summary>
    ///     The visible elements that are displayed within the widget. This property provides the ability to turn individual elements of the widget's display on/off.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SliderVisibleElements? VisibleElements { get; set; }

    /// <summary>
    ///     Retrieves references to the HTML Element nodes representing the slider segment between the min and effectiveMin, and the segment between the effectiveMax and max. You can use this method to customize the style and attach event handlers to these segments. This only applies to sliders where the effectiveMin and effectiveMax are specified.
    /// </summary>
    public async Task<ElementReference[]?> GetEffectiveSegmentElements()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<ElementReference[]>("getEffectiveSegmentElements");
    }

    /// <summary>
    ///     Retrieves references to the HTML Element nodes representing labels attached to slider thumbs. You can use this property to customize the style of labels and attach event handlers to each element.
    /// </summary>
    public async Task<ElementReference[]?> GetLabelElements()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<ElementReference[]>("getLabelElements");
    }

    /// <summary>
    ///     Retrieves an array of strings associated with 'values' generated using an internal label formatter or the values returned from labelFormatFunction.
    /// </summary>
    public async Task<string[]?> GetLabels()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<string[]>("getLabels");
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
    public async Task<ElementReference[]?> GetSegmentElements()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<ElementReference[]>("getSegmentElements");
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
    public async Task<ElementReference[]?> GetThumbElements()
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference.InvokeAsync<ElementReference[]>("getThumbElements");
    }
    
    /// <summary>
    ///     Retrieves references to the HTML Element nodes representing slider ticks and their associated labels. These elements are created in TickCreatedFunction and configured in tickConfigs.
    /// </summary>
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
    public async Task SetValues(IReadOnlyCollection<double> values)
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
    public async Task SetSteps(IReadOnlyCollection<double> steps)
    {
        Steps = steps;
        
        if (JsComponentReference is null) return;
        
        await JsComponentReference.InvokeVoidAsync("setProperty", "steps", steps);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SliderTickConfig tickConfig:
                _tickConfigs.Add(tickConfig); 
                
                break;
            case SliderVisibleElements visibleElement:
                VisibleElements = visibleElement;
                
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
            case SliderTickConfig tickConfig:
                _tickConfigs.Remove(tickConfig); 
                
                break;
            case SliderVisibleElements visibleElement:
                VisibleElements = null;
                
                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    internal override void ValidateRequiredChildren()
    {
        foreach (SliderTickConfig tickConfig in _tickConfigs)
        {
            tickConfig.ValidateRequiredChildren();
        }
        VisibleElements?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }

    private List<SliderTickConfig> _tickConfigs = new();
}

/// <summary>
///     Object specification for configuring ticks on the slider. An array of these objects should be set on the tickConfigs property.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Slider.html#TickConfig">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SliderTickConfig: MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SliderTickConfig()
    {
    }
    
    /// <summary>
    ///     Constructor with parameters for use in C# code.
    /// </summary>
    /// <param name="mode">
    ///     The mode or method of positioning ticks along the slider track. See the table below for a list of possible values.
    /// </param>
    /// <param name="singleValue">
    ///     Indicates where ticks will be rendered below the track. Use <see cref="Values"/> for multiple values. See the description for mode for more information about how this property is interpreted by each mode.
    /// </param>
    /// <param name="values">
    ///     Indicates where ticks will be rendered below the track. Use <see cref="SingleValue"/> for single values. See the description for mode for more information about how this property is interpreted by each mode.
    /// </param>
    /// <param name="labelsVisible">
    ///     Indicates whether to render labels for the ticks.
    /// </param>
    /// <param name="tickCreatedFunction">
    ///     Callback that fires for each tick. You can override default behaviors and styles with this property.
    /// </param>
    /// <param name="labelFormatFunction">
    ///     Callback for formatting tick labels.
    /// </param>
    public SliderTickConfig(TickConfigMode? mode = null, double? singleValue = null,
        IReadOnlyCollection<double>? values = null, bool? labelsVisible = null, 
        string? tickCreatedFunction = null, string? labelFormatFunction = null)
    {
#pragma warning disable BL0005
        Mode = mode;
        SingleValue = singleValue;
        Values = values;
        LabelsVisible = labelsVisible;
        TickCreatedFunction = tickCreatedFunction;
        LabelFormatFunction = labelFormatFunction;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     The mode or method of positioning ticks along the slider track. See the table below for a list of possible values.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TickConfigMode? Mode { get; set; }
    
    /// <summary>
    ///     Indicates where ticks will be rendered below the track. Use <see cref="Values"/> for multiple values. See the description for mode for more information about how this property is interpreted by each mode.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SingleValue { get; set; }
    
    /// <summary>
    ///    Indicates where ticks will be rendered below the track. Use <see cref="SingleValue"/> for single values. See the description for mode for more information about how this property is interpreted by each mode. 
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyCollection<double>? Values { get; set; }
    
    /// <summary>
    ///     Indicates whether to render labels for the ticks.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LabelsVisible { get; set; }
    
    /// <summary>
    ///     Callback that fires for each tick. You can override default behaviors and styles with this property.
    /// </summary>
    /// <remarks>
    ///     Because the attributes this function exposes are in HTML, they must be set in JavaScript, and it doesn't make sense to pass them to C#. Instead, pass in valid JavaScript code as a string. This code has access to three parameters (value, tickElement, and labelElement). See <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Slider.html#TickConfig">ArcGIS Maps SDK for JavaScript</a> for more information. 
    ///     Example value:
    ///     """
    ///         tickElement.classList.add("largeTicks");
    ///         labelElement.classList.add("largeLabels");
    ///         labelElement.onclick = function() {
    ///             const newValue = labelElement["data-value"];
    ///             slider.values = [ newValue ];
    ///         };
    ///     """;
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TickCreatedFunction { get; set; }
    
    /// <summary>
    ///     Callback for formatting tick labels.
    /// </summary>
    /// <remarks>
    ///     Because this function must resolve synchronously, it cannot be used in Blazor. Instead, pass in valid JavaScript code as a string. This code has access to three parameters (value, type, and index) and must return a string. See <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Slider.html#labelFormatFunction">ArcGIS Maps SDK for JavaScript</a> for more information. 
    ///     Example value:
    ///     """
    ///         return (type === "value") ? value.toFixed(0) : value;
    ///     """;
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LabelFormatFunction { get; set; }
}

/// <summary>
///     The HTML Element nodes representing a single slider tick and its associated label.
/// </summary>
/// <param name="TickElement">
///     The HTMLElement representing a tick. You can add or modify the style of a tick by adding CSS classes to this element. You can also attach event listeners to this element.
/// </param>
/// <param name="LabelElement">
///     The HTMLElement representing the label associated with the tick element. You can add or modify the style of a tick label by adding CSS classes to this element. You can also attach event listeners to this element.
/// </param>
public record TickElementGroup(ElementReference? TickElement, ElementReference? LabelElement);

/// <summary>
///     The visible elements that are displayed within the widget. This provides the ability to turn individual elements of the widget's display on/off. Alternatively, developers may also use CSS (e.g. display: none) to show/hide elements, such as labels.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Slider.html#VisibleElements">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SliderVisibleElements : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SliderVisibleElements()
    {
    }

    /// <summary>
    ///     Constructor with parameters for use in C# code.
    /// </summary>
    /// <param name="labels">
    ///     Indicates whether to display labels for slider thumbs. By default, labels display input thumb values as floating point values with a precision of two digits. The format of labels can be customized via the labelFormatFunction.
    /// </param>
    /// <param name="rangeLabels">
    ///     Indicates whether to display min or max range values on the slider. The format of labels can be customized via the labelFormatFunction.
    /// </param>
    public SliderVisibleElements(bool? labels = null, bool? rangeLabels = null)
    {
#pragma warning disable BL0005
        Labels = labels;
        RangeLabels = rangeLabels;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     Indicates whether to display labels for slider thumbs. By default, labels display input thumb values as floating point values with a precision of two digits. The format of labels can be customized via the labelFormatFunction.
    ///     Default value: false
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Labels { get; set; }
    
    /// <summary>
    ///     Indicates whether to display min or max range values on the slider. The format of labels can be customized via the labelFormatFunction.
    ///     Default value: false
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? RangeLabels { get; set; }
}

/// <summary>
///     Event arguments for the <see cref="SliderWidget.OnMaxChange"/> event.
/// </summary>
/// <param name="OldValue">
///     The former max value (or bound) of the slider.
/// </param>
/// <param name="Value">
///     The max value (or bound) of the slider when the event is emitted.
/// </param>
public record SliderMaxChangeEvent(double OldValue, double Value);

/// <summary>
///     Event arguments for the <see cref="SliderWidget.OnMaxClick"/> event.
/// </summary>
/// <param name="Value">
///     The max value of the slider.
/// </param>
public record SliderMaxClickEvent(double Value);

/// <summary>
///     Event arguments for the <see cref="SliderWidget.OnMinChange"/> event.
/// </summary>
/// <param name="OldValue">
///     The former min value (or bound) of the slider.
/// </param>
/// <param name="Value">
///     The min value (or bound) of the slider when the event is emitted.
/// </param>
public record SliderMinChangeEvent(double OldValue, double Value);

/// <summary>
///     Event arguments for the <see cref="SliderWidget.OnMinClick"/> event.
/// </summary>
/// <param name="Value">
///     The min value of the slider.
/// </param>
public record SliderMinClickEvent(double Value);

/// <summary>
///     Event arguments for the <see cref="SliderWidget.OnSegmentClick"/> event.
/// </summary>
/// <param name="Index">
///     The 1-based index of the segment on the slider.
/// </param>
/// <param name="ThumbIndices">
///     The indices of the thumbs on each end of the segment.
/// </param>
/// <param name="Value">
///     The approximate value of the slider at the location of the click event.
/// </param>
public record SliderSegmentClickEvent(int Index, int[] ThumbIndices, double Value);

/// <summary>
///     Event arguments for the <see cref="SliderWidget.OnSegmentDrag"/> event.
/// </summary>
/// <param name="Index">
///     The 1-based index of the segment on the slider.
/// </param>
/// <param name="State">
///     The state of the drag.
/// </param>
/// <param name="ThumbIndices">
///     The indices of the thumbs on each end of the segment.
/// </param>
public record SliderSegmentDragEvent(int Index, SliderDragState State, int[] ThumbIndices);

/// <summary>
///     Event arguments for the <see cref="SliderWidget.OnThumbChange"/> event.
/// </summary>
/// <param name="Index">
///     The 0-based index of the updated thumb.
/// </param>
/// <param name="OldValue">
///     The former value of the thumb before the change was made.
/// </param>
/// <param name="Value">
///     The value of the thumb when the event is emitted.
/// </param>
public record SliderThumbChangeEvent(int Index, double OldValue, double Value);

/// <summary>
///     Event arguments for the <see cref="SliderWidget.OnThumbClick"/> event.
/// </summary>
/// <param name="Index">
///     The 0-based index of the thumb.
/// </param>
/// <param name="Value">
///     The value of the thumb when the event is emitted.
/// </param>
public record SliderThumbClickEvent(int Index, double Value);

/// <summary>
///     Event arguments for the <see cref="SliderWidget.OnThumbDrag"/> event.
/// </summary>
/// <param name="Index">
///     The 0-based index of the updated thumb.
/// </param>
/// <param name="State">
///     The state of the drag.
/// </param>
/// <param name="Value">
///     The value of the thumb when the event is emitted.
/// </param>
public record SliderThumbDragEvent(int Index, SliderThumbDragState State, double Value);

/// <summary>
///     Event arguments for the <see cref="SliderWidget.OnTickClick"/> event.
/// </summary>
/// <param name="Value">
///     The approximate value that the tick represents on the slider track.
/// </param>
/// <param name="ConfigIndex">
///     The 0-based index of the associated configuration provided in tickConfigs.
/// </param>
/// <param name="GroupIndex">
///     The 0-based index of the tick and/or group (associated label) relative to other ticks in the same configuration.
/// </param>
public record SliderTickClickEvent(double Value, int ConfigIndex, int GroupIndex);

/// <summary>
///     Event arguments for the <see cref="SliderWidget.OnTrackClick"/> event.
/// </summary>
/// <param name="Value">
///     The approximate value of the slider at the location of the click event.
/// </param>
public record SliderTrackClickEvent(double Value);