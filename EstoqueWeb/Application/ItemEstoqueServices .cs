using EstoqueWeb.Models;
using System.Text;
using System.Text.Json;

namespace EstoqueWeb.Application;

public interface IItemEstoqueServices
{
    Task<ItemEstoque> GetItemEstoque(int id);
    Task<IEnumerable<ItemEstoque>> GetItemEstoques();
    Task<ItemEstoqueViewModel> GetItemEstoquesTotais();
    Task Delete(int id);
    Task Update(int id, ItemEstoque itemEstoque);
    public Task Create(ItemEstoque itemEstoque);
}

public class ItemEstoqueServices(HttpClient httpClient) : IItemEstoqueServices
{
    private readonly JsonSerializerOptions jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };
    public async Task<IEnumerable<ItemEstoque>> GetItemEstoques()
    {
        var message = await httpClient.GetAsync("/ItemEstoques");

        message.EnsureSuccessStatusCode();

        var ItemEstoqueJson = await message.Content.ReadAsStringAsync();

        var ItemEstoque = JsonSerializer.Deserialize<IEnumerable<ItemEstoque>>(ItemEstoqueJson, jsonOptions);

        return ItemEstoque ?? [];
    }

    public async Task<ItemEstoque> GetItemEstoque(int id)
    {
        var message = await httpClient.GetAsync(string.Format("/ItemEstoques/{0}", id));

        message.EnsureSuccessStatusCode();

        var ItemEstoqueJson = await message.Content.ReadAsStringAsync();

        var ItemEstoque = JsonSerializer.Deserialize<ItemEstoque>(ItemEstoqueJson, jsonOptions);

        return ItemEstoque ?? default!;
    }

    public async Task Delete(int id)
    {
        var message = await httpClient.DeleteAsync(string.Format("/ItemEstoques/{0}", id));

        message.EnsureSuccessStatusCode();

    }
    public async Task Update(int id, ItemEstoque itemEstoque)
    {
        var jsonString = JsonSerializer.Serialize(itemEstoque);

        var message = await httpClient.PatchAsync(string.Format("/itemEstoques/{0}", id), new StringContent(jsonString, Encoding.UTF8, "application/json"));

        message.EnsureSuccessStatusCode();
    }

    public async Task<ItemEstoqueViewModel> GetItemEstoquesTotais()
    {
        var message = await httpClient.GetAsync("/ItemEstoques/Completo");

        message.EnsureSuccessStatusCode();

        var ItemEstoqueJson = await message.Content.ReadAsStringAsync();

        var ItemEstoque = JsonSerializer.Deserialize<ItemEstoqueViewModel>(ItemEstoqueJson, jsonOptions);

        return ItemEstoque ?? default!;
    }

    public async Task Create(ItemEstoque itemEstoque)
    {
        var jsonString = JsonSerializer.Serialize(itemEstoque);

        var message = await httpClient.PostAsync("/itemEstoques", new StringContent(jsonString, Encoding.UTF8, "application/json"));

        message.EnsureSuccessStatusCode();
    }
}
