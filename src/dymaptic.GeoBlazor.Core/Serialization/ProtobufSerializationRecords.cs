using FieldInfo = dymaptic.GeoBlazor.Core.Components.FieldInfo;


namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Base class for all Protobuf serialization records for MapComponents.
/// </summary>
[ProtoContract(Name = "MapComponent")]
[ProtoInclude(100, typeof(GeometrySerializationRecord))]
[ProtoInclude(200, typeof(PopupContentSerializationRecord))]
[ProtoInclude(300, typeof(PopupExpressionInfoSerializationRecord))]
[ProtoInclude(400, typeof(PopupTemplateSerializationRecord))]
[ProtoInclude(500, typeof(SymbolSerializationRecord))]
[ProtoInclude(600, typeof(ActionBaseSerializationRecord))]
[ProtoInclude(700, typeof(ChartMediaInfoValueSerializationRecord))]
[ProtoInclude(800, typeof(ChartMediaInfoValueSeriesSerializationRecord))]
[ProtoInclude(900, typeof(ElementExpressionInfoSerializationRecord))]
[ProtoInclude(1000, typeof(FieldInfoSerializationRecord))]
[ProtoInclude(1100, typeof(FieldInfoFormatSerializationRecord))]
[ProtoInclude(1200, typeof(GraphicSerializationRecord))]
[ProtoInclude(1300, typeof(MapFontSerializationRecord))]
[ProtoInclude(1400, typeof(MediaInfoSerializationRecord))]
[ProtoInclude(1500, typeof(RelatedRecordsInfoFieldOrderSerializationRecord))]
[ProtoInclude(1600, typeof(SpatialReferenceSerializationRecord))]
[ProtoInclude(1700, typeof(AttributeSerializationRecord))]
[ProtoInclude(1800, typeof(GraphicOriginSerializationRecord))]
[ProtoInclude(1900, typeof(MapPathSerializationRecord))]
[ProtoInclude(2000, typeof(MapPointSerializationRecord))]
[ProtoInclude(2100, typeof(MeshComponentSerializationRecord))]
[ProtoInclude(2200, typeof(MeshComponentMaterialSerializationRecord))]
[ProtoInclude(2300, typeof(MeshTransformSerializationRecord))]
[ProtoInclude(2400, typeof(MeshTextureTransformSerializationRecord))]
[ProtoInclude(2500, typeof(MeshVertexAttributesSerializationRecord))]
[ProtoInclude(2600, typeof(MeshVertexSpaceSerializationRecord))]
[ProtoInclude(2700, typeof(MeshTextureSerializationRecord))]
[ProtoInclude(2800, typeof(ViewHitSerializationRecord))]
public abstract record MapComponentSerializationRecord
{
    /// <summary>
    ///     The Type of the Protobuf collection for this class.
    /// </summary>
    [ProtoIgnore]
    public abstract Type CollectionType { get; }
}

