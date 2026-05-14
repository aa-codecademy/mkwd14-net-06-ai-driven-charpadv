using ExtensionMethods.Helpers;

Console.WriteLine("Hello, World!");

List<int> integers = new() { 1, 2, 3, 4, 5 };
List<string> strings = ["str1", "str2", "str3"];

//ListHelper.PrintItems<int>(integers);
//ListHelper.PrintItems(strings);
integers.PrintItems();
strings.PrintItems();


Console.ReadLine();