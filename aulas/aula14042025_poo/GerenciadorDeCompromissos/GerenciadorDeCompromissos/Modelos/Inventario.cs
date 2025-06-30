namespace ConsoleApp.Modelos;

public class Inventario
{
    private const int LimiteEspacos = 50;
    public List<Item> Itens { get; set; } = new List<Item>();

    public int EspacosOcupados => Itens.Sum(i => i.ObterEspacoOcupado());

    public bool Adicionar(Item item)
    {
        int espacoNecessario = item.ObterEspacoOcupado();

        if (item.Empilhavel)
        {
            var existente = Itens.FirstOrDefault(i => i.GetType() == item.GetType() && i.Empilhavel);
            if (existente is ItemEmpilhavel emp && item is ItemEmpilhavel novo)
            {
                if (emp.Quantidade + novo.Quantidade <= 99)
                {
                    emp.Quantidade += novo.Quantidade;
                    return true;
                }
            }
        }

        if (EspacosOcupados + espacoNecessario > LimiteEspacos)
        {
            Console.WriteLine("Inventário cheio! Não é possível adicionar este item.");
            return false;
        }

        Itens.Add(item);
        return true;
    }

    public void Remover(Guid id)
    {
        Itens.RemoveAll(i => i.Id == id);
    }

    public void Listar()
    {
        if (!Itens.Any()) Console.WriteLine("Inventário vazio.");
        else
        {
            foreach (var item in Itens)
            {
                string info = item.Empilhavel ? $" x{((ItemEmpilhavel)item).Quantidade}" : "";
                Console.WriteLine($"[{item.GetType().Name}] {item.Nome}{info} - Espaço: {item.ObterEspacoOcupado()}");
            }
            Console.WriteLine($"Espaço ocupado: {EspacosOcupados}/50");
        }
    }

    public Item ObterPorNome(string nome) =>
        Itens.FirstOrDefault(i => i.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
}

