using dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.Extensions.Hosting;


namespace dymaptic.GeoBlazor.Pro.Test.Maui;

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
        builder.Services.AddScoped<IHostApplicationLifetime, MauiApplicationLifetime>();
		Assembly executingAssembly = Assembly.GetExecutingAssembly();

		using Stream stream = executingAssembly
			.GetManifestResourceStream(typeof(MauiProgram), "appsettings.json")!;

		IConfigurationRoot config = new ConfigurationBuilder()
			.AddJsonStream(stream)
			.Build();
		builder.Configuration.AddConfiguration(config);

		builder.Services.AddGeoBlazorPro(builder.Configuration);
        builder.Services.AddScoped<ITestLogger, ServerTestLogger>();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
