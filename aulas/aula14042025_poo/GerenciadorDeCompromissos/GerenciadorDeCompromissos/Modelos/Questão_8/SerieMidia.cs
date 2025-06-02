namespace ConsoleApp.Modelos;

public class Serie : Midia
{
    public int Temporadas { get; set; }
    public int Episodios { get; set; }
    public List<Episodio> ListaEpisodios { get; set; } = new();

    public override void ExibirResumo()
    {
        Console.WriteLine($"{Titulo} - {Temporadas} temporadas, {Episodios} episódios");
    }
}