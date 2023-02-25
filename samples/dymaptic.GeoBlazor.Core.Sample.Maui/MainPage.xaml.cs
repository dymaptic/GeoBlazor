namespace dymaptic.GeoBlazor.Core.Sample.Maui;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();

        if (DeviceInfo.Model.Contains("Surface Duo"))
        {
            BlazorWebView.HostPage = "wwwroot/surface_duo_index.html";
        }
#if ANDROID26_0_OR_GREATER
        BlazorWebView.BlazorWebViewInitialized += OnBlazorWebViewInitialized;
#endif
    }
}