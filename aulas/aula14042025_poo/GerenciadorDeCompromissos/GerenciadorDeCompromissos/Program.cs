using ConsoleApp.Modelos;
using ConsoleApp.Persistencia;
 
 
var usuarios = RepositorioCompromissos.Carregar();


Console.WriteLine("Informe seu nome:");
string nome = Console.ReadLine()!;
var usuario = usuarios.FirstOrDefault(u => u.Nome == nome) ?? new Usuario(nome);

if (!usuarios.Contains(usuario)) usuarios.Add(usuario);

int opcao;

do{
  
    Console.WriteLine("\n1. Adicionar compromisso\n2. Listar compromissos\n0. Sair");
    opcao = int.Parse(Console.ReadLine()!);

    if(opcao == 1){

        Console.Write("Data (dd/MM/yyyy): ");
        DateTime data = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", null);

        Console.Write("Hora (HH:mm): ");
        TimeSpan hora = TimeSpan.ParseExact(Console.ReadLine()!, "hh\\:mm", null);
        
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine()!;
        
        Console.Write("Local: ");
        string nomeLocal = Console.ReadLine()!;
        
        Console.Write("Capacidade: ");
        int capacidade = int.Parse(Console.ReadLine()!);

        var local = new Local(nomeLocal, capacidade);
        var compromisso = new Compromisso(data + hora, descricao, usuario, local);

        Console.Write("Quantos participantes? ");
        int total = int.Parse(Console.ReadLine()!);
        
        for (int i = 0; i < total; i++){
            
            Console.Write($"Participante {i + 1}: ");
            compromisso.AdicionarParticipante(new Participante(Console.ReadLine()!));
        }

        Console.Write("Deseja adicionar uma anotação? (s/n): ");
        
        if (Console.ReadLine()!.ToLower() == "s"){
            
            Console.Write("Texto da anotação: ");
            compromisso.AdicionarAnotacao(Console.ReadLine()!);
        }

       usuario.AdicionarCompromisso(compromisso);
       RepositorioCompromissos.Salvar(usuarios);


        Console.WriteLine("Compromisso adicionado!");
    } else if (opcao == 2){
        foreach (var compromisso in usuario.Compromissos){

            Console.WriteLine(compromisso);
            foreach (var anotacao in compromisso.Anotacoes) Console.WriteLine("  - " + anotacao);
        }
    }

    RepositorioCompromissos.Salvar(usuarios);

} while(opcao != 0);

Console.WriteLine("Encerrando...");