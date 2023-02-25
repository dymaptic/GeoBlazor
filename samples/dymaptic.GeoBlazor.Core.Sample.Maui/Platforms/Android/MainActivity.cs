using Android.App;
using Android.Content.PM;


namespace dymaptic.GeoBlazor.Core.Sample.Maui;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, Icon = "@drawable/icon",
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
        ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
}