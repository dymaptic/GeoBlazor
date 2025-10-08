namespace dymaptic.GeoBlazor.Core.Components.Symbols;

[JsonConverter(typeof(SymbolJsonConverter))]
public abstract partial class Symbol : MapComponent, IProtobufSerializable
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

    internal abstract SymbolSerializationRecord ToSerializationRecord();
    
    public MapComponentSerializationRecord ToProtobuf()
    {
        return ToSerializationRecord();
    }
}

[ProtoContract(Name = "Symbol")]
internal record SymbolSerializationRecord : MapComponentSerializationRecord
{
    public SymbolSerializationRecord()
    {
    }
    
    public SymbolSerializationRecord(string Id,
        string Type,
        MapColor? Color)
    {
        this.Id = Id;
        this.Type = Type;
        this.Color = Color;
    }

    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public MapColor? Color { get; init; }
    
    [ProtoMember(3)]
    public SymbolSerializationRecord? Outline { get; init; }

    [ProtoMember(4)]
    public double? Size { get; init; }

    [ProtoMember(5)]
    public string? Style { get; init; }

    [ProtoMember(6)]
    public double? Angle { get; init; }

    [ProtoMember(7)]
    public double? Xoffset { get; init; }

    [ProtoMember(8)]
    public double? Yoffset { get; init; }

    [ProtoMember(9)]
    public double? Width { get; init; }

    [ProtoMember(10)]
    public string? LineStyle { get; init; }

    [ProtoMember(11)]
    public string? Text { get; init; }

    [ProtoMember(12)]
    public MapColor? HaloColor { get; init; }

    [ProtoMember(13)]
    public double? HaloSize { get; init; }

    [ProtoMember(14)]
    public MapFontSerializationRecord? Font { get; init; }

    [ProtoMember(15)]
    public double? Height { get; init; }

    [ProtoMember(16)]
    public string? Url { get; init; }
    
    [ProtoMember(17)]
    public MapColor? BackgroundColor { get; init; }
    
    [ProtoMember(18)]
    public double? BorderLineSize { get; init; }
    
    [ProtoMember(19)]
    public MapColor? BorderLineColor { get; init; }
    
    [ProtoMember(20)]
    public string? HorizontalAlignment { get; init; }
    
    [ProtoMember(21)]
    public bool? Kerning { get; init; }
    
    [ProtoMember(22)]
    public double? LineHeight { get; init; }
    
    [ProtoMember(23)]
    public double? LineWidth { get; init; }
    
    [ProtoMember(24)]
    public bool? Rotated { get; init; }
    
    [ProtoMember(25)]
    public string? VerticalAlignment { get; init; }
    
    [ProtoMember(26)]
    public double? XScale { get; init; }
    
    [ProtoMember(27)]
    public double? YScale { get; init; }
    
    [ProtoMember(28)]
    public string? Id { get; init; }
    
    [ProtoMember(29)]
    public string? Name { get; init; }
    
    [ProtoMember(30)]
    public string? PortalUrl { get; init; }
    
    [ProtoMember(31)]
    public string? StyleName { get; init; }
    
    [ProtoMember(32)]
    public string? StyleUrl { get; init; }

    public Symbol FromSerializationRecord(bool isOutline = false)
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guidId))
        {
            id = guidId;
        }

        if (Type == "web-style")
        {
            // WebStyleSymbol is in GeoBlazor Pro assembly, so we need to use reflection to get the type
            Type? webStyleSymbolType = System.Type
                .GetType("dymaptic.GeoBlazor.Pro.Components.Symbols.WebStyleSymbol, dymaptic.GeoBlazor.Pro");

            if (webStyleSymbolType is not null)
            {
                Portal? portal = PortalUrl is null ? null : new Portal(url: PortalUrl);
                Symbol webStyleSymbol = Activator.CreateInstance(webStyleSymbolType, Color, Name, portal, StyleName, StyleUrl) as Symbol
                    ?? throw new InvalidOperationException("Failed to create WebStyleSymbol instance.");
                webStyleSymbol.Id = id;
                return webStyleSymbol;
            }
        }
        
        return Type switch
        {
            "outline" => new Outline(Color, Width, 
                LineStyle is null ? null : Enum.Parse<SimpleLineSymbolStyle>(LineStyle!, true))
            {
                Id = id
            },
            "simple-marker" => new SimpleMarkerSymbol(Outline?.FromSerializationRecord(true) as Outline, Color, Size, 
                Style is null ? null : Enum.Parse<SimpleMarkerSymbolStyle>(Style!, true), Angle, Xoffset, Yoffset)
            {
                Id = id
            },
            "simple-line" => isOutline 
                ? new Outline(Color, Width, 
                    LineStyle is null ? null : Enum.Parse<SimpleLineSymbolStyle>(LineStyle!, true))
                {
                    Id = id
                }
                : new SimpleLineSymbol(Color, Width, 
                    LineStyle is null ? null : Enum.Parse<SimpleLineSymbolStyle>(LineStyle!, true))
                {
                    Id = id
                },
            "simple-fill" => new SimpleFillSymbol(Outline?.FromSerializationRecord(true) as Outline, Color, 
                Style is null ? null : Enum.Parse<SimpleFillSymbolStyle>(Style!, true)) { Id = id },
            "picture-marker" => new PictureMarkerSymbol(Url!, Width, Height, Angle, Xoffset, Yoffset) { Id = id },
            "picture-fill" => new PictureFillSymbol(Url!, Width, Height, Xoffset, Yoffset, XScale, YScale, 
                Outline?.FromSerializationRecord(true) as Outline) { Id = id },
            "text" => new TextSymbol(Text ?? string.Empty, Color, HaloColor, HaloSize, 
                Font?.FromSerializationRecord(), Angle, BackgroundColor, BorderLineColor,
                BorderLineSize, HorizontalAlignment is null ? null : Enum.Parse<HorizontalAlignment>(HorizontalAlignment!, true),
                Kerning, LineHeight, LineWidth, Rotated, 
                VerticalAlignment is null ? null : Enum.Parse<VerticalAlignment>(VerticalAlignment!, true),
                Xoffset, Yoffset) { Id = id },
            _ => throw new ArgumentException($"Unknown symbol type: {Type}")
        };
    }
}