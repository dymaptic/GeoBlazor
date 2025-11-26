using FieldInfo = dymaptic.GeoBlazor.Core.Components.FieldInfo;


namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Base class for all Protobuf serialization records for MapComponents.
/// </summary>
[ProtoContract(Name = "MapComponent")]
public abstract record MapComponentSerializationRecord
{
    [ProtoMember(1000)]
    public abstract bool IsNull { get; init; }
}

public abstract record MapComponentSerializationRecord<T> : MapComponentSerializationRecord
{
    public abstract T? FromSerializationRecord();
}

[ProtoContract(Name = "MapComponentCollection")]
public abstract record MapComponentBaseCollectionSerializationRecord
{
    [ProtoMember(1000)]
    public abstract bool IsNull { get; init; }
}

public abstract record MapComponentCollectionSerializationRecord<TItem> : MapComponentBaseCollectionSerializationRecord
    where TItem : MapComponentSerializationRecord
{
    public abstract TItem[]? Items { get; set; }
}

[ProtoContract(Name = "Geometry")]
public record GeometrySerializationRecord : MapComponentSerializationRecord<Geometry>
{
    public GeometrySerializationRecord()
    {
    }

    public GeometrySerializationRecord(string Id, string Type, GeometrySerializationRecord? Extent,
        SpatialReferenceSerializationRecord? SpatialReference)
    {
        this.Id = Id;
        this.Type = Type;
        this.Extent = Extent;
        this.SpatialReference = SpatialReference;
    }

