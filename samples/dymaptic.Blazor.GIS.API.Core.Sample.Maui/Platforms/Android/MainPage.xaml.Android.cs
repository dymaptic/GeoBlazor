using AndroidX.Activity;
using dymaptic.Blazor.GIS.API.Core.Sample.Maui.Platforms.Android;
using Microsoft.AspNetCore.Components.WebView;
using Microsoft.Maui.Platform;

namespace dymaptic.Blazor.GIS.API.Core.Sample.Maui;

public partial class MainPage
{
    private void OnBlazorWebViewInitialized(object sender, BlazorWebViewInitializedEventArgs e)
    {
        if (e.WebView.Context?.GetActivity() is not ComponentActivity activity)
        {
            throw new InvalidOperationException($"The permission-managing WebChromeClient requires that the current activity be a '{nameof(ComponentActivity)}'.");
        }

        e.WebView.Settings.SetGeolocationEnabled(true);
        e.WebView.Settings.SetGeolocationDatabasePath(e.WebView.Context?.FilesDir?.Path);
        e.WebView.SetWebChromeClient(new PermissionManagingBlazorWebChromeClient(e.WebView.WebChromeClient!, activity));
    }
}
