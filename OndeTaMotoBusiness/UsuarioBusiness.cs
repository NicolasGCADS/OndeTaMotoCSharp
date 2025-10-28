using OndeTaMotoModel;
using OndeTaMotoData;
using System.Collections.Generic;
using System.Linq;

namespace OndeTaMotoBusiness;

public class UsuarioService
{
    private readonly AppDbContext _context;

    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }

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
