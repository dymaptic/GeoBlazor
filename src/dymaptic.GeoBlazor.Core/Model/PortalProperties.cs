namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
/// Represents the organization settings structure from the ArcGIS Portal API.
/// </summary>
public record PortalProperties
{
    /// <summary>
    /// Gets or sets the links section of the organization settings.
    /// </summary>
    public PortalLinks? Links { get; init; }

    /// <summary>
    /// Gets or sets the shared theme configuration for the organization.
    /// </summary>
    public PortalSharedTheme? SharedTheme { get; init; }

    /// <summary>
    /// Gets or sets whether social media links should be displayed.
    /// </summary>
    public bool ShowSocialMediaLinks { get; init; }

    /// <summary>
    /// Gets or sets the Open Data configuration for the organization.
    /// </summary>
    public PortalOpenData? OpenData { get; init; }

    /// <summary>
    /// Gets or sets the Hub configuration for the organization.
    /// </summary>
    public PortalHub? Hub { get; init; }

    /// <summary>
    /// Gets or sets the default map viewer type, either "classic" or "modern".
    /// </summary>
    public string? MapViewer { get; init; }

    /// <summary>
    /// Gets or sets the timestamp when the map viewer was switched, in milliseconds since epoch.
    /// </summary>
    public long MapViewerSwitchDate { get; init; }

    /// <summary>
    /// Gets or sets the home page style, either "classic" or "modern".
    /// </summary>
    public string? HomePage { get; init; }
}

/// <summary>
/// Represents the links section of the organization settings.
/// </summary>
public record PortalLinks
{
    /// <summary>
    /// Gets or sets the contact us link information.
    /// </summary>
    public PortalLink? ContactUs { get; init; }
}

/// <summary>
/// Represents a link in the portal organization settings.
/// </summary>
public record PortalLink
{
    /// <summary>
    /// Gets or sets the URL for the link.
    /// </summary>
    public string? Url { get; init; }

    /// <summary>
    /// Gets or sets whether the link should be visible.
    /// </summary>
    public bool Visible { get; init; }
}

/// <summary>
/// Represents the shared theme configuration for the organization.
/// </summary>
public record PortalSharedTheme
{
    /// <summary>
    /// Gets or sets the header theming options.
    /// </summary>
    public PortalSharedThemeHeader? Header { get; init; }

    /// <summary>
    /// Gets or sets the body theming options.
    /// </summary>
    public PortalSharedThemeBody? Body { get; init; }

    /// <summary>
    /// Gets or sets the button theming options.
    /// </summary>
    public PortalSharedThemeButton? Button { get; init; }

    /// <summary>
    /// Gets or sets the logo configuration.
    /// </summary>
    public PortalSharedThemeLogo? Logo { get; init; }
}

/// <summary>
/// Represents the header theming configuration.
/// </summary>
public record PortalSharedThemeHeader
{
    /// <summary>
    /// Gets or sets the text color for the header, in hex format.
    /// </summary>
    public string? Text { get; init; }
}

/// <summary>
/// Represents the body theming configuration.
/// </summary>
public record PortalSharedThemeBody
{
    // Properties will be added as needed
}

/// <summary>
/// Represents the button theming configuration.
/// </summary>
public record PortalSharedThemeButton
{
    // Properties will be added as needed
}

/// <summary>
/// Represents the logo configuration in the shared theme.
/// </summary>
public record PortalSharedThemeLogo
{
    /// <summary>
    /// Gets or sets the URL to the small version of the logo.
    /// </summary>
    public string? Small { get; init; }

    /// <summary>
    /// Gets or sets the link associated with the logo.
    /// </summary>
    public string? Link { get; init; }
}

/// <summary>
/// Represents the Open Data configuration for the organization.
/// </summary>
public record PortalOpenData
{
    /// <summary>
    /// Gets or sets whether Open Data is enabled for the organization.
    /// </summary>
    public bool Enabled { get; init; }

    /// <summary>
    /// Gets or sets the settings for Open Data.
    /// </summary>
    public PortalOpenDataSettings? Settings { get; init; }
}

/// <summary>
/// Represents the settings for Open Data.
/// </summary>
public record PortalOpenDataSettings
{
    /// <summary>
    /// Gets or sets the migration settings for Open Data.
    /// </summary>
    public PortalOpenDataMigrations? Migrations { get; init; }

    /// <summary>
    /// Gets or sets the version of the Open Data application.
    /// </summary>
    public string? AppVersion { get; init; }
}

/// <summary>
/// Represents the migration settings for Open Data.
/// </summary>
public record PortalOpenDataMigrations
{
    /// <summary>
    /// Gets or sets whether site-to-items migration has been completed.
    /// </summary>
    public bool SiteToItems { get; init; }
}

/// <summary>
/// Represents the Hub configuration for the organization.
/// </summary>
public record PortalHub
{
    /// <summary>
    /// Gets or sets whether Hub is enabled for the organization.
    /// </summary>
    public bool Enabled { get; init; }

    /// <summary>
    /// Gets or sets the settings for Hub.
    /// </summary>
    public PortalHubSettings? Settings { get; init; }
}

/// <summary>
/// Represents the settings for Hub.
/// </summary>
public record PortalHubSettings
{
    /// <summary>
    /// Gets or sets the organization type, e.g., "enterprise".
    /// </summary>
    public string? OrgType { get; init; }

    /// <summary>
    /// Gets or sets the community organization configuration.
    /// </summary>
    public PortalHubCommunityOrg? CommunityOrg { get; init; }

    /// <summary>
    /// Gets or sets the events configuration.
    /// </summary>
    public PortalHubEvents? Events { get; init; }
}

/// <summary>
/// Represents the community organization configuration for Hub.
/// </summary>
public record PortalHubCommunityOrg
{
    /// <summary>
    /// Gets or sets the organization ID.
    /// </summary>
    public string? OrgId { get; init; }

    /// <summary>
    /// Gets or sets the portal hostname.
    /// </summary>
    public string? PortalHostname { get; init; }
}

/// <summary>
/// Represents the events configuration for Hub.
/// </summary>
public record PortalHubEvents
{
    /// <summary>
    /// Gets or sets the service ID for events.
    /// </summary>
    public string? ServiceId { get; init; }

    /// <summary>
    /// Gets or sets the public view ID for events.
    /// </summary>
    public string? PublicViewId { get; init; }
}

/// <summary>
///     Custom HTML for the home page.
/// </summary>
public record RotatorPanel
{
    /// <summary>
    ///     The Id of the panel.
    /// </summary>
    public string? Id { get; init; }

    /// <summary>
    ///     The HTML content of the panel.
    /// </summary>
    public string? InnerHTML { get; init; }
}