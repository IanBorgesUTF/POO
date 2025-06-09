namespace ConsoleApp.Modelos;

public class Funcionario : IEntidade
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeCompleto { get; set; } = "";
    public string Cargo { get; set; } = "";
    public Guid DepartamentoId { get; set; }
}