namespace ConsoleApp.Modelos;

public class ArquivoDigitalJsonRepository : GenericJsonRepository<ArquivoDigital>, IArquivoDigitalRepository
{
    public ArquivoDigitalJsonRepository() : base("arquivos.json") {}
}