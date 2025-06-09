namespace ConsoleApp.Modelos;

public class CursoOnline : IEntidade
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Titulo { get; set; } = "";
    public string Instrutor { get; set; } = "";
}