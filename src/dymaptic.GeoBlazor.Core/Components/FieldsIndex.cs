namespace dymaptic.GeoBlazor.Core.Components;

public partial class FieldsIndex : MapComponent
{
    /// <summary>
    ///     For internal use only, JavaScript object reference.
    /// </summary>
    public IJSObjectReference JsFieldsReference { get; set; } = default!;


    /// <summary>
    ///     Returns a field with the specified field name.
    /// </summary>
    /// <param name="fieldName">
    ///     The name of the field. The name is case-insensitive.
    /// </param>
    [ArcGISMethod]
    public async Task<Field> Get(string fieldName)
    {
        return await JsFieldsReference.InvokeAsync<Field>("get", fieldName);
    }

    /// <summary>
    ///     Returns a time zone for a field. Use this method to ensure queries in the following places are issued in the time zone of the given date field:
    ///     FeatureLayer.DefinitionExpression
    ///     Query.Where
    ///     FeatureFilter.Where
    /// </summary>
    /// <param name="fieldName">
    ///     The name of the field.
    /// </param>
    /// <returns>
    ///     For Date Fields: Returns the time zone associated with the date field. Returns null if the layer's date fields are in unknown time zone.
    ///     For DateOnly, TimeOnly, or TimeStampOffset Fields: Returns null.
    ///     All other fields return null.
    /// </returns>
    [ArcGISMethod]
    public async Task<string?> GetTimeZone(string fieldName)
    {
        return await JsFieldsReference.InvokeAsync<string>("getTimeZone", fieldName);
    }

    /// <summary>
    ///     Checks if a field with the specified field name exists in the layer.
    /// </summary>
    /// <param name="fieldName">
    ///     The name of the field. The name is case-insensitive.
    /// </param>
    [ArcGISMethod]
    public async Task<bool> Has(string fieldName)
    {
        return await JsFieldsReference.InvokeAsync<bool>("has", fieldName);
    }
    
    /// <summary>
    ///     Checks if a field with the specified field name is a date field.
    /// </summary>
    /// <param name="fieldName">
    ///     The name of the field.
    /// </param>
    [ArcGISMethod]
    public async Task<bool> IsDateField(string fieldName)
    {
        return await JsFieldsReference.InvokeAsync<bool>("isDateField", fieldName);
    }
}