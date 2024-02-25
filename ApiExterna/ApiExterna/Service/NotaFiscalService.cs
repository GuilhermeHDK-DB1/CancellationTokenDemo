namespace ApiExterna.Service;

public class NotaFiscalService : INotaFiscalService
{
    private readonly ILogger<NotaFiscalService> _logger;
    
    public NotaFiscalService(ILogger<NotaFiscalService> logger)
    {
        _logger = logger;
    }
    
    public async Task CadastrarComCancellationToken(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(1000, cancellationToken);
            _logger.LogInformation("*** Task is running ***");
        }
    }

    public async Task CadastrarSemCancellationToken()
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(1000);
            _logger.LogInformation("*** Task is running ***");
        }
    }
}