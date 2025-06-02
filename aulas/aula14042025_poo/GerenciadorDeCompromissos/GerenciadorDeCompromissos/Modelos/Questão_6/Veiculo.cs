namespace ConsoleApp.Modelos;

public class Veiculo
{
    public string Modelo { get; set; }
    public string Placa { get; set; }
    public string Tipo { get; set; }
    public List<Manutencao> Manutencoes { get; set; } = new();

    public bool AdicionarManutencao(Manutencao manutencao)
    {
        if (Manutencoes.Exists(m => m.DataServico.Date == manutencao.DataServico.Date))
            return false;

        Manutencoes.Add(manutencao);
        return true;
    }
}