using Entidade = API.Entidade;

namespace API.Application.ItemEstoque;

public static class ItemEstoqueFactory
{
    public static Entidade.ItemEstoque Create(IItemEstoqueProps props)
    {
        var itemEstoque = new Entidade.ItemEstoque();

        itemEstoque.setLojaId(props.LojaId);
        itemEstoque.setProdutoId(props.ProdutoId);
        itemEstoque.setQuantidade(props.Quantidade);

        return itemEstoque;
            
    }
}

public interface IItemEstoqueProps
{
    long LojaId { get; set; }
    long ProdutoId { get; set; }
    int Quantidade { get; set; }
}

