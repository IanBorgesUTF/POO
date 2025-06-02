namespace ConsoleApp.Modelos;

 public class Emprestimo
{
    public Livro Livro { get; set; }
    public Leitor Leitor { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime? DataDevolucao { get; set; }
}
