namespace dymaptic.GeoBlazor.Pro.Test.Maui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new MainPage()) { Title = "dymaptic.GeoBlazor.Pro.Test.MauiApp" };
	}
}
