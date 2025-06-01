namespace ConsoleApp.Modelos;

public class Palestra : Evento
{
    public string Palestrante { get; set; }
    public string Topico { get; set; }
    public int DuracaoPrevista { get; set; }

    public override void ExibirInformacoes()
    {
        Console.WriteLine($"{Titulo} - Palestra sobre {Topico}, com {Palestrante}.");
    }
}