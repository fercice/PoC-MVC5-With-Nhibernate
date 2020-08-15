namespace PoC.Services.Admin
{    
    using PoC.Domain.Entities;
    using PoC.Domain.Interfaces;
    using PoC.Services.Interface;
    using System.Collections.Generic;
    using System.Linq;

    public class CompraService : BaseService<Compra>, ICompraService
    {
        private readonly IRepository<Compra> _repository;

        public CompraService(IRepository<Compra> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public IList<Compra> BuscarCompraPorCliente(int idCliente)
        {
            return _repository
                .Get()
                .Where(x => x.Cliente.Id.Equals(idCliente))
                .ToList();
        }

        public Compra BuscarCompraPorClienteEProduto(int idCliente, int idProduto)
        {
            return _repository
                .Get()
                .Where(x => x.Cliente.Id.Equals(idCliente) && x.Produto.Id.Equals(idProduto))
                .FirstOrDefault();
        }
    }
}