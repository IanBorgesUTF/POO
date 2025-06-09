namespace ConsoleApp.Modelos;

public class EquipamentoTI : IEntidade
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeEquipamento { get; set; } = "";
    public string TipoEquipamento { get; set; } = "";
    public string NumeroSerie { get; set; } = "";
    public DateTime DataAquisicao { get; set; }
}