// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components.Popups;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Popups.PopupViewModel.html">GeoBlazor Docs</a>
///     Provides the logic for the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html">Popup</a> widget, which allows users to view
///     content from feature attributes.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup-PopupViewModel.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class PopupViewModel : FeaturesViewModel
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public PopupViewModel()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="actions">
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-Collection.html">Collection</a> of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionButton.html">action</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionToggle.html">action toggle</a> objects.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#actions">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="activeFeature">
    ///     The highlighted feature on the map that is either hovered over or in focus within the feature menu.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#activeFeature">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="autoCloseEnabled">
    ///     This closes the container when the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html">View</a> camera or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Viewpoint.html">Viewpoint</a> changes.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#autoCloseEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="browseClusterEnabled">
    ///     Indicates if the "Browse features" experience is active in a
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureReductionCluster.html">cluster</a> popup.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#browseClusterEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="defaultPopupTemplateEnabled">
    ///     Enables automatic creation of a popup template for layers that have popups enabled but no
    ///     popupTemplate defined.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#defaultPopupTemplateEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="elementReferenceContent">
    ///     The information to display.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#content">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="featureMenuOpen">
    ///     This property enables showing the list of features.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#featureMenuOpen">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="featureMenuTitle">
    ///     The title to display on the widget while viewing the feature menu.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#featureMenuTitle">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="featurePage">
    ///     The current page number in the feature browsing menu.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#featurePage">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="features">
    ///     An array of features.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#features">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="featuresPerPage">
    ///     The number of features to fetch at one time.
    ///     default 20
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#featuresPerPage">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="featureViewModelAbilities">
    ///     Defines the specific <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Feature-FeatureViewModel.html#Abilities">abilities</a> that can be used when querying and displaying content.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#featureViewModelAbilities">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="goToOverride">
    ///     This function provides the ability to override either the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#goTo">MapView goTo()</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html#goTo">SceneView goTo()</a> methods.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-support-GoTo.html#goToOverride">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="highlightEnabled">
    ///     Highlight the selected feature using the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#highlightOptions">highlightOptions</a>
    ///     set on the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">MapView</a> or the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html#highlightOptions">highlightOptions</a>
    ///     set on the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">SceneView</a>.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#highlightEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="includeDefaultActions">
    ///     Indicates whether or not to include <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#defaultActions">defaultActions</a>.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#includeDefaultActions">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="initialDisplayMode">
    ///     Indicates whether to initially display a list of features, or the content for one feature.
    ///     default "feature"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#initialDisplayMode">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="location">
    ///     Geometry used to show the location of the feature.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#location">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="screenLocation">
    ///     The screen location of the selected feature.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#screenLocation">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="screenLocationEnabled">
    ///     Determines whether screen point tracking is active for positioning.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#screenLocationEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="selectedFeatureIndex">
    ///     Index of the feature that is <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#selectedFeature">selected</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#selectedFeatureIndex">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference used for <a target="_blank" href="https://developers.arcgis.com/arcade">Arcade</a> operations.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#spatialReference">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="stringContent">
    ///     The information to display.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#content">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="timeZone">
    ///     Dates and times will be displayed in this time zone.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#timeZone">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="title">
    ///     The title of the widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="updateLocationEnabled">
    ///     Indicates whether to update the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#location">location</a> when the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#selectedFeatureIndex">selectedFeatureIndex</a> changes.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#updateLocationEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visible">
    ///     Indicates whether the widget is visible.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#visible">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="widgetContent">
    ///     The information to display.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#content">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public PopupViewModel(
        IReadOnlyList<ActionBase>? actions = null,
        Graphic? activeFeature = null,
        bool? autoCloseEnabled = null,
        bool? browseClusterEnabled = null,
        bool? defaultPopupTemplateEnabled = null,
        ElementReference? elementReferenceContent = null,
        bool? featureMenuOpen = null,
        string? featureMenuTitle = null,
        double? featurePage = null,
        IReadOnlyList<Graphic>? features = null,
        double? featuresPerPage = null,
        Abilities? featureViewModelAbilities = null,
        GoToOverride? goToOverride = null,
        bool? highlightEnabled = null,
        bool? includeDefaultActions = null,
        InitialDisplayMode? initialDisplayMode = null,
        Point? location = null,
        FeaturesViewModelScreenPoint? screenLocation = null,
        bool? screenLocationEnabled = null,
        int? selectedFeatureIndex = null,
        SpatialReference? spatialReference = null,
        string? stringContent = null,
        string? timeZone = null,
        string? title = null,
        bool? updateLocationEnabled = null,
        bool? visible = null,
        Widget? widgetContent = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Actions = actions;
        ActiveFeature = activeFeature;
        AutoCloseEnabled = autoCloseEnabled;
        BrowseClusterEnabled = browseClusterEnabled;
        DefaultPopupTemplateEnabled = defaultPopupTemplateEnabled;
        ElementReferenceContent = elementReferenceContent;
        FeatureMenuOpen = featureMenuOpen;
        FeatureMenuTitle = featureMenuTitle;
        FeaturePage = featurePage;
        Features = features;
        FeaturesPerPage = featuresPerPage;
        FeatureViewModelAbilities = featureViewModelAbilities;
        GoToOverride = goToOverride;
        HighlightEnabled = highlightEnabled;
        IncludeDefaultActions = includeDefaultActions;
        InitialDisplayMode = initialDisplayMode;
        Location = location;
        ScreenLocation = screenLocation;
        ScreenLocationEnabled = screenLocationEnabled;
        SelectedFeatureIndex = selectedFeatureIndex;
        SpatialReference = spatialReference;
        StringContent = stringContent;
        TimeZone = timeZone;
        Title = title;
        UpdateLocationEnabled = updateLocationEnabled;
        Visible = visible;
        WidgetContent = widgetContent;
#pragma warning restore BL0005    
    }
    
    
}
