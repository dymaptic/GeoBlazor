namespace dymaptic.GeoBlazor.Pro.Components;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.SelectionTools.html">GeoBlazor Docs</a>
///     The available selection tools within the widget.
/// </summary>
/// <remarks>
/// Known Limitation: Rectangle and lasso selection is only supported when working with a MapView.
/// </remarks>
[CodeGenerationIgnore]
public partial class SelectionTools : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public SelectionTools()
    {
    }
    
    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="lassoSelection">
    ///     Indicates whether to display the "lasso-selection" tool. Default is true.
    /// </param>
    /// <param name="rectangleSelection">
    ///     Indicates whether to display the "rectangle-selection" tool. Default is true.
    /// </param>
    [CodeGenerationIgnore]
    public SelectionTools(bool? lassoSelection = true, bool? rectangleSelection = true)
    {
        AllowRender = false;
#pragma warning disable BL0005
        LassoSelection = lassoSelection;
        RectangleSelection = rectangleSelection;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     Indicates whether to display the "lasso-selection" tool. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LassoSelection { get; set; }
    
    /// <summary>
    ///     Indicates whether to display the "rectangle-selection" tool. Default is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? RectangleSelection { get; set; }
}