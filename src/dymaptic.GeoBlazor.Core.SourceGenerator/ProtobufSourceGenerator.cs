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
#if SHOW_SOURCEGEN_DIALOGS
    private static bool _showDialog = true;
#else
    private static bool _showDialog = false;
#endif

    /// <inheritdoc />
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
        IncrementalValueProvider<(string?, string?)> optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select((configProvider, _) =>
            {
                configProvider.GlobalOptions.TryGetValue("build_property.CoreProjectPath",
                    out var projectDirectory);

                configProvider.GlobalOptions.TryGetValue("build_property.PipelineBuild",
                    out var pipelineBuild);

                return (projectDirectory, pipelineBuild);
            });

        IncrementalValueProvider<(ImmutableArray<BaseTypeDeclarationSyntax> Left, (string?, string?) Right)> combined =
            typeProvider.Combine(optionsProvider);

        context.RegisterSourceOutput(combined, FilesChanged);
    }

    private void FilesChanged(SourceProductionContext context,
        (ImmutableArray<BaseTypeDeclarationSyntax> Types, (string? ProjectDirectory, string? PipelineBuild) Options)
            pipeline)
    {
        _corePath = pipeline.Options.ProjectDirectory;
        bool showDialog = pipeline.Options.PipelineBuild != "true" && _showDialog;

        // Generate a unique session ID for this build session
        string sessionId = $"{nameof(ProtobufSourceGenerator)}_{Guid.NewGuid():N}";

        if (pipeline.Types.Length > 0)
        {
            try
            {
                ProcessHelper.Log(nameof(ProtobufSourceGenerator),
                    $"Source Generation triggered with {pipeline.Types.Length} protobuf types found.",
                    DiagnosticSeverity.Info,
                    context, showDialog, sessionId);

                var protoDefinitions = ProtobufDefinitionsGenerator
                    .UpdateProtobufDefinitions(context, pipeline.Types, _corePath!, showDialog, sessionId);

                context.CancellationToken.ThrowIfCancellationRequested();

                SerializationGenerator.GenerateSerializationDataClass(context,
                    pipeline.Types, protoDefinitions, false, showDialog, sessionId);

                context.CancellationToken.ThrowIfCancellationRequested();

                if (showDialog)
                {
                    ProcessHelper.CloseDialog(sessionId);
                }
            }
            catch (Exception ex)
            {
                ProcessHelper.Log(nameof(ProtobufSourceGenerator),
                    $"Error generating serialization data class: {ex.Message}\n{ex.StackTrace}",
                    DiagnosticSeverity.Error,
                    context, showDialog, sessionId);

                if (showDialog)
                {
                    ProcessHelper.CloseDialog(sessionId);
                }
            }
        }
    }

    private static string? _corePath;
    private const string ProtoContractAttribute = "ProtoContract";
    private const string ProtoSerializableAttribute = "ProtobufSerializable";
    private const string SerializedMethodAttributeName = "SerializedMethod";
}