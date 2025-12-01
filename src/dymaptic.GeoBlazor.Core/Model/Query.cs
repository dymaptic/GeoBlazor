using ParameterValue = Microsoft.AspNetCore.Components.ParameterValue;

namespace dymaptic.GeoBlazor.Core.Model;

public partial record Query
{
    /// <summary>
    ///     Determines whether to use the view's extent as the query geometry
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseViewExtent { get; set; }
    
    /// <summary>
    ///     Internal GeoBlazor Tracking Id for Queries Created by a Layer or View
    /// </summary>
    public Guid Id { get; set; }
}


