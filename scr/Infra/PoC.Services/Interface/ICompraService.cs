namespace PoC.Services.Interface
{
    using PoC.Domain.Entities;
    using PoC.Domain.Interfaces;
    using System.Collections.Generic;

    public interface ICompraService : IService<Compra>
    {
        IList<Compra> BuscarCompraPorCliente(int idCliente);

        Compra BuscarCompraPorClienteEProduto(int idCliente, int idProduto);
    }
}
