using ParameterValue = Microsoft.AspNetCore.Components.ParameterValue;

namespace dymaptic.GeoBlazor.Core.Components;

public partial class Graphic: MapComponent, IEquatable<Graphic>
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public Graphic()
    {
        Attributes.OnChange = OnAttributesChanged;
        ToSerializationRecord();
    }

    /// <summary>
    ///     Constructor for use in C# code.
    /// </summary>
    /// <param name="geometry">
    ///     The geometry that defines the graphic's location.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="symbol">
    ///     The [Symbol](https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Symbol.html) for the graphic.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#symbol">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="popupTemplate">
    ///     The template for displaying content in a [Popup](https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html) when the graphic is selected.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#popupTemplate">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="attributes">
    ///     Name-value pairs of fields and field values associated with the graphic.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#attributes">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visible">
    /// </param>
    /// <param name="legendLabel">
    /// </param>
    /// <param name="aggregateGeometries">
    ///     The aggregateGeometries contains spatial aggregation geometries when [statistics](https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-StatisticDefinition.html#statisticType) query is executed with `envelope-aggregate`, `centroid-aggregate` and/or `convex-hull-aggregate` statistics type.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#aggregateGeometries">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="origin">
    ///     Returns information about an origin of a graphic if applicable.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#origin">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public Graphic(
        Geometry? geometry = null,
        Symbol? symbol = null,
        PopupTemplate? popupTemplate = null,
        AttributesDictionary? attributes = null,
        bool? visible = null,
        string? legendLabel = null,
        object? aggregateGeometries = null,
        GraphicOrigin? origin = null)
    {
#pragma warning disable BL0005
        Geometry = geometry;
        Symbol = symbol;
        PopupTemplate = popupTemplate;
        if (attributes is not null)
        {
            Attributes = attributes;
        }
        Visible = visible;
        LegendLabel = legendLabel;
        AggregateGeometries = aggregateGeometries;
        Origin = origin;
#pragma warning restore BL0005    
        Attributes.OnChange = OnAttributesChanged;
        ToSerializationRecord();
    }
    
#region public properties
    
    /// <summary>
    ///     Name-value pairs of fields and field values associated with the graphic.
    /// </summary>
    /// <remarks>
    ///     This collection should only be set via the constructor or as a markup parameter/attribute. To add or remove
    ///     members, use the methods defined in <see cref = "AttributesDictionary"/>
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public AttributesDictionary Attributes { get; set; } = new();
    
    /// <summary>
    ///     The geometry that defines the graphic's location.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? Geometry { get; set; }
    
    /// <summary>
    ///     Returns information about an origin of a graphic if applicable.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#origin">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GraphicOrigin? Origin { get; set; }
    
    /// <summary>
    ///     Legend label override for this graphic in the GeoBlazor Pro Graphics Legend Widget.
    ///     Supports attribute substitution using the syntax {attributeName}.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public string? LegendLabel { get; set; }
    
    /// <summary>
    ///     The template for displaying content in a [Popup](https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html) when the graphic is selected.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#popupTemplate">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PopupTemplate? PopupTemplate { get; set; }
    
    /// <summary>
    ///     The [Symbol](https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Symbol.html) for the graphic.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#symbol">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Symbol? Symbol { get; set; }
    

    /// <summary>
    ///     Indicates whether the graphic refers to an aggregate, or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureReductionCluster.html">cluster</a> graphic.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#isAggregate">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    [JsonInclude]
    public bool? IsAggregate { get; protected set; }
    
#endregion

