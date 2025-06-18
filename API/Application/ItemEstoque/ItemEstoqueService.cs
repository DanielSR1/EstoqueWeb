using API.DBContext;
using API.Models.ItemEstoque;
using Microsoft.EntityFrameworkCore;
namespace API.Application.ItemEstoque;
public class ItemEstoqueService(ApiDBContext context) : IItemEstoqueService
{   
    public async Task<ItemEstoqueTotaisViewModel> BuscarItemsTotais()
    {
        var itemsEstoque =  await context.ItemEstoque.Include(s => s.Produto).ToListAsync();

        var item = new ItemEstoqueTotaisViewModel()
        {
            ValorTotal = itemsEstoque.Sum(s => s.Produto.PrecoCusto * s.Quantidade),
            TotalItens = itemsEstoque.Sum(s => s.Quantidade),
            ItemEstoque = ItemEstoquesViewModel.ToItemEstoquesViewModel(itemsEstoque),
        };

        return item;

    }
    private static Entidade.ItemEstoque CreateItemEstoque(IItemEstoqueProps props)
    {
        var itemEstoque = ItemEstoqueFactory.Create(props);

        return itemEstoque;
    }

    public async Task<bool> AdicionaItemEstoque(IItemEstoqueProps props)
    {
        await context.ItemEstoque.AddAsync(CreateItemEstoque(props));

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> AtualizarItemEstoque(int id, IItemEstoqueProps props)
    {
        var itemEstoque = await context.ItemEstoque.FirstOrDefaultAsync(ie => ie.Id == id);

        if (itemEstoque is null) return false;

        itemEstoque.setLojaId(props.LojaId == default ? itemEstoque.LojaId : props.LojaId);
        itemEstoque.setProdutoId(props.ProdutoId == default ? itemEstoque.ProdutoId : props.ProdutoId);
        itemEstoque.setQuantidade(props.Quantidade == default ? itemEstoque.Quantidade : props.Quantidade);

        context.ItemEstoque.Update(itemEstoque);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<Entidade.ItemEstoque> BuscaItemEstoque(int id)
    {
        return await context.ItemEstoque.FirstOrDefaultAsync(s => s.Id == id) ?? default!;
    }

    public async Task<IEnumerable<Entidade.ItemEstoque>> BuscaItemEstoques()
    {
        return await context.ItemEstoque.ToListAsync();
    }

    public async Task<bool> DeleteItemEstoque(int id)
    {
        var itemEstoque = await context.ItemEstoque.FirstOrDefaultAsync(ie => ie.Id == id);

        if (itemEstoque == null) return false;

        context.ItemEstoque.Remove(itemEstoque);

        return await context.SaveChangesAsync() > 0;
    }
}

public interface IItemEstoqueService
{
    public Task<bool> AdicionaItemEstoque(IItemEstoqueProps props);

    public Task<Entidade.ItemEstoque> BuscaItemEstoque(int id);
    public Task<IEnumerable<Entidade.ItemEstoque>> BuscaItemEstoques();

    public Task<bool> DeleteItemEstoque(int id);

    public Task<bool> AtualizarItemEstoque(int id, IItemEstoqueProps props);

    public Task<ItemEstoqueTotaisViewModel> BuscarItemsTotais();
}

