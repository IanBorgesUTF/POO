namespace ConsoleApp.Persistencia;

  public class RepositorioCompromissos{
    private const string Caminho = "agenda.json";

    public static void Salvar(List<Usuario> usuarios){
            
            var opcoes = new JsonSerializerOptions { WriteIndented = true };
            
            File.WriteAllText(Caminho, JsonSerializer.Serialize(usuarios, opcoes));
    }

    public static List<Usuario> Carregar(){
        
        if (!File.Exists(Caminho)) return new List<Usuario>();
        
        return JsonSerializer.Deserialize<List<Usuario>>(File.ReadAllText(Caminho)) ?? new List<Usuario>();
    }
}
