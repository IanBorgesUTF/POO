namespace ConsoleApp.Modelos;

public abstract class ItemCardapio : IEntidade
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeItem { get; set; } = "";
    public decimal Preco { get; set; }
}
