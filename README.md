
--------------------------------Nomes dos integrantes do grupo-----------------------------------------

Bruno Rocco Wolfardt;
Felipe Sousa da Costa;
Ian Fernandes Borges.

-------------------------------------------------------------------------------------------------------
Reserva de Salas

Este projeto implementa uma aplicação de console para criar as configurações de reservas de salas de estudo na universidade e gerenciá-las.

--------------------------------Estrutura do Projeto-----------------------------------------

---------------------------------ConfiguracaoReserva.cs-----------------------------------------

Classe responsável por validar e guardar o intervalo de datas e intervalo de horas permitidas para as reservas.

*Propriedades:*

DateTime DataMinima
DateTime DataMaxima
TimeSpan HoraMinima
TimeSpan HoraMaxima

O construtor recebe as quatro propriedades e realiza validações iniciais:

DataMinima < DataMaxima e HoraMinima < HoraMaxima

*Métodos de validação:*

*bool ValidarData(DateTime data) - Usada para verificar se a data informada para reserva está entre o intervalo definido na configuração da reserva.

*bool ValidarHora(TimeSpan hora) - Usada para verificar se a hora informada para reserva está entre o intervalo definido na configuração da reserva.

---------------------------------Anotacao.cs---------------------------------

Classe que representa uma anotação simples com um texto e a data de criação.

Atributos públicos:

Texto – Armazena o conteúdo da anotação.

DataCriacao – Registra automaticamente a data e hora em que a anotação foi criada.

Métodos:

ToString() – Retorna a anotação formatada como uma string no padrão "dd/MM/yyyy HH:mm: Texto".

---------------------------------Local.cs---------------------------------

Classe que representa um local físico que pode ser reservado, contendo nome e capacidade máxima de pessoas.

Atributos públicos:

Nome – Nome do local

Capacidade – Número máximo de pessoas que o local comporta.

Métodos:

ValidarCapacidade(int quantidade) – Retorna true se a quantidade informada for menor ou igual à capacidade do local.

ToString() – Formata a saída como "Nome (Cap: Capacidade)".

---------------------------------Participante.cs---------------------------------

Classe que representa um participante que pode estar vinculado a compromissos.

Atributos públicos:

Nome – Nome do participante.

Compromissos – Lista de compromissos associados a esse participante.

Métodos:

AdicionarCompromisso – Adiciona um compromisso à lista

ToString() – Retorna apenas o nome do participante.

---------------------------------compromisso.cs---------------------------------

A classe serve para representar o evento que é agendado pelo usuário. Onde esta abrange as informaçõe acerca da data, descrição, local, participantes e anotações. 

DataHora: Data e hora do compromisso. Tem que estar no futuro.

Descrição: Descrição do compromisso.

Usuário:  Usuário responsável pelo compromisso.

Local: Local onde o compromisso irá ocorrer.

Participantes: Participantes associados ao compromisso.

Anotações: Anotação adicional endereçada ao compromisso

Adicionar Pariticipante(Participante p): adiciona um participante ao compromisso e atualiza a referência do compromisso no participante.

Adicionar Anotacao(string texto): Cria a nova anotação e inseri no compromisso.

ToString(): Retorna descrição resumida do compromisso.

---------------------------------Reserva.cs---------------------------------

Classe que representa realmente uma reserva, usando uma instância de ConfiguracaoReserva para validar suas entradas de valores.

*Atributos privados:*

_data
_hora
_descricaoSala
_capacidade

_configReserva (referência à configuração da reserva)

*Métodos de registro:*

*RegistrarData(DateTime data) - Registra a data no formato dd/mm/yyyy

*RegistrarHora(TimeSpan hora) - Registra a data no formato hh:mm

*RegistrarDescricao(string descricao) - Registra a descrição da reserva que seria o nome ou código da sala a ser reservada

*RegistrarCapacidade(int capacidade) - Registra a capacidade de pessoas prevista para a sala reservada sendo no máximo 39 pessoas

*ValidarReserva() - Chama ValidarData e ValidarHora de ConfiguracaoReserva, e verifica capacidade de pessoas(1 a 39)

*ToString() - Formata a saída em dd/MM/yyyy para data e hh:mm para hora

---------------------------------Program.cs-----------------------------------------

É onde está o fluxo principal da aplicação, ele atua com o usuário primeiramente fazendo a configuração inicial das reservas e depois registrando uma reserva

*Configuração:*

Solicita ao usuário as datas mínima e máxima (formato dd/MM/yyyy).

Solicita as horas mínima e máxima (formato hh:mm).

Solicita a descrição do conpromisso (formato string).

Cria a instância de ConfiguracaoReserva usando:
ReservaConfig = new(dataMin, dataMax, horaMin, horaMax)

*Reserva:*

Solicita ao usuário a data da reserva (dd/MM/yyyy)

Solicita a hora da reserva (hh:mm)

Solicita a descrição da sala(código da sala)

Solicita a capacidade

Cria a instância de Reserva usando registrando cada campo

Por fim, depois de validado exibe sucesso ou a lista de erros ao usuário.