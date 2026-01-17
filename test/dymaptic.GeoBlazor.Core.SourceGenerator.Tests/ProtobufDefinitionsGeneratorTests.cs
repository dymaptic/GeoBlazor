using dymaptic.GeoBlazor.Core.SourceGenerator.Shared;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection;


namespace dymaptic.GeoBlazor.Core.SourceGenerator.Tests;

/// <summary>
///     Tests for the ProtobufDefinitionsGenerator class which extracts and generates
///     Protobuf schema definitions from C# types marked with ProtoContract attributes.
/// </summary>
/// <remarks>
///     These tests use reflection to test the private extraction methods directly,
///     bypassing the SourceProductionContext dependency which cannot be properly
///     initialized outside the Roslyn infrastructure.
/// </remarks>
[TestClass]
public class ProtobufDefinitionsGeneratorTests
{
    /// <summary>
    ///     Tests that a simple type with ProtoContract and ProtoMember attributes
    ///     is correctly extracted into a ProtoMessageDefinition.
    /// </summary>
    [TestMethod]
    public void ExtractMessageDefinition_ExtractsSimpleProtoMessage()
    {
        // Arrange
        var source = """
                     using ProtoBuf;

                     namespace Test;

                     [ProtoContract(Name = "SimpleMessage")]
                     public record SimpleSerializationRecord
                     {
                         [ProtoMember(1)]
                         public string? Name { get; init; }

                         [ProtoMember(2)]
                         public int Value { get; init; }
                     }
                     """;

        var type = ParseSingleTypeFromSource(source, "SimpleSerializationRecord");

        // Act
        var messageDef = ExtractMessageDefinition(type);

        // Assert
        Assert.IsNotNull(messageDef, "Expected a message definition to be extracted.");
        Assert.AreEqual("SimpleMessage", messageDef.Name);
        Assert.HasCount(2, messageDef.Fields);

        var nameField = messageDef.Fields.First(f => f.Name == "name");
        Assert.AreEqual("string", nameField.Type);
        Assert.AreEqual(1, nameField.Number);

        var valueField = messageDef.Fields.First(f => f.Name == "value");
        Assert.AreEqual("int32", valueField.Type);
        Assert.AreEqual(2, valueField.Number);
    }

    /// <summary>
    ///     Tests that types without ProtoContract attribute return null.
    /// </summary>
    [TestMethod]
    public void ExtractMessageDefinition_ReturnsNullForTypesWithoutProtoContract()
    {
        // Arrange
        var source = """
                     namespace Test;

                     public record NonProtoRecord
                     {
                         public string? Name { get; init; }
                     }
                     """;

        var type = ParseSingleTypeFromSource(source, "NonProtoRecord");

        // Act
        var messageDef = ExtractMessageDefinition(type);

        // Assert
        Assert.IsNull(messageDef,
            "Expected null for types without ProtoContract attribute.");
    }

    /// <summary>
    ///     Tests that various C# types are correctly converted to Protobuf types.
    /// </summary>
    [TestMethod]
    public void ConvertCSharpTypeToProtoType_ConvertsBasicTypesCorrectly()
    {
        // Assert basic type conversions
        Assert.AreEqual("string", ConvertCSharpTypeToProtoType("string"));
        Assert.AreEqual("string", ConvertCSharpTypeToProtoType("string?"));
        Assert.AreEqual("int32", ConvertCSharpTypeToProtoType("int"));
        Assert.AreEqual("int32", ConvertCSharpTypeToProtoType("int?"));
        Assert.AreEqual("int64", ConvertCSharpTypeToProtoType("long"));
        Assert.AreEqual("int64", ConvertCSharpTypeToProtoType("long?"));
        Assert.AreEqual("double", ConvertCSharpTypeToProtoType("double"));
        Assert.AreEqual("double", ConvertCSharpTypeToProtoType("double?"));
        Assert.AreEqual("float", ConvertCSharpTypeToProtoType("float"));
        Assert.AreEqual("float", ConvertCSharpTypeToProtoType("float?"));
        Assert.AreEqual("bool", ConvertCSharpTypeToProtoType("bool"));
        Assert.AreEqual("bool", ConvertCSharpTypeToProtoType("bool?"));
        Assert.AreEqual("bytes", ConvertCSharpTypeToProtoType("byte[]"));
        Assert.AreEqual("bytes", ConvertCSharpTypeToProtoType("byte[]?"));
    }

