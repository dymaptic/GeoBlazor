using ParameterValue = Microsoft.AspNetCore.Components.ParameterValue;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     A Graphic is a vector representation of real world geographic phenomena. It can contain geometry, a symbol, and
///     attributes. A Graphic is displayed in the GraphicsLayer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class Graphic : MapComponent, IEquatable<Graphic>
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public Graphic()
    {
    }

    /// <summary>
    ///     Constructs a new Graphic in code with parameters
    /// </summary>
    /// <param name="geometry">
    ///     The geometry that defines the graphic's location.
    /// </param>
    /// <param name="symbol">
    ///     The <see cref="Symbol" /> for the object.
    /// </param>
    /// <param name="popupTemplate">
    ///     The <see cref="PopupTemplate" /> for displaying content in a Popup when the graphic is selected.
    /// </param>
    /// <param name="attributes">
    ///     Name-value pairs of fields and field values associated with the graphic.
    /// </param>
    /// <param name="visible">
    ///     Indicates the visibility of the graphic.
    /// </param>
    /// <param name="legendLabel">
    ///     Optional label override for this graphic in the GeoBlazor Pro GraphicsLegendWidget.
    /// </param>
    public Graphic(Geometry? geometry = null, Symbol? symbol = null, PopupTemplate? popupTemplate = null,
        AttributesDictionary? attributes = null, bool? visible = null, string? legendLabel = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Geometry = geometry;
        Symbol = symbol;
        PopupTemplate = popupTemplate;
        Visible = visible;
        LegendLabel = legendLabel;

        if (attributes is not null)
        {
            Attributes = attributes;
        }
#pragma warning restore BL0005
        Attributes.OnChange = OnAttributesChanged;
        ToSerializationRecord();
    }

    /// <summary>
    ///     Name-value pairs of fields and field values associated with the graphic.
    /// </summary>
    /// <remarks>
    ///     This collection should only be set via the constructor or as a markup parameter/attribute. To add or remove
    ///     members, use the methods defined in <see cref="AttributesDictionary" />
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AttributesDictionary Attributes { get; set; } = new();
    
    /// <summary>
    ///     Legend label override for this graphic in the GeoBlazor Pro Graphics Legend Widget.
    ///     Supports attribute substitution using the syntax {attributeName}.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public string? LegendLabel { get; set; }

    /// <summary>
    ///     The geometry that defines the graphic's location.
    /// </summary>
    /// <remarks>
    ///     To retrieve a current geometry for a graphic, use <see cref="GetGeometry" /> instead of calling this Property
    ///     directly.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonInclude]
    public Geometry? Geometry { get; private set; }

    /// <summary>
    ///     The <see cref="PopupTemplate" /> for displaying content in a Popup when the graphic is selected.
    /// </summary>
    /// <remarks>
    ///     To retrieve a current popup template for a graphic, use <see cref="GetPopupTemplate" /> instead of calling this
    ///     Property directly.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonInclude]
    public PopupTemplate? PopupTemplate { get; private set; }
    
    /// <summary>
    ///     The <see cref="Symbol" /> for the object.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonInclude]
    public Symbol? Symbol { get; protected set; }

    /// <summary>
    ///     The GeoBlazor Id of the parent layer, used when serializing the graphic to/from JavaScript.
    /// </summary>
    public Guid? LayerId { get; set; }

    /// <summary>
    ///     Retrieves the <see cref="Geometry" /> from the rendered graphic.
    /// </summary>
    public async Task<Geometry?> GetGeometry()
    {
        if (CoreJsModule is not null)
        {
            Geometry = await CoreJsModule.InvokeAsync<Geometry>("getGraphicGeometry",
                CancellationTokenSource.Token, Id);
        }

        return Geometry;
    }

    /// <summary>
    ///     Sets the <see cref="Geometry" /> on the rendered graphic.
    /// </summary>
    /// <param name="geometry"></param>
    public async Task SetGeometry(Geometry geometry)
    {
        Geometry = geometry;

        if (CoreJsModule is not null)
        {
            await CoreJsModule.InvokeVoidAsync("setGraphicGeometry", Id,
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
    ///     Sets the <see cref="Symbol" /> for the object.
    /// </summary>
    /// <param name="symbol">
    ///     The <see cref="Symbol" /> for the object.
    /// </param>
    public async Task SetSymbol(Symbol symbol)
    {
        Symbol = symbol;

        if (CoreJsModule is not null)
        {
            await CoreJsModule.InvokeVoidAsync("setGraphicSymbol",
                Id, Symbol.ToSerializationRecord());
        }
        else
        {
            _updateSymbol = true;
        }
        
        _serializationRecord = null;
        ToSerializationRecord();
    }

    /// <summary>
    ///     Gets the current <see cref="Symbol" /> for the object.
    /// </summary>
    public async Task<Symbol?> GetSymbol()
    {
        if (CoreJsModule is not null)
        {
            Symbol = await CoreJsModule.InvokeAsync<Symbol>("getGraphicSymbol",
                CancellationTokenSource.Token, Id);
        }

        return Symbol;
    }

    /// <summary>
    ///     Retrieves the <see cref="PopupTemplate" /> from the rendered graphic.
    /// </summary>
    public async Task<PopupTemplate?> GetPopupTemplate()
    {
        if (CoreJsModule is not null)
        {
            PopupTemplate = await CoreJsModule.InvokeAsync<PopupTemplate>("getGraphicPopupTemplate",
                CancellationTokenSource.Token, Id);
        }

        return PopupTemplate;
    }

    /// <summary>
    ///     Sets the <see cref="PopupTemplate" /> on the rendered graphic.
    /// </summary>
    /// <param name="popupTemplate">
    ///     The <see cref="PopupTemplate" /> for displaying content in a Popup when the graphic is selected.
    /// </param>
    public async Task SetPopupTemplate(PopupTemplate popupTemplate)
    {
        var oldTemplate = PopupTemplate;

        PopupTemplate = popupTemplate;


        if (CoreJsModule is not null)
        {
            if (oldTemplate != null)
            {
                await CoreJsModule.InvokeVoidAsync("removeGraphicPopupTemplate", Id,
                    oldTemplate.ToSerializationRecord(), oldTemplate.DotNetComponentReference, View?.Id);
            }

            await CoreJsModule.InvokeVoidAsync("setGraphicPopupTemplate", Id,
                PopupTemplate.ToSerializationRecord(), PopupTemplate.DotNetComponentReference, View?.Id);
        }
        else
        {
            _updatePopupTemplate = true;
        }

        _serializationRecord = null;
        ToSerializationRecord();
    }
    
    public Layer? Layer { get; set; }
        
    public Task<Layer?> GetLayer()
    {
        return Task.FromResult(Layer);
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
    public override async ValueTask DisposeAsync()
    {
        await base.DisposeAsync();

        if (CoreJsModule is not null)
        {
            await CoreJsModule.InvokeVoidAsync("disposeGraphic", Id);
        }
    }

    /// <inheritdoc />
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
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Geometry?.ValidateRequiredChildren();
        PopupTemplate?.ValidateRequiredChildren();
        Symbol?.ValidateRequiredChildren();
    }

    internal GraphicSerializationRecord ToSerializationRecord(bool refresh = false)
    {
        if (_serializationRecord is null || refresh)
        {
            _serializationRecord = new GraphicSerializationRecord(Id.ToString(),
                Geometry?.ToSerializationRecord(),
                Symbol?.ToSerializationRecord(),
                PopupTemplate?.ToSerializationRecord(),
                Attributes.ToSerializationRecord());
        }

        return _serializationRecord;
    }

    /// <inheritdoc />
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
        if (CoreJsModule is null) return;

        await CoreJsModule.InvokeVoidAsync("setGraphicAttributes",
            CancellationTokenSource.Token, Id, Attributes);
        ToSerializationRecord(true);
    }

    private GraphicSerializationRecord? _serializationRecord;
    private bool _updateGeometry;
    private bool _updateSymbol;
    private bool _updatePopupTemplate;
    private bool _updateAttributes;

    public bool Equals(Graphic? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
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
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Graphic)obj);
    }

    public override int GetHashCode()
    {
        return (Geometry != null ? Geometry.GetHashCode() : 0);
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
    
    public GraphicSerializationRecord(string Id,
        GeometrySerializationRecord? Geometry,
        SymbolSerializationRecord? Symbol,
        PopupTemplateSerializationRecord? PopupTemplate,
        AttributeSerializationRecord[]? Attributes)
    {
        this.Id = Id;
        this.Geometry = Geometry;
        this.Symbol = Symbol;
        this.PopupTemplate = PopupTemplate;
        this.Attributes = Attributes;
    }

    public Graphic FromSerializationRecord()
    {
        if (!Guid.TryParse(Id, out Guid graphicId))
        {
            graphicId = Guid.NewGuid();
        }
        return new Graphic(Geometry?.FromSerializationRecord(),
            Symbol?.FromSerializationRecord(),
            PopupTemplate?.FromSerializationRecord(),
            new AttributesDictionary(Attributes))
        {
            Id = graphicId
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
    [ProtoMember(5)]
    public AttributeSerializationRecord[]? Attributes { get; set; }
}