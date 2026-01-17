using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Text;
using System.Text.RegularExpressions;


namespace dymaptic.GeoBlazor.Core.SourceGenerator.Shared;

/// <summary>
///     Generates Protobuf definitions by invoking the ProtoGen project.
/// </summary>
public static class ProtobufDefinitionsGenerator
{
    public static Dictionary<string, ProtoMessageDefinition> UpdateProtobufDefinitions(SourceProductionContext context,
        ImmutableArray<BaseTypeDeclarationSyntax> types, string corePath)
    {
        ProcessHelper.Log(nameof(ProtobufDefinitionsGenerator),
            "Updating Protobuf definitions...",
            DiagnosticSeverity.Info,
            context);

        // fetch protobuf definitions
        var protoTypeContent = Generate(context, types);

        var typescriptContent = $"""
                                 export let protoTypeDefinitions: string = `
                                 {protoTypeContent}
                                 `;
                                 """;

        var encoded = escapeRegex.Replace(typescriptContent, match => match.Value switch
        {
            "\"" => "\\\"",
            "\r" => "\\r",
            "\n" => "\\n",
            _ => match.Value
        });
        StringBuilder logBuilder = new();

        var scriptPath = Path.Combine(corePath, "copyProtobuf.ps1");

        // write protobuf definitions to geoblazorProto.ts
        // must use GetAwaiter().GetResult(), since Source Generator is not Async
        ProcessHelper.RunPowerShellScript("Copy Protobuf Definitions",
                corePath, scriptPath,
                $"-Content \"{encoded}\"",
                logBuilder, context.CancellationToken)
            .GetAwaiter()
            .GetResult();

        ProcessHelper.Log(nameof(ProtobufDefinitionsGenerator),
            logBuilder.ToString(),
            DiagnosticSeverity.Info,
            context);

        ProcessHelper.Log(nameof(ProtobufDefinitionsGenerator),
            "Protobuf definitions updated successfully.",
            DiagnosticSeverity.Info,
            context);

        return _protoDefinitions ?? [];
    }

    private static string Generate(SourceProductionContext context,
        ImmutableArray<BaseTypeDeclarationSyntax> types)
    {
        try
        {
            ProcessHelper.Log(nameof(ProtobufDefinitionsGenerator),
                "Generating Protobuf schema",
                DiagnosticSeverity.Info,
                context);

            // Extract protobuf definitions from syntax nodes
            _protoDefinitions ??= ExtractProtobufDefinitions(types, context);

            ProcessHelper.Log(nameof(ProtobufDefinitionsGenerator),
                $"Extracted {_protoDefinitions.Count} Protobuf message definitions.",
                DiagnosticSeverity.Info,
                context);

            // Generate new proto file content
            var newProtoContent = GenerateProtoFileContent(_protoDefinitions);

            ProcessHelper.Log(nameof(ProtobufDefinitionsGenerator),
                "Protobuf schema generation complete",
                DiagnosticSeverity.Info,
                context);

            return newProtoContent;
        }
        catch (Exception ex)
        {
            ProcessHelper.Log(nameof(ProtobufDefinitionsGenerator),
                $"Error generating Protobuf definitions: {ex.Message}",
                DiagnosticSeverity.Error,
                context);

            return string.Empty;
        }
    }

    private static Dictionary<string, ProtoMessageDefinition> ExtractProtobufDefinitions(
        ImmutableArray<BaseTypeDeclarationSyntax> types, SourceProductionContext context)
    {
        var definitions = new Dictionary<string, ProtoMessageDefinition>();
        const string protoContractAttribute = "ProtoContract";

        foreach (var type in types)
        {
            if (type.AttributeLists.SelectMany(a => a.Attributes)
                .All(a => a.Name.ToString() != protoContractAttribute))
            {
                if (type.Identifier.Text.EndsWith("SerializationRecord")
                    && (type.Identifier.Text != "MapComponentSerializationRecord")
                    && (type.Identifier.Text != "MapComponentCollectionSerializationRecord"))
                {
                    ProcessHelper.Log(nameof(ProtobufDefinitionsGenerator),
                        $"Processing syntax node: {type.Identifier.Text
                        }, which is a SerializationRecord without ProtoContract attribute. Attributes: {
                            string.Join(", ",
                                type.AttributeLists.SelectMany(al => al.Attributes.SelectMany(a => a.ToString())))
                        }",
                        DiagnosticSeverity.Warning,
                        context);
                }

                continue;
            }

            try
            {
                var messageDef = ExtractMessageDefinition(type);

                if (messageDef != null)
                {
                    definitions[messageDef.Name] = messageDef;
                }
            }
            catch (Exception ex)
            {
                ProcessHelper.Log(nameof(ProtobufDefinitionsGenerator),
                    $"Error processing syntax node {type.Identifier.Text}: {ex.Message}",
                    DiagnosticSeverity.Warning,
                    context);
            }
        }

