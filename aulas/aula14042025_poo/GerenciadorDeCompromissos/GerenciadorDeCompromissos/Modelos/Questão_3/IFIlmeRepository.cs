namespace ConsoleApp.Modelos;

public interface IFilmeRepository : IRepository<Filme>
{
    IEnumerable<Filme> ObterPorGenero(string genero);
}
