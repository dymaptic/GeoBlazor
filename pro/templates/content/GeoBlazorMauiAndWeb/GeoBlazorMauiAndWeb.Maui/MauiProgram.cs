using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using GeoBlazorMauiAndWeb.Shared.Services;
using GeoBlazorMauiAndWeb.Services;
using System.Reflection;
#if UsePro
using dymaptic.GeoBlazor.Pro;
#else
using dymaptic.GeoBlazor.Core;
#endif

namespace GeoBlazorMauiAndWeb.Maui;

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

        // Add device-specific services used by the GeoBlazorMauiAndWeb.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();

        builder.Services.AddMauiBlazorWebView();
        Assembly executingAssembly = Assembly.GetExecutingAssembly();

		using Stream stream = executingAssembly
			.GetManifestResourceStream(typeof(MauiProgram), "appsettings.json")!;

		IConfigurationRoot config = new ConfigurationBuilder()
			.AddJsonStream(stream)
			.Build();
		builder.Configuration.AddConfiguration(config);

		#if UsePro
		builder.Services.AddGeoBlazorPro(builder.Configuration);
		#else
		builder.Services.AddGeoBlazor(builder.Configuration);
		#endif

//-:cnd:noEmit
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
//+:cnd:noEmit

        return builder.Build();
    }
}
