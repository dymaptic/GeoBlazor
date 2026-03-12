namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Union of number and DateTime values
/// </summary>
[JsonConverter(typeof(UnionConverter<NumberOrDate>))]
public record NumberOrDate
{
    /// <summary>
    ///     Parameterless Constructor
    /// </summary>
    public NumberOrDate()
    {
        
    }

    /// <summary>
    ///     Constructor with params
    /// </summary>
    /// <param name="number">
    ///     The numeric value
    /// </param>
    /// <param name="date">
    ///     The DateTime value
    /// </param>
    public NumberOrDate(double? number = null, DateTime? date = null)
    {
        Number = number;
        Date = date;
    }

    /// <summary>
    ///     The numeric value
    /// </summary>
    public double? Number { get; set; }

    /// <summary>
    ///     The DateTime value
    /// </summary>
    public DateTime? Date { get; set; }
}
