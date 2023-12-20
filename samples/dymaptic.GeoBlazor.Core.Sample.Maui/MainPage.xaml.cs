namespace dymaptic.GeoBlazor.Core.Sample.Maui;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();

#if ANDROID26_0_OR_GREATER
        BlazorWebView.BlazorWebViewInitialized += OnBlazorWebViewInitialized;
#endif
    }
}