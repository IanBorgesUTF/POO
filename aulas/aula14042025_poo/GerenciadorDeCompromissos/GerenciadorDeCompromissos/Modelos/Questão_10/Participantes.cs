namespace ConsoleApp.Modelos;

public class Participantes
{
    public string Nome { get; set; }
    public List<Evento> EventosInscritos { get; set; } = new();
}