namespace ConsoleApp.Modelos;

 public class Participante{
    public string Nome { get; set; } = "";
    public List<Compromisso> Compromissos { get; set; } = new();

        public Participante() { }

    public Participante(string nome)
        {

                Nome = nome;
        }

    public void AdicionarCompromisso(Compromisso c){
           
            if (!Compromissos.Contains(c))
                Compromissos.Add(c);
    }

    public override string ToString() => Nome;

}
