using dymaptic.GeoBlazor.Core.SourceGenerator.Shared;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Text;


namespace dymaptic.GeoBlazor.Core.SourceGenerator;

/// <summary>
///     Triggers the ESBuild build process for the GeoBlazor project, so that your JavaScript code is up to date.
/// </summary>
[Generator]
public class ProtobufSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Finds all class, struct, and record declarations in the source code.
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

        // Reads the MSBuild properties to get the project directory and configuration.
        IncrementalValueProvider<string?> optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select((configProvider, _) =>
            {
                configProvider.GlobalOptions.TryGetValue("build_property.CoreProjectPath",
                    out var projectDirectory);

                return (projectDirectory);
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
        if (pipeline.Compilation.AssemblyName != "dymaptic.GeoBlazor.Core")
        {
            ProcessHelper.Log(nameof(ProtobufSourceGenerator),
                $"Run from project {pipeline.Compilation.AssemblyName}.",
                DiagnosticSeverity.Info,
                context);

            _isTest = true;
        }

        _corePath = pipeline.Data.ProjectDirectory;

        ProcessHelper.Log(nameof(ProtobufSourceGenerator),
            "Source Generation triggered.",
            DiagnosticSeverity.Info,
            context);

        if (pipeline.Data.Types.Length > 0)
        {
            var protoDefinitions = ProtobufDefinitionsGenerator
                .UpdateProtobufDefinitions(context, pipeline.Data.Types, _corePath!);

            context.CancellationToken.ThrowIfCancellationRequested();

            SerializationGenerator.GenerateSerializationDataClass(context,
                pipeline.Data.Types, protoDefinitions, false,
                _isTest);
            
            context.CancellationToken.ThrowIfCancellationRequested();
        }
    }

    private static string? _corePath;
    private static bool _isTest;
    private const string ProtoContractAttribute = "ProtoContract";
    private const string ProtoSerializableAttribute = "ProtobufSerializable";
    private const string SerializedMethodAttributeName = "SerializedMethod";
}