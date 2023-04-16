using AndroidX.Activity;
using Microsoft.AspNetCore.Components.WebView;
using Microsoft.Maui.Platform;


namespace dymaptic.GeoBlazor.Core.Sample.Maui;

public partial class MainPage
{
    private void OnBlazorWebViewInitialized(object? sender, BlazorWebViewInitializedEventArgs e)
    {
        if (e.WebView.Context?.GetActivity() is not ComponentActivity)
        {
            throw new InvalidOperationException(
                $"The permission-managing WebChromeClient requires that the current activity be a '{
                    nameof(ComponentActivity)}'.");
        }

        e.WebView.Settings.SetGeolocationEnabled(true);
#if !ANDROID24_0_OR_GREATER
        e.WebView.Settings.SetGeolocationDatabasePath(e.WebView.Context?.FilesDir?.Path);
#endif
#if Android26_0_OR_GREATER
        e.WebView.SetWebChromeClient(new PermissionManagingBlazorWebChromeClient(e.WebView.WebChromeClient!, activity));
#endif
    }
}