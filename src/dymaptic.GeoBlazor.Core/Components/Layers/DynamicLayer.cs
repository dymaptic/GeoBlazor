using dymaptic.GeoBlazor.Core.Attributes;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Abstract base class for <see cref="DynamicMapLayer"/> and <see cref="DynamicDataLayer"/>.
/// </summary>
[JsonConverter(typeof(DynamicLayerConverter))]
public abstract class DynamicLayer : MapComponent
{
    /// <summary>
    ///     The type of dynamic layer
    /// </summary>
    public abstract string Type { get; }
}

/// <summary>
///     A dynamic map layer refers to a layer published in a map service that has dynamic layers enabled. This layer type may be used to create multiple sublayers that point to the same service layer, but are assigned different definition expressions, renderers, and other properties.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#DynamicMapLayer">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class DynamicMapLayer : DynamicLayer
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public DynamicMapLayer()
    {
    }
    
    /// <summary>
    ///     Creates a new DynamicMapLayer in code with parameters.
    /// </summary>
    /// <param name="mapLayerId">
    ///     The id of the service sublayer.
    /// </param>
    /// <param name="gdbVersion">
    ///     An optional property for specifying the GDB version.
    /// </param>
    public DynamicMapLayer(int mapLayerId, string? gdbVersion = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        MapLayerId = mapLayerId;
        GdbVersion = gdbVersion;
#pragma warning restore BL0005 // Set parameter or member default value.
    }
    
    /// <inheritdoc />
    public override string Type => "map-layer";
    
    /// <summary>
    ///     The id of the service sublayer.
    /// </summary>
    [Parameter]
    [EditorRequired]
    [RequiredProperty]
    public int MapLayerId { get; set; }
    
    /// <summary>
    ///     An optional property for specifying the GDB version.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GdbVersion { get; set; }
}

/// <summary>
///     A dynamic data layer is a layer created on-the-fly with data stored in a registered workspace. This is data that can be rendered and queried on the fly, but that isn't explicitly exposed as a service sublayer. Depending on the type of data source, these layers are classified as one of the following:
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#DynamicDataLayer">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class DynamicDataLayer : DynamicLayer
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public DynamicDataLayer()
    {
    }
    
    /// <summary>
    ///     Creates a new DynamicDataLayer in code with parameters.
    /// </summary>
    /// <param name="dataSource">
    ///     The data source for the dynamic data layer.
    /// </param>
    /// <param name="fields">
    ///     Controls field visibility in the layer. Only specified fields will be visible. If null, all fields are visible in the dynamic layer. The specification for a field object is provided below.
    /// </param>
    public DynamicDataLayer(DynamicDataSource dataSource, IEnumerable<DynamicLayerField>? fields = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        DataSource = dataSource;

        if (fields is not null)
        {
            _fields = new HashSet<DynamicLayerField>(fields);
        }
#pragma warning restore BL0005 // Set parameter or member default value.
    }
    
    /// <inheritdoc />
    public override string Type => "data-layer";
    
    /// <summary>
    ///     A table, feature class, or raster that resides in a registered workspace (either a folder or geodatabase). The data sources are not visible in the Services Directory by default. They may be viewed, published, and configured using the ArcGIS Server Manager.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicDataSource? DataSource { get; set; }
    
    /// <summary>
    ///     Controls field visibility in the layer. Only specified fields will be visible. If null, all fields are visible in the dynamic layer. The specification for a field object is provided below.
    /// </summary>
    public IReadOnlyCollection<DynamicLayerField> Fields
    {
        get => _fields;
        set => _fields = new HashSet<DynamicLayerField>(value);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case DynamicDataSource dataSource:
                DataSource = dataSource;
                
                break;
            case DynamicLayerField field:
                _fields.Add(field);
                
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
            case DynamicDataSource:
                DataSource = null;
                
                break;
            case DynamicLayerField field:
                _fields.Remove(field);

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        DataSource?.ValidateRequiredChildren();

        foreach (DynamicLayerField field in _fields)
        {
            field.ValidateRequiredChildren();
        }
        base.ValidateRequiredChildren();
    }
    
    private HashSet<DynamicLayerField> _fields = new();
}

/// <summary>
///     Abstract base class for data sources in a dynamic data layer.
/// </summary>
[JsonConverter(typeof(DynamicDataSourceConverter))]
public abstract class DynamicDataSource : MapComponent
{
    /// <summary>
    ///     The name of the data source type.
    /// </summary>
    public abstract string Type { get; }
}

