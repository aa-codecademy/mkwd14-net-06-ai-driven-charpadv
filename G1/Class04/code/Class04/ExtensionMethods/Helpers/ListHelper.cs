namespace ExtensionMethods.Helpers
{
    public static class ListHelper
    {
        public static void PrintItems<T>(this List<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
