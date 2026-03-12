namespace dymaptic.GeoBlazor.Core.Model;

[JsonConverter(typeof(UnionConverter<FormElementOrData>))]
public record FormElementOrData
{
    /// <summary>
    ///     Parameterless constructor
    /// </summary>
    public FormElementOrData()
    {
    }

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="htmlFormElement">
    ///     Reference to an <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Elements/form">HTMLFormElement</a> defined in markup
    /// </param>
    /// <param name="formData">
    ///     A Key/Value collection representing a <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/FormData">FormData</a>.
    /// </param>
    public FormElementOrData(ElementReference? htmlFormElement = null, Dictionary<string, string?>? formData = null)
    {
        HtmlFormElement = htmlFormElement;
        FormData = formData;
    }

    /// <summary>
    ///     Implicit conversion from HtmlFormElement to FormElementOrData
    /// </summary>
    public static implicit operator FormElementOrData(ElementReference htmlFormElement) => 
        new FormElementOrData(htmlFormElement);

    /// <summary>
    ///     Implicit conversion from HtmlFormElement to FormElementOrData
    /// </summary>
    public static implicit operator FormElementOrData(Dictionary<string, string?> formData) =>
        new FormElementOrData(formData: formData);

    /// <summary>
    ///     Reference to an <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Elements/form">HTMLFormElement</a> defined in markup
    /// </summary>
    public ElementReference? HtmlFormElement { get; set; }

    /// <summary>
    ///     A Key/Value collection representing a <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/FormData">FormData</a>.
    /// </summary>
    public Dictionary<string, string?>? FormData { get; set; }
}