    /// <summary>
    ///     Tests that collection types are converted to repeated fields.
    /// </summary>
    [TestMethod]
    public void ConvertCSharpTypeToProtoType_ConvertsCollectionsToRepeated()
    {
        // Assert collection type conversions
        Assert.AreEqual("repeated string", ConvertCSharpTypeToProtoType("string[]"));
        Assert.AreEqual("repeated int32", ConvertCSharpTypeToProtoType("int[]"));
        Assert.AreEqual("repeated string", ConvertCSharpTypeToProtoType("List<string>"));
        Assert.AreEqual("repeated int32", ConvertCSharpTypeToProtoType("List<int>"));
        Assert.AreEqual("repeated string", ConvertCSharpTypeToProtoType("IEnumerable<string>"));
        Assert.AreEqual("repeated int32", ConvertCSharpTypeToProtoType("IList<int>"));
    }

    /// <summary>
    ///     Tests that SerializationRecord suffix is removed from type references.
    /// </summary>
    [TestMethod]
    public void ConvertCSharpTypeToProtoType_RemovesSerializationRecordSuffix()
    {
        // Assert SerializationRecord suffix handling
        Assert.AreEqual("Child", ConvertCSharpTypeToProtoType("ChildSerializationRecord"));
        Assert.AreEqual("repeated Child", ConvertCSharpTypeToProtoType("ChildSerializationRecord[]"));
        Assert.AreEqual("repeated Child", ConvertCSharpTypeToProtoType("List<ChildSerializationRecord>"));
    }

    /// <summary>
    ///     Tests that ProtoInclude attributes are correctly extracted for polymorphic types.
    /// </summary>
    [TestMethod]
    public void ExtractMessageDefinition_ExtractsProtoIncludes()
    {
        // Arrange
        var source = """
                     using ProtoBuf;

                     namespace Test;

                     [ProtoContract(Name = "BaseType")]
                     [ProtoInclude(100, typeof(DerivedOneSerializationRecord))]
                     [ProtoInclude(101, typeof(DerivedTwoSerializationRecord))]
                     public record BaseTypeSerializationRecord
                     {
                         [ProtoMember(1)]
                         public string? CommonField { get; init; }
                     }

                     [ProtoContract(Name = "DerivedOne")]
                     public record DerivedOneSerializationRecord : BaseTypeSerializationRecord
                     {
                         [ProtoMember(2)]
                         public int SpecificField { get; init; }
                     }

                     [ProtoContract(Name = "DerivedTwo")]
                     public record DerivedTwoSerializationRecord : BaseTypeSerializationRecord
                     {
                         [ProtoMember(3)]
                         public double OtherField { get; init; }
                     }
                     """;

        var type = ParseSingleTypeFromSource(source, "BaseTypeSerializationRecord");

        // Act
        var messageDef = ExtractMessageDefinition(type);

        // Assert
        Assert.IsNotNull(messageDef);
        Assert.AreEqual("BaseType", messageDef.Name);

        Assert.HasCount(2, messageDef.ProtoIncludes,
            "Expected 2 ProtoInclude entries.");

        var include100 = messageDef.ProtoIncludes.First(p => p.Tag == 100);
        Assert.AreEqual("DerivedOneSerializationRecord", include100.TypeName);

        var include101 = messageDef.ProtoIncludes.First(p => p.Tag == 101);
        Assert.AreEqual("DerivedTwoSerializationRecord", include101.TypeName);
    }

