namespace PoC.Domain.Entities
{
    public class Produto : Base.IEntity
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }        
    }
}