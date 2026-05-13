namespace Generics.Helpers
{
    /// <summary>
    ///     Class with non-generic methods. You need to repeat the same logic for different type of data.
    /// </summary>
    public class NonGenericListHelper
    {
        public void PrintStrings(List<string> strings)
        {
            Console.WriteLine("\n=== Printing Strings ===");
            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintInfoForStrings(List<string> strings)
        {
            string first = strings[0];
            string elementType = first.GetType().Name;
            Console.WriteLine($"This list has {strings.Count} elements and is of type {elementType}");
        }

        public void PrintIntegers(List<int> integers)
        {
            Console.WriteLine("\n=== Printing Integers ===");
            foreach (var item in integers)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintInfoForIntegers(List<int> integers)
        {
            int first = integers[0];
            string elementType = first.GetType().Name;
            Console.WriteLine($"This list has {integers.Count} elements and is of type {elementType}");
        }

        public void PrintBooleans(List<bool> booleans)
        {
            Console.WriteLine("\n=== Printing Booleas ===");
            foreach (var item in booleans)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintInfoForBooleans(List<bool> booleans)
        {
            bool first = booleans[0];
            string elementType = first.GetType().Name;
            Console.WriteLine($"This list has {booleans.Count} elements and is of type {elementType}");
        }
    }
}
