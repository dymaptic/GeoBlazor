using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Runtime.Serialization;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;

public class LocalizationTests: TestRunnerBase
{
    [TestMethod]
    public void TestCanDeserializeAmericanDoubleAttribute()
    {
        string originalCulture = Thread.CurrentThread.CurrentCulture.Name;
        SetCulture("en-US");
        AttributeSerializationRecord doubleAttribute = new("Value", "1.1", "[object Number]");
        AttributesDictionary attributes = new([doubleAttribute]);
        Assert.AreEqual(1.1, attributes["Value"]);
        SetCulture(originalCulture);
    }
    
    [TestMethod]
    public void TestCanDeserializeEuropeanDoubleAttribute()
    {
        string originalCulture = Thread.CurrentThread.CurrentCulture.Name;
        SetCulture("de-DE");
        AttributeSerializationRecord doubleAttribute = new("Value", "1,1", "[object Number]");
        AttributesDictionary attributes = new([doubleAttribute]);
        Assert.AreEqual(1.1, attributes["Value"]);
        SetCulture(originalCulture);
    }
    
    [TestMethod]
    public void TestDeserializeAmericanDoubleAttributeInEuropeanCultureFails()
    {
        string originalCulture = Thread.CurrentThread.CurrentCulture.Name;
        SetCulture("de-DE");
        AttributeSerializationRecord doubleAttribute = new("Value", "1.1", "[object Number]");

        Assert.ThrowsException<SerializationException>(() =>
        {
            AttributesDictionary _ = new([doubleAttribute]);
        });
        SetCulture(originalCulture);
    }

    private void SetCulture(string cultureName)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
    }
}