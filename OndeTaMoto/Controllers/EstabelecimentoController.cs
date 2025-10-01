using OndeTaMotoBusiness;
using OndeTaMotoModel;
using Microsoft.AspNetCore.Mvc;

namespace OndeTaMotoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstabelecimentoController : ControllerBase
{
    private readonly EstabelecimentoService _estabelecimentoService;

    public EstabelecimentoController(EstabelecimentoService estabelecimentoService)
    {
        _estabelecimentoService = estabelecimentoService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var estabelecimentos = _estabelecimentoService.ListarTodos();
        return estabelecimentos.Count == 0 ? NoContent() : Ok(estabelecimentos);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var estabelecimento = _estabelecimentoService.ObterPorId(id);
        return estabelecimento == null ? NotFound() : Ok(estabelecimento);
    }

    [HttpPost]
    public IActionResult Post([FromBody] EstabelecimentoModel novoEstabelecimento)
    {
        if (string.IsNullOrWhiteSpace(novoEstabelecimento.Nome))
            return BadRequest("Nome é obrigatório.");

        var criado = _estabelecimentoService.Criar(novoEstabelecimento);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] EstabelecimentoModel estabelecimentoAtualizado)
    {
        if (estabelecimentoAtualizado == null || estabelecimentoAtualizado.Id != id)
            return BadRequest("Dados inconsistentes.");

        return _estabelecimentoService.Atualizar(estabelecimentoAtualizado) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _estabelecimentoService.Remover(id) ? NoContent() : NotFound();
    }
}