/// <summary>
///     A table or feature class that resides in a registered workspace (either a folder or geodatabase). In the case of a geodatabase, if versioned, use version to switch to an alternate geodatabase version.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#TableDataSource">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class TableDataSource : DynamicDataSource
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public TableDataSource()
    {
    }

    /// <summary>
    ///     Creates a new TableDataSource in code with parameters.
    /// </summary>
    /// <param name="workspaceId">
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </param>
    /// <param name="dataSourceName">
    ///     The name of the table in the registered workspace.
    /// </param>
    /// <param name="gdbVersion">
    ///     References the geodatabase version if multiple versions exist in the geodatabase.
    /// </param>
    public TableDataSource(string workspaceId, string dataSourceName, string? gdbVersion = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        WorkspaceId = workspaceId;
        DataSourceName = dataSourceName;
        GdbVersion = gdbVersion;
#pragma warning restore BL0005 // Set parameter or member default value.
    }

    /// <inheritdoc />
    public override string Type => "table";
    
    /// <summary>
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WorkspaceId { get; set; }
    
    /// <summary>
    ///     The name of the table in the registered workspace.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DataSourceName { get; set; }
    
    /// <summary>
    ///     References the geodatabase version if multiple versions exist in the geodatabase.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GdbVersion { get; set; }
}

/// <summary>
///     A query table is a feature class or table defined by a SQL query on the fly. Query layers allow both spatial and nonspatial information stored in a database to be easily integrated into map service operations. Since a query table uses SQL to directly query database tables and views, spatial information used by a query table is not required to be in a geodatabase.
///     This data source is useful for scenarios where you have a table containing multiple records that match to a single geometry in either another table or a map service layer. You can use the QueryTableDataSource to select only a subset of those matching records and join them to the table with geometries so records in both tables have a one-to-one relationship with each other.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#QueryTableDataSource">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class QueryTableDataSource : DynamicDataSource
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public QueryTableDataSource()
    {
    }

    /// <summary>
    ///     Creates a new QueryTableDataSource in code with parameters.
    /// </summary>
    /// <param name="workspaceId">
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </param>
    /// <param name="query">
    ///     The SQL query used to filter records.
    /// </param>
    /// <param name="oidFields">
    ///     The field name(s) containing the unique IDs for each record in the table. This can be a comma separated list if the query table is used in a JoinTableDataSource.
    /// </param>
    /// <param name="geometryType">
    ///     The geometry type of each record in the table.
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference of the geometry of each feature in the table source.
    /// </param>
    public QueryTableDataSource(string workspaceId, string query, string? oidFields = null, 
        GeometryType? geometryType = null, SpatialReference? spatialReference = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        WorkspaceId = workspaceId;
        Query = query;
        OidFields = oidFields;
        GeometryType = geometryType;
        SpatialReference = spatialReference;
#pragma warning restore BL0005 // Set parameter or member default value.
    }

    /// <inheritdoc />
    public override string Type => "query-table";
    
    /// <summary>
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WorkspaceId { get; set; }

    /// <summary>
    ///     The SQL query used to filter records.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Query { get; set; }
    
    /// <summary>
    ///     The field name(s) containing the unique IDs for each record in the table. This can be a comma separated list if the query table is used in a JoinTableDataSource.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OidFields { get; set; }
    
    /// <summary>
    ///     The geometry type of each record in the table.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GeometryType? GeometryType { get; set; }
    
    /// <summary>
    ///     The spatial reference of the geometry of each feature in the table source.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SpatialReference spatialReference:
                SpatialReference = spatialReference;

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
        SpatialReference?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     A file-based raster that resides in a registered raster workspace. The raster may only be displayed in the view, not queried or assigned a renderer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#RasterDataSource">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class RasterDataSource : DynamicDataSource
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public RasterDataSource()
    {
    }

    /// <summary>
    ///     Creates a new RasterDataSource in code with parameters.
    /// </summary>
    /// <param name="workspaceId">
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </param>
    /// <param name="dataSourceName">
    ///     The name of the raster in the registered workspace.
    /// </param>
    public RasterDataSource(string workspaceId, string dataSourceName)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        WorkspaceId = workspaceId;
        DataSourceName = dataSourceName;
#pragma warning restore BL0005 // Set parameter or member default value.
    }

    /// <inheritdoc />
    public override string Type => "raster";
    
    /// <summary>
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WorkspaceId { get; set; }
    
    /// <summary>
    ///     The name of the raster in the registered workspace.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DataSourceName { get; set; }
}

