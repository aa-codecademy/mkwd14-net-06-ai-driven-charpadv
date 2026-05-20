using LinqMethods.Entities;

namespace LinqMethods.Helpers
{
    public static class ListHelper
    {
        public static void PrintSimple<T>(this List<T> list)
        {
            Console.WriteLine("Printing List...");
            Console.WriteLine("------------------------------");
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------");
        }

        public static void PrintEntities<T>(this List<T> list) where T : BaseEntity
        {
            Console.WriteLine($"Printing {typeof(T).Name}s...");
            Console.WriteLine("------------------------------");
            foreach (T item in list)
            {
                Console.WriteLine(item.GetInfo());
            }
            Console.WriteLine("------------------------------");
        }
    }
}
