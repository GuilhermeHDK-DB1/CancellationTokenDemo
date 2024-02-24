namespace ApiExterna.Service;

public class NotaFiscalService : INotaFiscalService
{
    public async Task CadastrarComCancellationToken(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(1000, cancellationToken);
            Console.WriteLine("*** Task is running ***");
        }
    }
    
    public async Task CadastrarSemCancellationToken()
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(1000);
            Console.WriteLine("*** Task is running  CadastrarSemCancellationToken***");
        }
    }
}