        return definitions;
    }

    private static ProtoMessageDefinition? ExtractMessageDefinition(BaseTypeDeclarationSyntax syntaxNode)
    {
        // Get ProtoContract attribute to find the message name
        var protoContractAttr = syntaxNode.AttributeLists
            .SelectMany(al => al.Attributes)
            .FirstOrDefault(a => a.Name.ToString().Contains("ProtoContract"));

        if (protoContractAttr == null)
        {
            return null;
        }

        // Extract the Name parameter from ProtoContract attribute
        var messageName = syntaxNode.Identifier.Text;

        var nameArg = protoContractAttr.ArgumentList?.Arguments
            .FirstOrDefault(arg => arg.NameEquals?.Name.Identifier.Text == "Name");

        if (nameArg is { Expression: LiteralExpressionSyntax literal })
        {
            messageName = literal.Token.ValueText;
        }

        var fields = new List<ProtoFieldDefinition>();
        var protoIncludeFields = new List<ProtoIncludeDefinition>();

        // Extract ProtoInclude attributes for oneof fields
        var protoIncludeAttrs = syntaxNode.AttributeLists
            .SelectMany(al => al.Attributes)
            .Where(a => a.Name.ToString().Contains("ProtoInclude"));

        var baseType = syntaxNode.BaseList?.Types.FirstOrDefault();
        var geoBlazorTypeIsInterface = false;

        if (!messageName.EndsWith("Collection") && baseType is not null)
        {
            var baseTypeName = baseType.Type.ToString();
            var innerTypeIndex = baseTypeName.IndexOf("<", StringComparison.OrdinalIgnoreCase) + 1;

            var geoBlazorTypeName =
                baseTypeName.Substring(innerTypeIndex, baseTypeName.Length - innerTypeIndex - 1);

            if ((geoBlazorTypeName[0] == 'I') && char.IsUpper(geoBlazorTypeName[1]))
            {
                geoBlazorTypeIsInterface = true;
            }
        }

        foreach (var includeAttr in protoIncludeAttrs)
        {
            if (includeAttr.ArgumentList?.Arguments.Count >= 2)
            {
                var tagArg = includeAttr.ArgumentList.Arguments[0].Expression;
                var typeArg = includeAttr.ArgumentList.Arguments[1].Expression;

                if (tagArg is LiteralExpressionSyntax tagLiteral &&
                    int.TryParse(tagLiteral.Token.ValueText, out var tag))
                {
                    var typeName = ExtractTypeFromExpression(typeArg);
                    protoIncludeFields.Add(new ProtoIncludeDefinition { Tag = tag, TypeName = typeName });
                }
            }
        }

        // Extract fields with ProtoMember attributes
        foreach (var member in syntaxNode.ChildNodes())
        {
            if (member is PropertyDeclarationSyntax property)
            {
                var protoMemberAttr = property.AttributeLists
                    .SelectMany(al => al.Attributes)
                    .FirstOrDefault(a => a.Name.ToString().Contains("ProtoMember"));

                if (protoMemberAttr is { ArgumentList.Arguments.Count: > 0 })
                {
                    var fieldNumber = protoMemberAttr.ArgumentList.Arguments[0].Expression;

                    if (fieldNumber is LiteralExpressionSyntax fieldNumLiteral &&
                        int.TryParse(fieldNumLiteral.Token.ValueText, out var num))
                    {
                        var fieldType = ConvertCSharpTypeToProtoType(property.Type.ToString());

                        fields.Add(new ProtoFieldDefinition
                        {
                            Type = fieldType, Name = property.Identifier.Text.ToLowerFirstChar(), Number = num
                        });
                    }
                }
            }
        }

        return new ProtoMessageDefinition
        {
            Name = messageName,
            Fields = fields.OrderBy(f => f.Number).ToList(),
            ProtoIncludes = protoIncludeFields.OrderBy(p => p.Tag).ToList(),
            GeoBlazorTypeIsInterface = geoBlazorTypeIsInterface
        };
    }

    private static string ExtractTypeFromExpression(ExpressionSyntax expression)
    {
        // Handle typeof(TypeName) expression
        if (expression is TypeOfExpressionSyntax typeOfExpr)
        {
            return typeOfExpr.Type.ToString();
        }

        return expression.ToString();
    }

    private static string ConvertCSharpTypeToProtoType(string csharpType)
    {
        // Check if it's an array type (need repeated keyword)
        var isRepeated = (csharpType.Contains("[]") && (csharpType != "byte[]") && (csharpType != "byte[]?"))
            || csharpType.Contains("IEnumerable")
            || csharpType.Contains("List<");

        // Remove nullable markers and array indicators
        var cleanType = csharpType.Replace("?", "").Trim();

        if (isRepeated)
        {
            cleanType = cleanType.Replace("[]", "")
                .Replace("IEnumerable<", "")
                .Replace("IList<", "")
                .Replace("List<", "")
                .Replace(">", "")
                .Trim();
        }

        // Map C# types to proto types
        var protoType = cleanType switch
        {
            "string" => "string",
            "int" => "int32",
            "long" => "int64",
            "double" => "double",
            "float" => "float",
            "bool" => "bool",
            "byte[]" => "bytes",
            _ when cleanType.Contains("SerializationRecord") => cleanType.Replace("SerializationRecord", ""),
            _ => cleanType
        };

        return isRepeated ? $"repeated {protoType}" : protoType;
    }

    private static string GenerateProtoFileContent(Dictionary<string, ProtoMessageDefinition> definitions)
    {
        var sb = new StringBuilder();

        // Header
        sb.AppendLine("syntax = \"proto3\";");
        sb.AppendLine("package dymaptic.GeoBlazor.Core.Serialization;");
        sb.AppendLine("import \"google/protobuf/empty.proto\";");
        sb.AppendLine();

        // First, generate regular message definitions (those without ProtoIncludes or with both fields and includes)
        foreach (var def in definitions.Values.OrderBy(d => d.Name))
        {
            if ((def.Name == "MapComponent") || (def.Name == "MapComponentCollection"))
            {
                continue; // Handle these special cases separately
            }

            sb.AppendLine($"message {def.Name} {{");

            // Generate regular fields
            foreach (var field in def.Fields)
            {
                sb.AppendLine($"   {field.Type} {field.Name} = {field.Number};");
            }

            sb.AppendLine("}");
        }

        // Generate MapComponent with oneof for all the serialization records
        if (definitions.TryGetValue("MapComponent", out var mapComponentDef) && mapComponentDef.ProtoIncludes.Any())
        {
            sb.AppendLine("message MapComponent {");
            sb.AppendLine("   oneof subtype {");

            foreach (var include in mapComponentDef.ProtoIncludes)
            {
                var typeName = include.TypeName.Replace("SerializationRecord", "");
                sb.AppendLine($"      {typeName} {typeName} = {include.Tag};");
            }

            sb.AppendLine("   }");
            sb.AppendLine("}");
        }

        // Generate MapComponentCollection with oneof for all the collection types
        if (definitions.TryGetValue("MapComponentCollection", out var collectionDef) &&
            collectionDef.ProtoIncludes.Any())
        {
            sb.AppendLine("message MapComponentCollection {");
            sb.AppendLine("   oneof subtype {");

            foreach (var include in collectionDef.ProtoIncludes)
            {
                var typeName = include.TypeName.Replace("SerializationRecord", "");
                sb.AppendLine($"      {typeName} {typeName} = {include.Tag};");
            }

            sb.AppendLine("   }");
            sb.AppendLine("}");
        }

        return sb.ToString();
    }

    private static readonly Regex escapeRegex = new(@"[""\r\n]", RegexOptions.Compiled);
    private static Dictionary<string, ProtoMessageDefinition>? _protoDefinitions;
}

