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
    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Finds all class, struct, and record declarations marked with protobuf attributes.
        IncrementalValueProvider<ImmutableArray<BaseTypeDeclarationSyntax>> typeProvider =
            context.SyntaxProvider.CreateSyntaxProvider(static (syntaxNode, _) =>
                        syntaxNode is ClassDeclarationSyntax or StructDeclarationSyntax or RecordDeclarationSyntax
                        && (((BaseTypeDeclarationSyntax)syntaxNode).AttributeLists.SelectMany(a => a.Attributes)
                            .Any(a => a.Name.ToString() is PROTO_CONTRACT_ATTRIBUTE or PROTO_SERIALIZABLE_ATTRIBUTE)
                            || syntaxNode.ChildNodes()
                                .OfType<MethodDeclarationSyntax>()
                                .Any(m => m.AttributeLists
                                    .SelectMany(a => a.Attributes)
                                    .Any(attr => attr.Name.ToString() == SERIALIZED_METHOD_ATTRIBUTE_NAME))),
                    static (context, _) => (BaseTypeDeclarationSyntax)context.Node)
                .Collect();

        // Reads the MSBuild properties to get the project directory.
        IncrementalValueProvider<Dictionary<string, string>> optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select((configProvider, _) =>
            {
                Dictionary<string, string> options = [];

                if (configProvider.GlobalOptions.TryGetValue("build_property.CoreProjectPath",
                    out var projectDirectory))
                {
                    options["CoreProjectPath"] = projectDirectory;
                }

                if (configProvider.GlobalOptions.TryGetValue("build_property.PipelineBuild",
                    out var pipelineBuild))
                {
                    options["PipelineBuild"] = pipelineBuild;
                }

                if (configProvider.GlobalOptions.TryGetValue("build_property.ShowSourceGenDialogs",
                    out var showDialog))
                {
                    options["ShowSourceGenDialogs"] = showDialog;
                }

                return options;
            });

        IncrementalValueProvider<(ImmutableArray<BaseTypeDeclarationSyntax> Left,
            Dictionary<string, string> Right)> combined =
            typeProvider.Combine(optionsProvider);

        context.RegisterSourceOutput(combined, FilesChanged);
    }

    private void FilesChanged(SourceProductionContext context,
        (ImmutableArray<BaseTypeDeclarationSyntax> Types, Dictionary<string, string> Options)
            pipeline)
    {
        pipeline.Options.TryGetValue("CoreProjectPath", out _corePath);
        pipeline.Options.TryGetValue("PipelineBuild", out string? pipelineBuildString);

        bool pipelineBuild = pipelineBuildString is not null
            && bool.TryParse(pipelineBuildString, out bool pipelineBuildBool)
            && pipelineBuildBool;

        pipeline.Options.TryGetValue("ShowSourceGenDialogs", out string? showDialogString);

        bool showDialog = !pipelineBuild
            && showDialogString is not null
            && bool.TryParse(showDialogString, out bool showDialogBool)
            && showDialogBool;

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
    private const string PROTO_CONTRACT_ATTRIBUTE = "ProtoContract";
    private const string PROTO_SERIALIZABLE_ATTRIBUTE = "ProtobufSerializable";
    private const string SERIALIZED_METHOD_ATTRIBUTE_NAME = "SerializedMethod";
}