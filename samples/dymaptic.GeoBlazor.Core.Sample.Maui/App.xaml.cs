using Microsoft.Extensions.Configuration;

namespace dymaptic.GeoBlazor.Core.Sample.Maui;

public partial class App
{
    public App(IConfiguration configuration)
    {
        _configuration = configuration;
        InitializeComponent();

        MainPage = new MainPage();
    }

    protected override void OnSleep()
    {
        var apiKey = _configuration.GetValue<string>("ArcGISApiKey", null);
        if (!string.IsNullOrWhiteSpace(apiKey))
        {
            Preferences.Set("ArcGISApiKey", apiKey);
        }
        base.OnSleep();
    }

    private IConfiguration _configuration;
}