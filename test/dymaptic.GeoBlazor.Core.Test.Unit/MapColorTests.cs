using dymaptic.GeoBlazor.Core.Model;
using System.Drawing;


namespace dymaptic.GeoBlazor.Core.Test.Unit;

[TestClass]
public class MapColorTests
{
    [TestMethod]
    public void TestMapColorFromHex()
    {
        string hexColor = "#FF5733"; // Example hex color
        MapColor color = new(hexColor);
        Assert.IsNotNull(color);
        Assert.IsTrue(color.RgbaValues!.SequenceEqual([255, 87, 51, 1]));
    }
    
    [TestMethod]
    public void TestMapColorFromRgba()
    {
        double[] rgbaValues = [255, 87, 51, 1]; // Example RGBA values
        MapColor color = new(rgbaValues);
        Assert.IsNotNull(color);
        Assert.AreEqual("#FF5733FF", color.HexOrNameValue);
    }
    
    [TestMethod]
    public void TestMapColorEquality()
    {
        MapColor color1 = new("#FF5733FF");
        MapColor color2 = new(255, 87, 51, 1); // Same color in different format
        Assert.IsTrue(color1.Equals(color2));
        Assert.IsTrue(color1 == color2);
        Assert.IsFalse(color1 != color2);
    }
    
    [TestMethod]
    public void TestMapColorInequality()
    {
        MapColor color1 = new("#FF5733FF");
        MapColor color2 = new("#33FF57FF"); // Different color
        Assert.IsFalse(color1.Equals(color2));
        Assert.IsFalse(color1 == color2);
        Assert.IsTrue(color1 != color2);
    }
    
    [TestMethod]
    public void TestMapColorToSystemColor()
    {
        MapColor color = new("#FF5733");
        Color? systemColor = color.ToSystemColor();
        Assert.IsNotNull(systemColor);
        Assert.AreEqual(255, systemColor.Value.R);
        Assert.AreEqual(87, systemColor.Value.G);
        Assert.AreEqual(51, systemColor.Value.B);
        Assert.AreEqual(255, systemColor.Value.A);
    }
    
    [TestMethod]
    public void TestMapColorToHex()
    {
        MapColor color = new(255, 87, 51, 1);
        string? hexValue = color.ToHex();
        Assert.AreEqual("#FF5733FF", hexValue);
    }
    
    [TestMethod]
    public void TestMapColorFromHexWithAlpha()
    {
        string hexColor = "#FF573380"; // Example hex color with alpha
        MapColor color = new(hexColor);
        Assert.IsNotNull(color);
        Assert.IsTrue(color.RgbaValues!.SequenceEqual([255, 87, 51, 128.0 / 255.0])); // 80 in hex is 128 in decimal, divided by 255 for alpha
    }
    
    [TestMethod]
    public void TestMapColorFromRgbaWithAlpha()
    {
        double[] rgbaValues = [255, 87, 51, 0.5]; // Example RGBA values with alpha
        MapColor color = new(rgbaValues);
        Assert.IsNotNull(color);
        Assert.AreEqual("#FF57337F", color.HexOrNameValue); // Alpha should be represented in hex
    }
}