namespace Generics.Domain.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public abstract string GetInfo();
        //public DateTime CreatedDate { get; set; }
    }
}
