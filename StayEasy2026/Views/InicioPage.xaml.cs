using StayEasy2026.Services;

namespace StayEasy2026.Views;

public partial class InicioPage : ContentPage
{
    public InicioPage() => InitializeComponent();

    protected override void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            int total = RepositorioReservas.Listar().Count;
            QuantidadeLabel.Text = total == 1 ? "1 reserva" : $"{total} reservas";
        }
        catch (Exception)
        {
            QuantidadeLabel.Text = "Consulte suas reservas";
        }
    }

    private async void OnNovaReservaClicked(object sender, EventArgs e) =>
        await Navigation.PushAsync(new NovaReservaPage());

    private async void OnMinhasReservasClicked(object sender, EventArgs e) =>
        await Navigation.PushAsync(new MinhasReservasPage());

    private async void OnSobreClicked(object sender, EventArgs e) =>
        await Navigation.PushAsync(new SobrePage());
}
