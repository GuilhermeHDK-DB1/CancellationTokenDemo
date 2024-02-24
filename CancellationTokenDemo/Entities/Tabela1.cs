namespace CancellationTokenDemo.Entities;

public class Tabela1
{
    public Tabela1(string userName)
    {
        UserName = userName;
    }

    public int Id { get; set; }
    public string UserName { get; set; }
}