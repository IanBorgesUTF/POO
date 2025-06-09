namespace ConsoleApp.Modelos;

public class Departamento : IEntidade
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeDepartamento { get; set; } = "";
    public string Sigla { get; set; } = "";
}