namespace ConsoleApp.Modelos;

public class ReservaHotel : IEntidade
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeHospede { get; set; } = "";
    public DateTime DataEntrada { get; set; }
    public DateTime DataSaida { get; set; }
    public StatusReserva Status { get; set; }
}