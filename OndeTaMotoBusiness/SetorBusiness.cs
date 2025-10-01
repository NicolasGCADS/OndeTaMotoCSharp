using OndeTaMotoModel;
using System.Collections.Generic;
using System.Linq;

namespace OndeTaMotoBusiness
{
    public class SetorService
    {
        private static readonly List<SetorModel> _setores = new();

        private static int _nextId = 1;

        public List<SetorModel> ListarTodos() => _setores;

        public SetorModel? ObterPorId(int id) =>
            _setores.FirstOrDefault(s => s.Id == id);

        public SetorModel Criar(SetorModel setor)
        {
            setor.Id = _nextId++;
            _setores.Add(setor);
            return setor;
        }

        public bool Atualizar(SetorModel setor)
        {
            var existente = ObterPorId(setor.Id);
            if (existente == null) return false;

            existente.Nome = setor.Nome;
            existente.Tamanho = setor.Tamanho;

            return true;
        }

        public bool Remover(int id)
        {
            var setor = ObterPorId(id);
            if (setor == null) return false;

            _setores.Remove(setor);
            return true;
        }
    }
}
