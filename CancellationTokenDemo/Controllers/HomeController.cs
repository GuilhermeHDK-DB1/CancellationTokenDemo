using System.Text.Json;
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
        _logger.LogInformation("Task iniciada");
        
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
        tabela2.QuantidadeCadastrada++;
        await _context.SaveChangesAsync(cancellationToken);
        
        _logger.LogInformation("Task finalizada com sucesso!");
    
        return Ok(tabela2.QuantidadeCadastrada);
    }
    
    [HttpPost("CadastrarComUnitOfWork")] // Funciona com cancellationToken
    public async Task<IActionResult> RegisterWithUnitOfWork(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Task iniciada");
        var userName = $"User-{Guid.NewGuid()}";
        _context.Tabela1.Add(new Tabela1(userName));

        await Task.Delay(2500, cancellationToken);

        var tabela2 = _context.Tabela2.FirstOrDefault();
        if (tabela2 is null)
        {
            tabela2 = new Tabela2();
            _context.Add(tabela2);
        }
        tabela2.QuantidadeCadastrada++;

        await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Task finalizada com sucesso!");

        return Ok(tabela2.QuantidadeCadastrada);
    }
    
    [HttpPost("CadastrarComCancellationToken")] // CancellationToken implementada de forma correta
    public async Task<IActionResult> CadastrarComCancellationToken(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Task iniciada");
        var userName = $"User-{Guid.NewGuid()}";
        var tabela1 = new Tabela1(userName);

        var httpClient = new HttpClient();
        string json = JsonSerializer.Serialize(tabela1);
        var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        await httpClient.PostAsync("https://localhost:7017/NotaFiscal/CadastrarComCancellationToken", httpContent, cancellationToken);

        _context.Tabela1.Add(tabela1);
        
        var tabela2 = _context.Tabela2.FirstOrDefault();
        if (tabela2 is null)
        {
            tabela2 = new Tabela2();
            _context.Add(tabela2);
        }
        tabela2.QuantidadeCadastrada++;

        await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Task finalizada com sucesso!");

        return Ok(tabela2.QuantidadeCadastrada);
    }
    
    [HttpPost("CadastrarSemCancellationToken")] // CancellationToken implementada de forma incorreta // Não confiar em assinatura
    public async Task<IActionResult> CadastrarSemCancellationToken(CancellationToken cancellationToken) 
    {
        _logger.LogInformation("Task iniciada");
        var userName = $"User-{Guid.NewGuid()}";
        var tabela1 = new Tabela1(userName);

        var httpClient = new HttpClient();
        string json = JsonSerializer.Serialize(tabela1);
        var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        await httpClient.PostAsync("https://localhost:7017/NotaFiscal/CadastrarSemCancellationToken", httpContent, cancellationToken);

        _context.Tabela1.Add(tabela1);
        
        var tabela2 = _context.Tabela2.FirstOrDefault();
        if (tabela2 is null)
        {
            tabela2 = new Tabela2();
            _context.Add(tabela2);
        }
        tabela2.QuantidadeCadastrada++;

        await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Task finalizada com sucesso!");

        return Ok(tabela2.QuantidadeCadastrada);
    }
}