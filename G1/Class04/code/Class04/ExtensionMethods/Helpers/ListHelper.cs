namespace ExtensionMethods.Helpers
{
    public static class ListHelper
    {
        /// <summary>
        /// A Generic extension method that can be called on any list with items and print the list
        /// </summary>
        public static void PrintItems<T>(this List<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// A Generic extension method that can be called on any list with items and print the list info
        /// </summary>
        public static void PrintListInfo<T>(this List<T> items) 
        {
            string listType = typeof(T).Name;
            Console.WriteLine($"This list has {items.Count} elements and is of type {listType}.");
        }
    }
}