[ProtoContract(Name = "MapComponentCollection")]
[ProtoInclude(100, typeof(GeometryCollectionSerializationRecord))]
[ProtoInclude(200, typeof(PopupContentCollectionSerializationRecord))]
[ProtoInclude(300, typeof(PopupExpressionInfoCollectionSerializationRecord))]
[ProtoInclude(400, typeof(PopupTemplateCollectionSerializationRecord))]
[ProtoInclude(500, typeof(SymbolCollectionSerializationRecord))]
[ProtoInclude(600, typeof(ActionBaseCollectionSerializationRecord))]
[ProtoInclude(700, typeof(ChartMediaInfoValueCollectionSerializationRecord))]
[ProtoInclude(800, typeof(ChartMediaInfoValueSeriesCollectionSerializationRecord))]
[ProtoInclude(900, typeof(ElementExpressionInfoCollectionSerializationRecord))]
[ProtoInclude(1000, typeof(FieldInfoCollectionSerializationRecord))]
[ProtoInclude(1100, typeof(FieldInfoFormatCollectionSerializationRecord))]
[ProtoInclude(1200, typeof(GraphicCollectionSerializationRecord))]
[ProtoInclude(1300, typeof(MapFontCollectionSerializationRecord))]
[ProtoInclude(1400, typeof(MediaInfoCollectionSerializationRecord))]
[ProtoInclude(1500, typeof(RelatedRecordsInfoFieldOrderCollectionSerializationRecord))]
[ProtoInclude(1600, typeof(SpatialReferenceCollectionSerializationRecord))]
[ProtoInclude(1700, typeof(AttributeCollectionSerializationRecord))]
[ProtoInclude(1800, typeof(GraphicOriginCollectionSerializationRecord))]
[ProtoInclude(1900, typeof(MapPathCollectionSerializationRecord))]
[ProtoInclude(2000, typeof(MapPointCollectionSerializationRecord))]
[ProtoInclude(2100, typeof(MeshComponentCollectionSerializationRecord))]
[ProtoInclude(2200, typeof(MeshComponentMaterialCollectionSerializationRecord))]
[ProtoInclude(2300, typeof(MeshTransformCollectionSerializationRecord))]
[ProtoInclude(2400, typeof(MeshTextureTransformCollectionSerializationRecord))]
[ProtoInclude(2500, typeof(MeshVertexAttributesCollectionSerializationRecord))]
[ProtoInclude(2600, typeof(MeshVertexSpaceCollectionSerializationRecord))]
[ProtoInclude(2700, typeof(MeshTextureCollectionSerializationRecord))]
[ProtoInclude(2800, typeof(ViewHitCollectionSerializationRecord))]
public record MapComponentBaseCollectionSerializationRecord;

public abstract record MapComponentCollectionSerializationRecord<TItem>: MapComponentBaseCollectionSerializationRecord
    where TItem : MapComponentSerializationRecord
{
    public abstract TItem[]? Items { get; set; }
}

[ProtoContract(Name = "Geometry")]
public record GeometrySerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(GeometryCollectionSerializationRecord);

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

    public Geometry FromSerializationRecord()
    {
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
                return new Polyline(Paths!.Select(x => x.FromSerializationRecord()).ToArray(),
                    SpatialReference?.FromSerializationRecord(), HasM, HasZ)
                {
                    Extent = extent, Id = id, IsSimple = IsSimple
                };
            case "polygon":
                return Center is not null && Radius is not null
                    ? new Circle((Point)Center.FromSerializationRecord(), Radius.Value,
                        Centroid?.FromSerializationRecord() as Point, Geodesic, HasM, HasZ, NumberOfPoints,
                        RadiusUnit is null ? null : Enum.Parse<RadiusUnit>(RadiusUnit),
                        Rings!.Select(x => x.FromSerializationRecord()).ToArray(),
                        SpatialReference?.FromSerializationRecord()) { Extent = extent, Id = id, IsSimple = IsSimple }
                    : new Polygon(Rings!.Select(x => x.FromSerializationRecord()).ToArray(),
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
                    var points = Points?.Select(p =>
                        {
                            var mp = p.FromSerializationRecord();

                            return new Point(x: mp[0], y: mp[1]);
                        })
                        .ToArray();

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
internal record GeometryCollectionSerializationRecord: MapComponentCollectionSerializationRecord<GeometrySerializationRecord>
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
}

[ProtoContract(Name = "PopupContent")]
public record PopupContentSerializationRecord : MapComponentSerializationRecord
{
    public PopupContentSerializationRecord()
    {
    }
    
    public PopupContentSerializationRecord(string Id, string Type)
    {
        this.Type = Type;
        this.Id = Id;
    }
    
    public override Type CollectionType => typeof(PopupContentCollectionSerializationRecord);

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

    public PopupContent FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();

        if (Guid.TryParse(Id, out Guid guidId))
        {
            id = guidId;
        }

        if (Type == "custom")
        {
            // CustomPopupContent is in GeoBlazor Pro assembly, so we need to use reflection to get the type
            Type? customType = System.Type.GetType("dymaptic.GeoBlazor.Pro.Components.Popups.CustomPopupContent, dymaptic.GeoBlazor.Pro");

            if (customType is not null && customType.IsSubclassOf(typeof(PopupContent)))
            {
                PopupContent? customContent = Activator.CreateInstance(customType, args: [null, OutFields]) as PopupContent;

                if (customContent is null)
                {
                    throw new InvalidOperationException("CustomPopupContent could not be created. Ensure the type is correct and the assembly is loaded.");
                }
                customContent.Id = id;

                return customContent;
            }
        }
        
        return Type switch
        {
            "fields" => new FieldsPopupContent(FieldInfos?.Select(i => 
                    i.FromSerializationRecord()).ToArray() ?? [],
                Description, Title) { Id = id },
            "text" => new TextPopupContent(Text){ Id = id },
            "attachments" => new AttachmentsPopupContent(Title, Description, 
                DisplayType is null ? null : Enum.Parse<AttachmentsPopupContentDisplayType>(DisplayType))
            {
                Id = id
            },
            "expression" => new ExpressionPopupContent(ExpressionInfo?.FromSerializationRecord()) { Id = id },
            "media" => new MediaPopupContent(Title, Description,
                MediaInfos?.Select(i => i.FromSerializationRecord()).ToArray(),
                ActiveMediaInfoIndex) { Id = id },
            "relationship" => new RelationshipPopupContent(Title, Description, DisplayCount,
                DisplayType, OrderByFields?.Select(x => x.FromSerializationRecord()).ToList(),
                RelationshipId) { Id = id },
            _ => throw new NotSupportedException($"PopupContent type {Type} is not supported")
        };
    }
}

