namespace PoC.Services
{   
    using System.Collections.Generic;
    using System.Linq;
    using PoC.Domain.Entities.Base;
    using PoC.Domain.Interfaces;    

    public class BaseService<TEntity> : IService<TEntity> where TEntity : IEntity
    {
        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public IList<TEntity> GetAll()
        {
            return _repository
                .GetAll()
                .ToList();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void InsertOrUpdate(TEntity entity)
        {
            _repository.InsertOrUpdate(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
