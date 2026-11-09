using System.Globalization;
using System.Text.Json.Serialization;

namespace StayEasy2026.Models;

// Propriedades armazenadas + regras de negócio centralizadas na classe.
public sealed class Reserva
{
    private static readonly CultureInfo PtBr = CultureInfo.GetCultureInfo("pt-BR");

    public string Codigo { get; set; } = Guid.NewGuid().ToString("N")[..8].ToUpperInvariant();
    public string Hospede { get; set; } = string.Empty;
    public string Quarto { get; set; } = string.Empty;
    public int Capacidade { get; set; }
    public int Adultos { get; set; } = 1;
    public int Criancas { get; set; }
    public decimal PrecoDiaria { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public DateTime RegistradaEm { get; set; } = DateTime.Now;

    [JsonIgnore] public int TotalHospedes => Adultos + Criancas;
    [JsonIgnore] public int Diarias => (CheckOut.Date - CheckIn.Date).Days;
    [JsonIgnore] public decimal PrecoTotal => Diarias * PrecoDiaria;
    [JsonIgnore] public string TotalTexto => PrecoTotal.ToString("C", PtBr);
    [JsonIgnore] public string DiariaTexto => PrecoDiaria.ToString("C", PtBr);
    [JsonIgnore] public string PeriodoTexto => $"{CheckIn:dd/MM/yyyy} até {CheckOut:dd/MM/yyyy}";
    [JsonIgnore] public string HospedesTexto => $"{Adultos} adulto(s) + {Criancas} criança(s)";
    [JsonIgnore] public string CodigoTexto => $"#{Codigo}";
    [JsonIgnore] public string DiariasTexto => Diarias == 1 ? "1 diária" : $"{Diarias} diárias";

    public bool Validar(out string mensagem)
    {
        if (string.IsNullOrWhiteSpace(Hospede) || Hospede.Trim().Length < 3)
        {
            mensagem = "Informe o nome do hóspede com pelo menos 3 caracteres.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(Quarto) || Capacidade <= 0 || PrecoDiaria <= 0)
        {
            mensagem = "Escolha uma acomodação válida.";
            return false;
        }
        if (Adultos < 1 || Criancas < 0 || TotalHospedes > Capacidade)
        {
            mensagem = $"A acomodação aceita até {Capacidade} pessoas e exige 1 adulto.";
            return false;
        }
        if (CheckIn.Date < DateTime.Today)
        {
            mensagem = "A data de entrada não pode ser anterior a hoje.";
            return false;
        }
        if (CheckOut.Date <= CheckIn.Date)
        {
            mensagem = "A saída deve ocorrer depois da entrada.";
            return false;
        }
        if (Diarias > 30)
        {
            mensagem = "O limite deste projeto demonstrativo é de 30 diárias.";
            return false;
        }

        mensagem = string.Empty;
        return true;
    }
}
