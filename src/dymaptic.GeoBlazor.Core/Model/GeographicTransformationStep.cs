namespace dymaptic.GeoBlazor.Core.Model;

public partial record GeographicTransformationStep
{
    [CodeGenerationIgnore]
    public GeographicTransformationStep(): this(null, null)
    {
        
    }

    /// <summary>
    ///     Indicates if the geographic transformation is inverted.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsInverse { get; set; } = IsInverse;

    /// <summary>
    ///     The well-known id (wkid) that represents a known geographic transformation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Wkid { get; set; } = Wkid;

    /// <summary>
    ///     The well-known text (wkt) that represents a known geographic transformation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Wkt { get; set; } = Wkt;
}