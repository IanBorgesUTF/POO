namespace ConsoleApp.Modelos;

 public class Leitor
{
    public string Nome { get; set; }
    public List<Emprestimo> Emprestimos { get; } = new();

    public void RealizarEmprestimo(Livro livro)
    {
        if (!livro.Disponivel)
        {
            Console.WriteLine($"Livro '{livro.Titulo}' não está disponível.");
            return;
        }

        var emprestimo = new Emprestimo
        {
            Livro = livro,
            Leitor = this,
            DataEmprestimo = DateTime.Now
        };
        Emprestimos.Add(emprestimo);
        livro.Disponivel = false;
        Console.WriteLine($"Livro '{livro.Titulo}' emprestado para {Nome}.");
    }
}

