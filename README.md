
--------------------------------Nomes dos integrantes do grupo-----------------------------------------

Daniel Vier Alberton;
Ian Fernandes Borges.

-------------------------------------------------------------------------------------------------------
-----------------------------Sistema de Biblioteca com Empréstimos-----------------------------

Este sistema é composto por três classes: Livro, Leitor e Emprestimo. A classe Livro possui atributos como título, autor e um status de disponibilidade. A classe Leitor representa um usuário da biblioteca que mantém uma lista de empréstimos realizados. Já a classe Emprestimo funciona como intermediária entre o livro e o leitor, registrando as datas de empréstimo e devolução.

O Program.cs permite que o usuário informe seu nome, escolha um livro disponível da lista e realize um empréstimo. O sistema valida se o livro está disponível antes de emprestar.

-------------------------------------------------------------------------------------------------------

-----------------------------Sistema de Cadastro Escolar-----------------------------

Neste sistema, temos a superclasse Pessoa, que contém atributos comuns como nome, CPF e data de nascimento. As subclasses são Aluno, Professor e Funcionario, cada uma com seus próprios atributos: matrícula e turma para aluno, disciplinas para professor e setor para funcionário.

O Program.cs solicita que o usuário informe o tipo de pessoa a ser cadastrada e os respectivos dados. Após o preenchimento, os dados são exibidos no console.

-------------------------------------------------------------------------------------------------------

-----------------------------Sistema de Cursos Online-----------------------------

As classes principais são Curso, Aula, AlunoCurso e Matricula. Curso contém uma lista de aulas, e cada aula tem título, duração e professor. AlunoCurso representa o aluno e guarda suas matrículas. A Matricula liga o aluno ao curso e armazena dados como progresso e data de inscrição.

O Program.cs permite ao usuário cadastrar um curso com várias aulas e realizar a matrícula de um aluno nesse curso.

-------------------------------------------------------------------------------------------------------

-----------------------------Sistema de Pet Shop-----------------------------

A superclasse Animal contém atributos comuns como nome, idade e peso, além de uma referência ao Dono. As subclasses Cachorro, Gato e Passaro possuem características específicas como raça, porte, comportamento, pelagem, etc.

O Program.cs permite ao usuário informar dados do dono, do tipo de animal e cadastrar um pet com as informações adequadas.

-------------------------------------------------------------------------------------------------------

-----------------------------Sistema de Vendas com Composição-----------------------------

As classes envolvidas são Produto, ItemPedido e Pedido. Produto representa o item com nome, preço e código. ItemPedido associa um produto a uma quantidade e calcula o subtotal. Pedido contém uma lista de itens e calcula o total do pedido.

No Program.cs, o usuário pode adicionar vários itens ao pedido e ao final visualizar o valor total da compra.

-------------------------------------------------------------------------------------------------------

-----------------------------Sistema de Controle de Veículos e Manutenções-----------------------------

O sistema possui as classes Veiculo e Manutencao. Veiculo possui atributos como modelo, placa e tipo, além de uma lista de manutenções. Cada Manutencao tem data, descrição e tipo (preventiva ou corretiva).

O Program.cs permite o cadastro de um veículo e o registro de manutenções, com validação para impedir mais de uma manutenção no mesmo dia.

-------------------------------------------------------------------------------------------------------

-----------------------------Sistema de Recrutamento-----------------------------

As principais classes são Candidato, Vaga e Candidatura. Candidato armazena dados pessoais e currículo. Vaga descreve o cargo, empresa e requisitos. Candidatura associa um candidato a uma vaga, armazenando a data de envio e o status.

O Program.cs solicita dados do candidato e da vaga, cria uma candidatura e exibe o status.

-------------------------------------------------------------------------------------------------------

-----------------------------Sistema de Streaming-----------------------------

A superclasse Midia contém atributos como título, duração e gênero. Suas subclasses são Filme, Serie e Documentario, cada uma com propriedades específicas. Serie também contém uma lista de episódios. Cada classe implementa o método polimórfico ExibirResumo() de forma distinta.

No Program.cs, o usuário pode cadastrar uma mídia e ver o resumo exibido conforme o tipo de conteúdo.

-------------------------------------------------------------------------------------------------------

-----------------------------Sistema de Controle de Treinos-----------------------------

As classes envolvidas são AlunoTreino, Treino e Exercicio. AlunoTreino contém os dados do aluno e uma lista de treinos. Cada Treino possui objetivo, data de criação e uma lista de exercícios. Exercicio detalha o nome, número de séries, repetições e carga.

O Program.cs permite ao usuário cadastrar um treino com vários exercícios e exibe a carga total calculada.

-------------------------------------------------------------------------------------------------------

-----------------------------Sistema de Eventos Culturais-----------------------------

A superclasse Evento define atributos comuns como título, data, local e capacidade. As subclasses Oficina, Palestra e Show adicionam dados específicos como material, palestrante ou banda. A classe Participante pode se inscrever em vários eventos. O método ExibirInformacoes() é polimórfico e exibe os detalhes específicos do evento.

O Program.cs permite que o usuário informe os dados do evento e exibe as informações formatadas conforme o tipo.