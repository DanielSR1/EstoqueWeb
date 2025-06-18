namespace API.Entidade;
public class Produto
{
    //EF ctor
    public Produto()
    {
        
    }
    public long Id { get; private set; }
    public string Nome { get; private set; }
    public decimal PrecoCusto { get; private set; }
    public string Descricao { get; private set; }

    public ICollection<Loja> Lojas { get; }

    public void SetNome(string nome)
    {
        Nome = nome;
    }

    public void SetPrecoCusto(decimal precoCusto)
    {
        PrecoCusto = precoCusto;
    }

    public void SetDescricao(string descricao)
    {
        Descricao = descricao;
    }
}

