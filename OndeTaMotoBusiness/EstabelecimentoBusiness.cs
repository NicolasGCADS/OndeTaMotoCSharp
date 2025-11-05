using OndeTaMotoModel;
using OndeTaMotoData;


namespace OndeTaMotoBusiness;

public class EstabelecimentoService
{
    private readonly AppDbContext _context;

    public EstabelecimentoService(AppDbContext context)
    {
        _context = context;
    }

    public List<EstabelecimentoModel> ListarTodos() => _context.Estabelecimentos.ToList();

    public EstabelecimentoModel? ObterPorId(int id) => _context.Estabelecimentos.Find(id);

    public EstabelecimentoModel Criar(EstabelecimentoModel estabelecimento)
    {
        _context.Estabelecimentos.Add(estabelecimento);
        _context.SaveChanges();
        return estabelecimento;
    }

    public bool Atualizar(EstabelecimentoModel estabelecimento)
    {
        var existente = _context.Estabelecimentos.Find(estabelecimento.Id);
        if (existente == null) return false;

        existente.Nome = estabelecimento.Nome;
        existente.Tamanho = estabelecimento.Tamanho;

        _context.SaveChanges();
        return true;
    }

    public bool Remover(int id)
    {
        var estabelecimento = _context.Estabelecimentos.Find(id);
        if (estabelecimento == null) return false;

        _context.Estabelecimentos.Remove(estabelecimento);
        _context.SaveChanges();
        return true;
    }
}
