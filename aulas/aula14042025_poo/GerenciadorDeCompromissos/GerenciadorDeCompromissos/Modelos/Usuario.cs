namespace ConsoleApp.Modelos;

 public class Usuario{
    public string Nome { get; set; }

    private List<Compromisso> compromissos = new();

    public IReadOnlyCollection<Compromisso> Compromissos => compromissos.AsReadOnly();

    public Usuario(string nome){
            
            Nome = nome;
    }

    public void AdicionarCompromisso(Compromisso c){
           
        if (c.DataHora <= DateTime.Now)
            throw new ArgumentException("Compromisso deve estar no futuro.");
            
        if (string.IsNullOrWhiteSpace(c.Descricao))
            throw new ArgumentException("Descrição obrigatória.");

        compromissos.Add(c);
    }

    public override string ToString() => Nome;

}
