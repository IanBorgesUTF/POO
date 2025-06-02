namespace ConsoleApp.Modelos;

public class Pedido
{
    public List<ItemPedido> Itens { get; set; } = new();

    public double Total => CalcularTotal();

    private double CalcularTotal()
    {
        double total = 0;
        foreach (var item in Itens)
            total += item.Subtotal;
        return total;
    }
}