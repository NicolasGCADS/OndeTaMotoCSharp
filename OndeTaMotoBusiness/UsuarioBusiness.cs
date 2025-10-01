using OndeTaMotoModel;
using System.Collections.Generic;
using System.Linq;

namespace OndeTaMotoBusiness;

public class UsuarioService
{
    private static readonly List<UsuarioModel> _usuarios = new();

    private static int _nextId = 1;

    public List<UsuarioModel> ListarTodos() => _usuarios;

    public UsuarioModel? ObterPorId(int id) => _usuarios.FirstOrDefault(u => u.Id == id);

    public UsuarioModel Criar(UsuarioModel usuario)
    {
        usuario.Id = _nextId++;
        _usuarios.Add(usuario);
        return usuario;
    }

    public bool Atualizar(UsuarioModel usuario)
    {
        var existente = ObterPorId(usuario.Id);
        if (existente == null) return false;

        existente.Email = usuario.Email;
        existente.Senha = usuario.Senha;

        return true;
    }

    public bool Remover(int id)
    {
        var usuario = ObterPorId(id);
        if (usuario == null) return false;

        _usuarios.Remove(usuario);
        return true;
    }
}
