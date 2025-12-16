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

        RegisterSerializationData();
        return serviceCollection
            .AddSingleton<GeoBlazorSettings>(_ => settings)
            .AddScoped<JsModuleManager>()
            .AddScoped<AbortManager>()
            .AddScoped<AuthenticationManager>()
            .AddCoreLogicComponents()
            .AddScoped<IAppValidator, RegistrationValidator>();
    }

    /// <summary>
    ///     Internal Call from Pro to Core DI
    /// </summary>
    internal static IServiceCollection AddGeoBlazorCoreFromPro(this IServiceCollection serviceCollection,
        GeoBlazorSettings settings)
    {
        // don't add the app validator or register serialization data here
        return serviceCollection
            .AddSingleton<GeoBlazorSettings>(_ => settings)
            .AddScoped<JsModuleManager>()
            .AddScoped<AbortManager>()
            .AddScoped<AuthenticationManager>()
            .AddCoreLogicComponents();
    }

    private static void RegisterSerializationData()
    {
        JsSyncManager.SerializableMethods = CoreSerializationData.SerializableMethods;
        JsSyncManager.ProtoContractTypes = CoreSerializationData.ProtoContractTypes;
        JsSyncManager.ProtoCollectionTypes = CoreSerializationData.ProtoCollectionTypes;
        JsSyncManager.Initialize();
    }

    private static IServiceCollection AddCoreLogicComponents(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<GeometryEngine>()
            .AddScoped<LocationService>()
            .AddScoped<ProjectionEngine>();
    }
}