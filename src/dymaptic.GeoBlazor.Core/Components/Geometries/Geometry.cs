namespace dymaptic.GeoBlazor.Core.Components.Geometries;

[JsonConverter(typeof(GeometryConverter))]
public abstract partial class Geometry : MapComponent
{
    /// <summary>
    ///     The <see cref = "Extent"/> of the geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    [JsonInclude]
    public Extent? Extent { get; protected set; }

    /// <summary>
    ///     Indicates if the geometry has M values.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#hasM">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasM { get; set; }

    /// <summary>
    ///     Indicates if the geometry has z-values (elevation).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#hasZ">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasZ { get; set; }

    /// <summary>
    ///     The spatial reference of the geometry.
    ///     default WGS84 (wkid: 4326)
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#spatialReference">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public SpatialReference? SpatialReference { get; set; }
    /// <summary>
    ///     The Geometry "type", used internally to render.
    /// </summary>
    public abstract GeometryType Type { get; }

    /// <inheritdoc/>
    [CodeGenerationIgnore]
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
                if (!spatialReference.Equals(SpatialReference))
                {
                    SpatialReference = spatialReference;
                }

                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    [CodeGenerationIgnore]
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

    /// <inheritdoc/>
    [CodeGenerationIgnore]
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Extent?.ValidateRequiredChildren();
        SpatialReference?.ValidateRequiredChildren();
    }

    /// <summary>
    ///     Asynchronously retrieve the current value of the SpatialReference property.
    /// </summary>
    public async Task<Extent?> GetExtent()
    {
        if (CoreJsModule is null)
        {
            return Extent;
        }

        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Extent;
        }

        // get the property value
#pragma warning disable BL0005
        Extent = await CoreJsModule!.InvokeAsync<Extent?>("getProperty", CancellationTokenSource.Token, JsComponentReference, "extent");
#pragma warning restore BL0005
        return Extent;
    }

    internal abstract GeometrySerializationRecord ToSerializationRecord();
    /// <inheritdoc/>
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

    public GeometrySerializationRecord(string Type, GeometrySerializationRecord? Extent, SpatialReferenceSerializationRecord? SpatialReference)
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

    public Geometry FromSerializationRecord()
    {
        return Type switch
        {
            "point" => new Point(Longitude, Latitude, X, Y, Z, SpatialReference?.FromSerializationRecord(), HasM, HasZ, M),
            "polyline" => new Polyline(Paths!.Select(x => x.FromSerializationRecord()).ToArray(), SpatialReference?.FromSerializationRecord(), HasM, HasZ),
            "polygon" => Center is not null && Radius is not null
            ? new Circle((Point)Center.FromSerializationRecord(), Radius.Value, 
                Centroid?.FromSerializationRecord() as Point, 
                Geodesic, HasM, HasZ, IsSelfIntersecting, NumberOfPoints, 
                RadiusUnit is null ? null : Enum.Parse<RadiusUnit>(RadiusUnit),
                Rings!.Select(x => x.FromSerializationRecord()).ToArray(),
                SpatialReference?.FromSerializationRecord())
            : new Polygon(Rings!.Select(x => x.FromSerializationRecord()).ToArray(), 
                SpatialReference?.FromSerializationRecord(), 
                Centroid?.FromSerializationRecord() as Point, 
                HasM, HasZ, IsSelfIntersecting),
            "extent" => new Extent(Xmax!.Value, Xmin!.Value, Ymax!.Value, Ymin!.Value, Zmax, Zmin, Mmax, Mmin, SpatialReference?.FromSerializationRecord(), HasM, HasZ),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}