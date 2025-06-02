namespace ConsoleApp.Modelos;

public class Documentario : Midia
{
    public string Tema { get; set; }
    public string Narrador { get; set; }

    public override void ExibirResumo()
    {
        Console.WriteLine($"{Titulo} - Documentário sobre {Tema}, narrado por {Narrador}");
    }
}