namespace ExtensionMethods.Helpers
{

    /*
        *EXTENSION METHOD* ===> A static method that is defined in a static class and is used to extend the functionality of existing types without modifying them.

        ===> Usecases:
            1) Extending built-in datatypes functionalities
            2) Adding models extenisons
            3) Helpers extensions
            4) Creating custom mappers
            5) Configurations extensions etc...
    */

    public static class StringExtensions
    {

        public static string Truncate(this string word, int length)
        {
            if (string.IsNullOrWhiteSpace(word) || word.Length <= length)
            {
                return word;
            }

            string result = word.Substring(0, length);
            return result + "...";
            // "Bob Bobsky" => Truncate("Bob Bobsky", 3) => "Bob..."
        }

        public static string Quote(this string word)
        {
            return $@"""{word}""";
        }
    }
}
