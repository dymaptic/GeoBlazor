using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;


namespace dymaptic.GeoBlazor.Core.Analyzers;

/// <summary>
///     Suppresses BL0005 ("Component parameter should not be set outside of its component") for
///     GeoBlazor parameters that are documented as code-assignable, most notably
///     <c>MapComponent.View</c>. These properties are dual-purpose — accepted as Razor markup
///     attributes *and* routinely assigned from code-behind in GeoBlazor apps — so BL0005 is a
///     false positive on those specific members.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
internal class GeoBlazorParameterAssignmentSuppressor : DiagnosticSuppressor
{
    public const string SuppressionId = "GeoBlazorBL0005";
    private const string SuppressedDiagnosticId = "BL0005";

    // Add (Namespace, TypeName, MemberName) entries to extend the allow-list.
    private static readonly string[] AllowedAssignments =
    {
        "dymaptic.GeoBlazor.Core.Components" // MapComponents
    };

    private static readonly SuppressionDescriptor Rule = new(
        id: SuppressionId,
        suppressedDiagnosticId: SuppressedDiagnosticId,
        justification: "GeoBlazor exposes select [Parameter] properties (e.g. MapComponent.View) that are designed to be assigned from code as well as Razor markup.");

    public override ImmutableArray<SuppressionDescriptor> SupportedSuppressions => ImmutableArray.Create(Rule);

    public override void ReportSuppressions(SuppressionAnalysisContext context)
    {
        foreach (Diagnostic diagnostic in context.ReportedDiagnostics)
        {
            if (diagnostic.Id != SuppressedDiagnosticId) continue;

            SyntaxTree? tree = diagnostic.Location.SourceTree;
            if (tree is null) continue;

            SyntaxNode root = tree.GetRoot(context.CancellationToken);
            SyntaxNode node = root.FindNode(diagnostic.Location.SourceSpan, getInnermostNodeForTie: true);
            SemanticModel model = context.GetSemanticModel(tree);

            if (model.GetSymbolInfo(node, context.CancellationToken).Symbol is not IPropertySymbol property)
                continue;

            if (IsAllowed(property))
            {
                context.ReportSuppression(Suppression.Create(Rule, diagnostic));
            }
        }
    }

    private static bool IsAllowed(IPropertySymbol property)
    {
        IPropertySymbol definition = property.OriginalDefinition;
        INamedTypeSymbol? containingType = definition.ContainingType;
        if (containingType is null) return false;

        string namespaceName = containingType.ContainingNamespace?.ToDisplayString() ?? string.Empty;

        foreach (string ns in AllowedAssignments)
        {
            if (namespaceName.Contains(ns))
            {
                return true;
            }
        }

        return false;
    }
}
