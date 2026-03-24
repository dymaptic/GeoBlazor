using FieldInfo = dymaptic.GeoBlazor.Core.Components.FieldInfo;


namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Base class for all Protobuf serialization records for MapComponents.
/// </summary>
[ProtoContract(Name = "MapComponent")]
public abstract record MapComponentSerializationRecord
{
    /// <summary>
    ///     Indicates whether this record represents a null value.
    /// </summary>
    [ProtoMember(1000)]
    public abstract bool IsNull { get; init; }
}

/// <summary>
///     Generic base class for Protobuf serialization records that can be converted to a specific type.
/// </summary>
/// <typeparam name="T">The type that this record can be converted to.</typeparam>
public abstract record MapComponentSerializationRecord<T> : MapComponentSerializationRecord
    where T : IProtobufSerializable
{
    /// <summary>
    ///     Converts this serialization record back to the original type.
    /// </summary>
    public abstract T? FromSerializationRecord();
}

/// <summary>
///     Base class for Protobuf serialization records representing collections.
/// </summary>
[ProtoContract(Name = "MapComponentCollection")]
public abstract record MapComponentBaseCollectionSerializationRecord
{
    /// <summary>
    ///     Indicates whether this collection record represents a null value.
    /// </summary>
    [ProtoMember(1000)]
    public abstract bool IsNull { get; init; }
}

/// <summary>
///     Generic base class for Protobuf serialization records representing collections of a specific item type.
/// </summary>
/// <typeparam name="TItem">The type of items in the collection.</typeparam>
public abstract record MapComponentCollectionSerializationRecord<TItem> : MapComponentBaseCollectionSerializationRecord
    where TItem : MapComponentSerializationRecord
{
    /// <summary>
    ///     The collection of serialization record items.
    /// </summary>
    public abstract TItem[]? Items { get; set; }
}

