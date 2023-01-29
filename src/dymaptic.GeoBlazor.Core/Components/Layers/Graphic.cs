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
    public Dictionary<string, object> Attributes
    {
        get => _attributes;
        set => _attributes = new ObservableDictionary<string, object>(value);
    }

    /// <summary>
    ///     The geometry that defines the graphic's location.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonInclude]
    public Geometry? Geometry { get; private set; }


    /// <summary>
    ///     The <see cref="PopupTemplate"/> for displaying content in a Popup when the graphic is selected.
    /// </summary>
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
    public async Task<Geometry> GetGeometry()
    {
        if (_jsObjectReference is not null)
        {
            Geometry = await _jsObjectReference!.InvokeAsync<Geometry>("getGeometry");
        }
        return Geometry;
    }

    public async Task SetGeometry(Geometry geometry)
    {
        await RegisterChildComponent(geometry);
    }
    
    public async Task<PopupTemplate> GetPopupTemplate()
    {
        if (_jsObjectReference is not null)
        {
            PopupTemplate = await _jsObjectReference!.InvokeAsync<PopupTemplate>("getPopupTemplate");
        }
        return PopupTemplate;
    }
    
    public async Task SetPopupTemplate(PopupTemplate popupTemplate)
    {
        await RegisterChildComponent(popupTemplate);
    }

    public override async Task<Symbol?> GetSymbol()
    {
        if (_jsObjectReference is not null)
        {
            Symbol = await _jsObjectReference!.InvokeAsync<Symbol>("getSymbol");
        }

        return Symbol;
    }

    public DotNetObjectReference<Graphic> DotNetGraphicReference => DotNetObjectReference.Create(this);

    [JSInvokable]
    public void OnGraphicCreated(IJSObjectReference jsObjectReference)
    {
        _jsObjectReference = jsObjectReference;
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
                else
                {
                    await UpdateComponent();
                }

                break;
            case PopupTemplate popupTemplate:
                PopupTemplate = popupTemplate;
                if (_jsObjectReference is not null)
                {
                    await _jsObjectReference.InvokeVoidAsync("setPopupTemplate", PopupTemplate);
                }
                else
                {
                    await UpdateComponent();
                }

                break;
            case Symbol symbol:
                Symbol = symbol;
                if (_jsObjectReference is not null)
                {
                    await _jsObjectReference.InvokeVoidAsync("setSymbol", Symbol);
                }
                else
                {
                    await UpdateComponent();
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
    public bool Equals(Graphic? other)
    {
        return other?.Id == Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

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