using Generics.Domain.Interfaces;
using Generics.Domain.Models;

namespace Generics.Domain.Data
{
    public class GenericDB<T> : IGenericDB<T> where T : BaseEntity
    {
        private List<T> Db;

        public GenericDB()
        {
            Db = new List<T>();
        }

        public void PrintAll()
        {
            Console.WriteLine($"\nPrinting items for {typeof(T).Name} DB:");
            foreach (T item in Db)
            {
                Console.WriteLine(item.GetInfo());
            }
        }

        public T GetById(int id)
        {
            T item = Db.FirstOrDefault(i => i.Id == id);
            ArgumentNullException.ThrowIfNull(item, $"No item with id {id} found");
            return item;
        }

        // Avoid using indexes for retrieving data, since it can produce unexpected behaviour (such as ArgumentOutOfRangeException)
        public T GetByIndex(int index)
        {
            return Db[index];
        }

        public void Insert(T entity)
        {
            Db.Add(entity);
            Console.WriteLine($"Item was added in the {typeof(T).Name} DB!");
        }

        public void RemoveById(int id)
        {
            T item = GetById(id);
            Db.Remove(item);
        }
    }
}