/// <summary>
///     Protobuf serialization record for Geometry types.
/// </summary>
[ProtoContract(Name = "Geometry")]
public record GeometrySerializationRecord : MapComponentSerializationRecord<Geometry>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public GeometrySerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new GeometrySerializationRecord with the specified values.
    /// </summary>
    public GeometrySerializationRecord(string Id, string Type, GeometrySerializationRecord? Extent,
        SpatialReferenceSerializationRecord? SpatialReference)
    {
        this.Id = Id;
        this.Type = Type;
        this.Extent = Extent;
        this.SpatialReference = SpatialReference;
    }

    /// <summary>
    ///     The geometry type (point, polyline, polygon, extent, multipoint, mesh).
    /// </summary>
    [ProtoMember(1)]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    ///     The extent of the geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public GeometrySerializationRecord? Extent { get; set; }

    /// <summary>
    ///     The spatial reference of the geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public SpatialReferenceSerializationRecord? SpatialReference { get; set; }

    /// <summary>
    ///     The longitude coordinate for point geometries.
    /// </summary>
    [ProtoMember(4)]
    public double? Longitude { get; set; }

    /// <summary>
    ///     The latitude coordinate for point geometries.
    /// </summary>
    [ProtoMember(5)]
    public double? Latitude { get; set; }

    /// <summary>
    ///     The X coordinate for point geometries.
    /// </summary>
    [ProtoMember(6)]
    public double? X { get; set; }

    /// <summary>
    ///     The Y coordinate for point geometries.
    /// </summary>
    [ProtoMember(7)]
    public double? Y { get; set; }

    /// <summary>
    ///     The Z coordinate for point geometries.
    /// </summary>
    [ProtoMember(8)]
    public double? Z { get; set; }

    /// <summary>
    ///     The paths for polyline geometries.
    /// </summary>
    [ProtoMember(9)]
    public MapPathSerializationRecord[]? Paths { get; set; }

    /// <summary>
    ///     The rings for polygon geometries.
    /// </summary>
    [ProtoMember(10)]
    public MapPathSerializationRecord[]? Rings { get; set; }

    /// <summary>
    ///     The maximum X coordinate for extent geometries.
    /// </summary>
    [ProtoMember(11)]
    public double? Xmax { get; set; }

    /// <summary>
    ///     The minimum X coordinate for extent geometries.
    /// </summary>
    [ProtoMember(12)]
    public double? Xmin { get; set; }

    /// <summary>
    ///     The maximum Y coordinate for extent geometries.
    /// </summary>
    [ProtoMember(13)]
    public double? Ymax { get; set; }

    /// <summary>
    ///     The minimum Y coordinate for extent geometries.
    /// </summary>
    [ProtoMember(14)]
    public double? Ymin { get; set; }

    /// <summary>
    ///     The maximum Z coordinate for extent geometries.
    /// </summary>
    [ProtoMember(15)]
    public double? Zmax { get; set; }

    /// <summary>
    ///     The minimum Z coordinate for extent geometries.
    /// </summary>
    [ProtoMember(16)]
    public double? Zmin { get; set; }

    /// <summary>
    ///     The maximum M value for extent geometries.
    /// </summary>
    [ProtoMember(17)]
    public double? Mmax { get; set; }

    /// <summary>
    ///     The minimum M value for extent geometries.
    /// </summary>
    [ProtoMember(18)]
    public double? Mmin { get; set; }

    /// <summary>
    ///     Indicates whether the geometry has M values.
    /// </summary>
    [ProtoMember(19)]
    public bool? HasM { get; set; }

    /// <summary>
    ///     Indicates whether the geometry has Z values.
    /// </summary>
    [ProtoMember(20)]
    public bool? HasZ { get; set; }

    /// <summary>
    ///     The M value for point geometries.
    /// </summary>
    [ProtoMember(21)]
    public double? M { get; set; }

    /// <summary>
    ///     The centroid of polygon geometries.
    /// </summary>
    [ProtoMember(22)]
    public GeometrySerializationRecord? Centroid { get; set; }

    /// <summary>
    ///     Indicates whether the polygon is self-intersecting.
    /// </summary>
    [ProtoMember(23)]
    public bool? IsSelfIntersecting { get; set; }

    /// <summary>
    ///     The center point for circle geometries.
    /// </summary>
    [ProtoMember(24)]
    public GeometrySerializationRecord? Center { get; set; }

    /// <summary>
    ///     Indicates whether the circle is geodesic.
    /// </summary>
    [ProtoMember(25)]
    public bool? Geodesic { get; set; }

    /// <summary>
    ///     The number of points in the circle.
    /// </summary>
    [ProtoMember(26)]
    public int? NumberOfPoints { get; set; }

    /// <summary>
    ///     The radius of the circle.
    /// </summary>
    [ProtoMember(27)]
    public double? Radius { get; set; }

    /// <summary>
    ///     The unit of the radius.
    /// </summary>
    [ProtoMember(28)]
    public string? RadiusUnit { get; set; }

    /// <summary>
    ///     The unique identifier for the geometry.
    /// </summary>
    [ProtoMember(29)]
    public string? Id { get; set; }

    /// <summary>
    ///     Multipoint geometry points.
    /// </summary>
    [ProtoMember(30)]
    public MapPointSerializationRecord[]? Points { get; set; }

    /// <summary>
    ///     Indicates whether the geometry is simple.
    /// </summary>
    [ProtoMember(31)]
    public bool? IsSimple { get; set; }

    /// <summary>
    ///     The mesh components for mesh geometries.
    /// </summary>
    [ProtoMember(32)]
    public MeshComponentSerializationRecord[]? Components { get; set; }

    /// <summary>
    ///     The transform for mesh geometries.
    /// </summary>
    [ProtoMember(33)]
    public MeshTransformSerializationRecord? Transform { get; set; }

    /// <summary>
    ///     The vertex attributes for mesh geometries.
    /// </summary>
    [ProtoMember(34)]
    public MeshVertexAttributesSerializationRecord? VertexAttributes { get; set; }

    /// <summary>
    ///     The vertex space for mesh geometries.
    /// </summary>
    [ProtoMember(35)]
    public MeshVertexSpaceSerializationRecord? VertexSpace { get; set; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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
                        RadiusUnit is null ? null : Enum.Parse<RadiusUnit>(RadiusUnit, true), rings,
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

/// <summary>
///     Protobuf serialization record for PopupContent types.
/// </summary>
[ProtoContract(Name = "PopupContent")]
public record PopupContentSerializationRecord : MapComponentSerializationRecord<PopupContent>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public PopupContentSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new PopupContentSerializationRecord with the specified values.
    /// </summary>
    public PopupContentSerializationRecord(string Id, string Type)
    {
        this.Type = Type;
        this.Id = Id;
    }

    /// <summary>
    ///     The popup content type.
    /// </summary>
    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;

    /// <summary>
    ///     The description of the popup content.
    /// </summary>
    [ProtoMember(2)]
    public string? Description { get; init; }

    /// <summary>
    ///     The display type of the popup content.
    /// </summary>
    [ProtoMember(3)]
    public string? DisplayType { get; init; }

    /// <summary>
    ///     The title of the popup content.
    /// </summary>
    [ProtoMember(4)]
    public string? Title { get; init; }

    /// <summary>
    ///     The expression info for expression popup content.
    /// </summary>
    [ProtoMember(5)]
    public ElementExpressionInfoSerializationRecord? ExpressionInfo { get; init; }

    /// <summary>
    ///     The field info array for fields popup content.
    /// </summary>
    [ProtoMember(6)]
    public FieldInfoSerializationRecord[]? FieldInfos { get; init; }

    /// <summary>
    ///     The active media info index for media popup content.
    /// </summary>
    [ProtoMember(7)]
    public int? ActiveMediaInfoIndex { get; init; }

    /// <summary>
    ///     The media info array for media popup content.
    /// </summary>
    [ProtoMember(8)]
    public MediaInfoSerializationRecord[]? MediaInfos { get; init; }

    /// <summary>
    ///     The display count for relationship popup content.
    /// </summary>
    [ProtoMember(9)]
    public int? DisplayCount { get; init; }

    /// <summary>
    ///     The order by fields for relationship popup content.
    /// </summary>
    [ProtoMember(10)]
    public RelatedRecordsInfoFieldOrderSerializationRecord[]? OrderByFields { get; init; }

    /// <summary>
    ///     The relationship ID for relationship popup content.
    /// </summary>
    [ProtoMember(11)]
    public long? RelationshipId { get; init; }

    /// <summary>
    ///     The text for text popup content.
    /// </summary>
    [ProtoMember(12)]
    public string? Text { get; init; }

    /// <summary>
    ///     The unique identifier for the popup content.
    /// </summary>
    [ProtoMember(13)]
    public string? Id { get; set; }

    /// <summary>
    ///     The out fields for custom popup content.
    /// </summary>
    [ProtoMember(14)]
    public string[]? OutFields { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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
                DisplayType is null ? null : Enum.Parse<AttachmentsPopupContentDisplayType>(DisplayType, true)) { Id = id },
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

/// <summary>
///     Protobuf serialization record for PopupExpressionInfo.
/// </summary>
[ProtoContract(Name = "PopupExpressionInfo")]
public record PopupExpressionInfoSerializationRecord : MapComponentSerializationRecord<PopupExpressionInfo>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public PopupExpressionInfoSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new PopupExpressionInfoSerializationRecord with the specified values.
    /// </summary>
    public PopupExpressionInfoSerializationRecord(string Id, string? Expression, string? Name, string? Title,
        PopupExpressionInfoReturnType? ReturnType)
    {
        this.Id = Id;
        this.Expression = Expression;
        this.Name = Name;
        this.Title = Title;
        this.ReturnType = ReturnType.ToString();
    }

    /// <summary>
    ///     The Arcade expression string.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? Expression { get; init; }

    /// <summary>
    ///     The name of the expression.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Name { get; init; }

    /// <summary>
    ///     The title of the expression.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? Title { get; init; }

    /// <summary>
    ///     The return type of the expression.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public string? ReturnType { get; init; }

    /// <summary>
    ///     The unique identifier.
    /// </summary>
    [ProtoMember(5)]
    public string? Id { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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
            ReturnType is null ? null : Enum.Parse<PopupExpressionInfoReturnType>(ReturnType, true),
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

/// <summary>
///     Protobuf serialization record for PopupTemplate.
/// </summary>
[ProtoContract(Name = "PopupTemplate")]
public record PopupTemplateSerializationRecord : MapComponentSerializationRecord<PopupTemplate>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public PopupTemplateSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new PopupTemplateSerializationRecord with the specified values.
    /// </summary>
    public PopupTemplateSerializationRecord(string? Title,
        string? StringContent = null,
        IEnumerable<string>? OutFields = null,
        IEnumerable<FieldInfoSerializationRecord>? FieldInfos = null,
        IEnumerable<PopupContentSerializationRecord>? Content = null,
        IEnumerable<PopupExpressionInfoSerializationRecord>? ExpressionInfos = null,
        bool? OverwriteActions = null,
        bool? ReturnGeometry = null,
        IEnumerable<ActionBaseSerializationRecord>? Actions = null,
        string? Id = null,
        bool? HasTitleFunction = null,
        bool? HasContentFunction = null)
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
        this.HasTitleFunction = HasTitleFunction;
        this.HasContentFunction = HasContentFunction;
    }

    /// <summary>
    ///     The title of the popup template.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? Title { get; init; }

    /// <summary>
    ///     The string content of the popup template.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? StringContent { get; init; }

    /// <summary>
    ///     The output fields for the popup template.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public IEnumerable<string>? OutFields { get; init; }

    /// <summary>
    ///     The field info records for the popup template.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public IEnumerable<FieldInfoSerializationRecord>? FieldInfos { get; init; }

    /// <summary>
    ///     The content records for the popup template.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public IEnumerable<PopupContentSerializationRecord>? Content { get; init; }

    /// <summary>
    ///     The expression info records for the popup template.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public IEnumerable<PopupExpressionInfoSerializationRecord>? ExpressionInfos { get; init; }

    /// <summary>
    ///     Indicates whether to overwrite actions.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(7)]
    public bool? OverwriteActions { get; init; }

    /// <summary>
    ///     Indicates whether to return geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(8)]
    public bool? ReturnGeometry { get; init; }

    /// <summary>
    ///     The action records for the popup template.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(9)]
    public IEnumerable<ActionBaseSerializationRecord>? Actions { get; init; }

    /// <summary>
    ///     The unique identifier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(10)]
    public string? Id { get; init; }

    /// <summary>
    ///     Whether or not there is a function to generate the title
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(11)]
    public bool? HasTitleFunction { get; init; }

    /// <summary>
    ///     Whether or not there is a function to generate the content
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(12)]
    public bool? HasContentFunction { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for Symbol types.
/// </summary>
[ProtoContract(Name = "Symbol")]
public record SymbolSerializationRecord : MapComponentSerializationRecord<Symbol>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public SymbolSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new SymbolSerializationRecord with the specified values.
    /// </summary>
    public SymbolSerializationRecord(string Id,
        string Type,
        MapColorSerializationRecord? Color)
    {
        this.Id = Id;
        this.Type = Type;
        this.Color = Color;
    }

    /// <summary>
    ///     The symbol type.
    /// </summary>
    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;

    /// <summary>
    ///     The color of the symbol.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public MapColorSerializationRecord? Color { get; init; }

    /// <summary>
    ///     The outline of the symbol.
    /// </summary>
    [ProtoMember(3)]
    public SymbolSerializationRecord? Outline { get; init; }

    /// <summary>
    ///     The size of the symbol.
    /// </summary>
    [ProtoMember(4)]
    public double? Size { get; init; }

    /// <summary>
    ///     The style of the symbol.
    /// </summary>
    [ProtoMember(5)]
    public string? Style { get; init; }

    /// <summary>
    ///     The angle of the symbol.
    /// </summary>
    [ProtoMember(6)]
    public double? Angle { get; init; }

    /// <summary>
    ///     The X offset of the symbol.
    /// </summary>
    [ProtoMember(7)]
    public double? Xoffset { get; init; }

    /// <summary>
    ///     The Y offset of the symbol.
    /// </summary>
    [ProtoMember(8)]
    public double? Yoffset { get; init; }

    /// <summary>
    ///     The width of the symbol.
    /// </summary>
    [ProtoMember(9)]
    public double? Width { get; init; }

    /// <summary>
    ///     The line style of the symbol.
    /// </summary>
    [ProtoMember(10)]
    public string? LineStyle { get; init; }

    /// <summary>
    ///     The text content of a text symbol.
    /// </summary>
    [ProtoMember(11)]
    public string? Text { get; init; }

    /// <summary>
    ///     The halo color of a text symbol.
    /// </summary>
    [ProtoMember(12)]
    public MapColorSerializationRecord? HaloColor { get; init; }

    /// <summary>
    ///     The halo size of a text symbol.
    /// </summary>
    [ProtoMember(13)]
    public double? HaloSize { get; init; }

    /// <summary>
    ///     The font of a text symbol.
    /// </summary>
    [ProtoMember(14)]
    public MapFontSerializationRecord? Font { get; init; }

    /// <summary>
    ///     The height of the symbol.
    /// </summary>
    [ProtoMember(15)]
    public double? Height { get; init; }

    /// <summary>
    ///     The URL of a picture symbol.
    /// </summary>
    [ProtoMember(16)]
    public string? Url { get; init; }

    /// <summary>
    ///     The background color of a text symbol.
    /// </summary>
    [ProtoMember(17)]
    public MapColorSerializationRecord? BackgroundColor { get; init; }

    /// <summary>
    ///     The border line size of a text symbol.
    /// </summary>
    [ProtoMember(18)]
    public double? BorderLineSize { get; init; }

    /// <summary>
    ///     The border line color of a text symbol.
    /// </summary>
    [ProtoMember(19)]
    public MapColorSerializationRecord? BorderLineColor { get; init; }

    /// <summary>
    ///     The horizontal alignment of a text symbol.
    /// </summary>
    [ProtoMember(20)]
    public string? HorizontalAlignment { get; init; }

    /// <summary>
    ///     Indicates whether kerning is enabled for a text symbol.
    /// </summary>
    [ProtoMember(21)]
    public bool? Kerning { get; init; }

    /// <summary>
    ///     The line height of a text symbol.
    /// </summary>
    [ProtoMember(22)]
    public double? LineHeight { get; init; }

    /// <summary>
    ///     The line width of a text symbol.
    /// </summary>
    [ProtoMember(23)]
    public double? LineWidth { get; init; }

    /// <summary>
    ///     Indicates whether the symbol is rotated.
    /// </summary>
    [ProtoMember(24)]
    public bool? Rotated { get; init; }

    /// <summary>
    ///     The vertical alignment of a text symbol.
    /// </summary>
    [ProtoMember(25)]
    public string? VerticalAlignment { get; init; }

    /// <summary>
    ///     The X scale of a picture fill symbol.
    /// </summary>
    [ProtoMember(26)]
    public double? Xscale { get; init; }

    /// <summary>
    ///     The Y scale of a picture fill symbol.
    /// </summary>
    [ProtoMember(27)]
    public double? Yscale { get; init; }

    /// <summary>
    ///     The unique identifier.
    /// </summary>
    [ProtoMember(28)]
    public string? Id { get; init; }

    /// <summary>
    ///     The name of a web style symbol.
    /// </summary>
    [ProtoMember(29)]
    public string? Name { get; init; }

    /// <summary>
    ///     The portal URL of a web style symbol.
    /// </summary>
    [ProtoMember(30)]
    public string? PortalUrl { get; init; }

    /// <summary>
    ///     The style name of a web style symbol.
    /// </summary>
    [ProtoMember(31)]
    public string? StyleName { get; init; }

    /// <summary>
    ///     The style URL of a web style symbol.
    /// </summary>
    [ProtoMember(32)]
    public string? StyleUrl { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
    public override Symbol? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return FromSerializationRecord();
    }

    /// <summary>
    ///     Converts this serialization record back to a Symbol, with an optional flag for outline context.
    /// </summary>
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
            "picture-fill" => new PictureFillSymbol(url: Url!, width: Width, height: Height,
                xoffset: Xoffset, yoffset: Yoffset,
                outline: Outline?.FromSerializationRecord(true) as Outline) { Id = id },
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

/// <summary>
///     Protobuf serialization record for MapColor.
/// </summary>
[ProtoContract(Name = "MapColor")]
public record MapColorSerializationRecord : MapComponentSerializationRecord<MapColor>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public MapColorSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new MapColorSerializationRecord with the specified values.
    /// </summary>
    public MapColorSerializationRecord(double[]? rgbaValues, string? hexOrNameValue)
    {
        RgbaValues = rgbaValues;
        HexOrNameValue = hexOrNameValue;
    }

    /// <summary>
    ///     The RGBA values of the color.
    /// </summary>
    [ProtoMember(1)]
    public double[]? RgbaValues { get; init; }

    /// <summary>
    ///     The hex or named color value.
    /// </summary>
    [ProtoMember(2)]
    public string? HexOrNameValue { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for a collection of MapColor.
/// </summary>
[ProtoContract(Name = "MapColorCollection")]
public record MapColorCollectionSerializationRecord
    : MapComponentCollectionSerializationRecord<MapColorSerializationRecord>
{
    /// <summary>
    ///     Creates a new MapColorCollectionSerializationRecord with the specified items.
    /// </summary>
    public MapColorCollectionSerializationRecord(MapColorSerializationRecord[] items)
    {
        Items = items;
    }

    /// <summary>
    ///     The collection of MapColor serialization records.
    /// </summary>
    public sealed override MapColorSerializationRecord[]? Items { get; set; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

/// <summary>
///     Protobuf serialization record for ActionBase types.
/// </summary>
[ProtoContract(Name = "ActionBase")]
public record ActionBaseSerializationRecord : MapComponentSerializationRecord<ActionBase>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public ActionBaseSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new ActionBaseSerializationRecord with the specified values.
    /// </summary>
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

    /// <summary>
    ///     The action type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;

    /// <summary>
    ///     The title of the action.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Title { get; init; }

    /// <summary>
    ///     The CSS class name for the action icon.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? ClassName { get; init; }

    /// <summary>
    ///     Indicates whether the action is active.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public bool? Active { get; init; }

    /// <summary>
    ///     Indicates whether the action is disabled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public bool? Disabled { get; init; }

    /// <summary>
    ///     Indicates whether the action is visible.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public bool? Visible { get; init; }

    /// <summary>
    ///     The unique identifier.
    /// </summary>
    [ProtoMember(7)]
    public string? Id { get; init; }

    /// <summary>
    ///     The image URL for the action.
    /// </summary>
    [ProtoMember(8)]
    public string? Image { get; init; }

    /// <summary>
    ///     The toggle value for toggle actions.
    /// </summary>
    [ProtoMember(9)]
    public bool? Value { get; init; }

    /// <summary>
    ///     The action identifier.
    /// </summary>
    [ProtoMember(10)]
    public string? ActionId { get; init; }

    /// <summary>
    ///     The test value.
    /// </summary>
    [ProtoMember(11)]
    public string? Test { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for MediaInfoValue types.
/// </summary>
[ProtoContract(Name = "MediaInfoValue")]
public record MediaInfoValueSerializationRecord : MapComponentSerializationRecord<IMediaInfoValue>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public MediaInfoValueSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new MediaInfoValueSerializationRecord with the specified values.
    /// </summary>
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

    /// <summary>
    ///     The fields used for chart values.
    /// </summary>
    [ProtoMember(1)]
    public IEnumerable<string>? Fields { get; init; }

    /// <summary>
    ///     The field used to normalize chart values.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? NormalizeField { get; init; }

    /// <summary>
    ///     The field used for tooltip display.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? TooltipField { get; init; }

    /// <summary>
    ///     The series data for chart media info.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public IEnumerable<ChartMediaInfoValueSeriesSerializationRecord>? Series { get; init; }

    /// <summary>
    ///     The link URL for image media info.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public string? LinkURL { get; init; }

    /// <summary>
    ///     The source URL for image media info.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public string? SourceURL { get; init; }

    /// <summary>
    ///     The unique identifier.
    /// </summary>
    [ProtoMember(7)]
    public string? Id { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for ChartMediaInfoValueSeries.
/// </summary>
[ProtoContract(Name = "ChartMediaInfoValueSeries")]
public record ChartMediaInfoValueSeriesSerializationRecord : MapComponentSerializationRecord<ChartMediaInfoValueSeries>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public ChartMediaInfoValueSeriesSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new ChartMediaInfoValueSeriesSerializationRecord with the specified values.
    /// </summary>
    public ChartMediaInfoValueSeriesSerializationRecord(string Id, string? FieldName, string? Tooltip, double? Value)
    {
        this.Id = Id;
        this.FieldName = FieldName;
        this.Tooltip = Tooltip;
        this.Value = Value;
    }

    /// <summary>
    ///     The field name for the series data.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? FieldName { get; init; }

    /// <summary>
    ///     The tooltip text for the series.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Tooltip { get; init; }

    /// <summary>
    ///     The numeric value for the series.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public double? Value { get; init; }

    /// <summary>
    ///     The unique identifier.
    /// </summary>
    [ProtoMember(4)]
    public string? Id { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for ElementExpressionInfo.
/// </summary>
[ProtoContract(Name = "ElementExpressionInfo")]
public record ElementExpressionInfoSerializationRecord : MapComponentSerializationRecord<ElementExpressionInfo>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public ElementExpressionInfoSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new ElementExpressionInfoSerializationRecord with the specified values.
    /// </summary>
    public ElementExpressionInfoSerializationRecord(string? expression, string? title)
    {
        Expression = expression;
        Title = title;
    }

    /// <summary>
    ///     The Arcade expression string.
    /// </summary>
    [ProtoMember(1)]
    public string? Expression { get; init; }

    /// <summary>
    ///     The title of the expression.
    /// </summary>
    [ProtoMember(2)]
    public string? Title { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for FieldInfo.
/// </summary>
[ProtoContract(Name = "FieldInfo")]
public record FieldInfoSerializationRecord : MapComponentSerializationRecord<FieldInfo>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public FieldInfoSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new FieldInfoSerializationRecord with the specified values.
    /// </summary>
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

    /// <summary>
    ///     The name of the field.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? FieldName { get; init; }

    /// <summary>
    ///     The label for the field.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Label { get; init; }

    /// <summary>
    ///     The tooltip text for the field.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? Tooltip { get; init; }

    /// <summary>
    ///     The string field option type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public string? StringFieldOption { get; init; }

    /// <summary>
    ///     The format for displaying the field value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public FieldInfoFormatSerializationRecord? Format { get; init; }

    /// <summary>
    ///     Indicates whether the field is editable.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public bool? IsEditable { get; init; }

    /// <summary>
    ///     Indicates whether the field is visible.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(7)]
    public bool? Visible { get; init; }

    /// <summary>
    ///     The unique identifier.
    /// </summary>
    [ProtoMember(8)]
    public string? Id { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for FieldInfoFormat.
/// </summary>
[ProtoContract(Name = "FieldInfoFormat")]
public record FieldInfoFormatSerializationRecord : MapComponentSerializationRecord<FieldInfoFormat>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public FieldInfoFormatSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new FieldInfoFormatSerializationRecord with the specified values.
    /// </summary>
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

    /// <summary>
    ///     The number of decimal places for numeric values.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public int? Places { get; init; }

    /// <summary>
    ///     Indicates whether to use a digit separator for numeric values.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public bool? DigitSeparator { get; init; }

    /// <summary>
    ///     The date format string.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? DateFormat { get; init; }

    /// <summary>
    ///     The unique identifier.
    /// </summary>
    [ProtoMember(4)]
    public string? Id { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for Graphic.
/// </summary>
[ProtoContract(Name = "Graphic")]
public record GraphicSerializationRecord : MapComponentSerializationRecord<Graphic>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public GraphicSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new GraphicSerializationRecord with the specified values.
    /// </summary>
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

    /// <summary>
    ///     The unique identifier.
    /// </summary>
    [ProtoMember(1)]
    public string? Id { get; set; } = string.Empty;

    /// <summary>
    ///     The geometry of the graphic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public GeometrySerializationRecord? Geometry { get; set; }

    /// <summary>
    ///     The symbol used to render the graphic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public SymbolSerializationRecord? Symbol { get; set; }

    /// <summary>
    ///     The popup template for the graphic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public PopupTemplateSerializationRecord? PopupTemplate { get; set; }

    /// <summary>
    ///     The attributes of the graphic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public AttributeSerializationRecord[]? Attributes { get; set; }

    /// <summary>
    ///     Indicates whether the graphic is visible.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public bool? Visible { get; set; }

    /// <summary>
    ///     The aggregate geometries setting.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(7)]
    public string? AggregateGeometries { get; set; }

    /// <summary>
    ///     The origin information for the graphic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(8)]
    public GraphicOriginSerializationRecord? Origin { get; set; }

    /// <summary>
    ///     The layer ID associated with the graphic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(9)]
    public string? LayerId { get; set; }

    /// <summary>
    ///     The view ID associated with the graphic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(10)]
    public string? ViewId { get; set; }

    /// <summary>
    ///     The stacked attributes for clustered graphics.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(11)]
    public AttributeSerializationRecord[]? StackedAttributes { get; set; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for MapFont.
/// </summary>
[ProtoContract(Name = "MapFont")]
public record MapFontSerializationRecord : MapComponentSerializationRecord<MapFont>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public MapFontSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new MapFontSerializationRecord with the specified values.
    /// </summary>
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

    /// <summary>
    ///     The font size in points.
    /// </summary>
    [ProtoMember(1)]
    public double? Size { get; init; }

    /// <summary>
    ///     The font family name.
    /// </summary>
    [ProtoMember(2)]
    public string? Family { get; init; }

    /// <summary>
    ///     The font style (normal, italic, oblique).
    /// </summary>
    [ProtoMember(3)]
    public string? FontStyle { get; init; }

    /// <summary>
    ///     The font weight (normal, bold, bolder, lighter).
    /// </summary>
    [ProtoMember(4)]
    public string? Weight { get; init; }

    /// <summary>
    ///     The text decoration (underline, line-through, none).
    /// </summary>
    [ProtoMember(5)]
    public string? Decoration { get; init; }

    /// <summary>
    ///     The unique identifier.
    /// </summary>
    [ProtoMember(6)]
    public string? Id { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

        return new MapFont(Size, Family, FontStyle is null ? null : Enum.Parse<MapFontStyle>(FontStyle, true),
            Weight is null ? null : Enum.Parse<FontWeight>(Weight, true),
            Decoration is null ? null : Enum.Parse<TextDecoration>(Decoration, true)) { Id = id };
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

/// <summary>
///     Protobuf serialization record for MediaInfo.
/// </summary>
[ProtoContract(Name = "MediaInfo")]
public record MediaInfoSerializationRecord : MapComponentSerializationRecord<MediaInfo>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public MediaInfoSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new MediaInfoSerializationRecord with the specified values.
    /// </summary>
    public MediaInfoSerializationRecord(string Id, string Type)
    {
        this.Id = Id;
        this.Type = Type;
    }

    /// <summary>
    ///     The media info type.
    /// </summary>
    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;

    /// <summary>
    ///     The alternative text for accessibility.
    /// </summary>
    [ProtoMember(2)]
    public string? AltText { get; init; }

    /// <summary>
    ///     The caption for the media.
    /// </summary>
    [ProtoMember(3)]
    public string? Caption { get; init; }

    /// <summary>
    ///     The title of the media.
    /// </summary>
    [ProtoMember(4)]
    public string? Title { get; init; }

    /// <summary>
    ///     The value containing media-specific data.
    /// </summary>
    [ProtoMember(5)]
    public MediaInfoValueSerializationRecord? Value { get; init; }

    /// <summary>
    ///     The refresh interval in minutes for image media.
    /// </summary>
    [ProtoMember(6)]
    public double? RefreshInterval { get; init; }

    /// <summary>
    ///     The unique identifier.
    /// </summary>
    [ProtoMember(7)]
    public string? Id { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for RelatedRecordsInfoFieldOrder.
/// </summary>
/// <param name="Field">
///     The field name to order by.
/// </param>
/// <param name="Order">
///     The order direction (asc or desc).
/// </param>
/// <param name="Id">
///     The unique identifier.
/// </param>
[ProtoContract(Name = "RelatedRecordsInfoFieldOrder")]
public record RelatedRecordsInfoFieldOrderSerializationRecord(
    [property: ProtoMember(1)] string? Field,
    [property: ProtoMember(2)] string? Order,
    [property: ProtoMember(3)] string Id) : MapComponentSerializationRecord<RelatedRecordsInfoFieldOrder>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public RelatedRecordsInfoFieldOrderSerializationRecord() : this(null, null, Guid.NewGuid().ToString())
    {
    }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for SpatialReference.
/// </summary>
[ProtoContract(Name = "SpatialReference")]
public record SpatialReferenceSerializationRecord : MapComponentSerializationRecord<SpatialReference>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public SpatialReferenceSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new SpatialReferenceSerializationRecord with the specified values.
    /// </summary>
    public SpatialReferenceSerializationRecord(int? Wkid, string? Wkt = null, string? Wkt2 = null)
    {
        this.Wkid = Wkid;
        this.Wkt = Wkt;
        this.Wkt2 = Wkt2;
    }

    /// <summary>
    ///     The well-known ID of the spatial reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public int? Wkid { get; init; }

    /// <summary>
    ///     The well-known text (WKT) of the spatial reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Wkt { get; init; }

    /// <summary>
    ///     The well-known text 2 (WKT2) of the spatial reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? Wkt2 { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for an attribute key-value pair.
/// </summary>
[ProtoContract(Name = "Attribute")]
public record AttributeSerializationRecord : MapComponentSerializationRecord
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public AttributeSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new AttributeSerializationRecord with the specified values.
    /// </summary>
    public AttributeSerializationRecord(string Key,
        string? Value,
        string ValueType)
    {
        this.Key = Key;
        this.Value = Value;
        this.ValueType = ValueType;
    }

    /// <summary>
    ///     The attribute key name.
    /// </summary>
    [ProtoMember(1)]
    public string Key { get; init; } = string.Empty;

    /// <summary>
    ///     The serialized attribute value.
    /// </summary>
    [ProtoMember(2)]
    public string? Value { get; init; }

    /// <summary>
    ///     The type name of the attribute value.
    /// </summary>
    [ProtoMember(3)]
    public string ValueType { get; init; } = string.Empty;

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <summary>
    ///     Converts this serialization record back to a key-value tuple.
    /// </summary>
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

/// <summary>
///     Protobuf serialization record for a collection of attributes.
/// </summary>
[ProtoContract(Name = "AttributeCollection")]
public record
    AttributeCollectionSerializationRecord : MapComponentCollectionSerializationRecord<AttributeSerializationRecord>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public AttributeCollectionSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new AttributeCollectionSerializationRecord with the specified items.
    /// </summary>
    public AttributeCollectionSerializationRecord(AttributeSerializationRecord[] items)
    {
        Items = items;
    }

    /// <summary>
    ///     The collection of attribute serialization records.
    /// </summary>
    [ProtoMember(1)]
    public sealed override AttributeSerializationRecord[]? Items { get; set; } = [];

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

/// <summary>
///     Protobuf serialization record for GraphicOrigin.
/// </summary>
[ProtoContract(Name = "GraphicOrigin")]
public record GraphicOriginSerializationRecord : MapComponentSerializationRecord<GraphicOrigin>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public GraphicOriginSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new GraphicOriginSerializationRecord with the specified values.
    /// </summary>
    public GraphicOriginSerializationRecord(string? LayerId, string? ArcGISLayerId, int? LayerIndex)
    {
        this.LayerId = LayerId;
        this.ArcGISLayerId = ArcGISLayerId;
        this.LayerIndex = LayerIndex;
    }

    /// <summary>
    ///     The GeoBlazor layer ID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? LayerId { get; init; }

    /// <summary>
    ///     The ArcGIS layer ID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? ArcGISLayerId { get; init; }

    /// <summary>
    ///     The layer index within the map.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public int? LayerIndex { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for MapPath.
/// </summary>
[ProtoContract(Name = "MapPath")]
public record MapPathSerializationRecord : MapComponentSerializationRecord<MapPath>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public MapPathSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new MapPathSerializationRecord with the specified points.
    /// </summary>
    public MapPathSerializationRecord(MapPointSerializationRecord[] Points)
    {
        this.Points = Points;
    }

    /// <summary>
    ///     The points that make up the path.
    /// </summary>
    [ProtoMember(1)]
    public MapPointSerializationRecord[] Points { get; init; } = [];

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for MapPoint.
/// </summary>
[ProtoContract(Name = "MapPoint")]
public record MapPointSerializationRecord : MapComponentSerializationRecord<MapPoint>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public MapPointSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new MapPointSerializationRecord with the specified coordinates.
    /// </summary>
    public MapPointSerializationRecord(double[] Coordinates)
    {
        this.Coordinates = Coordinates;
    }

    /// <summary>
    ///     The coordinate values array.
    /// </summary>
    [ProtoMember(1)]
    public double[] Coordinates { get; init; } = [];

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for MeshComponent.
/// </summary>
[ProtoContract(Name = "MeshComponent")]
public record MeshComponentSerializationRecord : MapComponentSerializationRecord<MeshComponent>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public MeshComponentSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new MeshComponentSerializationRecord with the specified values.
    /// </summary>
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

    /// <summary>
    ///     The face indices for the mesh component.
    /// </summary>
    [ProtoMember(1)]
    public byte[]? Faces { get; init; }

    /// <summary>
    ///     The material for the mesh component.
    /// </summary>
    [ProtoMember(2)]
    public MeshComponentMaterialSerializationRecord? Material { get; init; }

    /// <summary>
    ///     The name of the mesh component.
    /// </summary>
    [ProtoMember(3)]
    public string? Name { get; init; }

    /// <summary>
    ///     The shading mode for the mesh component.
    /// </summary>
    [ProtoMember(4)]
    public string? Shading { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
    public override MeshComponent? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return new MeshComponent(Faces,
            Material?.FromSerializationRecord(),
            Name,
            Shading is null ? null : Enum.Parse<MeshShading>(Shading, true));
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

/// <summary>
///     Protobuf serialization record for MeshComponentMaterial.
/// </summary>
[ProtoContract(Name = "MeshComponentMaterial")]
public record MeshComponentMaterialSerializationRecord : MapComponentSerializationRecord<IMeshComponentMaterial>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public MeshComponentMaterialSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new MeshComponentMaterialSerializationRecord with the specified values.
    /// </summary>
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

    /// <summary>
    ///     The alpha cutoff threshold.
    /// </summary>
    [ProtoMember(1)]
    public double? AlphaCutoff { get; init; }

    /// <summary>
    ///     The alpha blending mode.
    /// </summary>
    [ProtoMember(2)]
    public string? AlphaMode { get; init; }

    /// <summary>
    ///     The base color of the material.
    /// </summary>
    [ProtoMember(3)]
    public MapColorSerializationRecord? Color { get; init; }

    /// <summary>
    ///     The color texture.
    /// </summary>
    [ProtoMember(4)]
    public MeshTextureSerializationRecord? ColorTexture { get; init; }

    /// <summary>
    ///     The transform for the color texture.
    /// </summary>
    [ProtoMember(5)]
    public MeshTextureTransformSerializationRecord? ColorTextureTransform { get; init; }

    /// <summary>
    ///     Indicates whether the material is double-sided.
    /// </summary>
    [ProtoMember(6)]
    public bool? DoubleSided { get; init; }

    /// <summary>
    ///     The normal map texture.
    /// </summary>
    [ProtoMember(7)]
    public MeshTextureSerializationRecord? NormalTexture { get; init; }

    /// <summary>
    ///     The transform for the normal texture.
    /// </summary>
    [ProtoMember(8)]
    public MeshTextureTransformSerializationRecord? NormalTextureTransform { get; init; }

    /// <summary>
    ///     The emissive color.
    /// </summary>
    [ProtoMember(9)]
    public MapColorSerializationRecord? EmissiveColor { get; init; }

    /// <summary>
    ///     The emissive texture.
    /// </summary>
    [ProtoMember(10)]
    public MeshTextureSerializationRecord? EmissiveTexture { get; init; }

    /// <summary>
    ///     The transform for the emissive texture.
    /// </summary>
    [ProtoMember(11)]
    public MeshTextureTransformSerializationRecord? EmissiveTextureTransform { get; init; }

    /// <summary>
    ///     The metallic factor.
    /// </summary>
    [ProtoMember(12)]
    public double? Metallic { get; init; }

    /// <summary>
    ///     The metallic-roughness texture.
    /// </summary>
    [ProtoMember(13)]
    public MeshTextureSerializationRecord? MetallicRoughnessTexture { get; init; }

    /// <summary>
    ///     The ambient occlusion texture.
    /// </summary>
    [ProtoMember(14)]
    public MeshTextureSerializationRecord? OcclusionTexture { get; init; }

    /// <summary>
    ///     The transform for the occlusion texture.
    /// </summary>
    [ProtoMember(15)]
    public MeshTextureTransformSerializationRecord? OcclusionTextureTransform { get; init; }

    /// <summary>
    ///     The roughness factor.
    /// </summary>
    [ProtoMember(16)]
    public double? Roughness { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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
                AlphaMode is null ? null : Enum.Parse<AlphaMode>(AlphaMode, true),
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
            AlphaMode is null ? null : Enum.Parse<AlphaMode>(AlphaMode, true),
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

/// <summary>
///     Protobuf serialization record for MeshTexture.
/// </summary>
[ProtoContract(Name = "MeshTexture")]
public record MeshTextureSerializationRecord : MapComponentSerializationRecord<MeshTexture>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public MeshTextureSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new MeshTextureSerializationRecord with the specified values.
    /// </summary>
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

    /// <summary>
    ///     The image data for the texture.
    /// </summary>
    [ProtoMember(1)]
    public ImageDataSerializationRecord? ImageData { get; init; }

    /// <summary>
    ///     The wrap modes for the texture.
    /// </summary>
    [ProtoMember(2)]
    public string?[]? Wrap { get; init; }

    /// <summary>
    ///     Indicates whether the texture has transparency.
    /// </summary>
    [ProtoMember(3)]
    public bool? Transparent { get; init; }

    /// <summary>
    ///     The URL of the texture image.
    /// </summary>
    [ProtoMember(4)]
    public string? Url { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

                wrapModes = new SeparableWrapModes(first is null ? null : Enum.Parse<WrapMode>(first, true),
                    second is null ? null : Enum.Parse<WrapMode>(second, true));
            }
            else if (Wrap.Length == 1)
            {
                var value = Wrap[0];
                WrapMode? wrapVal = value is null ? null : Enum.Parse<WrapMode>(value, true);
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

/// <summary>
///     Protobuf serialization record for ImageData.
/// </summary>
[ProtoContract(Name = "ImageData")]
public record ImageDataSerializationRecord : MapComponentSerializationRecord<ImageData>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public ImageDataSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new ImageDataSerializationRecord with the specified values.
    /// </summary>
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

    /// <summary>
    ///     The raw image data bytes.
    /// </summary>
    [ProtoMember(1)]
    public byte[]? Data { get; init; }

    /// <summary>
    ///     The color space of the image.
    /// </summary>
    [ProtoMember(2)]
    public string? ColorSpace { get; init; }

    /// <summary>
    ///     The height of the image in pixels.
    /// </summary>
    [ProtoMember(3)]
    public long Height { get; init; }

    /// <summary>
    ///     The width of the image in pixels.
    /// </summary>
    [ProtoMember(4)]
    public long Width { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
    public override ImageData? FromSerializationRecord()
    {
        if (IsNull)
        {
            return null;
        }

        return new ImageData(Data ?? [], ColorSpace ?? string.Empty, Height, Width);
    }
}

/// <summary>
///     Protobuf serialization record for a collection of ImageData.
/// </summary>
[ProtoContract(Name = "ImageDataCollection")]
public record ImageDataCollectionSerializationRecord
    : MapComponentCollectionSerializationRecord<ImageDataSerializationRecord>
{
    /// <summary>
    ///     Creates a new ImageDataCollectionSerializationRecord with the specified items.
    /// </summary>
    public ImageDataCollectionSerializationRecord(ImageDataSerializationRecord[] items)
    {
        Items = items;
    }

    /// <summary>
    ///     The collection of image data serialization records.
    /// </summary>
    public sealed override ImageDataSerializationRecord[]? Items { get; set; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }
}

/// <summary>
///     Protobuf serialization record for MeshTextureTransform.
/// </summary>
[ProtoContract(Name = "MeshTextureTransform")]
public record MeshTextureTransformSerializationRecord : MapComponentSerializationRecord<MeshTextureTransform>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public MeshTextureTransformSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new MeshTextureTransformSerializationRecord with the specified values.
    /// </summary>
    public MeshTextureTransformSerializationRecord(double[]? offset,
        double? rotation,
        double[]? scale)
    {
        Offset = offset;
        Rotation = rotation;
        Scale = scale;
    }

    /// <summary>
    ///     The UV offset values.
    /// </summary>
    [ProtoMember(1)]
    public double[]? Offset { get; init; }

    /// <summary>
    ///     The rotation angle in degrees.
    /// </summary>
    [ProtoMember(2)]
    public double? Rotation { get; init; }

    /// <summary>
    ///     The UV scale values.
    /// </summary>
    [ProtoMember(3)]
    public double[]? Scale { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for MeshTransform.
/// </summary>
[ProtoContract(Name = "MeshTransform")]
public record MeshTransformSerializationRecord : MapComponentSerializationRecord<MeshTransform>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public MeshTransformSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new MeshTransformSerializationRecord with the specified values.
    /// </summary>
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

    /// <summary>
    ///     The rotation angle in degrees.
    /// </summary>
    [ProtoMember(1)]
    public double? RotationAngle { get; init; }

    /// <summary>
    ///     The rotation axis vector.
    /// </summary>
    [ProtoMember(2)]
    public double[]? RotationAxis { get; init; }

    /// <summary>
    ///     The scale factors.
    /// </summary>
    [ProtoMember(3)]
    public double[]? Scale { get; init; }

    /// <summary>
    ///     The translation vector.
    /// </summary>
    [ProtoMember(4)]
    public double[]? Translation { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for MeshVertexAttributes.
/// </summary>
[ProtoContract(Name = "MeshVertexAttributes")]
public record MeshVertexAttributesSerializationRecord : MapComponentSerializationRecord<MeshVertexAttributes>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public MeshVertexAttributesSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new MeshVertexAttributesSerializationRecord with the specified values.
    /// </summary>
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

    /// <summary>
    ///     The vertex colors as RGBA bytes.
    /// </summary>
    [ProtoMember(1)]
    public byte[]? Color { get; init; }

    /// <summary>
    ///     The vertex normals.
    /// </summary>
    [ProtoMember(2)]
    public double[]? Normal { get; init; }

    /// <summary>
    ///     The vertex positions.
    /// </summary>
    [ProtoMember(3)]
    public double[]? Position { get; init; }

    /// <summary>
    ///     The vertex tangents.
    /// </summary>
    [ProtoMember(4)]
    public double[]? Tangent { get; init; }

    /// <summary>
    ///     The texture coordinates.
    /// </summary>
    [ProtoMember(5)]
    public double[]? Uv { get; init; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for MeshVertexSpace.
/// </summary>
[ProtoContract(Name = "MeshVertexSpace")]
public record MeshVertexSpaceSerializationRecord : MapComponentSerializationRecord<IMeshVertexSpace>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public MeshVertexSpaceSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new MeshVertexSpaceSerializationRecord with the specified values.
    /// </summary>
    public MeshVertexSpaceSerializationRecord(string? type,
        double[]? origin)
    {
        Type = type;
        Origin = origin;
    }

    /// <summary>
    ///     The vertex space type (local or georeferenced).
    /// </summary>
    [ProtoMember(1)]
    public string? Type { get; set; }

    /// <summary>
    ///     The origin coordinates of the vertex space.
    /// </summary>
    [ProtoMember(2)]
    public double[]? Origin { get; set; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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

/// <summary>
///     Protobuf serialization record for ViewHit.
/// </summary>
[ProtoContract(Name = "ViewHit")]
public record ViewHitSerializationRecord : MapComponentSerializationRecord<ViewHit>
{
    /// <summary>
    ///     Default constructor for protobuf deserialization.
    /// </summary>
    public ViewHitSerializationRecord()
    {
    }

    /// <summary>
    ///     Creates a new ViewHitSerializationRecord with the specified values.
    /// </summary>
    public ViewHitSerializationRecord(string? Type,
        GeometrySerializationRecord? MapPoint,
        GraphicSerializationRecord? Graphic,
        string? LayerId,
        double? Distance)
    {
        this.Type = Type;
        this.MapPoint = MapPoint;
        this.Graphic = Graphic;
        this.LayerId = LayerId;
        this.Distance = Distance;
    }

    /// <summary>
    ///     The type of view hit (graphic, ground, etc.).
    /// </summary>
    [ProtoMember(1)]
    public string? Type { get; set; }

    /// <summary>
    ///     The map point of the hit.
    /// </summary>
    [ProtoMember(2)]
    public GeometrySerializationRecord? MapPoint { get; set; }

    /// <summary>
    ///     The graphic that was hit (if type is graphic).
    /// </summary>
    [ProtoMember(3)]
    public GraphicSerializationRecord? Graphic { get; set; }

    /// <summary>
    ///     The layer ID of the hit graphic.
    /// </summary>
    [ProtoMember(4)]
    public string? LayerId { get; set; }

    /// <summary>
    ///     The distance to the hit in meters.
    /// </summary>
    [ProtoMember(5)]
    public double? Distance { get; set; }

    /// <inheritdoc />
    [ProtoMember(1000)]
    public override bool IsNull { get; init; }

    /// <inheritdoc />
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
                (Point)MapPoint!.FromSerializationRecord()!, Distance);
        }

        return new ViewHit(Type!, (Point)MapPoint!.FromSerializationRecord()!);
    }
}