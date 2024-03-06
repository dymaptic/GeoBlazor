using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Components.Widgets;
using dymaptic.GeoBlazor.Core.Exceptions;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System.Diagnostics;


// ReSharper disable RedundantCast

namespace dymaptic.GeoBlazor.Core.Components.Views;

/// <summary>
///     A SceneView displays a 3D view of a Map or WebScene instance using WebGL. To render a map and its layers in 2D, see
///     the documentation for MapView. For a general overview of views, see View.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <example>
///     <a target="_blank" href="https://samples.geoblazor.com/web-scene">Sample - Web Scene</a>
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

    /// <inheritdoc />
    [JSInvokable]
    public override async Task OnJavascriptExtentChanged(Extent extent, Point? center, double zoom, double scale,
        double? rotation = null, double? tilt = null)
    {
        ZIndex = center?.Z;
        Tilt = tilt;
        await base.OnJavascriptExtentChanged(extent, center, zoom, scale, rotation, tilt);
    }

    /// <inheritdoc />
    public override async Task SetCenter(Point point)
    {
        if (!Equals(point.Latitude, Latitude) || !Equals(point.Longitude, Longitude))
        {
            ShouldUpdate = false;
            ExtentSetByCode = true;
            Latitude = point.Latitude;
            Longitude = point.Longitude;

            if (ViewJsModule is null) return;

            ViewExtentUpdate change =
                await ViewJsModule!.InvokeAsync<ViewExtentUpdate>("setCenter",
                    CancellationTokenSource.Token, (object)point, Id);
            Extent = change.Extent;
            Zoom = change.Zoom;
            Scale = change.Scale;
            Tilt = change.Tilt;
            ZIndex = change.Center?.Z;
            ShouldUpdate = true;
        }
    }

    /// <inheritdoc />
    public override async Task SetZoom(double zoom)
    {
        Zoom = zoom;

        if (ViewJsModule is not null)
        {
            ShouldUpdate = false;
            ExtentSetByCode = true;

            ViewExtentUpdate change =
                await ViewJsModule!.InvokeAsync<ViewExtentUpdate>("setZoom",
                    CancellationTokenSource.Token, Zoom, Id);
            Extent = change.Extent;
            Latitude = change.Center?.Latitude;
            Longitude = change.Center?.Longitude;
            Scale = change.Scale;
            ZIndex = change.Center?.Z;
            Tilt = change.Tilt;
            ShouldUpdate = true;
        }
    }

    /// <inheritdoc />
    public override async Task SetScale(double scale)
    {
        Scale = scale;

        if (ViewJsModule is not null)
        {
            ShouldUpdate = false;
            ExtentSetByCode = true;

            ViewExtentUpdate change =
                await ViewJsModule!.InvokeAsync<ViewExtentUpdate>("setScale",
                    CancellationTokenSource.Token, Scale, Id);
            Extent = change.Extent;
            Latitude = change.Center?.Latitude;
            Longitude = change.Center?.Longitude;
            Zoom = change.Zoom;
            ZIndex = change.Center?.Z;
            Tilt = change.Tilt;
            ShouldUpdate = true;
        }
    }

    /// <inheritdoc />
    public override async Task SetExtent(Extent extent)
    {
        if (!extent.Equals(Extent))
        {
            Extent = extent;

            if (ViewJsModule is null) return;

            ShouldUpdate = false;
            ExtentSetByCode = true;

            ViewExtentUpdate change =
                await ViewJsModule!.InvokeAsync<ViewExtentUpdate>("setExtent",
                    CancellationTokenSource.Token, (object)Extent, Id);
            Latitude = change.Center?.Latitude;
            Longitude = change.Center?.Longitude;
            Zoom = change.Zoom;
            Scale = change.Scale;
            Tilt = change.Tilt;
            ZIndex = change.Center?.Z;
            ShouldUpdate = true;
        }
    }

    /// <inheritdoc />
    public override async Task GoTo(IEnumerable<Graphic> graphics)
    {
        if (ViewJsModule is null) return;

        ShouldUpdate = false;
        ExtentSetByCode = true;

        ViewExtentUpdate change =
            await ViewJsModule!.InvokeAsync<ViewExtentUpdate>("goToGraphics",
                CancellationTokenSource.Token, graphics, Id);
        Extent = change.Extent;
        Latitude = change.Center?.Latitude;
        Longitude = change.Center?.Longitude;
        Zoom = change.Zoom;
        Scale = change.Scale;
        Tilt = change.Tilt;
        ZIndex = change.Center?.Z;
        ShouldUpdate = true;
    }

    /// <inheritdoc />
    protected override async Task UpdateView()
    {
        if (!MapRendered || !ShouldUpdate || ExtentSetByCode || ExtentChangedInJs || PointerDown)
        {
            return;
        }

        ShouldUpdate = false;

        ViewExtentUpdate? change = await ViewJsModule!.InvokeAsync<ViewExtentUpdate>("updateView",
            CancellationTokenSource.Token, new
            {
                Id,
                Latitude,
                Longitude,
                Zoom,
                Rotation,
                Tilt,
                ZIndex
            });
        if (change is not null)
        {
            Extent = change.Extent;
        }
        ShouldUpdate = true;
    }

    /// <inheritdoc />
    protected override async Task RenderView(bool forceRender = false)
    {
        if (!NeedsRender && !forceRender)
        {
            return;
        }

        if (!AuthenticationInitialized || Rendering || Map is null || ViewJsModule is null) return;

        if (string.IsNullOrWhiteSpace(ApiKey) && AllowDefaultEsriLogin is null or false &&
            PromptForArcGISKey is null or true && string.IsNullOrWhiteSpace(AppId))
        {
            var newErrorMessage =
                "No ArcGIS API Key Found. See https://docs.geoblazor.com/pages/authentication.html for instructions on providing an API Key or suppressing this message.";

            if (ErrorMessage == newErrorMessage)
            {
                return;
            }

            ErrorMessage = newErrorMessage;
            Debug.WriteLine(ErrorMessage);
            StateHasChanged();

            return;
        }

        Rendering = true;
        Map.Layers.RemoveWhere(l => l.Imported);
        Map.Basemap?.Layers.RemoveWhere(l => l.Imported);
        ValidateRequiredChildren();

        await InvokeAsync(async () =>
        {
            Console.WriteLine("Rendering View");

            if (Map is null)
            {
                throw new MissingMapException();
            }

            string mapType = Map is WebScene ? "webscene" : "scene";

            NeedsRender = false;

            await ViewJsModule!.InvokeVoidAsync("setAssetsPath", CancellationTokenSource.Token,
                Configuration.GetValue<string?>("ArcGISAssetsPath",
                    "/_content/dymaptic.GeoBlazor.Core/assets"));

            await ViewJsModule!.InvokeVoidAsync("buildMapView",
                CancellationTokenSource.Token, Id, DotNetObjectReference,
                Longitude, Latitude, Rotation, Map, Zoom, Scale,
                mapType, Widgets, Graphics, SpatialReference, Constraints, Extent,
                EventRateLimitInMilliseconds, GetActiveEventHandlers(), IsServer, HighlightOptions, ZIndex, Tilt);
            Rendering = false;
            MapRendered = true;
            
            if (ProJsViewModule is not null)
            {
                // register pro widgets
                foreach (Widget widget in Widgets.Where(w => !w.GetType().Namespace!.Contains("Core")))
                {
                    await AddWidget(widget);
                }
            }
        });
    }
}