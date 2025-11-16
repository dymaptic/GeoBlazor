using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Sample.Shared.Shared;

public partial class NavMenu: IDisposable
{
    [Inject]
    public required IJSRuntime JsRuntime { get; set; }
    [Inject]
    public required NavigationManager NavigationManager { get; set; }
    [Inject]
    public required JsModuleManager JsModuleManager { get; set; }
    [Parameter]
    public string? SearchText { get; set; }
    [Parameter]
    public bool EnterKeyPressed { get; set; }

    protected string? NavMenuCssClass => CollapseNavMenu ? "collapse" : null;
    protected IEnumerable<PageLink> FilteredPages => string.IsNullOrWhiteSpace(SearchText)
        ? Pages
        : Pages.Where(p => p.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
    
    public void Dispose()
    {
        _dotNetRef?.Dispose();
    }

    [JSInvokable]
    public void OnScroll(double scrollTop)
    {
        _scrollTop = scrollTop;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            // instantiate GeoBlazor modules here so we can initialize our JS and register the views
            IJSObjectReference? pro = await JsModuleManager.GetProJsModule(JsRuntime, CancellationToken.None);
            IJSObjectReference core = await JsModuleManager.GetCoreJsModule(JsRuntime, pro, CancellationToken.None);
            await JsRuntime.InvokeVoidAsync("initializeGeoBlazor", core);

            string currentPage = NavigationManager
                .ToBaseRelativePath(NavigationManager.Uri)
                .Replace("source-code/", "");
            await JsRuntime.InvokeVoidAsync("scrollToNav", currentPage);
            _dotNetRef = DotNetObjectReference.Create(this);
            await JsRuntime.InvokeVoidAsync("trackScrollPosition", Navbar, _dotNetRef);
            StateHasChanged();
        }

        if (EnterKeyPressed)
        {
            EnterKeyPressed = false;

            if (FilteredPages.Count() == 1)
            {
                NavigationManager.NavigateTo(FilteredPages.First().Href);
            }
        }
    }

    protected void ToggleNavMenu()
    {
        CollapseNavMenu = !CollapseNavMenu;
    }

    protected async Task NavigateTo(string href)
    {
        if (href == NavigationManager.ToBaseRelativePath(NavigationManager.Uri))
        {
            // If the user clicks on the current page, we don't want to navigate away.
            return;
        }

        await JsRuntime.InvokeVoidAsync("setWaitCursor", true);

        await InvokeAsync(async () =>
        {
            NavigationManager.NavigateTo(href);
            await JsRuntime.InvokeVoidAsync("setWaitCursor", false);
            StateHasChanged();
        });
    }

    protected virtual bool CollapseNavMenu { get; set; } = true;
    protected ElementReference? Navbar;
    private DotNetObjectReference<NavMenu>? _dotNetRef;
    private double _scrollTop;
    public virtual PageLink[] Pages =>
    [
        new("", "Home", "oi-home"),
        new("navigation", "Navigation", "oi-compass"),
        new("drawing", "Drawing", "oi-pencil"),
        new("click-to-add", "Click to Add Point", "oi-map-marker"),
        new("many-graphics", "Many Graphics", "oi-calculator"),
        new("scene", "Scene & Attributes", "oi-globe"),
        new("widgets", "Widgets", "oi-location"),
        new("basemaps", "Basemaps", "oi-map"),
        new("feature-layers", "Feature Layers", "oi-layers"),
        new("map-image-layers", "Map Image Layers", "oi-image"),
        new("labels", "Labels", "oi-text"),
        new("popups", "Popups", "oi-chat"),
        new("popup-actions", "Popup Actions", "oi-bullhorn"),
        new("bookmarks", "Bookmarks", "oi-bookmark"),
        new("vector-layer", "Vector Layer", "oi-arrow-right"),
        new("layer-lists", "Layer Lists", "oi-list"),
        new("basemap-layer-lists", "Basemap Layer Lists", "oi-spreadsheet"),
        new("csv-layer", "CSV Layers", "oi-grid-four-up"),
        new("kmllayers", "KML Layers", "oi-excerpt"),
        new("georss-layer", "GeoRSS Layer", "oi-rss"),
        new("osm-layer", "OpenStreetMaps Layer", null, "osm.webp"),
        new("wcslayers", "WCS Layers", "oi-project"),
        new("wfslayers", "WFS Layers", null, "wfs.svg"),
        new("wmslayers", "WMS Layers", null, "wms.svg"),
        new("wmtslayers", "WMTS Layers", null, "wmts.svg"),
        new("imagerylayer", "Imagery Layers", "oi-image"),
        new("imagery-tile-layer", "Imagery Tile Layers", null, "tile.webp"),
        new("web-map", "Web Map", "oi-browser"),
        new("web-scene", "Web Scene", "oi-box"),
        new("events", "Events", "oi-flash"),
        new("reactive-utils", "Reactive Utils", "oi-wrench"),
        new("hit-tests", "Hit Tests", "oi-star"),
        new("sql-query", "SQL Query", "oi-data-transfer-download"),
        new("sql-filter-query", "SQL Filter", "oi-arrow-thick-bottom"),
        new("server-side-queries", "Server-Side Queries", "oi-question-mark"),
        new("query-related-features", "Query Related Features", "oi-people"),
        new("query-top-features", "Query Top Features", "oi-arrow-thick-top"),
        new("place-selector", "Place Selector", "oi-arrow-bottom"),
        new("service-areas", "Service Areas", "oi-comment-square"),
        new("measurement-widgets", "Measurement Widgets", null, "ruler.svg"),
        new("calculate-geometries", "Calculate Geometries", "oi-clipboard"),
        new("projection", "Display Projection", "oi-sun"),
        new("projection-tool", "Projection Tool", "oi-cog"),
        new("basemap-projections", "Basemap Projections", "oi-bullhorn"),
        new("unique-value", "Unique Renderers", "oi-eyedropper"),
        new("marker-rotation", "Marker Rotation", "oi-loop-circular"),
        new("graphic-tracking", "Graphic Tracking", "oi-move"),
        new("geometry-methods", "Geometry Methods", "oi-task"),
        new("locator-methods", "Locator Methods", "oi-task"),
        new("search-multi-source", "Search Multiple Sources", "oi-magnifying-glass"),
        new("reverse-geolocator", "GeoLocator", "oi-arrow-circle-bottom")
    ];
    public record PageLink(string Href, string Title, string? IconClass, string? ImageFile = null, bool Pro = false);
}