namespace API.Entidade;

public class ItemEstoque
{
    //EF ctor
    public ItemEstoque()
    {
        
    }

    public long Id { get; private set; }
    public long LojaId { get; private set; }
    public long ProdutoId { get; private set; }
    public int Quantidade { get; private set; }

    public Loja Loja { get; set; }

    public Produto Produto { get; set; }

    public void setLojaId(long lojaId)
    {
        LojaId = lojaId;
    }

    public void setProdutoId(long produtoId)
    {
        ProdutoId = produtoId;
    }

    public void setQuantidade(int quantidade)
    {
        Quantidade = quantidade;
    }

}
