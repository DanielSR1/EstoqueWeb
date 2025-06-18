using API.Application.Produto;

namespace API.Models.Produto;
public class ProdutosCreateViewModel : IProdutoProps
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public decimal PrecoCusto { get; set; }
    public string Descricao { get; set; }
}
