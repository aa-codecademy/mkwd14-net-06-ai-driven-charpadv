namespace Generics.Domain.Interfaces
{
    public interface IGenericDB<T>
    {
        void PrintAll();
        T GetById(int id);
        T GetByIndex(int index);
        void Insert(T entity);
        void RemoveById(int id);
    }
}
