namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
/// Time info represents the temporal data of a time-aware layer. The time info class provides information such
/// as date fields that store the start and end times for each feature and the total time span for the layer.
/// </summary>
public record TimeInfo
{
    /// <summary>
    ///     Public constructor
    /// </summary>
    /// <param name="startField">
    ///     The name of the field containing the start time information.
    /// </param>
    /// <param name="endField">
    ///     The name of the field containing the end time information.
    /// </param>
    public TimeInfo(string? startField, string? endField)
    {
        StartField = startField;
        EndField = endField;
    }


    /// <summary>
    ///   The name of the field containing the end time information.
    /// </summary>
    public string? EndField { get; set; }

    /// <summary>
    ///  The time extent defines the start time and end time for all data in the layer.
    ///  The fullTimeExtent for timeInfo is automatically calculated based on its startField and endField properties.
    ///  The timeInfo parameters cannot be changed after the layer is loaded.
    /// </summary>
    public TimeExtent? FullTimeExtent { get; set; }

    /// <summary>
    ///   The time interval defines the granularity of the temporal data and allows you to visualize the data at specified intervals using the time slider widget.
    /// </summary>
    public TimeInterval? Interval { get; set; }

    /// <summary>
    ///  The name of the field containing the start time information.
    /// </summary>
    public string? StartField { get; set; }

    /// <summary>
    /// The name of the field used to join or group discrete locations.
    /// </summary>
    public string? TrackIdField { get; set; }
}