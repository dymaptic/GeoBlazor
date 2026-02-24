namespace dymaptic.GeoBlazor.Core.Serialization;

internal class SizeVariableConverter : JsonConverter<SizeVariable>
{
    public override SizeVariable? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // manually loop through the reader
        // required because of the "MinSize" and "MaxSize" properties which can be either Dimension or SizeVariable
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            SizeVariable sizeVariable = new();
            string? currentPropertyName = null;
#pragma warning disable BL0005
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        currentPropertyName = reader.GetString()?.ToUpperFirstChar();

                        break;
                    case JsonTokenType.EndObject:
                        return sizeVariable;
                    default:
                        switch (currentPropertyName)
                        {
                            case nameof(SizeVariable.Field):
                                sizeVariable.Field = reader.GetString();

                                break;
                            case nameof(SizeVariable.MinSize):
                                var (minDimension, minSizeVariable) =
                                    GetDimensionOrSizeVariable(ref reader, options);

                                if (minDimension is not null)
                                {
                                    sizeVariable.MinSize = minDimension;
                                }

                                if (minSizeVariable is not null)
                                {
                                    sizeVariable.MinSize = minSizeVariable.MinSize;
                                }

                                break;
                            case nameof(SizeVariable.MaxSize):
                                var (maxDimension, maxSizeVariable) =
                                    GetDimensionOrSizeVariable(ref reader, options);

                                if (maxDimension is not null)
                                {
                                    sizeVariable.MaxSize = maxDimension;
                                }

                                if (maxSizeVariable is not null)
                                {
                                    sizeVariable.MaxSize = maxSizeVariable.MaxSize;
                                }

                                break;
                            case nameof(SizeVariable.MinDataValue):
                                if (reader.TokenType == JsonTokenType.Number)
                                {
                                    sizeVariable.MinDataValue = reader.GetDouble();
                                }

                                break;
                            case nameof(SizeVariable.MaxDataValue):
                                if (reader.TokenType == JsonTokenType.Number)
                                {
                                    sizeVariable.MaxDataValue = reader.GetDouble();
                                }

                                break;
                            case nameof(SizeVariable.ValueRepresentation):
                                sizeVariable.ValueRepresentation =
                                    JsonSerializer.Deserialize<VisualValueRepresentation>(ref reader, options);

                                break;
                            case nameof(SizeVariable.ValueUnit):
                                sizeVariable.ValueUnit =
                                    JsonSerializer.Deserialize<VisualValueUnit>(ref reader, options);

                                break;
                            case nameof(SizeVariable.NormalizationField):
                                sizeVariable.NormalizationField = reader.GetString();

                                break;
                            case nameof(SizeVariable.Target):
                                sizeVariable.Target = reader.GetString();

                                break;
                            case nameof(SizeVariable.UseSymbolValue):
                                if (reader.TokenType != JsonTokenType.Null)
                                {
                                    sizeVariable.UseSymbolValue = reader.GetBoolean();
                                }

                                break;
                            case nameof(SizeVariable.Axis):
                                sizeVariable.Axis =
                                    JsonSerializer.Deserialize<VisualAxis>(ref reader, options);

                                break;
                            case nameof(SizeVariable.ValueExpression):
                                sizeVariable.ValueExpression = reader.GetString();

                                break;
                            case nameof(SizeVariable.ValueExpressionTitle):
                                sizeVariable.ValueExpressionTitle = reader.GetString();

                                break;
                            case nameof(SizeVariable.LegendOptions):
                                sizeVariable.LegendOptions = JsonSerializer
                                    .Deserialize<VisualVariableLegendOptions>(ref reader, options);

                                break;
                            case nameof(SizeVariable.Stops):
                                sizeVariable.Stops = JsonSerializer
                                    .Deserialize<List<SizeStop>>(ref reader, options);

                                break;
                        }

                        break;
                }
            }

            return sizeVariable;
        }
#pragma warning restore BL0005
        return null;
    }

    public override void Write(Utf8JsonWriter writer, SizeVariable value, JsonSerializerOptions options)
    {
        PropertyInfo[] props = value.GetPropertyInfos()
            .Where(p => p.SetMethod is not null 
                && !_excludedProperties.Contains(p.Name))
            .ToArray();

        writer.WriteStartObject();

        // type does not have a Getter, so it is not included in GetPropertyInfos
        writer.WritePropertyName("type");
        writer.WriteStringValue("size");

        foreach (PropertyInfo prop in props)
        {
            JsonIgnoreAttribute? ignoreAttribute = prop.GetCustomAttribute<JsonIgnoreAttribute>();

            if (ignoreAttribute is not null && ignoreAttribute.Condition == JsonIgnoreCondition.WhenWritingNull)
            {
                continue;
            }

            object? propValue = prop.GetValue(value);

            if (ignoreAttribute is not null && propValue is null
                && ignoreAttribute.Condition == JsonIgnoreCondition.WhenWritingNull)
            {
                continue;
            }

            if (prop.Name == nameof(SizeVariable.MinSizeVariable) || prop.Name == nameof(SizeVariable.MaxSizeVariable))
            {
                writer.WritePropertyName(prop.Name.Replace("Variable", "").ToLowerFirstChar());
            }
            else
            {
                writer.WritePropertyName(prop.Name.ToLowerFirstChar());
            }

            writer.WriteRawValue(JsonSerializer.Serialize(propValue, typeof(object),
                GeoBlazorSerialization.JsonSerializerOptions));
        }

        writer.WriteEndObject();
    }

    private (Dimension? dimension, SizeVariable? sizeVariable) GetDimensionOrSizeVariable(ref Utf8JsonReader reader,
        JsonSerializerOptions options)
    {
        Dimension? dimension = null;
        SizeVariable? sizeVariable = null;

        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                var stringVal = reader.GetString();

                if (stringVal is not null)
                {
                    dimension = new Dimension(stringVal);
                }

                break;
            case JsonTokenType.Number:
                var doubleVal = reader.GetDouble();
                dimension = new Dimension(doubleVal);

                break;
            case JsonTokenType.StartObject:
                try
                {
                    sizeVariable = JsonSerializer.Deserialize<SizeVariable>(ref reader, options);
                }
                catch
                {
                    dimension = JsonSerializer.Deserialize<Dimension>(ref reader, options);
                }

                break;
        }

        return (dimension, sizeVariable);
    }
    
    private string[] _excludedProperties = 
        [
            nameof(MapComponent.Parent),
            nameof(MapComponent.View),
            nameof(MapComponent.Layer)
        ];
}