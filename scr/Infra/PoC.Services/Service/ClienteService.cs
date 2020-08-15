namespace PoC.Services.Admin
{
    using System.Linq;
    using PoC.Domain.Entities;
    using PoC.Domain.Interfaces;
    using PoC.Services.Interface;

    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IRepository<Cliente> _repository;

        public ClienteService(IRepository<Cliente> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Cliente BuscarClientePorNome(string nome)
        {
            return _repository
                .Get()
                .Where(x => x.Nome.Equals(nome))
                .FirstOrDefault();
        }
    }
}
