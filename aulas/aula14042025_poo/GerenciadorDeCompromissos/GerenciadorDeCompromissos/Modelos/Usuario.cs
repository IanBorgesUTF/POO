namespace ConsoleApp.Modelos;

 public class Usuario{
    public string Nome { get; set; }= "";

    public List<Compromisso> Compromissos { get; set; } = new();

    public Usuario() { }

    public Usuario(string nome)
    {

        Nome = nome;
    }


    public void AdicionarCompromisso(Compromisso c){

        if (c.DataHora <= DateTime.Now)
            throw new ArgumentException("Compromisso deve estar no futuro.");

        if (string.IsNullOrWhiteSpace(c.Descricao))
            throw new ArgumentException("Descrição obrigatória.");

        Compromissos.Add(c);
    }

    public override string ToString() => Nome;

}
