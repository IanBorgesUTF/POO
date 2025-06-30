namespace ConsoleApp.Modelos;

public enum TipoMunicao
{
    Pesada,
    Doze,
    Sniper,
    Leve
}

public class Municao : ItemEmpilhavel
{
    public TipoMunicao Tipo { get; set; }

   public override string Nome => $"Munição {Tipo}";

    public string Descricao => Tipo switch
    {
        TipoMunicao.Pesada => "Munições para fuzis de assalto",
        TipoMunicao.Doze => "Munições para escopetas",
        TipoMunicao.Sniper => "Munições para fuzis de atirador",
        TipoMunicao.Leve => "Munições para pistolas e SMGs",
        _ => "Munições"
    };

    public int Dano => Tipo switch
    {
        TipoMunicao.Pesada => 130,
        TipoMunicao.Doze => 150,
        TipoMunicao.Sniper => 200,
        TipoMunicao.Leve => 80,
        _ => 0
    };
}

