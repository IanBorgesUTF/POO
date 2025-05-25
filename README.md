
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

---------------------------------Reserva.cs---------------------------------

Classe que representa realmente uma reserva, usando uma instância de ConfiguracaoReserva para validar suas entradas de valores.

*Atributos privados:*

_data
_hora
_descricaoSala
_capacidade

_config (referência à configuração)

*Lista de erros - List<string> Erros guarda uma lista contendo as mensagens de validação dos possíveis erros gerados por conta dos dados de entrada
    O construtor Reserva(ConfiguracaoReserva config) inicializa a lista de erros e guarda a configuração

*Métodos de registro:*

*RegistrarData(DateTime data) - Registra a data no formato dd/mm/yyyy

*RegistrarHora(TimeSpan hora) - Registra a data no formato hh:mm

*RegistrarDescricao(string descricao) - Registra a descrição da reserva que seria o nome ou código da sala a ser reservada

*RegistrarCapacidade(int capacidade) - Registra a capacidade de pessoas prevista para a sala reservada sendo no máximo 39 pessoas

*ValidarReserva() - Chama ValidarData e ValidarHora de ConfiguracaoReserva, e verifica capacidade de pessoas(1 a 39)

*ToString() - Formata a saída em dd/MM/yyyy para data e hh:mm para hora

---------------------------------Program.cs-----------------------------------------

É onde está o fluxo principal da aplicação, ele atua em primeiro o usuário fazendo a configuração iniciais das reservas e depois registrando uma reserva

*Configuração:*

Solicita ao usuário as datas mínima e máxima (formato dd/MM/yyyy).

Solicita as horas mínima e máxima (formato hh:mm).

Cria a instância de ConfiguracaoReserva usando:
ReservaConfig = new(dataMin, dataMax, horaMin, horaMax)

*Reserva:*

Solicita ao usuário a data da reserva (dd/MM/yyyy)

Solicita a hora da reserva (hh:mm)

Solicita a descrição da sala(código da sala)

Solicita a capacidade

Cria a instância de Reserva usando:
Reserva reserva = new(config)

Registra cada campo

Chama reserva.ValidarReserva()

Por fim, depois de validado exibe sucesso ou a lista de erros ao usuário.