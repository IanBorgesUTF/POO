namespace ConsoleApp.Modelos;

public class Local{
    public string Nome { get; set; } = "";
    public int Capacidade { get; set; }

    public Local() { }

    public Local(string nome, int capacidade)
    {

        Nome = nome;
        Capacidade = capacidade;
    }

    public bool ValidarCapacidade(int quantidade) => quantidade <= Capacidade;

    public override string ToString() => $"{Nome} (Cap: {Capacidade})";

}