using TryBeingFit.Domain.Models;

namespace TryBeingFit.Domain.Database
{
	public interface IDatabase<T> where T : BaseEntity
	{
		//CRUD - Create, Read, Update and Delete
		List<T> GetAll(); //Read
		T GetById(int id); //Read
		int Insert(T entity); //create
		void Update(T entity); //update
		void RemoveById (int id); //delete
	}
}
