namespace Generics.Domain.Models
{
	//BaseEntity is a class that holds all the properties and methods that are valid for all entities that we want to have in our app
	public abstract class BaseEntity
	{
        public int Id { get; set; }
		public abstract string GetInfo();
    }
}
