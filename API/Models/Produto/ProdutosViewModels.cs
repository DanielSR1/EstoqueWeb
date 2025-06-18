namespace API.Models.Produto;

public class ProdutosViewModel
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public decimal PrecoCusto { get; set; }
    public string Descricao { get; set; }

    public static IEnumerable<ProdutosViewModel> ToProdutosViewModel(IEnumerable<Entidade.Produto> produtos)
    {
        if (produtos is null) return [];

        return produtos.Select(p => new ProdutosViewModel()
        {
            Id = p.Id,
            Nome = p.Nome,
            Descricao = p.Descricao,
            PrecoCusto = p.PrecoCusto,
        });
    }

    public static implicit operator ProdutosViewModel(Entidade.Produto? produto)
    {
        if (produto is null) return default!;
        return new ProdutosViewModel()
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            PrecoCusto = produto.PrecoCusto,
        };
    }
}