    [ProtoMember(1)]
    public string Type { get; set; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public GeometrySerializationRecord? Extent { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public SpatialReferenceSerializationRecord? SpatialReference { get; set; }

    [ProtoMember(4)]
    public double? Longitude { get; set; }

    [ProtoMember(5)]
    public double? Latitude { get; set; }

    [ProtoMember(6)]
    public double? X { get; set; }

    [ProtoMember(7)]
    public double? Y { get; set; }

    [ProtoMember(8)]
    public double? Z { get; set; }

    [ProtoMember(9)]
    public MapPathSerializationRecord[]? Paths { get; set; }

    [ProtoMember(10)]
    public MapPathSerializationRecord[]? Rings { get; set; }

    [ProtoMember(11)]
    public double? Xmax { get; set; }

    [ProtoMember(12)]
    public double? Xmin { get; set; }

    [ProtoMember(13)]
    public double? Ymax { get; set; }

    [ProtoMember(14)]
    public double? Ymin { get; set; }

    [ProtoMember(15)]
    public double? Zmax { get; set; }

    [ProtoMember(16)]
    public double? Zmin { get; set; }

    [ProtoMember(17)]
    public double? Mmax { get; set; }

    [ProtoMember(18)]
    public double? Mmin { get; set; }

    [ProtoMember(19)]
    public bool? HasM { get; set; }

    [ProtoMember(20)]
    public bool? HasZ { get; set; }

    [ProtoMember(21)]
    public double? M { get; set; }

    [ProtoMember(22)]
    public GeometrySerializationRecord? Centroid { get; set; }

    [ProtoMember(23)]
    public bool? IsSelfIntersecting { get; set; }

    [ProtoMember(24)]
    public GeometrySerializationRecord? Center { get; set; }

    [ProtoMember(25)]
    public bool? Geodesic { get; set; }

    [ProtoMember(26)]
    public int? NumberOfPoints { get; set; }

    [ProtoMember(27)]
    public double? Radius { get; set; }

    [ProtoMember(28)]
    public string? RadiusUnit { get; set; }

    [ProtoMember(29)]
    public string? Id { get; set; }

    /// <summary>
    ///     Multipoint geometry points.
    /// </summary>
    [ProtoMember(30)]
    public MapPointSerializationRecord[]? Points { get; set; }

    [ProtoMember(31)]
    public bool? IsSimple { get; set; }

    [ProtoMember(32)]
    public MeshComponentSerializationRecord[]? Components { get; set; }

    [ProtoMember(33)]
    public MeshTransformSerializationRecord? Transform { get; set; }

    [ProtoMember(34)]
    public MeshVertexAttributesSerializationRecord? VertexAttributes { get; set; }

    [ProtoMember(35)]
    public MeshVertexSpaceSerializationRecord? VertexSpace { get; set; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override Geometry? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        var extent = Extent?.FromSerializationRecord() as Extent;
        var id = Guid.NewGuid();

        if (Guid.TryParse(Id, out var guidId))
        {
            id = guidId;
        }

        switch (Type)
        {
            case "point":
                return new Point(Longitude, Latitude, X, Y, Z, SpatialReference?.FromSerializationRecord(), HasM, HasZ,
                    M) { Extent = extent, Id = id };
            case "polyline":
                var paths = Paths?.Any(p => !p.IsNull) == true
                    ? Paths.Select(x => x.FromSerializationRecord()!).ToArray()
                    : null;

                if (paths is null)
                {
                    return null;
                }

                return new Polyline(paths,
                    SpatialReference?.FromSerializationRecord(), HasM, HasZ)
                {
                    Extent = extent, Id = id, IsSimple = IsSimple
                };
            case "polygon":
                var rings = Rings?.Any(p => !p.IsNull) == true
                    ? Rings.Select(x => x.FromSerializationRecord()!).ToArray()
                    : null;

                if (rings is null)
                {
                    return null;
                }

                return Center is not null && Radius is not null && !Center.IsNull
                    ? new Circle((Point)Center.FromSerializationRecord()!, Radius.Value,
                        Centroid?.FromSerializationRecord() as Point, Geodesic, HasM, HasZ, NumberOfPoints,
                        RadiusUnit is null ? null : Enum.Parse<RadiusUnit>(RadiusUnit), rings,
                        SpatialReference?.FromSerializationRecord()) { Extent = extent, Id = id, IsSimple = IsSimple }
                    : new Polygon(rings,
                        SpatialReference?.FromSerializationRecord(), Centroid?.FromSerializationRecord() as Point, HasM,
                        HasZ) { Extent = extent, Id = id, IsSimple = IsSimple };
            case "extent":
                return new Extent(Xmax!.Value, Xmin!.Value, Ymax!.Value, Ymin!.Value, Zmax, Zmin, Mmax, Mmin,
                    SpatialReference?.FromSerializationRecord(), HasM, HasZ) { Id = id, IsSimple = IsSimple };
            case "multipoint":
                // Multipoint is in GeoBlazor Pro assembly, so we need to use reflection to get the type
                var multipointType = System.Type.GetType("dymaptic.GeoBlazor.Pro.Components.Geometries.Multipoint, " +
                    "dymaptic.GeoBlazor.Pro");

                if (multipointType is not null && multipointType.IsSubclassOf(typeof(Geometry)))
                {
                    var points = Points?.Any(p => !p.IsNull) == true
                        ? Points?.Select(p =>
                            {
                                var mp = p.FromSerializationRecord()!;

                                return new Point(x: mp[0], y: mp[1]);
                            })
                            .ToArray()
                        : null;

                    if (Activator.CreateInstance(multipointType, HasM, HasZ, points,
                            SpatialReference?.FromSerializationRecord())
                        is Geometry multipoint)
                    {
                        multipoint.Extent = extent;
                        multipoint.Id = id;
                        multipoint.IsSimple = IsSimple;

                        return multipoint;
                    }
                }

                throw new InvalidOperationException(
                    "Multipoint could not be created. Ensure the type is correct and the assembly is loaded.");
            case "mesh":
                // Mesh is in GeoBlazor Pro assembly, so we need to use reflection to get the type
                var meshType = System.Type.GetType("dymaptic.GeoBlazor.Pro.Components.Geometries.Mesh, " +
                    "dymaptic.GeoBlazor.Pro");

                if (meshType is not null
                    && meshType.IsSubclassOf(typeof(Geometry))
                    && Activator.CreateInstance(meshType,
                            Components?.Select(c => c.FromSerializationRecord()).ToArray(),
                            HasM, HasZ,
                            SpatialReference?.FromSerializationRecord(),
                            Transform?.FromSerializationRecord(),
                            VertexAttributes?.FromSerializationRecord(),
                            VertexSpace?.FromSerializationRecord())
                        is Geometry mesh)
                {
                    mesh.Extent = extent;
                    mesh.Id = id;
                    mesh.IsSimple = IsSimple;

                    return mesh;
                }

                throw new InvalidOperationException(
                    "Mesh could not be created. Ensure the type is correct and the assembly is loaded.");
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

[ProtoContract(Name = "GeometryCollection")]
internal record
    GeometryCollectionSerializationRecord : MapComponentCollectionSerializationRecord<GeometrySerializationRecord>
{
    public GeometryCollectionSerializationRecord()
    {
    }

    public GeometryCollectionSerializationRecord(GeometrySerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override GeometrySerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "PopupContent")]
public record PopupContentSerializationRecord : MapComponentSerializationRecord<PopupContent>
{
    public PopupContentSerializationRecord()
    {
    }

    public PopupContentSerializationRecord(string Id, string Type)
    {
        this.Type = Type;
        this.Id = Id;
    }

    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;

    [ProtoMember(2)]
    public string? Description { get; init; }

    [ProtoMember(3)]
    public string? DisplayType { get; init; }

    [ProtoMember(4)]
    public string? Title { get; init; }

    [ProtoMember(5)]
    public ElementExpressionInfoSerializationRecord? ExpressionInfo { get; init; }

    [ProtoMember(6)]
    public FieldInfoSerializationRecord[]? FieldInfos { get; init; }

    [ProtoMember(7)]
    public int? ActiveMediaInfoIndex { get; init; }

    [ProtoMember(8)]
    public MediaInfoSerializationRecord[]? MediaInfos { get; init; }

    [ProtoMember(9)]
    public int? DisplayCount { get; init; }

    [ProtoMember(10)]
    public RelatedRecordsInfoFieldOrderSerializationRecord[]? OrderByFields { get; init; }

    [ProtoMember(11)]
    public long? RelationshipId { get; init; }

    [ProtoMember(12)]
    public string? Text { get; init; }

    [ProtoMember(13)]
    public string? Id { get; set; }

    [ProtoMember(14)]
    public string[]? OutFields { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override PopupContent? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        var id = Guid.NewGuid();

        if (Guid.TryParse(Id, out var guidId))
        {
            id = guidId;
        }

        if (Type == "custom")
        {
            // CustomPopupContent is in GeoBlazor Pro assembly, so we need to use reflection to get the type
            var customType =
                System.Type.GetType(
                    "dymaptic.GeoBlazor.Pro.Components.Popups.CustomPopupContent, dymaptic.GeoBlazor.Pro");

            if (customType is not null && customType.IsSubclassOf(typeof(PopupContent)))
            {
                var customContent = Activator.CreateInstance(customType, [null, OutFields]) as PopupContent;

                if (customContent is null)
                {
                    throw new InvalidOperationException(
                        "CustomPopupContent could not be created. Ensure the type is correct and the assembly is loaded.");
                }

                customContent.Id = id;

                return customContent;
            }
        }

        return Type switch
        {
            "fields" => new FieldsPopupContent(FieldInfos?.Any(i => !i.IsNull) == true
                    ? FieldInfos.Select(i => i.FromSerializationRecord()!).ToArray()
                    : [],
                Description, Title) { Id = id },
            "text" => new TextPopupContent(Text) { Id = id },
            "attachments" => new AttachmentsPopupContent(Title, Description,
                DisplayType is null ? null : Enum.Parse<AttachmentsPopupContentDisplayType>(DisplayType)) { Id = id },
            "expression" => new ExpressionPopupContent(ExpressionInfo?.FromSerializationRecord()) { Id = id },
            "media" => new MediaPopupContent(Title, Description, MediaInfos?.Any(i => !i.IsNull) == true
                    ? MediaInfos.Select(i => i.FromSerializationRecord()!).ToArray()
                    : null,
                ActiveMediaInfoIndex) { Id = id },
            "relationship" => new RelationshipPopupContent(Title, Description, DisplayCount,
                DisplayType, OrderByFields?.Any(f => !f.IsNull) == true
                    ? OrderByFields.Select(x => x.FromSerializationRecord()!).ToList()
                    : null,
                RelationshipId) { Id = id },
            _ => throw new NotSupportedException($"PopupContent type {Type} is not supported")
        };
    }
}

[ProtoContract(Name = "PopupContentCollection")]
internal record
    PopupContentCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    PopupContentSerializationRecord>
{
    public PopupContentCollectionSerializationRecord()
    {
    }

    public PopupContentCollectionSerializationRecord(PopupContentSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override PopupContentSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "PopupExpressionInfo")]
public record PopupExpressionInfoSerializationRecord : MapComponentSerializationRecord<PopupExpressionInfo>
{
    public PopupExpressionInfoSerializationRecord()
    {
    }

    public PopupExpressionInfoSerializationRecord(string Id, string? Expression, string? Name, string? Title,
        PopupExpressionInfoReturnType? ReturnType)
    {
        this.Id = Id;
        this.Expression = Expression;
        this.Name = Name;
        this.Title = Title;
        this.ReturnType = ReturnType.ToString();
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? Expression { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Name { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? Title { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public string? ReturnType { get; init; }

    [ProtoMember(5)]
    public string? Id { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override PopupExpressionInfo? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        var id = Guid.NewGuid();

        if (Guid.TryParse(Id, out var guid))
        {
            id = guid;
        }

        return new PopupExpressionInfo(Expression, Name,
            ReturnType is null ? null : Enum.Parse<PopupExpressionInfoReturnType>(ReturnType),
            Title) { Id = id };
    }
}

[ProtoContract(Name = "PopupExpressionInfoCollection")]
internal record
    PopupExpressionInfoCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    PopupExpressionInfoSerializationRecord>
{
    public PopupExpressionInfoCollectionSerializationRecord()
    {
    }

    public PopupExpressionInfoCollectionSerializationRecord(PopupExpressionInfoSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override PopupExpressionInfoSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "PopupTemplate")]
public record PopupTemplateSerializationRecord : MapComponentSerializationRecord<PopupTemplate>
{
    public PopupTemplateSerializationRecord()
    {
    }

    public PopupTemplateSerializationRecord(string? Title,
        string? StringContent = null,
        IEnumerable<string>? OutFields = null,
        IEnumerable<FieldInfoSerializationRecord>? FieldInfos = null,
        IEnumerable<PopupContentSerializationRecord>? Content = null,
        IEnumerable<PopupExpressionInfoSerializationRecord>? ExpressionInfos = null,
        bool? OverwriteActions = null,
        bool? ReturnGeometry = null,
        IEnumerable<ActionBaseSerializationRecord>? Actions = null,
        string? Id = null)
    {
        this.Title = Title;
        this.StringContent = StringContent;
        this.OutFields = OutFields;
        this.FieldInfos = FieldInfos;
        this.Content = Content;
        this.ExpressionInfos = ExpressionInfos;
        this.OverwriteActions = OverwriteActions;
        this.ReturnGeometry = ReturnGeometry;
        this.Actions = Actions;
        this.Id = Id;
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? Title { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? StringContent { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public IEnumerable<string>? OutFields { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public IEnumerable<FieldInfoSerializationRecord>? FieldInfos { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public IEnumerable<PopupContentSerializationRecord>? Content { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public IEnumerable<PopupExpressionInfoSerializationRecord>? ExpressionInfos { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(7)]
    public bool? OverwriteActions { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(8)]
    public bool? ReturnGeometry { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(9)]
    public IEnumerable<ActionBaseSerializationRecord>? Actions { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(10)]
    public string? Id { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override PopupTemplate? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return new PopupTemplate(Title, StringContent, OutFields?.ToList(),
            FieldInfos?.Any(i => !i.IsNull) == true
                ? FieldInfos.Select(f => f.FromSerializationRecord()!).ToList()
                : null,
            Content?.Any(c => !c.IsNull) == true
                ? Content.Select(c => c.FromSerializationRecord()!).ToList()
                : null,
            ExpressionInfos?.Any(i => i.IsNull) == true
                ? ExpressionInfos.Select(e => e.FromSerializationRecord()!).ToList()
                : null,
            OverwriteActions, ReturnGeometry,
            Actions?.Any(a => !a.IsNull) == true
                ? Actions?.Select(a => a.FromSerializationRecord()!).ToList()
                : null);
    }
}

[ProtoContract(Name = "PopupTemplateCollection")]
internal record
    PopupTemplateCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    PopupTemplateSerializationRecord>
{
    public PopupTemplateCollectionSerializationRecord()
    {
    }

    public PopupTemplateCollectionSerializationRecord(PopupTemplateSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override PopupTemplateSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "Symbol")]
public record SymbolSerializationRecord : MapComponentSerializationRecord<Symbol>
{
    public SymbolSerializationRecord()
    {
    }

    public SymbolSerializationRecord(string Id,
        string Type,
        MapColorSerializationRecord? Color)
    {
        this.Id = Id;
        this.Type = Type;
        this.Color = Color;
    }

    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public MapColorSerializationRecord? Color { get; init; }

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
    public MapColorSerializationRecord? HaloColor { get; init; }

    [ProtoMember(13)]
    public double? HaloSize { get; init; }

    [ProtoMember(14)]
    public MapFontSerializationRecord? Font { get; init; }

    [ProtoMember(15)]
    public double? Height { get; init; }

    [ProtoMember(16)]
    public string? Url { get; init; }

    [ProtoMember(17)]
    public MapColorSerializationRecord? BackgroundColor { get; init; }

    [ProtoMember(18)]
    public double? BorderLineSize { get; init; }

    [ProtoMember(19)]
    public MapColorSerializationRecord? BorderLineColor { get; init; }

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

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override Symbol? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return FromSerializationRecord();
    }

    public Symbol FromSerializationRecord(bool isOutline = false)
    {
        var id = Guid.NewGuid();

        if (Guid.TryParse(Id, out var guidId))
        {
            id = guidId;
        }

        if (Type == "web-style")
        {
            // WebStyleSymbol is in GeoBlazor Pro assembly, so we need to use reflection to get the type
            var webStyleSymbolType = System.Type
                .GetType("dymaptic.GeoBlazor.Pro.Components.Symbols.WebStyleSymbol, dymaptic.GeoBlazor.Pro");

            if (webStyleSymbolType is not null)
            {
                var portal = PortalUrl is null ? null : new Portal(url: PortalUrl);

                var webStyleSymbol = Activator.CreateInstance(webStyleSymbolType, Color?.FromSerializationRecord(),
                        Name, portal, StyleName, StyleUrl) as Symbol
                    ?? throw new InvalidOperationException("Failed to create WebStyleSymbol instance.");
                webStyleSymbol.Id = id;

                return webStyleSymbol;
            }
        }

        return Type switch
        {
            "outline" => new Outline(Color?.FromSerializationRecord(), Width,
                LineStyle is null ? null : Enum.Parse<SimpleLineSymbolStyle>(LineStyle!, true)) { Id = id },
            "simple-marker" => new SimpleMarkerSymbol(Outline?.FromSerializationRecord(true) as Outline,
                Color?.FromSerializationRecord(), Size,
                Style is null ? null : Enum.Parse<SimpleMarkerSymbolStyle>(Style!, true),
                Angle, Xoffset, Yoffset) { Id = id },
            "simple-line" => isOutline
                ? new Outline(Color?.FromSerializationRecord(), Width,
                    LineStyle is null ? null : Enum.Parse<SimpleLineSymbolStyle>(LineStyle!, true)) { Id = id }
                : new SimpleLineSymbol(Color?.FromSerializationRecord(), Width,
                    LineStyle is null ? null : Enum.Parse<SimpleLineSymbolStyle>(LineStyle!, true)) { Id = id },
            "simple-fill" => new SimpleFillSymbol(Outline?.FromSerializationRecord(true) as Outline,
                Color?.FromSerializationRecord(),
                Style is null ? null : Enum.Parse<SimpleFillSymbolStyle>(Style!, true)) { Id = id },
            "picture-marker" => new PictureMarkerSymbol(Url!, Width, Height, Angle, Xoffset, Yoffset) { Id = id },
            "picture-fill" => new PictureFillSymbol(Url!, Width, Height, Xoffset, Yoffset, XScale, YScale,
                Outline?.FromSerializationRecord(true) as Outline) { Id = id },
            "text" => new TextSymbol(Text ?? string.Empty, Color?.FromSerializationRecord(),
                HaloColor?.FromSerializationRecord(), HaloSize,
                Font?.FromSerializationRecord(), Angle, BackgroundColor?.FromSerializationRecord(),
                BorderLineColor?.FromSerializationRecord(),
                BorderLineSize,
                HorizontalAlignment is null ? null : Enum.Parse<HorizontalAlignment>(HorizontalAlignment!, true),
                Kerning, LineHeight, LineWidth, Rotated,
                VerticalAlignment is null ? null : Enum.Parse<VerticalAlignment>(VerticalAlignment!, true),
                Xoffset, Yoffset) { Id = id },
            _ => throw new ArgumentException($"Unknown symbol type: {Type}")
        };
    }
}

[ProtoContract(Name = "SymbolCollection")]
internal record
    SymbolCollectionSerializationRecord : MapComponentCollectionSerializationRecord<SymbolSerializationRecord>
{
    public SymbolCollectionSerializationRecord()
    {
    }

    public SymbolCollectionSerializationRecord(SymbolSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override SymbolSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "MapColor")]
public record MapColorSerializationRecord : MapComponentSerializationRecord<MapColor>
{
    public MapColorSerializationRecord()
    {
    }

    public MapColorSerializationRecord(double[]? rgbaValues, string? hexOrNameValue)
    {
        RgbaValues = rgbaValues;
        HexOrNameValue = hexOrNameValue;
    }

    [ProtoMember(1)]
    public double[]? RgbaValues { get; init; }

    [ProtoMember(2)]
    public string? HexOrNameValue { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override MapColor? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        if (HexOrNameValue is not null)
        {
            return new MapColor(HexOrNameValue);
        }

        if (RgbaValues is not null)
        {
            return new MapColor(RgbaValues);
        }

        return new MapColor();
    }
}

[ProtoContract(Name = "MapColorCollection")]
public record MapColorCollectionSerializationRecord
    : MapComponentCollectionSerializationRecord<MapColorSerializationRecord>
{
    public MapColorCollectionSerializationRecord(MapColorSerializationRecord[] items)
    {
        Items = items;
    }
    
    public sealed override MapColorSerializationRecord[]? Items { get; set; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "ActionBase")]
public record ActionBaseSerializationRecord : MapComponentSerializationRecord<ActionBase>
{
    public ActionBaseSerializationRecord()
    {
    }

    public ActionBaseSerializationRecord(string Id,
        string Type,
        string? Title,
        string? ClassName,
        bool? Active,
        bool? Disabled,
        bool? Visible,
        string? ActionId)
    {
        this.Id = Id;
        this.Type = Type;
        this.Title = Title;
        this.ClassName = ClassName;
        this.Active = Active;
        this.Disabled = Disabled;
        this.Visible = Visible;
        this.ActionId = ActionId;
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Title { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? ClassName { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public bool? Active { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public bool? Disabled { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public bool? Visible { get; init; }

    [ProtoMember(7)]
    public string? Id { get; init; }

    [ProtoMember(8)]
    public string? Image { get; init; }

    [ProtoMember(9)]
    public bool? Value { get; init; }

    [ProtoMember(10)]
    public string? ActionId { get; init; }

    [ProtoMember(11)]
    public string? Test { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override ActionBase? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        var id = Guid.NewGuid();

        if (Guid.TryParse(Id, out var guidId))
        {
            id = guidId;
        }

        return Type switch
        {
            "button" => new ActionButton(Title, Image, ActionId, null, ClassName, Active, Disabled, Visible)
            {
                Id = id
            },
            "toggle" => new ActionToggle(Title, ActionId, null, Value, Active, Disabled, Visible) { Id = id },
            _ => throw new NotSupportedException()
        };
    }
}

[ProtoContract(Name = "ActionBaseCollection")]
internal record
    ActionBaseCollectionSerializationRecord : MapComponentCollectionSerializationRecord<ActionBaseSerializationRecord>
{
    public ActionBaseCollectionSerializationRecord()
    {
    }

    public ActionBaseCollectionSerializationRecord(ActionBaseSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override ActionBaseSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "MediaInfoValue")]
public record MediaInfoValueSerializationRecord : MapComponentSerializationRecord<IMediaInfoValue>
{
    public MediaInfoValueSerializationRecord()
    {
    }

    public MediaInfoValueSerializationRecord(string Id, IEnumerable<string>? Fields = null,
        string? NormalizeField = null, string? TooltipField = null,
        IEnumerable<ChartMediaInfoValueSeriesSerializationRecord>? Series = null, string? LinkURL = null,
        string? SourceURL = null)
    {
        this.Id = Id;
        this.Fields = Fields;
        this.NormalizeField = NormalizeField;
        this.TooltipField = TooltipField;
        this.Series = Series;
        this.LinkURL = LinkURL;
        this.SourceURL = SourceURL;
    }

    [ProtoMember(1)]
    public IEnumerable<string>? Fields { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? NormalizeField { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? TooltipField { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public IEnumerable<ChartMediaInfoValueSeriesSerializationRecord>? Series { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public string? LinkURL { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public string? SourceURL { get; init; }

    [ProtoMember(7)]
    public string? Id { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override IMediaInfoValue? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        var id = Guid.NewGuid();

        if (Guid.TryParse(Id, out var guid))
        {
            id = guid;
        }

        if (LinkURL is not null || SourceURL is not null)
        {
            return new ImageMediaInfoValue(LinkURL, SourceURL) { Id = id };
        }

        return new ChartMediaInfoValue(Fields?.ToArray(), NormalizeField, TooltipField,
            Series?.Any(s => !s.IsNull) == true
                ? Series.Select(s => s.FromSerializationRecord()!).ToArray()
                : null) { Id = id };
    }
}

[ProtoContract(Name = "MediaInfoValueCollection")]
internal record
    MediaInfoValueCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    MediaInfoValueSerializationRecord>
{
    public MediaInfoValueCollectionSerializationRecord()
    {
    }

    public MediaInfoValueCollectionSerializationRecord(MediaInfoValueSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MediaInfoValueSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "ChartMediaInfoValueSeries")]
public record ChartMediaInfoValueSeriesSerializationRecord : MapComponentSerializationRecord<ChartMediaInfoValueSeries>
{
    public ChartMediaInfoValueSeriesSerializationRecord()
    {
    }

    public ChartMediaInfoValueSeriesSerializationRecord(string Id, string? FieldName, string? Tooltip, double? Value)
    {
        this.Id = Id;
        this.FieldName = FieldName;
        this.Tooltip = Tooltip;
        this.Value = Value;
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? FieldName { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Tooltip { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public double? Value { get; init; }

    [ProtoMember(4)]
    public string? Id { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override ChartMediaInfoValueSeries? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        var id = Guid.NewGuid();

        if (Guid.TryParse(Id, out var guid))
        {
            id = guid;
        }

        return new ChartMediaInfoValueSeries(FieldName, Tooltip, Value) { Id = id };
    }
}

[ProtoContract(Name = "ChartMediaInfoValueSeriesCollection")]
internal record ChartMediaInfoValueSeriesCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    ChartMediaInfoValueSeriesSerializationRecord>
{
    public ChartMediaInfoValueSeriesCollectionSerializationRecord()
    {
    }

    public ChartMediaInfoValueSeriesCollectionSerializationRecord(ChartMediaInfoValueSeriesSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override ChartMediaInfoValueSeriesSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "ElementExpressionInfo")]
public record ElementExpressionInfoSerializationRecord : MapComponentSerializationRecord<ElementExpressionInfo>
{
    public ElementExpressionInfoSerializationRecord()
    {
    }

    public ElementExpressionInfoSerializationRecord(string? expression, string? title)
    {
        Expression = expression;
        Title = title;
    }

    [ProtoMember(1)]
    public string? Expression { get; init; }

    [ProtoMember(2)]
    public string? Title { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override ElementExpressionInfo? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return new ElementExpressionInfo(Expression, Title);
    }
}

[ProtoContract(Name = "ElementExpressionInfoCollection")]
internal record
    ElementExpressionInfoCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    ElementExpressionInfoSerializationRecord>
{
    public ElementExpressionInfoCollectionSerializationRecord()
    {
    }

    public ElementExpressionInfoCollectionSerializationRecord(ElementExpressionInfoSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override ElementExpressionInfoSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "FieldInfo")]
public record FieldInfoSerializationRecord : MapComponentSerializationRecord<FieldInfo>
{
    public FieldInfoSerializationRecord()
    {
    }

    public FieldInfoSerializationRecord(string Id, string? FieldName = null, string? Label = null,
        string? Tooltip = null, string? StringFieldOption = null, FieldInfoFormatSerializationRecord? Format = null,
        bool? IsEditable = null, bool? Visible = null)
    {
        this.Id = Id;
        this.FieldName = FieldName;
        this.Label = Label;
        this.Tooltip = Tooltip;
        this.StringFieldOption = StringFieldOption;
        this.Format = Format;
        this.IsEditable = IsEditable;
        this.Visible = Visible;
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? FieldName { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Label { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? Tooltip { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public string? StringFieldOption { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public FieldInfoFormatSerializationRecord? Format { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public bool? IsEditable { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(7)]
    public bool? Visible { get; init; }

    [ProtoMember(8)]
    public string? Id { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override FieldInfo? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        var id = Guid.NewGuid();

        if (Guid.TryParse(Id, out var guid))
        {
            id = guid;
        }

        StringFieldOption? sfo = StringFieldOption switch
        {
            "rich-text" => Enums.StringFieldOption.RichText,
            "text-area" => Enums.StringFieldOption.TextArea,
            "text-box" => Enums.StringFieldOption.TextBox,
            _ => null
        };

        return new FieldInfo(FieldName, Label, Tooltip, sfo, Format?.FromSerializationRecord(), IsEditable, Visible)
        {
            Id = id
        };
    }
}

[ProtoContract(Name = "FieldInfoCollection")]
internal record
    FieldInfoCollectionSerializationRecord : MapComponentCollectionSerializationRecord<FieldInfoSerializationRecord>
{
    public FieldInfoCollectionSerializationRecord()
    {
    }

    public FieldInfoCollectionSerializationRecord(FieldInfoSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override FieldInfoSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "FieldInfoFormat")]
public record FieldInfoFormatSerializationRecord : MapComponentSerializationRecord<FieldInfoFormat>
{
    public FieldInfoFormatSerializationRecord()
    {
    }

    public FieldInfoFormatSerializationRecord(string Id,
        int? Places,
        bool? DigitSeparator,
        string? DateFormat)
    {
        this.Id = Id;
        this.Places = Places;
        this.DigitSeparator = DigitSeparator;
        this.DateFormat = DateFormat;
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public int? Places { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public bool? DigitSeparator { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? DateFormat { get; init; }

    [ProtoMember(4)]
    public string? Id { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override FieldInfoFormat? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        var id = Guid.NewGuid();

        if (Guid.TryParse(Id, out var guidId))
        {
            id = guidId;
        }

        DateFormat? df = DateFormat switch
        {
            "short-date" => Enums.DateFormat.ShortDate,
            "short-date-short-time.cs" => Enums.DateFormat.ShortDateShortTime,
            "short-date-short-time-24" => Enums.DateFormat.ShortDateShortTime24,
            "short-date-long-time" => Enums.DateFormat.ShortDateLongTime,
            "short-date-long-time-24" => Enums.DateFormat.ShortDateLongTime24,
            "short-date-le" => Enums.DateFormat.ShortDateLe,
            "short-date-le-short-time" => Enums.DateFormat.ShortDateLeShortTime,
            "short-date-le-short-time-24" => Enums.DateFormat.ShortDateLeShortTime24,
            "short-date-le-long-time" => Enums.DateFormat.ShortDateLeLongTime,
            "short-date-le-long-time-24" => Enums.DateFormat.ShortDateLeLongTime24,
            "long-month-day-year" => Enums.DateFormat.LongMonthDayYear,
            "long-month-day-year-short-time" => Enums.DateFormat.LongMonthDayYearShortTime,
            "long-month-day-year-short-time-24" => Enums.DateFormat.LongMonthDayYearShortTime24,
            "long-month-day-year-long-time" => Enums.DateFormat.LongMonthDayYearLongTime,
            "long-month-day-year-long-time-24" => Enums.DateFormat.LongMonthDayYearLongTime24,
            "day-short-month-year" => Enums.DateFormat.DayShortMonthYear,
            "day-short-month-year-short-time" => Enums.DateFormat.DayShortMonthYearShortTime,
            "day-short-month-year-short-time-24" => Enums.DateFormat.DayShortMonthYearShortTime24,
            "day-short-month-year-long-time" => Enums.DateFormat.DayShortMonthYearLongTime,
            "day-short-month-year-long-time-24" => Enums.DateFormat.DayShortMonthYearLongTime24,
            "long-date" => Enums.DateFormat.LongDate,
            "long-date-short-time" => Enums.DateFormat.LongDateShortTime,
            "long-date-short-time-24" => Enums.DateFormat.LongDateShortTime24,
            "long-date-long-time" => Enums.DateFormat.LongDateLongTime,
            "long-date-long-time-24" => Enums.DateFormat.LongDateLongTime24,
            "long-month-year" => Enums.DateFormat.LongMonthYear,
            "short-month-year" => Enums.DateFormat.ShortMonthYear,
            "year" => Enums.DateFormat.Year,
            _ => null
        };

        return new FieldInfoFormat(Places, DigitSeparator, df) { Id = id };
    }
}

[ProtoContract(Name = "FieldInfoFormatCollection")]
internal record
    FieldInfoFormatCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    FieldInfoFormatSerializationRecord>
{
    public FieldInfoFormatCollectionSerializationRecord()
    {
    }

    public FieldInfoFormatCollectionSerializationRecord(FieldInfoFormatSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override FieldInfoFormatSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "Graphic")]
public record GraphicSerializationRecord : MapComponentSerializationRecord<Graphic>
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

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(11)]
    public AttributeSerializationRecord[]? StackedAttributes { get; set; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override Graphic? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        if (!Guid.TryParse(Id, out var graphicId))
        {
            graphicId = Guid.NewGuid();
        }

        Guid? layerId = null;

        if (Guid.TryParse(LayerId, out var existingLayerId))
        {
            layerId = existingLayerId;
        }

        Guid? viewId = null;

        if (Guid.TryParse(ViewId, out var existingViewId))
        {
            viewId = existingViewId;
        }

        return new Graphic(Geometry?.FromSerializationRecord(), Symbol?.FromSerializationRecord(),
            PopupTemplate?.FromSerializationRecord(), new AttributesDictionary(Attributes),
            Visible, null, AggregateGeometries, Origin?.FromSerializationRecord())
        {
            Id = graphicId,
#pragma warning disable BL0005
            LayerId = layerId,
#pragma warning restore BL0005
            ViewId = viewId
        };
    }
}

[ProtoContract(Name = "GraphicCollection")]
internal record
    GraphicCollectionSerializationRecord : MapComponentCollectionSerializationRecord<GraphicSerializationRecord>
{
    public GraphicCollectionSerializationRecord()
    {
    }

    public GraphicCollectionSerializationRecord(GraphicSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override GraphicSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "MapFont")]
public record MapFontSerializationRecord : MapComponentSerializationRecord<MapFont>
{
    public MapFontSerializationRecord()
    {
    }

    public MapFontSerializationRecord(string Id, double? Size, string? Family, string? FontStyle, string? Weight,
        string? Decoration)
    {
        this.Id = Id;
        this.Size = Size;
        this.Family = Family;
        this.FontStyle = FontStyle;
        this.Weight = Weight;
        this.Decoration = Decoration;
    }

    [ProtoMember(1)]
    public double? Size { get; init; }

    [ProtoMember(2)]
    public string? Family { get; init; }

    [ProtoMember(3)]
    public string? FontStyle { get; init; }

    [ProtoMember(4)]
    public string? Weight { get; init; }

    [ProtoMember(5)]
    public string? Decoration { get; init; }

    [ProtoMember(6)]
    public string? Id { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override MapFont? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        var id = Guid.NewGuid();

        if (Guid.TryParse(Id, out var guid))
        {
            id = guid;
        }

        return new MapFont(Size, Family, FontStyle is null ? null : Enum.Parse<MapFontStyle>(FontStyle),
            Weight is null ? null : Enum.Parse<FontWeight>(Weight),
            Decoration is null ? null : Enum.Parse<TextDecoration>(Decoration)) { Id = id };
    }
}

[ProtoContract(Name = "MapFontCollection")]
internal record
    MapFontCollectionSerializationRecord : MapComponentCollectionSerializationRecord<MapFontSerializationRecord>
{
    public MapFontCollectionSerializationRecord()
    {
    }

    public MapFontCollectionSerializationRecord(MapFontSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MapFontSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "MediaInfo")]
public record MediaInfoSerializationRecord : MapComponentSerializationRecord<MediaInfo>
{
    public MediaInfoSerializationRecord()
    {
    }

    public MediaInfoSerializationRecord(string Id, string Type)
    {
        this.Id = Id;
        this.Type = Type;
    }

    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;

    [ProtoMember(2)]
    public string? AltText { get; init; }

    [ProtoMember(3)]
    public string? Caption { get; init; }

    [ProtoMember(4)]
    public string? Title { get; init; }

    [ProtoMember(5)]
    public MediaInfoValueSerializationRecord? Value { get; init; }

    [ProtoMember(6)]
    public double? RefreshInterval { get; init; }

    [ProtoMember(7)]
    public string? Id { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override MediaInfo? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        var id = Guid.NewGuid();

        if (Guid.TryParse(Id, out var guid))
        {
            id = guid;
        }

        return Type switch
        {
            "bar-chart" => new BarChartMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ChartMediaInfoValue) { Id = id },
            "column-chart" => new ColumnChartMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ChartMediaInfoValue) { Id = id },
            "pie-chart" => new PieChartMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ChartMediaInfoValue) { Id = id },
            "line-chart" => new LineChartMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ChartMediaInfoValue) { Id = id },
            "image-media" => new ImageMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ImageMediaInfoValue,
                RefreshInterval) { Id = id },
            _ => throw new NotSupportedException($"MediaInfo type {Type} is not supported.")
        };
    }
}

[ProtoContract(Name = "MediaInfoCollection")]
internal record
    MediaInfoCollectionSerializationRecord : MapComponentCollectionSerializationRecord<MediaInfoSerializationRecord>
{
    public MediaInfoCollectionSerializationRecord()
    {
    }

    public MediaInfoCollectionSerializationRecord(MediaInfoSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MediaInfoSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "RelatedRecordsInfoFieldOrder")]
public record RelatedRecordsInfoFieldOrderSerializationRecord(
    [property: ProtoMember(1)] string? Field,
    [property: ProtoMember(2)] string? Order,
    [property: ProtoMember(3)] string Id) : MapComponentSerializationRecord<RelatedRecordsInfoFieldOrder>
{
    public RelatedRecordsInfoFieldOrderSerializationRecord() : this(null, null, Guid.NewGuid().ToString())
    {
    }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override RelatedRecordsInfoFieldOrder? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        var id = Guid.NewGuid();

        if (Guid.TryParse(Id, out var guid))
        {
            id = guid;
        }

        OrderBy? orderBy = Order is null ? null : Enum.Parse<OrderBy>(Order!, true);

        return new RelatedRecordsInfoFieldOrder(Field, orderBy) { Id = id };
    }
}

[ProtoContract(Name = "RelatedRecordsInfoFieldOrderCollection")]
internal record RelatedRecordsInfoFieldOrderCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    RelatedRecordsInfoFieldOrderSerializationRecord>
{
    public RelatedRecordsInfoFieldOrderCollectionSerializationRecord()
    {
    }

    public RelatedRecordsInfoFieldOrderCollectionSerializationRecord(
        RelatedRecordsInfoFieldOrderSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override RelatedRecordsInfoFieldOrderSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "SpatialReference")]
public record SpatialReferenceSerializationRecord : MapComponentSerializationRecord<SpatialReference>
{
    public SpatialReferenceSerializationRecord()
    {
    }

    public SpatialReferenceSerializationRecord(int? Wkid, string? Wkt = null, string? Wkt2 = null)
    {
        this.Wkid = Wkid;
        this.Wkt = Wkt;
        this.Wkt2 = Wkt2;
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public int? Wkid { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Wkt { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? Wkt2 { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override SpatialReference? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return new SpatialReference(Wkid ?? 4326, wkt: Wkt, wkt2: Wkt2);
    }
}

[ProtoContract(Name = "SpatialReferenceCollection")]
internal record
    SpatialReferenceCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    SpatialReferenceSerializationRecord>
{
    public SpatialReferenceCollectionSerializationRecord()
    {
    }

    public SpatialReferenceCollectionSerializationRecord(SpatialReferenceSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override SpatialReferenceSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "Attribute")]
public record AttributeSerializationRecord : MapComponentSerializationRecord
{
    public AttributeSerializationRecord()
    {
    }

    public AttributeSerializationRecord(string Key,
        string? Value,
        string ValueType)
    {
        this.Key = Key;
        this.Value = Value;
        this.ValueType = ValueType;
    }

    [ProtoMember(1)]
    public string Key { get; init; } = string.Empty;
    [ProtoMember(2)]
    public string? Value { get; init; }
    [ProtoMember(3)]
    public string ValueType { get; init; } = string.Empty;

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public (string Key, object? Value) FromSerializationRecord()
    {
        if (Value is null)
        {
            return (Key, Value);
        }

        if (string.Equals("OBJECTID", Key, StringComparison.OrdinalIgnoreCase))
        {
            if (long.TryParse(Value, NumberStyles.None, CultureInfo.InvariantCulture, out var numVal))
            {
                return (Key, new ObjectId(numVal));
            }

            return (Key, new ObjectId(Value));
        }

        switch (ValueType)
        {
            case "System.Int32":
            case "integer":
                return (Key, int.Parse(Value!, CultureInfo.InvariantCulture));

            case "System.Int16":
            case "small-integer":
                return (Key, short.Parse(Value!, CultureInfo.InvariantCulture));

            case "System.Int64":
            case "big-integer":
                return (Key, long.Parse(Value!, CultureInfo.InvariantCulture));

            case "System.Single":
            case "single":
                return (Key, float.Parse(Value!, CultureInfo.InvariantCulture));

            case "System.Double":
            case "double":
                return (Key, double.Parse(Value!, CultureInfo.InvariantCulture));

            case "[object Number]":
                if (int.TryParse(Value, NumberStyles.None, CultureInfo.InvariantCulture, out var intVal))
                {
                    return (Key, intVal);
                }

                if (long.TryParse(Value, NumberStyles.None, CultureInfo.InvariantCulture, out var longVal))
                {
                    return (Key, longVal);
                }

                if (double.TryParse(Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                    out var doubleVal))
                {
                    return (Key, doubleVal);
                }

                return (Key, Value);
            case "System.Boolean":
            case "[object Boolean]":
                return (Key, bool.Parse(Value!));

            case "guid":
                return (Key, Guid.Parse(Value!));

            case "System.DateTime":
            case "date":
            case "timestamp-offset":
            case "[object Date]":
                // Date is serialized in ArcGIS as a long unix timestamp, so we check for this first.
                if (long.TryParse(Value, out var unixTimestamp))
                {
                    return (Key, DateTimeOffset.FromUnixTimeMilliseconds(unixTimestamp).DateTime);
                }

                return (Key, DateTime.Parse(Value!, CultureInfo.InvariantCulture));

            case "System.DateOnly":
            case "date-only":
                return (Key, DateOnly.Parse(Value!, CultureInfo.InvariantCulture));

            case "System.TimeOnly":
            case "time-only":
                return (Key, TimeOnly.Parse(Value!, CultureInfo.InvariantCulture));

            default:
                if (Guid.TryParse(Value, out var guidValue))
                {
                    return (Key, guidValue);
                }

                if (DateTime.TryParse(Value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateValue))
                {
                    return (Key, dateValue);
                }

                return (Key, Value);
        }
    }
}

[ProtoContract(Name = "AttributeCollection")]
public record
    AttributeCollectionSerializationRecord : MapComponentCollectionSerializationRecord<AttributeSerializationRecord>
{
    public AttributeCollectionSerializationRecord()
    {
    }

    public AttributeCollectionSerializationRecord(AttributeSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override AttributeSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "GraphicOrigin")]
public record GraphicOriginSerializationRecord : MapComponentSerializationRecord<GraphicOrigin>
{
    public GraphicOriginSerializationRecord()
    {
    }

    public GraphicOriginSerializationRecord(string? LayerId, string? ArcGISLayerId, int? LayerIndex)
    {
        this.LayerId = LayerId;
        this.ArcGISLayerId = ArcGISLayerId;
        this.LayerIndex = LayerIndex;
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? LayerId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? ArcGISLayerId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public int? LayerIndex { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override GraphicOrigin? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return new GraphicOrigin(LayerId is null ? null : Guid.Parse(LayerId),
            ArcGISLayerId, LayerIndex);
    }
}

[ProtoContract(Name = "GraphicOriginCollection")]
internal record
    GraphicOriginCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    GraphicOriginSerializationRecord>
{
    public GraphicOriginCollectionSerializationRecord()
    {
    }

    public GraphicOriginCollectionSerializationRecord(GraphicOriginSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override GraphicOriginSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "MapPath")]
public record MapPathSerializationRecord : MapComponentSerializationRecord<MapPath>
{
    public MapPathSerializationRecord()
    {
    }

    public MapPathSerializationRecord(MapPointSerializationRecord[] Points)
    {
        this.Points = Points;
    }

    [ProtoMember(1)]
    public MapPointSerializationRecord[] Points { get; init; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override MapPath? FromSerializationRecord()
    {
        if (IsNull || (Points.Length == 0) || Points.Any(p => p.IsNull))
        {
            return null;
        }

        return new MapPath(Points.Select(p => p.FromSerializationRecord()!));
    }
}

[ProtoContract(Name = "MapPathCollection")]
internal record
    MapPathCollectionSerializationRecord : MapComponentCollectionSerializationRecord<MapPathSerializationRecord>
{
    public MapPathCollectionSerializationRecord()
    {
    }

    public MapPathCollectionSerializationRecord(MapPathSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MapPathSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "MapPoint")]
public record MapPointSerializationRecord : MapComponentSerializationRecord<MapPoint>
{
    public MapPointSerializationRecord()
    {
    }

    public MapPointSerializationRecord(double[] Coordinates)
    {
        this.Coordinates = Coordinates;
    }

    [ProtoMember(1)]
    public double[] Coordinates { get; init; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override MapPoint? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return new MapPoint(Coordinates);
    }
}

[ProtoContract(Name = "MapPointCollection")]
internal record
    MapPointCollectionSerializationRecord : MapComponentCollectionSerializationRecord<MapPointSerializationRecord>
{
    public MapPointCollectionSerializationRecord()
    {
    }

    public MapPointCollectionSerializationRecord(MapPointSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MapPointSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "MeshComponent")]
public record MeshComponentSerializationRecord : MapComponentSerializationRecord<MeshComponent>
{
    public MeshComponentSerializationRecord()
    {
    }

    public MeshComponentSerializationRecord(byte[]? faces,
        MeshComponentMaterialSerializationRecord? material,
        string? name,
        string? shading)
    {
        Faces = faces;
        Material = material;
        Name = name;
        Shading = shading;
    }

    [ProtoMember(1)]
    public byte[]? Faces { get; init; }

    [ProtoMember(2)]
    public MeshComponentMaterialSerializationRecord? Material { get; init; }

    [ProtoMember(3)]
    public string? Name { get; init; }

    [ProtoMember(4)]
    public string? Shading { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override MeshComponent? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return new MeshComponent(Faces,
            Material?.FromSerializationRecord(),
            Name,
            Shading is null ? null : Enum.Parse<MeshShading>(Shading));
    }
}

[ProtoContract(Name = "MeshComponentCollection")]
internal record
    MeshComponentCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    MeshComponentSerializationRecord>
{
    public MeshComponentCollectionSerializationRecord(MeshComponentSerializationRecord[] items)
    {
        Items = items;
    }
    
    [ProtoMember(1)]
    public sealed override MeshComponentSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "MeshComponentMaterial")]
public record MeshComponentMaterialSerializationRecord : MapComponentSerializationRecord<IMeshComponentMaterial>
{
    public MeshComponentMaterialSerializationRecord()
    {
    }

    public MeshComponentMaterialSerializationRecord(double? alphaCutoff,
        string? alphaMode,
        MapColorSerializationRecord? color,
        MeshTextureSerializationRecord? colorTexture,
        MeshTextureTransformSerializationRecord? colorTextureTransform,
        bool? doubleSided,
        MeshTextureSerializationRecord? normalTexture,
        MeshTextureTransformSerializationRecord? normalTextureTransform,
        MapColorSerializationRecord? emissiveColor,
        MeshTextureSerializationRecord? emissiveTexture,
        MeshTextureTransformSerializationRecord? emissiveTextureTransform,
        double? metallic,
        MeshTextureSerializationRecord? metallicRoughnessTexture,
        MeshTextureSerializationRecord? occlusionTexture,
        MeshTextureTransformSerializationRecord? occlusionTextureTransform,
        double? roughness)
    {
        AlphaCutoff = alphaCutoff;
        AlphaMode = alphaMode;
        Color = color;
        ColorTexture = colorTexture;
        ColorTextureTransform = colorTextureTransform;
        DoubleSided = doubleSided;
        NormalTexture = normalTexture;
        NormalTextureTransform = normalTextureTransform;
        EmissiveColor = emissiveColor;
        EmissiveTexture = emissiveTexture;
        EmissiveTextureTransform = emissiveTextureTransform;
        Metallic = metallic;
        MetallicRoughnessTexture = metallicRoughnessTexture;
        OcclusionTexture = occlusionTexture;
        OcclusionTextureTransform = occlusionTextureTransform;
        Roughness = roughness;
    }

    [ProtoMember(1)]
    public double? AlphaCutoff { get; init; }

    [ProtoMember(2)]
    public string? AlphaMode { get; init; }

    [ProtoMember(3)]
    public MapColorSerializationRecord? Color { get; init; }

    [ProtoMember(4)]
    public MeshTextureSerializationRecord? ColorTexture { get; init; }

    [ProtoMember(5)]
    public MeshTextureTransformSerializationRecord? ColorTextureTransform { get; init; }

    [ProtoMember(6)]
    public bool? DoubleSided { get; init; }

    [ProtoMember(7)]
    public MeshTextureSerializationRecord? NormalTexture { get; init; }

    [ProtoMember(8)]
    public MeshTextureTransformSerializationRecord? NormalTextureTransform { get; init; }

    [ProtoMember(9)]
    public MapColorSerializationRecord? EmissiveColor { get; init; }

    [ProtoMember(10)]
    public MeshTextureSerializationRecord? EmissiveTexture { get; init; }

    [ProtoMember(11)]
    public MeshTextureTransformSerializationRecord? EmissiveTextureTransform { get; init; }

    [ProtoMember(12)]
    public double? Metallic { get; init; }

    [ProtoMember(13)]
    public MeshTextureSerializationRecord? MetallicRoughnessTexture { get; init; }

    [ProtoMember(14)]
    public MeshTextureSerializationRecord? OcclusionTexture { get; init; }

    [ProtoMember(15)]
    public MeshTextureTransformSerializationRecord? OcclusionTextureTransform { get; init; }

    [ProtoMember(16)]
    public double? Roughness { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override IMeshComponentMaterial? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        if ((EmissiveColor != null) || (EmissiveTexture != null)
            || (EmissiveTextureTransform != null) || (Metallic != null)
            || (MetallicRoughnessTexture != null) || (OcclusionTexture != null)
            || (OcclusionTextureTransform != null) || (Roughness != null))
        {
            return new MeshMaterialMetallicRoughness(AlphaCutoff,
                AlphaMode is null ? null : Enum.Parse<AlphaMode>(AlphaMode),
                Color?.FromSerializationRecord(),
                ColorTexture?.FromSerializationRecord(),
                ColorTextureTransform?.FromSerializationRecord(),
                DoubleSided,
                EmissiveColor?.FromSerializationRecord(),
                EmissiveTexture?.FromSerializationRecord(),
                EmissiveTextureTransform?.FromSerializationRecord(),
                Metallic,
                MetallicRoughnessTexture?.FromSerializationRecord(),
                NormalTexture?.FromSerializationRecord(),
                NormalTextureTransform?.FromSerializationRecord(),
                OcclusionTexture?.FromSerializationRecord(),
                OcclusionTextureTransform?.FromSerializationRecord(),
                Roughness);
        }

        return new MeshMaterial(AlphaCutoff,
            AlphaMode is null ? null : Enum.Parse<AlphaMode>(AlphaMode),
            Color?.FromSerializationRecord(),
            ColorTexture?.FromSerializationRecord(),
            ColorTextureTransform?.FromSerializationRecord(),
            DoubleSided,
            NormalTexture?.FromSerializationRecord(),
            NormalTextureTransform?.FromSerializationRecord());
    }
}

[ProtoContract(Name = "MeshComponentMaterialCollection")]
internal record
    MeshComponentMaterialCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    MeshComponentMaterialSerializationRecord>
{
    public MeshComponentMaterialCollectionSerializationRecord(MeshComponentMaterialSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MeshComponentMaterialSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "MeshTexture")]
public record MeshTextureSerializationRecord : MapComponentSerializationRecord<MeshTexture>
{
    public MeshTextureSerializationRecord()
    {
    }

    public MeshTextureSerializationRecord(ImageDataSerializationRecord? imageData,
        string?[]? wrap,
        bool? transparent,
        string? url)
    {
        ImageData = imageData;
        Wrap = wrap;
        Transparent = transparent;
        Url = url;
    }

    [ProtoMember(1)]
    public ImageDataSerializationRecord? ImageData { get; init; }

    [ProtoMember(2)]
    public string?[]? Wrap { get; init; }

    [ProtoMember(3)]
    public bool? Transparent { get; init; }

    [ProtoMember(4)]
    public string? Url { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override MeshTexture? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        SeparableWrapModes? wrapModes = null;

        if (Wrap != null)
        {
            if (Wrap.Length == 2)
            {
                var first = Wrap[0];
                var second = Wrap[1];

                wrapModes = new SeparableWrapModes(first is null ? null : Enum.Parse<WrapMode>(first),
                    second is null ? null : Enum.Parse<WrapMode>(second));
            }
            else if (Wrap.Length == 1)
            {
                var value = Wrap[0];
                WrapMode? wrapVal = value is null ? null : Enum.Parse<WrapMode>(value);
                wrapModes = new SeparableWrapModes(wrapVal, wrapVal);
            }
        }

        return new MeshTexture(null, ImageData?.FromSerializationRecord(), wrapModes, Transparent, Url);
    }
}

[ProtoContract(Name = "MeshTextureCollection")]
internal record
    MeshTextureCollectionSerializationRecord : MapComponentCollectionSerializationRecord<MeshTextureSerializationRecord>
{
    public MeshTextureCollectionSerializationRecord(MeshTextureSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MeshTextureSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "ImageData")]
public record ImageDataSerializationRecord : MapComponentSerializationRecord<ImageData>
{
    public ImageDataSerializationRecord()
    {
    }

    public ImageDataSerializationRecord(byte[] data,
        string colorSpace,
        long height,
        long width)
    {
        Data = data;
        ColorSpace = colorSpace;
        Height = height;
        Width = width;
    }

    [ProtoMember(1)]
    public byte[]? Data { get; init; }

    [ProtoMember(2)]
    public string? ColorSpace { get; init; }

    [ProtoMember(3)]
    public long Height { get; init; }

    [ProtoMember(4)]
    public long Width { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override ImageData? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return new ImageData(Data ?? [], ColorSpace ?? string.Empty, Height, Width);
    }
}

[ProtoContract(Name = "ImageDataCollection")]
public record ImageDataCollectionSerializationRecord 
    : MapComponentCollectionSerializationRecord<ImageDataSerializationRecord>
{
    public ImageDataCollectionSerializationRecord(ImageDataSerializationRecord[] items)
    {
        Items = items;
    }
    
    public sealed override ImageDataSerializationRecord[]? Items { get; set; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "MeshTextureTransform")]
public record MeshTextureTransformSerializationRecord : MapComponentSerializationRecord<MeshTextureTransform>
{
    public MeshTextureTransformSerializationRecord()
    {
    }

    public MeshTextureTransformSerializationRecord(double[]? offset,
        double? rotation,
        double[]? scale)
    {
        Offset = offset;
        Rotation = rotation;
        Scale = scale;
    }

    [ProtoMember(1)]
    public double[]? Offset { get; init; }

    [ProtoMember(2)]
    public double? Rotation { get; init; }

    [ProtoMember(3)]
    public double[]? Scale { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override MeshTextureTransform? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return new MeshTextureTransform(Offset, Rotation, Scale);
    }
}

[ProtoContract(Name = "MeshTextureTransformCollection")]
internal record
    MeshTextureTransformCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    MeshTextureTransformSerializationRecord>
{
    public MeshTextureTransformCollectionSerializationRecord(MeshTextureTransformSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MeshTextureTransformSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "MeshTransform")]
public record MeshTransformSerializationRecord : MapComponentSerializationRecord<MeshTransform>
{
    public MeshTransformSerializationRecord()
    {
    }

    public MeshTransformSerializationRecord(double? rotationAngle,
        double[]? rotationAxis,
        double[]? scale,
        double[]? translation)
    {
        RotationAngle = rotationAngle;
        RotationAxis = rotationAxis;
        Scale = scale;
        Translation = translation;
    }

    [ProtoMember(1)]
    public double? RotationAngle { get; init; }

    [ProtoMember(2)]
    public double[]? RotationAxis { get; init; }

    [ProtoMember(3)]
    public double[]? Scale { get; init; }

    [ProtoMember(4)]
    public double[]? Translation { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override MeshTransform? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return new MeshTransform(RotationAngle, RotationAxis, Scale, Translation);
    }
}

[ProtoContract(Name = "MeshTransformCollection")]
internal record
    MeshTransformCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    MeshTransformSerializationRecord>
{
    public MeshTransformCollectionSerializationRecord(MeshTransformSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MeshTransformSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "MeshVertexAttributes")]
public record MeshVertexAttributesSerializationRecord : MapComponentSerializationRecord<MeshVertexAttributes>
{
    public MeshVertexAttributesSerializationRecord()
    {
    }

    public MeshVertexAttributesSerializationRecord(byte[]? color,
        double[]? normal,
        double[]? position,
        double[]? tangent,
        double[]? uv)
    {
        Color = color;
        Normal = normal;
        Position = position;
        Tangent = tangent;
        Uv = uv;
    }

    [ProtoMember(1)]
    public byte[]? Color { get; init; }

    [ProtoMember(2)]
    public double[]? Normal { get; init; }

    [ProtoMember(3)]
    public double[]? Position { get; init; }

    [ProtoMember(4)]
    public double[]? Tangent { get; init; }

    [ProtoMember(5)]
    public double[]? Uv { get; init; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override MeshVertexAttributes? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return new MeshVertexAttributes(Color, Normal, Position, Tangent, Uv);
    }
}

[ProtoContract(Name = "MeshVertexAttributesCollection")]
internal record
    MeshVertexAttributesCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    MeshVertexAttributesSerializationRecord>
{
    public MeshVertexAttributesCollectionSerializationRecord(MeshVertexAttributesSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MeshVertexAttributesSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "MeshVertexSpace")]
public record MeshVertexSpaceSerializationRecord : MapComponentSerializationRecord<IMeshVertexSpace>
{
    public MeshVertexSpaceSerializationRecord()
    {
    }

    public MeshVertexSpaceSerializationRecord(string? type,
        double[]? origin)
    {
        Type = type;
        Origin = origin;
    }

    [ProtoMember(1)]
    public string? Type { get; set; }

    [ProtoMember(2)]
    public double[]? Origin { get; set; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override IMeshVertexSpace? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return Type switch
        {
            "local" => new MeshLocalVertexSpace(Origin),
            "georeferenced" => new MeshGeoreferencedVertexSpace(Origin),
            _ => throw new NotSupportedException($"MeshVertexSpace type {Type} is not supported.")
        };
    }
}

[ProtoContract(Name = "MeshVertexSpaceCollection")]
internal record
    MeshVertexSpaceCollectionSerializationRecord : MapComponentCollectionSerializationRecord<
    MeshVertexSpaceSerializationRecord>
{
    public MeshVertexSpaceCollectionSerializationRecord(MeshVertexSpaceSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MeshVertexSpaceSerializationRecord[]? Items { get; set; } = [];

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "ViewHitCollection")]
internal record
    ViewHitCollectionSerializationRecord : MapComponentCollectionSerializationRecord<ViewHitSerializationRecord>
{
    public ViewHitCollectionSerializationRecord()
    {
    }

    public ViewHitCollectionSerializationRecord(ViewHitSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override ViewHitSerializationRecord[]? Items { get; set; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

[ProtoContract(Name = "ViewHit")]
public record ViewHitSerializationRecord : MapComponentSerializationRecord<ViewHit>
{
    public ViewHitSerializationRecord()
    {
    }

    public ViewHitSerializationRecord(string? Type,
        GeometrySerializationRecord? MapPoint,
        GraphicSerializationRecord? Graphic,
        string? LayerId)
    {
        this.Type = Type;
        this.MapPoint = MapPoint;
        this.Graphic = Graphic;
        this.LayerId = LayerId;
    }

    [ProtoMember(1)]
    public string? Type { get; set; }

    [ProtoMember(2)]
    public GeometrySerializationRecord? MapPoint { get; set; }

    [ProtoMember(3)]
    public GraphicSerializationRecord? Graphic { get; set; }

    [ProtoMember(4)]
    public string? LayerId { get; set; }

    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    public override ViewHit? FromSerializationRecord()
    {
        if (IsNull || MapPoint is null || MapPoint.IsNull)
        {
            return null;
        }

        if (Type == "graphic")
        {
            if (Graphic is null || Graphic.IsNull)
            {
                return null;
            }

            Guid? layerId = null;

            if (Guid.TryParse(LayerId, out var layerGuid))
            {
                layerId = layerGuid;
            }

            return new GraphicHit(Graphic!.FromSerializationRecord()!, layerId,
                (Point)MapPoint!.FromSerializationRecord()!);
        }

        return new ViewHit(Type!, (Point)MapPoint!.FromSerializationRecord()!);
    }
}