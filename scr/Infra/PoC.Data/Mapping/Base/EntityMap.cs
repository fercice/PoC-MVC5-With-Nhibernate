namespace PoC.Data.Mapping
{
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using PoC.Domain.Entities.Base;

    public class EntityMap : IAutoMappingOverride<IEntity>
    {
        public void Override(AutoMapping<IEntity> mapping)
        {
        }
    }
}
