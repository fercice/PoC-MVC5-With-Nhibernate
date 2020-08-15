namespace PoC.Domain.Interfaces
{
    using System.Collections.Generic;
    using PoC.Domain.Entities.Base;

    public interface IService<TEntity> where TEntity : IEntity
    {
        IList<TEntity> GetAll();

        TEntity GetById(int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void InsertOrUpdate(TEntity entity);

        void Delete(int id);
    }
}
