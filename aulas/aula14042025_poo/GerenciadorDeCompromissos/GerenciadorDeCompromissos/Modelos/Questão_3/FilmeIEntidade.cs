namespace ConsoleApp.Modelos;

public class Filme : IEntidade
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Titulo { get; set; } = "";
    public string Diretor { get; set; } = "";
    public int AnoLancamento { get; set; }
    public string Genero { get; set; } = "";
}