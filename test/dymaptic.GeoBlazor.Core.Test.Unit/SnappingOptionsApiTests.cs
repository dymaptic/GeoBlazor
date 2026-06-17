using dymaptic.GeoBlazor.Core.Components;
using System.Reflection;

namespace dymaptic.GeoBlazor.Core.Test.Unit;

/// <summary>
///     Public-API contract tests for <see cref="SnappingOptions"/>.
///     The 4.5.x release dropped the runtime setter methods (and collection helpers) from the
///     generated component — <c>SnappingOptions.gb.cs</c> was truncated right after the getters —
///     breaking consumers who toggled snapping / grid snapping at runtime
///     (<c>SetEnabled</c>, <c>SetGridEnabled</c>, etc.).
///     These tests lock in the public API surface so a future code-generation split cannot
///     silently remove it again.
/// </summary>
[TestClass]
public class SnappingOptionsApiTests
{
    private static readonly Type SnappingOptionsType = typeof(SnappingOptions);

    [TestMethod]
    [DataRow("SetEnabled")]
    [DataRow("SetGridEnabled")]
    [DataRow("SetFeatureEnabled")]
    [DataRow("SetSelfEnabled")]
    public void HasRuntimeNullableBoolSetter(string methodName)
    {
        MethodInfo? method = SnappingOptionsType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.Instance, [typeof(bool?)]);

        Assert.IsNotNull(method,
            $"SnappingOptions.{methodName}(bool?) must exist for runtime snapping toggling (regression from 4.5.x).");
        Assert.AreEqual(typeof(Task), method.ReturnType,
            $"SnappingOptions.{methodName}(bool?) should return Task.");
    }

    [TestMethod]
    [DataRow("Enabled")]
    [DataRow("GridEnabled")]
    [DataRow("FeatureEnabled")]
    [DataRow("SelfEnabled")]
    public void HasNullableBoolParameter(string propertyName)
    {
        PropertyInfo? property = SnappingOptionsType.GetProperty(propertyName,
            BindingFlags.Public | BindingFlags.Instance);

        Assert.IsNotNull(property,
            $"SnappingOptions.{propertyName} property must exist (regression from 4.5.x).");
        Assert.AreEqual(typeof(bool?), property.PropertyType,
            $"SnappingOptions.{propertyName} should be a bool? property.");
        Assert.IsTrue(property.CanRead && property.CanWrite,
            $"SnappingOptions.{propertyName} should be readable and writable.");
    }

    [TestMethod]
    public void SetEnabled_UpdatesLocalProperty_BeforeRender()
    {
        // Without a JS runtime the setter should still update the local value (used for binding /
        // initial render). The customer reported that even binding Enabled "didn't take effect".
        SnappingOptions options = new();

        // Should not throw when there is no JS component yet; should set the local property.
        options.SetEnabled(true).GetAwaiter().GetResult();
        Assert.IsTrue(options.Enabled.GetValueOrDefault(), "SetEnabled should update the local Enabled value.");

        options.SetGridEnabled(true).GetAwaiter().GetResult();
        Assert.IsTrue(options.GridEnabled.GetValueOrDefault(), "SetGridEnabled should update the local GridEnabled value.");
    }
}
