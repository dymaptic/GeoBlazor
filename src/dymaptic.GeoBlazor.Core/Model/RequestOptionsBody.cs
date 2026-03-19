namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.RequestOptionsBody.html">GeoBlazor Docs</a>
///     Union type of <see cref="Dictionary{String, String}" />, <see cref="ElementReference" />, and <see cref="string" />
/// </summary>
[JsonConverter(typeof(UnionConverter<RequestOptionsBody>))]
[CodeGenerationIgnore]
public record RequestOptionsBody
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public RequestOptionsBody()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="bodyElementReference">
    ///     Implementation of parent property Body as ElementReference.
    /// </param>
    /// <param name="bodyFormData">
    ///     Implementation of parent property Body as FormData (Dictionary).
    /// </param>
    /// <param name="bodyString">
    ///     Implementation of parent property Body as String.
    /// </param>
    public RequestOptionsBody(ElementReference? bodyElementReference = null,
        Dictionary<string, string?>? bodyFormData = null,
        string? bodyString = null)
    {
        BodyElementReference = bodyElementReference;
        BodyFormData = bodyFormData;
        BodyString = bodyString;
    }


    #region Union Conversion Operators

    /// <summary>
    ///     Implicit conversion between <see cref="ElementReference" /> and <see cref="RequestOptionsBody" />.
    /// </summary>
    /// <param name="bodyElementReference">
    ///     The ElementReference to use as the value.
    /// </param>
    public static implicit operator RequestOptionsBody(ElementReference bodyElementReference) =>
        new(bodyElementReference: bodyElementReference);

    /// <summary>
    ///     Implicit conversion between <see cref="Dictionary{String, String}" /> and <see cref="RequestOptionsBody" />.
    /// </summary>
    /// <param name="bodyFormData">
    ///     The Dictionary to use as the value.
    /// </param>
    public static implicit operator RequestOptionsBody(Dictionary<string, string?> bodyFormData) =>
        new(bodyFormData: bodyFormData);
        

    /// <summary>
    ///     Implicit conversion between a string and <see cref="RequestOptionsBody" />.
    /// </summary>
    /// <param name="bodyString">
    ///     The string to use as the value.
    /// </param>
    public static implicit operator RequestOptionsBody(string bodyString) =>
        new(bodyString: bodyString);

#endregion


#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.RequestOptionsBody.html#requestoptionsbodybodyelementreference-property">GeoBlazor Docs</a>
    ///     Implementation of parent property Body as ElementReference.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ElementReference? BodyElementReference { get; set; }

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.RequestOptionsBody.html#requestoptionsbodybodyobject-property">GeoBlazor Docs</a>
    ///     Implementation of parent property Body as Object.
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string?>? BodyFormData { get; set; }

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.RequestOptionsBody.html#requestoptionsbodybodystring-property">GeoBlazor Docs</a>
    ///     Implementation of parent property Body as String.
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BodyString { get; set; }

#endregion
}
