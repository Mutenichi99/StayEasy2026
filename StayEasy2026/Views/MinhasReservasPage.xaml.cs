using StayEasy2026.Services;

namespace StayEasy2026.Views;

public partial class MinhasReservasPage : ContentPage
{
    public MinhasReservasPage() => InitializeComponent();

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            AtualizarLista();
        }
        catch (Exception)
        {
            ReservasCollection.ItemsSource = null;
            ContagemLabel.Text = "Erro ao carregar as reservas";
            await DisplayAlertAsync("Não foi possível abrir",
                "O arquivo de reservas pode estar indisponível ou danificado.", "OK");
        }
    }

    private void AtualizarLista()
    {
        var reservas = RepositorioReservas.Listar()
            .OrderByDescending(r => r.RegistradaEm).ToList();
        ReservasCollection.ItemsSource = reservas;
        ContagemLabel.Text = reservas.Count == 1
            ? "1 reserva salva neste dispositivo"
            : $"{reservas.Count} reservas salvas neste dispositivo";
    }

    private async void OnCancelarClicked(object sender, EventArgs e)
    {
        if (sender is not Button botao || botao.CommandParameter is not string codigo)
            return;

        bool confirmar = await DisplayAlertAsync("Cancelar reserva",
            $"Deseja cancelar a reserva #{codigo}?", "Sim, cancelar", "Não");
        if (!confirmar) return;

        try
        {
            RepositorioReservas.Cancelar(codigo);
            AtualizarLista();
        }
        catch (Exception)
        {
            await DisplayAlertAsync("Erro ao cancelar",
                "Não foi possível atualizar o histórico de reservas.", "OK");
        }
    }

    private async void OnNovaReservaClicked(object sender, EventArgs e) =>
        await Navigation.PushAsync(new NovaReservaPage());
}
