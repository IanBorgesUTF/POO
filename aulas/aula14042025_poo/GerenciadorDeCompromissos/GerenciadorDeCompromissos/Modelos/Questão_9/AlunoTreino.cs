namespace ConsoleApp.Modelos;

public class AlunoTreino
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Objetivo { get; set; }
    public List<Treino> Treinos { get; set; } = new();
}
