using ConsoleApp.Modelos;
using ConsoleApp.Persistencia;
 
 Personagem personagem = Persistencia.Carregar();

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"--- Inventário de {personagem.Nome} ---");
            Console.WriteLine("1. Listar itens");
            Console.WriteLine("2. Adicionar item");
            Console.WriteLine("3. Usar item");
            Console.WriteLine("4. Remover item");
            Console.WriteLine("5. Sair e salvar");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    personagem.Inventario.Listar();
                    break;
                case "2":
                    AdicionarItem(personagem);
                    break;
                case "3":
                    UsarItem(personagem);
                    break;
                case "4":
                    RemoverItem(personagem);
                    break;
                case "5":
                    Persistencia.Salvar(personagem);
                    Console.WriteLine("Jogo salvo. Até a próxima!");
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    

    static void AdicionarItem(Personagem p)
    {
      Console.WriteLine("1 - Arma");
Console.WriteLine("2 - Poção");
Console.WriteLine("3 - Granada");
Console.WriteLine("4 - Munição");


        Console.Write("Escolha: ");
        string tipo = Console.ReadLine();

        Item novoItem = null;

        switch (tipo)
        {
            case "1": // Arma

                    Console.Write("Nome: ");
        string nomeArma = Console.ReadLine();

    Console.WriteLine("Tipo de arma: 1 - Pequena | 2 - Grande");
    string tipoArma = Console.ReadLine();

    var arma = new Arma
    {
        Nome = nomeArma,
        Tipo = tipoArma == "2" ? TipoArma.Grande : TipoArma.Pequena
    };

    if (arma.Tipo == TipoArma.Grande)
    {
        Console.WriteLine("Subtipo: 1 - Fuzil de Assalto | 2 - Fuzil de Atirador | 3 - Escopeta");
        string subtipo = Console.ReadLine();
        arma.SubtipoGrande = subtipo switch
        {
            "1" => SubtipoArmaGrande.FuzilDeAssalto,
            "2" => SubtipoArmaGrande.FuzilDeAtirador,
            "3" => SubtipoArmaGrande.Escopeta,
            _ => SubtipoArmaGrande.FuzilDeAssalto
        };
    }
    else
    {
        Console.WriteLine("Subtipo: 1 - Pistola | 2 - SMG | 3 - Corpo a Corpo");
        string subtipo = Console.ReadLine();
        arma.SubtipoPequena = subtipo switch
        {
            "1" => SubtipoArmaPequena.Pistola,
            "2" => SubtipoArmaPequena.SMG,
            "3" => SubtipoArmaPequena.CorpoACorpo,
            _ => SubtipoArmaPequena.Pistola
        };
    }

    novoItem = arma;
    break;


            case "2": // Poção

                                Console.Write("Nome: ");
        string nomePocao = Console.ReadLine();
        Console.Write("Descrição: ");
        string descPocao = Console.ReadLine();
                Console.Write("Cura: ");
                int cura = int.Parse(Console.ReadLine());
                Console.Write("Quantidade (até 99): ");
                int qtdPocao = int.Parse(Console.ReadLine());

                novoItem = new Pocao
                {
                    Nome = nomePocao,
                    Descricao = descPocao,
                    Cura = cura,
                    Quantidade = Math.Min(qtdPocao, 99)
                };
                break;

            case "3": // Granada

            Console.Write("Nome: ");
        string nomeGranada = Console.ReadLine();
        Console.Write("Descrição: ");
        string descGranada = Console.ReadLine();
                Console.Write("Dano: ");
                int danoGranada = int.Parse(Console.ReadLine());
                Console.Write("Quantidade (até 99): ");
                int qtdGranada = int.Parse(Console.ReadLine());

                novoItem = new Granada
                {
                    Nome = nomeGranada,
                    Descricao = descGranada,
                    Dano = danoGranada,
                    Quantidade = Math.Min(qtdGranada, 99)
                };
                break;

                case "4": // Munição
    Console.WriteLine("Tipo de munição:");
    Console.WriteLine("1 - Pesada (fuzil)");
    Console.WriteLine("2 - 12 (escopeta)");
    Console.WriteLine("3 - Sniper");
    Console.WriteLine("4 - Leve (smg/pistola)");

    string tipoM = Console.ReadLine();
    TipoMunicao tipoMunicao = tipoM switch
    {
        "1" => TipoMunicao.Pesada,
        "2" => TipoMunicao.Doze,
        "3" => TipoMunicao.Sniper,
        "4" => TipoMunicao.Leve,
        _ => TipoMunicao.Leve
    };

    Console.Write("Quantidade (até 99): ");
    int qtdM = int.Parse(Console.ReadLine());

    novoItem = new Municao
{
    Tipo = tipoMunicao,
    Quantidade = Math.Min(qtdM, 99)
};

    break;


            default:
                Console.WriteLine("Tipo inválido.");
                return;
        }

        if (p.Inventario.Adicionar(novoItem))
        {
            Console.WriteLine("Item adicionado com sucesso!");
        }
    }

    static void UsarItem(Personagem p)
    {
        Console.Write("Digite o nome do item a usar: ");
        string nome = Console.ReadLine();

        var item = p.Inventario.ObterPorNome(nome);
        if (item != null)
        {
            item.Usar(p.Inventario);
        }
        else
        {
            Console.WriteLine("Item não encontrado.");
        }
    }

    static void RemoverItem(Personagem p)
    {
        Console.Write("Digite o nome do item a remover: ");
        string nome = Console.ReadLine();

        var item = p.Inventario.ObterPorNome(nome);
        if (item != null)
        {
            p.Inventario.Remover(item.Id);
            Console.WriteLine("Item removido.");
        }
        else
        {
            Console.WriteLine("Item não encontrado.");
        }
    }
