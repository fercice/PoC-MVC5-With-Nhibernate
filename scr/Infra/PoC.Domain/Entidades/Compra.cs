namespace PoC.Domain.Entities
{    
    using System.Collections.Generic;    

    public class Compra : Base.IEntity
    {
        public virtual int Id { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Produto Produto { get; set; }        
    }
}