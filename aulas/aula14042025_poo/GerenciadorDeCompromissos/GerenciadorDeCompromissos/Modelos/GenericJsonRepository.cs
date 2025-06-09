namespace ConsoleApp.Modelos;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class GenericJsonRepository<T> : IRepository<T> where T : IEntidade
{
    private readonly string _arquivo;
    private readonly List<T> _entidades;

    public GenericJsonRepository(string arquivo)
    {
        _arquivo = arquivo;
        _entidades = File.Exists(_arquivo)
            ? JsonSerializer.Deserialize<List<T>>(File.ReadAllText(_arquivo)) ?? new List<T>()
            : new List<T>();
    }

    public void Adicionar(T entidade)
    {
        _entidades.Add(entidade);
        Salvar();
    }

    public T? ObterPorId(Guid id) => _entidades.FirstOrDefault(e => e.Id == id);

    public List<T> ObterTodos() => _entidades;

    public void Atualizar(T entidade)
    {
        var index = _entidades.FindIndex(e => e.Id == entidade.Id);
        if (index >= 0)
        {
            _entidades[index] = entidade;
            Salvar();
        }
    }

    public bool Remover(Guid id)
    {
        var entidade = ObterPorId(id);
        if (entidade == null) return false;
        _entidades.Remove(entidade);
        Salvar();
        return true;
    }

    protected void Salvar()
    {
        File.WriteAllText(_arquivo, JsonSerializer.Serialize(_entidades));
    }
}