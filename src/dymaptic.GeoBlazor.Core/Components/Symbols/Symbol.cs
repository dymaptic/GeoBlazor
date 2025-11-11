namespace dymaptic.GeoBlazor.Core.Components.Symbols;

[JsonConverter(typeof(SymbolJsonConverter))]
public abstract partial class Symbol : MapComponent, IProtobufSerializable<SymbolSerializationRecord>
{
    /// <summary>
    ///     The color of the symbol.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? Color { get; set; }

    /// <summary>
    ///     The symbol type
    /// </summary>
    public abstract SymbolType Type { get; }

    /// <inheritdoc />
    public abstract SymbolSerializationRecord ToProtobuf();
}