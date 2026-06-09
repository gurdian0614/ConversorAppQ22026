using ConversorAppQ22026.Views;
using Microsoft.Extensions.DependencyInjection;

namespace ConversorAppQ22026;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new MainTabbedPage());
	}
}