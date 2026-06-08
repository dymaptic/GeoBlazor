namespace dymaptic.GeoBlazor.Core.Components;

public partial class Ground
{
    // Add custom code to this file to override generated code

    /// <summary>
    ///     Implicit conversion from string to Ground
    /// </summary>
    [CodeGenerationIgnore]
    public static implicit operator Ground(string stringVal) => stringVal switch
    {
        "world-elevation" => new Ground { WorldElevation = true },
        "world-topobathymetry" => new Ground { WorldTopoBathymetry = true },
        _ => throw new NotSupportedException(
            "Only 'world-elevation' and 'world-topobathymetry' are supported as string-defined Ground values.")
    };

    /// <summary>
    ///     Specifies a default instance of ground using the <a target="_blank" href="https://www.arcgis.com/home/item.html?id=7029fb60158543ad845c7e1527af11e4">Terrain3D Service</a>.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? WorldElevation { get; set; }

    /// <summary>
    ///     Specifies an instance of ground that combines surface elevation and bathymetry using the <a target="_blank" href="https://www.arcgis.com/home/item.html?id=0c69ba5a5d254118841d43f03aa3e97d">TopoBathy3D Service</a>.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? WorldTopoBathymetry { get; set; }
}