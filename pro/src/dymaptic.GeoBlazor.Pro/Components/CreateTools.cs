namespace dymaptic.GeoBlazor.Pro.Components;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.CreateTools.html">GeoBlazor Docs</a>
///     The available sketch tools within the widget.
/// </summary>
[CodeGenerationIgnore]
public partial class CreateTools : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public CreateTools()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="circle">
    ///     Indicates whether to display the circle sketch tool. Default is true.
    /// </param>
    /// <param name="freehandPolygon">
    ///     Indicates whether to display the freehand polygon sketch tool. Default is false.
    /// </param>
    /// <param name="freehandPolyline">
    ///     Indicates whether to display the freehand polyline sketch tool. Default is false.
    /// </param>
    /// <param name="point">
    ///     Indicates whether to display the point sketch tool. Default is true.
    /// </param>
    /// <param name="polygon">
    ///     Indicates whether to display the polygon sketch tool. Default is true.
    /// </param>
    /// <param name="polyline">
    ///     Indicates whether to display the polyline sketch tool. Default is true.
    /// </param>
    /// <param name="rectangle">
    ///     Indicates whether to display the rectangle sketch tool. Default is true.
    /// </param>
    [CodeGenerationIgnore]
    public CreateTools(
        bool? circle = null,
        bool? freehandPolygon = null,
        bool? freehandPolyline = null,
        bool? point = null,
        bool? polygon = null,
        bool? polyline = null,
        bool? rectangle = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Circle = circle;
        FreehandPolygon = freehandPolygon;
        FreehandPolyline = freehandPolyline;
        Point = point;
        Polygon = polygon;
        Polyline = polyline;
        Rectangle = rectangle;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.CreateTools.html#createtoolsfreehandpolygon-property">GeoBlazor Docs</a>
    ///     Indicates whether to display the freehand polygon sketch tool. Default is false.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? FreehandPolygon { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.CreateTools.html#createtoolsfreehandpolyline-property">GeoBlazor Docs</a>
    ///     Indicates whether to display the freehand polyline sketch tool. Default is false.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? FreehandPolyline { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.CreateTools.html#createtoolsrectangle-property">GeoBlazor Docs</a>
    ///     Indicates whether to display the point sketch tool. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? Point { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.CreateTools.html#createtoolsrectangle-property">GeoBlazor Docs</a>
    ///     Indicates whether to display the polyline sketch tool. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? Polyline { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.CreateTools.html#createtoolsrectangle-property">GeoBlazor Docs</a>
    ///     Indicates whether to display the polygon sketch tool. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? Polygon { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.CreateTools.html#createtoolsrectangle-property">GeoBlazor Docs</a>
    ///     Indicates whether to display the rectangle sketch tool. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? Rectangle { get; set; }

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.CreateTools.html#createtoolscircle-property">GeoBlazor Docs</a>
    ///     Indicates whether to display the circle sketch tool. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? Circle { get; set; }
    
#endregion
}