    /// <summary>
    ///     Tests that the message name is extracted from the ProtoContract Name parameter.
    /// </summary>
    [TestMethod]
    public void ExtractMessageDefinition_UsesProtoContractNameParameter()
    {
        // Arrange
        var source = """
                     using ProtoBuf;

                     namespace Test;

                     [ProtoContract(Name = "CustomMessageName")]
                     public record SomeSerializationRecord
                     {
                         [ProtoMember(1)]
                         public string? Field { get; init; }
                     }
                     """;

        var type = ParseSingleTypeFromSource(source, "SomeSerializationRecord");

        // Act
        var messageDef = ExtractMessageDefinition(type);

        // Assert
        Assert.IsNotNull(messageDef);

        Assert.AreEqual("CustomMessageName", messageDef.Name,
            "Expected message to use name from ProtoContract attribute.");
    }

    /// <summary>
    ///     Tests that fields are ordered by their ProtoMember field number.
    /// </summary>
    [TestMethod]
    public void ExtractMessageDefinition_OrdersFieldsByNumber()
    {
        // Arrange
        var source = """
                     using ProtoBuf;

                     namespace Test;

                     [ProtoContract(Name = "OrderedFields")]
                     public record OrderedFieldsSerializationRecord
                     {
                         [ProtoMember(3)]
                         public string? Third { get; init; }

                         [ProtoMember(1)]
                         public string? First { get; init; }

                         [ProtoMember(2)]
                         public string? Second { get; init; }
                     }
                     """;

        var type = ParseSingleTypeFromSource(source, "OrderedFieldsSerializationRecord");

        // Act
        var messageDef = ExtractMessageDefinition(type);

        // Assert
        Assert.IsNotNull(messageDef);
        Assert.HasCount(3, messageDef.Fields);
        Assert.AreEqual(1, messageDef.Fields[0].Number);
        Assert.AreEqual("first", messageDef.Fields[0].Name);
        Assert.AreEqual(2, messageDef.Fields[1].Number);
        Assert.AreEqual("second", messageDef.Fields[1].Name);
        Assert.AreEqual(3, messageDef.Fields[2].Number);
        Assert.AreEqual("third", messageDef.Fields[2].Name);
    }

    /// <summary>
    ///     Tests that properties without ProtoMember attribute are skipped.
    /// </summary>
    [TestMethod]
    public void ExtractMessageDefinition_SkipsPropertiesWithoutProtoMember()
    {
        // Arrange
        var source = """
                     using ProtoBuf;

                     namespace Test;

                     [ProtoContract(Name = "PartialMessage")]
                     public record PartialSerializationRecord
                     {
                         [ProtoMember(1)]
                         public string? IncludedField { get; init; }

                         public string? ExcludedField { get; init; }
                     }
                     """;

        var type = ParseSingleTypeFromSource(source, "PartialSerializationRecord");

        // Act
        var messageDef = ExtractMessageDefinition(type);

        // Assert
        Assert.IsNotNull(messageDef);

        Assert.HasCount(1, messageDef.Fields,
            "Expected only the field with ProtoMember attribute to be included.");
        Assert.AreEqual("includedField", messageDef.Fields[0].Name);
    }

    /// <summary>
    ///     Tests that nullable types are handled correctly (nullable marker removed).
    /// </summary>
    [TestMethod]
    public void ExtractMessageDefinition_HandlesNullableTypes()
    {
        // Arrange
        var source = """
                     using ProtoBuf;

                     namespace Test;

                     [ProtoContract(Name = "NullableTypes")]
                     public record NullableTypesSerializationRecord
                     {
                         [ProtoMember(1)]
                         public string? NullableString { get; init; }

                         [ProtoMember(2)]
                         public int? NullableInt { get; init; }

                         [ProtoMember(3)]
                         public double? NullableDouble { get; init; }
                     }
                     """;

        var type = ParseSingleTypeFromSource(source, "NullableTypesSerializationRecord");

        // Act
        var messageDef = ExtractMessageDefinition(type);

        // Assert
        Assert.IsNotNull(messageDef);

        // Nullable markers should be stripped from the protobuf type
        AssertFieldType(messageDef, "nullableString", "string");
        AssertFieldType(messageDef, "nullableInt", "int32");
        AssertFieldType(messageDef, "nullableDouble", "double");
    }

