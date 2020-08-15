
namespace PoC.Data.Helpers
{
    using FluentNHibernate.Automapping;
    using System;
    using PoC.Domain.Entities.Base;

    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterface(typeof(IEntity).FullName) != null;
        }
    }
}
