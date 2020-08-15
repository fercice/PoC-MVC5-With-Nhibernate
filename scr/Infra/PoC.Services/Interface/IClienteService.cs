namespace PoC.Services.Interface
{
    using PoC.Domain.Entities;
    using PoC.Domain.Interfaces;

    public interface IClienteService : IService<Cliente>
    {
        Cliente BuscarClientePorNome(string nome);
    }
}
