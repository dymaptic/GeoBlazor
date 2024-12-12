namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     FeatureEditResult represents the result of adding, updating or deleting a feature or an attachment.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#FeatureEditResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="ObjectId">
///     The objectId of the feature or the attachmentId of the attachment that was edited.
/// </param>
/// <param name="GlobalId">
///     The globalId of the feature or the attachment that was edited.
/// </param>
/// <param name="Error">
///     If the edit failed, the edit result includes an error.
/// </param>
public record FeatureEditResult(long? ObjectId, string? GlobalId, EditError? Error);

/// <summary>
///     The error object in a <see cref="FeatureEditResult"/>
/// </summary>
/// <param name="Name">
///     Error name.
/// </param>
/// <param name="Message">
///     Message describing the error.
/// </param>
public record EditError(string? Name, string? Message);