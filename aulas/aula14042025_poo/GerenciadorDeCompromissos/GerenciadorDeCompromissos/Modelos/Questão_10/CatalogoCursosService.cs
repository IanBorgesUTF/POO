namespace ConsoleApp.Modelos;

public class CatalogoCursosService
{
    private readonly ICursoOnlineRepository _repo;

    public CatalogoCursosService(ICursoOnlineRepository repo)
    {
        _repo = repo;
    }

    public bool RegistrarCurso(CursoOnline curso)
    {
        if (_repo.ObterTodos().Any(c => c.Titulo == curso.Titulo && c.Instrutor == curso.Instrutor))
            return false;

        _repo.Adicionar(curso);
        return true;
    }
}