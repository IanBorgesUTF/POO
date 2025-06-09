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
        var produto = new Produto { Nome = "Notebook", Descricao = "Dell Inspiron", Preco = 4500, Estoque = 10 };
        repo.Adicionar(produto);
        Console.WriteLine("Produto adicionado com sucesso.");
    }

    static void TestarMusica()
    {
        var repo = new GenericJsonRepository<Musica>("musicas.json");
        var musica = new Musica { Titulo = "Imagine", Artista = "John Lennon", Album = "Imagine", Duracao = TimeSpan.FromMinutes(3.1) };
        repo.Adicionar(musica);
        Console.WriteLine("Música adicionada.");
    }

    static void TestarFilme()
    {
        var repo = new FilmeJsonRepository();
        repo.Adicionar(new Filme { Titulo = "Matrix", Diretor = "Wachowski", AnoLancamento = 1999, Genero = "Ficção" });
        var filmes = repo.ObterPorGenero("Ficção");
        foreach (var filme in filmes)
            Console.WriteLine($"Filme: {filme.Titulo}, Diretor: {filme.Diretor}");
    }

    static void TestarFuncionario()
    {
        var repoDepto = new GenericJsonRepository<Departamento>("departamentos.json");
        var repoFunc = new GenericJsonRepository<Funcionario>("funcionarios.json");
        var depto = new Departamento { NomeDepartamento = "TI", Sigla = "TEC" };
        repoDepto.Adicionar(depto);
        repoFunc.Adicionar(new Funcionario { NomeCompleto = "João Silva", Cargo = "Dev", DepartamentoId = depto.Id });
        Console.WriteLine("Funcionário cadastrado no departamento TI.");
    }

    static void TestarPaciente()
    {
        var repo = new PacienteJsonRepository();
        repo.Adicionar(new Paciente { NomeCompleto = "Maria", DataNascimento = new DateTime(1990, 1, 1), ContatoEmergencia = "99999-9999" });
        var pacientes = repo.ObterPorFaixaEtaria(30, 40);
        foreach (var p in pacientes)
            Console.WriteLine($"Paciente: {p.NomeCompleto}");
    }

    static void TestarEquipamentoTI()
    {
        var repo = new InMemoryEquipamentoTIRepository();
        repo.Adicionar(new EquipamentoTI { NomeEquipamento = "Monitor", TipoEquipamento = "Display", NumeroSerie = "ABC123", DataAquisicao = DateTime.Now });
        var todos = repo.ObterTodos();
        Console.WriteLine($"Equipamentos cadastrados: {todos.Count}");
    }

    static void TestarPedidoRestaurante()
    {
        var repo = new GenericJsonRepository<ItemCardapio>("cardapio.json");
        repo.Adicionar(new Prato { NomeItem = "Lasanha", Preco = 30, DescricaoDetalhada = "Lasanha de carne", Vegetariano = false });
        repo.Adicionar(new Bebida { NomeItem = "Suco", Preco = 10, VolumeMl = 300, Alcoolica = false });
        Console.WriteLine("Itens adicionados ao cardápio.");
    }

    static void TestarArquivoDigital()
    {
        var repo = new ArquivoDigitalJsonRepository();
        repo.Adicionar(new ArquivoDigital { NomeArquivo = "foto.png", TipoArquivo = "Imagem", TamanhoBytes = 123456, DataUpload = DateTime.Now });
        Console.WriteLine("Arquivo digital salvo.");
    }

    static void TestarReservaHotel()
    {
        var repo = new ReservaHotelJsonRepository();
        repo.Adicionar(new ReservaHotel
        {
            NomeHospede = "Carlos",
            DataEntrada = DateTime.Today,
            DataSaida = DateTime.Today.AddDays(2),
            Status = StatusReserva.Confirmada
        });

        var reservas = repo.ObterPorStatus(StatusReserva.Confirmada);
        foreach (var r in reservas)
            Console.WriteLine($"Reserva: {r.NomeHospede}, Entrada: {r.DataEntrada:dd/MM/yyyy}");
    }

    static void TestarCursoOnline()
    {
        var repo = new CursoOnlineJsonRepository();
        var servico = new CatalogoCursosService(repo);
        var curso = new CursoOnline { Titulo = "C# Básico", Instrutor = "Ana" };
        var sucesso = servico.RegistrarCurso(curso);
        Console.WriteLine(sucesso ? "Curso registrado." : "Curso já existente.");
    }
