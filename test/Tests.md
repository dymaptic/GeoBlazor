# GeoBlazor Tests

## dymaptic.GeoBlazor.Core.Test

This library includes unit tests, integration tests, and Playwright automation tests.
The playwright tests attempt to run through the `Samples` application and verify all the
pages and actions. Unfortunately, this is long-running and brittle. It is recommended
instead to use the Blazor Test Runner.

## Blazor Test Runner

This consists of 3 libraries, just like the samples:
- dymaptic.GeoBlazor.Core.Test.Blazor.Shared: Includes all the test runner logic and tests.
- dymaptic.GeoBlazor.Core.Test.Blazor.Server: Runner for testing with Blazor Server.
- dymaptic.GeoBlazor.Core.Test.Blazor.Wasm: Runner for testing with Blazor WebAssembly.

The test runner is a Blazor application that runs the tests in the browser. It is
designed to mimic an IDE test runner, yet you can also see the maps in the view.

### Running the Test Runner

To run the test runner, simply run `dymaptic.GeoBlazor.Core.Test.Server` or `dymaptic.GeoBlazor.Core.Test.Wasm`.
You will see a web page in the browser with options for running tests, either all together, by class, or individually.
Errors are displayed inline with the tests, and include a full stack trace.

### Creating a Blazor Test Runner Test

1. Create a new class in `dymaptic.GeoBlazor.Core.Test.Blazor.Shared/Components` that inherits from `BlazorTestBase`
   and has the following code.

```csharp
@inherits BlazorTestBase

@{
    base.BuildRenderTree(__builder);
}

@code {
    
}
```

2. In the `@code` block, create public async methods with the MSTest `[TestMethod]` attribute. Add a parameter,
   `Action renderHandler`, which will be provided by the testrunner.

```csharp
@code {
    [TestMethod]
    public async Task TestMethod1(Action renderHandler)
    {
        Assert.IsTrue(true);
    }
}
```

3. Add code to render the map. The key method is `AddMapRenderFragment`. This method takes a render fragment,
   which should be a `MapView` component. You must define the `class` and `OnViewRendered` parameters. The 
   inner contents of the `MapView` are up to your individual test.

```html
@code {
    [TestMethod]
    public async Task TestMethod1(Action renderHandler)
    {
        AddMapRenderFragment(
            @<MapView class="map-view" OnViewRendered="renderHandler">
                <Map ArcGISDefaultBasemap="arcgis-imagery" />
            </MapView>);

        Assert.IsTrue(true);
    }
}
```

4. Call `await WaitForMapToRender();`. This will render the `MapView` fragment onto the web test page.

```csharp
[TestMethod]
public async Task TestMethod1(Action renderHandler)
{
    AddMapRenderFragment(
        @<MapView class="map-view" OnViewRendered="renderHandler">
            <Map ArcGISDefaultBasemap="arcgis-imagery" />
        </MapView>);

    await WaitForMapToRender();
    Assert.IsTrue(true);
}
```

5. Add specific asserts. You can add @ref to any map component, and then use that to query parameters or call methods.

```csharp
[TestMethod]
public async Task TestMethod1(Action renderHandler)
{
    MapView? mapView = null;
    AddMapRenderFragment(
        @<MapView @ref="mapView" class="map-view" OnViewRendered="renderHandler">
            <Map ArcGISDefaultBasemap="arcgis-imagery" />
        </MapView>);
    
    await WaitForMapToRender();
    Assert.IsTrue(mapView.MapRendered);
}
```

6. In addition to MSTest Asserts, you can also use the `AssertJavaScript` method to run JavaScript code in the browser
   and assert the result. This is useful for testing the implementation of GeoBlazor in ArcGIS JS. JavaScript asserts 
   are defined in `wwwroot/testRunner.js`, and can be added to as needed. Each one receives the `methodName` to look up
   the `view`, and any `args` passed from the test. Note that because there is a `[CallerMemberName]` parameter after
   the JavaScript function name, you must either define this or use `args: ` before declaring the args for the JavaScript
   function.

```csharp
 [TestMethod]
 public async Task TestCanRenderFeatureLayer(Action renderHandler)
 {
     AddMapRenderFragment(
         @<MapView class="map-view" OnViewRendered="renderHandler">
             <Map>
                 <FeatureLayer Url="https://services.arcgis.com/V6ZHFr6zdgNZuVG0/arcgis/rest/services/TrailRuns/FeatureServer/0" />
             </Map>
         </MapView>);
     await WaitForMapToRender();
     await AssertJavaScript("assertLayerExists", args: "feature");
 }
```