[ProtoContract(Name = "PopupContentCollection")]
internal record PopupContentCollectionSerializationRecord: MapComponentCollectionSerializationRecord<PopupContentSerializationRecord>
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
}

[ProtoContract(Name = "ExpressionInfo")]
public record PopupExpressionInfoSerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(PopupExpressionInfoCollectionSerializationRecord);

    public PopupExpressionInfo FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();

        if (Guid.TryParse(Id, out Guid guid))
        {
            id = guid;
        }
        
        return new PopupExpressionInfo(Expression, Name, 
            ReturnType is null ? null : Enum.Parse<PopupExpressionInfoReturnType>(ReturnType),
            Title) { Id = id };
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
}

[ProtoContract(Name = "PopupExpressionInfoCollection")]
internal record PopupExpressionInfoCollectionSerializationRecord: MapComponentCollectionSerializationRecord<PopupExpressionInfoSerializationRecord>
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
}

[ProtoContract(Name = "PopupTemplate")]
public record PopupTemplateSerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(PopupTemplateCollectionSerializationRecord);

    public PopupTemplate FromSerializationRecord()
    {
        return new PopupTemplate(Title, StringContent, OutFields?.ToList(),
            FieldInfos?.Select(f => f.FromSerializationRecord()).ToList(),
            Content?.Select(c => c.FromSerializationRecord()).ToList(),
            ExpressionInfos?.Select(e => e.FromSerializationRecord()).ToList(), 
            OverwriteActions, ReturnGeometry, 
            Actions?.Select(a => a.FromSerializationRecord()).ToList());
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
}

[ProtoContract(Name = "PopupTemplateCollection")]
internal record PopupTemplateCollectionSerializationRecord: MapComponentCollectionSerializationRecord<PopupTemplateSerializationRecord>
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
}

[ProtoContract(Name = "Symbol")]
public record SymbolSerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(SymbolCollectionSerializationRecord);

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

[ProtoContract(Name = "SymbolCollection")]
internal record SymbolCollectionSerializationRecord: MapComponentCollectionSerializationRecord<SymbolSerializationRecord>
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
}

[ProtoContract(Name = "Action")]
public record ActionBaseSerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(ActionBaseCollectionSerializationRecord);

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

    public ActionBase FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guidId))
        {
            id = guidId;
        }
        
        return Type switch
        {
            "button" => new ActionButton(Title, Image, ActionId, null, ClassName, Active, Disabled, Visible)
            {
                Id = id
            },
            "toggle" => new ActionToggle(Title, ActionId, null, Value, Active, Disabled, Visible)
            {
                Id = id
            },
            _ => throw new NotSupportedException()
        };
    }
}

[ProtoContract(Name = "ActionCollection")]
internal record ActionBaseCollectionSerializationRecord: MapComponentCollectionSerializationRecord<ActionBaseSerializationRecord>
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
}

[ProtoContract(Name = "ChartMediaInfoValue")]
public record ChartMediaInfoValueSerializationRecord : MapComponentSerializationRecord
{
    public ChartMediaInfoValueSerializationRecord()
    {
    }

