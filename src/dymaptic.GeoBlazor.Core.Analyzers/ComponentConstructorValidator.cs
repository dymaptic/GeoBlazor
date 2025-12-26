using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;


namespace dymaptic.GeoBlazor.Core.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
internal class ComponentConstructorValidator : DiagnosticAnalyzer
{
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSymbolAction(ValidateSymbol, SymbolKind.NamedType);
    }

    private static readonly DiagnosticDescriptor rule = new("GeoBlazor_AUC", "Missing ActivatorUtilitiesConstructorAttribute",
            "Class '{0}' has multiple constructors but does not have a parameterless constructor with the [ActivatorUtilitiesConstructor] attribute. Add [ActivatorUtilitiesConstructor] to the parameterless constructor to enable proper dependency injection.",
            "Usage", DiagnosticSeverity.Error, isEnabledByDefault: true,
            description: "When a Blazor component has multiple constructors, the parameterless constructor must be marked with [ActivatorUtilitiesConstructor] to ensure proper instantiation. Example: [ActivatorUtilitiesConstructor] public YourComponent() { }.");

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => [rule];

    private void ValidateSymbol(SymbolAnalysisContext context)
    {
        INamedTypeSymbol classSymbol = (INamedTypeSymbol)context.Symbol;

        if (classSymbol.IsAbstract || !IsRazorComponent(classSymbol)) return;

        List<IMethodSymbol> constructors = classSymbol.Constructors
            .Where(c => c is { IsImplicitlyDeclared: false, DeclaredAccessibility: Accessibility.Public })
            .ToList();

        // more than one constructor, at least one with parameters,
        if (constructors.Any(c => c.Parameters.Length > 0)
            // and no parameterless constructor with the attribute
            && constructors.All(c => c.Parameters.Length > 0 || !HasActivatorUtilitiesConstructorAttribute(c)))
        {
            foreach (Location location in constructors.SelectMany(c => c.Locations))
            {
                context.ReportDiagnostic(Diagnostic.Create(SupportedDiagnostics[0], location, classSymbol.Name));
            }
        }
    }

    bool IsRazorComponent(INamedTypeSymbol classSymbol)
    {
        INamedTypeSymbol? baseType = classSymbol.BaseType;

        while (baseType is not null)
        {
            // check simple name first (fast)
            if (baseType.Name == "MapComponent" || baseType.Name == "ComponentBase")
            {
                return true;
            }
            
            baseType = baseType.BaseType;
        }

        return false;
    }

    bool HasActivatorUtilitiesConstructorAttribute(IMethodSymbol constructor)
    {
        return constructor.GetAttributes().Any(attr =>
            attr.AttributeClass?.Name == "ActivatorUtilitiesConstructorAttribute");
    }
}