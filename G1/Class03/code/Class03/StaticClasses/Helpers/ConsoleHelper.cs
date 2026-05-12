namespace StaticClasses.Helpers
{
    /*
        STATIC CLASS:
           - Cannot be instantiated (no objects)
           - Contains only static members (fields, methods, properties)
           - Is loaded once in memory and shared
        USE CASES:
           - Utility/helper methods (e.g., StringHelper, ListHelper)
           - Application-level constants or configuration
           - In-memory fake databases (like StaticDb, OrdersTempDB..)
    */
    public static class ConsoleHelper
    {
        public static void WriteInColor(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // Cannot create non-static members in a static class !!!
        //public void WriteSuccess(string message)
        //{
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine(message);
        //    Console.ResetColor();
        //}
    }
}
