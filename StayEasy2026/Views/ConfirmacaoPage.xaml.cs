using StayEasy2026.Models;

namespace StayEasy2026.Views;

public partial class ConfirmacaoPage : ContentPage
{
    public ConfirmacaoPage(Reserva reserva)
    {
        InitializeComponent();
        CodigoLabel.Text = reserva.CodigoTexto;
        HospedeLabel.Text = reserva.Hospede;
        QuartoLabel.Text = reserva.Quarto;
        PeriodoLabel.Text = reserva.PeriodoTexto;
        HospedesLabel.Text = reserva.HospedesTexto;
        DiariasLabel.Text = reserva.DiariasTexto;
        TotalLabel.Text = reserva.TotalTexto;
    }

    private async void OnMinhasReservasClicked(object sender, EventArgs e) =>
        await Navigation.PushAsync(new MinhasReservasPage());

    private async void OnVoltarInicioClicked(object sender, EventArgs e) =>
        await Navigation.PopToRootAsync();
}
