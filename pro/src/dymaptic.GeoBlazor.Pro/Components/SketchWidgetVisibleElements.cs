namespace dymaptic.GeoBlazor.Pro.Components;

public partial class SketchWidgetVisibleElements : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public SketchWidgetVisibleElements()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="createTools">
    ///     The available sketch tools within the widget.
    /// </param>
    /// <param name="deleteButton">
    ///     Indicates whether to display the 'delete' button while a graphic is selected. Default is true. Do not hide this button without giving users on touch devices another way to delete selected geometries.
    /// </param>
    /// <param name="duplicateButton">
    ///     Indicates whether to display the 'duplicate' button while a graphic is selected. Default is true.
    /// </param>
    /// <param name="labelsToggle">
    ///     Indicates whether to display the sketch labels toggle. Default value is true.
    /// </param>
    /// <param name="selectionCountLabel">
    ///     Indicates whether to display a label indicating the length of the currently selected feature set.
    /// </param>
    /// <param name="selectionTools">
    ///     The available selection tools within the widget. Known Limitation: Rectangle and lasso selection is only supported when working with a MapView.
    /// </param>
    /// <param name="settingsMenu">
    ///     Indicates whether to display the settings menu. Currently this menu contains snapping options. Default value is true.
    /// </param>
    /// <param name="snappingControls">
    ///     Indicates whether to display the SnappingControls widget. Default is true.
    /// </param>
    /// <param name="snappingControlsElements">
    ///     The available SnappingControls elements within the widget.
    /// </param>
    /// <param name="tooltipsToggle">
    ///     Indicates whether to display the tooltips toggle. Default value is true.
    /// </param>
    /// <param name="undoRedoMenu">
    ///     Indicates whether to display the undo/redo menu within the widget. Default is true.
    /// </param>
    [CodeGenerationIgnore]
    public SketchWidgetVisibleElements(
        CreateTools? createTools = null,
        bool? deleteButton = null,
        bool? duplicateButton = null,
        bool? labelsToggle = null,
        bool? selectionCountLabel = null,
        SelectionTools? selectionTools = null,
        bool? settingsMenu = null,
        bool? snappingControls = null,
        SnappingControlsElements? snappingControlsElements = null,
        bool? tooltipsToggle = null,
        bool? undoRedoMenu = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        CreateTools = createTools;
        DeleteButton = deleteButton;
        DuplicateButton = duplicateButton;
        LabelsToggle = labelsToggle;
        SelectionCountLabel = selectionCountLabel;
        SelectionTools = selectionTools;
        SettingsMenu = settingsMenu;
        SnappingControls = snappingControls;
        SnappingControlsElements = snappingControlsElements;
        TooltipsToggle = tooltipsToggle;
        UndoRedoMenu = undoRedoMenu;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.SketchWidgetVisibleElements.html#sketchwidgetvisibleelementscreatetools-property">GeoBlazor Docs</a>
    ///     The available sketch tools within the widget.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public CreateTools? CreateTools { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.SketchWidgetVisibleElements.html#sketchwidgetvisibleelementsdeletebutton-property">GeoBlazor Docs</a>
    ///     Indicates whether to display the 'delete' button while a graphic is selected. Default is true. Do not hide this button without giving users on touch devices another way to delete selected geometries.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? DeleteButton { get; set; }
    
        
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.SketchWidgetVisibleElements.html#sketchwidgetvisibleelementsduplicatebutton-property">GeoBlazor Docs</a>
    ///     Indicates whether to display the 'duplicate' button while a graphic is selected. Default is true.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? DuplicateButton { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.SketchWidgetVisibleElements.html#sketchwidgetvisibleelementslabelstoggle-property">GeoBlazor Docs</a>
    ///      Indicates whether to display the sketch labels toggle. Default value is true.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? LabelsToggle { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.SketchWidgetVisibleElements.html#sketchwidgetvisibleelementsselectioncountlabel-property">GeoBlazor Docs</a>
    ///     Indicates whether to display a label indicating the length of the currently selected feature set.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? SelectionCountLabel { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.SketchWidgetVisibleElements.html#sketchwidgetvisibleelementsselectiontools-property">GeoBlazor Docs</a>
    ///     The available selection tools within the widget.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public SelectionTools? SelectionTools { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.SketchWidgetVisibleElements.html#sketchwidgetvisibleelementssnappingcontrols-property">GeoBlazor Docs</a>
    ///     Indicates whether to display the SnappingControls widget. Default is true.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ArcGISProperty]
    public bool? SnappingControls { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.SketchWidgetVisibleElements.html#sketchwidgetvisibleelementssnappingcontrolselements-property">GeoBlazor Docs</a>
    ///     The available SnappingControls elements within the widget.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public SnappingControlsElements? SnappingControlsElements { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.SketchWidgetVisibleElements.html#sketchwidgetvisibleelementstooltipstoggle-property">GeoBlazor Docs</a>
    ///     Indicates whether to display the tooltips toggle. Default value is true.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? TooltipsToggle { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.SketchWidgetVisibleElements.html#sketchwidgetvisibleelementssettingsmenu-property">GeoBlazor Docs</a>
    ///     Indicates whether to display the settings menu. Currently this menu contains snapping options. Default value is true.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? SettingsMenu { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.SketchWidgetVisibleElements.html#sketchwidgetvisibleelementsundoredomenu-property">GeoBlazor Docs</a>
    ///     Indicates whether to display the undo/redo menu within the widget. Default is true.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? UndoRedoMenu { get; set; }
    
#endregion
    
    #region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the CreateTools property.
    /// </summary>
    public async Task<CreateTools?> GetCreateTools()
    {
        if (CoreJsModule is null)
        {
            return CreateTools;
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
            return CreateTools;
        }

        CreateTools? result = await JsComponentReference.InvokeAsync<CreateTools?>(
            "getCreateTools", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            CreateTools = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(CreateTools)] = CreateTools;
        }
        
        return CreateTools;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the DeleteButton property.
    /// </summary>
    public async Task<bool?> GetDeleteButton()
    {
        if (CoreJsModule is null)
        {
            return DeleteButton;
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
            return DeleteButton;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "deleteButton");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             DeleteButton = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(DeleteButton)] = DeleteButton;
        }
         
        return DeleteButton;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the DuplicateButton property.
    /// </summary>
    public async Task<bool?> GetDuplicateButton()
    {
        if (CoreJsModule is null)
        {
            return DuplicateButton;
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
            return DuplicateButton;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "duplicateButton");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             DuplicateButton = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(DuplicateButton)] = DuplicateButton;
        }
         
        return DuplicateButton;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the LabelsToggle property.
    /// </summary>
    public async Task<bool?> GetLabelsToggle()
    {
        if (CoreJsModule is null)
        {
            return LabelsToggle;
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
            return LabelsToggle;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "labelsToggle");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             LabelsToggle = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(LabelsToggle)] = LabelsToggle;
        }
         
        return LabelsToggle;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SelectionCountLabel property.
    /// </summary>
    public async Task<bool?> GetSelectionCountLabel()
    {
        if (CoreJsModule is null)
        {
            return SelectionCountLabel;
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
            return SelectionCountLabel;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "selectionCountLabel");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             SelectionCountLabel = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SelectionCountLabel)] = SelectionCountLabel;
        }
         
        return SelectionCountLabel;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SelectionTools property.
    /// </summary>
    public async Task<SelectionTools?> GetSelectionTools()
    {
        if (CoreJsModule is null)
        {
            return SelectionTools;
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
            return SelectionTools;
        }

        SelectionTools? result = await JsComponentReference.InvokeAsync<SelectionTools?>(
            "getSelectionTools", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            SelectionTools = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(SelectionTools)] = SelectionTools;
        }
        
        return SelectionTools;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SettingsMenu property.
    /// </summary>
    public async Task<bool?> GetSettingsMenu()
    {
        if (CoreJsModule is null)
        {
            return SettingsMenu;
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
            return SettingsMenu;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "settingsMenu");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             SettingsMenu = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SettingsMenu)] = SettingsMenu;
        }
         
        return SettingsMenu;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SnappingControls property.
    /// </summary>
    public async Task<bool?> GetSnappingControls()
    {
        if (CoreJsModule is null)
        {
            return SnappingControls;
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
            return SnappingControls;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "snappingControls");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             SnappingControls = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SnappingControls)] = SnappingControls;
        }
         
        return SnappingControls;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SnappingControlsElements property.
    /// </summary>
    public async Task<SnappingControlsElements?> GetSnappingControlsElements()
    {
        if (CoreJsModule is null)
        {
            return SnappingControlsElements;
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
            return SnappingControlsElements;
        }

        SnappingControlsElements? result = await JsComponentReference.InvokeAsync<SnappingControlsElements?>(
            "getSnappingControlsElements", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            SnappingControlsElements = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(SnappingControlsElements)] = SnappingControlsElements;
        }
        
        return SnappingControlsElements;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the TooltipsToggle property.
    /// </summary>
    public async Task<bool?> GetTooltipsToggle()
    {
        if (CoreJsModule is null)
        {
            return TooltipsToggle;
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
            return TooltipsToggle;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "tooltipsToggle");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             TooltipsToggle = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(TooltipsToggle)] = TooltipsToggle;
        }
         
        return TooltipsToggle;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the UndoRedoMenu property.
    /// </summary>
    public async Task<bool?> GetUndoRedoMenu()
    {
        if (CoreJsModule is null)
        {
            return UndoRedoMenu;
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
            return UndoRedoMenu;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "undoRedoMenu");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             UndoRedoMenu = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(UndoRedoMenu)] = UndoRedoMenu;
        }
         
        return UndoRedoMenu;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the CreateTools property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetCreateTools(CreateTools? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        CreateTools = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(CreateTools)] = value;
        
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
            JsComponentReference, "createTools", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the DeleteButton property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetDeleteButton(bool? value)
    {
#pragma warning disable BL0005
        DeleteButton = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(DeleteButton)] = value;
        
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
            JsComponentReference, "deleteButton", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the DuplicateButton property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetDuplicateButton(bool? value)
    {
#pragma warning disable BL0005
        DuplicateButton = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(DuplicateButton)] = value;
        
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
            JsComponentReference, "duplicateButton", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the LabelsToggle property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetLabelsToggle(bool? value)
    {
#pragma warning disable BL0005
        LabelsToggle = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(LabelsToggle)] = value;
        
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
            JsComponentReference, "labelsToggle", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SelectionCountLabel property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSelectionCountLabel(bool? value)
    {
#pragma warning disable BL0005
        SelectionCountLabel = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SelectionCountLabel)] = value;
        
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
            JsComponentReference, "selectionCountLabel", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SelectionTools property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSelectionTools(SelectionTools? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        SelectionTools = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SelectionTools)] = value;
        
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
            JsComponentReference, "selectionTools", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SettingsMenu property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSettingsMenu(bool? value)
    {
#pragma warning disable BL0005
        SettingsMenu = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SettingsMenu)] = value;
        
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
            JsComponentReference, "settingsMenu", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SnappingControls property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSnappingControls(bool? value)
    {
#pragma warning disable BL0005
        SnappingControls = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SnappingControls)] = value;
        
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
            JsComponentReference, "snappingControls", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SnappingControlsElements property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSnappingControlsElements(SnappingControlsElements? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        SnappingControlsElements = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SnappingControlsElements)] = value;
        
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
            JsComponentReference, "snappingControlsElements", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the TooltipsToggle property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetTooltipsToggle(bool? value)
    {
#pragma warning disable BL0005
        TooltipsToggle = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(TooltipsToggle)] = value;
        
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
            JsComponentReference, "tooltipsToggle", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the UndoRedoMenu property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetUndoRedoMenu(bool? value)
    {
#pragma warning disable BL0005
        UndoRedoMenu = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(UndoRedoMenu)] = value;
        
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
            JsComponentReference, "undoRedoMenu", value);
    }
    
