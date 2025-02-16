using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Exceptions;

namespace dymaptic.GeoBlazor.Core.Test;

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
        Assert.AreEqual(1, component.TestChildrenInCollection!.Count);
    }
    
    [TestMethod]
    public async Task CanUnregisterUnknownChildComponent()
    {
        var child = new TestChildComponent();
        var component = new TestMapComponent
        {
            TestChildComponent = child
        };
        await component.UnregisterChildComponent(child);
        Assert.AreEqual(null, component.TestChildComponent);
    }

    [TestMethod]
    public async Task CanUnregisterUnknownChildComponentInCollection()
    {
        var child = new TestChildInCollection();
        var component = new TestMapComponent()
        {
            TestChildrenInCollection = (List<TestChildInCollection>) [child]
        };
        await component.UnregisterChildComponent(child);
        Assert.AreEqual(0, component.TestChildrenInCollection!.Count);
    }
    
    [TestMethod]
    public async Task RegisteringTypeThatIsNotAChildPropertyThrows()
    {
        var component = new TestMapComponent();
        var notAChildComponent = new NotAChildComponent();
        await Assert.ThrowsExceptionAsync<InvalidChildElementException>(() => 
            component.RegisterChildComponent(notAChildComponent));
    }

    [TestMethod]
    public void CallingValidateRequiredChildrenCascades()
    {
        var child = new TestChildComponent();
        var component = new TestMapComponent
        {
            TestChildComponent = child
        };
        component.ValidateRequiredChildren();
        Assert.IsTrue(child.WasValidated);
    }
    
    [TestMethod]
    public void CallingValidateRequiredChildrenCascadesToCollectionTypes()
    {
        var child = new TestChildInCollection();
        var component = new TestMapComponent
        {
            TestChildrenInCollection = new List<TestChildInCollection>{child}
        };
        component.ValidateRequiredChildren();
        Assert.IsTrue(child.WasValidated);
    }

    public class TestMapComponent : MapComponent
    {
        public TestChildComponent? TestChildComponent { get; set; }

        public IReadOnlyList<TestChildInCollection>? TestChildrenInCollection
        {
            get => _testChildrenInCollection;
            set
            {
                if (value is not null)
                {
                    _testChildrenInCollection = [..value];
                }
            }
        }

        private List<TestChildInCollection> _testChildrenInCollection = [];
    }

    public class TestChildComponent : MapComponent
    {
        public override void ValidateRequiredChildren()
        {
            WasValidated = true;
            base.ValidateRequiredChildren();
        }
        
        public bool WasValidated { get; private set; }
    }

    public class TestChildInCollection : MapComponent
    {
        public override void ValidateRequiredChildren()
        {
            WasValidated = true;
            base.ValidateRequiredChildren();
        }
        
        public bool WasValidated { get; private set; }
    }
    public class NotAChildComponent : MapComponent;
}