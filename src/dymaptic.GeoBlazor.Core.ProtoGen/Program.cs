using dymaptic.GeoBlazor.Core.ProtoGen;
using ProtoBuf.Grpc.Reflection;

string projectDirectory = Directory.GetCurrentDirectory();
string corePath = Path.GetFullPath(Path.Combine(projectDirectory, "../",
    "GeoBlazor.Pro/GeoBlazor/src/dymaptic.GeoBlazor.Core/"));

// Running from console or from IDE can change the result of Directory.GetCurrentDirectory() from the bin to the project root.
// This checks for that and sets it to the project root if it is in the bin.
if (projectDirectory.Contains("bin"))
{
    projectDirectory = Path.GetFullPath(Path.Combine(projectDirectory, "../", "../", "../"));
    corePath = Path.GetFullPath(Path.Combine(projectDirectory, "../",
        "GeoBlazor.Pro/GeoBlazor/src/dymaptic.GeoBlazor.Core/"));
}

string outputPath = Path.Combine(corePath, "wwwroot", "geoblazor.proto");

SchemaGenerator generator = new();

string schema = generator.GetSchema<IProtoService>();
await using StreamWriter writer = new(outputPath);
await writer.WriteAsync(schema);
Console.WriteLine("Protobuf schema written to geoblazor.proto");