    /// <summary>
    ///     Tests that SerializationRecord suffix is handled correctly for nested types.
    /// </summary>
    [TestMethod]
    public void ExtractMessageDefinition_HandlesSerializationRecordReferences()
    {
        // Arrange
        var source = """
                     using ProtoBuf;

                     namespace Test;

                     [ProtoContract(Name = "Parent")]
                     public record ParentSerializationRecord
                     {
                         [ProtoMember(1)]
                         public ChildSerializationRecord? Child { get; init; }
                     }

                     [ProtoContract(Name = "Child")]
                     public record ChildSerializationRecord
                     {
                         [ProtoMember(1)]
                         public string? Name { get; init; }
                     }
                     """;

        var type = ParseSingleTypeFromSource(source, "ParentSerializationRecord");

        // Act
        var messageDef = ExtractMessageDefinition(type);

        // Assert
        Assert.IsNotNull(messageDef);

        // The type should have SerializationRecord suffix removed
        var childField = messageDef.Fields.First(f => f.Name == "child");

        Assert.AreEqual("Child", childField.Type,
            "Expected 'SerializationRecord' suffix to be removed from the type reference.");
    }

    /// <summary>
    ///     Tests that IEnumerable collections are converted to repeated fields.
    /// </summary>
    [TestMethod]
    public void ExtractMessageDefinition_HandlesIEnumerableAsRepeated()
    {
        // Arrange
        var source = """
                     using ProtoBuf;
                     using System.Collections.Generic;

                     namespace Test;

                     [ProtoContract(Name = "EnumerableTest")]
                     public record EnumerableSerializationRecord
                     {
                         [ProtoMember(1)]
                         public IEnumerable<string>? StringItems { get; init; }

                         [ProtoMember(2)]
                         public IList<int>? IntItems { get; init; }
                     }
                     """;

        var type = ParseSingleTypeFromSource(source, "EnumerableSerializationRecord");

        // Act
        var messageDef = ExtractMessageDefinition(type);

        // Assert
        Assert.IsNotNull(messageDef);
        AssertFieldType(messageDef, "stringItems", "repeated string");
        AssertFieldType(messageDef, "intItems", "repeated int32");
    }

    /// <summary>
    ///     Tests that the generator handles interface base types correctly.
    /// </summary>
    [TestMethod]
    public void ExtractMessageDefinition_DetectsInterfaceBaseType()
    {
        // Arrange
        var source = """
                     using ProtoBuf;

                     namespace Test;

                     public interface ITestInterface { }

                     [ProtoContract(Name = "InterfaceImpl")]
                     public record InterfaceImplSerializationRecord : MapComponentSerializationRecord<ITestInterface>
                     {
                         [ProtoMember(1)]
                         public string? Field { get; init; }
                     }

                     public abstract record MapComponentSerializationRecord<T> { }
                     """;

        var type = ParseSingleTypeFromSource(source, "InterfaceImplSerializationRecord");

        // Act
        var messageDef = ExtractMessageDefinition(type);

        // Assert
        Assert.IsNotNull(messageDef);

        Assert.IsTrue(messageDef.GeoBlazorTypeIsInterface,
            "Expected GeoBlazorTypeIsInterface to be true for types implementing interface-based generics.");
    }

    /// <summary>
    ///     Tests that the generator falls back to type identifier when no Name parameter is specified.
    /// </summary>
    [TestMethod]
    public void ExtractMessageDefinition_FallsBackToTypeIdentifier()
    {
        // Arrange
        var source = """
                     using ProtoBuf;

                     namespace Test;

                     [ProtoContract]
                     public record FallbackSerializationRecord
                     {
                         [ProtoMember(1)]
                         public string? Field { get; init; }
                     }
                     """;

        var type = ParseSingleTypeFromSource(source, "FallbackSerializationRecord");

        // Act
        var messageDef = ExtractMessageDefinition(type);

        // Assert
        Assert.IsNotNull(messageDef);

        Assert.AreEqual("FallbackSerializationRecord", messageDef.Name,
            "Expected type identifier to be used as message name when Name parameter is not specified.");
    }

