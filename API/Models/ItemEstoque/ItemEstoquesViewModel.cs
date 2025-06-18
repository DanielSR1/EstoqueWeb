namespace API.Models.ItemEstoque;

public class ItemEstoquesViewModel
{
    public long Id { get; set; }
    public long LojaId { get; set; }
    public long ProdutoId { get; set; }
    public int Quantidade { get; set; }

    public static implicit operator ItemEstoquesViewModel(Entidade.ItemEstoque? itemEstoque)
    {
        if (itemEstoque is null) return default!;
        return new()
        {
            Id = itemEstoque.Id,
            LojaId = itemEstoque.LojaId,
            ProdutoId = itemEstoque.ProdutoId,
            Quantidade = itemEstoque.Quantidade
        };
    }

    public static IEnumerable<ItemEstoquesViewModel> ToItemEstoquesViewModel(IEnumerable<Entidade.ItemEstoque> itemEstoques)
    {
        return itemEstoques.Select(ie => new ItemEstoquesViewModel()
        {
            Id = ie.Id,
            LojaId = ie.LojaId,
            ProdutoId = ie.ProdutoId,
            Quantidade = ie.Quantidade
        });
    }
}
