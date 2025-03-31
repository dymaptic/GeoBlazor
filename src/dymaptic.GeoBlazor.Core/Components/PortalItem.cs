namespace dymaptic.GeoBlazor.Core.Components;

public partial class PortalItem : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [CodeGenerationIgnore]
    [ActivatorUtilitiesConstructor]
    public PortalItem()
    {
    }
    
    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="portalItemId">
    ///     The unique id for the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="access">
    ///     Indicates the level of access to this item: `private`, `shared`, `org`, or `public`.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#access">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="accessInformation">
    ///     Information on the source of the item and its copyright status.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#accessInformation">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="apiKey">
    ///     An authorization string used to access the portal item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#apiKey">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="avgRating">
    ///     Average rating.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#avgRating">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="categories">
    ///     An array of organization categories that are set on the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#categories">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="created">
    ///     The date the item was created.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#created">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="culture">
    ///     The item's locale information (language and country).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#culture">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="description">
    ///     The detailed description of the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#description">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="extent">
    ///     The geographic extent, or bounding rectangle, of the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#extent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="groupCategories">
    ///     An array of group categories set on the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#groupCategories">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="licenseInfo">
    ///     Information on license or restrictions related to the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#licenseInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="modified">
    ///     The date the item was last modified.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#modified">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="name">
    ///     The name of the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#name">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="numComments">
    ///     Number of comments on the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#numComments">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="numRatings">
    ///     Number of ratings on the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#numRatings">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="numViews">
    ///     Number of views on the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#numViews">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="owner">
    ///     The username of the user who owns this item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#owner">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="ownerFolder">
    ///     The ID of the folder in which the owner has stored the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#ownerFolder">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="portal">
    ///     The portal that contains the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#portal">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="screenshots">
    ///     An array of string URLs.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#screenshots">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="size">
    ///     The size of the item (in bytes).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#size">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="snippet">
    ///     A summary description of the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#snippet">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="tags">
    ///     User defined tags that describe the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#tags">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="title">
    ///     The title for the item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="typeKeywords">
    ///     Type keywords that describe the type of content of this item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#typeKeywords">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="url">
    ///     The service URL of this item.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html#url">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public PortalItem(
        string portalItemId,
        PortalItemAccess? access = null,
        string? accessInformation = null,
        string? apiKey = null,
        double? avgRating = null,
        IReadOnlyList<string>? categories = null,
        DateTime? created = null,
        string? culture = null,
        string? description = null,
        Extent? extent = null,
        IReadOnlyList<string>? groupCategories = null,
        string? licenseInfo = null,
        DateTime? modified = null,
        string? name = null,
        double? numComments = null,
        double? numRatings = null,
        double? numViews = null,
        string? owner = null,
        string? ownerFolder = null,
        Portal? portal = null,
        IReadOnlyList<string>? screenshots = null,
        int? size = null,
        string? snippet = null,
        IReadOnlyList<string>? tags = null,
        string? title = null,
        IReadOnlyList<string>? typeKeywords = null,
        string? url = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Access = access;
        AccessInformation = accessInformation;
        ApiKey = apiKey;
        AvgRating = avgRating;
        Categories = categories;
        Created = created;
        Culture = culture;
        Description = description;
        Extent = extent;
        GroupCategories = groupCategories;
        LicenseInfo = licenseInfo;
        Modified = modified;
        Name = name;
        NumComments = numComments;
        NumRatings = numRatings;
        NumViews = numViews;
        Owner = owner;
        OwnerFolder = ownerFolder;
        Portal = portal;
        PortalItemId = portalItemId;
        Screenshots = screenshots;
        Size = size;
        Snippet = snippet;
        Tags = tags;
        Title = title;
        TypeKeywords = typeKeywords;
        Url = url;
#pragma warning restore BL0005    
    }

    /// <summary>
    ///     An authorization string used to access the portal item. API keys are generated and managed in the ArcGIS Developer Portal. An API key is tied explicitly to an ArcGIS account; it is also used to monitor service usage.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ApiKey { get; set; }

}