namespace ApiExterna.Service;

public interface INotaFiscalService
{
    Task CadastrarComCancellationToken(CancellationToken cancellationToken);

    Task CadastrarSemCancellationToken();
}