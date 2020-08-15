namespace PoC.Data.Mapping.Admin
{
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using PoC.Domain.Entities;

    public class CompraMap : IAutoMappingOverride<Compra>
    {
        public void Override(AutoMapping<Compra> mapping)
        {
            mapping.Table("COMPRA");

            mapping.Id(x => x.Id).Column("ID_COMPRA");

            mapping.References(x => x.Cliente).Column("ID_CLIENTE").Not.Nullable();

            mapping.References(x => x.Produto).Column("ID_PRODUTO").Not.Nullable();            
        }
    }
}
