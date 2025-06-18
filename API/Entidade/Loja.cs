namespace API.Entidade;

public class Loja
{
    //EF ctor
    public Loja()
    {
        
    }

    public long Id { get; private set; }
    public string Nome { get; private set; }
    public string Endereco { get; private set; }

    public ICollection<Produto> Produtos{ get; }

    public void SetNome(string nome)
    {
        Nome = nome;
    }

    public void SetEndereco(string endereco)
    {
        Endereco = endereco;
    }

}
