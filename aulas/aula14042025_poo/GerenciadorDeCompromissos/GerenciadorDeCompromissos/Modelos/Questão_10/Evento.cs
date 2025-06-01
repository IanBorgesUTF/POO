namespace ConsoleApp.Modelos;

public abstract class Evento
{
    public string Titulo { get; set; }
    public DateTime Data { get; set; }
    public string Horario { get; set; }
    public string Local { get; set; }
    public int Capacidade { get; set; }

    public abstract void ExibirInformacoes();
}