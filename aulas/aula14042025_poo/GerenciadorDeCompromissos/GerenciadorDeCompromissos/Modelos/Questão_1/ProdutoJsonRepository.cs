namespace ConsoleApp.Modelos;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class ProdutoJsonRepository : IProdutoRepository
{
    private readonly string _arquivo = "produtos.json";
    private readonly List<Produto> _produtos;

    public ProdutoJsonRepository()
    {
        _produtos = File.Exists(_arquivo)
            ? JsonSerializer.Deserialize<List<Produto>>(File.ReadAllText(_arquivo)) ?? new List<Produto>()
            : new List<Produto>();
    }


    public void Adicionar(Produto produto)
    {
        _produtos.Add(produto);
        Salvar();
    }

    public Produto? ObterPorId(Guid id) => _produtos.FirstOrDefault(p => p.Id == id);

    public List<Produto> ObterTodos() => _produtos;

    public void Atualizar(Produto produto)
    {
        var index = _produtos.FindIndex(p => p.Id == produto.Id);
        if (index >= 0)
        {
            _produtos[index] = produto;
            Salvar();
        }
    }

    public bool Remover(Guid id)
    {
        var produto = ObterPorId(id);
        if (produto == null) return false;
        _produtos.Remove(produto);
        Salvar();
        return true;
    }

    private void Salvar()
    {
        File.WriteAllText(_arquivo, JsonSerializer.Serialize(_produtos));
    }
}

