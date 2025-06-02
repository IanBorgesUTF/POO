namespace ConsoleApp.Modelos;

public class AlunoCurso
{
    public AlunoCurso(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    public List<Matricula> Matriculas { get; set; } = new();
}
