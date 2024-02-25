namespace CancellationTokenDemo.Entities;

public class Tabela1
{
    public Tabela1(string produto)
    {
        Produto = produto;
    }

    public int Id { get; set; }
    public string Produto { get; set; }
}