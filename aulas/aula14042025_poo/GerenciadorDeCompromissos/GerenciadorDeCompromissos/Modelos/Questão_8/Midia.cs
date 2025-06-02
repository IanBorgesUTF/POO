namespace ConsoleApp.Modelos;

public abstract class Midia
{
    public string Titulo { get; set; }
    public int Duracao { get; set; }
    public string Genero { get; set; }

    public abstract void ExibirResumo();
}