    public ChartMediaInfoValueSerializationRecord(string Id, IEnumerable<string>? Fields = null, 
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
    
    public override Type CollectionType => typeof(ChartMediaInfoValueCollectionSerializationRecord);

    public object FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guid))
        {
            id = guid;
        }
        
        if (LinkURL is not null || SourceURL is not null)
        {
            return new ImageMediaInfoValue(LinkURL, SourceURL) { Id = id };
        }

        return new ChartMediaInfoValue(Fields?.ToArray(), NormalizeField, TooltipField, 
            Series?.Select(s => s.FromSerializationRecord()).ToArray())
        {
            Id = id
        };
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
}

[ProtoContract(Name = "ChartMediaInfoValueCollection")]
internal record ChartMediaInfoValueCollectionSerializationRecord: MapComponentCollectionSerializationRecord<ChartMediaInfoValueSerializationRecord>
{
    public ChartMediaInfoValueCollectionSerializationRecord()
    {
    }

    public ChartMediaInfoValueCollectionSerializationRecord(ChartMediaInfoValueSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override ChartMediaInfoValueSerializationRecord[]? Items { get; set; } = [];
}

[ProtoContract(Name = "ChartMediaInfoValueSeries")]
public record ChartMediaInfoValueSeriesSerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(ChartMediaInfoValueSeriesCollectionSerializationRecord);

    public ChartMediaInfoValueSeries FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guid))
        {
            id = guid;
        }
        return new ChartMediaInfoValueSeries(FieldName, Tooltip, Value) { Id = id };
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
}

[ProtoContract(Name = "ChartMediaInfoValueSeriesCollection")]
internal record ChartMediaInfoValueSeriesCollectionSerializationRecord: MapComponentCollectionSerializationRecord<ChartMediaInfoValueSeriesSerializationRecord>
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
}

[ProtoContract(Name = "ElementExpressionInfo")]
public record ElementExpressionInfoSerializationRecord: MapComponentSerializationRecord
{
    public ElementExpressionInfoSerializationRecord()
    {
    }
    
    public ElementExpressionInfoSerializationRecord(string? expression, string? title)
    {
        Expression = expression;
        Title = title;
    }
    
    public override Type CollectionType => typeof(ElementExpressionInfoCollectionSerializationRecord);
    
    [ProtoMember(1)]
    public string? Expression { get; init; }
    
    [ProtoMember(2)]
    public string? Title { get; init; }
    
    public ElementExpressionInfo FromSerializationRecord()
    {
        return new ElementExpressionInfo(Expression, Title);
    }
}

[ProtoContract(Name = "ElementExpressionInfoCollection")]
internal record ElementExpressionInfoCollectionSerializationRecord: MapComponentCollectionSerializationRecord<ElementExpressionInfoSerializationRecord>
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
}

[ProtoContract(Name = "FieldInfo")]
public record FieldInfoSerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(FieldInfoCollectionSerializationRecord);

    public FieldInfo FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guid))
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
}

[ProtoContract(Name = "FieldInfoCollection")]
internal record FieldInfoCollectionSerializationRecord: MapComponentCollectionSerializationRecord<FieldInfoSerializationRecord>
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
}

[ProtoContract(Name = "FieldInfoFormat")]
public record FieldInfoFormatSerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(FieldInfoFormatCollectionSerializationRecord);

    public FieldInfoFormat FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guidId))
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
}

[ProtoContract(Name = "FieldInfoFormatCollection")]
internal record FieldInfoFormatCollectionSerializationRecord: MapComponentCollectionSerializationRecord<FieldInfoFormatSerializationRecord>
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
}

[ProtoContract(Name = "Graphic")]
public record GraphicSerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(GraphicCollectionSerializationRecord);

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
#pragma warning disable BL0005
            LayerId = layerId,
#pragma warning restore BL0005
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
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(11)]
    public AttributeSerializationRecord[]? StackedAttributes { get; set; }
}

[ProtoContract(Name = "GraphicCollection")]
internal record GraphicCollectionSerializationRecord: MapComponentCollectionSerializationRecord<GraphicSerializationRecord>
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
}

