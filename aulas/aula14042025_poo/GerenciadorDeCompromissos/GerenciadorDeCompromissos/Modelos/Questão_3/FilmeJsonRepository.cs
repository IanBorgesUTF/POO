namespace ConsoleApp.Modelos;

public class FilmeJsonRepository : GenericJsonRepository<Filme>, IFilmeRepository
{
    public FilmeJsonRepository() : base("filmes.json") {}

    public IEnumerable<Filme> ObterPorGenero(string genero)
    {
        return ObterTodos().Where(f => f.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase));
    }
}