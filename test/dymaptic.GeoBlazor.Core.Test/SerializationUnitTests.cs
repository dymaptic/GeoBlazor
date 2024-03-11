using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Symbols;
using dymaptic.GeoBlazor.Core.Objects;
using ProtoBuf;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Point = dymaptic.GeoBlazor.Core.Components.Geometries.Point;


namespace dymaptic.GeoBlazor.Core.Test;

[TestClass]
public class SerializationUnitTests
{
    [TestMethod]
    public void SerializeGraphicToJson()
    {
        var graphic = new Graphic(new Point(_random.NextDouble() * 10 + 11.0,
                _random.NextDouble() * 10 + 50.0),
            new SimpleMarkerSymbol(new Outline(new MapColor("green")), new MapColor("red"), 10),
            new PopupTemplate("Test", "Test Content<br/>{testString}<br/>{testNumber}", new[] { "*" }),
            new AttributesDictionary(new Dictionary<string, object?> { { "testString", "test" }, { "testNumber", 123 } }));
        var sw = Stopwatch.StartNew();
        string json = JsonSerializer.Serialize(graphic.ToSerializationRecord());
        byte[] data = Encoding.UTF8.GetBytes(json);
        sw.Stop();
        Console.WriteLine($"SerializeGraphicToJson: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Size: {data.Length} bytes");
    }

    [TestMethod]
    public void SerializeToProtobuf()
    {
        var graphic = new Graphic(new Point(_random.NextDouble() * 10 + 11.0,
                _random.NextDouble() * 10 + 50.0),
            new SimpleMarkerSymbol(new Outline(new MapColor("green")), new MapColor("red"), 10),
            new PopupTemplate("Test", "Test Content<br/>{testString}<br/>{testNumber}", new[] { "*" }),
            new AttributesDictionary(new Dictionary<string, object?> { { "testString", "test" }, { "testNumber", 123 } }));
        var sw = Stopwatch.StartNew();
        ProtoGraphicCollection collection = new(new[] { graphic.ToSerializationRecord() });
        using MemoryStream ms = new();
        Serializer.Serialize(ms, collection);
        byte[] data = ms.ToArray();
        sw.Stop();
        Console.WriteLine($"SerializeGraphicToJson: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Size: {data.Length} bytes");
    }

    private readonly Random _random = new();
}