namespace ConsoleApp.Modelos;

 public class Anotacao{
    public string Texto { get; set; } = "";
    public DateTime DataCriacao { get; set; }

    public Anotacao() { }

    public Anotacao(string texto)
    {
        Texto = texto;
        DataCriacao = DateTime.Now;
    }

    public override string ToString() => $"{DataCriacao:dd/MM/yyyy HH:mm}: {Texto}";

}
