using System.Threading.Tasks;
using OndeTaMotoModel;
using System.Collections.Generic;

namespace OndeTaMotoBusiness
{
    public interface IUsuarioService
    {
        Task<UsuarioModel?> GetByEmailAsync(string email);
        Task<UsuarioModel?> ValidateCredentialsAsync(string email, string senha);
        Task<UsuarioModel> CreateAsync(string email, string senha, string role);

        // Métodos síncronos usados pelos controllers CRUD
        List<UsuarioModel> ListarTodos();
        UsuarioModel? ObterPorId(int id);
        UsuarioModel Criar(UsuarioModel usuario);
        bool Atualizar(UsuarioModel usuario);
        bool Remover(int id);
    }
}
