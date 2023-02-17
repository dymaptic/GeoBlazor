using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Symbols;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Specialized;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     A Graphic is a vector representation of real world geographic phenomena. It can contain geometry, a symbol, and attributes. A Graphic is displayed in the GraphicsLayer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html">ArcGIS JS API</a>
/// </summary>
public class Graphic : LayerObject, IEquatable<Graphic>
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
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
    ///     The <see cref="Symbol"/> for the object.
    /// </param>
    /// <param name="popupTemplate">
    ///     The <see cref="PopupTemplate"/> for displaying content in a Popup when the graphic is selected.
    /// </param>
    /// <param name="attributes">
    ///     Name-value pairs of fields and field values associated with the graphic.
    /// </param>
    public Graphic(Geometry? geometry = null, Symbol? symbol = null, PopupTemplate? popupTemplate = null, 
        Dictionary<string, object>? attributes = null)
    {
#pragma warning disable BL0005
        Geometry = geometry;
        Symbol = symbol;
        PopupTemplate = popupTemplate;

        if (attributes != null)
        {
            Attributes = attributes;
        }
#pragma warning restore BL0005
    }

    /// <summary>
    ///     Name-value pairs of fields and field values associated with the graphic.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>? Attributes
    {
        get => _attributes;
        set => _attributes = value is null 
            ? new ObservableDictionary<string, object>() 
            : new ObservableDictionary<string, object>(value);
    }

    /// <summary>
    ///     The geometry that defines the graphic's location.
    /// </summary>
    /// <remarks>
    ///     To retrieve a current geometry for a graphic, use <see cref="GetGeometry"/> instead of calling this Property directly.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonInclude]
    public Geometry? Geometry { get; private set; }


    /// <summary>
    ///     The <see cref="PopupTemplate"/> for displaying content in a Popup when the graphic is selected.
    /// </summary>
    /// <remarks>
    ///     To retrieve a current popup template for a graphic, use <see cref="GetPopupTemplate"/> instead of calling this Property directly.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonInclude]
    public PopupTemplate? PopupTemplate { get; private set; }
    
    /// <summary>
    ///     The GeoBlazor Id of the parent layer, used when serializing the graphic to/from JavaScript.
    /// </summary>
    public Guid? LayerId { get; set; }

    /// <summary>
    ///     Retrieves the <see cref="Geometry"/> from the rendered graphic.
    /// </summary>
    public async Task<Geometry?> GetGeometry()
    {
        if (_jsObjectReference is not null)
        {
            Geometry = await _jsObjectReference!.InvokeAsync<Geometry>("getGeometry");
        }
        return Geometry;
    }

    /// <summary>
    ///    Sets the <see cref="Geometry"/> on the rendered graphic.
    /// </summary>
    /// <param name="geometry"></param>
    public async Task SetGeometry(Geometry geometry)
    {
        await RegisterChildComponent(geometry);
    }
    
    /// <summary>
    ///    Retrieves the <see cref="PopupTemplate"/> from the rendered graphic.
    /// </summary>
    public async Task<PopupTemplate?> GetPopupTemplate()
    {
        if (_jsObjectReference is not null)
        {
            PopupTemplate = await _jsObjectReference!.InvokeAsync<PopupTemplate>("getPopupTemplate");
        }
        return PopupTemplate;
    }
    
    /// <summary>
    ///   Sets the <see cref="PopupTemplate"/> on the rendered graphic.
    /// </summary>
    /// <param name="popupTemplate">
    ///     The <see cref="PopupTemplate"/> for displaying content in a Popup when the graphic is selected.
    /// </param>
    public async Task SetPopupTemplate(PopupTemplate popupTemplate)
    {
        await RegisterChildComponent(popupTemplate);
    }

    /// <inheritdoc />
    public override async Task<Symbol?> GetSymbol()
    {
        if (_jsObjectReference is not null)
        {
            Symbol = await _jsObjectReference!.InvokeAsync<Symbol>("getSymbol");
        }

        return Symbol;
    }

    /// <summary>
    ///   Internally used reference for JavaScript callbacks.
    /// </summary>
    public DotNetObjectReference<Graphic> DotNetGraphicReference => DotNetObjectReference.Create(this);

    /// <summary>
    ///    Javascript-invokable internal method.
    /// </summary>
    /// <param name="jsObjectReference">
    ///     The javascript object reference for the rendered graphic.
    /// </param>
    [JSInvokable]
    public void OnGraphicCreated(IJSObjectReference jsObjectReference)
    {
        _jsObjectReference ??= jsObjectReference;
    }

    /// <summary>
    ///     Used internally to register a graphic that was generated in Javascript directly.
    /// </summary>
    /// <remarks>
    ///     Not intended for end-user use.
    /// </remarks>
    public async Task RegisterGraphic(IJSObjectReference jsObjectReference)
    {
        _jsObjectReference ??= jsObjectReference;
        await _jsObjectReference.InvokeVoidAsync("registerWithId", Id);
    } 

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Geometry geometry:
                Geometry = geometry;

                if (_jsObjectReference is not null)
                {
                    await _jsObjectReference.InvokeVoidAsync("setGeometry", Geometry);
                }

                break;
            case PopupTemplate popupTemplate:
                PopupTemplate = popupTemplate;
                if (_jsObjectReference is not null)
                {
                    await _jsObjectReference.InvokeVoidAsync("setPopupTemplate", PopupTemplate);
                }

                break;
            case Symbol symbol:
                Symbol = symbol;
                if (_jsObjectReference is not null)
                {
                    await _jsObjectReference.InvokeVoidAsync("setSymbol", Symbol);
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
        Geometry?.ValidateRequiredChildren();
        PopupTemplate?.ValidateRequiredChildren();
    }
    
    internal bool IsRendered => _jsObjectReference is not null;

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        _attributes.CollectionChanged -= OnAttributesChanged;
        _attributes.CollectionChanged += OnAttributesChanged;
    }

    private async void OnAttributesChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (_jsObjectReference is null) return;
        await _jsObjectReference.InvokeVoidAsync("setAttributes", Attributes);
    }

    private IJSObjectReference? _jsObjectReference = null!;
    private ObservableDictionary<string, object> _attributes = new();

    /// <inheritdoc />
    public bool Equals(Graphic? other)
    {
        return other?.Id == Id ||
            (other is not null &&
             other.Geometry?.Equals(Geometry) == true &&
             (other.Attributes?.Equals(Attributes) == true));
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

        return Equals((Graphic)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    ///    Compares two <see cref="Graphic"/> instances for equality.
    /// </summary>
    public static bool operator ==(Graphic? left, Graphic? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Compares two <see cref="Graphic"/> instances for inequality.
    /// </summary>
    public static bool operator !=(Graphic? left, Graphic? right)
    {
        return !Equals(left, right);
    }
}

