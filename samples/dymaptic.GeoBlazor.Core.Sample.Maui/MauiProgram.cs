using dymaptic.GeoBlazor.Core.Sample.Shared;
using Microsoft.Extensions.Configuration;
using System.Reflection;


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

        builder.Services.AddScoped<HttpClient>();
        builder.Configuration.AddInMemoryCollection();

        var executingAssembly = Assembly.GetExecutingAssembly();

        using Stream stream = executingAssembly
            .GetManifestResourceStream("dymaptic.GeoBlazor.Core.Sample.Maui.appsettings.json")!;

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets(executingAssembly)
            .AddJsonStream(stream)
            .Build();
        builder.Configuration.AddConfiguration(config);
        builder.Services.AddGeoBlazor(builder.Configuration);

        return builder.Build();
    }
}