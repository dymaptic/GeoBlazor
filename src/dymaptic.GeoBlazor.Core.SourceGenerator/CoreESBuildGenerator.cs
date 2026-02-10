using dymaptic.GeoBlazor.Core.SourceGenerator.Shared;
using Microsoft.CodeAnalysis;
using System.Diagnostics.CodeAnalysis;


namespace dymaptic.GeoBlazor.Core.SourceGenerator;

/// <summary>
///     Triggers the ESBuild build process for the GeoBlazor project, so that your JavaScript code is up to date.
/// </summary>
[Generator]
[SuppressMessage("MicrosoftCodeAnalysisCorrectness", "RS1035:Do not use APIs banned for analyzers")]
public class CoreESBuildGenerator : IIncrementalGenerator
{
    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Tracks all TypeScript source files in the Scripts directories of Core and Pro.
        // This will trigger the build any time a TypeScript file is added, removed, or changed.
        var tsFilesProvider = context
            .AdditionalTextsProvider
            .Where(static text => text.Path.Contains("Scripts") && text.Path.EndsWith(".ts"))
            .Collect();

        // Reads the MSBuild properties to get the project directory and configuration.
        var optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select(ESBuildGenerator.ConfigSelector);

        var combined =
            tsFilesProvider.Combine(optionsProvider);

        context.RegisterSourceOutput(combined, (ctx, pipeline) => ESBuildGenerator.FilesChanged(ctx, pipeline));
    }
}