using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Text;


namespace dymaptic.GeoBlazor.Core.SourceGenerator;

/// <summary>
///     Triggers the ESBuild build process for the GeoBlazor project, so that your JavaScript code is up to date.
/// </summary>
[Generator]
public class CoreSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Tracks all TypeScript source files in the Scripts directories of Core and Pro.
        // This will trigger the build any time a TypeScript file is added, removed, or changed.
        IncrementalValueProvider<ImmutableArray<AdditionalText>> tsFilesProvider = context.AdditionalTextsProvider
            .Where(static text => text.Path.Contains("Scripts") && text.Path.EndsWith(".ts"))
            .Collect();
        
        // Protobuf type definitions
        IncrementalValueProvider<ImmutableArray<BaseTypeDeclarationSyntax>> protoTypeProvider = 
            context.SyntaxProvider.ForAttributeWithMetadataName(
                fullyQualifiedMetadataName: "ProtoBuf.ProtoContractAttribute",
                predicate: static (syntaxNode, _) => 
                    syntaxNode is ClassDeclarationSyntax or StructDeclarationSyntax or RecordDeclarationSyntax,
                transform: static (context, _) => (BaseTypeDeclarationSyntax)context.TargetNode).Collect();
        
        // Find all methods with the [SerializedMethod] attribute
        IncrementalValueProvider<ImmutableArray<SerializableMethodRecord>> serializableMethodsProvider = 
            context.SyntaxProvider.ForAttributeWithMetadataName(
                fullyQualifiedMetadataName: "dymaptic.GeoBlazor.Core.Attributes.SerializedMethodAttribute",
                predicate: static (syntaxNode, _) => syntaxNode is MethodDeclarationSyntax,
                transform: static (context, _) =>
                {
                    MethodDeclarationSyntax method = (MethodDeclarationSyntax)context.TargetNode;
                    string typeName = context.TargetSymbol.ContainingType.ToDisplayString().Split('.').Last();
                    string returnType = method.ReturnType.ToString();

                    if (returnType.StartsWith("Task") || returnType.StartsWith("ValueTask"))
                    {
                        int bracketIndex = returnType.IndexOf('<');
                        returnType = returnType.Substring(bracketIndex + 1, returnType.Length - bracketIndex - 2);
                    }
                    SerializableMethodRecord record = new(typeName, 
                        method.Identifier.Text,
                        method.ParameterList.Parameters.ToDictionary(
                            p => p.Identifier.Text,
                            p => p.Type!.ToString()),
                        returnType);

                    return record;
                }).Collect();

        // Reads the MSBuild properties to get the project directory and configuration.
        IncrementalValueProvider<(string?, string?, string?)> optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select((configProvider, _) =>
            {
                configProvider.GlobalOptions.TryGetValue("build_property.MSBuildProjectDirectory",
                    out string? projectDirectory);

                configProvider.GlobalOptions.TryGetValue("build_property.Configuration",
                    out string? configuration);
                
                configProvider.GlobalOptions.TryGetValue("build_property.PipelineBuild",
                    out string? pipelineBuild);

                return (projectDirectory, configuration, pipelineBuild);
            });

        IncrementalValueProvider<(((ImmutableArray<BaseTypeDeclarationSyntax> ProtoTypes, 
            ImmutableArray<SerializableMethodRecord> SerializableMethods) Types, 
            ImmutableArray<AdditionalText> TsFiles) Files, 
            (string?, string?, string?) Options)> combined = 
            protoTypeProvider.Combine(serializableMethodsProvider).Combine(tsFilesProvider).Combine(optionsProvider);

        context.RegisterSourceOutput(combined, FilesChanged);
    }

    private void FilesChanged(SourceProductionContext context,
        (((ImmutableArray<BaseTypeDeclarationSyntax> ProtoTypes, 
            ImmutableArray<SerializableMethodRecord> SerializableMethods) Types, 
            ImmutableArray<AdditionalText> TsFiles) Files, 
        (string? ProjectDirectory, string? Configuration, string? PipelineBuild) Options) pipeline)
    {
        if (!SetProjectDirectoryAndConfiguration(pipeline.Options, context))
        {
            return;
        }

        ProcessHelper.Log(nameof(CoreSourceGenerator),
            "Source Generation triggered.", 
            DiagnosticSeverity.Info,
            context);

        ProtobufDefinitionsGenerator.UpdateProtobufDefinitions(context, pipeline.Files.Types.ProtoTypes, _corePath!);
        
        context.CancellationToken.ThrowIfCancellationRequested();

        SerializationGenerator.GenerateSerializationDataClass(context,
            pipeline.Files.Types.SerializableMethods, ProtobufDefinitionsGenerator.ProtoDefinitions!, false);
        
        context.CancellationToken.ThrowIfCancellationRequested();
        
        if (pipeline.Options.PipelineBuild == "true")
        {
            // If the pipeline build is enabled, we skip the ESBuild process.
            // This is to avoid race conditions where the files are not ready on time, and we do the build separately.
            ProcessHelper.Log(nameof(CoreSourceGenerator), 
                "Skipping ESBuild process as PipelineBuild is set to true.", 
                DiagnosticSeverity.Info,
                context);
            return;
        }
        
        LaunchESBuild(context);
    }

    private bool SetProjectDirectoryAndConfiguration((string? projectDirectory, string? configuration, string? _) options,
        SourceProductionContext context)
    {
        if (options.projectDirectory is { } projectDirectory)
        {
            _corePath = Path.GetFullPath(projectDirectory);
            ProcessHelper.Log(
                nameof(CoreSourceGenerator),
                $"Project directory set to {_corePath}",
                DiagnosticSeverity.Info, 
                context);

            if (_corePath.Contains("GeoBlazor.Pro"))
            {
                // we are inside the Pro submodule, we should also set the Pro path to build the Pro JavaScript files
                string path = _corePath;

                while (!path.EndsWith("GeoBlazor.Pro"))
                {
                    // move up the directory tree until we find the GeoBlazor.Pro directory
                    path = Path.GetDirectoryName(path)!;
                }
                
                // set the pro path to the src/dymaptic.GeoBlazor.Pro directory
                _proPath = Path.GetFullPath(Path.Combine(path, "src", "dymaptic.GeoBlazor.Pro"));
            }
        }
        else
        {
            ProcessHelper.Log(nameof(CoreSourceGenerator),
                "Invalid project directory.",
                DiagnosticSeverity.Error,
                context);

            return false;
        }

        if (options.configuration is { } configuration)
        {
            _configuration = configuration;

            return true;
        }

        ProcessHelper.Log(nameof(CoreSourceGenerator),
            "Could not parse configuration setting, invalid configuration.",
            DiagnosticSeverity.Error,
            context);

        return false;
    }

    private void LaunchESBuild(SourceProductionContext context)
    {
        context.CancellationToken.ThrowIfCancellationRequested();
        
        ProcessHelper.Log(nameof(CoreSourceGenerator), 
            "Starting Core ESBuild process...", 
            DiagnosticSeverity.Info,
            context);

        StringBuilder logBuilder = new StringBuilder(DateTime.Now.ToLongTimeString());
        logBuilder.AppendLine("Starting Core ESBuild process...");

        try
        {
            List<Task> tasks = [];
            bool buildSuccess = false;
            bool proBuildSuccess = false;

            // gets the esBuild.ps1 script from the Core path
            tasks.Add(Task.Run(async () =>
            {
                await ProcessHelper.RunPowerShellScript("Core",
                    _corePath!, "esBuild.ps1",
                    $"-c {_configuration}", logBuilder, context.CancellationToken);
                buildSuccess = true;
            }));

            if (_proPath is not null)
            {
                logBuilder.AppendLine("Starting Pro ESBuild process...");

                tasks.Add(Task.Run(async () =>
                {
                    await ProcessHelper.RunPowerShellScript("Pro",
                        _proPath, "esProBuild.ps1",
                        $"-c {_configuration}", logBuilder, context.CancellationToken);
                    proBuildSuccess = true;
                }));
            }

            Task.WhenAll(tasks).GetAwaiter().GetResult();

            if (!buildSuccess)
            {
                ProcessHelper.Log(nameof(CoreSourceGenerator),
                    $"Core ESBuild process failed\r\n{logBuilder}",
                    DiagnosticSeverity.Error,
                    context);
                return;
            }
            
            logBuilder.AppendLine("Core ESBuild process completed successfully.");
            logBuilder.AppendLine();

            if (_proPath is not null)
            {
                if (!proBuildSuccess)
                {
                    ProcessHelper.Log(nameof(CoreSourceGenerator),
                        $"Pro ESBuild process failed\r\n{logBuilder}",
                        DiagnosticSeverity.Error,
                        context);
                    return;
                }
                
                logBuilder.AppendLine("Pro ESBuild process completed successfully.");
                logBuilder.AppendLine();
            }
            
            ProcessHelper.Log(nameof(CoreSourceGenerator),
                logBuilder.ToString(),
                DiagnosticSeverity.Info,
                context);
        }
        catch (Exception ex)
        {
            ProcessHelper.Log(nameof(CoreSourceGenerator),
                $"An error occurred while running ESBuild: {ex.Message}\r\n{ex.StackTrace}", 
                DiagnosticSeverity.Error,
                context);
        }
    }

    private static string? _corePath;
    private static string? _proPath;
    private static string? _configuration;
}