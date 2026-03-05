namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Custom conversion of <see cref="ElementReference" /> to and from JSON, necessary to support elements defined in
///     ArcGIS JavaScript
/// </summary>
/// <param name="elementReferenceContext">
///     The context in which the element reference is being used.
/// </param>
internal class ElementReferenceConverter(ElementReferenceContext? elementReferenceContext)
    : JsonConverter<ElementReference>
{
    public ElementReferenceConverter(): this(null)
    {
    }
    
    public override ElementReference Read(ref Utf8JsonReader reader, Type typeToConvert, 
        JsonSerializerOptions options)
    {
        string? id = null;

        while (reader.Read() && (reader.TokenType != JsonTokenType.EndObject))
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                if (reader.ValueTextEquals(idProperty.EncodedUtf8Bytes))
                {
                    reader.Read();
                    id = reader.GetString();
                }
                else if (reader.ValueTextEquals(blazorIdProperty.EncodedUtf8Bytes))
                {
                    reader.Read();
                    id = reader.GetString();
                }
                else
                {
                    throw new JsonException($"Unexpected JSON property '{reader.GetString()}'.");
                }
            }
            else
            {
                throw new JsonException($"Unexpected JSON Token {reader.TokenType}.");
            }
        }

        if (id is null)
        {
            throw new JsonException("gb_element_ref_id is required.");
        }

        ElementReferenceConverter registeredConverter = (ElementReferenceConverter)options.GetConverter(typeToConvert);
        
        return new ElementReference(id, registeredConverter.ElementReferenceContext);
    }

    public override void Write(Utf8JsonWriter writer, ElementReference value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString(idProperty, value.Id);
        // write both our ID and Blazor's ID, so either "reviver" can restore the element in JS
        writer.WriteString(blazorIdProperty, value.Id);
        writer.WriteEndObject();
    }

    private ElementReferenceContext? ElementReferenceContext { get; } = elementReferenceContext;
    private static readonly JsonEncodedText idProperty = JsonEncodedText.Encode("gb_element_ref_id");
    private static readonly JsonEncodedText blazorIdProperty = JsonEncodedText.Encode("__internalId");
}