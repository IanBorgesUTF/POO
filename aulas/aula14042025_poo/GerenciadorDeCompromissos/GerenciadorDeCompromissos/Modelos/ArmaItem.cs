namespace ConsoleApp.Modelos;
public enum TipoArma
{
    Pequena,
    Grande
}

public enum SubtipoArmaPequena
{
    Pistola,
    SMG,
    CorpoACorpo
}

public enum SubtipoArmaGrande
{
    FuzilDeAssalto,
    FuzilDeAtirador,
    Escopeta
}

public class Arma : Item
{
    public int Dano { get; set; }
    public TipoArma Tipo { get; set; }

    // Um dos dois campos será preenchido, dependendo do tipo
    public SubtipoArmaPequena? SubtipoPequena { get; set; }
    public SubtipoArmaGrande? SubtipoGrande { get; set; }

public override void Usar(Inventario inventario)
{
    TipoMunicao tipoNecessario = Tipo switch
    {
        TipoArma.Grande => SubtipoGrande switch
        {
            SubtipoArmaGrande.FuzilDeAssalto => TipoMunicao.Pesada,
            SubtipoArmaGrande.FuzilDeAtirador => TipoMunicao.Sniper,
            SubtipoArmaGrande.Escopeta => TipoMunicao.Doze,
            _ => throw new NotSupportedException()
        },
        TipoArma.Pequena => TipoMunicao.Leve,
        _ => throw new NotSupportedException()
    };

    var municao = inventario.Itens
        .OfType<Municao>()
        .FirstOrDefault(m => m.Tipo == tipoNecessario);

    if (municao == null || municao.Quantidade == 0)
    {
        Console.WriteLine($"Sem munição ({tipoNecessario}) para usar {Nome}.");
        return;
    }

    municao.Quantidade--;
    Console.WriteLine($"Usando {Nome} com {tipoNecessario}: causando {municao.Dano} de dano. Munições restantes: {municao.Quantidade}");

    if (municao.Quantidade == 0)
    {
        inventario.Remover(municao.Id);
        Console.WriteLine("O pack de munição foi removido (acabou).");
    }
}



    public override int ObterEspacoOcupado()
    {
        return Tipo == TipoArma.Grande ? 5 : 3;
    }

    public override bool Empilhavel => false;
}


