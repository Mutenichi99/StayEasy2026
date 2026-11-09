using StayEasy2026.Models;

namespace StayEasy2026.Services;

public static class CatalogoQuartos
{
    // Lista de objetos: conceito estudado na Agenda 14.
    public static List<Quarto> Criar() =>
    [
        new Quarto("Suíte Essencial", "Conforto para viagens rápidas", 2, 210m),
        new Quarto("Suíte Vista", "Vista privilegiada e espaço extra", 3, 345m),
        new Quarto("Suíte Família", "Mais espaço para toda a família", 5, 495m)
    ];
}
