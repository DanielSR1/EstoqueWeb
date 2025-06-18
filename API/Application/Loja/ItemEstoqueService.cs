using API.DBContext;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Loja;
public class LojaService(ApiDBContext context) : ILojaService
{
    private static Entidade.Loja CreateLoja(ILojaProps props)
    {
        var loja = LojaFactory.Create(props);

        return loja;
    }

    public async Task<bool> AdicionaLoja(ILojaProps props)
    {
        await context.Lojas.AddAsync(CreateLoja(props));

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> AtualizarLoja(int id, ILojaProps props)
    {
        var loja = await context.Lojas.FirstOrDefaultAsync(ie => ie.Id == id);

        if (loja is null) return false;

        loja.SetNome(props.Nome == default ? loja.Nome : props.Nome);
        loja.SetEndereco(props.Endereco == default ? loja.Endereco : props.Endereco);

        context.Lojas.Update(loja);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<Entidade.Loja> BuscaLoja(int id)
    {
        return await context.Lojas.FirstOrDefaultAsync(s => s.Id == id) ?? default!;
    }

    public async Task<IEnumerable<Entidade.Loja>> BuscaLojas()
    {
        return await context.Lojas.ToListAsync();
    }

    public async Task<bool> DeleteLoja(int id)
    {
        var loja = await context.Lojas.FirstOrDefaultAsync(ie => ie.Id == id);

        if (loja == null) return false;

        context.Lojas.Remove(loja);

        return await context.SaveChangesAsync() > 0;
    }
}

public interface ILojaService
{
    public Task<bool> AdicionaLoja(ILojaProps props);

    public Task<Entidade.Loja> BuscaLoja(int id);
    public Task<IEnumerable<Entidade.Loja>> BuscaLojas();

    public Task<bool> DeleteLoja(int id);

    public Task<bool> AtualizarLoja(int id, ILojaProps props);
}

