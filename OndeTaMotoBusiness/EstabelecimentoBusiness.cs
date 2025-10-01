using OndeTaMotoModel;
using System.Collections.Generic;
using System.Linq;

namespace OndeTaMotoBusiness;

public class EstabelecimentoService
{
    private static readonly List<EstabelecimentoModel> _estabelecimentos = new();

    private static int _nextId = 1;

    public List<EstabelecimentoModel> ListarTodos() => _estabelecimentos;

    public EstabelecimentoModel? ObterPorId(int id) =>
        _estabelecimentos.FirstOrDefault(e => e.Id == id);

    public EstabelecimentoModel Criar(EstabelecimentoModel estabelecimento)
    {
        estabelecimento.Id = _nextId++;
        _estabelecimentos.Add(estabelecimento);
        return estabelecimento;
    }

    public bool Atualizar(EstabelecimentoModel estabelecimento)
    {
        var existente = ObterPorId(estabelecimento.Id);
        if (existente == null) return false;

        existente.Nome = estabelecimento.Nome;
        existente.Tamanho = estabelecimento.Tamanho;

        return true;
    }

    public bool Remover(int id)
    {
        var estabelecimento = ObterPorId(id);
        if (estabelecimento == null) return false;

        _estabelecimentos.Remove(estabelecimento);
        return true;
    }
}
