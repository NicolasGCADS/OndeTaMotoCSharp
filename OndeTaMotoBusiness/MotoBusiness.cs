using OndeTaMotoModel;
using OndeTaMotoData;
using System.Collections.Generic;
using System.Linq;

namespace OndeTaMotoBusiness;

public class MotoService
{
    private readonly AppDbContext _context;

    public MotoService(AppDbContext context)
    {
        _context = context;
    }

    public List<MotoModel> ListarTodos() => _context.Motos.ToList();

    public MotoModel? ObterPorId(int id) => _context.Motos.Find(id);

    public MotoModel Criar(MotoModel moto)
    {
        _context.Motos.Add(moto);
        _context.SaveChanges();
        return moto;
    }

    public bool Atualizar(MotoModel moto)
    {
        var existente = _context.Motos.Find(moto.Id);
        if (existente == null) return false;

        existente.Nome = moto.Nome;
        existente.Tag = moto.Tag;
        existente.Placa = moto.Placa;

        _context.SaveChanges();
        return true;
    }

    public bool Remover(int id)
    {
        var moto = _context.Motos.Find(id);
        if (moto == null) return false;
        _context.Motos.Remove(moto);
        _context.SaveChanges();
        return true;
    }
}


