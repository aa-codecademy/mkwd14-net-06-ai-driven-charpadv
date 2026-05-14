namespace Generics.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public override string GetInfo()
        {
            return $"{Id}) {Title} - {Description}";
        }

        //public override string ToString()
        //{
        //    return $"{Id}) {Title} - {Description}";
        //}
    }
}
