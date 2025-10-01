using OndeTaMotoBusiness;
using OndeTaMotoModel;
using Microsoft.AspNetCore.Mvc;

namespace OndeTaMotoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SetorController : ControllerBase
{
    private readonly SetorService _setorService;

    public SetorController(SetorService setorService)
    {
        _setorService = setorService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var setores = _setorService.ListarTodos();
        return setores.Count == 0 ? NoContent() : Ok(setores);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var setor = _setorService.ObterPorId(id);
        return setor == null ? NotFound() : Ok(setor);
    }

    [HttpPost]
    public IActionResult Post([FromBody] SetorModel novoSetor)
    {
        if (string.IsNullOrWhiteSpace(novoSetor.Nome))
            return BadRequest("Nome é obrigatório.");

        var criado = _setorService.Criar(novoSetor);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SetorModel setorAtualizado)
    {
        if (setorAtualizado == null || setorAtualizado.Id != id)
            return BadRequest("Dados inconsistentes.");

        return _setorService.Atualizar(setorAtualizado) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _setorService.Remover(id) ? NoContent() : NotFound();
    }
}
