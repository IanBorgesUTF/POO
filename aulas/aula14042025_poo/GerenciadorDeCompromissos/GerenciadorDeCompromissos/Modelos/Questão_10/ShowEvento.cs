namespace ConsoleApp.Modelos;

public class Show : Evento
{
    public string Artista { get; set; }
    public string Estilo { get; set; }
    public string ClassificacaoEtaria { get; set; }

    public override void ExibirInformacoes()
    {
        Console.WriteLine($"{Titulo} - Show de {Artista}, estilo {Estilo}.");
    }
}