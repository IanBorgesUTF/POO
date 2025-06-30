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

    // Localiza todos os packs disponíveis dessa munição
    var packs = inventario.Itens
        .OfType<Municao>()
        .Where(m => m.Tipo == tipoNecessario)
        .OrderBy(m => m.Quantidade)
        .ToList();

    if (packs.Count == 0)
    {
        Console.WriteLine($"Sem munição ({tipoNecessario}) para usar {Nome}.");
        return;
    }

    // Consome do pack com menor quantidade
    var packMenor = packs.First();
    packMenor.Quantidade--;
    Console.WriteLine($"Usando {Nome} com {tipoNecessario}: causando {packMenor.Dano} de dano. Munição restante no pack: {packMenor.Quantidade}");

    if (packMenor.Quantidade == 0)
    {
        inventario.Remover(packMenor.Id);
        Console.WriteLine("Um pack de munição foi removido (acabou).");
        packs.Remove(packMenor); // remove da lista local para fusão
    }

    // Agora tentar consolidar todos os packs restantes
    if (packs.Count > 1)
    {
        var principal = packs.First(); // este receberá as sobras
        foreach (var outro in packs.Skip(1).ToList())
        {
            int espaco = 99 - principal.Quantidade;
            int transferir = Math.Min(espaco, outro.Quantidade);
            principal.Quantidade += transferir;
            outro.Quantidade -= transferir;

            if (outro.Quantidade == 0)
            {
                inventario.Remover(outro.Id);
                Console.WriteLine("Outro pack de munição foi removido após fusão.");
            }
        }
    }
}




    public override int ObterEspacoOcupado()
    {
        return Tipo == TipoArma.Grande ? 5 : 3;
    }

    public override bool Empilhavel => false;
}


