using dymaptic.GeoBlazor.Core.Objects;


namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Represents the result of a query for attachments, grouped by the source feature objectIds.
/// </summary>
public class AttachmentQueryResult: Dictionary<long, AttachmentInfo>;