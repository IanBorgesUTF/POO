namespace ConsoleApp.Modelos;

public abstract class Item : IOcupacao
{
    public Guid Id { get; set; } = Guid.NewGuid();
public virtual string Nome { get; set; } = string.Empty;


    public string Descricao { get; set; }

    public abstract void Usar(Inventario inventario);
    public abstract int ObterEspacoOcupado();
    public virtual bool Empilhavel => false;
}


