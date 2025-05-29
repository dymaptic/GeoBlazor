namespace dymaptic.GeoBlazor.Core;

/// <summary>
///     Static extension class for injecting GeoBlazor types
/// </summary>
public static class DependencyExtension
{
    /// <summary>
    ///     Registers all GeoBlazor components and services for dependency injection.
    /// </summary>
    public static IServiceCollection AddGeoBlazor(this IServiceCollection serviceCollection,
        IConfiguration? configuration)
    {
        GeoBlazorSettings settings = configuration?.GetSection("GeoBlazor").Get<GeoBlazorSettings>() 
            ?? new GeoBlazorSettings();
        return serviceCollection
            .AddSingleton<GeoBlazorSettings>(_ => settings)
            .AddScoped<JsModuleManager>()
            .AddScoped<GeometryEngine>()
            .AddScoped<LocationService>()
            .AddScoped<ProjectionEngine>()
            .AddScoped<AbortManager>()
            .AddScoped<AuthenticationManager>()
            .AddScoped<IAppValidator, RegistrationValidator>();
    }
}