namespace ConsoleApp.Modelos;

public class Filme : Midia
{
    public string Diretor { get; set; }
    public int Ano { get; set; }
    public string Elenco { get; set; }

    public override void ExibirResumo()
    {
        Console.WriteLine($"{Titulo} ({Ano}) - Dirigido por {Diretor}");
    }
}