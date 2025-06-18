using System.Text.Json.Serialization;

namespace EstoqueWeb.Models
{

    public class ItemEstoque
    {
        public int Id { get; set; }
        public int LojaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }

    public class ItemEstoqueViewModel
    {
        public int TotalItens {  get; set; }
        public decimal ValorTotal { get; set; }

        [JsonPropertyName("ItemEstoque")]
        public ICollection<ItemEstoque> Items { get; set; } = [];
    }
}
