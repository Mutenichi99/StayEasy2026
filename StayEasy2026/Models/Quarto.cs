namespace StayEasy2026.Models;

// O objeto Quarto representa uma opção do catálogo.
public sealed class Quarto
{
    public string Nome { get; }
    public string Descricao { get; }
    public int Capacidade { get; }
    public decimal PrecoDiaria { get; }

    public Quarto(string nome, string descricao, int capacidade, decimal precoDiaria)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O quarto precisa de um nome.", nameof(nome));
        if (capacidade < 1)
            throw new ArgumentOutOfRangeException(nameof(capacidade));
        if (precoDiaria <= 0)
            throw new ArgumentOutOfRangeException(nameof(precoDiaria));

        Nome = nome;
        Descricao = descricao;
        Capacidade = capacidade;
        PrecoDiaria = precoDiaria;
    }

    public override string ToString() => Nome;
}
