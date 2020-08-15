namespace PoC.Data.Mapping.Admin
{
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using PoC.Domain.Entities;

    public class ClienteMap : IAutoMappingOverride<Cliente>
    {
        public void Override(AutoMapping<Cliente> mapping)
        {
            mapping.Table("CLIENTE");

            mapping.Id(x => x.Id).Column("ID_CLIENTE");

            mapping.Map(x => x.Nome).Column("NM_CLIENTE").Not.Nullable().Length(150).Unique();            
        }
    }
}
