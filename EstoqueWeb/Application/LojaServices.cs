using EstoqueWeb.Models;
using System.Text.Json;
using System.Text;

namespace EstoqueWeb.Application;

public interface ILojaServices
{
    Task<Loja> GetLoja(int id);
    Task<IEnumerable<Loja>> GetLojas();
    Task Delete(int id);

    Task Update(int id, Loja loja);
    Task Create(Loja loja);
}

public class LojaServices(HttpClient httpClient) : ILojaServices
{
    private readonly JsonSerializerOptions jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };
    public async Task<IEnumerable<Loja>> GetLojas()
    {
        var message = await httpClient.GetAsync("/lojas");

        message.EnsureSuccessStatusCode();

        var lojaJson = await message.Content.ReadAsStringAsync();

        var loja = JsonSerializer.Deserialize<IEnumerable<Loja>>(lojaJson, jsonOptions);

        return loja ?? [];
    }

    public async Task<Loja> GetLoja(int id)
    {
        var message = await httpClient.GetAsync(string.Format("/lojas/{0}", id));

        message.EnsureSuccessStatusCode();

        var lojaJson = await message.Content.ReadAsStringAsync();

        var loja = JsonSerializer.Deserialize<Loja>(lojaJson, jsonOptions);

        return loja ?? default!;
    }

    public async Task Delete(int id)
    {
        var message = await httpClient.DeleteAsync(string.Format("/lojas/{0}", id));

        message.EnsureSuccessStatusCode();

    }

    public async Task Update(int id, Loja loja)
    {
        var jsonString = JsonSerializer.Serialize(loja);

        var message = await httpClient.PatchAsync(string.Format("/lojas/{0}", id), new StringContent(jsonString, Encoding.UTF8, "application/json"));

        message.EnsureSuccessStatusCode();
    }

    public async Task Create(Loja loja)
    {
        var jsonString = JsonSerializer.Serialize(loja);

        var message = await httpClient.PostAsync(string.Format("/lojas"), new StringContent(jsonString, Encoding.UTF8, "application/json"));

        message.EnsureSuccessStatusCode();
    }
}
