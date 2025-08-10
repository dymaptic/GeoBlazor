namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Datum transformations used for projecting geometries in query results
/// </summary>
[CodeGenerationIgnore]
public record QueryDatumTransformation
{
    /// <summary>
    ///     Creates a new instance of <see cref="QueryDatumTransformation"/> with a simple transformation.
    /// </summary>
    /// <param name="transformation">
    ///     The simple transformation to apply to the datum.
    /// </param>
    public QueryDatumTransformation(QuerySimpleTransformation transformation)
    {
        SimpleTransformation = transformation ?? throw new ArgumentNullException(nameof(transformation));
    }
    
    /// <summary>
    ///     Creates a new instance of <see cref="QueryDatumTransformation"/> with a composite transformation.
    /// </summary>
    /// <param name="transformation">
    ///     The composite transformation to apply to the datum.
    /// </param>
    public QueryDatumTransformation(QueryCompositeTransformation transformation)
    {
        CompositeTransformation = transformation ?? throw new ArgumentNullException(nameof(transformation));
    }
    
    /// <summary>
    ///     Creates a new instance of <see cref="QueryDatumTransformation"/> with a numeric transformation.
    /// </summary>
    /// <param name="numericTransformation">
    ///     The numeric transformation to apply to the datum.
    /// </param>
    public QueryDatumTransformation(double numericTransformation)
    {
        NumericTransformation = numericTransformation;
    }

    /// <summary>
    ///     Implicit operator to convert a QuerySimpleTransformation to a QueryDatumTransformation.
    /// </summary>
    public static implicit operator QueryDatumTransformation(QuerySimpleTransformation transformation)
    {
        return new QueryDatumTransformation(transformation);
    }
    
    /// <summary>
    ///     Implicit operator to convert a QueryCompositeTransformation to a QueryDatumTransformation.
    /// </summary>
    public static implicit operator QueryDatumTransformation(QueryCompositeTransformation transformation)
    {
        return new QueryDatumTransformation(transformation);
    }
    
    /// <summary>
    ///     Implicit operator to convert a double to a QueryDatumTransformation.
    /// </summary>
    public static implicit operator QueryDatumTransformation(double numericTransformation)
    {
        return new QueryDatumTransformation(numericTransformation);
    }
    
    /// <summary>
    ///     Implicit operator to convert a QueryDatumTransformation to a QuerySimpleTransformation.
    /// </summary>
    public static implicit operator QuerySimpleTransformation?(QueryDatumTransformation transformation)
    {
        return transformation.SimpleTransformation;
    }
    
    /// <summary>
    ///     Implicit operator to convert a QueryDatumTransformation to a QueryCompositeTransformation.
    /// </summary>
    /// <param name="transformation"></param>
    /// <returns></returns>
    public static implicit operator QueryCompositeTransformation?(QueryDatumTransformation transformation)
    {
        return transformation.CompositeTransformation;
    }
    
    public static implicit operator double?(QueryDatumTransformation transformation)
    {
        return transformation.NumericTransformation;
    }
    
    /// <summary>
    ///     The simple transformation to apply to the datum.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public QuerySimpleTransformation? SimpleTransformation { get; set; }
    
    /// <summary>
    ///     The composite transformation to apply to the datum.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public QueryCompositeTransformation? CompositeTransformation { get; set; }
    
    /// <summary>
    ///     The numeric transformation to apply to the datum.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? NumericTransformation { get; set; }
}