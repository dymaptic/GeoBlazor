using ParameterValue = Microsoft.AspNetCore.Components.ParameterValue;

namespace dymaptic.GeoBlazor.Core.Model;

public partial record Query
{
    /// <summary>
    ///     Determines whether to use the view's extent as the query geometry
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseViewExtent { get; set; }
}


