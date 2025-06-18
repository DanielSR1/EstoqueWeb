using API.DBContext;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Produto;
public class ProdutoService(ApiDBContext context) : IProdutoService
{
    private static Entidade.Produto CreateProduto(IProdutoProps props)
    {
        var produto = ProdutoFactory.Create(props);

        return produto;
    }

    public async Task<bool> AdicionaProduto(IProdutoProps props)
    {
        await context.Produtos.AddAsync(CreateProduto(props));

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> AtualizarProduto(int id, IProdutoProps props)
    {
        var produto = await context.Produtos.FirstOrDefaultAsync(ie => ie.Id == id);

        if (produto is null) return false;

        produto.SetNome(props.Nome == default ? produto.Nome : props.Nome);
        produto.SetPrecoCusto(props.PrecoCusto == default ? produto.PrecoCusto : props.PrecoCusto);
        produto.SetDescricao(props.Descricao == default ? produto.Descricao : props.Descricao);

        context.Produtos.Update(produto);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<Entidade.Produto> BuscaProduto(int id)
    {
        return await context.Produtos.FirstOrDefaultAsync(s => s.Id == id) ?? default!;
    }

    public async Task<IEnumerable<Entidade.Produto>> BuscaProdutos(string nomeProduto)
    {
        if (string.IsNullOrWhiteSpace(nomeProduto))
        {
            return await context.Produtos.ToListAsync();
        }

        return await context.Produtos.Where(p => p.Nome.Contains(nomeProduto)).ToListAsync();
    }

    public async Task<bool> DeleteProduto(int id)
    {
        var produto = await context.Produtos.FirstOrDefaultAsync(ie => ie.Id == id);

        if (produto == null) return false;

        context.Produtos.Remove(produto);

        return await context.SaveChangesAsync() > 0;
    }
}

public interface IProdutoService
{
    public Task<bool> AdicionaProduto(IProdutoProps props);

    public Task<Entidade.Produto> BuscaProduto(int id);
    public Task<IEnumerable<Entidade.Produto>> BuscaProdutos(string nomeProduto);

    public Task<bool> DeleteProduto(int id);

    public Task<bool> AtualizarProduto(int id, IProdutoProps props);
}

