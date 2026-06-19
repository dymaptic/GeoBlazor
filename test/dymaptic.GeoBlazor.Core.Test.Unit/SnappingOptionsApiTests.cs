using dymaptic.GeoBlazor.Core.Components;
using System.Reflection;

namespace dymaptic.GeoBlazor.Core.Test.Unit;

/// <summary>
///     Public-API contract tests for <see cref="SnappingOptions"/>.
///     The 4.5.x release dropped the runtime setter methods (and collection helpers) from the
///     generated component — <c>SnappingOptions.gb.cs</c> was truncated right after the getters —
///     breaking consumers who toggled snapping / grid snapping at runtime
///     (<c>SetEnabled</c>, <c>SetGridEnabled</c>, etc.).
///     These tests lock in the full runtime public API surface (every setter, every parameter, and
///     the collection helpers) so a future code-generation split cannot silently remove it again.
/// </summary>
[TestClass]
public class SnappingOptionsApiTests
{
    private static readonly Type SnappingOptionsType = typeof(SnappingOptions);

    // --- Runtime setters (the whole region was dropped by the 4.5.x truncation) ---

    [TestMethod]
    [DataRow("SetEnabled")]
    [DataRow("SetGridEnabled")]
    [DataRow("SetFeatureEnabled")]
    [DataRow("SetSelfEnabled")]
    [DataRow("SetAttributeRulesEnabled")]
    public void HasNullableBoolSetter(string methodName)
    {
        AssertRuntimeSetter(methodName, typeof(bool?));
    }

    [TestMethod]
    public void HasDistanceSetter()
    {
        AssertRuntimeSetter("SetDistance", typeof(double?));
    }

    [TestMethod]
    public void HasFeatureSourcesSetter()
    {
        AssertRuntimeSetter("SetFeatureSources", typeof(IReadOnlyList<FeatureSnappingLayerSource>));
    }

    private static void AssertRuntimeSetter(string methodName, Type parameterType)
    {
        MethodInfo? method = SnappingOptionsType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.Instance, [parameterType]);

        Assert.IsNotNull(method,
            $"SnappingOptions.{methodName}({parameterType.Name}) must exist for runtime configuration (regression from 4.5.x).");
        Assert.AreEqual(typeof(Task), method.ReturnType,
            $"SnappingOptions.{methodName} should return Task.");
    }

    // --- Collection helpers (also dropped by the truncation) ---

    [TestMethod]
    [DataRow("AddToFeatureSources")]
    [DataRow("RemoveFromFeatureSources")]
    public void HasFeatureSourcesCollectionHelper(string methodName)
    {
        MethodInfo? method = SnappingOptionsType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.Instance, [typeof(FeatureSnappingLayerSource[])]);

        Assert.IsNotNull(method,
            $"SnappingOptions.{methodName}(params FeatureSnappingLayerSource[]) must exist (regression from 4.5.x).");
        Assert.AreEqual(typeof(Task), method.ReturnType,
            $"SnappingOptions.{methodName} should return Task.");
    }

    // --- Public properties / Blazor parameters ---

    [TestMethod]
    [DataRow("Enabled")]
    [DataRow("GridEnabled")]
    [DataRow("FeatureEnabled")]
    [DataRow("SelfEnabled")]
    [DataRow("AttributeRulesEnabled")]
    public void HasNullableBoolParameter(string propertyName)
    {
        AssertParameter(propertyName, typeof(bool?));
    }

    [TestMethod]
    public void HasDistanceParameter()
    {
        AssertParameter("Distance", typeof(double?));
    }

    [TestMethod]
    public void HasFeatureSourcesParameter()
    {
        AssertParameter("FeatureSources", typeof(IReadOnlyList<FeatureSnappingLayerSource>));
    }

    private static void AssertParameter(string propertyName, Type propertyType)
    {
        PropertyInfo? property = SnappingOptionsType.GetProperty(propertyName,
            BindingFlags.Public | BindingFlags.Instance);

        Assert.IsNotNull(property,
            $"SnappingOptions.{propertyName} property must exist (regression from 4.5.x).");
        Assert.AreEqual(propertyType, property.PropertyType,
            $"SnappingOptions.{propertyName} should be of type {propertyType.Name}.");
        Assert.IsTrue(property.CanRead && property.CanWrite,
            $"SnappingOptions.{propertyName} should be readable and writable.");
    }

    // --- Behavioral: setters update local state before render ---

    [TestMethod]
    public async Task Setters_UpdateLocalProperty_BeforeRender()
    {
        // Without a JS runtime the setters should still update the local value (used for binding /
        // initial render). The customer reported that even binding Enabled "didn't take effect".
        SnappingOptions options = new();

        await options.SetEnabled(true);
        Assert.IsTrue(options.Enabled.GetValueOrDefault(), "SetEnabled should update the local Enabled value.");

        await options.SetGridEnabled(true);
        Assert.IsTrue(options.GridEnabled.GetValueOrDefault(), "SetGridEnabled should update the local GridEnabled value.");
    }
}
