namespace ConsoleApp.Modelos;

public class InMemoryEquipamentoTIRepository : IEquipamentoTIRepository
{
    private readonly List<EquipamentoTI> _lista = new();

    public void Adicionar(EquipamentoTI entidade) => _lista.Add(entidade);
    public EquipamentoTI? ObterPorId(Guid id) => _lista.FirstOrDefault(e => e.Id == id);
    public List<EquipamentoTI> ObterTodos() => _lista;
    public void Atualizar(EquipamentoTI entidade)
    {
        var index = _lista.FindIndex(e => e.Id == entidade.Id);
        if (index >= 0) _lista[index] = entidade;
    }
    public bool Remover(Guid id)
    {
        var item = ObterPorId(id);
        return item != null && _lista.Remove(item);
    }
}