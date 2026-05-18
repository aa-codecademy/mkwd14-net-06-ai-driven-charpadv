using ExtensionMethods.Helpers;
using ExtensionMethods.Models;
using ExtensionMethods;

Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("\n=================== EXTENSION METHODS ===================\n");
Console.ResetColor();


#region List Extensions examples
Console.WriteLine("\n============== List Extensions ==============\n");
List<int> integers = new() { 1, 2, 3, 4, 5 };
List<string> strings = ["str1", "str2", "str3"];

//ListHelper.PrintItems<int>(integers);
//ListHelper.PrintItems(strings);
integers.PrintItems();
strings.PrintItems();

integers.PrintListInfo();
#endregion


#region String Extensions examples
Console.WriteLine("\n============== String Extensions ==============\n");
string bobLong = "Bob Bobsky";
string bobShorten = bobLong.Truncate(3);
Console.WriteLine(bobShorten);
Console.WriteLine("Bob Bobsky".Truncate(5));

string johnShort = StringExtensions.Truncate("John Doe", 1);
Console.WriteLine(johnShort.Quote());
#endregion


#region Product Extensions & Piggybacking
Console.WriteLine("\n============== Product Extensions ==============\n");
Product product = new Product
{
    Id = 1,
    Description = "Product Description",
    Title = "Product Title"
};
product.PrintInfo();
#endregion


Console.ReadLine();