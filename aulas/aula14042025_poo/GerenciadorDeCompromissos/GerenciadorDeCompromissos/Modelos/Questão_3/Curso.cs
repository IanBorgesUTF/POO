namespace ConsoleApp.Modelos;

public class Curso
{
    public string Nome { get; set; }
    public List<Aula> Aulas { get; set; } = new();
}