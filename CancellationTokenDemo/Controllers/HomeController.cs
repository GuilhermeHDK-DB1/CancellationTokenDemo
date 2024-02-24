using CancellationTokenDemo.Dados;
using CancellationTokenDemo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CancellationTokenDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    [HttpPost("CadastrarSemTransaction")] // Não funciona com cancellationToken
    public async Task<IActionResult> RegisterWithoutTransaction(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando");
        
        var userName = $"User-{Guid.NewGuid()}";
        _context.Tabela1.Add(new Tabela1(userName));
        await _context.SaveChangesAsync(cancellationToken);
    
        await Task.Delay(2500, cancellationToken);
    
        var tabela2 = _context.Tabela2.FirstOrDefault();
        if (tabela2 is null)
        {
            tabela2 = new Tabela2();
            _context.Add(tabela2);
        }
        tabela2.QuantidadeDeContas++;
        await _context.SaveChangesAsync(cancellationToken);
        
        _logger.LogInformation("Finalizando");
    
        return Ok(tabela2.QuantidadeDeContas);
    }
    
    [HttpPost("CadastrarComUnitOfWork")] // Funciona com cancellationToken
    public async Task<IActionResult> RegisterWithUnitOfWork(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando");
        var userName = $"User-{Guid.NewGuid()}";
        _context.Tabela1.Add(new Tabela1(userName));

        await Task.Delay(2500, cancellationToken);

        var tabela2 = _context.Tabela2.FirstOrDefault();
        if (tabela2 is null)
        {
            tabela2 = new Tabela2();
            _context.Add(tabela2);
        }
        tabela2.QuantidadeDeContas++;

        await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Finalizando");

        return Ok(tabela2.QuantidadeDeContas);
    }
}