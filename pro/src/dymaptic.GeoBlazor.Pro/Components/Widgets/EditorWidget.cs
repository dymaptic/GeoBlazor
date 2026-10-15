namespace dymaptic.GeoBlazor.Pro.Components.Widgets;

public partial class EditorWidget : ProWidget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Editor;

    /// <summary>
    ///     Indicates the heading level to use for title of the widget. By default, the title (i.e. "Editor") is rendered as a level 4 heading (e.g. <h4>Editor</h4>). Depending on the widget's placement in your app, you may need to adjust this heading for proper semantics. This is important for meeting accessibility standards.
    ///     Default Value: 4
    /// </summary>
    [Parameter]
    public int? HeadingLevel { get; set; }

    /// <summary>
    ///     The unique ID assigned to the widget when the widget is created. If not set by the developer, it will default to the container ID, or if that is not present then it will be automatically generated.
    /// </summary>
    /// <remarks>
    ///     Known Limitation: Sketch labels are currently only supported when working with a SceneView.
    /// </remarks>
    [Parameter]
    public SketchLabelOptions? LabelOptions { get; set; }

    /// <summary>
    ///     The SnappingOptions for editing. Supports self snapping and feature snapping. The SnappingControls UI is automatically integrated into the Editor widget. Modify the snappingOptions if modifications are needed from what is provided in the default UI.
    /// </summary>
    [Parameter]
    public SnappingOptions? SnappingOptions { get; set; }

    /// <summary>
    ///     This property allows customization of supporting Editor widgets and their default behavior. These widgets include FeatureForm, FeatureTemplates, and the SketchViewModel.
    /// </summary>
    /// <remarks>
    ///     This property is useful for basic overrides of the default widgets. There may be some limitations to what the Editor can do with these overridden properties. For example, the Editor will disable the multipleSelectionEnabled
    ///     property in Sketch.defaultUpdateOptions no matter what is set within this property.
    /// </remarks>
    [Parameter]
    public SupportingWidgetDefaults? SupportingWidgetDefaults { get; set; }

    /// <summary>
    ///     Options to configure the tooltip shown next to the cursor when creating or updating graphics.
    /// </summary>
    [Parameter]
    public SketchTooltipOptions? TooltipOptions { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case EditorLayerInfo layerInfo:
                LayerInfos ??= [];
                LayerInfos = [..LayerInfos, layerInfo];

                break;
            case SnappingOptions snappingOptions:
                SnappingOptions = snappingOptions;

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
            case EditorLayerInfo layerInfo:
                LayerInfos = LayerInfos?.Except([layerInfo]).ToList();

                break;
            case SnappingOptions _:
                SnappingOptions = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        SnappingOptions?.ValidateRequiredChildren();
        SupportingWidgetDefaults?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }

    /// <summary>
    ///     Retrieves the active <see cref="IEditorWidgetActiveWorkflow" /> from the widget.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<IEditorWidgetActiveWorkflow?> GetActiveWorkflow()
    {
        if (CoreJsModule is null)
        {
            return ActiveWorkflow;
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
            return ActiveWorkflow;
        }

        IEditorWidgetActiveWorkflow? result = await JsComponentReference.InvokeAsync<IEditorWidgetActiveWorkflow?>(
            "getActiveWorkflow", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            ActiveWorkflow = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(ActiveWorkflow)] = ActiveWorkflow;
        }
        
        return ActiveWorkflow;
    }

    /// <summary>
    ///     Updates and sets the <see cref="LayerInfos" /> property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task SetLayerInfos(IReadOnlyList<EditorLayerInfo> layerInfos)
    {
        if (JsComponentReference is null) return;

        LayerInfos = layerInfos;
        await JsComponentReference.InvokeVoidAsync("setLayerInfos", layerInfos);
    }

    /// <summary>
    ///     Cancels any active workflow.
    /// </summary>
    [ArcGISMethod]
    public async Task CancelWorkflow()
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("cancelWorkflow");
    }

    /// <summary>
    ///     This is applicable if there is an active UpdateWorkflow. If so, this method deletes the workflow feature.
    /// </summary>
    [ArcGISMethod]
    [Obsolete("Deprecated since GeoBlazor 4.2.0. Use <a target=\"_blank\" href=\"#deletefeatures\">`deleteFeatures`</a> instead.")]
    [CodeGenerationIgnore]
    public async Task DeleteFeatureFromWorkflow()
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("deleteFeatureFromWorkflow");
    }

    /// <summary>
    ///     Initiates the CreateFeaturesWorkflow by displaying the panel where feature(s) creation begins. This method takes a CreationInfo object containing the layer(s) and template(s) to use.
    /// </summary>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task StartCreateFeaturesWorkflowAtFeatureCreation(CreationInfo creationInfo)
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("startCreateFeaturesWorkflowAtFeatureCreation", creationInfo);
    }

    /// <summary>
    ///     Initiates the CreateFeaturesWorkflow by displaying the FeatureTemplates panel.
    /// </summary>
    [ArcGISMethod]
    public async Task StartCreateFeaturesWorkflowAtFeatureTypeSelection()
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("startCreateFeaturesWorkflowAtFeatureTypeSelection");
    }

    /// <summary>
    ///     Starts the UpdateWorkflow at the attribute editing panel.
    /// </summary>
    /// <param name="feature">The feature to be updated</param>
    [CodeGenerationIgnore]
    public async Task StartUpdateWorkflowAtFeatureEdit(Graphic feature)
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("startUpdateWorkflowAtFeatureEdit", feature);
    }

    /// <summary>
    ///     Starts the UpdateWorkflow using the current selected feature.
    /// </summary>
    [ArcGISMethod]
    public async Task StartUpdateWorkflowAtFeatureSelection()
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("startUpdateWorkflowAtFeatureSelection");
    }

    /// <summary>
    ///     Starts the UpdateWorkflow using the current selected feature.
    /// </summary>
    /// <param name="candidates">
    ///     An array of features to be updated. This is only relevant when there are multiple candidates to update.
    /// </param>
    [CodeGenerationIgnore]
    public async Task StartUpdateWorkflowAtMultipleFeatureSelection(IEnumerable<Graphic> candidates)
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("startUpdateWorkflowAtMultipleFeatureSelection", candidates);
    }
}

