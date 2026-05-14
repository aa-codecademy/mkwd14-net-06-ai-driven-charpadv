namespace Generics.Helpers
{
    /// <summary>
    ///     Class with generic methods.
    ///     Generic Methods allow you to write methods that can operate on any data type.
    /// </summary>
    public class GenericListHelper
    {
        // SYNTAX: [access modifier] [return type] [method name]<T> ([parameters])
        public void PrintItems<T>(List<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }

        // works with static methods as well
        public static void PrintItemsInfo<T>(List<T> items)
        {
            string elementType = typeof(T).Name;

            Console.WriteLine($"\nThis list has {items.Count} elements and is of type {elementType}");
        }
    }
}
