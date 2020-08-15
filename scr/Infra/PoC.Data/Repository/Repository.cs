namespace PoC.Data.Repository
{
    using System.Linq;
    using PoC.Domain.Entities.Base;
    using PoC.Domain.Interfaces;
    using NHibernate;
    using NHibernate.Linq;
    using PoC.Data.UoW;
    using System;

    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private UnitOfWork _unitOfWork;
        public Repository(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = (UnitOfWork)UnitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }

        public IQueryable<T> Get()
        {
            return Session.Query<T>();
        }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }        

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public void Insert(T entity)
        {
            Session.Save(entity);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void InsertOrUpdate(T entity)
        {
            try
            {
                Session.Clear();
                Session.SaveOrUpdate(entity);
            }
            catch (Exception ex)
            {
                if (ex.Source == "NHibernate")
                {
                    if (ex.InnerException.Message.Contains("UNIQUE KEY"))
                    {
                        throw new Exception(entity.GetType().Name + " já cadastrado");
                    }
                }

                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            Session.Delete(Session.Load<T>(id));
        }
    }
}
