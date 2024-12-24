namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     The base class for geometry objects. This class has no constructor. To construct geometries see
///     <see cref="Point" />, <see cref="Polyline" />, or <see cref="Polygon" />.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(GeometryConverter))]
public abstract class Geometry : MapComponent
{
    /// <summary>
    ///     The <see cref="Extent" /> of the geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? Extent { get; protected set; }

    /// <summary>
    ///     The <see cref="SpatialReference" /> of the geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }

    /// <summary>
    ///     The Geometry "type", used internally to render.
    /// </summary>
    public abstract GeometryType Type { get; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Extent extent:
                if (!extent.Equals(Extent))
                {
                    Extent = extent;
                }

                break;
            case SpatialReference spatialReference:
                // ReSharper disable once RedundantCast
                if (!((object)spatialReference).Equals(SpatialReference))
                {
                    SpatialReference = spatialReference;
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
            case Extent _:
                Extent = null;

                break;
            case SpatialReference _:
                SpatialReference = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Extent?.ValidateRequiredChildren();
        SpatialReference?.ValidateRequiredChildren();
    }

    internal abstract GeometrySerializationRecord ToSerializationRecord();

    /// <inheritdoc />
    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (Parent is not null)
        {
            await Parent.RegisterChildComponent(this);
        }
    }
}

[ProtoContract(Name = "Geometry")]
internal record GeometrySerializationRecord : MapComponentSerializationRecord
{
    public GeometrySerializationRecord()
    {
    }
    
    public GeometrySerializationRecord(string Type,
        GeometrySerializationRecord? Extent,
        SpatialReferenceSerializationRecord? SpatialReference)
    {
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

    public Geometry FromSerializationRecord()
    {
        return Type switch
        {
            "point" => new Point(Longitude, Latitude, X, Y, Z, SpatialReference?.FromSerializationRecord(),
                Extent?.FromSerializationRecord() as Extent),
            "polyline" => new Polyline(Paths!.Select(x => x.FromSerializationRecord()).ToArray(),
                SpatialReference?.FromSerializationRecord(),
                Extent?.FromSerializationRecord() as Extent),
            "polygon" => new Polygon(Rings!.Select(x => x.FromSerializationRecord()).ToArray(),
                SpatialReference?.FromSerializationRecord(),
                Extent?.FromSerializationRecord() as Extent),
            "extent" => new Extent(Xmax!.Value, Xmin!.Value, Ymax!.Value, Ymin!.Value, Zmax, Zmin, 
                Mmax, Mmin, SpatialReference?.FromSerializationRecord()),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}