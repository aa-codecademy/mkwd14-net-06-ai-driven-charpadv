using Generics.Domain.Models;

namespace Generics.Domain
{
	//GenericDb can work with any type, but that type has to be either BaseEntity or it has to inherit from BaseEntity
	public class GenericDb<T> where T : BaseEntity
	{
		private List<T> items;

		public GenericDb()
		{
			items = new List<T>();
		}

		//ReadAll
		public void PrintAll()
		{
			foreach (T item in items)
			{
				//we can call GetInfo beacuse T must inherit from BaseEntity, which means that it must have an impl of GetInfo
				Console.WriteLine(item.GetInfo());
			}
		}

		public T GetById(int id) {

			//SELECT *
			//FROM Product/Order -> BaseEntity
			//WHERE Id == id

			//because T inherits from BaseEntity, T will always have a property Id
			return items.FirstOrDefault(x => x.Id == id);
		}

		//Create
		public void Add(T item)
		{
			if(item != null)
			{
				items.Add(item);
				Console.WriteLine("The item was added");
			}
		}


		public void RemoveById(int id)
		{
			//item to remove
			T itemToRemove = items.FirstOrDefault(x => x.Id == id);
			if(itemToRemove != null)
			{
				items.Remove(itemToRemove); //we pass the whole object that we want to remove from the list
				Console.WriteLine("The item was removed");
			}
			else
			{
				Console.WriteLine($"There is no member with id {id}");
			}
		}
	}
}
