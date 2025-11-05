using Microsoft.EntityFrameworkCore;
using OndeTaMotoData;
using OndeTaMotoModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OndeTaMotoBusiness
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioModel?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UsuarioModel?> ValidateCredentialsAsync(string email, string senha)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }

        public async Task<UsuarioModel> CreateAsync(string email, string senha, string role)
        {
            var usuario = new UsuarioModel
            {
                Email = email,
                Senha = senha,
                Role = role
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        // Métodos síncronos usados pelos controllers CRUD
        public List<UsuarioModel> ListarTodos() => _context.Usuarios.ToList();

        public UsuarioModel? ObterPorId(int id) => _context.Usuarios.Find(id);

        public UsuarioModel Criar(UsuarioModel usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public bool Atualizar(UsuarioModel usuario)
        {
            var existente = _context.Usuarios.Find(usuario.Id);
            if (existente == null) return false;

            existente.Email = usuario.Email;
            existente.Senha = usuario.Senha;
            existente.Role = usuario.Role;

            _context.SaveChanges();
            return true;
        }

        public bool Remover(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }
    }
}