/// <summary>
///     The result of an on-the-fly join operation at runtime. Nested joins are supported. To use nested joins, set either leftTableSource or rightTableSource to join-table.
///     <a target="_blank" href="The result of an on-the-fly join operation at runtime. Nested joins are supported. To use nested joins, set either leftTableSource or rightTableSource to join-table.">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class JoinTableDataSource : DynamicDataSource
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public JoinTableDataSource()
    {
    }

    /// <summary>
    ///     Creates a new JoinTableDataSource in code with parameters.
    /// </summary>
    /// <param name="leftTableKey">
    ///     The field name used for joining or matching records in the left table to records in the right table.
    /// </param>
    /// <param name="rightTableKey">
    ///     The field name used for joining or matching records in the right table to records in the left table.
    /// </param>
    /// <param name="joinType">
    ///     The type of join that will be performed.
    /// </param>
    /// <param name="leftTableSource">
    ///     The left table for joining to the right table source. This can either be a dynamic map layer or a dynamic data layer. The dynamic data layer may contain another join data source used for nested joining.
    /// </param>
    /// <param name="rightTableSource">
    ///     The right table for joining to the left table source. This can either be a dynamic map layer or a dynamic data layer. The dynamic data layer may contain another join data source used for nested joining.
    /// </param>
    public JoinTableDataSource(string leftTableKey, string rightTableKey, DynamicJoinType joinType,
        DynamicLayer leftTableSource, DynamicLayer rightTableSource)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        LeftTableKey = leftTableKey;
        RightTableKey = rightTableKey;
        JoinType = joinType;
        LeftTableSource = leftTableSource;
        RightTableSource = rightTableSource;
#pragma warning restore BL0005 // Set parameter or member default value.
    }

    /// <inheritdoc />
    public override string Type => "join-table";
    
    /// <summary>
    ///     The field name used for joining or matching records in the left table to records in the right table.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LeftTableKey { get; set; }
    
    /// <summary>
    ///     The field name used for joining or matching records in the right table to records in the left table.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? RightTableKey { get; set; }
    
    /// <summary>
    ///     The type of join that will be performed.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicJoinType? JoinType { get; set; }
    
    /// <summary>
    ///     The left table for joining to the right table source. This can either be a dynamic map layer or a dynamic data layer. The dynamic data layer may contain another join data source used for nested joining.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicLayer? LeftTableSource { get; set; }
    
    /// <summary>
    ///     The right table for joining to the left table source. This can either be a dynamic map layer or a dynamic data layer. The dynamic data layer may contain another join data source used for nested joining.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicLayer? RightTableSource { get; set; }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case DynamicLayer dynamicLayer:
                if (LeftTableSource is null)
                {
                    LeftTableSource = dynamicLayer;
                }
                else
                {
                    RightTableSource = dynamicLayer;
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
            case DynamicLayer dynamicLayer:
                if (dynamicLayer.Equals(LeftTableSource))
                {
                    LeftTableSource = null;
                }
                else
                {
                    RightTableSource = null;
                }

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        LeftTableSource?.ValidateRequiredChildren();
        RightTableSource?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     Defines fields that should be visible in the <see cref="DynamicDataLayer"/>
/// </summary>
public class DynamicLayerField : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public DynamicLayerField()
    {
    }
    
    /// <summary>
    ///     Creates a new DynamicLayerField in code with parameters.
    /// </summary>
    /// <param name="name">
    ///     The name of the field.
    /// </param>
    /// <param name="alias">
    ///     The alias of the field.
    /// </param>
    public DynamicLayerField(string name, string? alias = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        Name = name;
        Alias = alias;
#pragma warning restore BL0005 // Set parameter or member default value.
    }
    
    /// <summary>
    ///     The name of the field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
    
    /// <summary>
    ///     The alias of the field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Alias { get; set; }
}

internal class DynamicLayerConverter : JsonConverter<DynamicLayer>
{
    public override DynamicLayer? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        Utf8JsonReader cloneReader = reader;

        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, newOptions) is not
            IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.TryGetValue("type", out object? typeValue))
        {
            switch (typeValue?.ToString())
            {
                case "map-layer":
                    return JsonSerializer.Deserialize<DynamicMapLayer>(ref cloneReader, newOptions);
                case "data-layer":
                    return JsonSerializer.Deserialize<DynamicDataLayer>(ref cloneReader, newOptions);
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, DynamicLayer value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, typeof(object), options);
    }
}

internal class DynamicDataSourceConverter : JsonConverter<DynamicDataSource>
{
    public override DynamicDataSource? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        Utf8JsonReader cloneReader = reader;

        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, newOptions) is not
            IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.TryGetValue("type", out object? typeValue))
        {
            switch (typeValue?.ToString())
            {
                case "table":
                    return JsonSerializer.Deserialize<TableDataSource>(ref cloneReader, newOptions);
                case "query-table":
                    return JsonSerializer.Deserialize<QueryTableDataSource>(ref cloneReader, newOptions);
                case "raster":
                    return JsonSerializer.Deserialize<RasterDataSource>(ref cloneReader, newOptions);
                case "join-table":
                    return JsonSerializer.Deserialize<JoinTableDataSource>(ref cloneReader, newOptions);
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, DynamicDataSource value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, typeof(object), options);
    }
}