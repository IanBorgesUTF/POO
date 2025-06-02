namespace ConsoleApp.Modelos;

public class Oficina : Evento
{
    public string Material { get; set; }
    public int MaxParticipantes { get; set; }

    public override void ExibirInformacoes()
    {
        Console.WriteLine($"{Titulo} - Oficina com {Material}, limite de {MaxParticipantes} pessoas.");
    }
}