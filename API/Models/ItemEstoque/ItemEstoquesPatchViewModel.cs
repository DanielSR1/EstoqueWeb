using API.Application.ItemEstoque;

namespace API.Models.ItemEstoque;

public class ItemEstoquesPatchViewModel : IItemEstoqueProps
{
    public long LojaId { get; set; }
    public long ProdutoId { get; set; }
    public int Quantidade { get; set; }

}
