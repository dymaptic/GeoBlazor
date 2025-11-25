using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Symbols;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Serialization;
using ProtoBuf;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Point = dymaptic.GeoBlazor.Core.Components.Geometries.Point;


namespace dymaptic.GeoBlazor.Core.Test.Unit;

[TestClass]
public class SerializationUnitTests
{
    [TestMethod]
    public void SerializeGraphicToJson()
    {
        var graphic = new Graphic(new Point(_random.NextDouble() * 10 + 11.0,
                _random.NextDouble() * 10 + 50.0),
            new SimpleMarkerSymbol(new Outline(new MapColor("green")), new MapColor("red"), 10),
            new PopupTemplate("Test", "Test Content<br/>{testString}<br/>{testNumber}", ["*"]),
            new AttributesDictionary(
                new Dictionary<string, object?> { { "testString", "test" }, { "testNumber", 123 } }));
        var sw = Stopwatch.StartNew();
        string json = JsonSerializer.Serialize(graphic.ToSerializationRecord());
        byte[] data = Encoding.UTF8.GetBytes(json);
        sw.Stop();
        Console.WriteLine($"SerializeGraphicToJson: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Size: {data.Length} bytes");
    }

    [TestMethod]
    public void RoundTripSerializeGraphicToJson()
    {
        var graphic = new Graphic(new Point(_random.NextDouble() * 10 + 11.0,
                _random.Next() * 10 + 50.0),
            new SimpleMarkerSymbol(new Outline(new MapColor("green")), new MapColor("red"), 10),
            new PopupTemplate("Test",
                "Test Content<br/>{testString}<br/>{testNumber}", 
                outFields: [ "*" ]),
            new AttributesDictionary(
                new Dictionary<string, object?> { { "testString", "test" }, { "testNumber", 123 } }));
        JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };
        string json = JsonSerializer.Serialize(graphic, options);
        Graphic deserialized = JsonSerializer.Deserialize<Graphic>(json, options)!;
        Assert.AreEqual(((Point)graphic.Geometry!).Latitude, ((Point)deserialized.Geometry!).Latitude);
        Assert.AreEqual(((Point)graphic.Geometry!).Longitude, ((Point)deserialized.Geometry!).Longitude);
        Assert.AreEqual(((SimpleMarkerSymbol)graphic.Symbol!).Color, ((SimpleMarkerSymbol)deserialized.Symbol!).Color);
        Assert.AreEqual(((SimpleMarkerSymbol)graphic.Symbol!).Outline!.Color, ((SimpleMarkerSymbol)deserialized.Symbol!).Outline!.Color);
        Assert.AreEqual(((SimpleMarkerSymbol)graphic.Symbol!).Size, ((SimpleMarkerSymbol)deserialized.Symbol!).Size);
        Assert.AreEqual(graphic.PopupTemplate!.Title, deserialized.PopupTemplate!.Title);
        Assert.AreEqual(graphic.Attributes.Count, deserialized.Attributes.Count);
        Assert.AreEqual(graphic.Attributes["testString"], deserialized.Attributes["testString"]);
        Assert.AreEqual(graphic.Attributes["testNumber"], deserialized.Attributes["testNumber"]);
   }

    [TestMethod]
    public void SerializeToProtobuf()
    {
        var graphic = new Graphic(new Point(_random.NextDouble() * 10 + 11.0,
                _random.NextDouble() * 10 + 50.0),
            new SimpleMarkerSymbol(new Outline(new MapColor("green")), new MapColor("red"), 10),
            new PopupTemplate("Test", "Test Content<br/>{testString}<br/>{testNumber}", ["*"]),
            new AttributesDictionary(
                new Dictionary<string, object?> { { "testString", "test" }, { "testNumber", 123 } }));
        var sw = Stopwatch.StartNew();
        GraphicCollectionSerializationRecord collection = new([graphic.ToSerializationRecord()]);
        using MemoryStream ms = new();
        Serializer.Serialize(ms, collection);
        byte[] data = ms.ToArray();
        sw.Stop();
        Console.WriteLine($"SerializeGraphicToJson: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Size: {data.Length} bytes");
    }
    
    [TestMethod]
    public void RoundTripSerializeToProtobuf()
    {
        var graphic = new Graphic(new Point(_random.NextDouble() * 10 + 11.0,
                _random.NextDouble() * 10 + 50.0),
            new SimpleMarkerSymbol(new Outline(new MapColor("green")), new MapColor("red"), 10),
            new PopupTemplate("Test", "Test Content<br/>{testString}<br/>{testNumber}", ["*"]),
            new AttributesDictionary(
                new Dictionary<string, object?> { { "testString", "test" }, { "testNumber", 123 } }));
        GraphicCollectionSerializationRecord collection = new([graphic.ToSerializationRecord()]);
        using MemoryStream ms = new();
        Serializer.Serialize(ms, collection);
        byte[] data = ms.ToArray();
        GraphicCollectionSerializationRecord deserializedCollection =
            Serializer.Deserialize<GraphicCollectionSerializationRecord>((ReadOnlyMemory<byte>)data);
        Graphic deserialized = deserializedCollection.Items![0].FromSerializationRecord()!;
        Assert.AreEqual(((Point)graphic.Geometry!).Latitude, ((Point)deserialized!.Geometry!).Latitude);
        Assert.AreEqual(((Point)graphic.Geometry!).Longitude, ((Point)deserialized.Geometry!).Longitude);
        Assert.AreEqual(((SimpleMarkerSymbol)graphic.Symbol!).Color, ((SimpleMarkerSymbol)deserialized.Symbol!).Color);
        Assert.AreEqual(((SimpleMarkerSymbol)graphic.Symbol!).Outline!.Color, ((SimpleMarkerSymbol)deserialized.Symbol!).Outline!.Color);
        Assert.AreEqual(((SimpleMarkerSymbol)graphic.Symbol!).Size, ((SimpleMarkerSymbol)deserialized.Symbol!).Size);
        Assert.AreEqual(graphic.PopupTemplate!.Title, deserialized.PopupTemplate!.Title);
        Assert.AreEqual(graphic.Attributes.Count, deserialized.Attributes.Count);
        Assert.AreEqual(graphic.Attributes["testString"], deserialized.Attributes["testString"]);
        Assert.AreEqual(graphic.Attributes["testNumber"], deserialized.Attributes["testNumber"]);
    }

    [TestMethod]
    public void DeserializePortal()
    {
        string portalJson = File.ReadAllText("Portal.json");
        Portal portal = JsonSerializer.Deserialize<Portal>(portalJson)!;
        Assert.IsNotNull(portal);
    }

    [TestMethod]
    public void DeserializePortalWithInvalidRotatorPanels()
    {
        string invalidJson =
          """
          {
              "rotatorPanels": {
                "id": "this is one object not an array"
              }
          }
          """;
        Portal portal = JsonSerializer.Deserialize<Portal>(invalidJson)!;
        Assert.IsNotNull(portal);
        Assert.IsNull(portal.RotatorPanels);
    }
    
    [TestMethod]
    public void DeserializePortalWithEmptyRotatorPanels()
    {
      string invalidJson =
        """
        {
            "rotatorPanels": []
        }
        """;
      Portal portal = JsonSerializer.Deserialize<Portal>(invalidJson)!;
      Assert.IsNotNull(portal);
      Assert.IsNull(portal.RotatorPanels);
    }
    
    [TestMethod]
    public void DeserializePortalWithEmptyStringAsRotatorPanels()
    {
      string invalidJson =
        """
        {
            "rotatorPanels": ""
        }
        """;
      Portal portal = JsonSerializer.Deserialize<Portal>(invalidJson)!;
      Assert.IsNotNull(portal);
      Assert.IsNull(portal.RotatorPanels);
    }

    [TestMethod]
    public void DeserializeWFSCapabilities()
    {
        string json = File.ReadAllText("WFSCapabilities.json");
        WFSCapabilities capabilities = JsonSerializer.Deserialize<WFSCapabilities>(json, 
            GeoBlazorSerialization.JsonSerializerOptions)!;
        Assert.IsNotNull(capabilities.FeatureTypes);
        Assert.IsTrue(capabilities.FeatureTypes!.Count > 0);
    }

    private readonly Random _random = new();
}