/// <summary>
///     Indicates whether to allow updating an existing attachment. Default value is true.
/// </summary>
public class SupportingWidgetAttachments : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SupportingWidgetAttachments()
    {
    }

    /// <summary>
    ///     Indicates whether to allow updating an existing attachment. Default value is true.
    /// </summary>
    /// <param name="displayType">
    ///     String indicating how to display the attachments.
    /// </param>
    /// <param name="capabilities">
    ///     The capabilities needed for the attachments widget.
    /// </param>
    public SupportingWidgetAttachments(string displayType, AttachmentsCapabilities? capabilities = null)
    {
        DisplayType = displayType;
        Capabilities = capabilities;
    }

    /// <summary>
    ///     String indicating how to display the attachments.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DisplayType { get; set; }

    /// <summary>
    ///     The capabilities needed for the attachments widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AttachmentsCapabilities? Capabilities { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        if (child is AttachmentsCapabilities capabilities)
        {
            Capabilities = capabilities;
        }
        else
        {
            await base.RegisterChildComponent(child);
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        if (child is AttachmentsCapabilities)
        {
            Capabilities = null;
        }
        else
        {
            await base.UnregisterChildComponent(child);
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        Capabilities?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     Describes the configurable attachments operations.
/// </summary>
public class AttachmentsCapabilitiesOperation : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public AttachmentsCapabilitiesOperation()
    {
    }
    
    /// <summary>
    ///     Describes the configurable attachments operations.
    /// </summary>
    /// <param name="add">
    ///     Indicates whether to allow adding attachments. Default value is true.
    /// </param>
    /// <param name="update">
    ///     Indicates whether to allow updating an existing attachment. Default value is true.
    /// </param>
    /// <param name="delete">
    ///     Indicates whether to allow deleting an existing attachment. Default value is true.
    /// </param>
    public AttachmentsCapabilitiesOperation(bool? add = null, bool? update = null, bool? delete = null)
    {
        Add = add;
        Update = update;
        Delete = delete;
    }

    /// <summary>
    ///     Indicates whether to allow adding attachments. Default value is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Add { get; set; }

    /// <summary>
    ///     Indicates whether to allow updating an existing attachment. Default value is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Update { get; set; }

    /// <summary>
    ///     Indicates whether to allow deleting an existing attachment. Default value is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Delete { get; set; }
}

/// <summary>
///     An object containing properties specific for customizing the FeatureForm widget.
/// </summary>
public class SupportingWidgetFeatureForm : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SupportingWidgetFeatureForm()
    {
    }

    /// <summary>
    ///     An object containing properties specific for customizing the FeatureForm widget.
    /// </summary>
    /// <param name="groupDisplay">
    ///     String indicating the groupDisplay and how they will be displayed to the end user. This only applies if using grouped field elements configured in the Editor's layer infos.
    /// </param>
    public SupportingWidgetFeatureForm(string groupDisplay)
    {
#pragma warning disable BL0005
        GroupDisplay = groupDisplay;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     String indicating the groupDisplay and how they will be displayed to the end user. This only applies if using grouped field elements configured in the Editor's layer infos.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GroupDisplay { get; set; }
}

/// <summary>
///     An object containing properties specific for customizing the FeatureTemplates widget.
/// </summary>
public class SupportingWidgetFeatureTemplates : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SupportingWidgetFeatureTemplates()
    {
    }

    /// <summary>
    ///     An object containing properties specific for customizing the FeatureTemplates widget.
    /// </summary>
    /// <param name="groupBy">
    ///     Aids in managing various template items and how they display within the widget. Please refer to groupBy API reference for additional information.
    /// </param>
    /// <param name="visibleElements">
    ///     Holds a single value, "filter".
    /// </param>
    public SupportingWidgetFeatureTemplates(string? groupBy = null,
        SupportingWidgetVisibleElements? visibleElements = null)
    {
        GroupBy = groupBy;
        VisibleElements = visibleElements;
    }

    /// <summary>
    ///     Aids in managing various template items and how they display within the widget. Please refer to groupBy API reference for additional information.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GroupBy { get; set; }

    /// <summary>
    ///     Holds a single value, "filter".
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SupportingWidgetVisibleElements? VisibleElements { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SupportingWidgetVisibleElements visibleElements:
                VisibleElements = visibleElements;

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
            case SupportingWidgetVisibleElements _:
                VisibleElements = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        VisibleElements?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     Support class for filtering.
/// </summary>
public class SupportingWidgetVisibleElements : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SupportingWidgetVisibleElements()
    {
    }
    
    /// <summary>
    ///     Support class for filtering.
    /// </summary>
    /// <param name="filter">
    ///     Indicates whether the templates filter displays.
    /// </param>
    public SupportingWidgetVisibleElements(bool? filter)
    {
        Filter = filter;
    }

    /// <summary>
    ///     Indicates whether the templates filter displays.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Filter { get; set; }
}

/// <summary>
///     An object containing properties specific for customizing the Sketch widget.
/// </summary>
public class SupportingWidgetSketch : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SupportingWidgetSketch()
    {
    }
    
    /// <summary>
    ///     An object containing properties specific for customizing the Sketch widget.
    /// </summary>
    /// <param name="defaultUpdateOptions">
    ///     An object containing the defaultUpdateOptions for the Sketch widget.
    /// </param>
    /// <param name="markerSymbol">
    ///     The marker symbol used to symbolize any point feature updates.
    /// </param>
    /// <param name="polygonSymbol">
    ///     The polygon symbol used to symbolize any polygon feature updates.
    /// </param>
    /// <param name="polylineSymbol">
    ///     The polygon symbol used to symbolize any polygon feature updates.
    /// </param>
    public SupportingWidgetSketch(object? defaultUpdateOptions, SimpleMarkerSymbol? markerSymbol = null,
        SimpleFillSymbol? polygonSymbol = null, SimpleLineSymbol? polylineSymbol = null)
    {
        DefaultUpdateOptions = defaultUpdateOptions;
        MarkerSymbol = markerSymbol;
        PolygonSymbol = polygonSymbol;
        PolylineSymbol = polylineSymbol;
    }

    /// <summary>
    ///     An object containing the defaultUpdateOptions for the Sketch widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? DefaultUpdateOptions { get; set; }

    /// <summary>
    ///     The marker symbol used to symbolize any point feature updates.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SimpleMarkerSymbol? MarkerSymbol { get; set; }

    /// <summary>
    ///     The polygon symbol used to symbolize any polygon feature updates.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SimpleFillSymbol? PolygonSymbol { get; set; }

    /// <summary>
    ///     The polygon symbol used to symbolize any polygon feature updates.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SimpleLineSymbol? PolylineSymbol { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SimpleMarkerSymbol markerSymbol:
                MarkerSymbol = markerSymbol;

                break;
            case SimpleFillSymbol polygonSymbol:
                PolygonSymbol = polygonSymbol;

                break;
            case SimpleLineSymbol polylineSymbol:
                PolylineSymbol = polylineSymbol;

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
            case SimpleMarkerSymbol _:
                MarkerSymbol = null;

                break;
            case SimpleFillSymbol _:
                PolygonSymbol = null;

                break;
            case SimpleLineSymbol _:
                PolylineSymbol = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        MarkerSymbol?.ValidateRequiredChildren();
        PolygonSymbol?.ValidateRequiredChildren();
        PolylineSymbol?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}