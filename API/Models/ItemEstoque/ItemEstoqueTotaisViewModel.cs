namespace API.Models.ItemEstoque;

public class ItemEstoqueTotaisViewModel
{
    public int TotalItens { get; set; }
    public decimal ValorTotal { get; set; }
    public IEnumerable<ItemEstoquesViewModel> ItemEstoque { get; set; } = [];
}
