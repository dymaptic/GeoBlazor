using dymaptic.GeoBlazor.Core.Model;
using Microsoft.Extensions.DependencyInjection;


namespace dymaptic.GeoBlazor.Core;

public static class DependencyExtension
{
    public static IServiceCollection AddGeoBlazor(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<GeometryEngine>()
            .AddScoped<Projection>();
    }
}