#region Property Getters
    
    /// <summary>
    ///     Retrieves the <see cref = "Geometry"/> from the rendered graphic.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<Geometry?> GetGeometry()
    {
        if (CoreJsModule is not null)
        {
            Geometry = await CoreJsModule.InvokeAsync<Geometry>("getGraphicGeometry", 
                CancellationTokenSource.Token, Id, LayerId, View?.Id);
        }

        return Geometry;
    }
    
    /// <summary>
    ///     Gets the current <see cref = "Symbol"/> for the object.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<Symbol?> GetSymbol()
    {
        if (CoreJsModule is not null)
        {
            Symbol = await CoreJsModule.InvokeAsync<Symbol>("getGraphicSymbol", CancellationTokenSource.Token, 
                Id, LayerId, View?.Id);
        }

        return Symbol;
    }

    /// <summary>
    ///     Retrieves the <see cref = "PopupTemplate"/> from the rendered graphic.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<PopupTemplate?> GetPopupTemplate()
    {
        if (CoreJsModule is not null)
        {
            PopupTemplate = await CoreJsModule.InvokeAsync<PopupTemplate>("getGraphicPopupTemplate", 
                CancellationTokenSource.Token, Id, LayerId, View?.Id);
        }

        return PopupTemplate;
    }
    
    [CodeGenerationIgnore]
    public Task<Layer?> GetLayer()
    {
        return Task.FromResult(Parent as Layer);
    }

    /// <summary>
    ///     Asynchronously retrieve the current value of the AggregateGeometries property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<object?> GetAggregateGeometries()
    {
        if (CoreJsModule is null)
        {
            return AggregateGeometries;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return AggregateGeometries;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "aggregateGeometries");
        if (result is not null)
        {
#pragma warning disable BL0005
             AggregateGeometries = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(AggregateGeometries)] = AggregateGeometries;
        }
         
        return AggregateGeometries;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the IsAggregate property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<bool?> GetIsAggregate()
    {
        if (CoreJsModule is null)
        {
            return IsAggregate;
        }
        
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return IsAggregate;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "isAggregate");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             IsAggregate = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(IsAggregate)] = IsAggregate;
        }
         
        return IsAggregate;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Origin property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<GraphicOrigin?> GetOrigin()
    {
        if (CoreJsModule is null)
        {
            return Origin;
        }

        // get the property value
        GraphicOrigin? result = await JsComponentReference!.InvokeAsync<GraphicOrigin?>("getProperty",
            CancellationTokenSource.Token, "origin");
        if (result is not null)
        {
#pragma warning disable BL0005
             Origin = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Origin)] = Origin;
        }
         
        return Origin;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///     Sets the <see cref = "Geometry"/> on the rendered graphic.
    /// </summary>
    /// <param name="geometry"></param>
    [CodeGenerationIgnore]
    public async Task SetGeometry(Geometry geometry)
    {
        Geometry = geometry;
        if (CoreJsModule is not null)
        {
            await CoreJsModule.InvokeVoidAsync("setGraphicGeometry", Id, LayerId, View?.Id,
                Geometry.ToSerializationRecord());
        }
        else
        {
            _updateGeometry = true;
        }

        _serializationRecord = null;
        ToSerializationRecord();
    }

    /// <summary>
    ///     Sets the <see cref = "Symbol"/> for the object.
    /// </summary>
    /// <param name="symbol">
    ///     The <see cref = "Symbol"/> for the object.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetSymbol(Symbol symbol)
    {
        Symbol = symbol;
        if (CoreJsModule is not null)
        {
            await CoreJsModule.InvokeVoidAsync("setGraphicSymbol", Id, Symbol.ToSerializationRecord(),
                LayerId, View?.Id);
        }
        else
        {
            _updateSymbol = true;
        }

        _serializationRecord = null;
        ToSerializationRecord();
    }

    /// <summary>
    ///     Sets the <see cref = "PopupTemplate"/> on the rendered graphic.
    /// </summary>
    /// <param name="popupTemplate">
    ///     The <see cref = "PopupTemplate"/> for displaying content in a Popup when the graphic is selected.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetPopupTemplate(PopupTemplate popupTemplate)
    {
        var oldTemplate = PopupTemplate;
        PopupTemplate = popupTemplate;
        if (CoreJsModule is not null)
        {
            if (oldTemplate != null)
            {
                await CoreJsModule.InvokeVoidAsync("removeGraphicPopupTemplate", Id, oldTemplate.ToSerializationRecord(), oldTemplate.DotNetComponentReference, View?.Id);
            }

            await CoreJsModule.InvokeVoidAsync("setGraphicPopupTemplate", Id, PopupTemplate.ToSerializationRecord(), PopupTemplate.DotNetComponentReference, View?.Id);
        }
        else
        {
            _updatePopupTemplate = true;
        }

        _serializationRecord = null;
        ToSerializationRecord();
    }

    /// <summary>
    ///    Asynchronously set the value of the AggregateGeometries property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetAggregateGeometries(string? value)
    {
#pragma warning disable BL0005
        AggregateGeometries = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(AggregateGeometries)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "aggregateGeometries", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Origin property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetOrigin(GraphicOrigin? value)
    {
#pragma warning disable BL0005
        Origin = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Origin)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setGraphicOrigin", CancellationTokenSource.Token,
            Id, value, LayerId, ViewId);
    }
    