    /// <summary>
    ///     Tests that empty types with no fields are still processed.
    /// </summary>
    [TestMethod]
    public void ExtractMessageDefinition_HandlesEmptyTypes()
    {
        // Arrange
        var source = """
                     using ProtoBuf;

                     namespace Test;

                     [ProtoContract(Name = "EmptyMessage")]
                     public record EmptySerializationRecord
                     {
                     }
                     """;

        var type = ParseSingleTypeFromSource(source, "EmptySerializationRecord");

        // Act
        var messageDef = ExtractMessageDefinition(type);

        // Assert
        Assert.IsNotNull(messageDef);
        Assert.IsEmpty(messageDef.Fields, "Expected no fields for empty message.");
    }

    /// <summary>
    ///     Tests that ProtoIncludes are ordered by tag number.
    /// </summary>
    [TestMethod]
    public void ExtractMessageDefinition_OrdersProtoIncludesByTag()
    {
        // Arrange
        var source = """
                     using ProtoBuf;

                     namespace Test;

                     [ProtoContract(Name = "OrderedIncludes")]
                     [ProtoInclude(300, typeof(ThirdSerializationRecord))]
                     [ProtoInclude(100, typeof(FirstSerializationRecord))]
                     [ProtoInclude(200, typeof(SecondSerializationRecord))]
                     public record OrderedIncludesSerializationRecord
                     {
                     }

                     [ProtoContract(Name = "First")]
                     public record FirstSerializationRecord { }

                     [ProtoContract(Name = "Second")]
                     public record SecondSerializationRecord { }

                     [ProtoContract(Name = "Third")]
                     public record ThirdSerializationRecord { }
                     """;

        var type = ParseSingleTypeFromSource(source, "OrderedIncludesSerializationRecord");

        // Act
        var messageDef = ExtractMessageDefinition(type);

        // Assert
        Assert.IsNotNull(messageDef);
        Assert.HasCount(3, messageDef.ProtoIncludes);
        Assert.AreEqual(100, messageDef.ProtoIncludes[0].Tag);
        Assert.AreEqual(200, messageDef.ProtoIncludes[1].Tag);
        Assert.AreEqual(300, messageDef.ProtoIncludes[2].Tag);
    }

    /// <summary>
    ///     Tests that GenerateProtoFileContent generates valid proto3 syntax.
    /// </summary>
    [TestMethod]
    public void GenerateProtoFileContent_GeneratesValidProto3Header()
    {
        // Arrange
        var definitions = new Dictionary<string, ProtoMessageDefinition>
        {
            ["TestMessage"] = new()
            {
                Name = "TestMessage",
                Fields = [new ProtoFieldDefinition { Name = "field", Type = "string", Number = 1 }]
            }
        };

        // Act
        var content = GenerateProtoFileContent(definitions);

        // Assert
        Assert.Contains("syntax = \"proto3\";", content,
            "Expected proto3 syntax declaration.");

        Assert.Contains("package dymaptic.GeoBlazor.Core.Serialization;", content,
            "Expected package declaration.");

        Assert.Contains("import \"google/protobuf/empty.proto\";", content,
            "Expected empty.proto import.");
    }

    /// <summary>
    ///     Tests that GenerateProtoFileContent generates message definitions correctly.
    /// </summary>
    [TestMethod]
    public void GenerateProtoFileContent_GeneratesMessageDefinitions()
    {
        // Arrange
        var definitions = new Dictionary<string, ProtoMessageDefinition>
        {
            ["SimpleMessage"] = new()
            {
                Name = "SimpleMessage",
                Fields =
                [
                    new ProtoFieldDefinition { Name = "name", Type = "string", Number = 1 },
                    new ProtoFieldDefinition { Name = "value", Type = "int32", Number = 2 }
                ]
            }
        };

        // Act
        var content = GenerateProtoFileContent(definitions);

        // Assert
        Assert.Contains("message SimpleMessage {", content,
            "Expected message declaration.");

        Assert.Contains("string name = 1;", content,
            "Expected name field declaration.");

        Assert.Contains("int32 value = 2;", content,
            "Expected value field declaration.");
    }

