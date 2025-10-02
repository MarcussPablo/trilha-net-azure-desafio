
using Microsoft.AspNetCore.Mvc;
using TrilhaNetAzureDesafio.Context;
using TrilhaNetAzureDesafio.Models;

namespace TrilhaNetAzureDesafio.Controllers;

[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly RHContext _context;


    public FuncionarioController(RHContext context)
    {
        _context = context;

    }


    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        var funcionario = _context.Funcionarios.Find(id);

        if (funcionario == null)
            return NotFound();

        return Ok(funcionario);
    }

    [HttpPost]
    public IActionResult Criar(Funcionario funcionario)
    {
        _context.Funcionarios.Add(funcionario);
        _context.SaveChanges();

        return CreatedAtAction(nameof(ObterPorId), new { id = funcionario.Id }, funcionario);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, Funcionario funcionario)
    {
        var funcionarioBanco = _context.Funcionarios.Find(id);

        if (funcionarioBanco == null)
            return NotFound();

        funcionarioBanco.Nome = funcionario.Nome;
        funcionarioBanco.Endereco = funcionario.Endereco;
        funcionarioBanco.EmailProfissional = funcionario.EmailProfissional;
        funcionarioBanco.Ramal=funcionario.Ramal;
        funcionarioBanco.Salario = funcionario.Salario;
        funcionarioBanco.DataAdmissao = funcionarioBanco.DataAdmissao;

        
        // TODO: As propriedades estão incompletas

        // TODO: Chamar o método de Update do _context.Funcionarios para salvar no Banco SQL
        _context.SaveChanges();

       
   

        return Ok(funcionarioBanco);
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var funcionarioBanco = _context.Funcionarios.Find(id);

        if (funcionarioBanco == null)
            return NotFound();

        // TODO: Chamar o método de Remove do _context.Funcionarios para salvar no Banco SQL
        _context.Funcionarios.Remove(funcionarioBanco);
        _context.SaveChanges();

       
        // TODO: Chamar o método UpsertEntity para salvar no Azure Table

        return NoContent();
    }
}
