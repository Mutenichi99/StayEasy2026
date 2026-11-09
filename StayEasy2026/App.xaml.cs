using StayEasy2026.Views;

namespace StayEasy2026;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    // No .NET 10, definimos a primeira janela pelo CreateWindow.
    protected override Window CreateWindow(IActivationState? activationState)
    {
        var navegacao = new NavigationPage(new InicioPage())
        {
            BarBackgroundColor = Color.FromArgb("#0C1E2E"),
            BarTextColor = Colors.White
        };
        return new Window(navegacao);
    }
}
