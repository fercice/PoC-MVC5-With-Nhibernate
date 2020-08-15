namespace PoC.Domain.Entities
{    
    using System.Collections.Generic;    

    public class Cliente : Base.IEntity
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }          
    }
}