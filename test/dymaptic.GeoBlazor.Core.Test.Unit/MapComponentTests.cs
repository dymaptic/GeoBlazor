using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Exceptions;
using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Test.Unit;

[TestClass]
public class MapComponentTests
{
    [TestMethod]
    public async Task CanRegisterUnknownChildComponent()
    {
        var component = new TestMapComponent();
        var child = new TestChildComponent();
        await component.RegisterChildComponent(child);
        Assert.AreEqual(child, component.TestChildComponent);
    }

    [TestMethod]
    public async Task CanRegisterUnknownChildComponentInCollection()
    {
        var component = new TestMapComponent();
        var child = new TestChildInCollection();
        await component.RegisterChildComponent(child);
        Assert.HasCount(1, component.TestChildrenInCollection!);
    }

    [TestMethod]
    public async Task CanUnregisterUnknownChildComponent()
    {
        var child = new TestChildComponent();
        var component = new TestMapComponent { TestChildComponent = child };
        await component.UnregisterChildComponent(child);
        Assert.IsNull(component.TestChildComponent);
    }

    [TestMethod]
    public async Task CanUnregisterUnknownChildComponentInCollection()
    {
        var child = new TestChildInCollection();
        var component = new TestMapComponent() { TestChildrenInCollection = (List<TestChildInCollection>)[child] };
        await component.UnregisterChildComponent(child);
        Assert.IsEmpty(component.TestChildrenInCollection!);
    }

    [TestMethod]
    public async Task RegisteringTypeThatIsNotAChildPropertyThrows()
    {
        var component = new TestMapComponent();
        var notAChildComponent = new NotAChildComponent();

        await Assert.ThrowsAsync<InvalidChildElementException>(() =>
            component.RegisterChildComponent(notAChildComponent));
    }

    [TestMethod]
    public void CallingValidateRequiredChildrenCascades()
    {
        var child = new TestChildComponent();
        var component = new TestMapComponent { TestChildComponent = child };
        component.ValidateRequiredChildren();
        Assert.IsTrue(child.WasValidated);
    }

    [TestMethod]
    public void CallingValidateRequiredChildrenCascadesToCollectionTypes()
    {
        var child = new TestChildInCollection();
        var component = new TestMapComponent { TestChildrenInCollection = new List<TestChildInCollection> { child } };
        component.ValidateRequiredChildren();
        Assert.IsTrue(child.WasValidated);
    }

    [TestMethod]
    public async Task SetLayer_UsesCoreSetLayerHelper()
    {
        var coreJsModule = new TestJsObjectReference();
        var jsComponentReference = new TestJsObjectReference();
        var component = new TestMapComponent
        {
            CoreJsModule = coreJsModule,
            JsComponentReference = jsComponentReference
        };
        var layer = new GraphicsLayer();

        await component.SetLayer(layer);

        Assert.HasCount(1, coreJsModule.Invocations);
        TestJsInvocation invocation = coreJsModule.Invocations[0];
        Assert.AreEqual("setLayer", invocation.Identifier);
        Assert.AreSame(jsComponentReference, invocation.Args[0]);
        Assert.AreSame(layer, invocation.Args[1]);
        Assert.IsEmpty(jsComponentReference.Invocations,
            "SetLayer must not invoke a missing setLayer method on the JS component reference.");
    }

    private class TestMapComponent : MapComponent
    {
        public TestChildComponent? TestChildComponent { get; set; }

        public IReadOnlyList<TestChildInCollection>? TestChildrenInCollection
        {
            get => _testChildrenInCollection;
            init
            {
                if (value is not null)
                {
                    _testChildrenInCollection = [..value];
                }
            }
        }

        public override async Task RegisterChildComponent(MapComponent child)
        {
            switch (child)
            {
                case TestChildComponent testChild:
                    TestChildComponent = testChild;

                    break;
                case TestChildInCollection testChildInCollection:
                    _testChildrenInCollection.Add(testChildInCollection);

                    break;
                default:
                    await base.RegisterChildComponent(child);

                    break;
            }
        }

        public override async Task UnregisterChildComponent(MapComponent child)
        {
            switch (child)
            {
                case TestChildComponent _:
                    TestChildComponent = null;

                    break;
                case TestChildInCollection testChildInCollection:
                    _testChildrenInCollection.Remove(testChildInCollection);

                    break;
                default:
                    await base.UnregisterChildComponent(child);

                    break;
            }
        }

        public override void ValidateRequiredChildren()
        {
            base.ValidateRequiredChildren();

            TestChildComponent?.ValidateRequiredChildren();

            if (TestChildrenInCollection is not null)
            {
                foreach (TestChildInCollection child in TestChildrenInCollection)
                {
                    child.ValidateRequiredChildren();
                }
            }
        }

        private readonly List<TestChildInCollection> _testChildrenInCollection = [];
    }

    private class TestChildComponent : MapComponent
    {
        public bool WasValidated { get; private set; }

        public override void ValidateRequiredChildren()
        {
            WasValidated = true;
            base.ValidateRequiredChildren();
        }
    }

    private class TestChildInCollection : MapComponent
    {
        public bool WasValidated { get; private set; }

        public override void ValidateRequiredChildren()
        {
            WasValidated = true;
            base.ValidateRequiredChildren();
        }
    }

    private class NotAChildComponent : MapComponent;

    private sealed class TestJsObjectReference : IJSObjectReference
    {
        public List<TestJsInvocation> Invocations { get; } = [];

        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
        {
            Invocations.Add(new TestJsInvocation(identifier, args ?? []));

            return ValueTask.FromResult(default(TValue)!);
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args)
        {
            Invocations.Add(new TestJsInvocation(identifier, args ?? []));

            return ValueTask.FromResult(default(TValue)!);
        }
    }

    private sealed record TestJsInvocation(string Identifier, object?[] Args);
}
