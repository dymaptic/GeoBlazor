using Codeuctivity.ImageSharpCompare;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System.Diagnostics;


namespace dymaptic.GeoBlazor.Core.Test;

[TestClass]
public class PlaywrightTests
{
    /// <summary>
    ///     An automated, yet still tedious process of going through each screen and clicking on things.
    ///     This test will likely break on changes to the repository, so don't rely on for stability.
    /// </summary>
    /// <remarks>
    ///     For faster and more reliable testing, use the blazor test runner in `dymaptic.GeoBlazor.Core.Test.Blazor.Server`
    ///     or `dymaptic.GeoBlazor.Core.Test.Blazor.Wasm`.
    /// </remarks>
    [TestMethod]
    public async Task RunThroughScreens()
    {
        StartServer();
        string? apiKey = new ConfigurationBuilder().AddUserSecrets<PlaywrightTests>().Build()["ArcGISApiKey"];

        if (!Directory.Exists(_screenShotsFolder))
        {
            Directory.CreateDirectory(_screenShotsFolder);
        }
        else
        {
            // move current screenshots to previous folder
            FileInfo[] screenshots = new DirectoryInfo(_screenShotsFolder).GetFiles();

            foreach (FileInfo ssFile in screenshots)
            {
                File.Move(ssFile.FullName, Path.Combine(_screenShotsFolder, "Previous", ssFile.Name), true);
            }
        }

        IPlaywright playwright = await Playwright.CreateAsync()!;
        IBrowser browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        IPage page = await browser.NewPageAsync();

        var renderMessage = new PageWaitForConsoleMessageOptions
        {
            Predicate = m => m.Text.Contains("View Render Complete"), Timeout = 60000
        };
        await Task.Delay(1000);
        Task waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);

        // Go to https://localhost:7255/
        await page.GotoAsync("https://localhost:7255/navigation");
        await Task.Delay(1000);

        if (await page.Locator("#api-key-field").IsVisibleAsync())
        {
            await page.Locator("#api-key-field").FillAsync(apiKey!);
            await page.Locator("#api-key-field").PressAsync("Enter");
        }

        await waitForRenderTask;

