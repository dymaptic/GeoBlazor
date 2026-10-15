namespace dymaptic.GeoBlazor.Pro.Components;

public partial class RouteService : ProLogicComponent
{
    /// <inheritdoc/>
    public RouteService(AuthenticationManager authenticationManager, JsModuleManager jsModuleManager, IAppValidator appValidator, IJSRuntime jsRuntime) : base(authenticationManager, jsModuleManager, appValidator, jsRuntime)
    {
    }

    /// <inheritdoc/>
    protected override string ComponentName => nameof(RouteService);
    /// <inheritdoc/>
    protected override string Library => "Pro";

    /// <summary>
    ///     Solves the route against the route layer with the route parameters.
    /// </summary>
    /// <param name="url">
    ///     URL to the ArcGIS Server REST resource that represents a network analysis service.
    /// </param>
    /// <param name="routeParameters">
    ///     Route parameters used as input to generate the route.
    /// </param>
    /// <param name="requestOptions">
    ///     Additional options to be used for the data request.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<RouteSolveResult> Solve(string url, RouteParameters routeParameters, RequestOptions? requestOptions = null)
    {
        _directionLines.Clear();
        _directionPoints.Clear();
        _directions.Clear();
        _stops.Clear();
        _traversedEdges.Clear();
        _traversedJunctions.Clear();
        _traversedTurns.Clear();
        _pointBarriers = null;
        _polylineBarriers = null;
        _polygonBarriers = null;
        RouteSolveResultWithoutGraphics resultWithoutGraphics = await InvokeAsync<RouteSolveResultWithoutGraphics>("solve", url, routeParameters, requestOptions);
        List<RouteResult> routeResults = new();
        foreach (RouteResultWithoutGraphics routeResult in resultWithoutGraphics.RouteResults)
        {
            RouteResultWithoutGraphics newResult = routeResult with
            {
            };
            if (newResult.DirectionLines is not null)
            {
                newResult = newResult with
                {
                    DirectionLines = newResult.DirectionLines with
                    {
                        Features = _directionLines[routeResult.Index]
                    }
                };
            }

            if (newResult.DirectionPoints is not null)
            {
                newResult = newResult with
                {
                    DirectionPoints = newResult.DirectionPoints with
                    {
                        Features = _directionPoints[routeResult.Index]
                    }
                };
            }

            if (newResult.Directions is not null)
            {
                newResult = newResult with
                {
                    Directions = newResult.Directions with
                    {
                        Features = _directions[routeResult.Index],
                        MergedGeometry = _mergedGeometries.GetValueOrDefault(routeResult.Index)
                    }
                };
            }

            if (newResult.TraversedEdges is not null)
            {
                newResult = newResult with
                {
                    TraversedEdges = newResult.TraversedEdges with
                    {
                        Features = _traversedEdges[routeResult.Index]
                    }
                };
            }

            if (newResult.TraversedJunctions is not null)
            {
                newResult = newResult with
                {
                    TraversedJunctions = newResult.TraversedJunctions with
                    {
                        Features = _traversedJunctions[routeResult.Index]
                    }
                };
            }

            if (newResult.TraversedTurns is not null)
            {
                newResult = newResult with
                {
                    TraversedTurns = newResult.TraversedTurns with
                    {
                        Features = _traversedTurns[routeResult.Index]
                    }
                };
            }

            Graphic[]? stops = _stops.GetValueOrDefault(newResult.Index);
            Graphic? route = _routes.GetValueOrDefault(newResult.Index);
            routeResults.Add(new RouteResult(newResult.DirectionLines, newResult.DirectionPoints, newResult.Directions, route, newResult.RouteName, stops, newResult.TraversedEdges, newResult.TraversedJunctions, newResult.TraversedTurns));
        }

        return new RouteSolveResult(resultWithoutGraphics.Messages, _pointBarriers, _polygonBarriers, _polylineBarriers, routeResults.ToArray());
    }

    /// <summary>
    ///     Internal callback function from JavaScript, do not call directly.
    /// </summary>
    [JSInvokable]
    public async Task JsGraphicsStreamCallback(IJSStreamReference streamReference, string collectionName, int? index)
    {
        await using Stream stream = await streamReference.OpenReadStreamAsync(1_000_000_000L);
        using var ms = new MemoryStream();
        await stream.CopyToAsync(ms);
        ms.Seek(0, SeekOrigin.Begin);
        ProtoGraphicCollection? collection = Serializer.Deserialize<ProtoGraphicCollection>(ms);
        Graphic[]? graphics = collection?.Graphics.Select(g => g.FromSerializationRecord()).ToArray();
        if (graphics is null)
        {
            return;
        }

        switch (collectionName)
        {
            case "directionLines":
                _directionLines[index!.Value] = graphics;
                break;
            case "directionPoints":
                _directionPoints[index!.Value] = graphics;
                break;
            case "directions":
                _directions[index!.Value] = graphics;
                break;
            case "mergedGeometry":
                _mergedGeometries[index!.Value] = (Polyline)graphics[0].Geometry!;
                break;
            case "stops":
                _stops[index!.Value] = graphics;
                break;
            case "traversedEdges":
                _traversedEdges[index!.Value] = graphics;
                break;
            case "traversedJunctions":
                _traversedJunctions[index!.Value] = graphics;
                break;
            case "traversedTurns":
                _traversedTurns[index!.Value] = graphics;
                break;
            case "route":
                _routes[index!.Value] = graphics[0];
                break;
            case "pointBarriers":
                _pointBarriers = graphics;
                break;
            case "polygonBarriers":
                _polygonBarriers = graphics;
                break;
            case "polylineBarriers":
                _polylineBarriers = graphics;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(collectionName), collectionName, null);
        }
    }

    private Graphic[]? _pointBarriers;
    private Graphic[]? _polygonBarriers;
    private Graphic[]? _polylineBarriers;
    private readonly Dictionary<int, Graphic[]> _directionLines = new();
    private readonly Dictionary<int, Graphic[]> _directionPoints = new();
    private readonly Dictionary<int, Graphic[]> _directions = new();
    private readonly Dictionary<int, Polyline> _mergedGeometries = new();
    private readonly Dictionary<int, Graphic[]> _stops = new();
    private readonly Dictionary<int, Graphic[]> _traversedEdges = new();
    private readonly Dictionary<int, Graphic[]> _traversedJunctions = new();
    private readonly Dictionary<int, Graphic[]> _traversedTurns = new();
    private readonly Dictionary<int, Graphic> _routes = new();
}


