using EstoqueWeb.Models;
using System.Text;
using System.Text.Json;

namespace EstoqueWeb.Application;

public interface IProdutoServices
{
    Task<Produto> GetProduto(int id);
    Task<IEnumerable<Produto>> GetProdutos(string nomeProduto = default!);
    Task Delete(int id);
    Task Update(int id, Produto produto);  
    Task Create(Produto produto);
}

public class ProdutoServices(HttpClient httpClient) : IProdutoServices
{
    private readonly JsonSerializerOptions jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public async Task<IEnumerable<Produto>> GetProdutos(string nomeProduto = default!)
    {
        var rota = string.Format("/produtos?produtoNome={0}", nomeProduto);
        var message = await httpClient.GetAsync(rota);

        message.EnsureSuccessStatusCode();

        var produtoJson = await message.Content.ReadAsStringAsync();

        var produto = JsonSerializer.Deserialize<IEnumerable<Produto>>(produtoJson, jsonOptions);

        return produto ?? [];
    }

    public async Task<Produto> GetProduto(int id)
    {
        var message = await httpClient.GetAsync(string.Format("/produtos/{0}", id));

        message.EnsureSuccessStatusCode();

        var produtoJson = await message.Content.ReadAsStringAsync();

        var produto = JsonSerializer.Deserialize<Produto>(produtoJson, jsonOptions);

        return produto ?? default!;
    }

    public async Task Delete(int id)
    {
        var message = await httpClient.DeleteAsync(string.Format("/produtos/{0}", id));

        message.EnsureSuccessStatusCode();

    }

    public async Task Update(int id, Produto produto)
    {
        var jsonString = JsonSerializer.Serialize(produto);

        var message = await httpClient.PatchAsync(string.Format("/produtos/{0}", id), new StringContent(jsonString, Encoding.UTF8, "application/json"));

        message.EnsureSuccessStatusCode();
    }

    public async Task Create(Produto produto)
    {
        var jsonString = JsonSerializer.Serialize(produto);

        var message = await httpClient.PostAsync(string.Format("/produtos"), new StringContent(jsonString, Encoding.UTF8, "application/json"));

        message.EnsureSuccessStatusCode();
    }
}
