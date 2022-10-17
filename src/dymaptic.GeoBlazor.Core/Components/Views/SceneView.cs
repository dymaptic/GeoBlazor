using dymaptic.GeoBlazor.Core.Exceptions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Components.Views;

/// <summary>
///     A SceneView displays a 3D view of a Map or WebScene instance using WebGL. To render a map and its layers in 2D, see the documentation for MapView. For a general overview of views, see View.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">ArcGIS JS API</a>
/// </summary>
/// <example>
///     <a target="_blank" href="https://blazor.dymaptic.com/web-scene">Sample - Web Scene</a>
/// </example>
public class SceneView : MapView
{
    /// <summary>
    ///     The Z-Index (elevation) of the camera position over the view.
    /// </summary>
    [Parameter]
    public double? ZIndex { get; set; }

    /// <summary>
    ///     The tilt of the camera in degrees with respect to the surface as projected down from the camera position.
    /// </summary>
    [Parameter]
    public double? Tilt { get; set; }
    
    /// <summary>
    ///     An instance of a <see cref="WebScene"/> object to display in the view.
    /// </summary>
    [RequiredProperty(nameof(MapView.WebMap), nameof(MapView.Map))]
    public WebScene? WebScene { get; set; }

    /// <inheritdoc />
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

    /// <inheritdoc />
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

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        WebScene?.ValidateRequiredChildren();
    }

    /// <inheritdoc />
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

            await ViewJsModule!.InvokeVoidAsync("buildMapView", Id, DotNetObjectReference,
                Longitude, Latitude, Rotation, scene, Zoom, Scale,
                ApiKey, sceneType, Widgets, Graphics, SpatialReference, Constraints, ZIndex, Tilt);
            Rendering = false;
        });
    }
}