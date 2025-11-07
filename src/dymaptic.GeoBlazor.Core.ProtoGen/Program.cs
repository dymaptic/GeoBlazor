using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.MSBuild;
using ProtoBuf;
using ProtoBuf.Grpc.Configuration;
using ProtoBuf.Grpc.Reflection;
using System.Reflection;
using System.Runtime.Loader;


string projectDirectory = Directory.GetCurrentDirectory();

// Running from console or from IDE can change the result of Directory.GetCurrentDirectory() from the bin to the project root.
// This checks for that and sets it to the project root if it is in the bin.
if (projectDirectory.Contains("bin"))
{
    projectDirectory = Path.GetFullPath(Path.Combine(projectDirectory, "../", "../", "../"));
}

string corePath = Path.GetFullPath(Path.Combine(projectDirectory, "../",
    "dymaptic.GeoBlazor.Core"));

// Path to your .csproj file
string projectPath = Path.Combine(corePath, "dymaptic.GeoBlazor.Core.csproj");

// Create an MSBuildWorkspace
using MSBuildWorkspace workspace = MSBuildWorkspace.Create();

// Load the project
Project project = await workspace.OpenProjectAsync(projectPath);

// Get the CSharpCompilation
CSharpCompilation compilation = (CSharpCompilation)(await project.GetCompilationAsync())!;

using MemoryStream ms = new MemoryStream();
EmitResult result = compilation.Emit(ms);

if (!result.Success)
{
    Console.WriteLine("Protobuf compilation failed:");

    foreach (Diagnostic diagnostic in result.Diagnostics)
    {
        Console.WriteLine(diagnostic.ToString());
    }

    return;
}

// Load the assembly from the memory stream
ms.Seek(0, SeekOrigin.Begin);
Assembly protoAssembly = Assembly.Load(ms.ToArray());
Type? protoServiceType = protoAssembly.GetType("dymaptic.GeoBlazor.Core.Serialization.IProtoService");

if (protoServiceType == null)
{
    Console.WriteLine("Protobuf generation failed: IProtoService type not found.");

    return;
}

SchemaGenerator generator = new();

MethodInfo? method = typeof(SchemaGenerator).GetMethod("GetSchema", 
    BindingFlags.Public | BindingFlags.Instance, 
    null, 
    Type.EmptyTypes, 
    null);
MethodInfo getSchemaMethod = method!.MakeGenericMethod(protoServiceType);
string schema = (string)getSchemaMethod.Invoke(generator, null)!;

string outputPath = Path.Combine(corePath, "wwwroot", "geoblazor.proto");
await using StreamWriter writer = new(outputPath);
await writer.WriteAsync(schema);
Console.WriteLine($"Protobuf schema written to {outputPath}");