using ConsoleApp.Modelos;
using ConsoleApp.Persistencia;
 
        int opcao;
        do
        {
            Console.WriteLine("Escolha um exercício para testar:");
            Console.WriteLine("1. Biblioteca");
            Console.WriteLine("2. Cadastro Escolar");
            Console.WriteLine("3. Cursos Online");
            Console.WriteLine("4. Pet Shop");
            Console.WriteLine("5. Vendas");
            Console.WriteLine("6. Veículos");
            Console.WriteLine("7. Recrutamento");
            Console.WriteLine("8. Streaming");
            Console.WriteLine("9. Treinos");
            Console.WriteLine("10. Eventos Culturais");
            Console.WriteLine("0. Sair");
            opcao = int.Parse(Console.ReadLine()!);

            Console.WriteLine();
            switch (opcao)
            {
                case 1: TestarBiblioteca(); break;
                case 2: TestarCadastroEscolar(); break;
                case 3: TestarCursosOnline(); break;
                case 4: TestarPetShop(); break;
                case 5: TestarVendas(); break;
                case 6: TestarVeiculos(); break;
                case 7: TestarRecrutamento(); break;
                case 8: TestarStreaming(); break;
                case 9: TestarTreinos(); break;
                case 10: TestarEventosCulturais(); break;
                case 0: Console.WriteLine("Encerrando..."); break;
                default: Console.WriteLine("Opção inválida."); break;
            }
            Console.WriteLine();
        } while (opcao != 0);
    
    

    static void TestarBiblioteca()
    {
        var livros = new List<Livro>
        {
            new Livro { Titulo = "1984", Autor = "George Orwell" },
            new Livro { Titulo = "O Hobbit", Autor = "J.R.R. Tolkien" }
        };

        Console.Write("Nome do leitor: ");
        var leitor = new Leitor { Nome = Console.ReadLine()! };

        Console.WriteLine("Livros disponíveis:");
        for (int i = 0; i < livros.Count; i++)
            Console.WriteLine($"{i + 1}. {livros[i].Titulo} - {(livros[i].Disponivel ? "Disponível" : "Indisponível")}");

        Console.Write("Escolha o número do livro para emprestar: ");
        int escolha = int.Parse(Console.ReadLine()!) - 1;

        leitor.RealizarEmprestimo(livros[escolha]);
    }

    static void TestarCadastroEscolar()
    {
        Console.Write("Digite tipo de pessoa (aluno, professor, funcionario): ");
        string tipo = Console.ReadLine()!.ToLower();

        Console.Write("Nome: ");
        string nome = Console.ReadLine()!;
        Console.Write("CPF: ");
        string cpf = Console.ReadLine()!;
        Console.Write("Data de nascimento (dd/MM/yyyy): ");
        DateTime nascimento = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", null);

        if (tipo == "aluno")
        {
            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine()!;
            Console.Write("Turma: ");
            string turma = Console.ReadLine()!;
            var aluno = new Aluno { Nome = nome, CPF = cpf, DataNascimento = nascimento, Matricula = matricula, Turma = turma };
            Console.WriteLine($"Aluno cadastrado: {aluno.Nome}, turma {aluno.Turma}");
        }
        else if (tipo == "professor")
        {
            Console.Write("Disciplinas (separadas por vírgula): ");
            string[] disciplinas = Console.ReadLine()!.Split(',');
            var professor = new Professor { Nome = nome, CPF = cpf, DataNascimento = nascimento, Disciplinas = new List<string>(disciplinas) };
            Console.WriteLine($"Professor: {professor.Nome}, disciplinas: {string.Join(", ", professor.Disciplinas)}");
        }
        else if (tipo == "funcionario")
        {
            Console.Write("Setor: ");
            string setor = Console.ReadLine()!;
            var funcionario = new Funcionario { Nome = nome, CPF = cpf, DataNascimento = nascimento, Setor = setor };
            Console.WriteLine($"Funcionário: {funcionario.Nome}, setor: {funcionario.Setor}");
        }
        else
        {
            Console.WriteLine("Tipo inválido.");
        }
    }

    static void TestarCursosOnline()
    {
        Console.Write("Nome do aluno: ");
        var aluno = new AlunoCurso(Console.ReadLine()!);

        Console.Write("Nome do curso: ");
        string cursoNome = Console.ReadLine()!;
        var curso = new Curso { Nome = cursoNome };

        Console.Write("Quantas aulas o curso terá? ");
        int totalAulas = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < totalAulas; i++)
        {
            Console.Write($"Aula {i + 1} - Título: ");
            string titulo = Console.ReadLine()!;
            Console.Write("Duração (min): ");
            int duracao = int.Parse(Console.ReadLine()!);
            Console.Write("Professor: ");
            string prof = Console.ReadLine()!;
            curso.Aulas.Add(new Aula { Titulo = titulo, DuracaoMin = duracao, Professor = prof });
        }

        aluno.Matriculas.Add(new Matricula { Curso = curso, DataInscricao = DateTime.Today, Progresso = 0 });
        Console.WriteLine($"Aluno {aluno.Nome} matriculado no curso '{curso.Nome}' com {curso.Aulas.Count} aulas.");
    }

     static void TestarPetShop()
    {
        Console.Write("Nome do dono: ");
        var dono = new Dono { Nome = Console.ReadLine()! };

        Console.Write("Tipo de animal (cachorro/gato/passaro): ");
        string tipo = Console.ReadLine()!.ToLower();

        Animal animal = tipo switch
        {
            "cachorro" => new Cachorro { Raca = "", Porte = "", Temperamento = "" },
            "gato" => new Gato { Pelagem = "", Comportamento = "" },
            "passaro" => new Passaro { Especie = "", Envergadura = 0 },
            _ => null
        };

        if (animal == null) { Console.WriteLine("Tipo inválido."); return; }

        Console.Write("Nome do animal: "); animal.Nome = Console.ReadLine()!;
        Console.Write("Idade: "); animal.Idade = int.Parse(Console.ReadLine()!);
        Console.Write("Peso: "); animal.Peso = double.Parse(Console.ReadLine()!);
        animal.Dono = dono;

        Console.WriteLine($"Animal cadastrado: {animal.Nome}, dono: {dono.Nome}");
    }

    static void TestarVendas()
    {
        var pedido = new Pedido();
        while (true)
        {
            Console.Write("Produto: "); string nome = Console.ReadLine()!;
            Console.Write("Preço: "); double preco = double.Parse(Console.ReadLine()!);
            Console.Write("Código: "); string codigo = Console.ReadLine()!;
            Console.Write("Quantidade: "); int qtd = int.Parse(Console.ReadLine()!);

            pedido.Itens.Add(new ItemPedido { Produto = new Produto { Nome = nome, Preco = preco, Codigo = codigo }, Quantidade = qtd });

            Console.Write("Adicionar mais itens? (s/n): ");
            if (Console.ReadLine()!.ToLower() != "s") break;
        }
        Console.WriteLine($"Total do pedido: R$ {pedido.Total}");
    }

    static void TestarVeiculos()
    {
        Console.Write("Modelo: "); string modelo = Console.ReadLine()!;
        Console.Write("Placa: "); string placa = Console.ReadLine()!;
        Console.Write("Tipo: "); string tipo = Console.ReadLine()!;

        var veiculo = new Veiculo { Modelo = modelo, Placa = placa, Tipo = tipo };

        Console.Write("Data da manutenção (dd/MM/yyyy): ");
        DateTime data = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", null);
        Console.Write("Descrição: "); string desc = Console.ReadLine()!;
        Console.Write("Tipo de manutenção: "); string tipoManut = Console.ReadLine()!;

        bool sucesso = veiculo.AdicionarManutencao(new Manutencao { DataServico = data, Descricao = desc, Tipo = tipoManut });
        Console.WriteLine(sucesso ? "Manutenção registrada." : "Já existe manutenção nesta data.");
    }

    static void TestarRecrutamento()
    {
        Console.Write("Nome do candidato: "); string nome = Console.ReadLine()!;
        Console.Write("Email: "); string email = Console.ReadLine()!;
        Console.Write("Currículo: "); string curriculo = Console.ReadLine()!;
        var candidato = new Candidato { Nome = nome, Email = email, Curriculo = curriculo };

        Console.Write("Vaga: "); string vaga = Console.ReadLine()!;
        Console.Write("Empresa: "); string empresa = Console.ReadLine()!;
        Console.Write("Descrição da vaga: "); string descricao = Console.ReadLine()!;
        var v = new Vaga { Titulo = vaga, Empresa = empresa, Descricao = descricao };

        var candidatura = new Candidatura { Vaga = v, Candidato = candidato, DataEnvio = DateTime.Today, Status = "Enviada" };
        Console.WriteLine($"Candidatura enviada para {v.Titulo} por {candidato.Nome}");
    }

    static void TestarStreaming()
    {
        Console.Write("Tipo de mídia (filme/série/documentário): ");
        string tipo = Console.ReadLine()!.ToLower();

        Midia midia = tipo switch
        {
            "filme" => new Filme { Diretor = "", Ano = 0, Elenco = "" },
            "série" => new Serie { Temporadas = 0, Episodios = 0 },
            "documentário" => new Documentario { Tema = "", Narrador = "" },
            _ => null
        };

        if (midia == null) { Console.WriteLine("Tipo inválido."); return; }

        Console.Write("Título: "); midia.Titulo = Console.ReadLine()!;
        Console.Write("Duração: "); midia.Duracao = int.Parse(Console.ReadLine()!);
        Console.Write("Gênero: "); midia.Genero = Console.ReadLine()!;
        midia.ExibirResumo();
    }

    static void TestarTreinos()
    {
        Console.Write("Nome do aluno: "); string nome = Console.ReadLine()!;
        var aluno = new AlunoTreino { Nome = nome };
        var treino = new Treino { DataCriacao = DateTime.Today };

        Console.Write("Objetivo do treino: "); treino.Objetivo = Console.ReadLine()!;

        while (true)
        {
            Console.Write("Exercício: "); string ex = Console.ReadLine()!;
            Console.Write("Séries: "); int s = int.Parse(Console.ReadLine()!);
            Console.Write("Repetições: "); int r = int.Parse(Console.ReadLine()!);
            Console.Write("Carga: "); double c = double.Parse(Console.ReadLine()!);

            treino.Exercicios.Add(new Exercicio { Nome = ex, Series = s, Repeticoes = r, Carga = c });

            Console.Write("Adicionar mais? (s/n): ");
            if (Console.ReadLine()!.ToLower() != "s") break;
        }

        aluno.Treinos.Add(treino);
        Console.WriteLine($"Carga total: {treino.CalcularCargaTotal()}kg");
    }

    static void TestarEventosCulturais()
{
    Console.Write("Tipo de evento (oficina/palestra/show): ");
    string tipo = Console.ReadLine()!.ToLower();

    Evento evento = tipo switch
    {
        "oficina" => new Oficina { Material = "", MaxParticipantes = 0 },
        "palestra" => new Palestra { Palestrante = "", Topico = "", DuracaoPrevista = 0 },
        "show" => new Show { Artista = "", Estilo = "", ClassificacaoEtaria = "" },
        _ => null
    };

    if (evento == null) { Console.WriteLine("Tipo inválido."); return; }

    Console.Write("Título: "); evento.Titulo = Console.ReadLine()!;
    Console.Write("Data (dd/MM/yyyy): "); evento.Data = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", null);
    Console.Write("Horário: "); evento.Horario = Console.ReadLine()!;
    Console.Write("Local: "); evento.Local = Console.ReadLine()!;
    Console.Write("Capacidade: "); evento.Capacidade = int.Parse(Console.ReadLine()!);
    evento.ExibirInformacoes();
}


