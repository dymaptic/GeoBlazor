using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace dymaptic.GeoBlazor.Core.Analyzers;

/// <summary>
///     Detects Blazor component parameters in Razor markup where a raw string value is assigned to a
///     property whose type has an implicit conversion from string. In Razor, raw string attribute values
///     bypass C# implicit operators, causing a runtime error. The fix is to wrap the value in @().
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
internal class ParameterConversionAnalyzer : DiagnosticAnalyzer
{
    public const string DiagnosticId = "GeoBlazor_RPC";

    private static readonly DiagnosticDescriptor rule = new(
        DiagnosticId,
        "Use @() wrapper for implicit string conversion in Razor",
        "Parameter '{0}' (type '{1}') supports implicit conversion from string, but Razor requires @() syntax for the conversion to work. Change {0}=\"{2}\" to {0}=\"@(\"{2}\")\".",
        "Usage",
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description:
        "In Razor markup, raw string attribute values are passed as-is to component parameters without applying C# implicit conversion operators. This causes a runtime error when the parameter type is not string. Wrap the value in @() to enable the implicit conversion. Example: change Param=\"value\" to Param=\"@(\"value\")\".");

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(rule);

    public override void Initialize(AnalysisContext context)
    {
        // Must analyze generated code since Razor compiles to generated .g.cs files
        context.ConfigureGeneratedCodeAnalysis(
            GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(AnalyzeInvocation, SyntaxKind.InvocationExpression);
    }

    private static void AnalyzeInvocation(SyntaxNodeAnalysisContext context)
    {
        var invocation = (InvocationExpressionSyntax)context.Node;

        if (!IsInGeneratedRazorCode(invocation.SyntaxTree))
            return;

        if (!IsAddComponentParameterCall(invocation))
            return;

        var args = invocation.ArgumentList.Arguments;

        if (args.Count < 3)
            return;

        // The value argument (3rd) must be a raw string literal.
        // If the Razor compiler wraps it in RuntimeHelpers.TypeCheck<T>(), that means @() was used
        // and the implicit conversion is already being applied — nothing to warn about.
        if (!IsStringLiteral(args[2].Expression, out string? stringValue))
            return;

        // Resolve the target property from the parameter name argument (2nd).
        // The Razor compiler generates nameof(global::Namespace.Type.Property) for the name.
        IPropertySymbol? property = TryResolvePropertyFromNameof(args[1].Expression, context.SemanticModel);

        if (property == null)
            return;

        if (property.Type.SpecialType == SpecialType.System_String)
            return;

        if (property.Type.TypeKind == TypeKind.Error)
            return;

        if (!HasImplicitConversionFromString(property.Type))
            return;

        context.ReportDiagnostic(Diagnostic.Create(
            rule,
            args[2].GetLocation(),
            property.Name,
            property.Type.Name,
            stringValue));
    }

    /// <summary>
    ///     Resolves a property symbol from a nameof(Type.Property) expression.
    /// </summary>
    private static IPropertySymbol? TryResolvePropertyFromNameof(
        ExpressionSyntax paramNameExpr,
        SemanticModel semanticModel)
    {
        if (paramNameExpr is not InvocationExpressionSyntax nameofExpr)
            return null;

        if (nameofExpr.Expression is not IdentifierNameSyntax { Identifier.Text: "nameof" })
            return null;

        if (nameofExpr.ArgumentList.Arguments.Count != 1)
            return null;

        var nameofArg = nameofExpr.ArgumentList.Arguments[0].Expression;
        var symbolInfo = semanticModel.GetSymbolInfo(nameofArg);

        return symbolInfo.Symbol as IPropertySymbol
            ?? symbolInfo.CandidateSymbols.OfType<IPropertySymbol>().FirstOrDefault();
    }

    private static bool IsAddComponentParameterCall(InvocationExpressionSyntax invocation)
    {
        return invocation.Expression is MemberAccessExpressionSyntax
        {
            Name.Identifier.Text: "AddComponentParameter"
        };
    }

    private static bool IsStringLiteral(ExpressionSyntax expression, out string? value)
    {
        if (expression is LiteralExpressionSyntax literal &&
            literal.IsKind(SyntaxKind.StringLiteralExpression))
        {
            value = literal.Token.ValueText;
            return true;
        }

        value = null;
        return false;
    }

    private static bool IsInGeneratedRazorCode(SyntaxTree tree)
    {
        string filePath = tree.FilePath;

        // Razor source generator outputs files ending with _razor.g.cs or .razor.g.cs
        return filePath.EndsWith("_razor.g.cs") || filePath.EndsWith(".razor.g.cs");
    }

    private static bool HasImplicitConversionFromString(ITypeSymbol type)
    {
        if (type is not INamedTypeSymbol namedType)
            return false;

        return namedType.GetMembers()
            .OfType<IMethodSymbol>()
            .Any(m => m.MethodKind == MethodKind.Conversion &&
                m.Parameters.Length == 1 &&
                m.Parameters[0].Type.SpecialType == SpecialType.System_String);
    }
}