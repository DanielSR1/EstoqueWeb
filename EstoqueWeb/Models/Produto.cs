namespace EstoqueWeb.Models;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal PrecoCusto { get; set; }
    public string Descricao { get; set; }
}