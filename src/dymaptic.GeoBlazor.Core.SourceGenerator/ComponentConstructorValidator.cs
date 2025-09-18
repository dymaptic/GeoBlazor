using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Immutable;


namespace dymaptic.GeoBlazor.Core.SourceGenerator;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
internal class ComponentConstructorValidator : DiagnosticAnalyzer
{
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSymbolAction(ctx => ValidateSymbol(ctx), SymbolKind.NamedType);
    }

    internal static DiagnosticDescriptor Rule = new("GeoBlazor_AUC", "Missing ActivatorUtilitiesConstructorAttribute",
            "Class '{0}' has multiple constructors but does not have a parameterless constructor with the [ActivatorUtilitiesConstructor] attribute",
            "Usage", DiagnosticSeverity.Error, isEnabledByDefault: true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

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

        while (baseType != null)
        {
            string typeName = baseType.Name;

            if (typeName == "MapComponent")
            {
                return true;
            }

            if (typeName == "ComponentBase")
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