namespace PoC.Data.Mapping.Admin
{
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using PoC.Domain.Entities;

    public class ProdutoMap : IAutoMappingOverride<Produto>
    {
        public void Override(AutoMapping<Produto> mapping)
        {
            mapping.Table("PRODUTO");

            mapping.Id(x => x.Id).Column("ID_PRODUTO");

            mapping.Map(x => x.Nome).Column("NM_PRODUTO").Not.Nullable().Length(150).Unique();
        }
    }
}
