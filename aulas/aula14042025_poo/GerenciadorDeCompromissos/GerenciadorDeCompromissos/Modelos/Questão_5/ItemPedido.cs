namespace ConsoleApp.Modelos;

public class ItemPedido
{
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }

    public double Subtotal => Produto.Preco * Quantidade;
}