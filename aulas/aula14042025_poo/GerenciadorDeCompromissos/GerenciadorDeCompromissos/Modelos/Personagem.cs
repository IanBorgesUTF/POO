namespace ConsoleApp.Modelos;

public class Personagem
{
    public string Nome { get; set; }
    public Inventario Inventario { get; set; } = new Inventario();
}

