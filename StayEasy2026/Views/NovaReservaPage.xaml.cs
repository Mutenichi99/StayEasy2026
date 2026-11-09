using StayEasy2026.Models;
using StayEasy2026.Services;

namespace StayEasy2026.Views;

public partial class NovaReservaPage : ContentPage
{
    private bool _salvando;

    public NovaReservaPage()
    {
        InitializeComponent();

        // Definir primeiro os limites e depois as datas evita valores fora do intervalo.
        var hoje = DateTime.Today;
        EntradaPicker.MinimumDate = hoje;
        EntradaPicker.MaximumDate = hoje.AddYears(2);
        SaidaPicker.MinimumDate = hoje.AddDays(1);
        SaidaPicker.MaximumDate = hoje.AddYears(2).AddDays(1);
        EntradaPicker.Date = hoje.AddDays(1);
        SaidaPicker.Date = hoje.AddDays(3);

        QuartoPicker.ItemsSource = CatalogoQuartos.Criar();
        QuartoPicker.SelectedIndex = 0;
        AtualizarResumo();
    }

    private void OnQuartoAlterado(object sender, EventArgs e) => AtualizarResumo();
    private void OnHospedesAlterados(object sender, ValueChangedEventArgs e) => AtualizarResumo();

    private void OnEntradaAlterada(object sender, DateChangedEventArgs e)
    {
        if (EntradaPicker is null || SaidaPicker is null)
            return;

        if (EntradaPicker.Date is DateTime entrada)
        {
            SaidaPicker.MinimumDate = entrada.AddDays(1);
            if (SaidaPicker.Date is not DateTime saida || saida <= entrada)
                SaidaPicker.Date = entrada.AddDays(1);
        }
        AtualizarResumo();
    }

    private void OnSaidaAlterada(object sender, DateChangedEventArgs e) => AtualizarResumo();

    private void AtualizarResumo()
    {
        // Os eventos de Picker/Stepper podem disparar durante o InitializeComponent.
        if (QuartoPicker is null || EntradaPicker is null || SaidaPicker is null ||
            DescricaoQuartoLabel is null || PrecoDiariaLabel is null ||
            AdultosStepper is null || CriancasStepper is null ||
            AdultosLabel is null || CriancasLabel is null ||
            TotalHospedesLabel is null || DiariasLabel is null || TotalLabel is null)
            return;

        AdultosLabel.Text = $"{(int)AdultosStepper.Value} adulto(s)";
        CriancasLabel.Text = $"{(int)CriancasStepper.Value} criança(s)";
        TotalHospedesLabel.Text = $"{(int)(AdultosStepper.Value + CriancasStepper.Value)}";

        var quarto = QuartoPicker.SelectedItem as Quarto;
        DescricaoQuartoLabel.Text = quarto is null
            ? "Escolha uma suíte."
            : $"{quarto.Descricao}  •  até {quarto.Capacidade} hóspedes";
        PrecoDiariaLabel.Text = (quarto?.PrecoDiaria ?? 0m).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));

        var entrada = EntradaPicker.Date;
        var saida = SaidaPicker.Date;
        int dias = entrada.HasValue && saida.HasValue
            ? Math.Max(0, (saida.Value.Date - entrada.Value.Date).Days)
            : 0;
        DiariasLabel.Text = dias == 1 ? "1 diária" : $"{dias} diárias";
        decimal valor = dias * (quarto?.PrecoDiaria ?? 0m);
        TotalLabel.Text = valor.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
    }

    private async void OnConfirmarClicked(object sender, EventArgs e)
    {
        if (_salvando) return;
        if (QuartoPicker.SelectedItem is not Quarto quarto)
        {
            await DisplayAlertAsync("Atenção", "Selecione a acomodação.", "OK");
            return;
        }
        if (EntradaPicker.Date is not DateTime entrada || SaidaPicker.Date is not DateTime saida)
        {
            await DisplayAlertAsync("Verifique as datas", "Escolha as datas de entrada e saída.", "OK");
            return;
        }

        var reserva = new Reserva
        {
            Hospede = NomeEntry.Text?.Trim() ?? string.Empty,
            Quarto = quarto.Nome,
            Capacidade = quarto.Capacidade,
            PrecoDiaria = quarto.PrecoDiaria,
            Adultos = (int)AdultosStepper.Value,
            Criancas = (int)CriancasStepper.Value,
            CheckIn = entrada,
            CheckOut = saida
        };

        if (!reserva.Validar(out var mensagem))
        {
            await DisplayAlertAsync("Dados inválidos", mensagem, "Corrigir");
            return;
        }

        _salvando = true;
        ConfirmarButton.IsEnabled = false;
        try
        {
            RepositorioReservas.Adicionar(reserva);
            await Navigation.PushAsync(new ConfirmacaoPage(reserva));
        }
        catch (Exception)
        {
            await DisplayAlertAsync("Erro ao salvar", "Não foi possível salvar a reserva no dispositivo.", "OK");
        }
        finally
        {
            _salvando = false;
            ConfirmarButton.IsEnabled = true;
        }
    }
}
