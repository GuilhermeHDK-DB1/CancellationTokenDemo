using ApiExterna.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiExterna.Controllers;

[ApiController]
[Route("[controller]")]
public class NotaFiscalController : ControllerBase
{
    private readonly ILogger<NotaFiscalController> _logger;
    private readonly INotaFiscalService _notaFiscalService;

    public NotaFiscalController(ILogger<NotaFiscalController> logger, INotaFiscalService notaFiscalService)
    {
        _logger = logger;
        _notaFiscalService = notaFiscalService;
    }

    [HttpPost("CadastrarComCancellationToken")] // CancellationToken implementada de forma correta
    public async Task<IActionResult> CadastrarComCancellationToken(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Task iniciada");
        await _notaFiscalService.CadastrarComCancellationToken(cancellationToken);
        _logger.LogInformation("Task finalizada com sucesso!");
        return Ok();
    }
    
    [HttpPost("CadastrarSemCancellationToken")] // CancellationToken implementada de forma incorreta // Não confiar em assinatura
    public async Task<IActionResult> CadastrarSemCancellationToken(CancellationToken cancellationToken) 
    {
        _logger.LogInformation("Task iniciada");
        await _notaFiscalService.CadastrarSemCancellationToken();
        _logger.LogInformation("Task finalizada com sucesso!");
        return Ok();
    }
}