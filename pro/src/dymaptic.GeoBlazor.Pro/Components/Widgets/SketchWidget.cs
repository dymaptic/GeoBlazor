namespace dymaptic.GeoBlazor.Pro.Components.Widgets;

public partial class SketchWidget : ProWidget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Sketch;

    /// <summary>
    ///     Defines the default behavior once the create operation is completed. By default, the user will be able to continuously create graphics with same geometry types.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CreationMode? CreationMode { get; set; }

    /// <summary>
    ///     Default create options set for the Sketch widget.
    /// </summary>
    [Parameter]
    public SketchToolCreateOptions? DefaultCreateOptions { get; set; }

    /// <summary>
    ///     Default update options set for the Sketch widget. Update options set on this property will be overwritten if the update options are changed when update() method is called.
    /// </summary>
    [Parameter]
    public SketchToolUpdateOptions? DefaultUpdateOptions { get; set; }

    /// <summary>
    ///     Options to configure the labels shown next to each segment of the geometry being created or updated.
    /// </summary>
    [Parameter]
    public SketchLabelOptions? LabelOptions { get; set; }

    /// <summary>
    ///     Determines the layout/orientation of the Sketch widget.
    /// </summary>
    [Parameter]
    public SketchWidgetLayout? Layout { get; set; }

    /// <summary>
    ///     Options to configure the tooltip shown next to the cursor when creating or updating graphics.
    /// </summary>
    [Parameter]
    public SketchTooltipOptions? TooltipOptions { get; set; }

    /// <summary>
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UpdateOnGraphicClick { get; set; }

    /// <summary>
    ///     Event Callback for handling all sketch Events.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SketchEvent> OnSketchEvent { get; set; }

    /// <summary>
    ///     Id reference to the editable graphics layer
    /// </summary>
    [Parameter]
    [RequiredProperty(nameof(GraphicsLayer), nameof(Layer), nameof(LayerId))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Guid? GraphicsLayerId { get; set; }

    /// <summary>
    ///     Controls how often the events are fired.
    /// </summary>
    [Parameter]
    public int EventRateLimitInMilliseconds { get; set; } = 100;

    /// <summary>
    ///     The <see cref="GraphicsLayer"/> to which the sketch widget is bound.
    /// </summary>
    [Parameter]
    [RequiredProperty(nameof(GraphicsLayerId), nameof(Layer), nameof(LayerId))]
    [JsonIgnore]
    public GraphicsLayer? GraphicsLayer { get; set; }

        /// <summary>
    ///     The relevant Layer for the MapComponent. Not always applicable to every component type.
    /// </summary>
    [JsonIgnore]
    [Parameter]
    [RequiredProperty(nameof(GraphicsLayer), nameof(GraphicsLayerId), nameof(LayerId))]
    public override Layer? Layer { get; set; }

    /// <summary>
    ///     The Id of the relevant Layer for the MapComponent. Not always applicable to every component type.
    /// </summary>
    [Parameter]
    [RequiredProperty(nameof(GraphicsLayer), nameof(Layer), nameof(GraphicsLayerId))]
    public override Guid? LayerId { get; set; }

    /// <summary>
    ///     When creating new graphics (for example after create() has been called), this property reflects the create tool being used. When updating graphics (for example after update() has been called), this property reflects the update tool being used. If no create or update operation is in progress, this is null.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<SketchTool?> GetActiveTool()
    {
        if (JsComponentReference is null) return null;

        return await JsComponentReference.InvokeAsync<SketchTool>("getActiveTool");
    }

    /// <summary>
    ///     Returns the graphic that is being created.
    /// </summary>
    public async Task<Graphic?> GetCreateGraphic()
    {
        if (JsComponentReference is null) return null;

        if (GraphicsLayer is null)
        {
            throw new InvalidOperationException("GraphicsLayer is not set.");
        }

        Graphic graphic = await JsComponentReference.InvokeAsync<Graphic>("getCreateGraphic");
        GraphicsLayer!.RegisterExistingGraphicsFromJavaScript([graphic]);

        return graphic;
    }

    /// <summary>
    ///     An array of graphics that are being updated by the Sketch widget.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<Graphic[]?> GetUpdateGraphics()
    {
        if (JsComponentReference is null) return null;

        if (GraphicsLayer is null)
        {
            throw new InvalidOperationException("GraphicsLayer is not set.");
        }

        Graphic[] graphics = await JsComponentReference.InvokeAsync<Graphic[]>("getUpdateGraphics");
        GraphicsLayer!.RegisterExistingGraphicsFromJavaScript(graphics);

        return graphics;
    }

    /// <summary>
    ///     Cancels the active operation and fires the create or update event. If called in the middle of a create operation, cancel() discards the partially created graphic.
    /// </summary>
    [ArcGISMethod]
    public async Task Cancel()
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("cancel");
    }

    /// <summary>
    ///     Completes the active operation and fires the create or update event and changes the event's state to complete. If called in the middle of a create operation, complete() finishes the active create operation and keeps the valid geometry.
    /// </summary>
    [ArcGISMethod]
    public async Task Complete()
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("complete");
    }

    /// <summary>
    ///     Create a graphic with the geometry specified in the tool parameter. When the first vertex of the graphic is added, the create event will start firing. The provided tool will become the activeTool.
    /// </summary>
    /// <param name="tool">
    ///     Name of the create tool. Specifies the geometry for the graphic to be created.
    ///     Possible Values:"point"|"polyline"|"polygon"|"rectangle"|"circle"
    /// </param>
    /// <param name="options">
    ///     Options for the graphic to be created.
    /// </param>
    [CodeGenerationIgnore]
    public async Task Create(SketchTool tool, SketchToolCreateOptions options)
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("create", tool, options);
    }

    /// <summary>
    ///     Deletes the selected graphics used in the update workflow. Calling this method will fire the delete event.
    /// </summary>
    [ArcGISMethod]
    public async Task Delete()
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("delete");
    }

    /// <summary>
    ///     Duplicates current graphics used in the update workflow and automatically adds them to the associated layer
    /// </summary>
    [ArcGISMethod]
    public async Task Duplicate()
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("duplicate");
    }

    /// <summary>
    ///     Incrementally redo actions recorded in the stack. Calling this method will fire the redo event. The undo/redo stack is for an individual sketch operation, meaning you can redo/undo actions while creating or updating a graphic.
    /// </summary>
    [ArcGISMethod]
    public async Task Redo()
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("redo");
    }

    /// <summary>
    ///     Incrementally undo actions recorded in the stack. Calling this method will fire the undo event. The undo/redo stack is for an individual sketch operation, meaning you can redo/undo actions while creating or updating a graphic.
    /// </summary>
    [ArcGISMethod]
    public async Task Undo()
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("undo");
    }

    /// <summary>
    ///     Initializes an update operation for the specified graphic(s) and fires update event.
    /// </summary>
    /// <param name="graphics">
    ///     A graphic or an array of graphics to be updated. Only graphics added to SketchViewModel's layer property can be updated.
    /// </param>
    /// <param name="options">
    ///     Update options for the graphics to be updated.
    /// </param>
    [CodeGenerationIgnore]
    public async Task Update(IEnumerable<Graphic> graphics, SketchToolUpdateOptions options)
    {
        if (JsComponentReference is null) return;

        await JsComponentReference.InvokeVoidAsync("update", graphics, options);
    }

    /// <inheritdoc />
    public override async Task SetLayer(Layer? value)
    {
#pragma warning disable BL0005
        GraphicsLayer = value as GraphicsLayer;
        GraphicsLayerId = value?.Id;
        LayerId = value?.Id;
#pragma warning restore BL0005

        await base.SetLayer(value);
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        // Seed the ids from whichever identifier the caller supplied.
        LayerId ??= GraphicsLayerId ?? Layer?.Id ?? GraphicsLayer?.Id;
        GraphicsLayerId ??= LayerId;

        // If only an id was supplied, resolve the concrete layer from the map.
        if (GraphicsLayer is null && Layer is null && GraphicsLayerId is not null)
        {
            GraphicsLayer = View?.Map?.Layers
                .FirstOrDefault(l => l.Id == GraphicsLayerId) as GraphicsLayer;
        }

        Layer ??= GraphicsLayer;
        GraphicsLayer ??= Layer as GraphicsLayer;

        // The concrete layer reference is the source of truth for the id. The reference can be
        // swapped after the first render (e.g. a `= new()` field initializer that an @ref later
        // overwrites with the real map instance), so always re-sync the ids to the current
        // instance instead of trusting the first ??= value. A stale id makes the JS
        // arcGisObjectRefs[graphicsLayerId] lookup in buildJsSketchWidget miss, leaving the
        // Sketch widget with no layer and every toolbar tool disabled.
        if (GraphicsLayer is not null)
        {
            Layer = GraphicsLayer;
            GraphicsLayerId = GraphicsLayer.Id;
            LayerId = GraphicsLayer.Id;
        }
        else if (Layer is not null)
        {
            GraphicsLayer = Layer as GraphicsLayer;
            GraphicsLayerId = Layer.Id;
            LayerId = Layer.Id;
        }
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (Layer is null)
        {
            Layer = View?.Map?.Layers.FirstOrDefault(l => l.Id == GraphicsLayerId) as GraphicsLayer;
            if (Layer is not null)
            {
                // Mirror OnParametersSet: the resolved layer instance is the source of truth for
                // the id, so hard-sync rather than ??= to avoid serializing a stale id.
                GraphicsLayer = Layer as GraphicsLayer;
                GraphicsLayerId = Layer.Id;
                LayerId = Layer.Id;
            }
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    /// <inheritdoc />
    public override void UpdateGeoBlazorReferences(IJSObjectReference coreJsModule, IJSObjectReference? proJsModule, 
        MapView? view, IMapComponent? parent, Layer? layer, int depth = 0, HashSet<object>? visited = null)
    {
        if (layer is not null && layer != GraphicsLayer)
        {
            GraphicsLayer = layer as GraphicsLayer;
        }

        base.UpdateGeoBlazorReferences(coreJsModule, proJsModule, view, parent, layer, depth, visited);
    }



#region Event Handlers

    /// <summary>
    ///     JavaScript-Invokable Method for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsCreate(IJSStreamReference jsStreamRef)
    {
        if (GraphicsLayer is null)
        {
            throw new InvalidOperationException("GraphicsLayer is not set.");   
        }

        SketchCreateEvent? createEvent = await jsStreamRef.ReadJsStreamReference<SketchCreateEvent>();

        if (createEvent is null)
        {
            return;
        }
        
        if (createEvent is { State: SketchEventState.Complete, Graphic: not null })
        {
            GraphicsLayer!.RegisterExistingGraphicsFromJavaScript([createEvent.Graphic]);
        }

        await OnCreate.InvokeAsync(createEvent);

        await OnSketchEvent.InvokeAsync(new SketchEvent
        {
            EventType = SketchEventType.Create,
            State = createEvent.State,
            Graphics = createEvent.Graphic is null ? [] : [createEvent.Graphic],
            Tool = createEvent.Tool is null ? null : (SketchEventTool)(int)createEvent.Tool,
            ToolEventInfo = createEvent.ToolEventInfo as ToolEventInfo
        });
    }

    /// <summary>
    ///     Event Listener for Create.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public EventCallback<SketchCreateEvent> OnCreate { get; set; }

    /// <summary>
    ///     JavaScript-Invokable Method for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsDelete(IJSStreamReference jsStreamRef)
    {
        if (GraphicsLayer is null)
        {
            throw new InvalidOperationException("GraphicsLayer is not set.");   
        }

        SketchDeleteEvent? deleteEvent = await jsStreamRef.ReadJsStreamReference<SketchDeleteEvent>();
        
        if (deleteEvent is null)
        {
            return;
        }
        
        if (deleteEvent.Graphics is not null)
        {
            await GraphicsLayer!.Remove(deleteEvent.Graphics);
        }

        await OnDelete.InvokeAsync(deleteEvent);

        await OnSketchEvent.InvokeAsync(new SketchEvent
        {
            EventType = SketchEventType.Delete,
            Graphics = deleteEvent.Graphics?.ToArray() ?? [],
            Tool = deleteEvent.Tool is null ? null : (SketchEventTool)(int)deleteEvent.Tool
        });
    }

    /// <summary>
    ///     Event Listener for Delete.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public EventCallback<SketchDeleteEvent> OnDelete { get; set; }

    /// <summary>
    ///     JavaScript-Invokable Method for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsRedo(IJSStreamReference jsStreamRef)
    {
        if (GraphicsLayer is null)
        {
            throw new InvalidOperationException("GraphicsLayer is not set.");   
        }

        SketchRedoEvent? redoEvent = await jsStreamRef.ReadJsStreamReference<SketchRedoEvent>();
        
        if (redoEvent is null)
        {
            return;
        }
        
        if (redoEvent.Graphics is not null)
        {
            foreach (Graphic graphic in redoEvent.Graphics)
            {
                if (!GraphicsLayer!.Graphics.Contains(graphic))
                {
                    GraphicsLayer!.RegisterExistingGraphicsFromJavaScript([graphic]);
                }

                await graphic.GetGeometry();
            }
        }

        await OnRedo.InvokeAsync(redoEvent);

        await OnSketchEvent.InvokeAsync(new SketchEvent
        {
            EventType = SketchEventType.Redo,
            Graphics = redoEvent.Graphics?.ToArray() ?? [],
            Tool = redoEvent.Tool is null ? null : (SketchEventTool)(int)redoEvent.Tool
        });
    }

    /// <summary>
    ///     Event Listener for Redo.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public EventCallback<SketchRedoEvent> OnRedo { get; set; }

    /// <summary>
    ///     JavaScript-Invokable Method for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsUndo(IJSStreamReference jsStreamRef)
    {
        if (GraphicsLayer is null)
        {
            throw new InvalidOperationException("GraphicsLayer is not set.");   
        }

        SketchUndoEvent? undoEvent = await jsStreamRef.ReadJsStreamReference<SketchUndoEvent>();
        
        if (undoEvent is null)
        {
            return;
        }
        
        if (undoEvent.Graphics is not null)
        {
            foreach (Graphic graphic in undoEvent.Graphics)
            {
                await graphic.GetGeometry();
            }
        }

        await OnUndo.InvokeAsync(undoEvent);

        await OnSketchEvent.InvokeAsync(new SketchEvent
        {
            EventType = SketchEventType.Undo,
            Graphics = undoEvent.Graphics?.ToArray() ?? [],
            Tool = undoEvent.Tool is null ? null : (SketchEventTool)(int)undoEvent.Tool
        });
    }

    /// <summary>
    ///     Event Listener for Undo.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public EventCallback<SketchUndoEvent> OnUndo { get; set; }

    /// <summary>
    ///     JavaScript-Invokable Method for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsUpdate(IJSStreamReference jsStreamRef)
    {
        if (GraphicsLayer is null)
        {
            throw new InvalidOperationException("GraphicsLayer is not set.");   
        }

        SketchUpdateEvent? updateEvent = await jsStreamRef.ReadJsStreamReference<SketchUpdateEvent>();
        
        if (updateEvent is null)
        {
            return;
        }
        
        if (updateEvent is { State: SketchEventState.Complete, Graphics: not null })
        {
            foreach (Graphic graphic in updateEvent.Graphics)
            {
                if (!GraphicsLayer!.Graphics.Contains(graphic))
                {
                    GraphicsLayer!.RegisterExistingGraphicsFromJavaScript([graphic]);
                }

                await graphic.GetGeometry();
            }
        }

        await OnUpdate.InvokeAsync(updateEvent);

        await OnSketchEvent.InvokeAsync(new SketchEvent
        {
            EventType = SketchEventType.Update,
            State = updateEvent.State,
            Graphics = updateEvent.Graphics?.ToArray() ?? [],
            Tool = updateEvent.Tool is null ? null : (SketchEventTool)(int)updateEvent.Tool,
            ToolEventInfo = updateEvent.ToolEventInfo as ToolEventInfo
        });
    }

    /// <summary>
    ///     Event Listener for Update.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public EventCallback<SketchUpdateEvent> OnUpdate { get; set; }

#endregion


    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SketchWidgetVisibleElements visibleElements:
                if (!visibleElements.Equals(VisibleElements))
                {
                    VisibleElements = visibleElements;
                    if (MapRendered)
                    {
                        await UpdateWidget();
                    }
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
            case SketchWidgetVisibleElements _:
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
    }
}