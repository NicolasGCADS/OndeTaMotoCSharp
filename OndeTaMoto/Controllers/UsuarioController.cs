using OndeTaMotoBusiness;
using OndeTaMotoModel;
using Microsoft.AspNetCore.Mvc;

namespace OndeTaMotoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var usuarios = _usuarioService.ListarTodos();
        return usuarios.Count == 0 ? NoContent() : Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var usuario = _usuarioService.ObterPorId(id);
        return usuario == null ? NotFound() : Ok(usuario);
    }

    [HttpPost]
    public IActionResult Post([FromBody] UsuarioModel usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Email))
            return BadRequest("Email é obrigatório.");

        var criado = _usuarioService.Criar(usuario);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] UsuarioModel usuario)
    {
        if (usuario == null || usuario.Id != id)
            return BadRequest("Dados inconsistentes.");

        return _usuarioService.Atualizar(usuario) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _usuarioService.Remover(id) ? NoContent() : NotFound();
    }
}