    // Reflection-based access to private methods
    private static readonly MethodInfo extractMessageDefinitionMethod =
        typeof(ProtobufDefinitionsGenerator).GetMethod("ExtractMessageDefinition",
            BindingFlags.NonPublic | BindingFlags.Static)!;

    private static readonly MethodInfo convertCSharpTypeToProtoTypeMethod =
        typeof(ProtobufDefinitionsGenerator).GetMethod("ConvertCSharpTypeToProtoType",
            BindingFlags.NonPublic | BindingFlags.Static)!;

    private static readonly MethodInfo generateProtoFileContentMethod =
        typeof(ProtobufDefinitionsGenerator).GetMethod("GenerateProtoFileContent",
            BindingFlags.NonPublic | BindingFlags.Static)!;


#region Helper Methods

    /// <summary>
    ///     Parses C# source code and extracts a specific type declaration by name.
    /// </summary>
    private static BaseTypeDeclarationSyntax ParseSingleTypeFromSource(string source, string typeName)
    {
        var sourceWithProtobuf = PROTOBUF_ATTRIBUTE_STUB + source;
        var parseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.Latest);
        var tree = CSharpSyntaxTree.ParseText(sourceWithProtobuf, parseOptions);
        var root = tree.GetCompilationUnitRoot();

        var type = root.DescendantNodes()
            .OfType<BaseTypeDeclarationSyntax>()
            .FirstOrDefault(t => t.Identifier.Text == typeName);

        return type ?? throw new InvalidOperationException($"Type '{typeName}' not found in source.");
    }

    /// <summary>
    ///     Invokes the private ExtractMessageDefinition method via reflection.
    /// </summary>
    private static ProtoMessageDefinition? ExtractMessageDefinition(BaseTypeDeclarationSyntax type)
    {
        return (ProtoMessageDefinition?)extractMessageDefinitionMethod.Invoke(null, [type]);
    }

    /// <summary>
    ///     Invokes the private ConvertCSharpTypeToProtoType method via reflection.
    /// </summary>
    private static string ConvertCSharpTypeToProtoType(string csharpType)
    {
        return (string)convertCSharpTypeToProtoTypeMethod.Invoke(null, [csharpType])!;
    }

    /// <summary>
    ///     Invokes the private GenerateProtoFileContent method via reflection.
    /// </summary>
    private static string GenerateProtoFileContent(Dictionary<string, ProtoMessageDefinition> definitions)
    {
        return (string)generateProtoFileContentMethod.Invoke(null, [definitions])!;
    }

    /// <summary>
    ///     Asserts that a field with the given name has the expected Protobuf type.
    /// </summary>
    private static void AssertFieldType(ProtoMessageDefinition messageDef, string fieldName, string expectedType)
    {
        var field = messageDef.Fields.FirstOrDefault(f => f.Name == fieldName);
        Assert.IsNotNull(field, $"Expected field '{fieldName}' to exist in message '{messageDef.Name}'.");

        Assert.AreEqual(expectedType, field.Type,
            $"Expected field '{fieldName}' to have type '{expectedType}' but was '{field.Type}'.");
    }

    /// <summary>
    ///     Stub definitions for ProtoBuf attributes to enable parsing without full ProtoBuf reference.
    /// </summary>
    private const string PROTOBUF_ATTRIBUTE_STUB = """
                                                   namespace ProtoBuf
                                                   {
                                                       [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
                                                       public sealed class ProtoContractAttribute : System.Attribute
                                                       {
                                                           public string? Name { get; set; }
                                                       }

                                                       [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Field)]
                                                       public sealed class ProtoMemberAttribute : System.Attribute
                                                       {
                                                           public ProtoMemberAttribute(int tag) { Tag = tag; }
                                                           public int Tag { get; }
                                                       }

                                                       [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct, AllowMultiple = true)]
                                                       public sealed class ProtoIncludeAttribute : System.Attribute
                                                       {
                                                           public ProtoIncludeAttribute(int tag, System.Type knownType) { Tag = tag; KnownType = knownType; }
                                                           public int Tag { get; }
                                                           public System.Type KnownType { get; }
                                                       }
                                                   }

                                                   """;

#endregion
}