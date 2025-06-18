namespace API.Application.Produto;

public static class ProdutoFactory
{
    public static Entidade.Produto Create(IProdutoProps props)
    {
        var produto = new Entidade.Produto();

        produto.SetNome(props.Nome);
        produto.SetPrecoCusto(props.PrecoCusto);
        produto.SetDescricao(props.Descricao);

        return produto;
            
    }
}

public interface IProdutoProps
{
    string Nome { get; set; }
    decimal PrecoCusto { get; set; }
    string Descricao { get; set; }
}

