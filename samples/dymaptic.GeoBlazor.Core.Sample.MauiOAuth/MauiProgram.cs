using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;


namespace dymaptic.GeoBlazor.Core.Sample.MauiOAuth;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddGeoBlazor();
        builder.Configuration.AddInMemoryCollection();
        builder.Configuration["ArcGISAppId"] = "eLXMtFmEx6ZoSNg1";

        return builder.Build();
    }
}