#endregion

#region Public Methods

    /// <summary>
    ///     Returns the value of the specified attribute.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#getAttribute">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="name">
    ///     The name of the attribute.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task<object?> GetAttribute(string name)
    {
        if (CoreJsModule is not null)
        {
            Attributes = await CoreJsModule.InvokeAsync<AttributesDictionary>("getGraphicAttributes", 
                CancellationTokenSource.Token, Id, LayerId, ViewId);
        }
        
        return Attributes.TryGetValue(name, out object? value) ? value : null;
    }
    
    /// <summary>
    ///     Returns the popup template applicable for the graphic.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#getEffectivePopupTemplate">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="defaultPopupTemplateEnabled">
    ///     Whether support for default popup templates
    ///     is enabled. When true, a default popup template may be created automatically if neither
    ///     the graphic nor its layer have a popup template defined.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task<PopupTemplate?> GetEffectivePopupTemplate(bool defaultPopupTemplateEnabled)
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference!.InvokeAsync<PopupTemplate?>(
            "getEffectivePopupTemplate", 
            CancellationTokenSource.Token,
            defaultPopupTemplateEnabled);
    }
    
    /// <summary>
    ///     Returns the Object ID of the feature associated with the graphic, if it exists.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#getObjectId">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task<long?> GetObjectId()
    {
        if (CoreJsModule is null) return null;
        
        return await CoreJsModule!.InvokeAsync<long?>(
            "getObjectIdForGraphic", 
            CancellationTokenSource.Token,
            Id, LayerId, ViewId);
    }
    
    /// <summary>
    ///     Sets a new value to the specified attribute.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#setAttribute">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="name">
    ///     The name of the attribute to set.
    /// </param>
    /// <param name="newValue">
    ///     The new value to set on the named attribute.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task SetAttribute(string name,
        string newValue)
    {
        await Attributes.AddOrUpdate(name, newValue);

        if (CoreJsModule is not null)
        {
            await CoreJsModule.InvokeVoidAsync("setGraphicAttributes",
                CancellationTokenSource.Token, Id, LayerId, ViewId);
        }
    }
    
