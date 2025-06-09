using ConsoleApp.Modelos;
 
        int opcao;
        do
        {
            Console.WriteLine("Escolha um exercício para testar:");
            Console.WriteLine("1. Produto (Catálogo)");
            Console.WriteLine("2. Música (Biblioteca)");
            Console.WriteLine("3. Filme (Consulta por Gênero)");
            Console.WriteLine("4. Funcionário e Departamento");
            Console.WriteLine("5. Paciente (Filtro por Idade)");
            Console.WriteLine("6. Equipamento TI (In-Memory)");
            Console.WriteLine("7. Pedido Restaurante");
            Console.WriteLine("8. Arquivo Digital");
            Console.WriteLine("9. Reserva Hotel");
            Console.WriteLine("10. Curso Online");
            Console.WriteLine("0. Sair");
            opcao = int.Parse(Console.ReadLine()!);

            Console.WriteLine();
            switch (opcao)
            {
                case 1: TestarProduto(); break;
                case 2: TestarMusica(); break;
                case 3: TestarFilme(); break;
                case 4: TestarFuncionario(); break;
                case 5: TestarPaciente(); break;
                case 6: TestarEquipamentoTI(); break;
                case 7: TestarPedidoRestaurante(); break;
                case 8: TestarArquivoDigital(); break;
                case 9: TestarReservaHotel(); break;
                case 10: TestarCursoOnline(); break;
                case 0: Console.WriteLine("Encerrando..."); break;
                default: Console.WriteLine("Opção inválida."); break;
            }
            Console.WriteLine();
        } while (opcao != 0);

    static void TestarProduto()
    {
        var repo = new ProdutoJsonRepository();
        Console.Write("Nome: ");
        string nome = Console.ReadLine()!;
        Console.Write("Descrição: ");
        string desc = Console.ReadLine()!;
        Console.Write("Preço: ");
        decimal preco = decimal.Parse(Console.ReadLine()!);
        Console.Write("Estoque: ");
        int estoque = int.Parse(Console.ReadLine()!);

        repo.Adicionar(new Produto
        {
            Nome = nome,
            Descricao = desc,
            Preco = preco,
            Estoque = estoque
        });

        Console.WriteLine("Produto cadastrado com sucesso.");
    }

    static void TestarMusica()
    {
        var repo = new GenericJsonRepository<Musica>("musicas.json");
        Console.Write("Título: ");
        string titulo = Console.ReadLine()!;
        Console.Write("Artista: ");
        string artista = Console.ReadLine()!;
        Console.Write("Álbum: ");
        string album = Console.ReadLine()!;
        Console.Write("Duração (minutos): ");
        double minutos = double.Parse(Console.ReadLine()!);

        repo.Adicionar(new Musica
        {
            Titulo = titulo,
            Artista = artista,
            Album = album,
            Duracao = TimeSpan.FromMinutes(minutos)
        });

        Console.WriteLine("Música adicionada.");
    }

    static void TestarFilme()
    {
        var repo = new FilmeJsonRepository();
        Console.Write("Título: ");
        string titulo = Console.ReadLine()!;
        Console.Write("Diretor: ");
        string diretor = Console.ReadLine()!;
        Console.Write("Ano de lançamento: ");
        int ano = int.Parse(Console.ReadLine()!);
        Console.Write("Gênero: ");
        string genero = Console.ReadLine()!;

        repo.Adicionar(new Filme
        {
            Titulo = titulo,
            Diretor = diretor,
            AnoLancamento = ano,
            Genero = genero
        });

        Console.Write("Digite o gênero para filtrar: ");
        string filtro = Console.ReadLine()!;
        var lista = repo.ObterPorGenero(filtro);

        foreach (var filme in lista)
            Console.WriteLine($"Filme: {filme.Titulo}, Diretor: {filme.Diretor}");
    }

    static void TestarFuncionario()
    {
        var repoDepto = new GenericJsonRepository<Departamento>("departamentos.json");
        var repoFunc = new GenericJsonRepository<Funcionario>("funcionarios.json");

        Console.Write("Nome do departamento: ");
        string nomeDepto = Console.ReadLine()!;
        Console.Write("Sigla do departamento: ");
        string sigla = Console.ReadLine()!;

        var depto = new Departamento { NomeDepartamento = nomeDepto, Sigla = sigla };
        repoDepto.Adicionar(depto);

        Console.Write("Nome do funcionário: ");
        string nome = Console.ReadLine()!;
        Console.Write("Cargo: ");
        string cargo = Console.ReadLine()!;

        repoFunc.Adicionar(new Funcionario
        {
            NomeCompleto = nome,
            Cargo = cargo,
            DepartamentoId = depto.Id
        });

        Console.WriteLine("Funcionário cadastrado com sucesso.");
    }

    static void TestarPaciente()
    {
        var repo = new PacienteJsonRepository();

        Console.Write("Nome do paciente: ");
        string nome = Console.ReadLine()!;
        Console.Write("Data de nascimento (yyyy-MM-dd): ");
        DateTime nascimento = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Contato de emergência: ");
        string contato = Console.ReadLine()!;

        repo.Adicionar(new Paciente
        {
            NomeCompleto = nome,
            DataNascimento = nascimento,
            ContatoEmergencia = contato
        });

        Console.Write("Idade mínima: ");
        int min = int.Parse(Console.ReadLine()!);
        Console.Write("Idade máxima: ");
        int max = int.Parse(Console.ReadLine()!);

        var pacientes = repo.ObterPorFaixaEtaria(min, max);
        foreach (var p in pacientes)
            Console.WriteLine($"Paciente: {p.NomeCompleto}");
    }

    static void TestarEquipamentoTI()
    {
        var repo = new InMemoryEquipamentoTIRepository();

        Console.Write("Nome do equipamento: ");
        string nome = Console.ReadLine()!;
        Console.Write("Tipo: ");
        string tipo = Console.ReadLine()!;
        Console.Write("Número de série: ");
        string numeroSerie = Console.ReadLine()!;
        Console.Write("Data de aquisição (yyyy-MM-dd): ");
        DateTime data = DateTime.Parse(Console.ReadLine()!);

        repo.Adicionar(new EquipamentoTI
        {
            NomeEquipamento = nome,
            TipoEquipamento = tipo,
            NumeroSerie = numeroSerie,
            DataAquisicao = data
        });

        Console.WriteLine("Equipamento registrado.");
    }

    static void TestarPedidoRestaurante()
    {
        var repo = new GenericJsonRepository<ItemCardapio>("cardapio.json");

        Console.Write("Tipo (prato/bebida): ");
        string tipo = Console.ReadLine()!.ToLower();

        Console.Write("Nome: ");
        string nome = Console.ReadLine()!;
        Console.Write("Preço: ");
        decimal preco = decimal.Parse(Console.ReadLine()!);

        if (tipo == "prato")
        {
            Console.Write("Descrição detalhada: ");
            string desc = Console.ReadLine()!;
            Console.Write("Vegetariano (true/false): ");
            bool vegetariano = bool.Parse(Console.ReadLine()!);

            repo.Adicionar(new Prato
            {
                NomeItem = nome,
                Preco = preco,
                DescricaoDetalhada = desc,
                Vegetariano = vegetariano
            });
        }
        else
        {
            Console.Write("Volume (ml): ");
            int volume = int.Parse(Console.ReadLine()!);
            Console.Write("Alcoólica (true/false): ");
            bool alcoolica = bool.Parse(Console.ReadLine()!);

            repo.Adicionar(new Bebida
            {
                NomeItem = nome,
                Preco = preco,
                VolumeMl = volume,
                Alcoolica = alcoolica
            });
        }

        Console.WriteLine("Item do cardápio adicionado.");
    }

    static void TestarArquivoDigital()
    {
        var repo = new ArquivoDigitalJsonRepository();

        Console.Write("Nome do arquivo: ");
        string nome = Console.ReadLine()!;
        Console.Write("Tipo do arquivo: ");
        string tipo = Console.ReadLine()!;
        Console.Write("Tamanho em bytes: ");
        long tamanho = long.Parse(Console.ReadLine()!);

        repo.Adicionar(new ArquivoDigital
        {
            NomeArquivo = nome,
            TipoArquivo = tipo,
            TamanhoBytes = tamanho,
            DataUpload = DateTime.Now
        });

        Console.WriteLine("Arquivo salvo.");
    }

    static void TestarReservaHotel()
    {
        var repo = new ReservaHotelJsonRepository();

        Console.Write("Nome do hóspede: ");
        string nome = Console.ReadLine()!;
        Console.Write("Data de entrada (yyyy-MM-dd): ");
        DateTime entrada = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Data de saída (yyyy-MM-dd): ");
        DateTime saida = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Status (Pendente, Confirmada, Cancelada): ");
        StatusReserva status = Enum.Parse<StatusReserva>(Console.ReadLine()!);

        repo.Adicionar(new ReservaHotel
        {
            NomeHospede = nome,
            DataEntrada = entrada,
            DataSaida = saida,
            Status = status
        });

        Console.WriteLine("Reservas com status solicitado:");
        foreach (var r in repo.ObterPorStatus(status))
            Console.WriteLine($"{r.NomeHospede}: {r.DataEntrada:dd/MM} → {r.DataSaida:dd/MM}");
    }

    static void TestarCursoOnline()
    {
        var repo = new CursoOnlineJsonRepository();
        var service = new CatalogoCursosService(repo);

        Console.Write("Título do curso: ");
        string titulo = Console.ReadLine()!;
        Console.Write("Instrutor: ");
        string instrutor = Console.ReadLine()!;

        bool sucesso = service.RegistrarCurso(new CursoOnline { Titulo = titulo, Instrutor = instrutor });

        Console.WriteLine(sucesso ? "Curso cadastrado com sucesso." : "Curso já registrado.");
    }
