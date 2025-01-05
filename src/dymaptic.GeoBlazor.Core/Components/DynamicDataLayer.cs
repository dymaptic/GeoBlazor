namespace dymaptic.GeoBlazor.Core.Components;

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

    /// <inheritdoc/>
    public override string Type => "data-layer";

    /// <summary>
    ///     A table, feature class, or raster that resides in a registered workspace (either a folder or geodatabase). The data sources are not visible in the Services Directory by default. They may be viewed, published, and configured using the ArcGIS Server Manager.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicDataSource? DataSource { get; set; }
    /// <summary>
    ///     Controls field visibility in the layer. Only specified fields will be visible. If null, all fields are visible in the dynamic layer. The specification for a field object is provided below.
    /// </summary>
    public IReadOnlyCollection<DynamicLayerField> Fields { get => _fields; set => _fields = new HashSet<DynamicLayerField>(value); }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
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

    /// <inheritdoc/>
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


