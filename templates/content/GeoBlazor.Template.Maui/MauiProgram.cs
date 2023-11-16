using dymaptic.GeoBlazor.Core;
using GeoBlazor.Template.Maui.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace GeoBlazor.Template.Maui
{
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
            var executingAssembly = Assembly.GetExecutingAssembly();

            using Stream stream = executingAssembly
                .GetManifestResourceStream("GeoBlazor.Template.Maui.appsettings.json")!;

            IConfigurationRoot config = new ConfigurationBuilder()
                .AddUserSecrets(executingAssembly)
                .AddJsonStream(stream)
                .Build();
            builder.Configuration.AddConfiguration(config);

            builder.Services.AddGeoBlazor(builder.Configuration);
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}
