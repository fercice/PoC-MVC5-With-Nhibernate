namespace PoC.Data.UoW
{
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;    
    using NHibernate.Context;
    using NHibernate.Tool.hbm2ddl;
    using PoC.Data.Helpers;
    using PoC.Data.Mapping;
    using PoC.Domain.Entities.Base;
    using PoC.Domain.Interfaces;

    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;        
        private ITransaction _transaction;

        public ISession Session { get; set; }

        static UnitOfWork() 
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(x => x.FromConnectionStringWithKey("connectionString")))                
                .Mappings(x => x.AutoMappings.Add(
                    AutoMap.AssemblyOf<IEntity>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<EntityMap>()
                    .Conventions.Setup(con => { con.Add<DefaultPrimaryKeyConvention>(); })))
                .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, false))
                .CurrentSessionContext("web")                
                .BuildSessionFactory();
        }

        public UnitOfWork()
        {
            Session = GetCurrentSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch 
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }

        public ISession GetCurrentSession()
        {
            if (!CurrentSessionContext.HasBind(_sessionFactory))
            {
                CurrentSessionContext.Bind(_sessionFactory.OpenSession());
            }
            return _sessionFactory.GetCurrentSession();
        }
    }
}
