using API.Application.Produto;

namespace API.Models.Produto;

public class ProdutosPatchViewModel : IProdutoProps
{
    public string Nome { get; set; }
    public decimal PrecoCusto { get; set; }
    public string Descricao { get; set; }
}
