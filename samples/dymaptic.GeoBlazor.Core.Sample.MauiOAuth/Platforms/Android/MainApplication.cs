using Android.App;
using Android.Runtime;


namespace dymaptic.GeoBlazor.Core.Sample.MauiOAuth;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}