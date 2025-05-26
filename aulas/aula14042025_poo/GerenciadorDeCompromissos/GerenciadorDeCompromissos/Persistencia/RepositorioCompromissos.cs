namespace ConsoleApp.Persistencia;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using Modelos;
using System.Text.Json.Serialization;



public class RepositorioCompromissos
{
    private const string Caminho = "agenda.json";

    private static readonly JsonSerializerOptions OpcoesJson = new()
    {
        WriteIndented = true,
        ReferenceHandler = ReferenceHandler.Preserve,
        PropertyNameCaseInsensitive = true
    };

    public static void Salvar(List<Usuario> usuarios)
    {
        string json = JsonSerializer.Serialize(usuarios, OpcoesJson);
        File.WriteAllText(Caminho, json);
    }

    public static List<Usuario> Carregar()
    {
        if (!File.Exists(Caminho))
            return new List<Usuario>();

        string json = File.ReadAllText(Caminho);
        
        try
        {
            return JsonSerializer.Deserialize<List<Usuario>>(json, OpcoesJson) ?? new List<Usuario>();
        }
        catch (JsonException ex)
        {
            Console.WriteLine("Erro ao carregar dados do JSON:");
            Console.WriteLine(ex.Message);
            return new List<Usuario>();
        }
    }
}
