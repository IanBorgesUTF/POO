namespace ConsoleApp.Modelos;

public class Candidatura
{
    public Vaga Vaga { get; set; }
    public Candidato Candidato { get; set; }
    public DateTime DataEnvio { get; set; }
    public string Status { get; set; }
}