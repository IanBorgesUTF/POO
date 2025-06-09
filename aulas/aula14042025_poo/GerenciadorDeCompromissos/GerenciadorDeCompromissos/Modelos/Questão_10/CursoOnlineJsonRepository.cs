namespace ConsoleApp.Modelos;

public class CursoOnlineJsonRepository : GenericJsonRepository<CursoOnline>, ICursoOnlineRepository
{
    public CursoOnlineJsonRepository() : base("cursos.json") {}
}