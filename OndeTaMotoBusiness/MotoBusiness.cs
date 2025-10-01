using OndeTaMotoModel;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OndeTaMotoBusiness;

public class MotoService
{
    private static readonly List<MotoModel> _moto = new();

    private static int _nextId = 1;

    public List<MotoModel> ListarTodos() => _moto;
    public MotoModel? ObterPorId(int id) => _moto.FirstOrDefault(c => c.Id == id);

    public MotoModel Criar(MotoModel moto)
    {
        moto.Id = _nextId++;
        _moto.Add(moto);
        return moto;
    }

    public bool Atualizar(MotoModel moto)
    {
        var existente = ObterPorId(moto.Id);
        if (existente == null) return false;
        existente.Nome = moto.Nome;
        existente.Tag = moto.Tag;
        existente.Placa = moto.Placa;
        return true;
    }

    public bool Remover(int id)
    {
        var moto = ObterPorId(id);
        if (moto == null) return false;
        _moto.Remove(moto);
        return true;
    }
}