[ProtoContract]
public record MapFontSerializationRecord: MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(MapFontCollectionSerializationRecord);

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

    public MapFont FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guid))
        {
            id = guid;
        }
        return new MapFont(Size, Family, FontStyle is null ? null : Enum.Parse<MapFontStyle>(FontStyle), 
            Weight is null ? null : Enum.Parse<FontWeight>(Weight), 
            Decoration is null ? null : Enum.Parse<TextDecoration>(Decoration)) { Id = id };
    }
}

[ProtoContract(Name = "MapFontCollection")]
internal record MapFontCollectionSerializationRecord: MapComponentCollectionSerializationRecord<MapFontSerializationRecord>
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
}

[ProtoContract(Name = "MediaInfo")]
public record MediaInfoSerializationRecord : MapComponentSerializationRecord
{
    public MediaInfoSerializationRecord()
    {
    }
    
    public MediaInfoSerializationRecord(string Id, string Type)
    {
        this.Id = Id;
        this.Type = Type;
    }
    
    public override Type CollectionType => typeof(MediaInfoCollectionSerializationRecord);

    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;
    
    [ProtoMember(2)]
    public string? AltText { get; init; }

    [ProtoMember(3)]
    public string? Caption { get; init; }

    [ProtoMember(4)]
    public string? Title { get; init; }

    [ProtoMember(5)]
    public ChartMediaInfoValueSerializationRecord? Value { get; init; }

    [ProtoMember(6)]
    public double? RefreshInterval { get; init; }
    
    [ProtoMember(7)]
    public string? Id { get; init; }

    public MediaInfo FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guid))
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
internal record MediaInfoCollectionSerializationRecord: MapComponentCollectionSerializationRecord<MediaInfoSerializationRecord>
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
}

[ProtoContract(Name = "RelatedRecordsInfoFieldOrder")]
public record RelatedRecordsInfoFieldOrderSerializationRecord(
    [property: ProtoMember(1)] string? Field,
    [property: ProtoMember(2)] string? Order,
    [property: ProtoMember(3)] string Id) : MapComponentSerializationRecord
{
    public RelatedRecordsInfoFieldOrderSerializationRecord() : this(null, null, Guid.NewGuid().ToString())
    {
    }

    public override Type CollectionType => typeof(RelatedRecordsInfoFieldOrderCollectionSerializationRecord);

    public RelatedRecordsInfoFieldOrder FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();

        if (Guid.TryParse(Id, out Guid guid))
        {
            id = guid;
        }
        
        OrderBy? orderBy = Order is null ? null : Enum.Parse<OrderBy>(Order!, true);
        return new RelatedRecordsInfoFieldOrder(Field, orderBy) { Id = id };
    }
}

[ProtoContract(Name = "RelatedRecordsInfoFieldOrderCollection")]
internal record RelatedRecordsInfoFieldOrderCollectionSerializationRecord: MapComponentCollectionSerializationRecord<RelatedRecordsInfoFieldOrderSerializationRecord>
{
    public RelatedRecordsInfoFieldOrderCollectionSerializationRecord()
    {
    }

    public RelatedRecordsInfoFieldOrderCollectionSerializationRecord(RelatedRecordsInfoFieldOrderSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override RelatedRecordsInfoFieldOrderSerializationRecord[]? Items { get; set; } = [];
}

[ProtoContract(Name = "SpatialReference")]
public record SpatialReferenceSerializationRecord : MapComponentSerializationRecord
{
    public SpatialReferenceSerializationRecord()
    {
    }

    public SpatialReferenceSerializationRecord(int? Wkid, string? Wkt = null)
    {
        this.Wkid = Wkid;
        this.Wkt = Wkt;
    }
    
    public override Type CollectionType => typeof(SpatialReferenceCollectionSerializationRecord);

