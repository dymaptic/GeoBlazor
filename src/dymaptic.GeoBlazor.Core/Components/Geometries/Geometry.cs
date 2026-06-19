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
    public Extent? Extent { get; internal set; }

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
    ///     Is Simple based on the ArcGIS simplify operator. Indicates if the given geometry is non-OGC topologically simple. This operation takes into account z-values.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-operators-simplifyOperator.html#isSimple">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [CodeGenerationIgnore]
    public virtual bool? IsSimple { get; internal set; }
    
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
        if (CoreJsModule is not null)
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent", CancellationTokenSource.Token, Id);

            if (JsComponentReference is not null)
            {
                // get the property value
                Extent? jsExtent = await CoreJsModule!.InvokeAsync<Extent?>("getProperty", CancellationTokenSource.Token, JsComponentReference, "extent");

                if (jsExtent is not null)
                {
#pragma warning disable BL0005
                    Extent = jsExtent;
#pragma warning restore BL0005
                }
            }
        }

        // Fall back to calculating the extent client-side when neither the cached value
        // nor the JS component provided one (e.g. geometries created in C#, or returned
        // from operators that do not expose a cached extent).
        if (Extent is null)
        {
#pragma warning disable BL0005
            Extent = CalculateExtent();
#pragma warning restore BL0005
        }

        return Extent;
    }

    /// <summary>
    ///     Calculates the <see cref="Extent" /> (bounding box) of this geometry from its
    ///     coordinates. Returns the existing <see cref="Extent" /> by default; vertex-based
    ///     geometries (e.g. <see cref="Polygon" />, <see cref="Polyline" />) override this to
    ///     compute a missing extent.
    /// </summary>
    [CodeGenerationIgnore]
    protected virtual Extent? CalculateExtent() => Extent;

    /// <summary>
    ///     Computes a bounding-box <see cref="Extent" /> over a set of vertex paths/rings,
    ///     or <see langword="null" /> when there are no coordinates. When the geometry has
    ///     Z and/or M values, the resulting extent's Z/M bounds are populated as well.
    /// </summary>
    [CodeGenerationIgnore]
    protected static Extent? CalculateExtentFromPaths(IEnumerable<MapPath>? paths,
        SpatialReference? spatialReference, bool? hasZ = null, bool? hasM = null)
    {
        if (paths is null)
        {
            return null;
        }

        // Coordinates are [x, y, z?, m?]: z is at index 2 when hasZ; m is at index 3
        // when hasZ, otherwise index 2.
        int zIndex = hasZ == true ? 2 : -1;
        int mIndex = hasM == true ? (hasZ == true ? 3 : 2) : -1;

        double xmin = double.MaxValue, ymin = double.MaxValue;
        double xmax = double.MinValue, ymax = double.MinValue;
        double zmin = double.MaxValue, zmax = double.MinValue;
        double mmin = double.MaxValue, mmax = double.MinValue;
        bool any = false, anyZ = false, anyM = false;

        foreach (MapPath path in paths)
        {
            foreach (MapPoint point in path)
            {
                if (point.Count < 2)
                {
                    continue;
                }

                any = true;
                if (point[0] < xmin) xmin = point[0];
                if (point[0] > xmax) xmax = point[0];
                if (point[1] < ymin) ymin = point[1];
                if (point[1] > ymax) ymax = point[1];

                if (zIndex >= 0 && point.Count > zIndex)
                {
                    anyZ = true;
                    if (point[zIndex] < zmin) zmin = point[zIndex];
                    if (point[zIndex] > zmax) zmax = point[zIndex];
                }

                if (mIndex >= 0 && point.Count > mIndex)
                {
                    anyM = true;
                    if (point[mIndex] < mmin) mmin = point[mIndex];
                    if (point[mIndex] > mmax) mmax = point[mIndex];
                }
            }
        }

        if (!any)
        {
            return null;
        }

        return new Extent(xmax, xmin, ymax, ymin,
            zmax: anyZ ? zmax : null, zmin: anyZ ? zmin : null,
            mmax: anyM ? mmax : null, mmin: anyM ? mmin : null,
            spatialReference: spatialReference,
            hasM: anyM ? true : hasM, hasZ: anyZ ? true : hasZ);
    }

    internal abstract GeometrySerializationRecord ToSerializationRecord();
}

[ProtoContract(Name = "Geometry")]
internal record GeometrySerializationRecord : MapComponentSerializationRecord
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

    public Geometry FromSerializationRecord()
    {
        Extent? extent = Extent?.FromSerializationRecord() as Extent;
        Guid id = Guid.NewGuid();

        if (Guid.TryParse(Id, out Guid guidId))
        {
            id = guidId;
        }
        
        if (Type == "multipoint")
        {
            // Multipoint is in GeoBlazor Pro assembly, so we need to use reflection to get the type
            Type? multipointType = System.Type.GetType("dymaptic.GeoBlazor.Pro.Components.Geometries.Multipoint, " +
                "dymaptic.GeoBlazor.Pro");

            if (multipointType is not null && multipointType.IsSubclassOf(typeof(Geometry)))
            {
                Point[]? points = Points?.Select(p =>
                    {
                        MapPoint mp = p.FromSerializationRecord();

                        return new Point(x: mp[0], y: mp[1]);
                    })
                    .ToArray();

                if (Activator.CreateInstance(multipointType, 
                        args: [HasM, HasZ, points, SpatialReference?.FromSerializationRecord()]) 
                    is not Geometry multipoint)
                {
                    throw new InvalidOperationException(
                        "Multipoint could not be created. Ensure the type is correct and the assembly is loaded.");
                }
                multipoint.Extent = extent;
                multipoint.Id = id;
                multipoint.IsSimple = IsSimple;

                return multipoint;
            }
        }
        
        return Type switch
        {
            "point" => new Point(Longitude, Latitude, X, Y, Z, SpatialReference?.FromSerializationRecord(), HasM, HasZ, M)
            {
                Extent = extent,
                Id = id
            },
            "polyline" => new Polyline(Paths!.Select(x => x.FromSerializationRecord()).ToArray(),
                SpatialReference?.FromSerializationRecord(), HasM, HasZ)
            {
                Extent = extent,
                Id = id,
                IsSimple = IsSimple
            },
            "polygon" => Center is not null && Radius is not null
            ? new Circle((Point)Center.FromSerializationRecord(), Radius.Value, 
                Centroid?.FromSerializationRecord() as Point, 
                Geodesic, HasM, HasZ, NumberOfPoints, 
                RadiusUnit is null ? null : Enum.Parse<RadiusUnit>(RadiusUnit),
                Rings!.Select(x => x.FromSerializationRecord()).ToArray(),
                SpatialReference?.FromSerializationRecord())
                {
                    Extent = extent,
                    Id = id,
                    IsSimple = IsSimple
                }
            : new Polygon(Rings!.Select(x => x.FromSerializationRecord()).ToArray(), 
                SpatialReference?.FromSerializationRecord(), 
                Centroid?.FromSerializationRecord() as Point, 
                HasM, HasZ)
                {
                    Extent = extent,
                    Id = id,
                    IsSimple = IsSimple
                },
            "extent" => new Extent(Xmax!.Value, Xmin!.Value, Ymax!.Value, Ymin!.Value, Zmax, 
                Zmin, Mmax, Mmin, SpatialReference?.FromSerializationRecord(), HasM, HasZ)
            {
                Id = id,
                IsSimple = IsSimple
            },
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}