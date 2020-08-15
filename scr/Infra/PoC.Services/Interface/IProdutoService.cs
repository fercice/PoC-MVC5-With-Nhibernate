namespace PoC.Services.Interface
{
    using PoC.Domain.Entities;
    using PoC.Domain.Interfaces;

    public interface IProdutoService : IService<Produto>
    {
        Produto BuscarProdutoPorNome(string nome);
    }
}
