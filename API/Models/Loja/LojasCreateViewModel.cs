using API.Application.Loja;

namespace API.Models.Loja;

public class LojasCreateViewModel : ILojaProps
{
    public string Nome { get; set; }
    public string Endereco { get; set; }
}
