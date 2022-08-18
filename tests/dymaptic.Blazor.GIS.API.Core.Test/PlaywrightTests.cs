using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System.Diagnostics;


namespace dymaptic.Blazor.GIS.API.Core.Test;

[TestClass]
public class PlaywrightTests
{
    [TestMethod]
    public async Task TestMethod1()
    {
        StartServer();
        IPlaywright playwright = await Playwright.CreateAsync()!;
        IBrowser browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        IPage page = await browser.NewPageAsync();
        // Go to https://localhost:7255/
        await page.GotoAsync("https://localhost:7255/");
        var apiKey = new ConfigurationBuilder().AddUserSecrets<PlaywrightTests>().Build()["ArcGISApiKey"];
        await Task.Delay(2000);
        await page.Locator("#api-key-field").FillAsync(apiKey!);
        await page.Locator("#api-key-field").PressAsync("Enter");
        await Task.Delay(2000);
        
        // Click text=Latitude: >> input[type="number"]
        await page.Locator("text=Latitude: >> input[type=\"number\"]").ClickAsync();
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Navigation1.png" });
        
        // Fill text=Latitude: >> input[type="number"]
        await page.Locator("text=Latitude: >> input[type=\"number\"]").FillAsync("34.023");
        // Press Tab
        await page.Locator("text=Latitude: >> input[type=\"number\"]").PressAsync("Tab");
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Navigation2.png" });
        
        // Click text=Longitude: >> input[type="number"]
        await page.Locator("text=Longitude: >> input[type=\"number\"]").ClickAsync();
        // Fill text=Longitude: >> input[type="number"]
        await page.Locator("text=Longitude: >> input[type=\"number\"]").FillAsync("-118.905");
        // Press Tab
        await page.Locator("text=Longitude: >> input[type=\"number\"]").PressAsync("Tab");
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Navigation3.png" });
        
        // Fill text=Zoom: >> input[type="number"]
        await page.Locator("text=Zoom: >> input[type=\"number\"]").FillAsync("12");
        // Press Tab
        await page.Locator("text=Zoom: >> input[type=\"number\"]").PressAsync("Tab");
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Navigation4.png" });        
        
        // Fill text=Rotation (deg): >> input[type="number"]
        await page.Locator("text=Rotation (deg): >> input[type=\"number\"]").FillAsync("30");
        // Press Tab
        await page.Locator("text=Rotation (deg): >> input[type=\"number\"]").PressAsync("Tab");
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Navigation4.png" });
        
        Task pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/");
        
        // Click text=Razor Source File
        await page.Locator("text=Razor Source File").ClickAsync();
        await pageLoadTask;
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Navigation_Source.png" });
        
        // Click text=Drawing
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/drawing");
        await page.Locator("text=Drawing").ClickAsync();
        await pageLoadTask;
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing1.png" });
        
        // Click text=Draw a Point >> span
        await page.Locator("text=Draw a Point >> span").ClickAsync();
        // Click text=Longitude: Latitude: Draw >> button
        await page.Locator("text=Longitude: Latitude: Draw >> button").ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing2.png" });
        
        // Click text=Longitude: >> input[type="number"]
        await page.Locator("text=Longitude: >> input[type=\"number\"]").ClickAsync();
        // Fill text=Longitude: >> input[type="number"]
        await page.Locator("text=Longitude: >> input[type=\"number\"]").FillAsync("-118.7");
        // Press Tab
        await page.Locator("text=Longitude: >> input[type=\"number\"]").PressAsync("Tab");
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing3.png" });
        
        // Press ArrowDown
        await page.Locator("text=Latitude: >> input[type=\"number\"]").PressAsync("ArrowDown");
        // Press ArrowDown
        await page.Locator("text=Latitude: >> input[type=\"number\"]").PressAsync("ArrowDown");
        // Press ArrowUp
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing4.png" });
        
        // Click text=Longitude: Latitude: Remove >> button
        await page.Locator("text=Longitude: Latitude: Remove >> button").ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing5.png" });
        
        // Click text=Draw a Line
        await page.Locator("text=Draw a Line").ClickAsync();
        // Click button:has-text("Draw") >> nth=1
        await page.Locator("button:has-text(\"Draw\")").Nth(1).ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing6.png" });
        
        // Click tr:nth-child(2) > td:nth-child(2) > input >> nth=0
        await page.Locator("tr:nth-child(2) > td:nth-child(2) > input").First.ClickAsync();
        // Press ArrowDown
        await page.Locator("tr:nth-child(2) > td:nth-child(2) > input").First.PressAsync("ArrowDown");
        // Press ArrowDown
        await page.Locator("tr:nth-child(2) > td:nth-child(2) > input").First.PressAsync("ArrowDown");
        // Press ArrowDown
        await page.Locator("tr:nth-child(2) > td:nth-child(2) > input").First.PressAsync("ArrowDown");
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing7.png" });
        
        // Click text=Add Pt >> nth=0
        await page.Locator("text=Add Pt").First.ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing8.png" });
        
        // Click tr:nth-child(4) > td:nth-child(2) > input >> nth=0
        await page.Locator("tr:nth-child(4) > td:nth-child(2) > input").First.ClickAsync();
        // Press ArrowUp
        await page.Locator("tr:nth-child(4) > td:nth-child(2) > input").First.PressAsync("ArrowUp");
        // Press ArrowUp
        await page.Locator("tr:nth-child(4) > td:nth-child(2) > input").First.PressAsync("ArrowUp");
        // Press ArrowUp
        await page.Locator("tr:nth-child(4) > td:nth-child(2) > input").First.PressAsync("ArrowUp");
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing9.png" });
        
        // Click text=Remove >> nth=0
        await page.Locator("text=Remove").First.ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing10.png" });
        
        // Click text=Draw a Polygon
        await page.Locator("text=Draw a Polygon").ClickAsync();
        // Click button:has-text("Draw") >> nth=2
        await page.Locator("button:has-text(\"Draw\")").Nth(2).ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing11.png" });
        
        // Click text=Add Pt >> nth=1
        await page.Locator("text=Add Pt").Nth(1).ClickAsync();
        // Click tr:nth-child(6) > td:nth-child(2) > input
        await page.Locator("tr:nth-child(6) > td:nth-child(2) > input").ClickAsync();
        // Press ArrowUp
        await page.Locator("tr:nth-child(6) > td:nth-child(2) > input").PressAsync("ArrowUp");
        // Press ArrowUp
        await page.Locator("tr:nth-child(6) > td:nth-child(2) > input").PressAsync("ArrowUp");
        // Press ArrowUp
        await page.Locator("tr:nth-child(6) > td:nth-child(2) > input").PressAsync("ArrowUp");
        // Press ArrowUp
        await page.Locator("tr:nth-child(6) > td:nth-child(2) > input").PressAsync("ArrowUp");
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing12.png" });
        
        // Click text=Remove Pt >> nth=1
        await page.Locator("text=Remove Pt").Nth(1).ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing13.png" });
        
        // Click text=Remove >> nth=1
        await page.Locator("text=Remove").Nth(1).ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing14.png" });
        
        // Click text=Razor Source File
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/drawing");
        await page.Locator("text=Razor Source File").ClickAsync();
        await pageLoadTask;

        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Drawing_Source.png" });
        
        // Click text=Scene >> nth=0
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/scene");
        await page.Locator("text=Scene").First.ClickAsync();
        await pageLoadTask;
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Scene.png" });

        // Click text=Widgets
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/widgets");
        await page.Locator("text=Widgets").ClickAsync();
        await pageLoadTask;
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets1.png" });
        
        // Check text=Locator: >> input[type="checkbox"]
        await page.Locator("text=Locator: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets2.png" });
        
