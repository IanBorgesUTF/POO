namespace ConsoleApp.Modelos;

public class ArquivoDigital : IEntidade
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeArquivo { get; set; } = "";
    public string TipoArquivo { get; set; } = "";
    public long TamanhoBytes { get; set; }
    public DateTime DataUpload { get; set; }
}