        // Click text=Latitude: >> input[type="number"]
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Navigation1.png"), FullPage = true
        });

        // Fill text=Latitude: >> input[type="number"]
        await page.Locator("text=Latitude: >> input[type=\"number\"]").FillAsync("34.023");

        // Press Tab
        await page.Locator("text=Latitude: >> input[type=\"number\"]").PressAsync("Tab");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Navigation2.png"), FullPage = true
        });

        // Click text=Longitude: >> input[type="number"]
        await page.Locator("text=Longitude: >> input[type=\"number\"]").ClickAsync();

        // Fill text=Longitude: >> input[type="number"]
        await page.Locator("text=Longitude: >> input[type=\"number\"]").FillAsync("-118.905");

        // Press Tab
        await page.Locator("text=Longitude: >> input[type=\"number\"]").PressAsync("Tab");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Navigation3.png"), FullPage = true
        });

        // Fill text=Zoom: >> input[type="number"]
        await page.Locator("text=Zoom: >> input[type=\"number\"]").FillAsync("12");

        // Press Tab
        await page.Locator("text=Zoom: >> input[type=\"number\"]").PressAsync("Tab");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Navigation4.png"), FullPage = true
        });

        // Fill text=Rotation (deg): >> input[type="number"]
        await page.Locator("text=Rotation (deg): >> input[type=\"number\"]").FillAsync("30");

        // Press Tab
        await page.Locator("text=Rotation (deg): >> input[type=\"number\"]").PressAsync("Tab");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Navigation4.png"), FullPage = true
        });

        Task pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/navigation");

        // Click text=Source Code
        await page.Locator("text=Source Code").ClickAsync();
        await pageLoadTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Navigation_Source.png"), FullPage = true
        });

        // Click text=Drawing
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/drawing");
        await page.Locator("text=Drawing").ClickAsync();
        await pageLoadTask;
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing1.png"), FullPage = true
        });

        // Click text=Draw a Point >> span
        await page.Locator("text=Draw a Point >> span").ClickAsync();

        // Click text=Longitude: Latitude: Draw >> button
        await page.Locator("text=Longitude: Latitude: Draw >> button").ClickAsync();

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing2.png"), FullPage = true
        });

        // Click text=Longitude: >> input[type="number"]
        await page.Locator("text=Longitude: >> input[type=\"number\"]").ClickAsync();

        // Fill text=Longitude: >> input[type="number"]
        await page.Locator("text=Longitude: >> input[type=\"number\"]").FillAsync("-118.7");

        // Press Tab
        await page.Locator("text=Longitude: >> input[type=\"number\"]").PressAsync("Tab");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing3.png"), FullPage = true
        });

        // Press ArrowDown
        await page.Locator("text=Latitude: >> input[type=\"number\"]").PressAsync("ArrowDown");

        // Press ArrowDown
        await page.Locator("text=Latitude: >> input[type=\"number\"]").PressAsync("ArrowDown");

        // Press ArrowUp
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing4.png"), FullPage = true
        });

        // Click text=Longitude: Latitude: Remove >> button
        await page.Locator("text=Longitude: Latitude: Remove >> button").ClickAsync();

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing5.png"), FullPage = true
        });

        // Click text=Draw a Line
        await page.Locator("text=Draw a Line").ClickAsync();

        // Click button:has-text("Draw") >> nth=1
        await page.Locator("button:has-text(\"Draw\")").Nth(1).ClickAsync();

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing6.png"), FullPage = true
        });

        // Click tr:nth-child(2) > td:nth-child(2) > input >> nth=0
        await page.Locator("tr:nth-child(2) > td:nth-child(2) > input").First.ClickAsync();

        // Press ArrowDown
        await page.Locator("tr:nth-child(2) > td:nth-child(2) > input").First.PressAsync("ArrowDown");

        // Press ArrowDown
        await page.Locator("tr:nth-child(2) > td:nth-child(2) > input").First.PressAsync("ArrowDown");

        // Press ArrowDown
        await page.Locator("tr:nth-child(2) > td:nth-child(2) > input").First.PressAsync("ArrowDown");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing7.png"), FullPage = true
        });

        // Click text=Add Pt >> nth=0
        await page.Locator("text=Add Pt").First.ClickAsync();

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing8.png"), FullPage = true
        });

        // Click tr:nth-child(4) > td:nth-child(2) > input >> nth=0
        await page.Locator("tr:nth-child(4) > td:nth-child(2) > input").First.ClickAsync();

        // Press ArrowUp
        await page.Locator("tr:nth-child(4) > td:nth-child(2) > input").First.PressAsync("ArrowUp");

        // Press ArrowUp
        await page.Locator("tr:nth-child(4) > td:nth-child(2) > input").First.PressAsync("ArrowUp");

        // Press ArrowUp
        await page.Locator("tr:nth-child(4) > td:nth-child(2) > input").First.PressAsync("ArrowUp");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing9.png"), FullPage = true
        });

        // Click text=Remove >> nth=0
        await page.Locator("text=Remove").First.ClickAsync();

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing10.png"), FullPage = true
        });

        // Click text=Draw a Polygon
        await page.Locator("text=Draw a Polygon").ClickAsync();

        // Click button:has-text("Draw") >> nth=2
        await page.Locator("button:has-text(\"Draw\")").Nth(1).ClickAsync();

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing11.png"), FullPage = true
        });

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

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing12.png"), FullPage = true
        });

        // Click text=Remove Pt >> nth=1
        await page.Locator("text=Remove Pt").Nth(1).ClickAsync();

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing13.png"), FullPage = true
        });

        // Click text=Remove >> nth=1
        await page.Locator("text=Remove").Nth(1).ClickAsync();

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing14.png"), FullPage = true
        });

        // Click text=Source Code
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/drawing");
        await page.Locator("text=Source Code").ClickAsync();
        await pageLoadTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Drawing_Source.png"), FullPage = true
        });

        // Click text=Scene >> nth=0
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/scene");
        await page.Locator("text=Scene").First.ClickAsync();
        await pageLoadTask;
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Scene.png"), FullPage = true
        });

        // Click text=Widgets
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/widgets");
        await page.Locator("text=Widgets").ClickAsync();
        await pageLoadTask;
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets1.png"), FullPage = true
        });

        // Check text=Locator: >> input[type="checkbox"]
        await page.Locator("text=Locator: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets2.png"), FullPage = true
        });

        // Check text=Search: >> input[type="checkbox"]
        await page.Locator("text=Search: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets3.png"), FullPage = true
        });

        // Check text=Basemap Toggle: >> input[type="checkbox"]
        await page.Locator("text=Basemap Toggle: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets4.png"), FullPage = true
        });

        // Check text=Basemap Gallery: >> input[type="checkbox"]
        await page.Locator("text=Basemap Gallery: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets5.png"), FullPage = true
        });

        // Check text=Legend: >> input[type="checkbox"]
        await page.Locator("text=Legend: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets6.png"), FullPage = true
        });

        // Check text=Scale Bar: >> input[type="checkbox"]
        await page.Locator("text=Scale Bar: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets7.png"), FullPage = true
        });

        // Uncheck text=Legend: >> input[type="checkbox"]
        await page.Locator("text=Legend: >> input[type=\"checkbox\"]").UncheckAsync();
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets8.png"), FullPage = true
        });

        // Check text=Legend: >> input[type="checkbox"]
        await page.Locator("text=Legend: >> input[type=\"checkbox\"]").CheckAsync();
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets9.png"), FullPage = true
        });

        // Click [aria-label="Find my location"]
        await page.Locator("[aria-label=\"Find my location\"]").ClickAsync();
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets10.png"), FullPage = true
        });

        // Click [placeholder="Find address or place"]
        await page.Locator("[placeholder=\"Find address or place\"]").ClickAsync();
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets11.png"), FullPage = true
        });

        // Fill [placeholder="Find address or place"]
        await page.Locator("[placeholder=\"Find address or place\"]")
            .FillAsync("1600 Pennsylvania Ave, Washington, DC");

        // Press Enter
        await page.Locator("[placeholder=\"Find address or place\"]").PressAsync("Enter");
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets12.png"), FullPage = true
        });

        // Click [aria-label="Close"]
        await page.Locator("[aria-label=\"Close\"]").ClickAsync();
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets13.png"), FullPage = true
        });

        // Click li[role="menuitem"]:has-text("Imagery Hybrid")
        await page.Locator("li[role=\"menuitem\"]:has-text(\"Imagery Hybrid\")").ClickAsync();
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets14.png"), FullPage = true
        });

        // Click .esri-basemap-gallery__item-thumbnail >> nth=0
        await page.Locator(".esri-basemap-gallery__item-thumbnail").First.ClickAsync();
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets15.png"), FullPage = true
        });

        // Click text=Source Code
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/widgets");
        await page.Locator("text=Source Code").ClickAsync();
        await pageLoadTask;
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Widgets_Source.png"), FullPage = true
        });

        // Click text=Basemaps
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/basemaps");
        await page.Locator("text=Basemaps").ClickAsync();
        await pageLoadTask;
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "BaseMaps1.png"), FullPage = true
        });

        // Check text=From Portal Id >> input[name="basemap-type"]
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Locator("text=From Portal Id >> input[name=\"basemap-type\"]").CheckAsync();
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "BaseMaps2.png"), FullPage = true
        });

        // Check text=From Tile Layers >> input[name="basemap-type"]
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Locator("text=From Tile Layers >> input[name=\"basemap-type\"]").CheckAsync();
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "BaseMaps3.png"), FullPage = true
        });

        // Click text=Source Code
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/basemaps");
        await page.Locator("text=Source Code").ClickAsync();
        await pageLoadTask;
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "BaseMaps_Source.png"), FullPage = true
        });

        // Click text=Feature Layers
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/feature-layers");
        await page.Locator("text=Feature Layers").ClickAsync();
        await pageLoadTask;
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "FeatureLayers1.png"), FullPage = true
        });

        // Check text=Show Trailheads Points Layer: >> input[name="points"]
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Locator("text=Show Trailheads Points Layer: >> input[name=\"points\"]").CheckAsync();
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "FeatureLayers2.png"), FullPage = true
        });

        // Check text=Show Trailheads Lines Layer: >> input[name="points"]
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Locator("text=Show Trailheads Lines Layer: >> input[name=\"points\"]").CheckAsync();
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "FeatureLayers3.png"), FullPage = true
        });

        // Check text=Show Trailheads Lines With Elevation Style Renderer: >> input[name="points"]
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);

        await page.Locator("text=Show Trailheads Lines With Elevation Style Renderer: >> input[name=\"points\"]")
            .CheckAsync();
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "FeatureLayers4.png"), FullPage = true
        });

        // Check text=Show Trailheads Lines With Bike Trails Styled: >> input[name="points"]
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);

        await page.Locator("text=Show Trailheads Lines With Bike Trails Styled: >> input[name=\"points\"]")
            .CheckAsync();
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "FeatureLayers5.png"), FullPage = true
        });

        // Check text=Show Trailheads Polygons Layer: >> input[name="points"]
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Locator("text=Show Trailheads Polygons Layer: >> input[name=\"points\"]").CheckAsync();
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "FeatureLayers6.png"), FullPage = true
        });

        // Click text=Vector Layer
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/vector-layer");
        await page.Locator("text=Vector Layer").ClickAsync();
        await pageLoadTask;
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "VectorLayer.png"), FullPage = true
        });

        // Click text=Source Code
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/vector-layer");
        await page.Locator("text=Source Code").ClickAsync();
        await pageLoadTask;
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "VectorLayer_Source.png"), FullPage = true
        });

        // Click text=Web Map
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/web-map");
        await page.Locator("text=Web Map").ClickAsync();
        await pageLoadTask;
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "WebMap1.png"), FullPage = true
        });

        // Click text=Web Scene
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/web-scene");
        await page.Locator("text=Web Scene").ClickAsync();
        await pageLoadTask;
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "WebScene1.png"), FullPage = true
        });

        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/sql-query");
        await page.Locator("text=SQL Query").ClickAsync();
        await pageLoadTask;
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "SqlQuery1.png"), FullPage = true
        });

        // Select UseType = 'Residential'
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Locator("select").SelectOptionAsync(new[] { "UseType = 'Residential'" });
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "SqlQuery2.png"), FullPage = true
        });

        // Select UseType = 'Irrigated Farm'
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Locator("select").SelectOptionAsync(new[] { "UseType = 'Irrigated Farm'" });
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "SqlQuery3.png"), FullPage = true
        });

        // Select TaxRateArea = 08637
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Locator("select").SelectOptionAsync(new[] { "TaxRateArea = 08637" });
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "SqlQuery4.png"), FullPage = true
        });

        // Select Roll_LandValue < 1000000
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Locator("select").SelectOptionAsync(new[] { "Roll_LandValue < 1000000" });
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "SqlQuery5.png"), FullPage = true
        });

        // Click text=Source Code
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/sql-query");
        await page.Locator("text=Source Code").ClickAsync();
        await pageLoadTask;
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "SqlQuery_Source.png"), FullPage = true
        });

        // Click text=SQL Filter Query
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/sql-filter-query");
        await page.Locator("text=SQL Filter Query").ClickAsync();
        await pageLoadTask;
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "SqlFilterQuery1.png"), FullPage = true
        });

        // Select Roll_LandValue < 200000
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Locator("select").SelectOptionAsync(new[] { "Roll_LandValue < 200000" });
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "SqlFilterQuery2.png"), FullPage = true
        });

        // Select Bedrooms5 > 0
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Locator("select").SelectOptionAsync(new[] { "Bedrooms5 > 0" });
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "SqlFilterQuery3.png"), FullPage = true
        });

        // Select Roll_RealEstateExemp > 0
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Locator("select").SelectOptionAsync(new[] { "Roll_RealEstateExemp > 0" });
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "SqlFilterQuery4.png"), FullPage = true
        });

        // Click text=Place Selector
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/place-selector");
        await page.Locator("text=Place Selector").ClickAsync();
        await pageLoadTask;
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "PlaceSelector1.png"), FullPage = true
        });

        // Select Coffee shop
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Locator("select").SelectOptionAsync(new[] { "Coffee shop" });
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "PlaceSelector2.png"), FullPage = true
        });

        // Click text=Routing
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/routing");
        await page.Locator("text=Routing").ClickAsync();
        await pageLoadTask;
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Routing1.png"), FullPage = true
        });

        // Click canvas
        await page.Mouse.ClickAsync(441, 320);
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Routing2.png"), FullPage = true
        });

        // Click canvas
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Mouse.ClickAsync(954, 348);
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "Routing3.png"), FullPage = true
        });

        // Click text=Service Areas
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/service-areas");
        await page.Locator("text=Service Areas").ClickAsync();
        await pageLoadTask;
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "ServiceAreas1.png"), FullPage = true
        });

        // Click canvas
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Mouse.ClickAsync(505, 339);
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "ServiceAreas2.png"), FullPage = true
        });

        // Click canvas
        waitForRenderTask = page.WaitForConsoleMessageAsync(renderMessage);
        await page.Mouse.ClickAsync(950, 442);
        await waitForRenderTask;

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "ServiceAreas3.png"), FullPage = true
        });

        // Click text=Source Code
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/source-code/service-areas");
        await page.Locator("text=Source Code").ClickAsync();
        await pageLoadTask;
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "ServiceAreas_Source.png"), FullPage = true
        });

        // Click text=About
        pageLoadTask = page.WaitForURLAsync("https://localhost:7255/about");
        await page.Locator("text=Home").ClickAsync();
        await pageLoadTask;
        await Task.Delay(1000);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(_screenShotsFolder, "About.png"), FullPage = true
        });

        StopServer();
    }

    private static void StartServer()
    {
        var processStartInfo = new ProcessStartInfo("dotnet",
            "run --project ../../../../../samples/dymaptic.GeoBlazor.Core.Sample.Server/dymaptic.GeoBlazor.Core.Sample.Server.csproj --no-build")
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
    private readonly string _screenShotsFolder = "../../../ScreenShots";
}