#endregion

    /// <inheritdoc/>
    public override async ValueTask DisposeAsync()
    {
        await base.DisposeAsync();

        try
        {
            if (CoreJsModule is not null)
            {
                await CoreJsModule.InvokeVoidAsync("disposeGraphic", Id);
            }
        }
        catch (TaskCanceledException)
        {
            // user cancelled
        }
        catch (JSDisconnectedException)
        {
            // lost connection (page navigation)
        }
        catch (JSException)
        {
            // instance already destroyed
        }
    }

    /// <inheritdoc/>
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        foreach (ParameterValue parameterValue in parameters)
        {
            if (parameterValue is { Name: nameof(Attributes), Value: AttributesDictionary attributeDictionary })
            {
                if (!Attributes.Equals(attributeDictionary))
                {
                    Attributes = attributeDictionary;
                    _updateAttributes = true;
                }

                Attributes.OnChange ??= OnAttributesChanged;
            }
        }

        await base.SetParametersAsync(parameters);
    }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Symbol symbol:

                await SetSymbol(symbol);

                break;
            case Geometry geometry:
                if (View?.ExtentChangedInJs == true)
                {
                    return;
                }

                await SetGeometry(geometry);

                break;
            case PopupTemplate popupTemplate:
                if (View?.ExtentChangedInJs == true)
                {
                    return;
                }

                await SetPopupTemplate(popupTemplate);

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }

        ToSerializationRecord(true);
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Symbol _:
                Symbol = null;

                break;
            case Geometry _:
                Geometry = null;

                break;
            case PopupTemplate _:
                PopupTemplate = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Symbol?.ValidateRequiredChildren();
        Geometry?.ValidateRequiredChildren();
        PopupTemplate?.ValidateRequiredChildren();
    }

    internal GraphicSerializationRecord ToSerializationRecord(bool refresh = false)
    {
        if (_serializationRecord is null || refresh)
        {
            _serializationRecord = new GraphicSerializationRecord(Id.ToString(), Geometry?.ToSerializationRecord(), 
                Symbol?.ToSerializationRecord(), PopupTemplate?.ToSerializationRecord(), 
                Attributes.ToSerializationRecord(), Visible, JsonSerializer.Serialize(AggregateGeometries), 
                Origin?.ToSerializationRecord(), LayerId?.ToString(), ViewId?.ToString());
        }

        return _serializationRecord;
    }

    /// <inheritdoc/>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (CoreJsModule is not null)
        {
            if (_updateSymbol)
            {
                _updateSymbol = false;
                await SetSymbol(Symbol!);
            }

            if (_updateGeometry)
            {
                _updateGeometry = false;
                await SetGeometry(Geometry!);
            }

            if (_updatePopupTemplate)
            {
                _updatePopupTemplate = false;
                await SetPopupTemplate(PopupTemplate!);
            }

            if (_updateAttributes)
            {
                _updateAttributes = false;
                await OnAttributesChanged();
            }
        }
    }

    private async Task OnAttributesChanged()
    {
        if (CoreJsModule is null)
            return;
        await CoreJsModule.InvokeVoidAsync("setGraphicAttributes", CancellationTokenSource.Token, Id, 
            Attributes, LayerId, View?.Id);
        ToSerializationRecord(true);
    }

    private GraphicSerializationRecord? _serializationRecord;
    private bool _updateGeometry;
    private bool _updateSymbol;
    private bool _updatePopupTemplate;
    private bool _updateAttributes;

    public bool Equals(Graphic? other)
    {
        if (other is null)
            return false;
        if (ReferenceEquals(this, other))
            return true;
        if (IsRenderedBlazorComponent)
        {
            if (!other.IsRenderedBlazorComponent)
            {
                return false;
            }
        }

        return Equals(Id, other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;
        return Equals((Graphic)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Graphic? left, Graphic? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Graphic? left, Graphic? right)
    {
        return !Equals(left, right);
    }
}

[ProtoContract(Name = "Graphic")]
internal record GraphicSerializationRecord : MapComponentSerializationRecord
{
    public GraphicSerializationRecord()
    {
    }

    public GraphicSerializationRecord(string Id, GeometrySerializationRecord? Geometry, 
        SymbolSerializationRecord? Symbol, PopupTemplateSerializationRecord? PopupTemplate, 
        AttributeSerializationRecord[]? Attributes, bool? Visible, string? AggregateGeometries,
        GraphicOriginSerializationRecord? Origin, string? LayerId, string? ViewId)
    {
        this.Id = Id;
        this.Geometry = Geometry;
        this.Symbol = Symbol;
        this.PopupTemplate = PopupTemplate;
        this.Attributes = Attributes;
        this.Visible = Visible;
        this.AggregateGeometries = AggregateGeometries;
        this.Origin = Origin;
        this.LayerId = LayerId;
        this.ViewId = ViewId;
    }

    public Graphic FromSerializationRecord()
    {
        if (!Guid.TryParse(Id, out Guid graphicId))
        {
            graphicId = Guid.NewGuid();
        }

        Guid? layerId = null;

        if (Guid.TryParse(LayerId, out Guid existingLayerId))
        {
            layerId = existingLayerId;
        }

        Guid? viewId = null;
        
        if (Guid.TryParse(ViewId, out Guid existingViewId))
        {
            viewId = existingViewId;
        }

        return new Graphic(Geometry?.FromSerializationRecord(), Symbol?.FromSerializationRecord(), 
            PopupTemplate?.FromSerializationRecord(), new AttributesDictionary(Attributes),
            Visible, null, AggregateGeometries, Origin?.FromSerializationRecord())
        {
            Id = graphicId,
            LayerId = layerId,
            ViewId = viewId
        };
    }

    [ProtoMember(1)]
    public string? Id { get; set; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public GeometrySerializationRecord? Geometry { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public SymbolSerializationRecord? Symbol { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public PopupTemplateSerializationRecord? PopupTemplate { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public AttributeSerializationRecord[]? Attributes { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public bool? Visible { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(7)]
    public string? AggregateGeometries { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(8)]
    public GraphicOriginSerializationRecord? Origin { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(9)]
    public string? LayerId { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(10)]
    public string? ViewId { get; set; }
}