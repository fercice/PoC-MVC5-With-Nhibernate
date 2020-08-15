namespace PoC.Data.Helpers
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class DefaultPrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            if (instance.Name == "Id")
            {
                instance.Column("Id");                
                instance.GeneratedBy.Native();
            }      
        }
    }
}