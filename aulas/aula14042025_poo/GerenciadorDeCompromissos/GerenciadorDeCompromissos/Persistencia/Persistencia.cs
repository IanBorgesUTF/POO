namespace ConsoleApp.Persistencia;

using ConsoleApp.Modelos;
using System.Text.Json;


public static class Persistencia
{
    private static readonly string Caminho = "personagem.json";

    private static readonly JsonSerializerOptions Opcoes = new JsonSerializerOptions
    {
        WriteIndented = true,
        Converters = { new ItemJsonConverter() }
    };

    public static void Salvar(Personagem personagem)
    {
        string json = JsonSerializer.Serialize(personagem, Opcoes);
        File.WriteAllText(Caminho, json);
    }

    public static Personagem Carregar()
    {
        if (!File.Exists(Caminho))
        {
            return new Personagem
            {
                Nome = "Jogador1",
                Inventario = new Inventario()
            };
        }

        string json = File.ReadAllText(Caminho);
        return JsonSerializer.Deserialize<Personagem>(json, Opcoes);
    }
}
