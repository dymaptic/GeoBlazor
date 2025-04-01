namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(LayerViewConverter))]
public partial class LayerView : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public LayerView()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="type">
    ///     The type of layer view.
    /// </param>
    /// <param name="spatialReferenceSupported">
    ///     Indicates if the  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#spatialReference">spatialReference</a> of the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">MapView</a> is supported by the layer view.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html#spatialReferenceSupported">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="suspended">
    ///     Value is `true` if the layer is suspended (i.e., layer will not redraw or update itself when the extent changes).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html#suspended">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="updating">
    ///     Indicates if the layer view is making any updates that will impact what is displayed on the map.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html#updating">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visibleAtCurrentScale">
    ///     When `true`, the layer is visible in the view at the current scale.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html#visibleAtCurrentScale">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visibleAtCurrentTimeExtent">
    ///     When `true`, the layer is visible in the view's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html#timeExtent">timeExtent</a>.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html#visibleAtCurrentTimeExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visible">
    ///     When `true`, the layer is visible in the view.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html#visible">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public LayerView(
        LayerType type,
        bool? spatialReferenceSupported = null,
        bool? suspended = null,
        bool? updating = null,
        bool? visibleAtCurrentScale = null,
        bool? visibleAtCurrentTimeExtent = null,
        bool? visible = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        // ReSharper disable once VirtualMemberCallInConstructor
        Type = type;
        SpatialReferenceSupported = spatialReferenceSupported;
        Suspended = suspended;
        Updating = updating;
        VisibleAtCurrentScale = visibleAtCurrentScale;
        VisibleAtCurrentTimeExtent = visibleAtCurrentTimeExtent;
        Visible = visible;
#pragma warning restore BL0005    
    }
    
    /// <summary>
    ///     Identifies the layer view type.
    /// </summary>
    public virtual LayerType? Type { get; set; }
}