namespace PoC.Domain.Interfaces
{
    using System.Linq;
    using PoC.Domain.Entities.Base;

    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> Get();

        IQueryable<T> GetAll();      
        
        T GetById(int id);

        void Insert(T entity);

        void Update(T entity);

        void InsertOrUpdate(T entity);

        void Delete(int id);
    }
}