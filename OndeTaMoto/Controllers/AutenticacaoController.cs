using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OndeTaMotoBusiness;
using OndeTaMotoModel;
using System.Threading.Tasks;
using System.Security.Claims;

namespace OndeTaMotoApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITokenService _tokenService;

        public AutenticacaoController(IUsuarioService usuarioService, ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        [HttpPost("registrar")]
        [AllowAnonymous]
        public async Task<IActionResult> Registrar([FromBody] UsuarioModel dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Senha))
                return BadRequest(new { error = "Email e senha são obrigatórios." });

            var existente = await _usuarioService.GetByEmailAsync(dto.Email);
            if (existente != null)
                return Conflict(new { error = "Usuário já existe com este e-mail." });

            var usuario = await _usuarioService.CreateAsync(dto.Email, dto.Senha, dto.Role ?? "Usuario");

            return CreatedAtAction(
                nameof(Me),
                routeValues: null,
                value: new
                {
                    message = "Usuário registrado com sucesso!",
                    usuario.Id,
                    usuario.Email,
                    usuario.Role
                });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UsuarioModel dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Senha))
                return BadRequest(new { error = "Email e senha são obrigatórios." });

            var usuario = await _usuarioService.ValidateCredentialsAsync(dto.Email, dto.Senha);
            if (usuario == null)
                return Unauthorized(new { error = "Credenciais inválidas." });

            var token = _tokenService.GenerateToken(
                usuario.Id.ToString(),
                usuario.Email,
                usuario.Role ?? "Usuario"
            );

            return Ok(token);
        }

        [HttpGet("me")]
        [Authorize]
        public IActionResult Me()
        {
            var email = User.Identity?.Name ?? "desconhecido";
            var role = User.FindFirst(ClaimTypes.Role)?.Value
                       ?? User.FindFirst("role")?.Value
                       ?? "Sem função";

            return Ok(new
            {
                Email = email,
                Role = role
            });
        }
    }
}