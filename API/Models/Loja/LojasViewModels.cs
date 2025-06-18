namespace API.Models.Loja;

public class LojasViewModel
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }


    public static implicit operator LojasViewModel(Entidade.Loja loja)
    {
        if(loja == default)
        {
            return default!;
        }

        return new LojasViewModel()
        {
            Id = loja.Id,
            Nome = loja.Nome,
            Endereco = loja.Endereco,
        };
    }

    public static IEnumerable<LojasViewModel> ToLojasViewModel(IEnumerable<Entidade.Loja> lojas)
    {
        return lojas.Select(l => new LojasViewModel()
        {
            Id = l.Id,
            Nome = l.Nome,
            Endereco = l.Endereco,
        });
    }
}
