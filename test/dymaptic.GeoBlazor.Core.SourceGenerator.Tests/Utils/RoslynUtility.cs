using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace dymaptic.GeoBlazor.Core.SourceGenerator.Tests.Utils;

public static class RoslynUtility
{
    public static CSharpCompilation CreateCompilation(string sourceCode)
    {
        CSharpParseOptions options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp7_3);
        SyntaxTree tree = CSharpSyntaxTree.ParseText(sourceCode, options);
        SyntaxTree protobufStubTree = CSharpSyntaxTree.ParseText(protobufStub, options);
    
        PortableExecutableReference[] references = new[]
            {
                typeof(object).Assembly, // System.Runtime
                typeof(Console).Assembly, // System.Console
                typeof(ComponentBase).Assembly, // Microsoft.AspNetCore.Components
                typeof(ActivatorUtilitiesConstructorAttribute).Assembly, // Microsoft.Extensions.DependencyInjection
                Assembly.Load("System.Runtime"), 
                Assembly.Load("netstandard"),
                Assembly.LoadFile(CoreDllPath) // dymaptic.GeoBlazor.Core
            }
            .Select(a => MetadataReference.CreateFromFile(a.Location))
            .ToArray();
    
        return CSharpCompilation.Create("dymaptic.GeoBlazor.Core",
            [tree, protobufStubTree],
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    }

    private static readonly string protobufStub = """


                                                   namespace ProtoBuf
                                                   {
                                                       [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
                                                       public sealed class ProtoContractAttribute : System.Attribute
                                                       {
                                                       }
                                                   }
                                                   """;
    
    public static string CorePath = Path.Combine(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
        "..", "..", "..", "..", "..", "src", "dymaptic.GeoBlazor.Core");
    
    public static string CoreDllPath => Path.Combine(CorePath, "bin", "Debug", "net8.0", 
        "dymaptic.GeoBlazor.Core.dll");
}