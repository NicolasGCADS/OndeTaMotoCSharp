using OndeTaMotoModel;
using OndeTaMotoData;

namespace OndeTaMotoBusiness
{
    public class SetorService
    {
        private readonly AppDbContext _context;

        public SetorService(AppDbContext context)
        {
            _context = context;
        }

        public List<SetorModel> ListarTodos() => _context.Setores.ToList();

        public SetorModel? ObterPorId(int id) =>
            _context.Setores.Find(id);

        public SetorModel Criar(SetorModel setor)
        {
            _context.Setores.Add(setor);
            _context.SaveChanges();
            return setor;
        }

        public bool Atualizar(SetorModel setor)
        {
            var existente = _context.Setores.Find(setor.Id);
            if (existente == null) return false;

            existente.Nome = setor.Nome;
            existente.Capacidade = setor.Capacidade;

            _context.SaveChanges();
            return true;
        }

        public bool Remover(int id)
        {
            var setor = _context.Setores.Find(id);
            if (setor == null) return false;

            _context.Setores.Remove(setor);
            _context.SaveChanges();
            return true;
        }
    }
}
