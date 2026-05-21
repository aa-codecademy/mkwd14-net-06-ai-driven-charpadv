using TryBeingFit.Domain.Models;

namespace TryBeingFit.Domain.Database
{
	public class Database<T> : IDatabase<T> where T : BaseEntity
	{
		//we mark the list as private because we don't want anyone from outside to be able to directly access and modify the items
		//we want to use the methods to manipulte the list
		private List<T> items { get; set; }

		public Database()
		{
			items = new List<T>();
		}
		public List<T> GetAll()
		{
			//SELECT *
			//FROM T

			return items; //here we need to return the whole list, all the items
		}

		public T GetById(int id)
		{
			//SELECT *
			//FROM T
			//WHERE T.Id == id

			T item = items.FirstOrDefault(x => x.Id == id);
			//validation
			if(item  == null)
			{
				throw new NullReferenceException($"Entity with id {id} was not found in the db");
			}

			return item;
		}

		public int Insert(T entity)
		{
			///always check if the entity is not null before accessing its properties/methods
			if(entity == null)
			{
				throw new Exception("Entity cannot be null");
			}
			//we don't have the real db option identity, so we need to manually set the id for each item
			//we can have a property LastUsedId where we will keep the last used id and increment it for each next item
			//or we can access the last item of the list using LastOrDefault, take its id and increment it by one for the new item
			int? id = items.LastOrDefault()?.Id; //LastOrDefault can have the value null. In that case, the id will not be accessed (null.Id). We add the ? to avoid exceptions and to make the int nullable
			entity.Id = id.HasValue ? id.Value + 1 : 1; //same as: id != null ? id : 1
			items.Add(entity);
			return entity.Id;
		}

		public void RemoveById(int id)
		{
			//we have only the id of the item that we want to remove. We need to find that item and then remove it
			T item = items.FirstOrDefault(x => x.Id == id);
			//validation
			if (item == null)
			{
				throw new NullReferenceException($"Entity with id {id} was not found in the db");
			}

			//T item = GetById(id);
			items.Remove(item);
		}

		public void Update(T entity)
		{
			///always check if the entity is not null before accessing its properties/methods
			if (entity == null)
			{
				throw new Exception("Entity cannot be null");
			}

			//first we need to search for the item and check if the item that we want to update exists in our db (our items list)
			T item = GetById(entity.Id);

			int indexOfElement = items.IndexOf(item); //we have to find the index of the item that we want to update (replace and switch with the new updated version)
			items[indexOfElement] = entity; //on the place (index) of the existing item in our list that we want to update, we now put the updated entity that we got sent as param
		}
	}
}
