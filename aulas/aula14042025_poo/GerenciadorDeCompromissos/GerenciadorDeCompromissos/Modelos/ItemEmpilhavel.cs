namespace ConsoleApp.Modelos;

public abstract class ItemEmpilhavel : Item
{
    public int Quantidade { get; set; } = 1;
    public override bool Empilhavel => true;

    public override void Usar(Inventario inventario)
    {
        if (Quantidade > 0)
        {
            Quantidade--;
            Console.WriteLine($"Usou 1x {Nome}. Restam {Quantidade}.");

            if (Quantidade == 0)
            {
                inventario.Remover(Id);
                Console.WriteLine($"O pack de {Nome} acabou e foi removido do inventário.");
            }
        }
        else
        {
            Console.WriteLine($"{Nome} já está esgotado.");
        }
    }

    public override int ObterEspacoOcupado() => 1;
}