#endregion
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case CreateTools createTools:
                if (createTools != CreateTools)
                {
                    CreateTools = createTools;
                    ModifiedParameters[nameof(CreateTools)] = CreateTools;
                }
                
                break;
            case SelectionTools selectionTools:
                if (selectionTools != SelectionTools)
                {
                    SelectionTools = selectionTools;
                    ModifiedParameters[nameof(SelectionTools)] = SelectionTools;
                }
                
                break;
            case SnappingControlsElements snappingControlsElements:
                if (snappingControlsElements != SnappingControlsElements)
                {
                    SnappingControlsElements = snappingControlsElements;
                    ModifiedParameters[nameof(SnappingControlsElements)] = SnappingControlsElements;
                }
                
                break;
            default:
                await base.RegisterGeneratedChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case CreateTools _:
                CreateTools = null;
                ModifiedParameters[nameof(CreateTools)] = CreateTools;

                break;
            case SelectionTools _:
                SelectionTools = null;
                ModifiedParameters[nameof(SelectionTools)] = SelectionTools;
                
                break;
            case SnappingControlsElements _:
                SnappingControlsElements = null;
                ModifiedParameters[nameof(SnappingControlsElements)] = SnappingControlsElements;
                
                break;
            default:
                await base.UnregisterGeneratedChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
    
        CreateTools?.ValidateRequiredChildren();
        SelectionTools?.ValidateRequiredChildren();
        SnappingControlsElements?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
      

}