        // Check text=Search: >> input[type="checkbox"]
        await page.Locator("text=Search: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets3.png" });
        
        // Check text=Basemap Toggle: >> input[type="checkbox"]
        await page.Locator("text=Basemap Toggle: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets4.png" });
        
        // Check text=Basemap Gallery: >> input[type="checkbox"]
        await page.Locator("text=Basemap Gallery: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets5.png" });
        
        // Check text=Legend: >> input[type="checkbox"]
        await page.Locator("text=Legend: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets6.png" });
        
        // Check text=Scale Bar: >> input[type="checkbox"]
        await page.Locator("text=Scale Bar: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets7.png" });
        
        // Uncheck text=Legend: >> input[type="checkbox"]
        await page.Locator("text=Legend: >> input[type=\"checkbox\"]").UncheckAsync();
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets8.png" });
        
        // Check text=Legend: >> input[type="checkbox"]
        await page.Locator("text=Legend: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets9.png" });
        
        // Click [aria-label="Find my location"]
        await page.Locator("[aria-label=\"Find my location\"]").ClickAsync();
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets10.png" });
        
        // Click [placeholder="Find address or place"]
        await page.Locator("[placeholder=\"Find address or place\"]").ClickAsync();
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets11.png" });
        
        // Fill [placeholder="Find address or place"]
        await page.Locator("[placeholder=\"Find address or place\"]").FillAsync("1600 Pennsylvania Ave, Washington, DC");
        // Press Enter
        await page.Locator("[placeholder=\"Find address or place\"]").PressAsync("Enter");
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets12.png" });
        
        // Click [aria-label="Close"]
        await page.Locator("[aria-label=\"Close\"]").ClickAsync();
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets13.png" });
        
        // Click li[role="menuitem"]:has-text("Imagery Hybrid")
        await page.Locator("li[role=\"menuitem\"]:has-text(\"Imagery Hybrid\")").ClickAsync();
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets14.png" });
        
        // Click .esri-basemap-gallery__item-thumbnail >> nth=0
        await page.Locator(".esri-basemap-gallery__item-thumbnail").First.ClickAsync();
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets15.png" });

        // Click text=Razor Source File
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/widgets");
        await page.Locator("text=Razor Source File").ClickAsync();
        await pageLoadTask;
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Widgets_Source.png" });
        
        // Click text=Basemaps
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/basemaps");
        await page.Locator("text=Basemaps").ClickAsync();
        await pageLoadTask;
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "BaseMaps1.png" });
        
        // Check text=From Portal Id >> input[name="basemap-type"]
        await page.Locator("text=From Portal Id >> input[name=\"basemap-type\"]").CheckAsync();
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "BaseMaps2.png" });
        
        // Check text=From Tile Layers >> input[name="basemap-type"]
        await page.Locator("text=From Tile Layers >> input[name=\"basemap-type\"]").CheckAsync();
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "BaseMaps3.png" });
        
        // Click text=Razor Source File
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/basemaps");
        await page.Locator("text=Razor Source File").ClickAsync();
        await pageLoadTask;
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "BaseMaps_Source.png" });
        
        // Click text=Feature Layers
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/feature-layers");
        await page.Locator("text=Feature Layers").ClickAsync();
        await pageLoadTask;
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "FeatureLayers1.png" });

        // Check text=Show Trailheads Points Layer: >> input[name="points"]
        await page.Locator("text=Show Trailheads Points Layer: >> input[name=\"points\"]").CheckAsync();
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "FeatureLayers2.png" });
        
        // Check text=Show Trailheads Lines Layer: >> input[name="points"]
        await page.Locator("text=Show Trailheads Lines Layer: >> input[name=\"points\"]").CheckAsync();
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "FeatureLayers3.png" });
        
        // Check text=Show Trailheads Lines With Elevation Style Renderer: >> input[name="points"]
        await page.Locator("text=Show Trailheads Lines With Elevation Style Renderer: >> input[name=\"points\"]").CheckAsync();
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "FeatureLayers4.png" });
        
        // Check text=Show Trailheads Lines With Bike Trails Styled: >> input[name="points"]
        await page.Locator("text=Show Trailheads Lines With Bike Trails Styled: >> input[name=\"points\"]").CheckAsync();
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "FeatureLayers5.png" });
        
        // Check text=Show Trailheads Polygons Layer: >> input[name="points"]
        await page.Locator("text=Show Trailheads Polygons Layer: >> input[name=\"points\"]").CheckAsync();
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "FeatureLayers6.png" });
        
        // Click text=Vector Layer
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/vector-layer");
        await page.Locator("text=Vector Layer").ClickAsync();
        await pageLoadTask;
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "VectorLayer.png" });
        
        // Click text=Razor Source File
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/vector-layer");
        await page.Locator("text=Razor Source File").ClickAsync();
        await pageLoadTask;
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "VectorLayer_Source.png" });
        
        // Click text=Web Map
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/web-map");
        await page.Locator("text=Web Map").ClickAsync();
        await pageLoadTask;
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "WebMap1.png" });

        // Click text=Web Scene
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/web-scene");
        await page.Locator("text=Web Scene").ClickAsync();
        await pageLoadTask;
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "WebScene1.png" });
        
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/sql-query");
        await page.Locator("text=SQL Query").ClickAsync();
        await pageLoadTask;
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "SqlQuery1.png" });

        // Select UseType = 'Residential'
        await page.Locator("select").SelectOptionAsync(new[] { "UseType = 'Residential'" });
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "SqlQuery2.png" });
        
        // Select UseType = 'Irrigated Farm'
        await page.Locator("select").SelectOptionAsync(new[] { "UseType = 'Irrigated Farm'" });
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "SqlQuery3.png" });
        // Select TaxRateArea = 08637
        await page.Locator("select").SelectOptionAsync(new[] { "TaxRateArea = 08637" });
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "SqlQuery4.png" });
        // Select Roll_LandValue < 1000000
        await page.Locator("select").SelectOptionAsync(new[] { "Roll_LandValue < 1000000" });
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "SqlQuery5.png" });
        
        // Click text=Razor Source File
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/sql-query");
        await page.Locator("text=Razor Source File").ClickAsync();
        await pageLoadTask;
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "SqlQuery_Source.png" });
        
        // Click text=SQL Filter Query
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/sql-filter-query");
        await page.Locator("text=SQL Filter Query").ClickAsync();
        await pageLoadTask;
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "SqlFilterQuery1.png" });
        
        // Select Roll_LandValue < 200000
        await page.Locator("select").SelectOptionAsync(new[] { "Roll_LandValue < 200000" });
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "SqlFilterQuery2.png" });
        
        // Select Bedrooms5 > 0
        await page.Locator("select").SelectOptionAsync(new[] { "Bedrooms5 > 0" });
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "SqlFilterQuery3.png" });
        
        // Select Roll_RealEstateExemp > 0
        await page.Locator("select").SelectOptionAsync(new[] { "Roll_RealEstateExemp > 0" });
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "SqlFilterQuery4.png" });
        
        // Click text=Place Selector
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/place-selector");
        await page.Locator("text=Place Selector").ClickAsync();
        await pageLoadTask;
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "PlaceSelector1.png" });
        
        // Select Coffee shop
        await page.Locator("select").SelectOptionAsync(new[] { "Coffee shop" });
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "PlaceSelector2.png" });
        
        // Click canvas
        await page.Mouse.ClickAsync(789, 299);
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "PlaceSelector3.png" });
        
        // Click canvas
        await page.Mouse.ClickAsync(772, 332);
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "PlaceSelector4.png" });
        
        // Click text=Routing
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/routing");
        await page.Locator("text=Routing").ClickAsync();
        await pageLoadTask;
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Routing1.png" });
        
        // Click canvas
        await page.Mouse.ClickAsync(441, 320);
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Routing2.png" });
        
        // Click canvas
        await page.Mouse.ClickAsync(954, 348);
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Routing3.png" });
        
        // Click text=Service Areas
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/service-areas");
        await page.Locator("text=Service Areas").ClickAsync();
        await pageLoadTask;
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "ServiceAreas1.png" });
        
        // Click canvas
        await page.Mouse.ClickAsync(505, 339);
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "ServiceAreas2.png" });
        
        // Click canvas
        await page.Mouse.ClickAsync(950, 442);
        await Task.Delay(2000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "ServiceAreas3.png" });
        
        // Click text=Razor Source File
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/service-areas");
        await page.Locator("text=Razor Source File").ClickAsync();
        await pageLoadTask;
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "ServiceAreas_Source.png" });
        
        // Click text=About
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/about");
        await page.Locator("text=About").ClickAsync();
        await pageLoadTask;
        await Task.Delay(1000);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "About.png" });
        
        StopServer();
    }


    private static void StartServer()
    {
        var processStartInfo = new ProcessStartInfo("dotnet", 
            "run --project ../../../../../samples/dymaptic.blazor.GIS.API.Core.Sample.Server/dymaptic.blazor.GIS.API.Core.Sample.Server.csproj --no-build")
        {
            UseShellExecute = true
        };
    
        _serverProcess = Process.Start(processStartInfo);
        Assert.IsNotNull(_serverProcess);
    }

    private static void StopServer()
    {
        if (_serverProcess is not null && !_serverProcess.HasExited)
        {
            _serverProcess.CloseMainWindow();
            _serverProcess.Kill();
        }
        
        _serverProcess = null;
    }


    private static Process? _serverProcess;
}