    public SpatialReference FromSerializationRecord()
    {
        return new SpatialReference(Wkid ?? 4326);
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public int? Wkid { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Wkt { get; init; }
}

[ProtoContract(Name = "SpatialReferenceCollection")]
internal record SpatialReferenceCollectionSerializationRecord: MapComponentCollectionSerializationRecord<SpatialReferenceSerializationRecord>
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
    
    public override Type CollectionType => typeof(AttributeCollectionSerializationRecord);

    [ProtoMember(1)]
    public string Key { get; init; } = string.Empty;
    [ProtoMember(2)]
    public string? Value { get; init; }
    [ProtoMember(3)]
    public string ValueType { get; init; } = string.Empty;
}

[ProtoContract(Name = "AttributeCollection")]
public record AttributeCollectionSerializationRecord: MapComponentCollectionSerializationRecord<AttributeSerializationRecord>
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
}

[ProtoContract(Name = "GraphicOrigin")]
public record GraphicOriginSerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(GraphicOriginCollectionSerializationRecord);

    public GraphicOrigin FromSerializationRecord()
    {
        return new GraphicOrigin(LayerId is null ? null : Guid.Parse(LayerId),
            ArcGISLayerId, LayerIndex);
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
}

[ProtoContract(Name = "GraphicOriginCollection")]
internal record GraphicOriginCollectionSerializationRecord: MapComponentCollectionSerializationRecord<GraphicOriginSerializationRecord>
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
}

[ProtoContract(Name = "MapPath")]
public record MapPathSerializationRecord: MapComponentSerializationRecord
{
    public MapPathSerializationRecord()
    {
    }
    
    public MapPathSerializationRecord(MapPointSerializationRecord[] Points)
    {
        this.Points = Points;
    }
    
    public override Type CollectionType => typeof(MapPathCollectionSerializationRecord);

    public MapPath FromSerializationRecord()
    {
        return new MapPath(Points.Select(p => p.FromSerializationRecord()));
    }

    [ProtoMember(1)]
    public MapPointSerializationRecord[] Points { get; init; } = []; 
}

[ProtoContract(Name = "MapPathCollection")]
internal record MapPathCollectionSerializationRecord: MapComponentCollectionSerializationRecord<MapPathSerializationRecord>
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
}

[ProtoContract(Name = "MapPoint")]
public record MapPointSerializationRecord: MapComponentSerializationRecord
{
    public MapPointSerializationRecord()
    {
    }
    
    public MapPointSerializationRecord(double[] Coordinates)
    {
        this.Coordinates = Coordinates;
    }
    
    public override Type CollectionType => typeof(MapPointCollectionSerializationRecord);

    public MapPoint FromSerializationRecord()
    {
        return new MapPoint(Coordinates);
    }

    [ProtoMember(1)]
    public double[] Coordinates { get; init; } = [];
}

[ProtoContract(Name = "MapPointCollection")]
internal record MapPointCollectionSerializationRecord: MapComponentCollectionSerializationRecord<MapPointSerializationRecord>
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
}

[ProtoContract(Name = "MeshComponent")]
public record MeshComponentSerializationRecord: MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(MeshComponentCollectionSerializationRecord);

    [ProtoMember(1)]
    public byte[]? Faces { get; init; }
    
    [ProtoMember(2)]
    public MeshComponentMaterialSerializationRecord? Material { get; init; }
    
    [ProtoMember(3)]
    public string? Name { get; init; }
    
    [ProtoMember(4)]
    public string? Shading { get; init; }
    
    public IMeshComponent FromSerializationRecord()
    {
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
    [ProtoMember(1)]
    public sealed override MeshComponentSerializationRecord[]? Items { get; set; } = [];
}

[ProtoContract(Name = "MeshComponentMaterial")]
public record MeshComponentMaterialSerializationRecord : MapComponentSerializationRecord
{
    public MeshComponentMaterialSerializationRecord()
    {
    }

