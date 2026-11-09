using System.Text.Json;
using Microsoft.Maui.Storage;
using StayEasy2026.Models;

namespace StayEasy2026.Services;

public static class RepositorioReservas
{
    // Arquivo JSON local: não exige servidor, login ou banco de dados.
    private static string Caminho => Path.Combine(FileSystem.AppDataDirectory, "reservas_stayeasy2026.json");

    public static List<Reserva> Listar()
    {
        if (!File.Exists(Caminho))
            return [];

        string texto = File.ReadAllText(Caminho);
        return JsonSerializer.Deserialize<List<Reserva>>(texto) ?? [];
    }

    public static void Adicionar(Reserva nova)
    {
        var lista = Listar();
        lista.Add(nova);
        Salvar(lista);
    }

    public static void Cancelar(string codigo)
    {
        var lista = Listar();
        lista.RemoveAll(reserva => reserva.Codigo == codigo);
        Salvar(lista);
    }

    private static void Salvar(List<Reserva> lista)
    {
        string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(Caminho, json);
    }
}
