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
        string originalCulture = JsModuleManager.ClientCultureInfo.Name;
        SetCulture("en-US");
        AttributeSerializationRecord doubleAttribute = new("Value", "1.1", "[object Number]");
        AttributesDictionary attributes = new([doubleAttribute]);
        Assert.AreEqual(1.1, attributes["Value"]);
        SetCulture(originalCulture);
    }
    
    [TestMethod]
    public void TestCanDeserializeEuropeanDoubleAttribute()
    {
        string originalCulture = JsModuleManager.ClientCultureInfo.Name;
        SetCulture("de-DE");
        AttributeSerializationRecord doubleAttribute = new("Value", "1,1", "[object Number]");
        AttributesDictionary attributes = new([doubleAttribute]);
        Assert.AreEqual(1.1, attributes["Value"]);
        SetCulture(originalCulture);
    }
    
    [TestMethod]
    public void TestDeserializeAmericanDoubleAttributeInEuropeanCultureReturnsWrongValue()
    {
        string originalCulture = JsModuleManager.ClientCultureInfo.Name;
        SetCulture("de-DE");
        AttributeSerializationRecord doubleAttribute = new("Value", "1.1", "[object Number]");
        AttributesDictionary attributes = new([doubleAttribute]);
        Assert.AreEqual(11.0, attributes["Value"]);
        SetCulture(originalCulture);
    }
    
    [TestMethod]
    public void TestDeserializeEuropeanDoubleAttributeInAmericanCultureReturnsWrongValue()
    {
        string originalCulture = JsModuleManager.ClientCultureInfo.Name;
        SetCulture("en-US");
        AttributeSerializationRecord doubleAttribute = new("Value", "1,1", "[object Number]");
        AttributesDictionary attributes = new([doubleAttribute]);
        Assert.AreEqual(11.0, attributes["Value"]);
        SetCulture(originalCulture);
    }

    private void SetCulture(string cultureName)
    {
        JsModuleManager.ClientCultureInfo = new CultureInfo(cultureName);
    }
}