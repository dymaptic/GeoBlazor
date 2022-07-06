using dymaptic.Blazor.GIS.API.Core.Exceptions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace dymaptic.Blazor.GIS.API.Core.Components.Views;

public class SceneView : MapView
{
    [Parameter]
    public double? ZIndex { get; set; }

    [Parameter]
    public double? Tilt { get; set; }

    public WebScene? WebScene { get; set; }

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case WebScene webScene:
                if (!webScene.Equals(WebScene))
                {
                    WebScene = webScene;
                    await UpdateComponent();
                }

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
            case WebScene _:
                WebScene = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    protected override async Task RenderView(bool forceRender = false)
    {
        if (!NeedsRender && !forceRender)
        {
            return;
        }

        if (Rendering || (Map is null && WebScene is null) || ViewJsModule is null) return;

        Rendering = true;

        await InvokeAsync(async () =>
        {
            Console.WriteLine("Rendering View");
            string sceneType = Map is null ? "webscene" : "scene";
            object? scene = Map is null ? WebScene : Map;

            if (scene is null)
            {
                throw new MissingMapException();
            }

            await ViewJsModule!.InvokeVoidAsync("buildMapView", DotNetObjectReference,
                Longitude, Latitude, Rotation, scene, Zoom, Scale,
                ApiKey, sceneType, Widgets, Graphics, SpatialReference, ZIndex, Tilt);
            Rendering = false;
        });
    }
}