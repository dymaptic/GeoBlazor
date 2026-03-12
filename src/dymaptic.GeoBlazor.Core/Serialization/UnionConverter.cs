using System.Text.Unicode;

namespace dymaptic.GeoBlazor.Core.Serialization;

internal class UnionConverter<T> : JsonConverter<T>
{
    static UnionConverter()
    {
        allTypes = Assembly.Load("dymaptic.GeoBlazor.Core").GetTypes();

        try
        {
            allTypes = allTypes
                .Concat(Assembly.Load("dymaptic.GeoBlazor.Pro").GetTypes())
                .ToArray();
        }
        catch (Exception)
        {
            // ignored, Pro is not available
        }
    }
    
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        PropertyInfo[] propertyInfos = typeToConvert.GetProperties();
        T instance = (T)Activator.CreateInstance(typeToConvert)!;
        Utf8JsonReader cloneReader = reader;
        bool inCollection = false;
        List<object?>? collectionVal = null;
        PropertyInfo? collectionProp = null;
        T? objectResult = default;

        while (reader.Read())
        {
            if (objectResult is not null)
            {
                continue;
            }
            
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    string? stringVal = reader.GetString();
                    if (inCollection)
                    {
                        PropertyInfo? stringCollectionProp = propertyInfos.FirstOrDefault(pi => 
                            (pi.PropertyType.IsGenericType && pi.PropertyType.GenericTypeArguments[0] == typeof(string))
                            || pi.PropertyType.IsArray && pi.PropertyType.GetElementType() == typeof(string));
                        if (stringCollectionProp is not null)
                        {
                            collectionVal!.Add(stringVal);
                            collectionProp = stringCollectionProp;
                        }
                    }
                    else
                    {
                        PropertyInfo? stringProp = propertyInfos.FirstOrDefault(pi => pi.PropertyType == typeof(string));
                        if (stringProp is not null)
                        {
                            stringProp.SetValue(instance, stringVal);
                            // value set, return
                            return instance;
                        }
                    }

                    break;
                case JsonTokenType.Number:
                    if (inCollection)
                    {
                        PropertyInfo? doubleCollectionProp = propertyInfos.FirstOrDefault(pi => 
                            (pi.PropertyType.IsGenericType && pi.PropertyType.GenericTypeArguments[0] == typeof(double))
                            || pi.PropertyType.IsArray && pi.PropertyType.GetElementType() == typeof(double));
                        if (doubleCollectionProp is not null)
                        {
                            double doubleCollectionVal = reader.GetDouble();
                            collectionVal!.Add(doubleCollectionVal);
                            collectionProp = doubleCollectionProp;
                        }
                        else
                        {
                            int intCollectionVal = reader.GetInt32();
                            PropertyInfo? intCollectionProp = propertyInfos.FirstOrDefault(pi => 
                            (pi.PropertyType.IsGenericType && pi.PropertyType.GenericTypeArguments[0] == typeof(int))
                            || pi.PropertyType.IsArray && pi.PropertyType.GetElementType() == typeof(int));
                            if (intCollectionProp is not null)
                            {
                                collectionVal!.Add(intCollectionVal);
                                collectionProp = intCollectionProp;
                            }
                        }
                    }
                    else
                    {
                        PropertyInfo? doubleProp = propertyInfos.FirstOrDefault(pi => pi.PropertyType == typeof(double));
                        if (doubleProp is not null)
                        {
                            double doubleVal = reader.GetDouble();
                            doubleProp.SetValue(instance, doubleVal);
                            // value set, return
                            return instance;
                        }
                        else
                        {
                            int intVal = reader.GetInt32();
                            PropertyInfo? intProp = propertyInfos.FirstOrDefault(pi => pi.PropertyType == typeof(int));
                            if (intProp is not null)
                            {
                                intProp.SetValue(instance, intVal);
                                // value set, return
                                return instance;
                            }
                        }
                    }

                    break;
                case JsonTokenType.True:
                case JsonTokenType.False:
                    bool boolVal = reader.GetBoolean();
                    if (inCollection)
                    {
                        PropertyInfo? boolCollectionProp = propertyInfos.FirstOrDefault(pi => 
                            (pi.PropertyType.IsGenericType && pi.PropertyType.GenericTypeArguments[0] == typeof(bool))
                            || pi.PropertyType.IsArray && pi.PropertyType.GetElementType() == typeof(bool));
                        if (boolCollectionProp is not null)
                        {
                            collectionVal!.Add(boolVal);
                            collectionProp = boolCollectionProp;
                        }
                    }
                    else
                    {
                        PropertyInfo? boolProp = propertyInfos.FirstOrDefault(pi => pi.PropertyType == typeof(bool));
                        if (boolProp is not null)
                        {
                            boolProp.SetValue(instance, boolVal);
                            // value set, return
                            return instance;
                        }
                    }

                    break;
                case JsonTokenType.StartArray:
                    inCollection = true;
                    collectionVal = new();
                
                    break;
                case JsonTokenType.StartObject:
                    objectResult = HandleObject(cloneReader, typeToConvert, options, propertyInfos);

                    break;
            }

        }

        if (objectResult is not null)
        {
            return objectResult;
        }

        if (collectionVal is not null && collectionProp is not null)
        {
            collectionProp.SetValue(instance, collectionVal);
            return instance;
        }

        // no properties were set
        return default(T?);
    }

    private T? HandleObject(Utf8JsonReader cloneReader, Type typeToConvert, 
        JsonSerializerOptions options, PropertyInfo[] propertyInfos)
    {


        Type[] propGeoBlazorTypes = allTypes
            .Where(t => t == typeToConvert || propertyInfos.Any(pi => pi.PropertyType == t))
            .ToArray();

        if (propGeoBlazorTypes.Length == 0)
        {
            return default;
        }
        if (propGeoBlazorTypes.Length == 1)
        {
            // Deserialize using the found type
            return (T?)JsonSerializer.Deserialize(ref cloneReader, propGeoBlazorTypes[0], options);
        }
        
        // find the closest match based on the properties
        Dictionary<string, object>? properties = JsonSerializer.Deserialize<Dictionary<string, object>>(ref cloneReader, options);

        if (properties is null || properties.Count == 0)
        {
            // No properties found, return null
            return default;
        }

        if (properties.TryGetValue("type", out object? typeSerializedValue))
        {
            string typeString = typeSerializedValue.ToString()!;
            foreach (Type t in propGeoBlazorTypes)
            {
                if (t.GetProperty("Type") is { SetMethod: null } typeProp)
                {
                    string? typeVal = typeProp.GetValue(Activator.CreateInstance(t)) as string;

                    if (typeVal == typeString || typeVal?.ToKebabCase() == typeString)
                    {
                        return (T?)JsonSerializer.Deserialize(ref cloneReader, t, options);
                    }
                }
            }
                
        }
        
        var bestMatch = propGeoBlazorTypes
            .Select(t => new
            {
                Type = t,
                MatchCount = t.GetProperties().Count(p => properties.ContainsKey(p.Name.ToLowerFirstChar()))
            })
            .OrderByDescending(m => m.MatchCount)
            .FirstOrDefault();
        
        if (bestMatch?.MatchCount > 0)
        {
            // Deserialize using the closest type
            return (T?)JsonSerializer.Deserialize(ref cloneReader, bestMatch.Type, options);
        }

        // Return null if the type is not available
        return default;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (PropertyInfo prop in propertyInfos)
        {
            if (prop.GetValue(value) is { } propVal)
            {
                writer.WriteRawValue(JsonSerializer.Serialize(propVal, prop.PropertyType, GeoBlazorSerialization.JsonSerializerOptions));
                return;
            }
        }

        // if no properties were set, write null
        writer.WriteNullValue();
    }
    
    // ReSharper disable once StaticMemberInGenericType
    private static readonly Type[] allTypes;
}