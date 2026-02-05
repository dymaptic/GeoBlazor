using dymaptic.GeoBlazor.Core.SourceGenerator.Shared;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
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
        IncrementalValueProvider<ImmutableArray<AdditionalText>> tsFilesProvider = context
            .AdditionalTextsProvider
            .Where(static text => text.Path.Contains("Scripts") && text.Path.EndsWith(".ts"))
            .Collect();

        // Reads the MSBuild properties to get the project directory and configuration.
        IncrementalValueProvider<Dictionary<string, string>> optionsProvider =
            context.AnalyzerConfigOptionsProvider.Select(ESBuildGenerator.ConfigSelector);

        var combined =
            tsFilesProvider.Combine(optionsProvider);

        context.RegisterSourceOutput(combined, (ctx, pipeline) =>
            ESBuildGenerator.FilesChanged(ctx, pipeline, false, _sessionId, _proSessionId));
    }

    // Generate a unique session ID for this build session
    private readonly string _sessionId = $"{nameof(CoreESBuildGenerator)}_{Guid.NewGuid():N}";
    private readonly string _proSessionId = $"{nameof(CoreESBuildGenerator)}_{Guid.NewGuid():N}";
}