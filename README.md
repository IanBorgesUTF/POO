
--------------------------------Nomes dos integrantes do grupo-----------------------------------------

Bruno Rocco Wolfardt
Felipe Sousa da Costa
Ian Fernandes Borges.

-------------------------------------------------------------------------------------------------------
-----------------------------Gerenciador de Catálogo de Produtos-----------------------------

Neste sistema, temos a entidade Produto, que contém as propriedades: Id, Nome, Descricao, Preco e Estoque. A interface IProdutoRepository define métodos para realizar operações CRUD. A classe ProdutoJsonRepository implementa essa interface e realiza a persistência dos dados em um arquivo JSON chamado "produtos.json".

O Program.cs pode ser usado para adicionar produtos ao catálogo

-------------------------------------------------------------------------------------------------------

-----------------------------Biblioteca de Músicas Pessoais com Repositório Genérico-----------------------------

Neste projeto, foi criada a entidade Musica, que implementa a interface IEntidade e possui os atributos Id, Titulo, Artista, Album e Duracao. Um GenericJsonRepository<Musica> é utilizado para persistir as músicas em "musicas.json", simplificando as operações de CRUD.

O Program.cs permite adicionar novas músicas utilizando o repositório genérico.

-------------------------------------------------------------------------------------------------------

-----------------------------Catálogo de Filmes com Consultas por Gênero-----------------------------

Aqui, a entidade Filme implementa IEntidade e inclui Id, Titulo, Diretor, AnoLancamento e Genero. A interface IFilmeRepository herda de IRepository e adiciona o método ObterPorGenero.

A classe FilmeJsonRepository herda do repositório genérico e implementa IFilmeRepository, persistindo os dados em "filmes.json". O Program.cs permite incluir filmes por gênero.

-------------------------------------------------------------------------------------------------------

-----------------------------Sistema de Gerenciamento de Funcionários e Departamentos-----------------------------

Este sistema possui duas entidades: Departamento e Funcionario, ambas implementando IEntidade. O Funcionario contém um DepartamentoId que referencia o departamento ao qual pertence.

Utiliza-se um GenericJsonRepository para persistência. O Program.cs permite cadastrar departamentos e funcionários.

-------------------------------------------------------------------------------------------------------

-----------------------------Registro de Pacientes em Clínica com Filtro por Idade-----------------------------

Neste sistema, a entidade Paciente possui Id, NomeCompleto, DataNascimento e ContatoEmergencia. A interface IPacienteRepository define um método extra: ObterPorFaixaEtaria.

A classe PacienteJsonRepository implementa essa interface, incluindo a lógica de filtragem de pacientes por idade. Os dados são persistidos em "pacientes.json" e as funcionalidades incluem adicionar pacientes por faixa etária.

-------------------------------------------------------------------------------------------------------

-----------------------------Inventário de Equipamentos de TI-----------------------------

Neste sistema, foi criada a entidade EquipamentoTI com os atributos Id, NomeEquipamento, TipoEquipamento, NumeroSerie e DataAquisicao. A interface IEquipamentoTIRepository define as operações e a classe InMemoryEquipamentoTIRepository implementa o repositório em memória, usando uma lista interna para persistência temporária.

O Program.cs permite gerenciar o inventário sem uso de arquivos.

-------------------------------------------------------------------------------------------------------

-----------------------------Sistema de Pedidos de Restaurante-----------------------------

Aqui, temos a classe abstrata ItemCardapio com os atributos Id, NomeItem e Preco. As subclasses Prato e Bebida adicionam atributos específicos como DescricaoDetalhada, Vegetariano, VolumeMl e Alcoolica.

Com GenericJsonRepository, é possível adicionar pratos e bebidas a um único arquivo, listando todos os itens do cardápio, mesmo sendo de tipos distintos.

-------------------------------------------------------------------------------------------------------

-----------------------------Gerenciador de Arquivos Digitais-----------------------------

Neste projeto, a entidade ArquivoDigital contém Id, NomeArquivo, TipoArquivo, TamanhoBytes e DataUpload. O repositório ArquivoDigitalJsonRepository é refatorado para herdar de GenericJsonRepository, eliminando redundância de código e mantendo métodos específicos se necessário.

O sistema permite gerenciar arquivos digitais de maneira padronizada e eficiente.

-------------------------------------------------------------------------------------------------------

-----------------------------Sistema de Reservas de Hotel com Status-----------------------------

A entidade ReservaHotel inclui um StatusReserva (enum) entre seus atributos. A interface IReservaHotelRepository adiciona o método ObterPorStatus, permitindo filtrar reservas com base no status atual.

A classe ReservaHotelJsonRepository implementa esse método e armazena os dados em "reservas.json". O sistema é capaz de gerenciar reservas.

-------------------------------------------------------------------------------------------------------

-----------------------------Plataforma de Cursos Online-----------------------------

Neste sistema, a entidade CursoOnline é gerenciada pela interface ICursoOnlineRepository e persistida por meio da classe CursoOnlineJsonRepository. A camada de serviço CatalogoCursosService utiliza o repositório para aplicar regras de negócio, como verificação de duplicidade antes de registrar novos cursos.

O sistema separa claramente persistência de lógica de negócios, seguindo boas práticas de arquitetura.
