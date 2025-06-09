namespace ConsoleApp.Modelos;

public interface IPacienteRepository : IRepository<Paciente>
{
    IEnumerable<Paciente> ObterPorFaixaEtaria(int idadeMinima, int idadeMaxima);
}