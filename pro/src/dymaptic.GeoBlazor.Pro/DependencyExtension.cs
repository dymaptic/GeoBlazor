namespace dymaptic.GeoBlazor.Pro;

/// <summary>
///     Static extension class for injecting GeoBlazor types
/// </summary>
public static class DependencyExtension
{
    /// <summary>
    ///     Registers all GeoBlazor components and services for dependency injection.
    /// </summary>
    public static IServiceCollection AddGeoBlazorPro(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        GeoBlazorSettings settings = configuration.GetSection("GeoBlazor").Get<GeoBlazorSettings>()
            ?? new GeoBlazorSettings();
        
        serviceCollection.AddHttpClient<ProGeoJSONLayer>();

        return serviceCollection
            .AddGeoBlazorCoreFromPro(settings)
            .AddProLogicComponents();
    }

    private static IServiceCollection AddProLogicComponents(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<ArcGISRest>()
            .AddScoped<RouteService>()
            .AddScoped<NetworkService>()
            .AddScoped<PopupTemplateGenerator>()
            .AddScoped<QueryService>()
            .AddScoped<LabelGenerator>()
            .AddScoped<MultiPartToSinglePartOperator>()
            .AddScoped<PieChartGenerator>()
            .AddScoped<WfsUtils>();
    }
}