/// <summary>
///     Represents a Protobuf message definition extracted from a C# type with ProtoContract attribute.
/// </summary>
public class ProtoMessageDefinition
{
    /// <summary>
    ///     The name of the Protobuf message, derived from the ProtoContract Name parameter or the type identifier.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     The list of fields in this message, extracted from properties with ProtoMember attributes.
    /// </summary>
    public List<ProtoFieldDefinition> Fields { get; set; } = new();

    /// <summary>
    ///     The list of ProtoInclude definitions for polymorphic serialization (oneof fields).
    /// </summary>
    public List<ProtoIncludeDefinition> ProtoIncludes { get; set; } = new();

    /// <summary>
    ///     Indicates whether the corresponding GeoBlazor type is an interface.
    /// </summary>
    public bool GeoBlazorTypeIsInterface { get; set; }
}

/// <summary>
///     Represents a field within a Protobuf message definition.
/// </summary>
public class ProtoFieldDefinition
{
    /// <summary>
    ///     The Protobuf type of the field (e.g., "string", "int32", "repeated Message").
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    ///     The name of the field in camelCase format.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     The field number from the ProtoMember attribute, used for wire format encoding.
    /// </summary>
    public int Number { get; set; }
}

/// <summary>
///     Represents a ProtoInclude attribute definition for polymorphic type hierarchies.
/// </summary>
public class ProtoIncludeDefinition
{
    /// <summary>
    ///     The tag number used to identify this subtype in the Protobuf oneof field.
    /// </summary>
    public int Tag { get; set; }

    /// <summary>
    ///     The name of the included subtype.
    /// </summary>
    public string TypeName { get; set; } = string.Empty;
}