namespace ConsoleApp.Modelos;

public class Professor : Pessoa
{
    public List<string> Disciplinas { get; set; } = new();
}
