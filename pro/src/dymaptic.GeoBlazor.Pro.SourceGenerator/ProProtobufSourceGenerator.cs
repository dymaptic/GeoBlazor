using dymaptic.GeoBlazor.Core.SourceGenerator.Shared;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;


namespace dymaptic.GeoBlazor.Pro.SourceGenerator;

/// <summary>
///     Generates code for GeoBlazor Pro
/// </summary>
[Generator]
public class ProProtobufSourceGenerator : IIncrementalGenerator
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

                if (configProvider.GlobalOptions.TryGetValue("build_property.ShowScriptDialogs",
                    out var showDialog))
                {
                    options["ShowScriptDialogs"] = showDialog;
                }

                return options;
            });

        var combined =
            typeProvider.Combine(optionsProvider);

        context.RegisterSourceOutput(combined, FilesChanged);
    }

    private void FilesChanged(SourceProductionContext context,
        (ImmutableArray<BaseTypeDeclarationSyntax> Types, Dictionary<string, string> Options) pipeline)
    {
        pipeline.Options.TryGetValue("ShowScriptDialogs", out var showDialogString);

        bool showDialog = showDialogString is not null
            && bool.TryParse(showDialogString, out bool showDialogBool)
            && showDialogBool;

        // Generate a unique session ID for this build session
        string sessionId = $"{nameof(ProProtobufSourceGenerator)}_{Guid.NewGuid():N}";

        if (pipeline.Types.Length > 0)
        {
            ProcessHelper.Log(nameof(ProProtobufSourceGenerator),
                $"Pro Source Generation triggered with {pipeline.Types.Length} protobuf types found.",
                DiagnosticSeverity.Info,
                context, showDialog, sessionId);

            Dictionary<string, ProtoMessageDefinition> protoDefinitions = ProtobufDefinitionsGenerator
                .ExtractProtobufDefinitions(pipeline.Types, context, showDialog, sessionId);

            context.CancellationToken.ThrowIfCancellationRequested();

            // SerializationGenerator.GenerateSerializationDataClass(context,
            //     pipeline.Types, protoDefinitions, true, showDialog, sessionId);

            if (showDialog)
            {
                ProcessHelper.CloseDialog(sessionId);
            }
        }
    }

    private const string PROTO_CONTRACT_ATTRIBUTE = "ProtoContract";
    private const string PROTO_SERIALIZABLE_ATTRIBUTE = "ProtobufSerializable";
    private const string SERIALIZED_METHOD_ATTRIBUTE_NAME = "SerializedMethod";
}