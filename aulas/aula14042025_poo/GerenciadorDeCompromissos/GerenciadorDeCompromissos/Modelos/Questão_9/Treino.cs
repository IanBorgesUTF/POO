namespace ConsoleApp.Modelos;

public class Treino
{
    public DateTime DataCriacao { get; set; }
    public string Objetivo { get; set; }
    public List<Exercicio> Exercicios { get; set; } = new();

    public double CalcularCargaTotal()
    {
        double total = 0;
        foreach (var ex in Exercicios)
        {
            total += ex.Series * ex.Repeticoes * ex.Carga;
        }
        return total;
    }
}