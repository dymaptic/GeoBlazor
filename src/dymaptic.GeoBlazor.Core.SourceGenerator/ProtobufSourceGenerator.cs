using dymaptic.GeoBlazor.Core.SourceGenerator.Shared;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;


namespace dymaptic.GeoBlazor.Core.SourceGenerator;

/// <summary>
///     Source generator for protobuf serialization records.
///     This generator scans for types marked with ProtoContract or ProtobufSerializable attributes
///     and generates serialization infrastructure.
/// </summary>
[Generator]
public class ProtobufSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Finds all class, struct, and record declarations marked with protobuf attributes.
        IncrementalValueProvider<ImmutableArray<BaseTypeDeclarationSyntax>> typeProvider =
            context.SyntaxProvider.CreateSyntaxProvider(static (syntaxNode, _) =>
                        syntaxNode is ClassDeclarationSyntax or StructDeclarationSyntax or RecordDeclarationSyntax
                        && (((BaseTypeDeclarationSyntax)syntaxNode).AttributeLists.SelectMany(a => a.Attributes)
                        .Any(a => a.Name.ToString() is ProtoContractAttribute or ProtoSerializableAttribute)
                            || syntaxNode.ChildNodes()
                                .OfType<MethodDeclarationSyntax>()
                                .Any(m => m.AttributeLists
                                    .SelectMany(a => a.Attributes)
                                    .Any(attr => attr.Name.ToString() == SerializedMethodAttributeName))),
                    static (context, _) => (BaseTypeDeclarationSyntax)context.Node)
                .Collect();

        // Reads the MSBuild properties to get the project directory.
        IncrementalValueProvider<string?> optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select((configProvider, _) =>
            {
                configProvider.GlobalOptions.TryGetValue("build_property.CoreProjectPath",
                    out var projectDirectory);

                return projectDirectory;
            });

        var combined =
            typeProvider.Combine(optionsProvider)
                .Combine(context.CompilationProvider);

        context.RegisterSourceOutput(combined, FilesChanged);
    }

    private void FilesChanged(SourceProductionContext context,
        ((ImmutableArray<BaseTypeDeclarationSyntax> Types, string? ProjectDirectory) Data,
            Compilation Compilation) pipeline)
    {
        // Skip if not running from the Core project
        if (pipeline.Compilation.AssemblyName != "dymaptic.GeoBlazor.Core")
        {
            return;
        }

        // Skip source generation if the project path is not available
        if (string.IsNullOrEmpty(pipeline.Data.ProjectDirectory))
        {
            ProcessHelper.Log(nameof(ProtobufSourceGenerator),
                "CoreProjectPath not set. Skipping protobuf source generation.",
                DiagnosticSeverity.Warning,
                context);
            return;
        }

        // Log that protobuf types were found (infrastructure ready for future implementation)
        if (pipeline.Data.Types.Length > 0)
        {
            ProcessHelper.Log(nameof(ProtobufSourceGenerator),
                $"Found {pipeline.Data.Types.Length} protobuf-serializable types.",
                DiagnosticSeverity.Info,
                context);

            // TODO: Generate protobuf serialization records and registration code.
            // This will include:
            // 1. Generating *SerializationRecord classes for each protobuf-attributed type
            // 2. Generating ToProtobuf()/FromProtobuf() extension methods
            // 3. Generating JsSyncManager registration code for ProtoContractTypes dictionary
            // 4. Copying .proto definitions to TypeScript for JS-side deserialization
        }
    }

    private const string ProtoContractAttribute = "ProtoContract";
    private const string ProtoSerializableAttribute = "ProtobufSerializable";
    private const string SerializedMethodAttributeName = "SerializedMethod";
}