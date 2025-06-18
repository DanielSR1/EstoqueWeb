namespace API.Application.Loja;

public static class LojaFactory
{
    public static Entidade.Loja Create(ILojaProps props)
    {
        var loja = new Entidade.Loja();

        loja.SetNome(props.Nome);
        loja.SetEndereco(props.Endereco);

        return loja;
            
    }
}

public interface ILojaProps
{
    string Nome { get; set; }
    string Endereco { get; set; }
}

