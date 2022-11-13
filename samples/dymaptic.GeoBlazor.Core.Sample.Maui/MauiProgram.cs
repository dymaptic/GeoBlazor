using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Sample.Shared;
using Microsoft.Extensions.Configuration;


namespace dymaptic.GeoBlazor.Core.Sample.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddScoped<SharedFileProvider, MauiFileProvider>();
        builder.Services.AddSingleton<IConfiguration>(_ => builder.Configuration);
        builder.Services.AddScoped<HttpClient>();
        builder.Services.AddGeoBlazor();

        var apiKey = Preferences.Get("ArcGISApiKey", null);
        if (apiKey is not null)
        {
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string> { { "ArcGISApiKey", apiKey } });
        }
        else
        {
            builder.Configuration.AddInMemoryCollection();
        }

        return builder.Build();
    }
}