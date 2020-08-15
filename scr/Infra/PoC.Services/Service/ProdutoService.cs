namespace PoC.Services.Admin
{
    using System.Linq;
    using PoC.Domain.Entities;
    using PoC.Domain.Interfaces;
    using PoC.Services.Interface;

    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        private readonly IRepository<Produto> _repository;

        public ProdutoService(IRepository<Produto> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Produto BuscarProdutoPorNome(string nome)
        {
            return _repository
                .Get()
                .Where(x => x.Nome.Equals(nome))
                .FirstOrDefault();
        }
    }
}