    public MeshComponentMaterialSerializationRecord(double? alphaCutoff,
        string? alphaMode,
        MapColor? color,
        MeshTextureSerializationRecord? colorTexture,
        MeshTextureTransformSerializationRecord? colorTextureTransform,
        bool? doubleSided,
        MeshTextureSerializationRecord? normalTexture,
        MeshTextureTransformSerializationRecord? normalTextureTransform,
        MapColor? emissiveColor,
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
    
    public override Type CollectionType => typeof(MeshComponentMaterialCollectionSerializationRecord);

    [ProtoMember(1)]
    public double? AlphaCutoff { get; init; }
    
    [ProtoMember(2)]
    public string? AlphaMode { get; init; }
    
    [ProtoMember(3)]
    public MapColor? Color { get; init; }
    
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
    public MapColor? EmissiveColor { get; init; }
    
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

    public IMeshComponentMaterial FromSerializationRecord()
    {
        if (EmissiveColor != null || EmissiveTexture != null
            || EmissiveTextureTransform != null || Metallic != null
            || MetallicRoughnessTexture != null || OcclusionTexture != null
            || OcclusionTextureTransform != null || Roughness != null)
        {
            return new MeshMaterialMetallicRoughness(AlphaCutoff,
                AlphaMode is null ? null : Enum.Parse<AlphaMode>(AlphaMode),
                Color,
                ColorTexture?.FromSerializationRecord(),
                ColorTextureTransform?.FromSerializationRecord(),
                DoubleSided,
                EmissiveColor,
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
            Color,
            ColorTexture?.FromSerializationRecord(),
            ColorTextureTransform?.FromSerializationRecord(),
            DoubleSided,
            NormalTexture?.FromSerializationRecord(),
            NormalTextureTransform?.FromSerializationRecord());
    }
}

[ProtoContract(Name = "MeshComponentMaterialCollection")]
internal record MeshComponentMaterialCollectionSerializationRecord : MapComponentCollectionSerializationRecord<MeshComponentMaterialSerializationRecord>
{
    public MeshComponentMaterialCollectionSerializationRecord (MeshComponentMaterialSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MeshComponentMaterialSerializationRecord[]? Items { get; set; } = [];
}

[ProtoContract(Name = "MeshTexture")]
public record MeshTextureSerializationRecord : MapComponentSerializationRecord
{
    public MeshTextureSerializationRecord()
    {
    }

    public MeshTextureSerializationRecord(ImageData? imageData,
        string?[]? wrap,
        bool? transparent,
        string? url)
    {
        ImageData = imageData;
        Wrap = wrap;
        Transparent = transparent;
        Url = url;
    }
    
    public override Type CollectionType => typeof(MeshTextureCollectionSerializationRecord);

    [ProtoMember(1)]
    public ImageData? ImageData { get; init; }
    
    [ProtoMember(2)]
    public string?[]? Wrap { get; init; }
    
    [ProtoMember(3)]
    public bool? Transparent { get; init; }
    
    [ProtoMember(4)]
    public string? Url { get; init; }
    
    public MeshTexture FromSerializationRecord()
    {
        SeparableWrapModes? wrapModes = null;
        if (Wrap != null)
        {
            if (Wrap.Length == 2)
            {
                string? first = Wrap[0];
                string? second = Wrap[1];
                wrapModes = new SeparableWrapModes(
                    first is null ? null : Enum.Parse<WrapMode>(first),
                    second is null ? null : Enum.Parse<WrapMode>(second));
            }
            else if (Wrap.Length == 1)
            {
                string? value = Wrap[0];
                WrapMode? wrapVal = value is null ? null : Enum.Parse<WrapMode>(value);
                wrapModes = new SeparableWrapModes(wrapVal, wrapVal);
            }
        }
        return new MeshTexture(null, ImageData, wrapModes, Transparent, Url);
    }
}

[ProtoContract(Name = "MeshTextureCollection")]
internal record MeshTextureCollectionSerializationRecord : MapComponentCollectionSerializationRecord<MeshTextureSerializationRecord>
{
    public MeshTextureCollectionSerializationRecord (MeshTextureSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MeshTextureSerializationRecord[]? Items { get; set; } = [];
}

[ProtoContract(Name = "MeshTextureTransform")]
public record MeshTextureTransformSerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(MeshTextureTransformCollectionSerializationRecord);
    
    [ProtoMember(1)]
    public double[]? Offset { get; init; }
    
    [ProtoMember(2)]
    public double? Rotation { get; init; }
    
    [ProtoMember(3)]
    public double[]? Scale { get; init; }
    
    public MeshTextureTransform FromSerializationRecord()
    {
        return new MeshTextureTransform(Offset, Rotation, Scale);
    }
}

[ProtoContract(Name = "MeshTextureTransformCollection")]
internal record MeshTextureTransformCollectionSerializationRecord : MapComponentCollectionSerializationRecord<MeshTextureTransformSerializationRecord>
{
    public MeshTextureTransformCollectionSerializationRecord (MeshTextureTransformSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MeshTextureTransformSerializationRecord[]? Items { get; set; } = [];
}

[ProtoContract(Name = "MeshTransform")]
public record MeshTransformSerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(MeshTransformCollectionSerializationRecord);
    
    [ProtoMember(1)]
    public double? RotationAngle { get; init; }

    [ProtoMember(2)]
    public double[]? RotationAxis { get; init; }
    
    [ProtoMember(3)]
    public double[]? Scale { get; init; }
    
    [ProtoMember(4)]
    public double[]? Translation { get; init; }

    public MeshTransform FromSerializationRecord()
    {
        return new MeshTransform(RotationAngle, RotationAxis, Scale, Translation);
    }
}

[ProtoContract(Name = "MeshTransformCollection")]
internal record MeshTransformCollectionSerializationRecord : MapComponentCollectionSerializationRecord<MeshTransformSerializationRecord>
{
    public MeshTransformCollectionSerializationRecord (MeshTransformSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MeshTransformSerializationRecord[]? Items { get; set; } = [];
}

[ProtoContract(Name = "MeshVertexAttributes")]
public record MeshVertexAttributesSerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(MeshVertexAttributesCollectionSerializationRecord);
    
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
    
    public MeshVertexAttributes FromSerializationRecord()
    {
        return new MeshVertexAttributes(Color, Normal, Position, Tangent, Uv);
    }
}

[ProtoContract(Name = "MeshVertexAttributesCollection")]
internal record MeshVertexAttributesCollectionSerializationRecord : MapComponentCollectionSerializationRecord<MeshVertexAttributesSerializationRecord>
{
    public MeshVertexAttributesCollectionSerializationRecord (MeshVertexAttributesSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MeshVertexAttributesSerializationRecord[]? Items { get; set; } = [];
}

[ProtoContract(Name = "MeshVertexSpace")]
public record MeshVertexSpaceSerializationRecord : MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(MeshVertexSpaceCollectionSerializationRecord);
    
    [ProtoMember(1)]
    public string? Type { get; set; }
    
    [ProtoMember(2)]
    public double[]? Origin { get; set; }

    public IMeshVertexSpace FromSerializationRecord()
    {
        return Type switch 
        {
            "local" => new MeshLocalVertexSpace(Origin),
            "georeferenced" => new MeshGeoreferencedVertexSpace(Origin),
            _ => throw new NotSupportedException($"MeshVertexSpace type {Type} is not supported.")
        };
    }
}

[ProtoContract(Name = "MeshVertexSpaceCollection")]
internal record MeshVertexSpaceCollectionSerializationRecord : MapComponentCollectionSerializationRecord<MeshVertexSpaceSerializationRecord>
{
    public MeshVertexSpaceCollectionSerializationRecord (MeshVertexSpaceSerializationRecord[] items)
    {
        Items = items;
    }

    [ProtoMember(1)]
    public sealed override MeshVertexSpaceSerializationRecord[]? Items { get; set; } = [];
}

[ProtoContract(Name = "ViewHitCollection")]
internal record ViewHitCollectionSerializationRecord: MapComponentCollectionSerializationRecord<ViewHitSerializationRecord>
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
}

[ProtoContract(Name = "ViewHit")]
public record ViewHitSerializationRecord: MapComponentSerializationRecord
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
    
    public override Type CollectionType => typeof(ViewHitCollectionSerializationRecord);
    
    [ProtoMember(1)]
    public string? Type { get; set; }
    
    [ProtoMember(2)]
    public GeometrySerializationRecord? MapPoint { get; set; }
    
    [ProtoMember(3)]
    public GraphicSerializationRecord? Graphic { get; set; }
    
    [ProtoMember(4)]
    public string? LayerId { get; set; }

    public ViewHit FromSerializationRecord()
    {
        if (Type == "graphic")
        {
            Guid? layerId = null;
            if (Guid.TryParse(LayerId, out Guid layerGuid))
            {
                layerId = layerGuid;
            }
            return new GraphicHit(Graphic!.FromSerializationRecord(), layerId, 
                (Point)MapPoint!.FromSerializationRecord());
        }
        return new ViewHit(Type!, (Point)MapPoint!.FromSerializationRecord());
    }
}